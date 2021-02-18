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
    bool* flag = (bool*)arg;
    while (!*flag)
    {
        printf("1\n");
        sleep(1);
    }
    int* returnCode = new int(2);
    printf("Thread 1 was ended...\n");
    pthread_exit(returnCode);
}

//func for thread 2
void *thread_func_2(void *arg)
{
    printf("Thread 2 was started...\n");
    bool* flag = (bool*)arg;
    while (!*flag)
    {
        printf("2\n");
        sleep(1);
    }
    int* returnCode = new int(3);
    printf("Thread 2 was ended...\n");
    pthread_exit(returnCode);
}


int main(int argc, char *argv[])
{
    bool flag1 = false;
    bool flag2 = false;

    pthread_t thread1, thread2;
   
    int* returnCode1, *returnCode2;

    int result;
  
    //create
    result = pthread_create(&thread1, NULL, thread_func_1, (void*)&flag1);
    if (result != 0) {
        perror("Error on creating the 1st thread...\n");
        return -1;
    }
    result = pthread_create(&thread2, NULL, thread_func_2, (void*)&flag2);
    if (result != 0) {
        perror("Error on creating the 2nd thread...\n");
        return -1;
    }


    //wainting... press any key
    getchar();

    //install flags
    flag1 = true;
    flag2 = true;

    //join
    result = pthread_join(thread1, (void **)&returnCode1);
    if (result != 0) {
        perror("Error on joining the 1st thread...\n");
        return -1;
    }
    result = pthread_join(thread2, (void **)&returnCode2);
    if (result != 0) {
        perror("Error on joining the 2nd thread...\n");
        return -1;
    }

    //print exit codes and exit
    printf("Thread 1 exited with code: %d \n", *returnCode1);
    printf("Thread 2 exited with code: %d \n", *returnCode2);
    
    delete returnCode1;
    delete returnCode2;

    printf("Done!\n");
    return 0;
}