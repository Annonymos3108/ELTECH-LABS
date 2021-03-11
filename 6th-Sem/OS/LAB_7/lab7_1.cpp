// lab 7_1 Writer

/*
Ограничения:
  + 1. Программы должны запускаться в любой очередности.
  + 2. Если запущена только одна программа. она дожна завершится по нажатию клавиши.
  + 3. Если две программы работают и одна из них завершается по нажатию калвиши,
       вторая не должна 'падать', а должна сообщить, что вторая сторона
       отсоединилась, и должна быть способна завершиться по нажатию клавиши.
  + 4. У программ не должно быть прав больше, чем необходимо. 
*/

#include <stdio.h>
#include <pthread.h>
#include <string.h>
#include <unistd.h>
#include <errno.h>
#include <sys/stat.h>
#include <time.h>
#include <stdlib.h>
#include <sys/types.h>
#include <fcntl.h>
#include <signal.h>

int  BUFF_SIZE   = 256;
int  fd;
char FIFO_NAME[] = {"/tmp/Black_pipe"};
bool flag = false;

pthread_t threadID_open;
pthread_t threadID_write;


bool sig_handler(int signo) {
    printf("\nSIGPIPE is gotten");
    fflush(stdout);
    sleep(1);
    return true;
}


void* Writer(void* data) {
    char buf[BUFF_SIZE];
    int  msg, res, count = 0;
    while (!flag) {
        if (signal(SIGPIPE, (__sighandler_t)sig_handler)) {
            msg = random() % 1000;
            int message = sprintf(buf, "Message: %d", msg);
            res = write(fd, buf, message);
            
            if (res != -1) {
                count = 0;
                printf("\nWrite: %s", buf);
                fflush(stdout);
            }
        }
        else {
            count++;
            if(count == 5) {
                printf("Reader is offline\n");
                printf("Press <ENTER> to stop\n");
                pthread_exit(NULL);
            }
        }
        sleep(1);
    }
    pthread_exit(NULL);
}


void* OpenFifoThread(void* data) {
    while (!flag) {
        fd = open(FIFO_NAME, O_WRONLY | O_NONBLOCK | O_CREAT);

        if (fd == -1) {
            printf("\n%s", strerror(errno));
            sleep(1);
        }
        else {
            pthread_create(&threadID_write, NULL, Writer, NULL);
            pthread_exit(NULL);
        }
    }
    pthread_exit(NULL);
}


int main() {
    printf("\nLab 7_1 start");
    printf("\nPress <ENTER> to stop");

    int fifo = mkfifo(FIFO_NAME, 0666);
    if (fifo == -1)
    {
        perror("mkfifo");
        return -1;
    }
    

    int result = pthread_create(&threadID_open, NULL, OpenFifoThread, NULL);
    if (result != 0) {
        perror("pthread_create");
        return -1;
    }

    getchar();

    flag = true;

    result = pthread_join(threadID_open, NULL);
    if (result != 0) {
        perror("pthread_join");
        return -1;
    }

    result = pthread_join(threadID_write, NULL);
    if (result != 0) {
        perror("pthread_join");
        return -1;
    }

    close(fd);
    unlink(FIFO_NAME);

    printf("\nLab7_1 end");
    return 0;
}