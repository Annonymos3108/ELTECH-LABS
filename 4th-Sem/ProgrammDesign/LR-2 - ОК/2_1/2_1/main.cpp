#include <iostream>
#include <conio.h>

using namespace std;

int main()
{
	int x[4], y[4], x_x[4][4];
	double a[4], b[4], temp;
	do
	{
		for (int i = 0; i < 4; ++i)
		{
			cout << "x" << i << " = ";
			cin >> x[i];
			cout << "y" << i << " = ";
			cin >> y[i];
		}
		for (int i = 0; i < 4; ++i)
			for (int j = 0; j < 4; ++j)
				x_x[i][j] = x[i] - x[j];
		for (int i = 0; i < 4; ++i)
		{
			a[i] = y[i];
			for (int j = 0; j < 4; ++j)
				if (i != j) a[i] /= x_x[i][j];
		}
		b[3] = 0;
		for (int i = 0; i < 4; ++i) b[3] += a[i];
		b[2] = 0;
		for (int i = 0; i < 4; ++i)
			for (int j = 0; j < 4; ++j)
				if (i != j) b[2] -= x[j] * a[i];
		b[1] = 0;
		for (int i = 0; i < 4; ++i)
			for (int j = 0; j < 4; ++j)
				if (i != j) for (int k = 0; k < 4; ++k)
					if ((i != k) && (j != k)) b[1] += x[j] * x[k] * a[i];
		b[1] /= 2;
		b[0] = 0;
		for (int i = 0; i < 4; ++i)
		{
			temp = a[i];
			for (int j = 0; j < 4; ++j)
				if (i != j) temp *= x[j];
			b[0] -= temp;
		}
		cout << b[3] << "x^3+" << b[2] << "x^2+" << b[1] << "x+" << b[0] << endl;
		temp = _getch();
	} while (temp != 27);
	return 0;
}