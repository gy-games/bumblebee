<%@ page language="java" pageEncoding="utf-8" contentType="text/html;charset=utf-8" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<div class="page-title">
    <div class="title_left">
        <h3>用户列表</h3>
    </div>
</div>

<div class="row">
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <button class="btn btn-info pull-left" onclick="reflushDatable('user-datatable')">
                    <i class="fa fa-repeat"></i> 刷新
                </button>
                <button class="btn btn-success pull-left"onclick="showAddDialog()">
                    <i class="fa fa-plus-square"></i> 新增用户
                </button>
                <ul class="nav navbar-right panel_toolbox">
                    <li>
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <table id="user-datatable" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                </table>
            </div>
        </div>
    </div>
</div>

<div class="modal fade bs-example-modal-md" tabindex="-1" role="dialog" aria-hidden="true" id="userDialog">
    <div class="modal-dialog modal-md">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span>
                </button>
                <h4 class="modal-title" id="myModalLabel2">
                </h4>
            </div>
            <div class="modal-body">
                <form id="demo-form" data-parsley-validate>
                    <input id="userId" value="" type="hidden"/>
                    <label for="userName">用户名:</label>
                    <input type="text" id="userName" class="form-control" data-parsley-trigger="change" required />
                    <br />
                    <label for="email">邮箱:</label>
                    <input type="email" id="email" class="form-control" data-parsley-trigger="change" required />
                    <br />
                    <label>授权用户组:</label>
                    <select id="groupId" class="form-control" required>
                    </select>
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                <button type="button" class="btn btn-primary" onclick="addOrEditUser();">保存</button>
            </div>
        </div>
    </div>
</div>

<script src="${ctx}/resources/js/custom.js"></script>
<script type="text/javascript">
    $(function(){
        $('#user-datatable').DataTable({
            "bServerSide" : false, //是否启动服务器端数据导入("前端分页/后端分页")
            "sAjaxSource" : _ctx+"/web/user/data",
            'bStateSave': true,
            "aoColumns" : [{
                "mDataProp" : "userId",
                "sDefaultContent":"",
                "sTitle" : "序号",
            },{
                "mDataProp" : "userName",
                "sDefaultContent":"",
                "sTitle" : "用户名",
            },{
                "mDataProp" : "email",
                "sDefaultContent":"",
                "sTitle" : "邮箱",
            },{
                "mDataProp" : "createTime",
                "sDefaultContent":"",
                "sTitle" : "创建时间",
            },{
                "mDataProp" : "createUser",
                "sDefaultContent":"",
                "sTitle" : "创建人",
            },{
                "mDataProp" : "lastLoginTime",
                "sDefaultContent":"",
                "sTitle" : "最后登录时间",
            },{
                "mDataProp" : "groupName",
                "sDefaultContent":"",
                "sTitle" : "用户组",
            },{
                "mDataProp" : "isSystem",
                "sDefaultContent":"",
                "sTitle" : "是否系统用户",
                "mRender": function ( data, type,row,full) {
                    if(data==1){
                        return "是";
                    }else{
                        return "否";
                    }
                }
            },{
                "mDataProp" : "userId",
                "sDefaultContent":"",
                "sTitle" : "操作",
                "mRender": function ( data, type,row, full ) {
                    return "<a href='javascript:void(0);' class='btn btn-info btn-xs' onclick='showEditDialog("+JSON.stringify(row)+")'><i class='fa fa-pencil'></i> 编辑</a>"
                      +"<a href='javascript:void(0);' class='btn btn-danger btn-xs' onclick='del("+data+")')><i class='fa fa-trash-o'></i> 删除</a>";
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

    function addOrEditUser(){
        var userId=$("#userId").val();
        var url;
        if(userId==""){
            url =_ctx+"/web/user/add";
        }else{
            url =_ctx+"/web/user/edit"
        }

        var userName = $("#userName").val();

        if(userName==''){
            layer.alert('请输入用户名！', {
                icon : 6
            });
            return;
        }

        var email= $("#email").val();
        if(email==''){
            layer.alert('请输入邮箱！', {
                icon : 6
            });
            return;
        }

        var groupId = $("#groupId").val();
        $.ajax({
            url: url,
            data:{'userName':userName,'email':email,'groupId':groupId,"userId":userId},
            type:'post',
            dataType:"json",
            success:function(data){
                if(data.code=='0'){
                    layer.alert('操作成功！', {
                        icon : 6
                    });
                    $('#userDialog').modal('hide');
                    reflushDatable("user-datatable");
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


    function del(userId){
        layer.confirm('确定要删除该用户么？', {
            btn: ['确定','取消'] //按钮
        }, function(){
            $.ajax({
                url:_ctx+"/web/user/del",
                data:{'userId':userId},
                type:'post',
                success:function(data){
                    if(data=='success'){
                        layer.alert('操作成功！', {
                            icon : 6
                        });
                        $('#userDialog').modal('hide');
                        reflushDatable("user-datatable");
                    }else{
                        layer.alert(data, {
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
        flushGroupList();
        $("#userId").val("");
        $("#userName").val("");
        $('#userName').attr("readonly",false);
        $("#email").val("");
        $('#email').attr("readonly",false);
        $("#myModalLabel2").html("新增用户");
        $('#userDialog').modal('toggle');
    }

    function showEditDialog(obj){
        flushGroupList(obj.groupId);
        $("#userId").val(obj.userId);
        $("#userName").val(obj.userName);
        $("#userName").attr("readonly",true);
        $("#email").val(obj.email);
        $("#email").attr("readonly",true);
        $("#myModalLabel2").html("编辑用户");
        $('#userDialog').modal('toggle');
    }

    //刷新分组下拉列表
    function flushGroupList(selectId){
        $.ajax({
            url: _ctx+"/web/group/data",
            type:'post',
            dataType:"json",
            success:function(data){
                var groupData =data.data;
                var html ="<option value=''>——请选择用户组——</option>";
                for(var i=0;i<groupData.length;i++){
                    html+="<option value='"+groupData[i].groupId+"'>"+groupData[i].groupName+"</option>";
                }
                $("#groupId").html(html);
                if(selectId!=undefined&&selectId!=""){
                    $("#groupId").val(selectId);
                }
            }
        });
    }

</script>
