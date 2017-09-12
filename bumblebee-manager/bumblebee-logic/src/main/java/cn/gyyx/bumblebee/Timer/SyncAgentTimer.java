package cn.gyyx.bumblebee.Timer;

import cn.gyyx.bumblebee.service.BumblebeeService;
import cn.gyyx.bumblebee.util.DateUtil;
import cn.gyyx.bumblebee.util.ExceptionUtil;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

/**
 * @Author : east.Fu
 * @Description : 同步agent数据定时器
 * @Date : Created in  2017/8/17 17:07
 */
@Component("syncAgentTimer")
public class SyncAgentTimer {

    private static final Logger LOG = LoggerFactory.getLogger(SyncAgentTimer.class);

    @Autowired
    private BumblebeeService bumblebeeServiceImpl;

    public void sync(){
        LOG.info("sync agent timer start "+ DateUtil.currentTimestamp2String(null));
        try {
            bumblebeeServiceImpl.syncAgentData();
            LOG.info("sync agent timer end "+ DateUtil.currentTimestamp2String(null));
        }catch (Exception e){
            LOG.info("sync agent timer error "+ ExceptionUtil.getStackTraceAsString(e));
        }
    }
}
