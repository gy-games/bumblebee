package cn.gyyx.bumblebee.service.impl;

import cn.gyyx.bumblebee.dao.BumblebeeDao;
import cn.gyyx.bumblebee.model.BumblebeeAgent;
import cn.gyyx.bumblebee.model.BumblebeeUser;
import cn.gyyx.bumblebee.model.CommandBlacklist;
import cn.gyyx.bumblebee.model.OperateLog;
import cn.gyyx.bumblebee.service.TerminalService;
import cn.gyyx.bumblebee.util.*;
import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.TypeReference;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @Author : east.Fu
 * @Description :
 * @Date : Created in  2017/7/13 11:20
 */
@Service
public class TerminalServiceImpl implements TerminalService{

    private static final Logger LOG = LoggerFactory.getLogger(TerminalServiceImpl.class);

    @Autowired
    private BumblebeeDao bumblebeeDao;

    @Override
    public List<BumblebeeAgent> queryAgent(String email, BumblebeeAgent agent) {
        if(StringUtils.isBlank(email)){
            return  null;
        }

        List<BumblebeeUser> list =bumblebeeDao.queryUser(email,"");
        if(null==list||list.size()!=1){
            return null;
        }

        BumblebeeUser user =list.get(0);
        user.setLastLoginTime(DateUtil.currentTimestamp2String(null));
        bumblebeeDao.updateUserLoginTime(user);

        if(list.get(0).getIsSystem()==1){
            return bumblebeeDao.queryAgent(agent);
        }
        return bumblebeeDao.queryAgentByPermission(email,agent);
    }


    @Override
    public Map<String, List<String>> getClientSearchCondition(String email) {
        //包含三个条件（大类，小类，负责人）
        Map<String, List<String>> result =new HashMap<String, List<String>>();
        List<BumblebeeUser> list =bumblebeeDao.queryUser(email,"");
        if(null==list||list.size()!=1){
            return result;
        }

        if(list.get(0).getIsSystem()==1){
            email=null;
        }

        List<String> mainNameList = bumblebeeDao.queryMainNameList(email);
        result.put("mainNameList",mainNameList==null?new ArrayList<String>():mainNameList);

        result.put("subNameList",new ArrayList<String>());

        List<String> managerList =bumblebeeDao.queryManagerList(email);
        result.put("managerList",managerList==null?new ArrayList<String>():managerList);
        return result;
    }

    @Override
    public List<String> getSubNameList(String mainName) {
        List<String> subNameList =bumblebeeDao.querySubNameList(mainName);
        return subNameList==null?new ArrayList<String>():subNameList;
    }

    @Override
    public Map<String, Object> runCommand(String email,String ip, String command,String func) {
        Map<String, Object> rs =new HashMap<String, Object>();

        if(StringUtils.isBlank(ip)){
            rs.put("code",-1);
            rs.put("data","ip is empty");
            return rs;
        }
        if(StringUtils.isBlank(command)){
            rs.put("code",-1);
            rs.put("data","command is empty");
            return rs;
        }

        //命令黑名单判断
        command=command.replaceAll(" +"," ").trim();
        CommandBlacklist list =bumblebeeDao.queryCommand(command);
        if(list!=null){
            rs.put("code",-1);
            rs.put("data","blacklist contains this command : "+command);
            return rs;
        }

        if(!ValidateUtil.validateIpAddress(ip)){
            rs.put("code",-1);
            rs.put("data","ip format error");
            return rs;
        }

        if(StringUtils.isBlank(email)){
            rs.put("code",-1);
            rs.put("data","operator not find");
            return rs;
        }

        //判断是否存在该用户
        List<BumblebeeUser> users =bumblebeeDao.queryUser(email,null);
        if(users==null||users.size()<=0){
            rs.put("code",-1);
            rs.put("data","operator not find");
            return rs;
        }
        String userName = users.get(0).getUserName();

        //判断该用户是否有操作该机器的权限(非系统用户判断)
        if(users.get(0).getIsSystem()==0){
            BumblebeeAgent agent =new BumblebeeAgent();
            agent.setAgentIp(ip);
            List<BumblebeeAgent> agents = bumblebeeDao.queryAgentByPermission(email,agent);
            if(null==agents||agents.size()<=0){
                rs.put("code",-1);
                rs.put("data","no operation authority of this ip:"+ip);
                return rs;
            }
        }

        //封装参数
        Map<String, Object> cmd =new HashMap<String, Object>();
        cmd.put("cmd", Base64Util.getBase64(command));

        Map<String, Object> params =new HashMap<String, Object>();
        params.put("ip",ip.trim());
//        params.put("func","excute");
        params.put("func",func);
        params.put("proxy","python|app-worker.py");
        params.put("param",JSON.toJSONString(cmd));
        params.put("timeout",30);
        //调用elves运行 app脚本，回收结果（rt同步任务）

        long startTime=System.currentTimeMillis();
        Map<String,Object> back = ElvesUtil.createElvesJob(ElvesUtil.ELVES_API_JOB_RT_URI,params);
        long endTime=System.currentTimeMillis();
        LOG.info(userName +" run command "+command+" and result :"+back);
        if(null!=back&&!"true".equals(back.get("flag"))){
            rs.put("code",-1);
            rs.put("data",back.get("error"));
            return rs;
        }else if(null!=back&&"true".equals(back.get("flag"))&&null!=back.get("result")){
            Map<String,Object> result = JSON.parseObject(back.get("result").toString(),new TypeReference<Map<String, Object>>(){});
            if(null!=result||null!=result.get("worker_message")){
                try {
                    rs = JSON.parseObject(result.get("worker_message").toString(),new TypeReference<Map<String, Object>>(){});
                    if(null!=rs.get("data")&&StringUtils.isNotBlank(rs.get("data").toString())){
                        String data= CharSetUtil.decodeUnicode(rs.get("data").toString());
                        rs.put("data",data);
                    }
                }catch (Exception e){
                    rs.put("code",-1);
                    rs.put("data",result.get("worker_message"));
                }
            }else{
                rs.put("code",-1);
                rs.put("data","elves unknow error");
            }
        }else{
            rs.put("code",-1);
            rs.put("data","elves unknow error");
        }

        OperateLog log =new OperateLog();
        log.setIp(ip).setStartTime(DateUtil.formatDate(startTime)).setEndTime(DateUtil.formatDate(endTime))
                .setCostTime((int)(endTime-startTime)).setParam(command)
                .setResult(back==null?null:JSON.toJSONString(rs)).setOperateUser(userName);
        bumblebeeDao.addOperateLog(log);
        return rs;
    }

