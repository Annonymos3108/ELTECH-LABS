#include <iostream>
#include <conio.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "rus");
	const double E = 0.0000001;
	double A[4][4], x[4], prev, y[4], h[4], temp;
	for (int i = 0; i < 4; ++i)
	{
		cout << "Строка №" << i << endl;
		for (int j = 0; j < 4; ++j)
			cin >> A[i][j];
		x[i] = 0;
	}
	x[0] = 1;
	for (int k = 0; k < 2; ++k)
	{
		do
		{
			for (int i = 0; i < 4; ++i)
			{
				y[i] = 0;
				for (int j = 0; j < 4; ++j)
					y[i] += A[i][j] * x[j];
			}
			prev = h[k];
			h[k] = 0;
			for (int i = 0; i < 4; ++i)
				h[k] += x[i] * y[i];
			temp = 0;
			for (int i = 0; i < 4; ++i)
				temp += y[i] * y[i];
			temp = sqrt(temp);
			for (int i = 0; i < 4; ++i)
				x[i] = y[i] / temp;
		} while ((h[k] - prev) > 0.001);
		if (k == 0) for (int i = 0; i < 4; ++i)
			A[i][i] -= h[0];
		else for (int i = 0; i < 4; ++i)
			A[i][i] += h[0];
	}
	h[1] += h[0];
	cout << h[0] << endl << h[1];
	_getch();
	return 0;
}