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

using namespace std;

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

void * send_require(void *arg) //функция передачи запросов()
{
    args_s *args = (args_s*) arg;

    printf("Поток send_require начал работу\n"); 

    while(args->flag_send_require == 0) //пока (флаг завершения потока передачи запросов не установлен)
    {
        char sndbuf[256];
        int len = sprintf(sndbuf, "request %d", count); // создать запрос

        int sentcount = send(clientSocket, sndbuf, len, 0); // передаем запрос
        if (sentcount == -1) {
            perror("send error");
        }else{
            printf("SEND IS OK, number of request is: %d \n", count);
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
        int reccount = recv(clientSocket, rcvbuf, 256, 0); // принять ответ из сокета;
        if (reccount == -1) {
            perror("recv error");
            sleep(1);
        }else if (reccount == 0) {
            //разъединение
            printf("Lost connection\n");
            sleep(1);
        }else{
            printf("Answer number %d, its : ", count);
            cout << rcvbuf << endl; //вывод ответа на экран
            sleep(1);
        }
    }
    pthread_exit((void*)1);
}


int main() // основная программа()
{

    signal(SIGPIPE, sig_handler);

    int exit = 0, exit1 = 0, exit2 = 0, err = 0;
   
    clientSocket = socket(AF_INET, SOCK_STREAM, 0); // создать сокет для работы с сервером;

    fcntl(clientSocket, F_SETFL, O_NONBLOCK);

    clientSockAddr.sin_family = AF_INET;
    clientSockAddr.sin_port = htons(7000);
    clientSockAddr.sin_addr.s_addr = inet_addr("127.0.0.1");

    err = pthread_create(&id_send_require, NULL, send_require, &arg1);
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
    arg1.flag_set_connection = 1;

    pthread_join(id_send_require, (void**)&exit1);
    printf("Поток send_require закончил работу\n"); 
    
    pthread_join(id_accept_answer, (void**)&exit2);
    printf("Поток accept_answer закончил работу\n"); 

    shutdown(clientSocket, 2);  //     закрыть соединение с сервером;
    close(clientSocket); // закрыть сокет;

    printf("Программа закончила работу\n"); 

    return 0;
}
