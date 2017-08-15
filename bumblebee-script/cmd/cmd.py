#!/usr/bin/python
# -*- coding:utf-8 -*-
#
# Bumblebee Elves App
#
#

import commands
import base64
import platform

class cmd():

    def excute(self,param):
        flag="false"
        result={}
        try:
            cmd=param["cmd"]
            cmd=base64.b64decode(cmd)
            if( platform.system() == 'Windows' ):
                import os
                status=0
                winout=os.popen(cmd)
                o = winout.read()
                output=o.decode("gb2312").encode("unicode_escape")
            else:
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
