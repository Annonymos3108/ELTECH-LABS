touch output.txt
cat /dev/null > output.txt

g++ lab5_1.cpp -lpthread -o lab5_1
g++ lab5_2.cpp -lpthread -o lab5_2

#if you work in Gnome
gnome-terminal -- ./lab5_1
gnome-terminal -- ./lab5_2
gnome-terminal -- tail --pid=$(pidof lab5_1 || pidof lab5_2) -f output.txt