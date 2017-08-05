package cn.gyyx.bumblebee.model;

import java.io.Serializable;

/**
 * @Author : east.Fu
 * @Description : 用户 bumblebee_user 表
 * @Date : Created in  2017/6/28 11:33
 */
public class BumblebeeUser implements Serializable{

    /* 主键ID */
    private int userId;

    /* 姓名 */
    private String userName;

    /* 邮箱 */
    private String email;

    /* 密码 */
    private String pwd;

    /* 创建时间 */
    private String createTime;

    /* 创建者 */
    private String createUser;

    /* 最后登录时间 */
    private String lastLoginTime;

    /* 用户组Id */
    private Integer groupId;

    /*  用户组名 */
    private String groupName;

    /* 是否为系统管理员：0-不是，1-是 */
    private Integer isSystem;

    public int getUserId() {
        return userId;
    }

    public BumblebeeUser setUserId(int userId) {
        this.userId = userId;
        return this;
    }

    public String getUserName() {
        return userName;
    }

    public BumblebeeUser setUserName(String userName) {
        this.userName = userName;
        return this;
    }

    public String getEmail() {
        return email;
    }

    public BumblebeeUser setEmail(String email) {
        this.email = email;
        return this;
    }

    public String getPwd() {
        return pwd;
    }

    public BumblebeeUser setPwd(String pwd) {
        this.pwd = pwd;
        return this;
    }

    public String getCreateTime() {
        return createTime;
    }

    public BumblebeeUser setCreateTime(String createTime) {
        this.createTime = createTime;
        return this;
    }

    public String getCreateUser() {
        return createUser;
    }

    public BumblebeeUser setCreateUser(String createUser) {
        this.createUser = createUser;
        return this;
    }

    public String getLastLoginTime() {
        return lastLoginTime;
    }

    public BumblebeeUser setLastLoginTime(String lastLoginTime) {
        this.lastLoginTime = lastLoginTime;
        return this;
    }

    public Integer getIsSystem() {
        return isSystem;
    }

    public BumblebeeUser setIsSystem(Integer isSystem) {
        this.isSystem = isSystem;
        return this;
    }

    public Integer getGroupId() {
        return groupId;
    }

    public BumblebeeUser setGroupId(Integer groupId) {
        this.groupId = groupId;
        return this;
    }

    public String getGroupName() {
        return groupName;
    }

    public void setGroupName(String groupName) {
        this.groupName = groupName;
    }
}
