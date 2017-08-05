#!/usr/bin/python
# coding=utf-8  
# Author: toryzen  
#  
# Create: 2016/06/22
#
#   app worker 示例 [文件名需要与类名一致]

import commands
class cmd():

    def excute(self,param):
        flag="false"
        result={}
        try:
            cmd=param["cmd"]
            (status, output) = commands.getstatusoutput(cmd)
            result["code"]=status
            result["data"] =output
            flag="true"
        except Exception,e:
            result["code"]=-1
            result["data"] = e
        return flag,result
if __name__ == '__main__':
    pass
