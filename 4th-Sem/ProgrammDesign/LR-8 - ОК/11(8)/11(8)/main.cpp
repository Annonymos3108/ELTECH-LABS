#include <iostream>
#include <conio.h>

using namespace std;

double tg(double x)
{
	return x + x*x*x / 3 + 2 * x*x*x*x*x / 15 + 17 * x*x*x*x*x*x*x / 315;
}

double func1(double x, double y)
{
	return tg(x*y + 0.2) - x*x;
}

double func2(double x, double y)
{
	return x*x + y*y - 1;
}

int main() 
{
	const double E = 0.001, h = 0.001;
	double x[2], y[2], prev[2], F[2][2], det, temp;
	cout << "tg(xy + 0.2) = x^2" << endl << "x^2 + y^2 = 1" << endl;
	x[0] = 0.1;
	x[1] = 0.1;
	do
	{
		prev[0] = x[0];
		prev[1] = x[1];
		F[0][0] = (func1(prev[0] + h, prev[1]) - func1(prev[0] - h, prev[1])) / (2 * h);
		F[0][1] = (func1(prev[0], prev[1] + h) - func1(prev[0], prev[1] - h)) / (2 * h);
		F[1][0] = (func2(prev[0] + h, prev[1]) - func2(prev[0] - h, prev[1])) / (2 * h);
		F[1][1] = (func2(prev[0], prev[1] + h) - func2(prev[0], prev[1] - h)) / (2 * h);
		det = F[0][0] * F[1][1] - F[0][1] * F[1][0];
		temp = F[0][0];
		F[0][0] = F[1][1] / det;
		F[1][1] = temp / det;
		F[0][1] /= -det;
		F[1][0] /= -det;
		y[0] = func1(prev[0], prev[1]);
		y[1] = func2(prev[0], prev[1]);
		x[0] = prev[0] - F[0][0] * y[0] - F[0][1] * y[1];
		x[1] = prev[1] - F[1][0] * y[0] - F[1][1] * y[1];
	} while (((x[0] - prev[0]) > E) || ((x[1] - prev[1]) > E));
	cout << "x = " << x[0] << endl << "y = " << x[1] << endl;
	_getch();
	return 0;
}