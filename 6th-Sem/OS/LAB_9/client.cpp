#include <iostream>
#include <pthread.h>
#include <fcntl.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <signal.h>
#include <cstring>
#include <netdb.h>
#include <unistd.h>

#define MAXLINE 256

pthread_t SendMsg, AcceptMsg;

struct sockaddr_in serverSockAddr; 
socklen_t serverSockAddrLen;

typedef struct {
    int flag_accept_answer = 0;
    int flag_send_require = 0;
} args_s;
    
args_s arg1;
int count = 1;
int clientSocket; 

void sig_handler(int signo)
{
    printf("SIGPIPE received\n");
}

void* send_msg(void *arg) 
{
    args_s *args = (args_s*) arg;

    printf("Thread SendMsg start...\n"); 

    while(args->flag_send_require == 0) 
    {
        char sndbuf[256];
        int len = sprintf(sndbuf, "Request %d", count); 

        int sentcount = sendto(clientSocket, sndbuf, len, 
            0, (const struct sockaddr *) &serverSockAddr, 
            sizeof(serverSockAddr));
        if (sentcount == -1) {
            perror("sendto");
        }else{
            int l = count - 1;
            printf("Send Success, Request number is: %d\n", l);
            count++;
        }
        sleep(1);
    }
    pthread_exit((void*)1);
}

void* accept_answer(void *arg) 
{
    args_s *args = (args_s*) arg;
    char rcvbuf[256];
    
    printf("Thread AcceptMsg start...\n"); 

    while(args->flag_accept_answer == 0) 
    {
        memset(rcvbuf, 0, 256);
        int reccount = recvfrom(clientSocket, rcvbuf, MAXLINE,
            0, (struct sockaddr *) &serverSockAddr, &serverSockAddrLen); 
        if (reccount == -1) {
            perror("recvfrom error");
            sleep(1);
        }else{
            printf("Answer Message number %d, is : ", count);
            std::cout << rcvbuf << std::endl;
            sleep(1);
        }
    }
    pthread_exit((void*)1);
}


int main() 
{
    printf("Lab 9 - Client start...\n"); 
    printf("Press <ENTER> to stop\n");

    signal(SIGPIPE, sig_handler);

    int exit = 0, exit1 = 0, exit2 = 0, err = 0;
   
    clientSocket = socket(AF_INET, SOCK_DGRAM, 0);

    fcntl(clientSocket, F_SETFL, O_NONBLOCK);

    serverSockAddr.sin_family = AF_INET;
    serverSockAddr.sin_port = htons(7000);
    serverSockAddr.sin_addr.s_addr = inet_addr("127.0.0.1");

    err = pthread_create(&SendMsg, NULL, send_msg, &arg1);
    if(err != 0)
    {
        perror("pthread_create");   
    } 

    err = pthread_create(&AcceptMsg, NULL, accept_answer, &arg1);
    if(err != 0)
    {
        perror("pthread_create");
    } 


    getchar();

    printf("Stop...\n"); 

    arg1.flag_accept_answer = 1;
    arg1.flag_send_require = 1;

    pthread_join(SendMsg, (void**)&exit1);
    printf("Thread SendMsg end...\n"); 
    
    pthread_join(AcceptMsg, (void**)&exit2);
    printf("Thread AcceptMsg end...\n"); 

    close(clientSocket);

    printf("Lab 9 - Client end success.\n"); 

    return 0;
}
