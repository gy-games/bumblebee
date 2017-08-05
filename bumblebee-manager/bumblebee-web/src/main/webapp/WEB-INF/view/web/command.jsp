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
                    </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</div>


<script src="${ctx}/resources/js/custom.js"></script>
<script type="text/javascript">
    $(function(){
        $('#agent-datatable').DataTable({
            "bServerSide" : false, //是否启动服务器端数据导入("前端分页/后端分页")
            "sAjaxSource" : _ctx+"/web/command/agentList",
            'bStateSave': true,
            "aoColumns" : [{
                "sClass": "text-center",
                "data": "agentIp",
                "render": function (data, type, row, meta) {

                    return "<input type='checkbox' name='ckBox' class='checkchild'  value='"+ data +"'/>";
                },
                "bSortable": false
            },{
                "mDataProp" : "agentIp",
                "sDefaultContent":""
            },{
                "mDataProp" : "result",
                "sDefaultContent":""
            },{
                "mDataProp" : "agentName",
                "sDefaultContent":""
            },{
                "mDataProp" : "asset",
                "sDefaultContent":""
            },{
                "mDataProp" : "manager",
                "sDefaultContent":""
            },{
                "mDataProp" : "mainName",
                "sDefaultContent":""
            },{
                "mDataProp" : "subName",
                "sDefaultContent":""
            }],
            "bProcessing": true,
            "processing" : true,
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

//        layer.alert('开发中！', {
//            icon : 6
//        });
//        return;

        var cmd=$("#command").val();
        if(""==cmd){
            layer.alert('请输入命令！', {
                icon : 6
            });
            return;
        }

        $("input[name='ckBox']:checked").each(function(){
            var ip =$(this).val();
            var updateEle=$(this).parent().next().next();
            $.ajax({
                url: _ctx+"/web/command/runCommand",
                type:'post',
                data:{'command':cmd,'ip':ip},
                dataType:"json",
                success:function(data){
                    updateEle.html(data.data);
                },
                error:function(){
                    updateEle.html("执行失败，请联系管理员！");
                }
            });
        });

    }
</script>



