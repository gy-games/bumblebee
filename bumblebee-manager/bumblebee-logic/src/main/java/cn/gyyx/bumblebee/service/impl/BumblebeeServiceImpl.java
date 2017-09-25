package cn.gyyx.bumblebee.service.impl;

import cn.gyyx.bumblebee.dao.BumblebeeDao;
import cn.gyyx.bumblebee.model.*;
import cn.gyyx.bumblebee.service.BumblebeeService;
import cn.gyyx.bumblebee.util.DateUtil;
import cn.gyyx.bumblebee.util.HttpUtil;
import cn.gyyx.bumblebee.util.Md5Util;
import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.TypeReference;
import org.apache.commons.lang3.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @Author : east.Fu
 * @Description : BumblebeeService 实现类
 * @Date : Created in  2017/6/28 11:11
 */
@Service
public class BumblebeeServiceImpl implements BumblebeeService{

    private static final Logger LOG=Logger.getLogger(BumblebeeServiceImpl.class);

    @Autowired
    private BumblebeeDao bumblebeeDao;

    @Override
    public BumblebeeUser queryUser(String email){
        List<BumblebeeUser> users =bumblebeeDao.queryUser(email,null);
        if(users!=null&&users.size()==1){
            return users.get(0);
        }
        return null;
    }

    @Override
    public BumblebeeUser login(String email, String pwd) {
        if(StringUtils.isBlank(email)||StringUtils.isBlank(pwd)){
            return null;
        }
        List<BumblebeeUser> users =bumblebeeDao.queryUser(email,pwd);
        if(users!=null&&users.size()==1){
            BumblebeeUser user =users.get(0);
            user.setLastLoginTime(DateUtil.currentTimestamp2String(null));
            bumblebeeDao.updateUserLoginTime(user);
            return users.get(0);
        }
        return null;
    }


    @Override
    public List<BumblebeeAgent> queryAllAgent() {
        return bumblebeeDao.queryAllAgent();
    }

    @Override
    public List<BumblebeeUser> queryAllUser() {
        return bumblebeeDao.queryUser(null,null);
    }

    @Override
    public Map<String,String> addUser(String currUserName,String userName, String email, Integer groupId) {
        Map<String,String> result =new HashMap<String,String>();

        /* 0-成功， 1-失败 */
        if(StringUtils.isBlank(userName)||StringUtils.isBlank(email)){
            result.put("code","1");
            result.put("msg","操作失败：请联系管理员！");
            return result;
        }

        List<BumblebeeUser> users=bumblebeeDao.queryUser(email,"");
        if(null!=users&&users.size()>0){
            result.put("code","1");
            result.put("msg","操作失败：邮箱已经被使用！");
            return result;
        }

        if(null!=groupId&&null==bumblebeeDao.queryGroupById(groupId)){
            result.put("code","1");
            result.put("msg","操作失败：用户组不存在！");
            return result;
        }

        BumblebeeUser user =new BumblebeeUser();
        user.setUserName(userName).setEmail(email).setCreateUser(currUserName).
                setIsSystem(0).setPwd(Md5Util.MD5("123456")).setGroupId(groupId);
        int flag =bumblebeeDao.addUser(user);
        if(flag>0){
            result.put("code","0");
            result.put("msg","操作成功！");
            return result;
        }

        result.put("code","1");
        result.put("msg","操作失败：请联系管理员！");
        return result;
    }

    @Override
    public Map<String, String> editUser(Integer userId, String userName, String email, Integer groupId) {
        Map<String,String> result =new HashMap<String,String>();

        /* 0-成功， 1-失败 */
        if(null==userId||StringUtils.isBlank(userName)||StringUtils.isBlank(email)){
            result.put("code","1");
            result.put("msg","操作失败：请联系管理员！");
            return result;
        }

        List<BumblebeeUser> users=bumblebeeDao.queryUser(email,"");
        if(null!=users&&users.size()>0&&users.get(0).getUserId()!=userId){
            result.put("code","1");
            result.put("msg","操作失败：邮箱已经被使用！");
            return result;
        }

        if(null!=groupId&&null==bumblebeeDao.queryGroupById(groupId)){
            result.put("code","1");
            result.put("msg","操作失败：用户组不存在！");
            return result;
        }

        BumblebeeUser user =new BumblebeeUser();
        user.setUserName(userName).setEmail(email).setGroupId(groupId)
        .setUserId(userId);
        int flag =bumblebeeDao.editUser(user);
        if(flag>0){
            result.put("code","0");
            result.put("msg","操作成功！");
            return result;
        }

        result.put("code","1");
        result.put("msg","操作失败：请联系管理员！");
        return result;
    }

