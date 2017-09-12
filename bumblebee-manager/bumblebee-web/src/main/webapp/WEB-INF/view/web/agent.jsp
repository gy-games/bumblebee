<%@ page language="java" pageEncoding="utf-8" contentType="text/html;charset=utf-8" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<div class="page-title">
    <div class="title_left">
        <h3>机器列表</h3>
    </div>
</div>

<div class="row">
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <button class="btn btn-info pull-left" onclick="reflushDatable('agent-datatable')">
                    <i class="fa fa-repeat"></i> 刷新
                </button>
                <button class="btn btn-success pull-left" onclick="syncAgent()">
                    <i class="fa fa-repeat"></i> 同步机器列表
                </button>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <table id="agent-datatable" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
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
            "sAjaxSource" : _ctx+"/web/agent/data",
            'bStateSave': true,
            "aoColumns" : [{
                "mDataProp" : "aaa",
                "sDefaultContent":"",
                "sTitle" : "序号"
            },{
                "mDataProp" : "agentIp",
                "sDefaultContent":"",
                "sTitle" : "IP",
            },{
                "mDataProp" : "agentName",
                "sDefaultContent":"",
                "sTitle" : "Agent名称",
            },{
                "mDataProp" : "asset",
                "sDefaultContent":"",
                "sTitle" : "资产号",
            },{
                "mDataProp" : "manager",
                "sDefaultContent":"",
                "sTitle" : "负责人",
            },{
                "mDataProp" : "mainName",
                "sDefaultContent":"",
                "sTitle" : "一级分类",
            },{
                "mDataProp" : "subName",
                "sDefaultContent":"",
                "sTitle" : "二级分类",
            },{
                "mDataProp" : "os",
                "sDefaultContent":"",
                "sTitle" : "操作系统",
            },{
                "mDataProp" : "updateTime",
                "sDefaultContent":"",
                "sTitle" : "更新时间"
            }],
            "bProcessing": true,
            "processing" : true,
            "sPaginationType" : "full_numbers",
            "fnDrawCallback": function(){
                this.api().column(0).nodes().each(function(cell, i) {
                    cell.innerHTML =  i + 1;
                });
            },
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
    });

    function syncAgent(){
        layer.confirm('确定要同步机器列表么？', {
            btn: ['确定','取消'] //按钮
        }, function(){
            var index = layer.load(2, {shade: false});
            $.ajax({
                url: _ctx+"/web/agent/syncAgentData",
                type:'post',
                success:function(data){
                    layer.close(index);
                    if(data=="success"){
                        layer.alert('操作成功！', {
                            icon : 6
                        });
                        reflushDatable('agent-datatable')
                    }else{
                        layer.alert('操作失败：请联系管理员！', {
                            icon : 6
                        });
                    }
                },
                error:function(){
                    layer.close(index);
                    layer.alert('操作失败：请联系管理员！', {
                        icon : 6
                    });
                }
            });
        });
    }
</script>



