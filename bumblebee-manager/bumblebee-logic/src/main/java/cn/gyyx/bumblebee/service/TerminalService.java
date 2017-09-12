package cn.gyyx.bumblebee.service;

import cn.gyyx.bumblebee.model.BumblebeeAgent;

import java.util.List;
import java.util.Map;

/**
 * @Author : east.Fu
 * @Description :
 * @Date : Created in  2017/7/13 11:19
 */
public interface TerminalService {

    public List<BumblebeeAgent> queryAgent(String email, BumblebeeAgent agent);

    public Map<String, List<String>> getClientSearchCondition(String email);

    public List<String> getSubNameList(String mainName);

    public Map<String, Object> runCommand(String email,String ip,String command,String func);

    public Map<String, Object> runShell(String email,String ip,String port);

}
