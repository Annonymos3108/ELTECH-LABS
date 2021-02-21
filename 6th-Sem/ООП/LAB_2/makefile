all : main

.PHONY : all clean

CC = g++
LD = g++

main : main.o application.o polinom.o rational.o

main.o: main.cpp application.h polinom.h number.h rational.h

application.o: application.cpp application.h

polinom.o: polinom.cpp polinom.h

rational.o: rational.cpp rational.h