#include "rational.h"

Rational::Rational() {};

Rational::Rational(const int& a_) 
{
    a = a_;
    b = 1;
}

//НОД
int getNod(int a, int b) 
{
    return b ? getNod(b, a % b) : a;
}


Rational sqrt(Rational rt)
{
    double a, b;
    a = ::sqrt(rt.a);
    b = ::sqrt(rt.b);
    // переобразовываем double a и b в int, далее снова в double
    // если переобразованый совпадает с исходным, значит число целое
    // например имеем раьиональное число 16/81
    // при извлечении квадратного корня получаем 4.0/9.0
    // if (((double)(int)4.0) == 4.0) 
    // т.е 4.0 -> 4 -> 4.0 == 4.0 значит можно записать в аттрибуты объекта (int)
    // заметим, что если бы а получилось скажем 4.254... то
    // при сравнении (((double)(int)4.254) == 4.254) получаем 4.0 == 4.254
    // и результат сравнения false
    if ((((double)(int)a) == a) && (((double)(int)b) == b))
    {
        rt.a = a;
        rt.b = b;
        return rt;
    }
    else 
    {
        std::cout << "Ошибка, квадратный корень из дискриминанта не " << 
            "рациональная дробь!" << std::endl;
        rt.a = 1;
        rt.b = 2;
        return rt;
    }
}


Rational abs(Rational rt)
{
    rt.a = ::abs(rt.a);
    return rt;
}

std::istream& operator>> (std::istream& is, Rational& rt)
{
    do {
        bool flag = false;
        is >> rt.a >> rt.b;
        if ((rt.b <= 1)) {
            std::cout << "Знаменатель не может быть 0, 1 или отрицательным, повторите попытку" << 
                std::endl;
            continue;
        }
        // если а без остатка делится на b
        if ((double(int((double(rt.a)/double(rt.b)))) == (double(rt.a)/double(rt.b))))
        {
            std::cout << "Введеные числа НЕ образуют рациональную дробь, повторите попытку" << 
                std::endl;
            continue;
        }
        return is;
    } while (true);    
}

std::ostream& operator<< (std::ostream& os, Rational rt)
{
    os << "(" << rt.a << "/" << rt.b << ")";
    return os;
}

Rational Rational::operator- ()
{
    return a *= -1;
}

//умножение рациональной дроби с целым
Rational Rational::operator* (int integer)
{
    Rational rational;
    rational.a = a*integer;
    //вызвать функцию нахождения НОД-а
    //проверить можно ли сократить дробь после умножения
    int nod = getNod(rational.a, rational.b);
    if (nod == 1) // НОД-а нет
    {
        return rational;
    }
    else // НОД есть, сокращаем
    {
        rational.a /= nod;
        rational.b /= nod;
        return rational;
    }
}

//сложение рациональных дробей
Rational Rational::operator+ (Rational rt)
{
    Rational rational;
    /*
     a     c     a*d + b*c         a это a     c это rt.a         a*d + b*c будет a*rt.b + b*rt.a
    --- + --- = -----------       ---------   ------------      ----------------------------------  
     b     d       b*d             b это b     d это rt.b               b*d будет b*rt.b

    */
    rational.a = a*rt.b + b*rt.a;
    rational.b = b*rt.b;
    //вызвать функцию нахождения НОД-а
    //проверить можно ли сократить дробь после сложения дробей
    int nod = getNod(rational.a, rational.b);
    if (nod == 1) // НОД-а нет
    {
        return rational;
    }
    else // НОД есть, сокращаем
    {
        rational.a /= nod;
        rational.b /= nod;
        return rational;
    }
}

//вычитание рациональных дробей
Rational Rational::operator- (Rational rt)
{
    Rational rational;
    /*
     a     c     a*d - b*c         a это a     c это rt.a         a*d - b*c будет a*rt.b - b*rt.a
    --- + --- = -----------       ---------   ------------      ----------------------------------  
     b     d       b*d             b это b     d это rt.b               b*d будет b*rt.b

    */
    rational.a = a*rt.b - b*rt.a;
    rational.b = b*rt.b;
    //вызвать функцию нахождения НОД-а
    //проверить можно ли сократить дробь после сложения дробей
    int nod = getNod(rational.a, rational.b);
    if (nod == 1) // НОД-а нет
    {
        return rational;
    }
    else // НОД есть, сокращаем
    {
        rational.a /= nod;
        rational.b /= nod;
        return rational;
    }
}

//умножение рациональных дробей
Rational Rational::operator* (Rational rt)
{
    Rational rational;
    rational.a = a*rt.a;
    rational.b = b*rt.b;
    //вызвать функцию нахождения НОД-а
    //проверить можно ли сократить дробь после умножения
    int nod = getNod(rational.a, rational.b);
    if (nod == 1) // НОД-а нет
    {
        return rational;
    }
    else // НОД есть, сокращаем
    {
        rational.a /= nod;
        rational.b /= nod;
        return rational;
    }
}

//деление рациональных дробей
Rational Rational::operator/ (Rational rt)
{
    Rational rational;
    rational.a = a*rt.b;
    rational.b = b*rt.a;
    //вызвать функцию нахождения НОД-а
    //проверить можно ли сократить дробь после умножения
    int nod = getNod(rational.a, rational.b);
    if (nod == 1) // НОД-а нет
    {
        return rational;
    }
    else // НОД есть, сокращаем
    {
        rational.a /= nod;
        rational.b /= nod;
        return rational;
    }
}

bool Rational::operator== (Rational rt) 
{
    return (a == rt.a) && (b == rt.b);
}

bool Rational::operator!= (Rational rt) 
{
    return (a != rt.a) || (b != rt.b);
}

bool Rational::operator>= (Rational rt) 
{
    return ((double(a)/double(b)) >= (double(rt.a)/double(rt.b)));
}

bool Rational::operator<= (Rational rt) 
{
    return ((double(a)/double(b)) >= (double(rt.a)/double(rt.b)));
}

bool Rational::operator> (Rational rt) 
{
    return ((double(a)/double(b)) > (double(rt.a)/double(rt.b)));
}

bool Rational::operator< (Rational rt) 
{
    return ((double(a)/double(b)) > (double(rt.a)/double(rt.b)));
}