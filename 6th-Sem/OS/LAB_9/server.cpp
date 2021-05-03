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
#include <signal.h>

#define MAXLINE 256

int serverSocket;
struct sockaddr_in serverSockAddr; 
std::vector<std::string> msglist; // объявить идентификатор очереди запросов на обработку;
// ????объявить идентификатор очереди ответов на передачу;
  //  объявить флаг завершения потока приема запросов;
  //  объявить флаг завершения потока обработки запросов;
  //  объявить флаг завершения потока передачи ответов;
  //  объявить флаг завершения потока ожидания соединений;

 //   объявить идентификатор потока приема запросов;
 //   объявить идентификатор потока обработки запросов;
  //  объявить идентификатор потока передачи ответов;
  //  объявить идентификатор потока ожидания соединений;
pthread_t id_accept_require, id_send_answer;

typedef struct {
    int flag_accept_require = 0;
    int flag_send_answer = 0;
    pthread_mutex_t mutex_p;
} args_s;

args_s arg1;

char rcvbuf[256];

void sig_handler(int signo)
{
    printf("SIGPIPE received\n");
}

void * accept_require(void *arg) // функция приема запросов()
{
    int k = 0;
    int len = sizeof(serverSockAddr);
    args_s *args = (args_s*) arg;

    printf("Поток accept_require начал работу\n"); 

    while(args->flag_accept_require != 1) // (флаг завершения потока приема не установлен) 
    {
        int reccount = recvfrom(serverSocket, rcvbuf, MAXLINE,
            MSG_WAITALL, (struct sockaddr *) &serverSockAddr, 
            (socklen_t *) &len); //   принять запрос из сокета;
        if (reccount == -1) {
            perror("recv");
            sleep(1);
       
        }else{
        //здесь запрос надо положить в очередь и учесть, что эта очередь – общий ресурс с потоком передачи ответов, т.е. нужен мьютекс
        k = pthread_mutex_trylock(&(args->mutex_p));
        while(k != 0) {
            perror("pthread_mutex_trylock");
            k = pthread_mutex_trylock(&(args->mutex_p));
            sleep(1);
        } // мьютекс захватить;
        msglist.push_back(std::string(rcvbuf)); //    поместить запрос в очередь;
        std::cout << "Accept is ok, number of request is: " << rcvbuf << std::endl;
        pthread_mutex_unlock(&(args->mutex_p)); // мьютекс освободить;
        }
    }
    pthread_exit((void*)5);
}

void * send_answer(void *arg) // функция передачи ответов()
{
    int k;
    args_s *args = (args_s*) arg;

    int res, s, len;
    struct addrinfo *result;
    char sndbuf[MAXLINE];

    s = getaddrinfo("localhost", NULL, NULL, &result);
    if (s != 0) {
        fprintf(stderr, "getaddrinfo: %s\n", gai_strerror(s));
        exit(EXIT_FAILURE);
    }

    res = result->ai_protocol;

    freeaddrinfo(result);

    printf("Поток send_answer начал работу\n");

    while(args->flag_send_answer != 1){ // пока (флаг завершения потока передачи не установлен)
        k = pthread_mutex_trylock(&(args->mutex_p));
        while(k != 0) {
            perror("pthread_mutex_trylock");
            k = pthread_mutex_trylock(&(args->mutex_p));
            sleep(1);
        } // мьютекс захватить;
        if (!msglist.empty()) {//очередь не пуста
            std::string S  = msglist.back(); //получаете первый в очереди запрос // прочитать ответ из очереди на передачу;
            msglist.pop_back();//удаляете его из очереди
            pthread_mutex_unlock(&(args->mutex_p)); // мьютекс освободить;

            len = sprintf(sndbuf, "%d", res);
        // выполняете функцию, которую требует задание; Например, uname. Функция возвращает структуру из нескольких полей. Берете любое поле, превращаете его в массив символов, например, назовем его sndbuf. Добавляете к нему запрос (для проверки очередности запросов и ответов).
            // Передаете его вызовом:

            int sentcount = sendto(serverSocket, sndbuf, len, 
                MSG_CONFIRM, (const struct sockaddr *) &serverSockAddr,
                sizeof(serverSockAddr)); //         передать ответ в сокет;
            if (sentcount == -1) {
                perror("send error");
            }else{
                sleep(1);
                std::cout << "Send is ok, number of request is: " << rcvbuf << ", its values is: " << sndbuf << std::endl;
                    //send OK
            }

        }else{//очередь пуста
            printf("QUEUE IS EMPTY\n");
            pthread_mutex_unlock(&(args->mutex_p)); // мьютекс освободить;
            sleep(1);
        }
        res++;
    }
    pthread_exit((void*)4);
}


int main() // основная программа()
{

    signal(SIGPIPE, sig_handler);
    int exit = 0, exit1 = 0, exit2 = 0, err = 0;

    printf("Программа начала работу\n"); 

    err = pthread_create(&id_accept_require, NULL, accept_require, &arg1);
    if(err != 0)
    {
        perror("pthread_create");   
    } //             создать поток приема запросов;

    err = pthread_create(&id_send_answer, NULL, send_answer, &arg1);
    if(err != 0)
    {
        perror("pthread_create");
    } // создать поток передачи ответов;
    

    printf("Программа ждет нажатия клавиши\n");

    getchar(); // ждать нажатия клавиши;

    printf("Клавиша нажата\n"); 
    
    arg1.flag_accept_require = 1;
    arg1.flag_send_answer = 1;

    //   установить флаг завершения потока приема запросов;
    //   установить флаг завершения потока обработки запросов;
    //   установить флаг завершения потока передачи ответов;


    pthread_join(id_accept_require, (void**)&exit1);
    printf("Поток accept_require закончил работу\n");
    pthread_join(id_send_answer, (void**)&exit2);
    printf("Поток send_answer закончил работу\n");

    //   ждать завершения потока приема запросов;
    //   ждать завершения потока обработки запросов;
    //   ждать завершения потока передачи ответов;
    //   ждать завершения потока ожидания соединений; 

    close(serverSocket); // закрыть сокет для работы с клиентом;

    printf("Программа закончила работу\n");

    return 0;
}
