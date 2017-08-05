<%@ page language="java" pageEncoding="utf-8" contentType="text/html;charset=utf-8" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <%@ include file="../../resources/common/common-css.jsp" %>
    <title>首页 - ${title }</title>
    <link rel="icon" href="${ctx}/resources/img/bb.ico"/>
</head>

<body class="nav-md">
<div class="container body">
    <div class="main_container">
        <%@ include file="common/head.jsp" %>
        <%@ include file="common/menu.jsp" %>
        <div class="top_nav">
            <div class="nav_menu">
                <nav>
                    <div class="nav toggle">
                        <a id="menu_toggle"><i class="fa fa-bars"></i></a>
                    </div>

                    <ul class="nav navbar-nav navbar-right">
                        <li class="">
                            <a href="javascript:void(0);" class="user-profile dropdown-toggle" data-toggle="dropdown"
                               aria-expanded="false" >
                                <img src="${ctx}/resources/img/bb.ico" alt="">${sessionScope.curUser.userName}
                                <span class=" fa fa-angle-down"></span>
                            </a>
                            <ul class="dropdown-menu dropdown-usermenu pull-right">
                                <li>
                                    <a href="javascript:void(0);" onclick="showPwdDiv()">
                                        <span>修改密码</span>
                                    </a>
                                </li>
                                <li><a href="javascript:void(0);" onclick="logOut();"><i class="fa fa-sign-out pull-right"></i>注销</a></li>
                            </ul>
                        </li>
                    </ul>
                </nav>
            </div>
        </div>

        <div class="right_col" style="min-height: 1000px;">
            <div class="cc" id="rightDiv">
                <%@ include file="web/home.jsp" %>
            </div>
        </div>
        <footer>
            <div class="clearfix" style="text-align: center;"> Copyright © 2004-2017, 光宇游戏系统部, All Rights Reserved</div>
        </footer>
    </div>
</div>

<div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="pwdDialog">
    <div class="modal-dialog modal-sm">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span>
                </button>
                <h4 class="modal-title" id="myModalLabel2">
                    修改密码
                </h4>
            </div>
            <div class="modal-body">
                <form id="demo-form" data-parsley-validate>
                    <input id="userId" value="" type="hidden"/>
                    <label for="pwd">新密码:</label>
                    <input type="password" id="pwd" class="form-control"  data-parsley-trigger="change" required />
                    <br />
                    <label for="rePwd">重复新密码:</label>
                    <input type="password" id="rePwd" class="form-control" data-parsley-trigger="change" required />
                    </select>
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                <button type="button" class="btn btn-primary" onclick="updatePwd();">保存</button>
            </div>
        </div>
    </div>
</div>
<%@ include file="../../resources/common/common-js.jsp" %>
<script type="text/javascript">
    $(document).ready(function(){
        init_sidebar();

        // NProgress
        if (typeof NProgress != 'undefined') {
            $(document).ready(function () {
                NProgress.start();
            });

            $(window).load(function () {
                NProgress.done();
            });
        }
    });

    function loadContent(url) {
        $.ajax({
            url:_ctx+url,
            type:'get',
            dataType:'html',
            success:function(data){
                $("#rightDiv").html(data);
            }
        });
    }

    //刷新datatable数据
    function reflushDatable(id){
        $("#"+id).DataTable().ajax.reload( null, false );
    }

    function downClient(){
        window.open(_ctx+"/resources/client/bumblebee-client.zip");
//        layer.alert('客户端正在开发中...', {
//            icon : 6
//        });
    }

    function showPwdDiv(){
        $("#pwd").val("");
        $("#rePwd").val("");
        $('#pwdDialog').modal('toggle');
    }

    function updatePwd(){
        var pwd=$("#pwd").val();
        var rePwd=$("#rePwd").val();
        if(pwd==""){
            layer.alert('请输入密码！', {
                icon : 6
            });
            return;
        }
        if(rePwd==""){
            layer.alert('请再次输入密码！', {
                icon : 6
            });
            return;
        }
        if(pwd!=rePwd){
            layer.alert('两次输入密码不一致！', {
                icon : 6
            });
            return;
        }
        layer.confirm('确定修改密码么？', {
            btn: ['确定','取消'] //按钮
        }, function(){
            $.ajax({
                url:_ctx+"/web/updatePwd",
                data:{'pwd':pwd},
                type:'post',
                success:function(data){
                    if(data=='success'){
                        layer.confirm('密码修改成功,请重新登录！', {
                            btn: ['确定','取消'] //按钮
                        }, function(){
                            top.location.href = _ctx;
                        }, function(){
                            top.location.href = _ctx;
                        });
                    }else{
                        layer.alert("密码修改失败：请联系管理员！", {
                            icon : 6
                        });
                    }
                },
                error:function(){
                    layer.alert('密码修改失败：请联系管理员！', {
                        icon : 6
                    });
                }
            });
        });
    }

    function logOut(){
        layer.confirm('确定注销登录么？', {
            btn: ['确定','取消'] //按钮
        }, function(){
            $.ajax({
                url:_ctx+"/web/logout",
                type:'post',
                success:function(data){
                    if(data=='success'){
                        top.location.href = _ctx;
                    }else{
                        layer.alert("操作失败：请联系管理员！", {
                            icon : 6
                        });
                    }
                },
                error:function(){
                    layer.alert('操作失败：请联系管理员！', {
                        icon : 6
                    });
                }
            });
        });
    }
</script>
</body>
</html>