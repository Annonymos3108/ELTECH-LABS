#include <iostream>
#include <conio.h>

using namespace std;

double exp(double x)
{
	double y = 1, prev, a = 1, fact = 1;
	int i = 1;
	const double E = 0.00001;
	do
	{
		prev = y;
		a *= x;
		fact *= i;
		++i;
		y += a / fact;
	} while ((y - prev) > E);
	return y;
}

double arctg(double x)
{
	double y = x, prev, a = x;
	int i = 2;
	const double E = 0.00001;
	do
	{
		prev = y;
		a *= x*x;
		if (i % 2) y += a / (2 * i - 1);
		else y -= a / (2 * i - 1);
		++i;
	} while (abs(y - prev) > E);
	return y;
}

double sin(double x)
{
	double y = x, prev, a = x, fact = 1;
	int i = 2;
	const double E = 0.00001;
	do
	{
		prev = y;
		a *= x*x;
		fact *= i*(i + 1);
		if (i % 2) y += a / fact;
		else y -= a / fact;
		++i;
	} while (abs(y - prev) > E);
	return y;
}

double f1(double x, double y1, double y2, double y3)
{
	return arctg(x*y1*y3);
}

double f2(double x, double y1, double y2, double y3)
{
	return sin(arctg(y1*y3));
}

double f3(double x, double y1, double y2, double y3)
{
	return exp(-y1*y3*y2);
}

int main()
{
	setlocale(LC_ALL, "rus");
	double x1 = 1, x2 = 4, h = 0.1, y1 = 0, y2 = -0.3, y3 = 1, x = x1;
	cout << "Метод Эйлера" << endl;
	cout << "x = 1;  y1 = 0; y2 = -0.3; y3 = 1" << endl;
	do
	{
		x += h;
		y1 += h*f1(x, y1, y2, y3);
		y2 += h*f2(x, y1, y2, y3);
		y3 += h*f3(x, y1, y2, y3);
		cout << "x = " << x << ";  y1 = " << y1 << "; y2 = " << y2 << "; y3 = " << y3 << endl;
	} while (x <= x2);
	cout << "Метод Рунге - Кутты" << endl;
	double k[3][4];
	y1 = 0;
	y2 = -0.3;
	y3 = 1;
	x = 1;
	cout << "x = 1;  y1 = 0; y2 = -0.3; y3 = 1" << endl;
	do
	{
		k[0][0] = f1(x, y1, y2, y3);
		k[1][0] = f2(x, y1, y2, y3);
		k[2][0] = f3(x, y1, y2, y3);
		x += h / 2;
		k[0][1] = f1(x, y1 + h*k[0][0] / 2, y2 + h*k[1][0] / 2, y3 + h*k[2][0] / 2);
		k[1][1] = f2(x, y1 + h*k[0][0] / 2, y2 + h*k[1][0] / 2, y3 + h*k[2][0] / 2);
		k[2][1] = f3(x, y1 + h*k[0][0] / 2, y2 + h*k[1][0] / 2, y3 + h*k[2][0] / 2);
		k[0][2] = f1(x, y1 + h*k[0][1] / 2, y2 + h*k[1][1] / 2, y3 + h*k[2][1] / 2);
		k[1][2] = f2(x, y1 + h*k[0][1] / 2, y2 + h*k[1][1] / 2, y3 + h*k[2][1] / 2);
		k[2][2] = f3(x, y1 + h*k[0][1] / 2, y2 + h*k[1][1] / 2, y3 + h*k[2][1] / 2);
		x += h / 2;
		k[0][3] = f1(x, y1 + h*k[0][2], y2 + h*k[1][2], y3 + h*k[2][2]);
		k[1][3] = f2(x, y1 + h*k[0][2], y2 + h*k[1][2], y3 + h*k[2][2]);
		k[2][3] = f3(x, y1 + h*k[0][2], y2 + h*k[1][2], y3 + h*k[2][2]);
		y1 += h * (k[0][0] + 2 * k[0][1] + 2 * k[0][2] + k[0][3]) / 6;
		y2 += h * (k[1][0] + 2 * k[1][1] + 2 * k[1][2] + k[1][3]) / 6;
		y3 += h * (k[2][0] + 2 * k[2][1] + 2 * k[2][2] + k[2][3]) / 6;
		cout << "x = " << x << ";  y1 = " << y1 << "; y2 = " << y2 << "; y3 = " << y3 << endl;
	} while (x < x2 - h);
	_getch();
	return 0;
}