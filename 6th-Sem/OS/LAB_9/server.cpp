#include <iostream>
#include <vector>
#include <pthread.h>
#include <fcntl.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <signal.h>
#include <cstring>
#include <netdb.h>
#include <unistd.h>

#define MAXLINE 256

int serverSocket, clientSocket;
sockaddr_in serverSockAddr, clientSockAddr;

std::vector<std::string> msglist;
pthread_t AcceptAndSend;

typedef struct {
    int flag = 0;
    pthread_mutex_t mutex_p;
} args_s;


char rcvbuf[MAXLINE];

void sig_handler(int signo)
{
    printf("\n\nSIGPIPE is gotten");
    printf("\nClient is offline");
    printf("\nPress <ENTER> to stop");
    fflush(stdout);
}

void * accept_and_send(void *arg) 
{
    int k = 0, res= 0, se=2, s;
    socklen_t serverAddrlen = sizeof(serverSockAddr);
    socklen_t clinetAddrlen = sizeof(clientSockAddr);
    args_s *args = (args_s*) arg;
    addrinfo *result;
    char sndbuf[MAXLINE];

    printf("Thread AcceptAndSend start...\n"); 

    while(args->flag != 1) 
    {
        s = recvfrom(serverSocket, rcvbuf, MAXLINE,
            0, (struct sockaddr *) &clientSockAddr, 
            &clinetAddrlen);
        if (s == -1) {
            perror("recvfrom");
            sleep(1);
       
        }else{
            std::cout << "Accepted Message is: " << rcvbuf << std::endl;
            
            int len = sprintf(sndbuf, "%d", se++);
            int sentcount = sendto(serverSocket, sndbuf, len, 
                0, (struct sockaddr *) &clientSockAddr, clinetAddrlen); 
            if (sentcount == -1) {
                perror("send error");
            }else{
                sleep(1);
                std::cout << " Answer of: " << rcvbuf << ", is: " << sndbuf << std::endl;
            }
        }        
    }
    pthread_exit((void*)1);
}

int main() 
{
    printf("Lab 9 - Server start...\n"); 
    printf("Press <ENTER> to stop\n");
    
    args_s arg1;
    signal(SIGPIPE, sig_handler);
    int exit = 0, err = 0;

    serverSocket = socket(AF_INET, SOCK_DGRAM, 0);
    fcntl(serverSocket, F_SETFL, O_NONBLOCK);
    
    serverSockAddr.sin_family = AF_INET;
    serverSockAddr.sin_port = htons(7000);
    serverSockAddr.sin_addr.s_addr = inet_addr("127.0.0.1");

    bind(serverSocket, (struct sockaddr*)&serverSockAddr, sizeof(serverSockAddr));
    
    err = pthread_create(&AcceptAndSend, NULL, accept_and_send, &arg1);
    if(err != 0)
    {
        perror("pthread_create");
    }    

    getchar(); 

    printf("Stop...\n"); 
    
    arg1.flag = 1;

    pthread_join(AcceptAndSend, (void**)&exit);
    printf("Thread AcceptAndSend end...\n");

    close(serverSocket);
    printf("Lab 9 - Server end success.\n");
    return 0;
}
