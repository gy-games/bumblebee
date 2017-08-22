from daemonize import Daemonize
import sys,base64,uuid
from subprocess import Popen,PIPE
pid = "/tmp/bbb_daemon_"+sys.argv[2]
b64cmd=sys.argv[1]
def main():
    cmd=base64.b64decode(b64cmd)
    Popen(cmd, shell=True)
daemon = Daemonize(app=b64cmd, pid=pid, action=main)
daemon.start()
