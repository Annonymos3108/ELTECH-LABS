#include <iostream>
#include <pthread.h>
#include <unistd.h>
#include <semaphore.h>
#include <fcntl.h>
#include <sys/stat.h>
#include <sys/mman.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netdb.h>
#include <cstring>
#include <mqueue.h>
#include <netdb.h>
#include <vector>
#include <arpa/inet.h>
#include <signal.h>

#define MAXLINE 256

 //   объявить идентификатор потока установления соединения;
 //   объявить идентификатор потока передачи запросов;
//    объявить идентификатор потока приема ответов;  
pthread_t id_send_require, id_accept_answer;
// объявить флаг завершения потока установления соединения;
// объявить флаг завершения потока передачи запросов;
// объявить флаг завершения потока приема ответов;

struct sockaddr_in clientSockAddr; 

typedef struct {
    int flag_accept_answer = 0;
    int flag_send_require = 0;
    int flag_set_connection = 0;
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
            MSG_CONFIRM, (const struct sockaddr *) &clientSockAddr, 
            sizeof(clientSockAddr));
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
    int len = sizeof(clientSockAddr);
    
    printf("Поток accept_answer начал работу\n"); 

    while(args->flag_accept_answer == 0) // пока (флаг завершения потока приема ответов не установлен)
    {
        memset(rcvbuf, 0, 256);
        int reccount = recvfrom(clientSocket, (char *)rcvbuf, MAXLINE,
            MSG_WAITALL, (struct sockaddr *) &clientSockAddr, (socklen_t *) &len); // принять ответ из сокета;
        if (reccount == -1) {
            perror("recv error");
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

    clientSockAddr.sin_family = AF_INET;
    clientSockAddr.sin_port = htons(7000);
    clientSockAddr.sin_addr.s_addr = inet_addr("127.0.0.1");

    err = pthread_create(&id_send_require, NULL, send_msg, &arg1);
    if(err != 0)
    {
        perror("pthread_create");   
    } //             создать поток передачи запросов;

    err = pthread_create(&id_accept_answer, NULL, accept_answer, &arg1);
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

    pthread_join(id_send_require, (void**)&exit1);
    printf("Поток send_require закончил работу\n"); 
    
    pthread_join(id_accept_answer, (void**)&exit2);
    printf("Поток accept_answer закончил работу\n"); 

    close(clientSocket); // закрыть сокет;

    printf("Программа закончила работу\n"); 

    return 0;
}