    @Override
    public Map<String, Object> runShell(String email,String ip,String port){
        Map<String, Object> rs =new HashMap<String, Object>();

        if(StringUtils.isBlank(ip)){
            rs.put("code",-1);
            rs.put("data","ip is empty");
            return rs;
        }

        if(!ValidateUtil.validateIpAddress(ip)){
            rs.put("code",-1);
            rs.put("data","ip format error");
            return rs;
        }

        if(StringUtils.isBlank(port)||!ValidateUtil.validateNumber(port)){
            rs.put("code",-1);
            rs.put("data","port format error");
            return rs;
        }

        if(StringUtils.isBlank(email)){
            rs.put("code",-1);
            rs.put("data","operator not find");
            return rs;
        }

        //判断是否存在该用户
        List<BumblebeeUser> users =bumblebeeDao.queryUser(email,null);
        if(users==null||users.size()<=0){
            rs.put("code",-1);
            rs.put("data","operator not find");
            return rs;
        }
        String userName = users.get(0).getUserName();

        //判断该用户是否有操作该机器的权限(非系统用户判断)
        if(users.get(0).getIsSystem()==0){
            BumblebeeAgent agent =new BumblebeeAgent();
            agent.setAgentIp(ip);
            List<BumblebeeAgent> agents = bumblebeeDao.queryAgentByPermission(email,agent);
            if(null==agents||agents.size()<=0){
                rs.put("code",-1);
                rs.put("data","no operation authority of this ip:"+ip);
                return rs;
            }
        }


        //封装参数
        Map<String, Object> cmd =new HashMap<String, Object>();
        cmd.put("email", email);
        cmd.put("port", port);

        Map<String, Object> params =new HashMap<String, Object>();
        params.put("ip",ip.trim());
        params.put("func","shell");
        params.put("proxy","python|app-worker.py");
        params.put("param",JSON.toJSONString(cmd));
        params.put("timeout",60);
        //调用elves运行 app脚本，回收结果（rt同步任务）

        long startTime=System.currentTimeMillis();
        Map<String,Object> back = ElvesUtil.createElvesJob(ElvesUtil.ELVES_API_JOB_RT_URI,params);
        long endTime=System.currentTimeMillis();
        LOG.info(userName +" run shell ip : "+ip+" and result : "+back);
        if(null!=back&&!"true".equals(back.get("flag"))){
            rs.put("code",-1);
            rs.put("data",back.get("error"));
            return rs;
        }else if(null!=back&&"true".equals(back.get("flag"))&&null!=back.get("result")){
            Map<String,Object> result = JSON.parseObject(back.get("result").toString(),new TypeReference<Map<String, Object>>(){});
            if(null!=result||null!=result.get("worker_message")){
                try {
                    rs = JSON.parseObject(result.get("worker_message").toString(),new TypeReference<Map<String, Object>>(){});
                }catch (Exception e){
                    rs.put("code",-1);
                    rs.put("data",result.get("worker_message"));
                }
            }else{
                rs.put("code",-1);
                rs.put("data","elves unknow error");
            }
        }else{
            rs.put("code",-1);
            rs.put("data","elves unknow error");
        }

        OperateLog log =new OperateLog();
        log.setIp(ip).setStartTime(DateUtil.formatDate(startTime)).setEndTime(DateUtil.formatDate(endTime))
                .setCostTime((int)(endTime-startTime)).setParam(JSON.toJSONString(cmd))
                .setResult(back==null?null:JSON.toJSONString(rs)).setOperateUser(userName);
        bumblebeeDao.addOperateLog(log);

        return rs;
    }
}
