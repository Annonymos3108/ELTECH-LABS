touch output.txt
cat /dev/null > output.txt

g++ lab5_1.cpp -lpthread -o lab5_1
g++ lab5_2.cpp -lpthread -o lab5_2

#if you work in Xfce
#xterm -- ./lab5_1
#xterm -- ./lab5_2

#xterm -- tail --pid=$(pidof lab5_1 || pidof lab5_2) -f output.txt

#if you work in KDE
konsole -- ./lab5_1
konsole -- ./lab5_2

konsole -- tail --pid=$(pidof lab5_1 || pidof lab5_2) -f output.txt

#if you work in Gnome
#gnome-terminal -- ./lab5_1
#gnome-terminal -- ./lab5_2
#gnome-terminal -- tail --pid=$(pidof lab5_1 || pidof lab5_2) -f output.txt