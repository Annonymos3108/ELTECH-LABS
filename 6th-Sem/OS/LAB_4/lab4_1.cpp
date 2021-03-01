//lab 4_1 program 1

#include <unistd.h>
#include <stdio.h>

int main(int argc, char* argv[]) {
    printf("Lab 4 first programm (lab4_1) start\n");
    printf("Parent  process ID from lab4_1: %d\n", getppid());
    printf("Program process ID from lab4_1: %d\n", getpid());

    if (argc == 1) {
        printf("no args\n");
        printf("lab4_1 end\n");
        return 1;
    }
    else {
        for (int i = 0; argv[i] != 0; i++) {
            printf("arg %d: %s \n", i, argv[i]);
            sleep(1);
        }
    }

    printf("Lab 4 first programm (lab4_1) end\n");
    return 10;
}
