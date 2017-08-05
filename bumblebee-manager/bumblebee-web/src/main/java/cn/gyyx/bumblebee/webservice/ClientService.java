package cn.gyyx.bumblebee.webservice;

import cn.gyyx.bumblebee.model.BumblebeeAgent;
import cn.gyyx.bumblebee.service.BumblebeeService;
import cn.gyyx.bumblebee.service.TerminalService;
import cn.gyyx.bumblebee.util.Md5Util;
import com.alibaba.fastjson.JSON;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.ArrayList;
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
    public String clientLogin(String email,String pwd){
        if(null!=bumblebeeServiceImpl.login(email, Md5Util.MD5(pwd))){
            return "success";
        }
        return "fail";
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
        //返回结果格式： {'code':0,'data':''}}
        Map<String,Object> result =terminalServiceImpl.runCommand(email,ip,command);
        return JSON.toJSONString(result);
    }


}
