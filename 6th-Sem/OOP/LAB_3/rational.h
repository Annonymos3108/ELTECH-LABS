#include <iostream>
#include <cmath>
#include <QString>
#include <QMessageBox>

#ifndef RATIONAL_H
#define RATIONAL_H

int getNod(int a, int b);

class Rational {
private:
    int a;
    unsigned int b;

public:
    Rational();
    Rational(const int&);
    Rational(int, unsigned int);

    friend Rational sqrt(Rational);
    friend Rational abs(Rational);

    friend QString& operator<<(QString&, Rational);

    Rational operator* (int);
    Rational operator* (Rational);
    Rational operator/ (Rational);
    Rational operator+ (Rational);
    Rational operator- (Rational);
    Rational operator- ();
    bool operator== (Rational);
    bool operator!= (Rational);
    bool operator>= (Rational);
    bool operator<= (Rational);
    bool operator> (Rational);
    bool operator< (Rational);

    int getA();
    unsigned int getB();

};

#endif // RATIONAL_H
