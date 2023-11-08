import socket
import threading
sock=socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
sock_pt=socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
ip_addr="192.168.0.3"#"192.168.137.1"    "192.168.137.1";
sock.bind((ip_addr,5555))
unity_sock=socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
unity_sock.bind(("192.168.0.3",5560))
unity_recv_sock=socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
unity_recv_sock.bind(("192.168.0.3",5550))
sock_pt.bind((ip_addr,5566))
watch_ip=socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
watch_ip.bind((ip_addr,5590))
ip_received=False
watch_ipaddr="192.168.0.15"
def pointToUnity():
    while(True):
        #print(sock_pt)
        data,addr=sock_pt.recvfrom(1024)
        #print(data)
        msg=str(data,'utf-8')
        if(msg!=""):print("1" + msg)
        #msg_arr=msg.split(",")
        unity_sock.sendto(data,("192.168.0.16",5566))
def watchToUnity():
    while(True):
        data,addr=sock.recvfrom(1024)
        msg=str(data,'utf-8')
        if(msg!=""):print("2 " + msg)
        #msg_arr=msg.split(",")
        unity_sock.sendto(data,("192.168.0.16",5556))
        
def unityToWatch():
    while(True):
        data,addr=unity_recv_sock.recvfrom(1024)
        msg=str(data,'utf-8')
        print("3" + msg)
        if(msg!=""):
            watch_ip.sendto(data,(watch_ipaddr,5555))

thread1=threading.Thread(target=pointToUnity)
thread2=threading.Thread(target=watchToUnity)
thread3=threading.Thread(target=unityToWatch)
thread1.start()
thread2.start()
thread3.start()