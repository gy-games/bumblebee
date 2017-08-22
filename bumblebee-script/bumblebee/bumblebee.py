#!/usr/bin/python
# -*- coding:utf-8 -*-
#
# Bumblebee Elves App
#
#
import commands
import base64
import platform
 
class bumblebee():

    def shell(self,param):
        flag="false"
        result={}
        if( platform.system() == 'Windows' ):
            result["code"]= "-1"
            result["data"] = "Only Support Linux!"
            return flag,result
        try:
            from subprocess import Popen,PIPE
            import time,os
            flag="false"
            email = param["email"]
            port  = param["port"]
            commands.getstatusoutput("python "+os.path.dirname(os.path.realpath(__file__))+"/shell.py "+port+" "+email)
            time.sleep(5)
            f,r = commands.getstatusoutput("netstat -an | grep "+port+" | grep ESTABLISHED | awk '{print $4}'")
            if f==0 and r!="":
                flag="true"
                result["code"] = "0"
                result["data"] = r
            else:
                result["code"] = "-2"
                commands.getstatusoutput("ps aux | grep netcat | grep "+port+" | awk '{print $2}' | xargs kill -9")
                result["data"] = "connect timeout!"
        except Exception,e:
            result["code"]="-3"
            result["data"] = e 
        return flag,result

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
            result["code"]=str(status)
            result["data"] =output
            flag="true"
        except Exception,e:
            result["code"]="-1"
            result["data"] = e
        return flag,result

    def excute_daemon(self,param):
        flag="false"
        result={}
        if( platform.system() == 'Windows' ):
            result["code"]= "-1"
            result["data"] = "Only Support Linux!"
            return flag,result
        try:
            from subprocess import Popen,PIPE
            import time,os,uuid
            cmd=param["cmd"]
            uuid = str(uuid.uuid1())
            f,r = commands.getstatusoutput("python "+os.path.dirname(os.path.realpath(__file__))+"/excute_daemon.py  "+cmd+" "+uuid)
            if f==0:
                flag="true"
                result["code"] = "0"
                time.sleep(1)
                ff,rr = commands.getstatusoutput("ps aux | grep -v \"\[*\]\" | grep -v \"/sbin/mingetty\" | grep -v \"/sbin/udevd\" | grep -v \"/sbin/rsyslog\" | grep -v \"/sbin/init\" | grep -v \"sshd\" | grep -v \"irqbalance\" | grep -v \"\-bash\" | grep -v \"inet_gethost\" | grep -v ntpd | grep -v dbus-daemon | grep -v \"/sbin/agetty\" | grep -v \"ps aux\"")
                if ff==0 and rr!="":
                    result["data"] = rr
                else:
                    result["data"] = "Get PS ERROR,Please Check by Yourself!"
            else:
                result["code"] = "-2"
                result["data"] = r
        except Exception,e:
            result["code"]="-3"
            result["data"] = e 
        return flag,result
        
if __name__ == '__main__':
    #c=cmd()
    #print c.excute_daemon({"cmd":"dGFpbCAtZiAvdmFyL2xvZy9tZXNzYWdlcw=="})
    pass

