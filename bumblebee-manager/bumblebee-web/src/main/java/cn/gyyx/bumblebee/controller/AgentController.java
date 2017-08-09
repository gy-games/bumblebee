package cn.gyyx.bumblebee.controller;

import cn.gyyx.bumblebee.filter.JsonFilter;
import cn.gyyx.bumblebee.model.BumblebeeAgent;
import cn.gyyx.bumblebee.service.BumblebeeService;
import cn.gyyx.bumblebee.util.DateUtil;
import cn.gyyx.bumblebee.util.ZookeeperExcutor;
import com.alibaba.fastjson.JSON;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.ArrayList;
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

        /*Map<String,Map<String,Object>> agents= null;
        if(ZookeeperExcutor.enabled){
            agents= ZookeeperExcutor.getChildrenData("/elves_v2/heartbeat/agent");
        }
        List<Map<String,Object>> data =new ArrayList<>();
        for(BumblebeeAgent agent:list){
            Map<String,Object> map =new HashMap<>();

            map.put("agentIp",agent.getAgentIp().trim());
            map.put("agentName",agent.getAgentName());
            map.put("asset",agent.getAsset());
            map.put("manager",agent.getManager());
            map.put("mainName",agent.getMainName());
            map.put("subName",agent.getSubName());

            if(agents!=null&&agents.size()>0&&agents.containsKey(agent.getAgentIp().trim())){
                long time=Long.parseLong(agents.get(agent.getAgentIp().trim()).get("checkTime").toString());
                map.put("status","在线");
                map.put("ckTime",DateUtil.formatDate(time,DateUtil.DEFAULT_DATETIME_FORMAT));
            }else{
                map.put("status","不在线");
                map.put("ckTime","");
            }
            data.add(map);
        }*/

        Map<String,Object> dt = new HashMap<String,Object>();
        dt.put("data",list);
        return JSON.toJSONString(dt,JsonFilter.filter);
    }

}
