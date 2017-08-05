package cn.gyyx.bumblebee.filter;

import cn.gyyx.bumblebee.model.BumblebeeUser;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.filter.OncePerRequestFilter;

import javax.servlet.FilterChain;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;

/**
 * @Author : east.Fu
 * @Description : web 登录过滤器
 * @Date : Created in  2017/6/29 9:20
 */
public class LoginFilter extends OncePerRequestFilter {

    private static final Logger LOG = LoggerFactory.getLogger(LoginFilter.class);

    private String basePath;

    @Override
    protected void initFilterBean() throws ServletException {
        super.initFilterBean();
    }


    @Override
    protected void doFilterInternal(HttpServletRequest request, HttpServletResponse response, FilterChain filterChain) throws ServletException, IOException {
        String requestURI = request.getRequestURI();
        requestURI = requestURI.replaceAll("/+", "/").replaceAll("/+", "/");
        LOG.info("LoginFilter receive request uri : " + requestURI);

        if (requestURI.equals("/")||requestURI.equals("/web/login")||requestURI.equals("/web/doLogin")||requestURI.startsWith("/resources")|| requestURI.startsWith("/terminal/")) {
            filterChain.doFilter(request, response);
            return;
        }
        String path = request.getContextPath();
        this.basePath = request.getScheme() + "://" + request.getServerName() + ":" + request.getServerPort() + path + "/";

        HttpSession session = request.getSession();

        BumblebeeUser user=(BumblebeeUser) session.getAttribute("curUser");
        if(null==user){
            java.io.PrintWriter out = response.getWriter();
            out.println("<html>");
            out.println("<script>");
            out.println("window.open ('"+basePath+"','_top')");
            out.println("</script>");
            out.println("</html>");
        }else{
            filterChain.doFilter(request, response);
            return;
        }


    }
}
