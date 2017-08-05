package cn.gyyx.bumblebee.model;

import java.io.Serializable;

/**
 * @Author : east.Fu
 * @Description : 命令黑名单 command_blacklist 表
 * @Date : Created in  2017/6/28 11:15
 */
public class CommandBlacklist implements Serializable{

    /* id */
    private int id;

    /* 命令 */
    private String command;


    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getCommand() {
        return command;
    }

    public void setCommand(String command) {
        this.command = command;
    }

}
