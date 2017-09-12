<%@ page language="java" pageEncoding="utf-8" contentType="text/html;charset=utf-8" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<div class="page-title">
    <div class="title_left">
        <h3>用户组列表</h3>
    </div>
</div>

<div class="row">
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <button class="btn btn-info pull-left" onclick="reflushDatable('group-datatable')">
                    <i class="fa fa-repeat"></i> 刷新
                </button>

                <button class="btn btn-success pull-left" onclick="showAddDialog()">
                    <i class="fa fa-plus-square"></i> 新增用户组
                </button>
                <ul class="nav navbar-right panel_toolbox">
                    <li>
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <table id="group-datatable" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                </table>
            </div>
        </div>
    </div>
</div>

<div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="groupDialog">
    <div class="modal-dialog modal-md">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span>
                </button>
                <h4 class="modal-title" id="myModalLabel2">
                    新增用户组
                </h4>
            </div>
            <div class="modal-body">
                <form id="demo-form" data-parsley-validate>
                    <input type="hidden" id="groupId" value=""/>
                    <label for="groupName">用户组名:</label>
                    <input type="text" id="groupName" class="form-control"  required />
                    <br />
                    <label for="desc">描述:</label>
                    <textarea id="desc" required="required" class="form-control" data-parsley-trigger="keyup" data-parsley-minlength="20" data-parsley-maxlength="100" data-parsley-minlength-message="Come on! You need to enter at least a 20 caracters long comment.."
                              data-parsley-validation-threshold="10"></textarea>
                    <br />

                    <label>授权机器(一级分类):</label>
                    <p style="padding: 5px;" id="perDiv">
                    </p>
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                <button type="button" class="btn btn-primary" onclick="addOrEditGroup();">保存</button>
            </div>
        </div>
    </div>
</div>

<script src="${ctx}/resources/js/custom.js"></script>
<script type="text/javascript">
    $(function(){
        $('#group-datatable').DataTable({
            "bServerSide" : false, //是否启动服务器端数据导入("前端分页/后端分页")
            "sAjaxSource" : _ctx+"/web/group/data",
            'bStateSave': true,
            "aoColumns" : [{
                "mDataProp" : "groupId",
                "sDefaultContent":"",
                "sTitle" : "序号",
                "sWidth" : "4%"
            },{
                "mDataProp" : "groupName",
                "sDefaultContent":"",
                "sTitle" : "组名",
                "sWidth" : "15%"
            },{
                "mDataProp" : "createTime",
                "sDefaultContent":"",
                "sTitle" : "创建时间",
                "sWidth" : "15%"
            },{
                "mDataProp" : "createUser",
                "sDefaultContent":"",
                "sTitle" : "创建人",
                "sWidth" : "15%"
            },{
                "mDataProp" : "desc",
                "sDefaultContent":"",
                "sTitle" : "描述"
            },{
                "mDataProp" : "groupId",
                "sDefaultContent":"",
                "sTitle" : "操作",
                "mRender": function ( data, type,row, full ) {
            return "<a href='javascript:void(0);' class='btn btn-info btn-xs' onclick='editPermission("+JSON.stringify(row)+")'><i class='fa fa-pencil'></i> 编辑用户组</a>"
                +"<a href='javascript:void(0);' class='btn btn-danger btn-xs' onclick='del("+data+")')><i class='fa fa-trash-o'></i> 删除</a>";
        },
                "sWidth" : "15%"
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

    function addOrEditGroup(){
        var groupId=$("#groupId").val();
        var url;
        if(groupId==""){
            url =_ctx+"/web/group/add";
        }else{
            url =_ctx+"/web/group/edit"
        }

        var groupName = $("#groupName").val();

        if(groupName==''){
            layer.alert('请输入用户组名！', {
                icon : 6
            });
            return;
        }

        var desc = $("#desc").val();

        var mainNameList="";
        $("input[name='permissions']:checked").each(function(){
            mainNameList+=$(this).val();
            mainNameList+=",";
        });

        $.ajax({
            url:url,
            data:{'groupName':groupName,'desc':desc,'groupId':groupId,"mainNameList":mainNameList},
            type:'post',
            dataType:"json",
            success:function(data){
                if(data.code=='0'){
                    layer.alert('操作成功！', {
                        icon : 6
                    });
                    $('#groupDialog').modal('hide');
                    reflushDatable("group-datatable");
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

    function del(groupId){
        layer.confirm('确定要删除该用户组么？', {
            btn: ['确定','取消'] //按钮
        }, function(){
            $.ajax({
                url:_ctx+"/web/group/del",
                data:{'groupId':groupId},
                type:'post',
                success:function(data){
                    if(data=='success'){
                        layer.alert('操作成功！', {
                            icon : 6
                        });
                        $('#groupDialog').modal('hide');
                        reflushDatable("group-datatable");
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
        $("#groupId").val("");
        $("#groupName").val("");
        $("#desc").val("");
        loadMainNameList();
        $('#groupDialog').modal('toggle');
    }

    //用户组授权
    function editPermission(obj){
        $("#groupId").val(obj.groupId);
        $("#groupName").val(obj.groupName);
        $("#desc").val(obj.desc);
        loadMainNameList(obj.mainNameList);
        $('#groupDialog').modal('toggle');
    }

    function loadMainNameList(mainNameList){
        var html="";
        $.ajax({
            url:_ctx+"/web/group/mainNameList",
            type:'post',
            dataType:"json",
            success:function(data){
                for (i=0;i<data.length ;i++ ){
                    if(mainNameList!=undefined&&mainNameList!=""){
                        var mainNames= new Array(); //定义一数组
                        mainNames=mainNameList.split(","); //字符分割
                        var flag=false;
                        for (x=0;x<mainNames.length ;x++ ){
                            if(data[i]==mainNames[x]){
                                flag=true;
                                break;
                            }
                        }
                        if(flag){
                            html+="<input type='checkbox' name='permissions' checked='checked' value='"+data[i]+"' class='flat' />"+data[i];
                            html+="&nbsp;&nbsp;";
                        }else{
                            html+="<input type='checkbox' name='permissions' value='"+data[i]+"' class='flat' />"+data[i];
                            html+="&nbsp;&nbsp;";
                        }
                    }else{
                        html+="<input type='checkbox' name='permissions' value='"+data[i]+"' class='flat' />"+data[i];
                        html+="&nbsp;&nbsp;";
                    }

                    if(i!=0&&i%6==0){
                        html+="<br/>";
                    }
                }
                $("#perDiv").html(html);
            },
            error:function(){
                layer.alert('加载数据失败：请联系管理员！', {
                    icon : 6
                });
            }
        });
    }
</script>
