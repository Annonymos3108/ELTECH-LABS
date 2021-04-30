#include <iostream>
#include <pthread.h>
#include <unistd.h>
#include <semaphore.h>
#include <fcntl.h>
#include <sys/stat.h>
#include <sys/mman.h>
#include <netdb.h>
#include <cstring>
#include <mqueue.h>

#define QUEUE "/myFqueue"
#define MAX_MSG_SIZE 8

typedef struct {
    int flag;
} args_s;

struct mq_attr attr;
mqd_t msg_q;

void * proc(void *arg){

    int res, s, len;
    struct addrinfo *result;
    char buf[MAX_MSG_SIZE];    
    args_s *args = (args_s*) arg;
    s = getaddrinfo("localhost", NULL, NULL, &result);
    if (s != 0) {
        fprintf(stderr, "getaddrinfo: %s\n", gai_strerror(s));
        exit(EXIT_FAILURE);
    }

    freeaddrinfo(result);

    while (args->flag == 0) {

        printf("%d", result->ai_protocol);
        fflush(stdout);
        len = sprintf(buf, "%d", result->ai_protocol);
        res = mq_send(msg_q, buf, len, 0);
        if (res == -1) {
                perror("mq_send");
        }else{
            printf(": sended successfully\n");
        }
 
        sleep(1);       
        result->ai_protocol++;
    }

    pthread_exit((void*)1);
}

int main(){

    args_s arg;
    int exit, err = 0;
    pthread_t id;

    arg.flag = 0;
    
    printf("Lab 8_1 starts...\n"); 

    attr.mq_maxmsg = 20;
    attr.mq_msgsize = 10000;
    attr.mq_flags = 0;
    attr.mq_curmsgs = 0;

    msg_q = mq_open(QUEUE, O_CREAT | O_WRONLY | O_NONBLOCK, 0644, &attr);
    if(msg_q == (mqd_t)-1)
    {
        perror("mq_open");
        return 1;
    }
    
    mq_getattr(msg_q, &attr);
    printf("Maximum # of messages on queue:   %ld\n", attr.mq_maxmsg);
    printf("Maximum message size:             %ld\n", attr.mq_msgsize);

    err = pthread_create(&id, NULL, proc, &arg);
    if(err != 0)
    {
        perror("pthread_create");
        return 2;    
    }

    printf("\nPress <ENTER> to stop\n");

    getchar();
    arg.flag = 1;
    pthread_join(id, (void**)&exit);
    printf("Thread %d joined\n", exit);
    err = mq_unlink(QUEUE);
    if(err == -1)
    {
        perror("mq_unlink");
        return 3;
    }
    err = mq_close(msg_q);
    if(err == -1)
    {
        perror("mq_close");
        return 4;
    }

    printf("\nLab 8_1 end\n");
    return 0;
}