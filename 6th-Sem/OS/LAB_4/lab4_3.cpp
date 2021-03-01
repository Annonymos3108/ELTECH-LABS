//lab 4_3

#include <errno.h>
#include <string.h>
#include <sched.h>
#include <stdlib.h>
#include <errno.h>
#include <unistd.h>
#include <stdio.h>
#include <sys/types.h>
#include <sys/wait.h>


const int STACK_SIZE = 1024 * 1024;


static int function(void* arg) {
    printf("parent  process ID: %d\n", getppid());
    printf("program process ID: %d\n", getpid());

    char* arg0 = (char*)arg;

    if (arg0 != NULL) {
        char* arg1 = arg0 + strlen(arg0) + 1;
        char* arg2 = arg1 + strlen(arg1) + 1;
        execlp("./lab_04_1", arg0, arg1, arg2, NULL);
    }
    else {
        execle("./lab_04_1", "lab_04_1", getenv("PATH"), (void*)NULL);
    }

    return 0;
}



int main(int argc, char* argv[]) {
    printf("lab4_3 start\n");
    printf("Parent  process ID from lab4_3: %d\n", getppid());
    printf("Program process ID from lab4_3: %d\n", getpid());

    char* stack;

    stack = (char*)malloc(STACK_SIZE);


    pid_t child_pid = clone(function, stack + STACK_SIZE, SIGCHLD, argv[1]);

    if (child_pid == -1) {
        printf("Process not created! Error: %s\n", strerror(errno));
        return 0;
    }

    int status;

    while (waitpid(child_pid, &status, WNOHANG) == 0) {
        printf("wait\n");
        sleep(1);
    }

    if (WIFEXITED(status)) {
        printf("Process finished successfully with status: %d \n", WEXITSTATUS(status));
    }
    else {
        printf("Process finished unsuccessfully\n");
    }

    printf("lab4_3 end\n");
    return 0;
}
