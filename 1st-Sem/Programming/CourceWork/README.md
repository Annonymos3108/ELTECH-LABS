# Курсовая работа. Тема: Стеганография в изображениях

[Оригинал задания](https://markoutte.me/students/steganography/)</br>
Работа выполнена по [методу LSB](https://ru.wikipedia.org/wiki/%D0%A1%D1%82%D0%B5%D0%B3%D0%B0%D0%BD%D0%BE%D0%B3%D1%80%D0%B0%D1%84%D0%B8%D1%8F#%D0%9C%D0%B5%D1%82%D0%BE%D0%B4_LSB)

## Идея

В один пиксель изображения будем шифровать один символ текста методом  2-3-3, то есть:
1 пиксель изображения в формате BMP-24 занимает 3 байта, а 1 символ текста 8 бит (1 байт), так как пиксель изображения состоит из трех каналов RGB (Red Green Blue) на каждый канал цвета соответственно нужно кодировать треть от байта текста таким образом:

Пиксель до кодировки | символ текста | Пиксель после кодировки
--- | --- | ---
R: 111100**10** | | R: 111100**10**
G: 11000**101** | 10111001 | G: 11000**111**
B: 11001**010** | | B: 11001**001**

</br>

## Алгоритм кодирования информации:

1. Загрузить изображение в память программы
2. Определить количество доступных пикселей изображения
3. Определить максимальную длину текста
4. Загружаем текст в память программы из консоли или файла
5. Если текст превышает максимально допустимую длину, сообщить об этом пользователю и завершить программу
6. Организуем цикл по байтам текста и пикселям изображения, кодируем байт текста по схеме 2-3-3 битов на каждый из каналов пикселя
7. Сохранить изображение на диск в исходном формате

Алгоритм декодирования разрабатывается похожим образом. Для чтения изображения в формате bmp используется бинарное чтение файлов, заголовок которого описан следующей структурой для 32-битной архитектуры:

```C++
#pragma pack(push, 1)
typedef struct
{
    unsigned char   b1,b2;
    unsigned long   bfSize;
    unsigned short  bfReserved1;
    unsigned short  bfReserved2;
    unsigned long   bfOffBits;
} BITMAPFILEHEADER;

typedef struct
{
    unsigned int    biSize;
    int             biWidth;
    int             biHeight;
    unsigned short  biPlanes;
    unsigned short  biBitCount;
    unsigned int    biCompression;
    unsigned int    biSizeImage;
    int             biXPelsPerMeter;
    int             biYPelsPerMeter;
    unsigned int    biClrUsed;
    unsigned int    biClrImportant;
} BITMAPINFOHEADER;
#pragma pack(pop)
```

## Требования к программе

Базово программа должна обеспечивать возможность кодирования текста из таблицы **ASCII** в изображении формата **BMP** без компрессии на стандартной палитре. В качестве усложнения программы могут быть реализованы:

- Кодирование любого текста из заранее известных кодировок (UTF-16, CP-1251, UTF-8)
- Использование других форматов изображения без потерь
- Шифрование текста перед кодированием в изображение для большей защищённости передачи информации
- Использование других схем записи байта текста в пиксель изображения, например, 1 бит текста в 1 пиксель, таким образом, кодировка является менее заметной, но существенно сокращается размер доступного для кодирования текста

До самой стеганографии, в программе исходный текст кодируется [Шифром Цезаря](https://ru.wikipedia.org/wiki/%D0%A8%D0%B8%D1%84%D1%80_%D0%A6%D0%B5%D0%B7%D0%B0%D1%80%D1%8F)

## Инструкция 

Программу принимает несколько аргументов:
- `[textfile]` - входные данные
- `<Option>` - опция шифрование/расшифровывание (encode/decode)
- `[bmpfile]` - файл bmp
- `<key> ` - ключ шифрования/расшифровывания для Шифра Цезаря

```bash
$ program [textfile] <Option> [bmpfile] <key> 
```

Пример команды для шифрования:

```bash
$ a.exe s.txt encode p.bmp 5
```

Пример команды для расшифровывания:

```bash
$ a.exe s.txt encode p.bmp 5
```