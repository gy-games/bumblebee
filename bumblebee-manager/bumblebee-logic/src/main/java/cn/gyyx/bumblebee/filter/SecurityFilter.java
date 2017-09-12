package cn.gyyx.bumblebee.filter;

import cn.gyyx.bumblebee.model.BumblebeeUser;
import cn.gyyx.bumblebee.service.BumblebeeService;
import cn.gyyx.bumblebee.service.impl.BumblebeeServiceImpl;
import cn.gyyx.bumblebee.util.Md5Util;
import cn.gyyx.bumblebee.util.SpringContextUtil;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.filter.OncePerRequestFilter;

import javax.servlet.FilterChain;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.*;

/**
 * @Author : east.Fu
 * @Description : http 接口安全验证过滤器
 * @Date : Created in  2017/6/29 9:21
 */
public class SecurityFilter extends OncePerRequestFilter {

    private static final Logger LOG = LoggerFactory.getLogger(SecurityFilter.class);

    private String basePath;

    @Override
    protected void initFilterBean() throws ServletException {
        super.initFilterBean();
    }

    @Override
    protected void doFilterInternal(HttpServletRequest request, HttpServletResponse response, FilterChain filterChain) throws ServletException, IOException {
        String requestURI = request.getRequestURI().replaceAll("/+", "/");
        LOG.info("SecurityFilter receive request uri : " + requestURI);
        if(!validateSign(request)){
            java.io.PrintWriter out = response.getWriter();
            out.println("");
        }else{
            filterChain.doFilter(request, response);
            return;
        }
    }

    private boolean validateSign(HttpServletRequest request){
        String sign = request.getParameter("sign");
        String email = request.getParameter("email");
        if(StringUtils.isBlank(sign)||StringUtils.isBlank(email)){
            return false;
        }

        //find user
        BumblebeeService bumblebeeService= SpringContextUtil.getBean(BumblebeeServiceImpl.class);
        BumblebeeUser user =bumblebeeService.queryUser(email);
        if(user==null){
            return false;
        }
        //制作md5
        String signKey=user.getPwd();

        StringBuffer sortUri = new StringBuffer();
        Map<String, String[]> params = request.getParameterMap();
        Set<String> keys = params.keySet();
        List<String> list = new ArrayList<String>();
        list.addAll(keys);
        Collections.sort(list);
        for (String k : list) {
            if (!"sign".equals(k)) {
                sortUri.append(k + "=");
                sortUri.append((params.get(k) != null && params.get(k).length > 0) ? params.get(k)[0] : "");
                sortUri.append("&");
            }
        }
        if(list!=null&&list.size()>0){
            sortUri.deleteCharAt(sortUri.length() - 1);
        }
        String signFinal = Md5Util.MD5(sortUri.toString().trim()+signKey);

        LOG.info("final sign str :" + sortUri + ",signFinal:" + signFinal + ",sign:" + sign);
        // 验签成功
        if (sign.equalsIgnoreCase(signFinal)) {
            LOG.info("Sign Validate success !");
            return true;
        }
        return false;
    }

}
