g++ client.cpp -o client -lpthread -lrt
g++ server.cpp -o server -lpthread -lrt

gnome-terminal -- ./client
gnome-terminal -- ./server