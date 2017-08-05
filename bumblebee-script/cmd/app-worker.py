#!/usr/bin/python
# coding=utf-8  
# Author: toryzen  
#
#   app worker入口

import sys
import json
import base64
import os
sys.path.append(os.path.abspath(__file__))

def agentExec(app,func,jsonParam=""):
    flag = "false"
    try:
        param = ""
        if(jsonParam!=""):
            param = json.loads(repr(base64.b64decode(jsonParam))[1:-1])
        
        #print param
        agentObj = __import__(app)
        agentClass = getattr(agentObj,app)
        obj = agentClass() 
        mtd = getattr(obj,func)
        flag,result = mtd(param)
    except Exception,e:
        flag,result = "false",e
    elvesPrint(flag,result)
    
def elvesPrint(flag,result):
    print "<ElvesWFlag>"+str(flag)+"</ElvesWFlag> <ElvesWResult>"+str(result)+"</ElvesWResult>"
    
if __name__ == '__main__':
    if(len(sys.argv)==3):
        agentExec(sys.argv[1],sys.argv[2])
    elif(len(sys.argv)==4):
        agentExec(sys.argv[1],sys.argv[2],sys.argv[3])
    else:
        elvesPrint("false","param error")