#include <iostream>
#include <QString>
#include "math.h"

#ifndef POLINOM_H
#define POLINOM_H

enum EPrintMode {
    EPrintModeClassic,
    EprintModeCanonical,
};


template <typename number>
class Polinom
{
private:
    number a, b, c;
    EPrintMode printMode;
public:
    Polinom(number, number, number);
    number value(number);
    void setPrintMode(EPrintMode);
    int Calculate(number*);

    QString CalculateRoots();

    template <typename T>
    friend QString& operator<< (QString&, Polinom<T>&);
};


template <typename number>
Polinom<number>::Polinom(number inputA, number inputB, number inputC)
{
    printMode = EPrintModeClassic;
    a = inputA;
    b = inputB;
    c = inputC;
};


template <typename number>
QString& operator<< (QString& qstr, Polinom<number>& p)
{
    if (p.printMode == EPrintModeClassic)
    {
        qstr += "p(x)=";
        qstr << p.a;
        qstr += "x^2";
        qstr += (p.b >= 0 ? "+" : "-");
        qstr << abs(p.b);
        qstr += "x";
        qstr += (p.c >= 0 ? "+" : "-");
        qstr << abs(p.c);
    }
    else
    {
        number roots[2];
        int count = p.Calculate(roots);
        if (count == 0) return qstr;
        //два корня
        if (count == 2) {
            qstr += "p(x)=";
            qstr << p.a;
            qstr += "*(x";
            qstr += (roots[0] >= 0 ? "-" : "+");
            qstr << abs(roots[0]);
            qstr += ")(x";
            qstr += (roots[1] >= 0 ? "-" : "+");
            qstr << abs(roots[1]);
            qstr += ")";
        }

        //один корень
        if (count == 1) {
            qstr += "p(x)=";
            qstr << p.a;
            qstr += "(x";
            qstr += (roots[0] >= 0 ? "-" : "+");
            qstr << abs(roots[0]);
            qstr += ")^2";
        }
    }
    return qstr;

}


template <typename number>
number Polinom<number>::value(number x)
{
    return a * x * x + b * x + c;
};


template <typename number>
void Polinom<number>::setPrintMode(EPrintMode mode)
{
    printMode = mode;
};


template <typename number>
int Polinom<number>::Calculate(number* roots)
{
    //при Д>0
    number d = ((b * b) - (a * c * 4));
    if (d > 0) //Если дискриминант больше 0
    {
        roots[0] = ((-b + sqrt(d)) / (a * 2));
        roots[1] = ((-b - sqrt(d)) / (a * 2));

        if (a * roots[0] * roots[0] + b * roots[0] + c == 0 &&
            a * roots[1] * roots[1] + b * roots[1] + c == 0) {
            return 2;
        }
        else
        {
            return 0;
        }
    }

    //при Д=0
    if (d == 0)
    {
        roots[0] = ((-b) / (a * 2));
        if (a * roots[0] * roots[0] + b * roots[0] + c == 0) {
            return 1;
        }
        else {

            return 0;
        }
    }

    //при Д<0
    else	{

        return 0;
    }
};


template <typename number>
QString Polinom<number>::CalculateRoots()
{
    QString qstr("");
    number roots[2];
    int count = Calculate(roots);

    if (count == 0) {
        qstr += "Полином не разложим над полем";
    }
    else if (count == 1) {
        qstr += "Корень равен ";
        qstr << roots[0];
    }
    else if (count == 2) {
        qstr += "Первый корень равен ";
        qstr << roots[0];
        qstr += "\nВторой корень равен ";
        qstr << roots[1];
    }
    return qstr;
}


#endif // POLINOM_H
