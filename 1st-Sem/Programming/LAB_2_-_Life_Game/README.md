# Задание № 2: Играем в жизнь

[Оригинал задания](https://markoutte.me/students/cpp-ass2/)

## Описание проблемы

В ходе разработки я написал программу, которая играет сама с собой в жизнь Конвея ([Жизнь (игра)](http://ru.wikipedia.org/wiki/Жизнь_(игра))). К моему глубочайшему сожалению, часть файлов затёрлась, а именно ключевая часть программы, где реализованы 3 важные функции. Я не помню, что это за функции, и как они работали.

**Ваша задача:** восстановить утерянные куски кода.

## Пример работы программы

Программа меняет своё состояние по правилам, описанным по ссылке. Дальше я привожу пример того, как выглядело поле после смены трёх эпох:

```bash
Эпоха 1         Эпоха 2         Эпоха 3

|          |    |       *  |    |       * *|
|          |    |          |    |          |
|       *  | => |          | => |          |
|         *|    |     *   *|    |         *|
|     * * *|    |       * *|    |     *   *|
--------------------------------------------
|          |    |       *  |    |       * *| <- Дополнительная строка для наглядности, вообще, она сверху ;-)
```

## Исходный код

Обратите внимание, что в некоторых случаях код может отличаться в зависимости от вашей платформы и используемого компилятора. Так, например, вместо time.h необходимо использовать unistd.h, если вы работаете под OS X Maverics с компилятором clang.

[main.cpp](./main.cpp)</br>
[console.h](./console.h)</br>
[game.h](./game.h)</br>
[makefile](./makefile)