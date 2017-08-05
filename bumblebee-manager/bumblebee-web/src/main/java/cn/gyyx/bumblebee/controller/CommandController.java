package cn.gyyx.bumblebee.controller;

import cn.gyyx.bumblebee.model.BumblebeeAgent;
import cn.gyyx.bumblebee.model.BumblebeeUser;
import cn.gyyx.bumblebee.service.BumblebeeService;
import cn.gyyx.bumblebee.service.TerminalService;
import com.alibaba.fastjson.JSON;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import javax.servlet.http.HttpServletRequest;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @Author : east.Fu
 * @Description : 控制器 CommandController
 * @Date : Created in  2017/6/27 22:31
 */
@Controller
@RequestMapping("/web/command")
public class CommandController {

    @Autowired
    private TerminalService terminalServiceImpl;

    @Autowired
    private BumblebeeService bumblebeeServiceImpl;

    @RequestMapping("/agentList")
    @ResponseBody
    public String agentList(HttpServletRequest request, BumblebeeAgent agent){
        String email =((BumblebeeUser)request.getSession().getAttribute("curUser")).getEmail();
        List<BumblebeeAgent> list=terminalServiceImpl.queryAgent(email,agent);
        Map<String,Object> data = new HashMap<String,Object>();
        data.put("data",list==null?new ArrayList<BumblebeeAgent>():list);
        return JSON.toJSONString(data);
    }

    @RequestMapping("/runCommand")
    @ResponseBody
    public String runCommand(HttpServletRequest request,String ip,String command){
        //返回结果格式： {'code':0,'data':''}}
        String email =((BumblebeeUser)request.getSession().getAttribute("curUser")).getEmail();
        Map<String,Object> result =terminalServiceImpl.runCommand(email,ip,command);
        return JSON.toJSONString(result);
    }

}
