#include <iostream>
#include <conio.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "rus");
	const double E = 0.0000001;
	double A[4][4], b[4], x[4], prev[4], B[4][4], c[4];
	for (int i = 0; i < 4; ++i)
	{
		cout << "Строка №" << i << endl;
		for (int j = 0; j < 4; ++j)
			cin >> A[i][j];
		cout << "b" << i << " = ";
		cin >> b[i];
		x[i] = 0;
	}
	for (int i = 0; i < 4; ++i)
	{
		for (int j = 0; j < 4; ++j)
			B[i][j] = -A[i][j] / A[i][i];
		c[i] = b[i] / A[i][i];
	}
	do
	{
		for (int i = 0; i < 4; ++i)
		{
			prev[i] = x[i];
			x[i] = 0;
			for (int j = 0; j < 4; ++j)
				if (i != j) x[i] += B[i][j] * x[j];
			x[i] += c[i];
		}
	} while (((x[0]-prev[0]) > E) || ((x[1] - prev[1]) > E) || ((x[2] - prev[2]) > E) || ((x[3] - prev[3]) > E));
	for (int i = 0; i < 4; ++i)
		cout << "x" << i << " = " << x[i] << endl;
	_getch();
	return 0;
}