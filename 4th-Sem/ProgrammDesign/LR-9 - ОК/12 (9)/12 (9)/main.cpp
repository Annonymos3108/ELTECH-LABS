//Задание № 1. Решить заданное дифференциальное уравнение первого порядка методом Эйлера и Рунге – Кутты 
//четвертого порядка на отрезке  0,1 с шагом 0.1  и оценить погрешность интегрирования по правилу Рунге.
#include <iostream>
#include <conio.h>

using namespace std;

double cos(double x)
{
	double y = 1, prev, a = 1, fact = 1;
	int i=1;
	const double E = 0.0001;
	do
	{
		prev = y;
		a *= x*x;
		for (int j = 2 * (i - 1) + 1; j <= 2 * i; ++j)
			fact *= j;
		if (i % 2) y -= a / fact;
		else y += a / fact;
		++i;
	} while (abs(y - prev) > E);
	return y;
}

double func(double x, double y)
{
	return cos(y) / (1.25 + x) - 0.5*y*y;
}

int main()
{
	setlocale(LC_ALL, "rus");
	double x1 = 0, x2 = 1, h = 0.1, x = x1 + h, y = 0, prev;
	cout << "Метод Эйлера" << endl;
	cout << "x = 0;  y = 0" << endl;
	do
	{
		y += h*func(x, y);
		cout << "x = " << x << ";  y = " << y << endl;
		x += h;
	} while (x <= x2);

	cout << "Метод Рунге - Кутты" << endl;
	double A[4][3];
	A[0][0] = x1;
	A[0][1] = 0;
	cout << "x = 0;  y = 0" << endl;
	do
	{
		A[2][0] = A[1][0] = A[0][0] + h / 2;
		A[3][0] = A[0][0] + h;
		A[0][2] = func(A[0][0], A[0][1]);
		A[1][1] = A[0][1] + h / 2 * A[0][2];
		A[1][2] = func(A[1][0], A[1][1]);
		A[2][1] = A[0][1] + h / 2 * A[1][2];
		A[2][2] = func(A[2][0], A[2][1]);
		A[3][1] = A[0][1] + h * A[2][2];
		A[3][2] = func(A[3][0], A[3][1]);
		A[0][1] += h*(A[0][2] + 2 * A[1][2] + 2 * A[2][2] + A[3][2])/6;
		A[0][0] += h;
		cout << "x = " << A[0][0] << ";  y = " << A[0][1] << endl;
	} while (A[0][0] <= x2-h);

	_getch();
	return 0;
}