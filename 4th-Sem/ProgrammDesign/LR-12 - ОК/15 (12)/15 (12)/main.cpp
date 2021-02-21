#include <iostream>
#include <conio.h>

using namespace std;

double cos(double x)
{
	double y = 1, prev, a = 1, fact = 1;
	int i = 1;
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
double phi(double x)
{
	return 10 * x*(x*x*x - 1);
}
double ut(double x)
{
	return cos(3.1415926*x / 2);
}

int main()
{
	cout.precision(3);
	double h = 0.1, x1 = 0, x2 = 1, t1 = 0, t2 = 1, u[11][11];
	for (int i = 0; i < 11; ++i)
	{
		u[0][i] = 0;
		u[10][i] = 0;
	}
	for (int i = 1; i < 10; ++i)
		u[i][0] = phi(x1 + i*h);
	for (int i = 1; i < 10; ++i)
		u[i][1] = u[0][i] + ut(x1 + i*h);
	double prev[9], b[9], E = 0.001, temp;
	for (int k = 2; k < 11; ++k)
	{
		for (int i = 0; i < 9; ++i)
		{
			b[i] = u[i + 1][k - 2] - 2 * u[i + 1][k - 1];
			u[i + 1][k] = 0;
		}
		do
		{
			temp = 0;
			for (int i = 0; i < 9; ++i)
			{
				prev[i] = u[i + 1][k];
				u[i + 1][k] = (b[i] - u[i][k] - u[i + 2][k]) / 3;
				if (abs(prev[i] - u[i + 1][k]) > temp) temp = abs(prev[i] - u[i + 1][k]);
			}
		} while (temp > E);
	}
	for (int i = 0; i < 11; ++i)
	{
		for (int j = 0; j < 11; ++j)
			cout << u[j][i] << " ";
		cout << endl;
	}
	_getch();
	return 0;
}