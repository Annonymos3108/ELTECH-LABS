#include <iostream>
#include <cmath>

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

    friend std::istream& operator>> (std::istream&, Rational&);
    friend std::ostream& operator<< (std::ostream&, Rational);
    friend int getNod(int, int);
    friend Rational sqrt(Rational);
    friend Rational abs(Rational);

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

#endif