//lab 2_2_trywait // semaphore
//8363 NersisyanA

#include <stdlib.h>
#include <stdio.h>
#include <unistd.h>
#include <semaphore.h>
#include <pthread.h>
#include <time.h>
#include <errno.h>

sem_t sem_id;

//func for thread 1
void *thread_func_1(void *arg)
{
    printf("\nThread 1 was started...\n");
    bool* flag = (bool*)arg;
    while (!*flag)
    {
        //trywait
        int ret =  sem_trywait(&sem_id);
        if(ret == 0) {
            //critical section 
            for (int i = 0; i < 5; i++) {
                printf("1");
                fflush(stdout);
                sleep(1);
            }
            //end of critical section

            ret = sem_post(&sem_id);
            if (ret == 0) {
                sleep(1);
            }
            else {
                perror("sem_post");
                //exit(EXIT_FAILURE);
            }
        }
        // error on trywait
        else {
            perror("\nsem_trywait");
            //exit(EXIT_FAILURE);
        }
    }
    int* returnCode = new int(3);
    printf("\nThread 1 was ended...\n");
    pthread_exit(returnCode);
}

//func for thread 2
void *thread_func_2(void *arg)
{
    printf("\nThread 2 was started...\n");
    bool* flag = (bool*)arg;
    while (!*flag)
    {
        int ret =  sem_trywait(&sem_id);
        if(ret == 0) {
            for (int i = 0; i < 5; i++) {
                printf("2");
                fflush(stdout);
                sleep(1);
            }

            ret = sem_post(&sem_id);
            if (ret == 0) {
                sleep(1);
            }
            else {
                perror("sem_post");
                //exit(EXIT_FAILURE);
            }
        }
        else {
            perror("\nsem_trywait");
            //exit(EXIT_FAILURE);
        }
    }
    int* returnCode = new int(4);
    printf("\nThread 2 was ended...\n");
    pthread_exit(returnCode);
}


int main()
{
    int result;
    int* returnCode1, *returnCode2;
    bool flag1 = false, flag2 = false;
    pthread_t thread1, thread2;
    
    //create semaphore
    result = sem_init(&sem_id, 0, 1);
    if (result != 0) {
        printf("\nError on creating the 1st semaphore. Error code %i", result);
        return -1;
    }

    //create threads
    result = pthread_create(&thread1, NULL, thread_func_1, (void*)&flag1);
    if (result != 0) {
        printf("\nError on creating the 1st thread. Error code %i", result);
        return -1;
    }
    result = pthread_create(&thread2, NULL, thread_func_2, (void*)&flag2);
    if (result != 0) {
        printf("\nError on creating the 2nd thread. Error code %i", result);
        return -1;
    }

    //wainting... press any key
    getchar();
    printf("\nJoining threads process starts...\n");

    //install flags
    flag1 = true;
    flag2 = true;

    //join
    result = pthread_join(thread1, (void**)&returnCode1);
    if (result != 0) {
        printf("\nError on joining the 1st thread. Error code %i\n", result);
        return -1;
    }
    result = pthread_join(thread2, (void**)&returnCode2);
    if (result != 0) {
        printf("\nError on joining the 2nd thread. Error code %i\n", result);
        return -1;
    }

    //print exit codes and exit
    printf("Thread 1 exited with code: %d \n", *returnCode1);
    printf("Thread 2 exited with code: %d \n", *returnCode2);
    
    sem_destroy(&sem_id);
    printf("Semaphore destroyed!\n");

    delete returnCode1;
    delete returnCode2;

    printf("Done!\n");
    return 0;
}