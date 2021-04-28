g++ lab8_1.cpp -o lab8_1 -lpthread -lrt
g++ lab8_2.cpp -o lab8_2 -lpthread -lrt


gnome-terminal -- sudo ./lab8_1
sudo setcap cap_sys_resource=eip lab8_1

gnome-terminal -- sudo ./lab8_2
sudo setcap cap_sys_resource=eip lab8_2