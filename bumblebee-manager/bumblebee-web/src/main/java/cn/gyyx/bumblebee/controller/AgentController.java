package cn.gyyx.bumblebee.controller;

import cn.gyyx.bumblebee.filter.JsonFilter;
import cn.gyyx.bumblebee.model.BumblebeeAgent;
import cn.gyyx.bumblebee.service.BumblebeeService;
import com.alibaba.fastjson.JSON;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @Author : east.Fu
 * @Description : 控制器 AgentController
 * @Date : Created in  2017/6/27 16:39
 */
@Controller
@RequestMapping("/web/agent")
public class AgentController {

    @Autowired
    private BumblebeeService bumblebeeServiceImpl;

    @RequestMapping("/data")
    @ResponseBody
    public String data(Model model){
        List<BumblebeeAgent> list = bumblebeeServiceImpl.queryAllAgent();
        Map<String,Object> dt = new HashMap<String,Object>();
        dt.put("data",list);
        return JSON.toJSONString(dt,JsonFilter.filter);
    }

    @RequestMapping("/syncAgentData")
    @ResponseBody
    public String syncAgentData(){
        boolean flag=bumblebeeServiceImpl.syncAgentData();
        if(flag){
            return "success";
        }
        return "fail";
    }
}
