package cn.gyyx.bumblebee.controller;

import cn.gyyx.bumblebee.filter.JsonFilter;
import cn.gyyx.bumblebee.model.BumblebeeConfig;
import cn.gyyx.bumblebee.service.BumblebeeService;
import com.alibaba.fastjson.JSON;
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
 * @Description : 控制器 ConfigController
 * @Date : Created in  2017/6/27 16:39
 */
@Controller
@RequestMapping("/web/config")
public class ConfigController {

    @Autowired
    private BumblebeeService bumblebeeServiceImpl;

    @RequestMapping("/data")
    @ResponseBody
    public String data(){
        BumblebeeConfig config =bumblebeeServiceImpl.queryConfig();
        List<Map<String,String>> data=new ArrayList<Map<String,String>>();
        Map<String,String> mp1=new HashMap<>();
        mp1.put("property","clientVersion");
        mp1.put("title","客户端版本号");
        mp1.put("value",config==null?"":config.getClientVersion());
        data.add(mp1);

        Map<String,String> mp2=new HashMap<>();
        mp2.put("property","syncAgentUrl");
        mp2.put("title","同步接口地址");
        mp2.put("value",config==null?"":config.getSyncAgentUrl());
        data.add(mp2);

        Map<String,String> mp3=new HashMap<>();
        mp3.put("property","ignoreFlag");
        mp3.put("title","忽略版本更新");
        mp3.put("value",config==null?"":config.getIgnoreFlag());
        data.add(mp3);

        Map<String,String> mp4=new HashMap<>();
        mp4.put("property","promptContent");
        mp4.put("title","登录失败提示信息");
        mp4.put("value",config==null?"":config.getPromptContent());
        data.add(mp4);

        Map<String,Object> back = new HashMap<String,Object>();
        back.put("data",data);
        return JSON.toJSONString(back, JsonFilter.filter);
    }

    @RequestMapping("/edit")
    @ResponseBody
    public String add(String property,String value){
        boolean flag = bumblebeeServiceImpl.updateConfig(property,value);
        return flag?"success":"fail";
    }
}
