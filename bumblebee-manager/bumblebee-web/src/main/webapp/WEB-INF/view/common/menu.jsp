<%@ page import="cn.gyyx.bumblebee.model.BumblebeeUser" %>
<%@ page language="java" pageEncoding="utf-8" contentType="text/html;charset=utf-8" %>
<%@ include file="jstl.jsp" %>
<div class="col-md-3 left_col">
	<div class="left_col scroll-view">
		<div class="navbar nav_title" style="border: 0;">
            <a href="javascript:void(0)" onclick="loadContent('/web/home')" class="site_title">
                <i class="fa fa-paw"></i>
                <span>Bumblebee</span>
            </a>
		</div>

		<div class="clearfix"></div>

		<br />

		<!-- sidebar menu -->
		<div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
			<div class="menu_section">

				<ul class="nav side-menu">
                    <li>
                        <a href="javascript:void(0);" onclick="loadContent('/web/home')">
                            <i class="fa fa-home"></i>首页
                        </a>
                    </li>
                    <li>
                        <a href="javascript:void(0);" onclick="loadContent('/web/view/command')">
                            <i class="fa fa-send"></i>发送命令
                        </a>
                    </li>
					<li>
						<a href="javascript:void(0);" onclick="loadContent('/web/view/log')">
                            <i class="fa fa-bar-chart"></i>操作日志
						</a>
					</li>
                    <li>
                        <a href="javascript:void(0);" onclick="loadContent('/web/view/agent')">
                            <i class="fa fa-sitemap"></i>机器列表
                        </a>
                    </li>
                    <c:if test="${sessionScope.curUser.isSystem==1}">

                        <li>
                            <a href="javascript:void(0);" onclick="loadContent('/web/view/blacklist')">
                                <i class="fa fa-calendar"></i>指令黑名单
                            </a>
                        </li>
                        <li><a><i class="fa fa-wrench"></i>后台管理<span class="fa fa-chevron-down"></span></a>
                            <ul class="nav child_menu">
                                <li>
                                    <a href="javascript:void(0);" onclick="loadContent('/web/view/user')">用户管理</a>
                                </li>
                                <li>
                                    <a href="javascript:void(0);" onclick="loadContent('/web/view/group')">用户组管理</a>
                                </li>
                            </ul>
                        </li>
                    </c:if>

				</ul>
			</div>

		</div>
		<div class="sidebar-footer hidden-small">
			<script>
                var stat=true;
                function fullScheen(){
                    var docElm = document.documentElement;
                    if(stat){
                        //W3C
                        if (docElm.requestFullscreen) {
                            docElm.requestFullscreen();
                        }
                        //FireFox
                        else if (docElm.mozRequestFullScreen) {
                            docElm.mozRequestFullScreen();
                        }
                        //Chrome等
                        else if (docElm.webkitRequestFullScreen) {
                            docElm.webkitRequestFullScreen();
                        }
                        //IE11
                        else if (docElm.msRequestFullscreen) {
                            docElm.msRequestFullscreen();
                        }
                        stat=false;
                    }else{
                        if (document.exitFullscreen) {
                            document.exitFullscreen();
                        }
                        else if (document.mozCancelFullScreen) {
                            document.mozCancelFullScreen();
                        }
                        else if (document.webkitCancelFullScreen) {
                            document.webkitCancelFullScreen();
                        }
                        else if (document.msExitFullscreen) {
                            document.msExitFullscreen();
                        }
                        stat=true;
                    }
                    //document.documentElement.webkitRequestFullScreen();
                }
			</script>
			<a data-toggle="tooltip" data-placement="top" title="全屏">
				<span class="glyphicon glyphicon-fullscreen" aria-hidden="true" onclick="fullScheen();"></span>
			</a>
			<a data-toggle="tooltip" data-placement="top" title="登出" href="javascript:void(0);" onclick="logOut();">
				<span class="glyphicon glyphicon-off" aria-hidden="true"></span>
			</a>
		</div>
	</div>
</div>