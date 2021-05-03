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

pthread_t SendMsg, AcceptMsg;

struct sockaddr_in serverSockAddr; 
socklen_t serverSockAddrLen;

typedef struct {
    int flag_accept_answer = 0;
    int flag_send_require = 0;
} args_s;
    
args_s arg1;
int count = 1;
int clientSocket; // объявить сокет для работы с сервером 

void sig_handler(int signo)
{
    printf("SIGPIPE received\n");
}

void * send_msg(void *arg) //функция передачи запросов()
{
    args_s *args = (args_s*) arg;

    printf("Поток send_msg начал работу\n"); 

    while(args->flag_send_require == 0) //пока (флаг завершения потока передачи запросов не установлен)
    {
        char sndbuf[256];
        int len = sprintf(sndbuf, "Message %d", count); // создать запрос

        int sentcount = sendto(clientSocket, sndbuf, len, 
            0, (const struct sockaddr *) &serverSockAddr, 
            sizeof(serverSockAddr));
        if (sentcount == -1) {
            perror("sendto");
        }else{
            printf("Send Success, msg num is: %d \n", count);
            count++;//счетчик, чтобы следить за очередностью запросов и ответов
        }
        sleep(1);//запросы посылаем 1 раз в секунду
    }
    pthread_exit((void*)1);
}

void * accept_answer(void *arg) // функция приема ответов()
{
    args_s *args = (args_s*) arg;
    char rcvbuf[256];
    
    printf("Поток accept_answer начал работу\n"); 

    while(args->flag_accept_answer == 0) // пока (флаг завершения потока приема ответов не установлен)
    {
        memset(rcvbuf, 0, 256);
        int reccount = recvfrom(clientSocket, rcvbuf, MAXLINE,
            0, (struct sockaddr *) &serverSockAddr, &serverSockAddrLen); // принять ответ из сокета;
        if (reccount == -1) {
            perror("recvfrom error");
            sleep(1);
        }else{
            printf("Answer msg number %d, its : ", count);
            std::cout << rcvbuf << std::endl; //вывод ответа на экран
            sleep(1);
        }
    }
    pthread_exit((void*)1);
}


int main() // основная программа()
{

    signal(SIGPIPE, sig_handler);

    int exit = 0, exit1 = 0, exit2 = 0, err = 0;
   
    clientSocket = socket(AF_INET, SOCK_DGRAM, 0); // создать сокет для работы с сервером;

    fcntl(clientSocket, F_SETFL, O_NONBLOCK);

    serverSockAddr.sin_family = AF_INET;
    serverSockAddr.sin_port = htons(7000);
    serverSockAddr.sin_addr.s_addr = inet_addr("127.0.0.1");

    err = pthread_create(&SendMsg, NULL, send_msg, &arg1);
    if(err != 0)
    {
        perror("pthread_create");   
    } //             создать поток передачи запросов;

    err = pthread_create(&AcceptMsg, NULL, accept_answer, &arg1);
    if(err != 0)
    {
        perror("pthread_create");
    } // создать поток приема ответов;

    printf("Программа начала работу\n"); 

    printf("Программа ждет нажатия клавиши\n");

    getchar(); // ждать нажатия клавиши;

    printf("Клавиша нажата\n"); 

    arg1.flag_accept_answer = 1;
    arg1.flag_send_require = 1;

    pthread_join(SendMsg, (void**)&exit1);
    printf("Поток send_require закончил работу\n"); 
    
    pthread_join(AcceptMsg, (void**)&exit2);
    printf("Поток accept_answer закончил работу\n"); 

    close(clientSocket); // закрыть сокет;

    printf("Программа закончила работу\n"); 

    return 0;
}
