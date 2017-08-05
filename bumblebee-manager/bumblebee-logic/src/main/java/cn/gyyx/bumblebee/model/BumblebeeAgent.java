package cn.gyyx.bumblebee.model;

import java.io.Serializable;

/**
 * @Author : east.Fu
 * @Description : agent信息 bumblebee_agent 表
 * @Date : Created in  2017/6/30 14:59
 */
public class BumblebeeAgent implements Serializable{

    /* AgentIP */
    private String agentIp;

    /* Agent名称 */
    private String agentName;

    /* 资产号 */
    private String asset;

    /* 负责人 */
    private String manager;

    /* 一级分类 */
    private String mainName;

    /* 二级分类 */
    private String subName;

    public String getAgentIp() {
        return agentIp;
    }

    public BumblebeeAgent setAgentIp(String agentIp) {
        this.agentIp = agentIp;
        return this;
    }

    public String getAgentName() {
        return agentName;
    }

    public BumblebeeAgent setAgentName(String agentName) {
        this.agentName = agentName;
        return this;
    }

    public String getAsset() {
        return asset;
    }

    public BumblebeeAgent setAsset(String asset) {
        this.asset = asset;
        return this;
    }

    public String getManager() {
        return manager;
    }

    public BumblebeeAgent setManager(String manager) {
        this.manager = manager;
        return this;
    }

    public String getMainName() {
        return mainName;
    }

    public BumblebeeAgent setMainName(String mainName) {
        this.mainName = mainName;
        return this;
    }

    public String getSubName() {
        return subName;
    }

    public BumblebeeAgent setSubName(String subName) {
        this.subName = subName;
        return this;
    }

}
