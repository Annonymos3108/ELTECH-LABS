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
    printf("SIGPIPE received\n");
}

void * accept_and_send(void *arg) // функция приема запросов()
{
    int k = 0, res= 0;
    socklen_t serverAddrlen = sizeof(serverSockAddr);
    socklen_t clinetAddrlen = sizeof(clientSockAddr);
    args_s *args = (args_s*) arg;
    addrinfo *result;
    char sndbuf[MAXLINE];

    printf("Поток Accept and send начал работу\n"); 

    while(args->flag != 1) 
    {
        res = recvfrom(serverSocket, rcvbuf, MAXLINE,
            0, (struct sockaddr *) &clientSockAddr, 
            &clinetAddrlen); //   принять запрос из сокета;
        if (res == -1) {
            perror("recvfrom");
            sleep(1);
       
        }else{
            std::cout << "Accept is ok, number of request is: " << rcvbuf << std::endl;
            res = getaddrinfo("localhost", NULL, NULL, &result);
            if (res != 0) {
                fprintf(stderr, "getaddrinfo: %s\n", gai_strerror(res));
                exit(EXIT_FAILURE);
            }
            
            res = result->ai_protocol;
            freeaddrinfo(result);

            int len = sprintf(sndbuf, "%d", res);
            int sentcount = sendto(serverSocket, sndbuf, len, 
                0, (struct sockaddr *) &clientSockAddr, clinetAddrlen); //         передать ответ в сокет;
            if (sentcount == -1) {
                perror("send error");
            }else{
                sleep(1);
                std::cout << "Send is ok, number of request is: " << rcvbuf << ", its values is: " << sndbuf << std::endl;
            }
        }        
    }
    pthread_exit((void*)1);
}

int main() // основная программа()
{
    args_s arg1;
    signal(SIGPIPE, sig_handler);
    int exit = 0, err = 0;

    serverSocket = socket(AF_INET, SOCK_DGRAM, 0);
    fcntl(serverSocket, F_SETFL, O_NONBLOCK);
    
    serverSockAddr.sin_family = AF_INET;
    serverSockAddr.sin_port = htons(7000);
    serverSockAddr.sin_addr.s_addr = inet_addr("127.0.0.1");

    bind(serverSocket, (struct sockaddr*)&serverSockAddr, sizeof(serverSockAddr));

    printf("Программа начала работу\n"); 
    
    err = pthread_create(&AcceptAndSend, NULL, accept_and_send, &arg1);
    if(err != 0)
    {
        perror("pthread_create");
    }    

    printf("Программа ждет нажатия клавиши\n");

    getchar(); // ждать нажатия клавиши;

    printf("Клавиша нажата\n"); 
    
    arg1.flag = 1;

    pthread_join(AcceptAndSend, (void**)&exit);
    printf("Поток AcceptAndSend закончил работу\n");

    close(serverSocket);
    printf("Программа закончила работу\n");
    return 0;
}
