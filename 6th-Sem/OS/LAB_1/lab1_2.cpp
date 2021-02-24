//lab 1 // pthread

#include <stdio.h>
#include <pthread.h>
#include <unistd.h>
#include <errno.h>
#include <string.h>

/*
    Итак, попробуем "Смоделировать ситуацию, когда
    pthread_join выдает ошибку".
    Самый простой способ такой ситуации, который мне удалось 
    найти в просторах интернета -- это "отсоединить" (я знаю что 
    такого понятия не существует) доченый поток и вызвать 
    pthread_join в потоке для себя.
    Для этого я выбрал прототип для потока, функцию thread_func_1 
    --> см. void *thread_func_1(void *arg)
*/


//func for thread 1
void *thread_func_1(void *arg)
{
    printf("\nThread 1 was started...\n");
    bool* flag = (bool*)arg;
    while (!*flag)
    {
        printf("1");
        fflush(stdout);
        sleep(1);
    }

    //чтобы было где хранить данные для этого потока
    pthread_t self; 

    //код ошибки, почему не просто int? 
    //чтобы после завершении/ошибки и прочего
    //данные остались в куче, а не уничтожились вместе со стеком
    int* code = new int;

    //получаем "указатель" на текущий поток
    self=pthread_self(); 
    
    //пробуем "сломать"
    *code=pthread_join(self, NULL); 
    
    //выводим что получилось, сначала код, потом сообщение об ошибке
    printf("Joining self, error code=%d, message %s\n", 
         *code, strerror(*code));

    //пробуем отсоединить, чтоб сломать все окончательно)
    pthread_detach(self); 
    //повторяем те же действия для вывода ошибки
    *code=pthread_join(self, NULL); 
    printf("Joining self after detach, error code=%d, message %s\n", 
         *code, strerror(*code)); 

    int* returnCode = code;
    printf("\nThread 1 was ended...\n");
    pthread_exit(returnCode);
    //return 0;
}

//func for thread 2
void *thread_func_2(void *arg)
{
    printf("\nThread 2 was started...\n");
    bool* flag = (bool*)arg;
    while (!*flag)
    {
        printf("2");
        fflush(stdout);
        sleep(1);
    }
    int* returnCode = new int(4);
    printf("\nThread 2 was ended...\n");
    pthread_exit(returnCode);
}


int main(int argc, char *argv[])
{
    bool flag1 = false;
    bool flag2 = false;

    pthread_t thread1, thread2;
   
    int* returnCode1, *returnCode2;

    int result;
  
    //create
    result = pthread_create(&thread1, NULL, thread_func_1, (void*)&flag1);
    if (result != 0) {
        printf("\nError on creating the 1st thread. Error code=%d, Error: %s",
             result, strerror(result));
        return -1;
    }
    result = pthread_create(&thread2, NULL, thread_func_2, (void*)&flag2);
    if (result != 0) {
        printf("\nError on creating the 2nd thread. Error code=%d, Error: %s",
             result, strerror(result));
        return -1;
    }


    //wainting... press any key
    getchar();

    //install flags
    flag1 = true;
    flag2 = true;

    //join
    result = pthread_join(thread1, (void**)&returnCode1);
    if (result != 0) {
        printf("\nError on joining the 1st thread. Error code=%d, Error: %s",
             result, strerror(result));
        return -1;
    }
    result = pthread_join(thread2, (void**)&returnCode2);
    if (result != 0) {
        printf("\nError on joining the 2nd thread. Error code=%d, Error: %s",
             result, strerror(result));
        return -1;
    }

    //print exit codes and exit
    printf("Thread 1 exited with code: %d \n", *returnCode1);
    printf("Thread 2 exited with code: %d \n", *returnCode2);
    
    delete returnCode1;
    delete returnCode2;

    printf("Done!\n");
    return 0;
}