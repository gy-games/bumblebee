package cn.gyyx.bumblebee.model;

import java.io.Serializable;

/**
 * @Author : east.Fu
 * @Description : 分组 bumblebee_group 表
 * @Date : Created in  2017/6/28 17:23
 */
public class BumblebeeGroup implements Serializable{

    /* 分组ID */
    private int groupId;

    /* 组名 */
    private String groupName;

    /* 创建时间 */
    private String createTime;

    /* 创建人 */
    private String createUser;

    /* 描述 */
    private String desc;

    private String mainNameList;  //授权的一级分类

    public int getGroupId() {
        return groupId;
    }

    public void setGroupId(int groupId) {
        this.groupId = groupId;
    }

    public String getGroupName() {
        return groupName;
    }

    public BumblebeeGroup setGroupName(String groupName) {
        this.groupName = groupName;
        return this;
    }

    public String getCreateTime() {
        return createTime;
    }

    public BumblebeeGroup setCreateTime(String createTime) {
        this.createTime = createTime;
        return this;
    }

    public String getCreateUser() {
        return createUser;
    }

    public BumblebeeGroup setCreateUser(String createUser) {
        this.createUser = createUser;
        return this;
    }

    public String getDesc() {
        return desc;
    }

    public BumblebeeGroup setDesc(String desc) {
        this.desc = desc;
        return this;
    }

    public String getMainNameList() {
        return mainNameList;
    }

    public void setMainNameList(String mainNameList) {
        this.mainNameList = mainNameList;
    }
}
