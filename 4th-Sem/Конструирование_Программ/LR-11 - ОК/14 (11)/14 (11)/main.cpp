#include <iostream>
#include <conio.h>

using namespace std;

double psi1(double y)
{
	return y*y;
}

double psi2(double y)
{
	return y*y + 2 * y;
}

double psi3(double x)
{
	return 2 * (x*x - x);
}

double psi4(double x)
{
	return x*x - 1;
}


int main()
{
	double x1 = -1, x2 = 1, y1 = -2, y2 = 0, h = 0.2, u[11][11], E = 0.001, l, next;
	bool rep;
	cout.precision(3);
	for (int i = 0; i < 11; ++i)
		u[0][i] = psi1(y1 + h * i);
	for (int i = 0; i < 11; ++i)
		u[10][i] = psi2(y1 + h * i);
	for (int i = 0; i < 11; ++i)
		u[i][0] = psi3(x1 + h * i);
	for (int i = 0; i < 11; ++i)
		u[i][10] = psi4(x1 + h * i);
	for (int i = 1; i < 10; ++i)
	{
		l = (u[10][i] - u[0][i]) / 10;
		for (int j = 1; j < 10; ++j)
			u[j][i] = u[0][i] + j*l;
	}
	do
	{
		rep = false;
		for (int i = 1; i < 10; ++i)
			for (int j = 1; j < 10; ++j)
			{
				next = (u[i][j - 1] + u[i][j + 1] + u[i - 1][j] + u[i + 1][j]) / 4;
				if (abs(next - u[i][j]) > E) rep = true;
				u[i][j] = next;
			}
	} while (rep);
	for (int i = 0; i < 11; ++i)
	{
		for (int j = 0; j < 11; ++j)
			cout << u[j][i] << " ";
		cout << endl;
	}
	_getch();
	return 0;
}