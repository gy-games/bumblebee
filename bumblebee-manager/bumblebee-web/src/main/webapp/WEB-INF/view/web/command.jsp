<%@ page import="cn.gyyx.bumblebee.model.BumblebeeUser" %>
<%@ page language="java" pageEncoding="utf-8" contentType="text/html;charset=utf-8" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<div class="page-title">
    <div class="title_left">
        <h3>发送命令</h3>
    </div>
</div>

<div class="row">
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <input type="text" id="command" class="form-control" placeholder="系统命令">
                </div>
                <button class="btn btn-info pull-left" onclick="runCMD()">
                    <i class="fa fa-mail-forward"></i> 发送
                </button>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <table id="agent-datatable" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                    <thead>
                    <tr>
                        <th>
                            <input type="checkbox" id="checkAll"/>
                        </th>
                        <th>IP</th>
                        <th>结果</th>
                        <th>Agent名称</th>
                        <th>资产号</th>
                        <th>负责人</th>
                        <th>一级分类</th>
                        <th>二级分类</th>
                        <th>操作系统</th>
                    </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</div>

<script src="${ctx}/resources/js/jbase64.js"></script>
<script src="${ctx}/resources/js/custom.js"></script>
<script type="text/javascript">
    $(function(){
        $('#agent-datatable').DataTable({
            "bServerSide" : false, //是否启动服务器端数据导入("前端分页/后端分页")
            "sAjaxSource" : _ctx+"/web/command/agentList",
            'bStateSave': true,
            "order": [],
            "aoColumnDefs": [ { "bSortable": false, "aTargets": [ 0 ] }],
            "aoColumns" : [{
                "sClass": "text-center",
                "data": "agentIp",
                "render": function (data, type, row, meta) {
                    return "<input type='checkbox' name='ckBox' class='checkchild'  value='"+ data +"'/>";
                },
                "sWidth" : "3%"
            },{
                "mDataProp" : "agentIp",
                "sDefaultContent":"",
                "sWidth" : "8%"
            },{
                "mDataProp" : "result",
                "sDefaultContent":"",
                "sWidth" : "40%"
            },{
                "mDataProp" : "agentName",
                "sDefaultContent":"",
                "sWidth" : "5%"
            },{
                "mDataProp" : "asset",
                "sDefaultContent":"",
                "sWidth" : "5%"
            },{
                "mDataProp" : "manager",
                "sDefaultContent":"",
                "sWidth" : "5%"
            },{
                "mDataProp" : "mainName",
                "sDefaultContent":"",
                "sWidth" : "5%"
            },{
                "mDataProp" : "subName",
                "sDefaultContent":"",
                "sWidth" : "5%"
            },{
                "mDataProp" : "os",
                "sDefaultContent":"",
                "sWidth" : "5%"
            }],
            "bProcessing": true,
            "sPaginationType" : "full_numbers",
            "oLanguage" : {
                "sLengthMenu": "每页显示 _MENU_ 条记录",
                "sZeroRecords": "抱歉，查询不到任何相关数据",
                "sInfo": "当前显示 _START_ 到 _END_ 条，共 _TOTAL_条记录",
                "sInfoEmpty": "找不到相关数据",
                "sInfoFiltered": "(数据表中共为 _MAX_ 条记录)",
                "sProcessing": "数据正在加载中，请稍候...",
                "sSearch": "搜索",
                "oPaginate": {
                    "sFirst": "首页",
                    "sPrevious": "前一页",
                    "sNext": "后一页",
                    "sLast": "尾页"
                }
            }
        });

        $("#checkAll").on("click",function() {
            if ($(this).prop("checked") === true) {
                $("input[name='ckBox']").prop("checked", $(this).prop("checked"));
                $('#example tbody tr').addClass('selected');
            } else {
                $("input[name='ckBox']").prop("checked", false);
                $('#example tbody tr').removeClass('selected');
            }
        });
    });


    function runCMD(){
        var cmd=$("#command").val();
        if(""==cmd){
            layer.alert('请输入命令！', {
                icon : 6
            });
            return;
        }
        var flag =false;
        $("input[name='ckBox']:checked").each(function(){
            flag=true;
            var ip =$(this).val();
            var updateEle=$(this).parent().next().next();
            $.ajax({
                url: _ctx+"/web/command/runCommand",
                type:'post',
                data:{'command':cmd,'ip':ip},
                dataType:"json",
                success:function(data){
                    var dt="";
                    if(data.code=="0"){
                        dt="<font color='#7fffd4'>"+replaceHtmlStr(data.data.substring(0,50))+"...</font>"
                    }else{
                        dt="<font color='red'>"+replaceHtmlStr(data.data.substring(0,50))+"...</font>"
                    }
                    var tipData=replaceHtmlStr(data.data).replace(/\n/g,"<br/>");
                    var base64 = BASE64.encoder(tipData);//返回编码后的字符
                    var html ="<a href='javascript:void(0);' id='aaa' onclick=\"showTips('"+base64+"')\">"+dt+"</a>";
                    updateEle.html(html);
                },
                error:function(){
                    updateEle.html("执行失败，请联系管理员！");
                }
            });
        });
        if(!flag){
            layer.alert('请选择机器！', {
                icon : 6
            });
        }
    }

    function showTips(data){
        var unicode= BASE64.decoder(data);
        var str = '';
        for(var i = 0 , len =  unicode.length ; i < len ;++i){
            str += String.fromCharCode(unicode[i]);
        }
        layer.open({
            type: 1,
            skin: 'layui-layer-rim', //加上边框
            area: ['500px', '300px'], //宽高
            content: str
        });
    }

    function replaceHtmlStr(str){
        return str.replace(/[ ]/g,"&nbsp;").replace(/>/g,"&gt;").replace(/</g,"&lt;");
    }
</script>



