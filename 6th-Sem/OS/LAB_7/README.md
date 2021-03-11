# Взаимодействие процессов через именованные каналы

Создание именованного канала производится вызовом:

```C++
int mkfifo(const char *pathname, mode_t mode)
```

где:</br>
`pathname` – имя именованного канала;</br>
`mode` – права доступа к именованному каналу.

Открытие именованного канала производится вызовом:

```C++
int open(const char *pathname, int flags)
```

где:</br>
`pathname` – имя именованного канала;</br>
`flags` – флаги, задающие режим доступа к именованному каналу.

Запись данных в именованный канал производится вызовом:

```C++
ssize_t write(int fd, const void *buf, size_t count)
```

где:</br>
`fd` – дескриптор именованного канала;</br>
`buf` – буфер для записи данных;</br>
`count` – количество записанных данных.

Чтение данных из именованного канала производится вызовом:

```C++
ssize_t read(int fd, void *buf, size_t count)
```
где:
`fd` – дескриптор именованного канала;</br>
`buf` – буфер для чтения данных;</br>
`count` – размер буфера.

Закрытие именованного канала производится вызовом:

```C++
int close(int fd)
```

где:</br>
`fd` – дескриптор именованного канала.</br>

Удаление именованного канала производится вызовом:

```C++
int unlink(const char *pathname)
```

где:</br>
`pathname` – имя именованного канала.

## Полезные ссылки

--- 

Из руководства пользователя Linux (man)

[функция fifo](http://man7.org/linux/man-pages/man7/fifo.7.html)</br>
[функция mkfifo](https://man7.org/linux/man-pages/man3/mkfifo.3.html)</br>
[функция write](https://man7.org/linux/man-pages/man2/write.2.html)</br>
[функция read](https://man7.org/linux/man-pages/man2/read.2.html)</br>
[функция signal](https://man7.org/linux/man-pages/man3/signal.3p.html)</br>