    @Override
    public String delUser(Integer userId) {
        if(null==userId){
            return "操作失败：请联系管理员！";
        }
        BumblebeeUser user =bumblebeeDao.queryUserById(userId);
        if(user==null){
            return "操作失败：未找到该用户！";
        }
        if(user.getIsSystem()==1){
            return "操作失败：系统用户不允许被删除！";
        }

        bumblebeeDao.delUser(userId);
        return "success";

    }

    @Override
    @Transactional(readOnly = false,rollbackFor = Exception.class)
    public Map<String, String> addGroup(String userName,String groupName, String desc,String mainNameList) {
        Map<String,String> result =new HashMap<String,String>();

        /* 0-成功， 1-失败 */
        if(StringUtils.isBlank(groupName)){
            result.put("code","1");
            result.put("msg","操作失败，请联系管理员");
            return result;
        }

        BumblebeeGroup rs=bumblebeeDao.queryGroupByName(groupName);
        if(rs!=null){
            result.put("code","1");
            result.put("msg","操作失败：用户组名已存在！");
            return result;
        }

        BumblebeeGroup group =new BumblebeeGroup();
        group.setCreateUser(userName).setGroupName(groupName).setDesc(desc);
        bumblebeeDao.addGroup(group);

        int groupId= group.getGroupId();
        bumblebeeDao.delGroupPermission(groupId);
        if(StringUtils.isNotBlank(mainNameList)){
            String mainName [] =mainNameList.split(",");
            for(String m :mainName){
                bumblebeeDao.addGroupPermission(groupId,m);
            }
        }

        result.put("code","0");
        result.put("msg","操作成功！");
        return result;
    }

    @Override
    public Map<String, String> editGroup(String groupName, String desc, Integer groupId, String mainNameList) {
        Map<String,String> result =new HashMap<String,String>();

        BumblebeeGroup rs=bumblebeeDao.queryGroupByName(groupName);
        if(rs!=null&&rs.getGroupId()!=groupId){
            result.put("code","1");
            result.put("msg","操作失败：用户组名已存在！");
            return result;
        }

        BumblebeeGroup group =new BumblebeeGroup();
        group.setGroupName(groupName).setDesc(desc).setGroupId(groupId);

        bumblebeeDao.editGroup(group);

        bumblebeeDao.delGroupPermission(groupId);
        if(StringUtils.isNotBlank(mainNameList)){
            String mainName [] =mainNameList.split(",");
            for(String m :mainName){
                bumblebeeDao.addGroupPermission(groupId,m);
            }
        }

        result.put("code","0");
        result.put("msg","操作成功！");
        return result;
    }

    @Override
    @Transactional(rollbackFor = Exception.class)
    public String delGroup(Integer groupId) {
        if(null==groupId){
            return "fail";
        }
        //删除组
        bumblebeeDao.delGroup(groupId);
        //设置用户组为null
        bumblebeeDao.updateUserGroup(groupId);
        //删除组绑定的权限
        bumblebeeDao.delPermission(groupId);
        return "fail";
    }

    @Override
    public List<BumblebeeGroup> queryAllGroup() {
        return bumblebeeDao.queryAllGroup();
    }

    @Override
    public Pagination<OperateLog> queryLogForPage(TableModelVO tableModelVO1,BumblebeeUser user) {
        int startIndex=tableModelVO1.getStart();
        int length=tableModelVO1.getLength();
        String search=tableModelVO1.getSearch().get("value");

        int count=0;
        List<OperateLog> logs =new ArrayList<OperateLog>();
        if(user.getIsSystem()==1){
            count=bumblebeeDao.queryLogCount(null,search);
            logs = bumblebeeDao.queryLogForPage(null,search,startIndex,length);
        }else{
            count=bumblebeeDao.queryLogCount(user.getUserName(),search);
            logs = bumblebeeDao.queryLogForPage(user.getUserName(),search,startIndex,length);
        }
        Pagination<OperateLog> back =new Pagination<OperateLog>();
        back.setData(logs).setDraw(tableModelVO1.getDraw()).setRecordsTotal(count).setRecordsFiltered(count);
        return back;
    }


