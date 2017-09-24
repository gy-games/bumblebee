<%@ page language="java" pageEncoding="utf-8" contentType="text/html;charset=utf-8" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<div class="page-title">
    <div class="title_left">
        <h3>Bumblebee管理系统</h3>
    </div>
</div>
<div class="clearfix"></div>
<br/>
<br/>

<div class="x_content">
    <div class="col-md-8 col-lg-8 col-sm-7" style="border-right: 5px solid #eee;">
        <ul class="list-unstyled timeline">
        <li>
            <div class="block">
                <div class="tags">
                    <a href="" class="tag">
                        <span>介绍</span>
                    </a>
                </div>
                <div class="block_content">
                    <h2 class="title">
                        <a>Bumblebee管理系统基于Elves远程管理平台进行开发</a>
                    </h2>
                    <p class="excerpt">
                       实现机器命令的远程调用功能，支持web操作和客户端操作两种形式，目前开发版本 V-${clientVersion},首页有客户端的下载连接，欢迎下载使用.<br/>
                    </p>
                </div>
            </div>
        </li>
        <li>
            <div class="block">
                <div class="tags">
                    <a href="" class="tag">
                        <span>发送指令</span>
                    </a>
                </div>
                <div class="block_content">
                    <h2 class="title">
                        该功能节点和客户端的功能类似
                    </h2>
                    <p class="excerpt">
                        选择机器，然后输入Linux/Window系统命令,就可以远程执行并回复执行结果。<br/>
                    </p>
                </div>
            </div>
        </li>
        <li>
            <div class="block">
                <div class="tags">
                    <a href="" class="tag">
                        <span>操作日志</span>
                    </a>
                </div>
                <div class="block_content">
                    <h2 class="title">
                        该节点记录了操作人员所有的命令操作
                    </h2>
                    <p class="excerpt">
                        可以进行日志追踪，操作人员进行的所有系统命令操作可以在这里查看.<br/>
                    </p>
                </div>
            </div>
        </li>
        <li>
            <div class="block">
                <div class="tags">
                    <a href="" class="tag">
                        <span>机器列表</span>
                    </a>
                </div>
                <div class="block_content">
                    <h2 class="title">
                        该节点可以查看所有的机器列表
                    </h2>
                    <p class="excerpt">
                        这里的机器列表作为元数据，供操作人员进行操作和查看Elves在该机器的在线状态.<br/>
                    </p>
                </div>
            </div>
        </li>
        <li>
            <div class="block">
                <div class="tags">
                    <a href="" class="tag">
                        <span>指令黑名单</span>
                    </a>
                </div>
                <div class="block_content">
                    <h2 class="title">
                        该节点是为了避免操作人员误操作而设计
                    </h2>
                    <p class="excerpt">
                        命令黑名单列表中的命令，在进行命令操作的时候都会被拦截掉，避免出现不可预估的损失.<br/>
                    </p>
                </div>
            </div>
        </li>
        <li>
            <div class="block">
                <div class="tags">
                    <a href="" class="tag">
                        <span>后台操作</span>
                    </a>
                </div>
                <div class="block_content">
                    <h2 class="title">
                        <a>该节点只对超级管理员开放</a>
                    </h2>
                    <p class="excerpt">
                        主要功能点：用户管理、用户组管理、授权用户、授权用户组权限、系统配置。<br/>
                    </p>
                </div>
            </div>
        </li>
    </ul>
    </div>
    <div class="col-md-4 col-lg-4 col-sm-5" style="padding-top: 200px;padding-left: 100px;text-align: center;">
        <h2>Bumblebee客户端 v-${clientVersion}</h2>
        <button class="btn btn-primary" onclick="downClient()">
            <i class="fa fa-download"></i><br/>Bumblebee客户端下载
        </button>
    </div>
</div>