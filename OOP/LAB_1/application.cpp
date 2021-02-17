#include "application.h"

int Application::Menu()
{
    int ch;
    std::cout << std::endl << std::endl <<
        "1. Ввод коэффициентов a, b, c (по умолчанию все коеффиценты = 1)" << std::endl <<
        "2. Расчет корней полинома и вывод результатов расчета" << std::endl <<
        "3. Ввод значения аргумента х (по умолчанию равен 0), расчет значения и его вывод" << std::endl <<
        "4. Вывод текстового представления полинома в указанной форме p(x)" << std::endl <<
        "5. Вывод текстового представления полинома в канонической форме" << std::endl <<
        "0. Выход из приложения" << std::endl << "Введите команду:" << std::endl << "> ";
    std::cin >> ch;
    return ch;
};

int Application::exec()
{
    setlocale(LC_ALL, "Russian");
    std::cout << "Практическая работа N1" << std::endl <<
        "Приложение для вычисления корней полинома 2-ой степени " <<
        "вида p(x) = a*x^2 + b*x + c (a!=0)" << std::endl <<
        "и его значения для заданного аргумента х " <<
        "на множестве целых чисел.";

    int ch;
    number a = 1, b = 2, c = 1, x1, x2;
    while (true)
    {
        ch = Menu();
        switch (ch)
        {
        case 0:
            return 0;
        case 1:
            std::cout << "Введите коеффиценты, например: 5 7 9 " <<
                "разделите коеффиценты пробелами." << std::endl;
            std::cin >> a >> b >> c;
            break;
        case 2: {
            Polinom p(a, b, c);
            p.Calculate();
            break;
        }
        case 3: {
            number x = 0;
            std::cout << "x = ";
            std::cin >> x;
            Polinom p(a, b, c);
            number v = p.value(x);
            std::cout << "Значение полинома p(" << x << ") = " << v << std::endl;
            break;
        }
        case 4: {
            Polinom p(a, b, c);
            p.setPrintMode(EPrintModeClassic);
            std::cout << p << std::endl;
            break;
        }
        case 5: {
            Polinom p(a, b, c);
            p.setPrintMode(EprintModeCanonical);
            std::cout << p << std::endl;
            break;
        }
        default:
            std::cout << "Ошибка, неверный ввод" << std::endl;
            break;
        }
    }
    return 0;
};