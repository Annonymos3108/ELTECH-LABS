// lab 7_2 Reader

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
pthread_t threadID_read;


void* Reader(void* data) {
    char buf[BUFF_SIZE] = {'\0'};
    int count = 0, res;
    while (!flag) {
        memset(buf, 0, BUFF_SIZE);
        res = read(fd, buf, BUFF_SIZE);
        
        if(res == 0)
            perror("\nEOF (End of file)");
        if(res == -1) {
            perror("read");
            count++;
            if(count == 5) {
                printf("Writer is offline\n");
                printf("Press <ENTER> to stop\n");
                pthread_exit(NULL);
            }
        }
        if (res != -1) {
            count = 0;
            if (*buf != 0) {
                printf("\nRead: %s", buf);
                fflush(stdout);
            }
        }        
        sleep(1);
    }
    pthread_exit(NULL);
}


void* OpenFifoThread(void* data) {
    int res;
    while (!flag) {
        fd = open(FIFO_NAME, O_RDONLY | O_NONBLOCK | O_CREAT);

        if (fd == -1) {
            printf("\n%s", strerror(errno));
            sleep(1);
        }
        else {
            res = pthread_create(&threadID_read, NULL, Reader, NULL);
            if (res != 0) {
                perror("pthread_create");
                //exit(EXIT_FAILURE);
            }
            pthread_exit(NULL);
        }
    }
    pthread_exit(NULL);
}


int main() {
    printf("\nLab 7_2 start");
    printf("\nPress <ENTER> to stop\n");

    int fifo = mkfifo(FIFO_NAME, 0666);

    int result = pthread_create(&threadID_open, NULL, OpenFifoThread, NULL);
    if (result != 0) {
        perror("pthread_create");
        return -1;
    }

    getchar();

    flag = true;
    result = pthread_join(threadID_read, NULL);
     if (result != 0) {
        perror("pthread_join");
        return -1;
    }

    close(fd);
    unlink(FIFO_NAME);
    printf("\nLab 7_2 end");
    return 0;
}