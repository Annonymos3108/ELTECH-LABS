#include <iostream>
#include <cmath>
#include <QString>

#ifndef RATIONAL_H
#define RATIONAL_H

int getNod(int a, int b);

class Rational {
private:
    static QChar SEPARATOR;
    int a;
    unsigned int b;

public:
    Rational();
    Rational(const int&);
    Rational(int, unsigned int);
    Rational(const QByteArray&);

    friend Rational sqrt(Rational);
    friend Rational abs(Rational);

    friend QString& operator<<(QString&, Rational);
    friend QByteArray& operator>>(QByteArray&,Rational&);

    friend std::ostream& operator<<(std::ostream&,Rational);
    friend std::istream& operator>>(std::istream&,Rational&);

    operator QString ();

    static void setSeparator(QChar);

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
