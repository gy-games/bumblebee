package cn.gyyx.bumblebee.util;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.TypeReference;
import org.apache.curator.framework.CuratorFramework;
import org.apache.curator.framework.CuratorFrameworkFactory;
import org.apache.curator.retry.ExponentialBackoffRetry;
import org.apache.log4j.Logger;

import java.io.IOException;
import java.io.InputStream;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Properties;

/**
 * @ClassName: ZookeeperExcutor
 * @Description: zookeeper连接处理器
 * @author East.F
 * @date 2016年11月7日 上午9:33:48
 */
public class ZookeeperExcutor {

	private static final Logger LOG=Logger.getLogger(ZookeeperExcutor.class);

	public static boolean enabled = false;

    public static String zklist = "";

    public static int outTime = 0;

    static{
        InputStream is =null;
        try {
            is =ElvesUtil.class.getResourceAsStream("/conf.properties");
            Properties properties = new Properties();
            properties.load(is);
            enabled=Boolean.getBoolean(properties.getProperty("zookeeper.enabled"));
            zklist=properties.getProperty("zookeeper.host");
            outTime=Integer.parseInt(properties.getProperty("zookeeper.outTime"));
        }catch (IOException e){
            LOG.error("load conf.properties error,msg : "+ExceptionUtil.getStackTraceAsString(e));
        }finally {
            if(null!=is){
                try {
                    is.close();
                } catch (IOException e) {
                    LOG.error(ExceptionUtil.getStackTraceAsString(e));
                }
            }
        }
    }

    public static Map<String,Map<String,Object>> getChildrenData(String path) {
        Map<String,Map<String,Object>> data =new HashMap<String,Map<String,Object>>();
        CuratorFramework client=null;
        try {
            client = CuratorFrameworkFactory.builder()
                    .connectString(zklist).sessionTimeoutMs(outTime)
                    .connectionTimeoutMs(outTime)
                    .retryPolicy(new ExponentialBackoffRetry(1000, 3)).build();
            client.start();
            List<String> list =client.getChildren().forPath(path);
            for(String str:list){
                String value=new String(client.getData().forPath(path+"/"+str),"UTF-8");
                Map<String,Object> rs = JSON.parseObject(value,new TypeReference<Map<String, Object>>(){});
                data.put(str,rs);
            }
        }catch (Exception e){
            LOG.error(ExceptionUtil.getStackTraceAsString(e));
        }finally {
            if(client!=null){
                client.close();
            }
        }
        return data;
    }
	
}
