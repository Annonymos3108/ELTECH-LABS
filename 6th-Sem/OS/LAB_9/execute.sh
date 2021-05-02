g++ client.cpp -o client -lpthread -lrt
g++ server.cpp -o server -lpthread -lrt

./client
./server

#gnome-terminal -- ./client
#gnome-terminal -- ./server