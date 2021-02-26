//lab 3_3 
//pipe fcntl
//8363 NersisyanA

#include <iostream>
#include <stdio.h>      //std input output
#include <pthread.h>    //pthread
#include <unistd.h>     //uid
#include <string.h>     //memset
#include <string>
#include <errno.h>      //perror
#include <fcntl.h>      //O_NONBLOCK
#include <pwd.h>        //passwd, getpwuid

/*
struct passwd {
        char    *pw_name;       // имя пользователя 
        char    *pw_passwd;     // пароль пользователя 
        uid_t   pw_uid;         // id пользователя 
        gid_t   pw_gid;         // id группы 
        char    *pw_gecos;      // настоящее имя 
        char    *pw_dir;        // домашний каталог 
        char    *pw_shell;      // программа-оболочка 
};
*/


int  BUFF_SIZE = 256;
int  field[2];

//write
void *thread_func_1(void *arg)
{
    printf("\nWrite thread was started...\n");
    bool* flag = (bool*)arg;
    char  buf[BUFF_SIZE];
    struct passwd pwent;
    struct passwd *pwentp;

    while (!*flag)
    {
        
        int ret = getpwuid_r(getuid(), &pwent, buf, sizeof buf, &pwentp);
        if (ret != 0)
        {
            perror("getpwuid_r");
        }        
        
        int message = sprintf(buf, "%s\n%s\n", pwent.pw_name, pwent.pw_shell);
        
        ret = write(field[1], buf, message);
        if (ret == 0) {
            printf("End of file, write channel was closed");
            sleep(1);
        }
        if (ret == -1) {
            perror("write");
            printf("\n\r");
            //exit(EXIT_FAILURE);
        }
        sleep(1);
    }
    int* returnCode = new int(3);
    printf("\nWrite thread was closed...\n");
    pthread_exit(returnCode);
}

//read
void *thread_func_2(void *arg)
{
    printf("\nRead thread was started...\n");
    bool* flag = (bool*)arg;
    char  buf[BUFF_SIZE];

    while (!*flag)
    {
        
        int res = read(field[0], buf, BUFF_SIZE);
        
        if (res == 0) {
            printf("End of file, read channel was closed");
            sleep(1);
        }
        if (res == -1) {
            perror("read");
            printf("\n\r");
            //exit(EXIT_FAILURE);
        }
        else {
            printf("%s\n", buf);           
        }
        memset(buf, 0, BUFF_SIZE);
        sleep(1);
        
    }
    int* returnCode = new int(4);
    printf("\nRead thread was closed...\n");
    pthread_exit(returnCode);
}


int main()
{
    int result;
    int* returnCode1, *returnCode2;
    bool flag1 = false, flag2 = false;
    pthread_t thread1, thread2;
    
    //create pipe
    result = pipe(field);
    if (result != 0) {      //linux man: 0 is ok, -1 is error
        perror("pipe2");
        return -1;
    }
    
    int fl1 = fcntl(field[0], F_GETFL);
    int fl2 = fcntl(field[1], F_SETFL);

    fcntl(field[0], F_GETFL, fl1 | O_NONBLOCK);
    fcntl(field[1], F_SETFL, fl2 | O_NONBLOCK);

    //create threads
    result = pthread_create(&thread1, NULL, thread_func_1, (void*)&flag1);
    if (result != 0) {
        perror("pthread_create");
        return -1;
    }
    result = pthread_create(&thread2, NULL, thread_func_2, (void*)&flag2);
    if (result != 0) {
        perror("pthread_create");
        return -1;
    }

    //wainting... press any key
    getchar();
    printf("\nJoining threads process was started...\n");

    //install flags
    flag1 = true;
    flag2 = true;

    //join
    result = pthread_join(thread1, (void**)&returnCode1);
    if (result != 0) {
        perror("pthread_join");
        return -1;
    }
    result = pthread_join(thread2, (void**)&returnCode2);
    if (result != 0) {
        perror("pthread_join");
        return -1;
    }
 
    //print exit codes and exit
    printf("Read thread exited with code: %d \n", *returnCode1);
    printf("Write thread exited with code: %d \n", *returnCode2);
    

    result = close(field[0]);
    if (result != 0) {
        perror("close");
        return -1;
    }
    
    result = close(field[1]);
    if (result != 0) {
        perror("close");
        return -1;
    }

    delete returnCode1;
    delete returnCode2;

    printf("Done!\n");
    return 0;
}