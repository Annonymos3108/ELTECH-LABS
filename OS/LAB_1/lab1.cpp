//lab 1 // pthread

//#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>
#include <unistd.h>
#include <errno.h>

struct pthread_args {
    bool flag;
};

//func for thread 1
void *thread_func_1(void *arg)
{
    printf("Thread 1 was started...\n");
    pthread_args* args = (pthread_args*)arg;
    while (args->flag)
    {
        printf("1\n");
        sleep(1);
    }
    printf("Thread 1 was ended...\n");
    pthread_exit((void*)1);
}

//func for thread 2
void *thread_func_2(void *arg)
{
    printf("Thread 2 was started...\n");
    pthread_args* args = (pthread_args*)arg;
    while (args->flag)
    {
        printf("2\n");
        sleep(1);
    }
    printf("Thread 2 was ended...\n");
    pthread_exit((void*)2);
}


int main(int argc, char *argv[])
{
    int thread_1_exitcode = 0, thread_2_exitcode = 0, result;
    pthread_t thread1, thread2;
    pthread_args arg1, arg2;

    arg1.flag = true;
    arg2.flag = true;
  

    //create
    result = pthread_create(&thread1, NULL, thread_func_1, &arg1);
    if (result != 0) {
        perror("Error on creating the 1st thread...\n");
        return -1;
    }
    result = pthread_create(&thread2, NULL, thread_func_2, &arg2);
    if (result != 0) {
        perror("Error on creating the 2nd thread...\n");
        return -1;
    }


    //wainting... press any key
    getchar();

    //install flags
    arg1.flag = false;
    arg2.flag = false;

    //join
    result = pthread_join(thread1, (void **)&thread_1_exitcode);
    if (result != 0) {
        perror("Error on joining the 1st thread...\n");
        return -1;
    }
    result = pthread_join(thread2, (void **)&thread_2_exitcode);
    if (result != 0) {
        perror("Error on joining the 2nd thread...\n");
        return -1;
    }

    //print exit codes and exit
    printf("Thread 1 exited with code: %i \n", thread_1_exitcode);
    printf("Thread 2 exited with code: %i \n", thread_2_exitcode);
    printf("Done!\n");
    return 0;
}