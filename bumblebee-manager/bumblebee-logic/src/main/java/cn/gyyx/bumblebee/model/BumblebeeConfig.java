package cn.gyyx.bumblebee.model;

/**
 * @Author : east.Fu
 * @Description : 系统配置 bumblebee_config 表
 * @Date : Created in  2017/8/17 15:34
 */
public class BumblebeeConfig {

    /* 同步agent机器接口地址 */
    private String syncAgentUrl;

    /* 客户端当前版本号 */
    private String clientVersion;

    /* 忽略版本更新：`0`-不可忽略，`1`-可忽略 */
    private String ignoreFlag;

    /* 登录失败提示信息 */
    private String promptContent;

    public String getSyncAgentUrl() {
        return syncAgentUrl;
    }

    public void setSyncAgentUrl(String syncAgentUrl) {
        this.syncAgentUrl = syncAgentUrl;
    }

    public String getClientVersion() {
        return clientVersion;
    }

    public void setClientVersion(String clientVersion) {
        this.clientVersion = clientVersion;
    }

    public String getIgnoreFlag() {
        return ignoreFlag;
    }

    public void setIgnoreFlag(String ignoreFlag) {
        this.ignoreFlag = ignoreFlag;
    }

    public String getPromptContent() {
        return promptContent;
    }

    public void setPromptContent(String promptContent) {
        this.promptContent = promptContent;
    }
}
