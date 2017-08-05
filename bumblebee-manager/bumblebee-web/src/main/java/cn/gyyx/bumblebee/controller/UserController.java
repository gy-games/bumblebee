package cn.gyyx.bumblebee.controller;

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
 * @Description : 控制器 UserController
 * @Date : Created in  2017/6/27 16:39
 */
@Controller
@RequestMapping("/web/user")
public class UserController {

    @Autowired
    private BumblebeeService bumblebeeServiceImpl;

    @RequestMapping("/data")
    @ResponseBody
    public String data(){
        List<BumblebeeUser> list = bumblebeeServiceImpl.queryAllUser();
        Map<String,Object> data = new HashMap<String,Object>();
        data.put("data",list);
        return JSON.toJSONString(data);
    }

    @RequestMapping("/add")
    @ResponseBody
    public String add(HttpServletRequest request,String userName, String email, Integer groupId){
        String curUser=((BumblebeeUser)request.getSession().getAttribute("curUser")).getUserName();
        Map<String,String> result = bumblebeeServiceImpl.addUser(curUser,userName,email,groupId);
        return JSON.toJSONString(result);
    }
    @RequestMapping("/edit")
    @ResponseBody
    public String add(Integer userId,String userName,String email,Integer groupId){
        Map<String,String> result = bumblebeeServiceImpl.editUser(userId,userName,email,groupId);
        return JSON.toJSONString(result);
    }

    @RequestMapping("/del")
    @ResponseBody
    public String del(Integer userId){
        String result =bumblebeeServiceImpl.delUser(userId);
        return result;
    }

}
