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
#include <mqueue.h>

int       BUFF_SIZE    = 32;
bool      flag         = false;
char      QUEUE_NAME[] = {"/my_sel_queue"};
pthread_t threadID;
mqd_t     qd;



void* Receiver(void* data) {
    char buf[BUFF_SIZE] = {'\0'};
    int  status;

    while (!flag) {
        memset(buf, 0, BUFF_SIZE);
        status = mq_receive(qd, buf, BUFF_SIZE, NULL);

        if (status > 0) {
            printf("\nReceive: %s", buf);
            fflush(stdout);
        }
        else if (status == -1) {
            printf("\nReceive error: %s", strerror(errno));
            fflush(stdout);
        }
        sleep(1);
    }
    pthread_exit(NULL);
}



int main() {
    printf("Lab 8_2 Receiver start\n");
    printf("Press <ENTER> to stop\n");

    struct mq_attr attr;

    attr.mq_flags   = 0;
    attr.mq_maxmsg  = 10;
    attr.mq_msgsize = BUFF_SIZE;
    attr.mq_curmsgs = 0;

    qd = mq_open(QUEUE_NAME, O_CREAT | O_RDONLY | O_NONBLOCK, 0644, &attr);

    if (qd == -1) {
        printf("\nOpen error: %s\n", strerror(errno));
        return 0;
    }

    int res = pthread_create(&threadID, NULL, Receiver, NULL);
    if (res != 0) {
        perror("pthread_create");
        return -1;
    }

    getchar();

    flag = true;

    res = pthread_join(threadID, NULL);
    if (res != 0) {
        perror("pthread_join");
        return -1;
    }

    mq_close(qd);
    mq_unlink(QUEUE_NAME);

    printf("\nLab 8_2 Receiver end\n");
    return 0;
}