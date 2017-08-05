package cn.gyyx.bumblebee.util;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.TypeReference;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.io.InputStream;
import java.util.*;

/**
 * @Author : east.Fu
 * @Description : elves 接口 调用工具类 , 参考文档：https://gy-games.gitbooks.io/elves
 * @Date : Created in  2017/7/24 22:08
 */
public class ElvesUtil {

    private static final Logger LOG = LoggerFactory.getLogger(ElvesUtil.class);

    private static String ELVES_AUTH_ID="";

    private static String ELVES_AUTH_KEY="";

    private static String ELVES_APP_INSTRUCT="";

    private static String ELVES_API_HOST="";

    /* elves info api */
    public static final String ELVES_API_INFO_APP_URI = "/api/v2/info/app";
    public static final String ELVES_API_INFO_AGENTS_URI = "/api/v2/info/agents";
    public static final String ELVES_API_INFO_AGENTS_DETAIL_URI = "/api/v2/info/agents/detail";

    /* elves rt job api */
    public static final String ELVES_API_JOB_RT_URI = "/api/v2/rt/exec";

    /* elves queue job  api */
    public static final String ELVES_API_JOB_QUEUE_CREATE_URI = "/api/v2/queue/create";
    public static final String ELVES_API_JOB_QUEUE_ADD_TASK_URI = "/api/v2/queue/addtask";
    public static final String ELVES_API_JOB_QUEUE_COMMIT_URI = "/api/v2/queue/commit";
    public static final String ELVES_API_JOB_QUEUE_STOP_URI = "/api/v2/queue/stop";
    public static final String ELVES_API_JOB_QUEUE_RESULT_URI = "/api/v2/queue/result";
    public static final String ELVES_API_JOB_QUEUE_QKS_URI = "/api/v2/queue/qksqueue";

    /* elves cron job api */
    public static final String ELVES_API_JOB_CRON_ADD_URI = "/api/v2/cron/add";
    public static final String ELVES_API_JOB_CRON_START_URI = "/api/v2/cron/start";
    public static final String ELVES_API_JOB_CRON_STOP_URI = "/api/v2/cron/stop";
    public static final String ELVES_API_JOB_CRON_DELETE_URI = "/api/v2/cron/delete";
    public static final String ELVES_API_JOB_CRON_DETAIL_URI = "/api/v2/cron/detail";


    static{
        InputStream is =null;
        try {
            is =ElvesUtil.class.getResourceAsStream("/conf.properties");
            Properties properties = new Properties();
            properties.load(is);
            ELVES_AUTH_ID=properties.getProperty("elves.auth.id");
            ELVES_AUTH_KEY=properties.getProperty("elves.auth.key");
            ELVES_API_HOST=properties.getProperty("elves.api.host");
            ELVES_APP_INSTRUCT=properties.getProperty("elves.app");
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

    /**
     * @param apiUri    elves接口的uri地址
     * @param params   接口参数
     * @return
     */
    public static Map<String,Object> createElvesJob(String apiUri , Map<String,Object> params){
        //添加必传参数 auth_id 、timestamp
        if(null==params){
            params=new HashMap<String, Object>();
        }
        params.put("auth_id", ElvesUtil.ELVES_AUTH_ID);
        params.put("timestamp", (System.currentTimeMillis()/1000)+"");
        if(null==params.get("mode")||StringUtils.isBlank(params.get("mode").toString())){
            params.put("mode","ssnp");
        }
        if(null==params.get("app")||StringUtils.isBlank(params.get("app").toString())){
            params.put("app",ElvesUtil.ELVES_APP_INSTRUCT);
        }
        //可选参数
        if(null==params.get("timeout")||StringUtils.isBlank(params.get("timeout").toString())){
            params.put("timeout","60");
        }
        LOG.debug("params :"+ JSON.toJSONString(params));
        //制作签名
        StringBuffer sortUri=new StringBuffer(apiUri);
        if(params.size()>0){
            sortUri.append("?");
            Set<String> keys=params.keySet();
            List<String> list=new ArrayList<String>();
            list.addAll(keys);
            Collections.sort(list);
            for(String k:list){
                sortUri.append(k+"=");
                sortUri.append(params.get(k)!=null?params.get(k):"");
                sortUri.append("&");
            }
            if(sortUri.length()>0){
                sortUri.deleteCharAt(sortUri.length()-1);
            }
        }
        sortUri.append(ElvesUtil.ELVES_AUTH_KEY);
        //MD5
        String sign=Md5Util.MD5(sortUri.toString());
        LOG.debug("sign uri : "+sortUri);
        LOG.debug("sign : "+sign);
        params.put("sign_type","MD5");
        params.put("sign",sign);
        //封装参数，post 发送
        String result=HttpUtil.sendPost(ElvesUtil.ELVES_API_HOST+apiUri,params);
        LOG.info("elves response result : "+result);
        if(StringUtils.isNotBlank(result)){
            Map<String,Object> back =JSON.parseObject(result,new TypeReference<Map<String, Object>>(){});
            return back;
        }
        return null;
    }
}
