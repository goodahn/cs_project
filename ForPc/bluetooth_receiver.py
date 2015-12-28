import bluetooth
import socket
import time
import pyautogui

#########################################################
#               initial position: mouse, screen         #
#########################################################
mouse_x = pyautogui.position()[0]
mouse_y = pyautogui.position()[1]
screen_width = pyautogui.size()[0]
screen_height = pyautogui.size()[1]
pyautogui.PAUSE = 0
#########################################################
#                socket  -  server                      #
#########################################################
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
ip = '127.0.0.1'
port = 8888

s.bind((ip, port))
s.listen(5)

t1 = time.time()
connection, local_address = s.accept()

#########################################################
#                 bluetooth socket                      #
#########################################################

server_sock = bluetooth.BluetoothSocket( bluetooth.RFCOMM )

server_sock.bind(("",bluetooth.PORT_ANY))
server_sock.listen(1)

port = server_sock.getsockname()[1]
uuid = "00001101-0000-1000-8000-00805F9B34FB"

bluetooth.advertise_service( server_sock, "SampleServer",
                             service_id = uuid,
                             service_classes = [ uuid, bluetooth.SERIAL_PORT_CLASS ],
                             profiles = [ bluetooth.SERIAL_PORT_PROFILE ],
                             #protocols = [ OBEX_UUID ]
                             )


print "waiting for connnection %d" %port

client_sock, address = server_sock.accept()
print "Accepted connection from ",address

try:
    while True:
        data = client_sock.recv(4096)
        if len(data) == 0:
            break

        data = data.replace("}", "").replace("{", "").split(",")
        parsed_data = ""

        for i in range(len_data):
                parsed_data += str(data[i].split(":")[1]) + " "
        print "received [%s]" %data
        if data[-1].split(":")[1]==3:
            connection.send(parsed_data)
        elif data[-1].split(":")[1]==2:
            delta_x = data[1].split(":")[0]*(screen_width/150)
            delta_y = data[1].split(":")[1]*(screen_width/150)
            mouse_x = min( 0, max( mouse_x + delta_x ) )
            mouse_y = min( 0, max( mouse_y + delta_y ) )
            pyautogui.moveTo(mouse_x,mouse_y)
            if data[2].split(":")[1] !=0 :
                pyautogui.mouseDown(button='left')
            if data[3].split(":")[1] !=0 :
                pyautogui.mouseUp(button='left')
            if data[4].split(":")[1] !=0 :
                pyautogui.mouseDown(button='right')
            if data[5].split(":")[1] !=0 :
                pyautogui.mouseUp(button='right')
except IOError:
    pass
except Exception:
    print "something error\n"
    pass

print "disconnected"

s.close()
client_sock.close()
server_sock.close()
print "all done, bye bye\n"
