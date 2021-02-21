all : main

.PHONY : all clean

CC = g++
LD = g++

main : main.o application.o polinom.o

main.o: main.cpp application.h polinom.h number.h

application.o: application.cpp application.h

polinom.o: polinom.cpp polinom.h