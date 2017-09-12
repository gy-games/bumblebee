package cn.gyyx.bumblebee.controller;

import cn.gyyx.bumblebee.model.BumblebeeConfig;
import cn.gyyx.bumblebee.model.BumblebeeUser;
import cn.gyyx.bumblebee.service.BumblebeeService;
import cn.gyyx.bumblebee.util.Md5Util;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 * @Author : east.Fu
 * @Description : 控制器HomeController
 * @Date : Created in  2017/6/27 16:39
 */
@Controller
@RequestMapping("/web")
public class HomeController {

    private static final Logger LOG = LoggerFactory.getLogger(HomeController.class);

    @Autowired
    private BumblebeeService bumblebeeServiceImpl;

    @RequestMapping("/login")
    public String login(){
        return "login";
    }

    @RequestMapping("/view/{page}")
    public String view(@PathVariable("page")String page){
        return "web/"+page;
    }



    @RequestMapping("/doLogin")
    @ResponseBody
    public String doLogin(HttpServletRequest request,String email, String pwd){
        BumblebeeUser user =bumblebeeServiceImpl.login(email,Md5Util.MD5(pwd));
        if(null!=user){
            //session存放user信息
            HttpSession session = request.getSession();
            session.setAttribute("curUser", user);
            session.setAttribute("username", user.getUserName());
            return "success";
        }
        return "fail";
    }

    @RequestMapping(value="logout")
    @ResponseBody
    public String logout(HttpServletRequest request,HttpServletResponse response){
        HttpSession session = request.getSession();
        session.setAttribute("curUser", null);
        return "success";
    }

    @RequestMapping("/main")
    public String main(){
        return "main";
    }

    @RequestMapping("/home")
    public String home(Model model){
        BumblebeeConfig config=bumblebeeServiceImpl.queryConfig();
        if(config!=null){
            model.addAttribute("clientVersion",config.getClientVersion());
        }
        return "/web/home";
    }

    @RequestMapping("/updatePwd")
    @ResponseBody
    public String updatePwd(HttpServletRequest request,String pwd){
        HttpSession session = request.getSession();
        BumblebeeUser user=(BumblebeeUser) request.getSession().getAttribute("curUser");
        user.setPwd(Md5Util.MD5(pwd));
        boolean flag=bumblebeeServiceImpl.updatePwd(user);
        if(flag){
            //注销登录
            session.setAttribute("curUser", null);
            return "success";
        }
        return "fail";
    }

}
