//lab 4_2 program 2

#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/wait.h>

int main(int argc, char* argv[]) {
    printf("lab4_2 start\n");

    pid_t pid = fork();

    if (pid != 0) {
        printf("Parent  process ID from lab4_2: %d\n", getppid());
        printf("Program process ID from lab4_2: %d\n", getpid());

        int status;
        while (waitpid(pid, &status, WNOHANG) == 0) {
            printf("wait\n");
            sleep(1);
        }

        if (WIFEXITED(status)) {
            printf("Process finished successfully with status: %d \n", WEXITSTATUS(status));
        }
        else {
            printf("Process terminated successfully\n");
        }
    }
    else {
        printf("Parent  process ID from lab4_2: %d\n", getppid());
        printf("Program process ID from lab4_2: %d\n", getpid());

        execle("./lab_04_1", "0", "1", "2", "3", getenv("PATH"), (void*)NULL);
    }

    printf("lab4_2 end\n");
    return 0;
}
