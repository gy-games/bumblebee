package cn.gyyx.bumblebee.model;

import java.io.Serializable;

/**
 * @Author : east.Fu
 * @Description : 操作日志 operate_log 表
 * @Date : Created in  2017/6/28 17:24
 */
public class OperateLog implements Serializable{

    /* 日志ID */
    private int logId;

    /* 操作的机器IP */
    private String ip;

    /* 参数 */
    private String param;

    /* 返回结果 */
    private String result;

    /* 开始时间 */
    private String startTime;

    /* 结束时间 */
    private String endTime;

    /* 耗时（毫秒ms） */
    private int costTime;

    /* 操作人 */
    private String operateUser;


    public int getLogId() {
        return logId;
    }

    public void setLogId(int logId) {
        this.logId = logId;
    }

    public String getIp() {
        return ip;
    }

    public OperateLog setIp(String ip) {
        this.ip = ip;
        return this;
    }

    public String getParam() {
        return param;
    }

    public OperateLog setParam(String param) {
        this.param = param;
        return this;
    }

    public String getResult() {
        return result;
    }

    public OperateLog setResult(String result) {
        this.result = result;
        return this;
    }

    public String getStartTime() {
        return startTime;
    }

    public OperateLog setStartTime(String startTime) {
        this.startTime = startTime;
        return this;
    }

    public String getEndTime() {
        return endTime;
    }

    public OperateLog setEndTime(String endTime) {
        this.endTime = endTime;
        return this;
    }

    public int getCostTime() {
        return costTime;
    }

    public OperateLog setCostTime(int costTime) {
        this.costTime = costTime;
        return this;
    }

    public String getOperateUser() {
        return operateUser;
    }

    public OperateLog setOperateUser(String operateUser) {
        this.operateUser = operateUser;
        return this;
    }
}
