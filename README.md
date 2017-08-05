# bumblebee
## 简介
bumblebee(大黄蜂)运维工具：基于Elves开源自动化运维开发平台进行开发，实现的一款远程命令行执行工具（Elves开源自动化运维开发平台地址：[https://github.com/gy-games/elves](https://github.com/gy-games/elves)），bumblebee分为manager、client、script三部分。
	
## manager
Java编写，纯java-web项目，作为管理端和服务端，作为后台管理端可以进行权限分配和为客户端提供接口。
![](manager-home.png)

## client
c#编写的一款c/s客户端程序，调用bumblebee-manager提供的接口实现服务器的远程命令执行，并显示结果展示。
![](client-home.png)

## script
python编写，依照Elves-App SDK开发，是Elves-Agent端执行的脚本文件，所有的命令通过Elves调用各个服务器上的脚本，执行并回复结果。


## 特征
- client端命令全部通过manager端作为代理，调用Elves执行并返回数据，并提供命令操作日志
- manager端提供指令黑名单，避免危险命令操作
- manager端同样提供发送命令节点功能
- manager端提供用户授权功能，用户只能操作授权的机器
- manager端提供机器列表界面（可以自定义查询Elves机器在线状态）


## 提示
bumblebee运维系统是基于Elves开源自动化运维开发平台进行开发，这套系统的完全依赖Elves来实现，因此在搭建之前，请熟悉了解Elves,欢迎大家的关注和使用~
# License
Licensed under the Apache License, Version 2.0