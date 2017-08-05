<%@ page language="java" pageEncoding="utf-8" contentType="text/html;charset=utf-8" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<div class="page-title">
    <div class="title_left">
        <h3>命令黑名单</h3>
    </div>
</div>

<div class="row">
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <button class="btn btn-info pull-left" onclick="reflushDatable('blacklist-datatable')">
                    <i class="fa fa-repeat"></i> 刷新
                </button>

                <button class="btn btn-success pull-left" onclick="showAddDialog()">
                    <i class="fa fa-plus-square"></i> 新增命令
                </button>
                <ul class="nav navbar-right panel_toolbox">
                    <li>
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <table id="blacklist-datatable" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                </table>
            </div>
        </div>
    </div>
</div>

<div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="groupDialog">
    <div class="modal-dialog modal-sm">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span>
                </button>
                <h4 class="modal-title" id="myModalLabel2">
                    新增命令
                </h4>
            </div>
            <div class="modal-body">
                <form id="demo-form" data-parsley-validate>
                    <label for="command">指令:</label>
                    <input type="text" id="command" class="form-control"  required />
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                <button type="button" class="btn btn-primary" onclick="addCommand();">保存</button>
            </div>
        </div>
    </div>
</div>

<script src="${ctx}/resources/js/custom.js"></script>
<script type="text/javascript">
    $(function(){
        $('#blacklist-datatable').DataTable({
            "bServerSide" : false, //是否启动服务器端数据导入("前端分页/后端分页")
            "sAjaxSource" : _ctx+"/web/blacklist/data",
            'bStateSave': true,
            "aoColumns" : [{
                "mDataProp" : "id",
                "sDefaultContent":"",
                "sTitle" : "序号"
            },{
                "mDataProp" : "command",
                "sDefaultContent":"",
                "sTitle" : "命令"
            },{
                "mDataProp" : "id",
                "sDefaultContent":"",
                "sTitle" : "操作",
                "mRender": function ( data, type,row, full ) {
                        return "<a href='javascript:void(0);' class='btn btn-danger btn-xs' onclick='del("+data+")')><i class='fa fa-trash-o'></i> 删除</a>";
                }
            }],
            "bProcessing": true,
            "processing" : true,
            "bSort": false,
            "fnDrawCallback": function(){
                this.api().column(0).nodes().each(function(cell, i) {
                    cell.innerHTML =  i + 1;
                });
            },
            "sPaginationType" : "full_numbers",
            "oLanguage" : {
                "sLengthMenu": "每页显示 _MENU_ 条记录",
                "sZeroRecords": "抱歉，查询不到任何相关数据",
                "sInfo": "当前显示 _START_ 到 _END_ 条，共 _TOTAL_条记录",
                "sInfoEmpty": "找不到相关数据",
                "sInfoFiltered": "(数据表中共为 _MAX_ 条记录)",
                "sProcessing": "正在加载中...",
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

    function addCommand(){
        var command = $("#command").val();

        if(command==''){
            layer.alert('请输入命令！', {
                icon : 6
            });
            return;
        }

        $.ajax({
            url:_ctx+"/web/blacklist/add",
            data:{'command':command},
            type:'post',
            dataType:"json",
            success:function(data){
                if(data.code=='0'){
                    layer.alert('操作成功！', {
                        icon : 6
                    });
                    reflushDatable("blacklist-datatable");
                }else{
                    layer.alert(data.msg, {
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
    }

    function del(id){
        layer.confirm('确定要删除该命令么？', {
            btn: ['确定','取消'] //按钮
        }, function(){
            $.ajax({
                url:_ctx+"/web/blacklist/del",
                data:{'id':id},
                type:'post',
                success:function(data){
                    if(data=='success'){
                        layer.alert('操作成功！', {
                            icon : 6
                        });
                        reflushDatable("blacklist-datatable");
                    }else{
                        layer.alert('操作失败：请联系管理员！', {
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

    function showAddDialog(){
        $("#command").val("");
        $('#groupDialog').modal('toggle');
    }

</script>