    @Override
    public List<CommandBlacklist> queryCommandBlacklist() {
        List<CommandBlacklist> list =bumblebeeDao.queryAllCommandBlacklist();
        return list==null?new ArrayList<CommandBlacklist>():list;
    }

    @Override
    public Map<String, String> addBlacklist(String command) {
        Map<String,String> result =new HashMap<String,String>();
        if(StringUtils.isBlank(command)){
            result.put("code","1");
            result.put("msg","操作失败：请联系管理员！");
            return result;
        }

        CommandBlacklist list = bumblebeeDao.queryCommand(command);
        if(list!=null){
            result.put("code","1");
            result.put("msg","操作失败：该命令已经存在！");
            return result;
        }
        int flag =bumblebeeDao.addBlacklist(command);
        if(flag>0){
            result.put("code","0");
            result.put("msg","操作成功！");
            return result;
        }

        result.put("code","1");
        result.put("msg","操作失败：请联系管理员！");
        return result;
    }

    @Override
    public String delBlacklist(Integer id) {
        if(null==id){
            return "操作失败：请联系管理员！";
        }
        bumblebeeDao.delBlacklist(id);
        return "success";
    }

    @Override
    public List<String> getMainNameList() {
        List<String> mainNameList= bumblebeeDao.queryMainNameList(null);
        return mainNameList==null?new ArrayList<String>():mainNameList;
    }

    @Override
    public boolean updatePwd(BumblebeeUser user) {
        bumblebeeDao.updateUserPwd(user);
        return true;
    }

    @Override
    @Transactional(readOnly = false,rollbackFor = Exception.class)
    public boolean syncAgentData(){
        String syncUrl=null;

        BumblebeeConfig config =bumblebeeDao.queryConfig();
        if(config!=null){
            syncUrl=config.getSyncAgentUrl();
        }

        if(StringUtils.isNotBlank(syncUrl)){
            String result= HttpUtil.sendGet(syncUrl,null);
            if(StringUtils.isNotBlank(result)){
                Map<String,String> rs = JSON.parseObject(result,new TypeReference<Map<String,String>>(){});
                List<Map<String,String>> dt =JSON.parseObject(rs.get("data"),new TypeReference<List<Map<String,String>>>(){});
                //删除所有的agent
                bumblebeeDao.delAllAgent();
                //添加agent
                String updateTime=DateUtil.currentTimestamp2String(null);
                for(Map<String,String> m:dt){
                    String ip=m.get("agent_ip")==null?"":m.get("agent_ip");
                    String mainName=m.get("main_name")==null?"":m.get("main_name");
                    if(StringUtils.isBlank(ip)||StringUtils.isBlank(mainName)){
                        //ip和一级分类必须有
                        continue;
                    }
                    String asset=m.get("asset")==null?"":m.get("asset");
                    String agentName=m.get("agent_name")==null?"":m.get("agent_name");
                    String manager=m.get("manager")==null?"":m.get("manager");
                    String subName=m.get("sub_name")==null?"":m.get("sub_name");
                    String os=m.get("os")==null?"":m.get("os");
                    BumblebeeAgent agent =new BumblebeeAgent();
                    agent.setAgentIp(ip).setMainName(mainName).setAgentName(agentName)
                            .setAsset(asset).setManager(manager).setSubName(subName)
                            .setOs(os).setUpdateTime(updateTime);
                    bumblebeeDao.addAgent(agent);
                }
                return true;
            }
        }
        return false;
    }

    @Override
    public BumblebeeConfig queryConfig(){
        return bumblebeeDao.queryConfig();
    }

    @Override
    public boolean updateConfig(String property,String value){
        if(StringUtils.isEmpty(property)){
            return false;
        }
        BumblebeeConfig config =new BumblebeeConfig();
        if("syncAgentUrl".equals(property)){
            config.setSyncAgentUrl(value);
        }else if("clientVersion".equals(property)){
            config.setClientVersion(value);
        }else if("ignoreFlag".equals(property)){
            config.setIgnoreFlag(value);
        }else if("promptContent".equals(property)){
            config.setPromptContent(value);
        }else{
            return false;
        }
        bumblebeeDao.updateConfig(config);
        return true;
    }
}
