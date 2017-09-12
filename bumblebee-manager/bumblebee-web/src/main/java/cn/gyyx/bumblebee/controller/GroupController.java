package cn.gyyx.bumblebee.controller;

import cn.gyyx.bumblebee.filter.JsonFilter;
import cn.gyyx.bumblebee.model.BumblebeeGroup;
import cn.gyyx.bumblebee.model.BumblebeeUser;
import cn.gyyx.bumblebee.service.BumblebeeService;
import com.alibaba.fastjson.JSON;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import javax.servlet.http.HttpServletRequest;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @Author : east.Fu
 * @Description : 控制器 GroupController
 * @Date : Created in  2017/6/27 16:39
 */
@Controller
@RequestMapping("/web/group")
public class GroupController {

    @Autowired
    private BumblebeeService bumblebeeServiceImpl;

    @RequestMapping("/data")
    @ResponseBody
    public String data(){
        List<BumblebeeGroup> list = bumblebeeServiceImpl.queryAllGroup();
        Map<String,Object> data = new HashMap<String,Object>();
        data.put("data",list);
        return JSON.toJSONString(data, JsonFilter.filter);
    }

    @RequestMapping("/mainNameList")
    @ResponseBody
    public String mainNameList(){
        List<String> mainNameList = bumblebeeServiceImpl.getMainNameList();
        return JSON.toJSONString(mainNameList);
    }

    @RequestMapping("/add")
    @ResponseBody
    public String add(HttpServletRequest request,String groupName, String desc, String mainNameList){
        String userName=((BumblebeeUser)request.getSession().getAttribute("curUser")).getUserName();
        Map<String,String> result = bumblebeeServiceImpl.addGroup(userName,groupName,desc,mainNameList);
        return JSON.toJSONString(result);
    }
    @RequestMapping("/edit")
    @ResponseBody
    public String edit(String groupName,String desc,Integer groupId,String mainNameList){
        Map<String,String> result = bumblebeeServiceImpl.editGroup(groupName,desc,groupId,mainNameList);
        return JSON.toJSONString(result);
    }

    @RequestMapping("/del")
    @ResponseBody
    public String del(Integer groupId){
        String result =bumblebeeServiceImpl.delGroup(groupId);
        return result;
    }

}
