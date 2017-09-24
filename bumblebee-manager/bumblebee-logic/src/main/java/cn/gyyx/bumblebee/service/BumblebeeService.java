package cn.gyyx.bumblebee.service;

import cn.gyyx.bumblebee.model.*;

import java.util.List;
import java.util.Map;

/**
 * @Author : east.Fu
 * @Description :
 * @Date : Created in  2017/6/28 11:11
 */
public interface BumblebeeService {

    public BumblebeeUser queryUser(String email);

    public BumblebeeUser login(String email,String pwd);

    public List<BumblebeeUser> queryAllUser();

    public Map<String,String> addUser(String currUserName,String userName, String email, Integer groupId);

    public Map<String,String> editUser(Integer userId,String userName, String email, Integer groupId);

    public String delUser(Integer userId);

    public Map<String,String> addGroup(String userName,String groupName, String desc,String mainNameList);

    public Map<String,String> editGroup(String groupName, String desc,Integer groupId,String mainNameList);

    public String delGroup(Integer groupId);

    public List<BumblebeeAgent> queryAllAgent();

    public List<BumblebeeGroup> queryAllGroup();

    public Pagination<OperateLog> queryLogForPage(TableModelVO tableModelVO1,BumblebeeUser user);

    //blacklist 相关
    public List<CommandBlacklist> queryCommandBlacklist();

    public Map<String,String> addBlacklist(String command);

    public String delBlacklist(Integer id);

    public List<String> getMainNameList();

    public boolean updatePwd(BumblebeeUser user);

    public boolean syncAgentData();

    public BumblebeeConfig queryConfig();

    public boolean updateConfig(String property,String value);
}
