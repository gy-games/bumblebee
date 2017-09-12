<%@ page language="java" pageEncoding="utf-8" contentType="text/html;charset=utf-8" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<div class="page-title">
    <div class="title_left">
        <h3>系统配置</h3>
    </div>
</div>

<div class="row">
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <button class="btn btn-info pull-left" onclick="reflushDatable('config-datatable')">
                    <i class="fa fa-repeat"></i> 刷新
                </button>
                <ul class="nav navbar-right panel_toolbox">
                    <li>
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">
                <table id="config-datatable" class="table table-striped table-bordered dt-responsive nowrap"
                       cellspacing="0" width="100%">
                </table>
            </div>
        </div>
    </div>
</div>

<div class="modal fade bs-example-modal-md" tabindex="-1" role="dialog" aria-hidden="true" id="configDialog">
    <div class="modal-dialog modal-md">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span
                        aria-hidden="true">×</span>
                </button>
                <h4 class="modal-title">编辑配置项</h4>
            </div>
            <div class="modal-body">
                <form id="demo-form" data-parsley-validate>
                    <input id="property" value="" type="hidden"/>
                    <label for="inputEle" id="title"></label>
                    <div id="inputEle">

                    </div>
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                <button type="button" class="btn btn-primary" onclick="saveConfig();">保存</button>
            </div>
        </div>
    </div>
</div>

<script src="${ctx}/resources/js/custom.js"></script>
<script type="text/javascript">
    $(function () {
        $('#config-datatable').DataTable({
            "bServerSide": false, //是否启动服务器端数据导入("前端分页/后端分页")
            "sAjaxSource": _ctx + "/web/config/data",
            'bStateSave': true,
            "aoColumns": [{
                "mDataProp" : "property",
                "sDefaultContent":"",
                "sTitle" : "序号",
                "sClass": "text-center"
            },{
                "mDataProp": "title",
                "sDefaultContent": "",
                "sTitle": "配置项",
                "sClass": "text-center"
            }, {
                "mDataProp": "value",
                "sDefaultContent": "",
                "sTitle": "值",
                "sClass": "text-left",
                "mRender": function (data, type, row, full) {
                    if (row.property == "ignoreFlag") {
                        if (data == "0") {
                            return "不可忽略";
                        } else {
                            return "可忽略";
                        }
                    }
                    return data;
                }
            }, {
                "mDataProp": "value",
                "sDefaultContent": "",
                "sTitle": "操作",
                "sClass": "text-center",
                "mRender": function (data, type, row, full) {
                    return "<a href='javascript:void(0);' class='btn btn-info btn-xs' onclick='showEditDialog(" + JSON.stringify(row) + ")'><i class='fa fa-pencil'></i> 编辑</a>";
                }
            }],
            "bProcessing": true,
            "searching": false,
            "bLengthChange": false,
            "fnDrawCallback": function(){
                this.api().column(0).nodes().each(function(cell, i) {
                    cell.innerHTML =  i + 1;
                });
            },
            "language": {
                "info": "", // 表格左下角显示的文字
                "paginate": {
                    "previous": "",
                    "next": ""
                }
            },
            "processing": true,
            "bSort": false,
            "paging": false
        });
    });

    function saveConfig() {
        var property = $("#property").val();
        if (property == "ignoreFlag") {
            value = $("input[name='ingnore']:checked").val();
        } else {
            value = $("#value").val();
        }
        $.ajax({
            url: _ctx + "/web/config/edit",
            data: {"value": value, "property": property},
            type: 'post',
            success: function (data) {
                if (data == 'success') {
                    layer.alert('操作成功！', {
                        icon: 6
                    });
                    $('#configDialog').modal('hide');
                    reflushDatable("config-datatable");
                } else {
                    layer.alert("操作失败：请联系管理员！", {
                        icon: 6
                    });
                }
            },
            error: function () {
                layer.alert('操作失败：请联系管理员！', {
                    icon: 6
                });
            }
        });
    }

    function showEditDialog(obj) {
        $("#property").val(obj.property);
        $("#title").html(obj.title + ":");
        var html = "";
        if (obj.property == "ignoreFlag") {
            html += "<br/><p>可忽略:<input type='radio' class='flat' name='ingnore' value='1'";
            if (obj.value == '1') {
                html += "checked=''";
            }
            html += " required />&nbsp;&nbsp;&nbsp;&nbsp;";
            html += "不可忽略:<input type='radio' class='flat' name='ingnore' value='0' ";
            if (obj.value == '0') {
                html += "checked=''";
            }
            html += "/></p>";
        } else if (obj.property == "promptContent") {
            html += "<textarea id=\"value\" required=\"required\" class=\"form-control\" data-parsley-trigger=\"keyup\" data-parsley-minlength=\"20\"";
            html += " data-parsley-maxlength=\"100\" data-parsley-validation-threshold=\"10\">" + obj.value + "</textarea>";
        } else {
            html += "<input type=\"text\" id=\"value\" class=\"form-control\" data-parsley-trigger=\"change\" required value='" + obj.value + "'/>"
        }
        $("#inputEle").html(html);
        $('#configDialog').modal('toggle');
    }

</script>
