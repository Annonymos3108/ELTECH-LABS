#include <iostream>
#include "number.h"
#include <QString>

#ifndef POLINOM_H
#define POLINOM_H

enum EPrintMode {
	EPrintModeClassic,
	EprintModeCanonical,
};

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

    QString Calculate(Polinom&);
    friend QString& operator<< (QString&, Polinom&);
};

#endif // POLINOM_H
