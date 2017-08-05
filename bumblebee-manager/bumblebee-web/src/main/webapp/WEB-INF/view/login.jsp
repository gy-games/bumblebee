<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Bumblebee管理系统</title>
    <link rel="icon" href="${ctx}/resources/img/bb.ico"/>
    <%@ include file="../../WEB-INF/view/common/jstl.jsp" %>
    <link href="${ctx}/resources/js/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="${ctx}/resources/css/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <link href="${ctx}/resources/js/nprogress/nprogress.css" rel="stylesheet">
    <link href="${ctx}/resources/js/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet"/>
    <link href="${ctx}/resources/js/layer-3.0.3/skin/default/layer.css" rel="stylesheet">
    <link href="${ctx}/resources/css/custom.css" rel="stylesheet">
</head>

<body class="login">
<div>
    <div class="login_wrapper">
        <div class="animate form login_form">
            <section class="login_content">
                <form>
                    <h1>Bumblebee</h1>
                    <div>
                        <input type="text" id="email" class="form-control" placeholder="登录帐号邮箱" required="true" />
                    </div>
                    <div>
                        <input type="password" id = "pwd" class="form-control" placeholder="登录密码" required="true" />
                    </div>
                    <div>
                        <a class="btn btn-default submit" href="#" onclick="javascript:login()">登录</a>
                    </div>

                    <div class="clearfix"></div>

                    <div class="separator">

                        <div class="clearfix"></div>
                        <br />

                        <div>
                            <h1><i class="fa fa-paw"></i> 光宇游戏</h1>
                            <p>Copyright©2004-2017, 光宇游戏系统部, All Rights Reserved</p>
                        </div>
                    </div>
                </form>
            </section>
        </div>

    </div>
</div>
<script src="${ctx}/resources/js/jquery/dist/jquery.min.js"></script>
<script src="${ctx}/resources/js/layer-3.0.3/layer.js"></script>
<script type="text/javascript">
    $(function(){
        document.onkeydown = function(e){
            var ev = document.all ? window.event : e;
            if(ev.keyCode==13) {
                login();
            }
        }
    });
    function login(){
        if($("#email").val()==''){
            layer.alert('请输入帐号邮箱！', {
                icon : 6
            });
            return;
        }

        if($("#pwd").val()==''){
            layer.alert('请输入密码！', {
                icon : 6
            });
            return;
        }

        $.ajax({
            url:_ctx+"/web/doLogin",
            type:'post',
            dataType:'html',
            data:{'email':$("#email").val(),'pwd':$("#pwd").val()},
            success:function(data){
                if(data=="success"){
                    top.location.href = _ctx + '/web/main';
                }else{
                    layer.alert('登录失败：账号邮箱或者密码错误！', {
                        icon : 6
                    });
                }
            },
            error:function(){
                layer.alert('登录失败：请联系管理员！', {
                    icon : 6
                });
            }
        });
    }
</script>
</body>
</html>

