package cn.gyyx.bumblebee.controller;

import cn.gyyx.bumblebee.filter.JsonFilter;
import cn.gyyx.bumblebee.model.BumblebeeUser;
import cn.gyyx.bumblebee.model.OperateLog;
import cn.gyyx.bumblebee.model.Pagination;
import cn.gyyx.bumblebee.model.TableModelVO;
import cn.gyyx.bumblebee.service.BumblebeeService;
import com.alibaba.fastjson.JSON;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

/**
 * @Author : east.Fu
 * @Description : 控制器 LogController
 * @Date : Created in  2017/6/27 16:39
 */
@Controller
@RequestMapping("/web/log")
public class LogController {

    @Autowired
    private BumblebeeService bumblebeeServiceImpl;

    @RequestMapping("/data")
    @ResponseBody
    public String data(TableModelVO tableModelVO1,HttpServletRequest request){
        HttpSession session = request.getSession();
        BumblebeeUser user=(BumblebeeUser) request.getSession().getAttribute("curUser");
        Pagination<OperateLog> list = bumblebeeServiceImpl.queryLogForPage(tableModelVO1,user);
        return JSON.toJSONString(list, JsonFilter.filter);
    }

}
