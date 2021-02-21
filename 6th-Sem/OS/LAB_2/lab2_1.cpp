//lab 2_1

#include <stdio.h>
#include <pthread.h>
#include <unistd.h>


bool flag1 = false;
bool flag2 = false;
pthread_mutex_t mutex;


void* function1(void* arg) {
    printf("thread1\n");

    bool* flag = (bool*)arg;

    while (!*flag) {
        pthread_mutex_lock(&mutex);

        for (int i = 0; i < 3; i++) {
            printf("1 in progress\n");
            fflush(stdout);
            sleep(1);
        }

        pthread_mutex_unlock(&mutex);
        sleep(1);
    }

    int* returnCode = new int(2);
    printf("end1\n");
    pthread_exit(returnCode);
}

void* function2(void* arg) {
    printf("thread2\n");

    bool* flag = (bool*)arg;

    while (!*flag) {
        pthread_mutex_lock(&mutex);

        for (int i = 0; i < 3; i++) {
            printf("2 in progress\n");
            fflush(stdout);
            sleep(1);
        }

        pthread_mutex_unlock(&mutex);
        sleep(1);
    }

    int* returnCode = new int(3);
    printf("end2\n");
    pthread_exit(returnCode);
}


int main() {
    printf("thread0\n");

    pthread_mutex_init(&mutex, NULL);

    pthread_t t1;
    pthread_t t2;

    pthread_create(&t1, NULL, function1, (void*)&flag1);
    pthread_create(&t2, NULL, function2, (void*)&flag2);

    getchar();

    flag1 = true;
    flag2 = true;

    int* returnCode1;
    int* returnCode2;

    pthread_join(t1, (void**)&returnCode1);
    pthread_join(t2, (void**)&returnCode2);

    printf("thread1 finished with exit code %d\n", *returnCode1);
    printf("thread2 finished with exit code %d\n", *returnCode2);

    pthread_mutex_destroy(&mutex);

    delete returnCode1;
    delete returnCode2;

    printf("end0\n");

    return 0;
}