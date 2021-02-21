#include <iostream>
#include "number.h"

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
	friend std::ostream& operator<< (std::ostream&, Polinom&);
	number value(number);
	void setPrintMode(EPrintMode);
	number* Calculate();
};

#endif