# Задание № 3: Шифруемся

[Оригинал задания](https://markoutte.me/students/cpp-ass3/)

## Задание на лабораторную работу

Требует создать программу для шифрования текста шифром Цезаря. Текст может быть любым символом из стандартной таблицы **ASCII**. Запуск программы осуществляется следующим образом:

```bash
$ crypt [options] <key> <source> [<dest>]
	
	options:
		-a, --alphabet=<alphabet>  alphabet — алфавит для работы алгоритма (по умолчанию 
		                           содержит буквы из латниского алфавита и цифры: AaBbCc..Zz0..9)
		-t, --type=<type>          type может быть 'encode' или 'decode', по умолчанию — encode		
		-h, --help                 выводит эту справку
		
	key:
		ключ для шифрования/дешифрования
	
	source:
		исходный файл для шифрования/дешифрования
		
	dest:
		файл, куда будет записан новый, зашифрованный текст. Если не указан, то переписывает source
```

Таким образом, команда

```bash
$ crypt -a "ABC0" -t encode 1 file_to_encode.txt
```

 зашифрует и перезапишет методом Цезаря файл *file_to_encode.txt*, сдвинув символы *ABC0* на *1*, где *1* — это ключ. Параметры могут следовать в любой очерёдности. Также должны работать следующие вызовы:

 ```bash
$ crypt 5 my.txt
$ crypt -t decode 3 my.txt another.txt
$ crypt --type=encode 3 another.txt my.txt
$ crypt -a "AaBbCcDd0135" 8 "C:/Program Files/yes.txt" "C:/Program Files/no.txt"
$ crypt --help
```

Следующие вызовы должны сообщать о неправильных введённых данных (напр., отрицательный ключ или несуществующий файл):

```bash
$ crypt my.txt
$ crypt -9
$ crypt all.txt 1
```

Следующий вызов приводит к ошибке «Неверно заданы параметры»:

```bash
$ crypt -a -t decode 7 my.txt
$ crypt -r encode 9 all.txt
```