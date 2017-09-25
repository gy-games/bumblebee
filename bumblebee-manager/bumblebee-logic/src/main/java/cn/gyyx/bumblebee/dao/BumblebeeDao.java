package cn.gyyx.bumblebee.dao;

import cn.gyyx.bumblebee.model.*;
import org.apache.ibatis.annotations.Param;

import java.util.List;

/**
 * @Author : east.Fu
 * @Description :
 * @Date : Created in  2017/6/28 11:12
 */
public interface BumblebeeDao {

    public List<BumblebeeUser> queryUser(@Param("email") String email, @Param("pwd") String pwd);

    public List<BumblebeeAgent> queryAllAgent();

    public List<BumblebeeAgent> queryAgent(BumblebeeAgent agent);

    public List<BumblebeeGroup> queryAllGroup();

    public BumblebeeGroup queryGroupById(int groupId);

    public BumblebeeGroup queryGroupByName(String groupName);

    public int addUser(BumblebeeUser user);

    public int editUser(BumblebeeUser user);

    public int delUser(int userId);

    public BumblebeeUser queryUserById(int userId);

    public int updateUserGroup(int groupId);

    public int delPermission(int groupId);

    public int addGroup(BumblebeeGroup group);

    public int editGroup(BumblebeeGroup group);

    public int delGroupPermission(int groupId);

    public int addGroupPermission(@Param("groupId") int groupId,@Param("mainName")String mainName);

    public int delGroup(int groupId);

    public List<OperateLog> queryLog(String userName);

    public List<OperateLog> queryLogForPage(@Param("userName") String userName,@Param("search")String search,@Param("startIndex")int startIndex,@Param("length")int length);

    public int queryLogCount(@Param("userName")String userName,@Param("search")String search);

    public List<CommandBlacklist> queryAllCommandBlacklist();

    public int addBlacklist(String command);

    public int delBlacklist(int id);

    public CommandBlacklist queryCommand(String command);

    public List<BumblebeeAgent> queryAgentByPermission(@Param("email")String email, @Param("agent") BumblebeeAgent agent);


    public List<String> queryMainNameList(@Param("email")String mainName);

    public List<String> querySubNameList(@Param("mainName")String mainName);

    public List<String> queryManagerList(@Param("email")String mainName);

    public int addOperateLog(OperateLog log);

    public int updateUserPwd(BumblebeeUser user);

    public int updateUserLoginTime(BumblebeeUser user);

    public int delAllAgent();

    public int addAgent(BumblebeeAgent agent);

    public BumblebeeConfig queryConfig();

    public int updateConfig(BumblebeeConfig config);
}
