#include "polinom.h"
#include "number.h"
#include "math.h"


Polinom::Polinom(number inputA, number inputB, number inputC)
{
	printMode = EPrintModeClassic;
	a = inputA;
	b = inputB;
	c = inputC;
};

std::ostream& operator<< (std::ostream& os, Polinom& p) {
	if (p.printMode == EPrintModeClassic)
	{
		os << "p(x)=" << p.a << "x^2" << (p.b >= 0 ? "+" : "-") << abs(p.b) <<
			"x" << (p.c >= 0 ? "+" : "-") << abs(p.c) << std::endl;
	}
	else
	{
		number roots[2];
		int count = p.Calculate(roots);
		if (count == 0) return os;
		//два корня
		if (count == 2) {
			std::cout << "p(x)=" << p.a << "*(x" << (roots[0] >= 0 ? "-" : "+") << abs(roots[0]) <<
				")(x" << (roots[1] >= 0 ? "-" : "+") << abs(roots[1]) << ")" << std::endl;
		}

		//один корень
		if (count == 1) {
			std::cout << "p(x)=" << p.a << "(x" << (roots[0] >= 0 ? "-" : "+") << abs(roots[0]) <<
				")^2" << std::endl;
		}
	}
	return os;
};

number Polinom::value(number x)
{
	return a * x * x + b * x + c;
};

void Polinom::setPrintMode(EPrintMode mode)
{
	printMode = mode;
};

int Polinom::Calculate(number* roots)
{
	//при Д>0
	number d = ((b * b) - (a * c * 4));
	if (d > 0) //Если дискриминант больше 0
	{
		roots[0] = ((-b + sqrt(d)) / (a * 2));
		roots[1] = ((-b - sqrt(d)) / (a * 2));

		if (a * roots[0] * roots[0] + b * roots[0] + c == 0 &&
			a * roots[1] * roots[1] + b * roots[1] + c == 0) {
			std::cout << "Первый корень равен " << roots[0] << std::endl;
			std::cout << "Второй корень равен " << roots[1] << std::endl;
			return 2;
		}
		else
		{
			std::cout << "Полином не разложим над полем целых" << std::endl;
			return 0;
		}
	}

	//при Д=0
	if (d == 0)
	{
		roots[0] = ((-b) / (a * 2));
		if (a * roots[0] * roots[0] + b * roots[0] + c == 0) {
			std::cout << "Корень равен " << roots[0] << std::endl;
			return 1;
		}
		else {
			std::cout << "Полином не разложим над полем целых" << std::endl;
			return 0;
		}
	}

	//при Д<0
	else
	{
		std::cout << "Полином не разложим над полем целых" << std::endl;
		return 0;
	}
};