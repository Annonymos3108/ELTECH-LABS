// lab 6_2 Reader

#include <stdio.h>
#include <time.h>
#include <pthread.h>
#include <string.h>
#include <unistd.h>
#include <errno.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <sys/mman.h>
#include <sys/stat.h>
#include <semaphore.h>
#include <stdlib.h>


bool   flag = false;
sem_t* semaphoreID_w;
sem_t* semaphoreID_r;
FILE*  file;
int*   shmPtr;


void* function(void* data) {
    int count = 0;

    while (!flag) {
        int semStatus_r;
        sem_getvalue(semaphoreID_r, &semStatus_r);

        if (semStatus_r == 0) {
            count = 0;
            int message;

            sem_wait(semaphoreID_w);

            memcpy(&message, shmPtr, sizeof(int));
            printf("Read: %d\n", message);
            fflush(stdout);

            sem_wait(semaphoreID_r);
            sem_post(semaphoreID_w);
        }
        else if (semStatus_r == 1) {
            count++;

            if (count == 5) {
                printf("Writer is offline\n");
                printf("Press <ENTER> to stop\n");
                pthread_exit(NULL);
            }
        }
        sleep(1);
    }
    pthread_exit(NULL);
}



int main() {
    srand(time(NULL));

    printf("Lab 6_2 start\n");
    printf("Press <ENTER> to stop\n");

    pthread_t threadID;
    char      semaphoreName_w[] = {"/semW"};
    char      semaphoreName_r[] = {"/semR"};
    char      shmName[]         = {"memory"};
    int       shm               = shm_open(shmName, O_CREAT | O_RDWR, 0644);

    ftruncate(shm, sizeof(int));

    shmPtr        = (int*)mmap(0, sizeof(int), PROT_WRITE | PROT_READ, MAP_SHARED, shm, 0);
    semaphoreID_w = sem_open(semaphoreName_w, O_CREAT, 0644, 0);
    semaphoreID_r = sem_open(semaphoreName_r, O_CREAT, 0644, 0);

    int semStatus_r;
    sem_getvalue(semaphoreID_r, &semStatus_r);

    if (semStatus_r == 0) {
        sem_wait(semaphoreID_r);
    }

    pthread_create(&threadID, NULL, function, NULL);

    getchar();

    flag = true;

    pthread_join(threadID, NULL);

    sem_close(semaphoreID_r);
    sem_unlink(semaphoreName_r);

    sem_close(semaphoreID_w);
    sem_unlink(semaphoreName_w);

    munmap(shmPtr, sizeof(int));
    close(shm);
    shm_unlink(shmName);

    printf("lab6_2 end\n");
    return 0;
}