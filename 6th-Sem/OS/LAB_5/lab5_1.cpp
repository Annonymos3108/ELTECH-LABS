// lab5_1

#include <stdio.h>
#include <pthread.h>
#include <string.h>
#include <unistd.h>
#include <errno.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <semaphore.h>


bool   flag = false;
sem_t* semaphoreID;
FILE*  file;


void* function(void* data) {
    char* message = (char*)data;

    while (!flag) {
        sem_wait(semaphoreID);

        for (int i = 0; i < 5; i++) {
            printf("%c", *message);
            fprintf(file, "%c", *message);
        }

        fflush(stdout);
        fflush(file);
        sem_post(semaphoreID);
        sleep(1);
    }

    pthread_exit(NULL);
}



int main() {
    printf("Lab5_1 start\n");
    printf("Press <ENTER> to stop\n");

    char      semaphoreName[] = {"/sem"};
    char      message = '1';
    pthread_t threadID;

    semaphoreID = sem_open(semaphoreName, O_CREAT, 0644, 1);

    if (semaphoreID == NULL) {
        printf("%s\n", strerror(errno));
        return 0;
    }

    file = fopen("output.txt", "a+");

    pthread_create(&threadID, NULL, function, &message);

    getchar();

    flag = true;

    pthread_join(threadID, NULL);

    sem_close(semaphoreID);
    sem_unlink(semaphoreName);

    printf("\nLab5_1 done\n");
    return 0;
}