package cn.gyyx.bumblebee.webservice;

import cn.gyyx.bumblebee.filter.JsonFilter;
import cn.gyyx.bumblebee.model.BumblebeeAgent;
import cn.gyyx.bumblebee.model.BumblebeeConfig;
import cn.gyyx.bumblebee.service.BumblebeeService;
import cn.gyyx.bumblebee.service.TerminalService;
import com.alibaba.fastjson.JSON;
import org.apache.commons.lang3.StringUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @Author : east.Fu
 * @Description : bumblebee 客户端 http接口
 * @Date : Created in  2017/6/27 22:31
 */
@Controller
@RequestMapping("/terminal")
public class ClientService {

    @Autowired
    private TerminalService terminalServiceImpl;

    @Autowired
    private BumblebeeService bumblebeeServiceImpl;

    @RequestMapping("/login")
    @ResponseBody
    public String clientLogin(String version){
        Map<String,String> rs=new HashMap<String,String>();

        BumblebeeConfig config=bumblebeeServiceImpl.queryConfig();

        if(StringUtils.isBlank(version)){
            rs.put("code","1");
            rs.put("msg","登录失败，客户端版本号异常，请联系管理员！");
            return JSON.toJSONString(rs, JsonFilter.filter);
        }

        if(null==config){
            rs.put("code","1");
            rs.put("msg","登录失败，服务端异常，请联系管理员！");
            return JSON.toJSONString(rs, JsonFilter.filter);
        }

        if("1".equals(config.getIgnoreFlag())||version.equals(config.getClientVersion())){
            rs.put("code","0");
            rs.put("msg","");
        }else {
            rs.put("code","1");
            rs.put("msg",config.getPromptContent());
        }
        return JSON.toJSONString(rs, JsonFilter.filter);
    }

    @RequestMapping("/agentList")
    @ResponseBody
    public String agentList(String email,BumblebeeAgent agent){
        List<BumblebeeAgent> list=terminalServiceImpl.queryAgent(email,agent);
        return JSON.toJSONString(list==null?new ArrayList<BumblebeeAgent>():list);
    }

    @RequestMapping("/agentCondition")
    @ResponseBody
    public String mainNameList(String email){
        Map<String,List<String>> list =terminalServiceImpl.getClientSearchCondition(email);
        return JSON.toJSONString(list);
    }

    @RequestMapping("/subNameList")
    @ResponseBody
    public String subNameList(String mainName){
        List<String> list =terminalServiceImpl.getSubNameList(mainName);
        return JSON.toJSONString(list);
    }

    @RequestMapping("/runCommand")
    @ResponseBody
    public String runCommand(String email,String ip,String command){
        ip="10.15.21.1";
        //返回结果格式： {'code':0,'data':''}}
        Map<String,Object> result =terminalServiceImpl.runCommand(email,ip,command,"excute");
        return JSON.toJSONString(result);
    }
    @RequestMapping("/runDaemonCommand")
    @ResponseBody
    public String runDaemonCommand (String email,String ip,String command){
        //返回结果格式： {'code':0,'data':''}}
        Map<String,Object> result =terminalServiceImpl.runCommand(email,ip,command,"excute_daemon");
        return JSON.toJSONString(result);
    }
    @RequestMapping("/runShell")
    @ResponseBody
    public String runShell(String email,String ip,String port){
        //返回结果格式： {'code':0,'data':''}}
        Map<String,Object> result =terminalServiceImpl.runShell(email,ip,port);
        return JSON.toJSONString(result);
    }
}
