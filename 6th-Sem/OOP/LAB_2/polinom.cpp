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
		number* roots = p.Calculate();
		if (roots == nullptr) return os;
		//два корня
		if (roots[2] != false && roots[3] != false) {
			std::cout << "p(x)=" << "(x" << (roots[0] >= 0 ? "-" : "+") << abs(roots[0]) <<
				")(x" << (roots[1] >= 0 ? "-" : "+") << abs(roots[1]) << ")" << std::endl;
		}

		//один корень
		if (roots[2] != false && roots[3] == false) {
			std::cout << "p(x)=" << "(x" << (roots[0] >= 0 ? "-" : "+") << abs(roots[0]) <<
				")^2" << std::endl;
		}
	}
	return os;
};

number Polinom::value(number x)
{
	return a * pow(x, 2) + b*x + c;
};

void Polinom::setPrintMode(EPrintMode mode)
{
	printMode = mode;
};

number* Polinom::Calculate()
{
	//2 аттрибуты, 2 значения
	number *roots = new number[4]; 
	
	//при Д>0
	number d = ((b * b) - (4 * a * c));
	if (d > 0) //Если дискриминант больше 0
	{
		roots[0] = ((-1*b + sqrt(d)) / (2*a));
		roots[1] = ((-1*b - sqrt(d)) / (2*a));

		if (a*roots[0]*roots[0] + b*roots[0] + c == 0 && 
			a * roots[1] * roots[1] + b * roots[1] + c == 0) {
			roots[2] = true;
			roots[3] = true;
			std::cout << "Первый корень равен " << roots[0] << std::endl;
			std::cout << "Второй корень равен " << roots[1] << std::endl;
			return roots;
		}
		else
		{
			std::cout << "Полином не разложим над полем целых" << std::endl;
			return NULL;
		}
	}

	//при Д=0
	if (d == 0)
	{
		roots[0] = (-1 * b) / (2 * a);
		roots[2] = true;
		roots[3] = false;
		if (a * roots[0] * roots[0] + b * roots[0] + c == 0) {
			std::cout << "Корень равен " << roots[0] << std::endl;
			return roots;
		}
		else {
			std::cout << "Полином не разложим над полем целых" << std::endl;
			return NULL;
		}
	}

	//при Д<0
	else
	{
		std::cout << "Полином не разложим над полем целых" << std::endl;
		return NULL;
	}
};