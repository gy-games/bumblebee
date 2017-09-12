<%@ page language="java" pageEncoding="utf-8" contentType="text/html;charset=utf-8" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<div class="page-title">
    <div class="title_left">
        <h3>操作日志</h3>
    </div>
</div>

<div class="row">
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <button class="btn btn-info pull-left" onclick="reflushDatable('log-datatable')">
                    <i class="fa fa-repeat"></i> 刷新
                </button>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <table id="log-datatable" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                </table>
            </div>
        </div>
    </div>
</div>


<script src="${ctx}/resources/js/custom.js"></script>
<script type="text/javascript">
    $(function(){
        $('#log-datatable').DataTable({
            "bServerSide" : false, //是否启动服务器端数据导入("前端分页/后端分页")
            "sAjaxSource" : _ctx+"/web/log/data",
            'bStateSave': true,
            "aoColumns" : [{
                "mDataProp" : "logId",
                "sDefaultContent":"",
                "sTitle" : "日志ID",
                "sWidth" : "4%"
            },{
                "mDataProp" : "ip",
                "sDefaultContent":"",
                "sTitle" : "机器IP",
                "sWidth" : "10%"
            },{
                "mDataProp" : "param",
                "sDefaultContent":"",
                "sTitle" : "参数",
            },{
                "mDataProp" : "operateUser",
                "sDefaultContent":"",
                "sTitle" : "操作人",
                "sWidth" : "5%"
            },{
                "mDataProp" : "startTime",
                "sDefaultContent":"",
                "sTitle" : "开始时间",
                "sWidth" : "10%"
            },{
                "mDataProp" : "endTime",
                "sDefaultContent":"",
                "sTitle" : "结束时间",
                "sWidth" : "10%"
            },{
                "mDataProp" : "costTime",
                "sDefaultContent":"",
                "sTitle" : "耗时(ms)",
                "sWidth" : "5%"
            },{
                "mDataProp" : "result",
                "sDefaultContent":"",
                "sTitle" : "结果",
                "sWidth" : "15%"
            }],
            "bSort": false,
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
    });
</script>



