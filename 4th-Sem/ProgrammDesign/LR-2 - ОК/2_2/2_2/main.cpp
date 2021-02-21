#include <iostream>
#include <conio.h>

using namespace std;

int main()
{
	const double h = 0.01;
	double a[10][8],x;
	bool br;
	do
	{
		cout << "x = ";
		cin >> x;
		for (int i = 0; i < 8; ++i)
		{
			cout << "x" << i << " = ";
			cin >> a[0][i];
			cout << "y" << i << " = ";
			cin >> a[1][i];
			a[2][i] = a[0][i] - x;
		}
		for (int i = 1; i < 8; ++i) 
			a[3][i] = (a[1][i - 1] * a[2][i] - a[1][i] * a[2][i - 1]) / (a[0][i] - a[0][i - 1]);
		for (int j = 4; j < 10; ++j)
		{
			for (int i = j - 2; i < 8; ++i)
			{
				a[j][i] = (a[j-1][i - j + 2] * a[2][i] - a[j-1][i] * a[2][i - j + 2]) / (a[0][i] - a[0][i - j + 2]);
				if (((a[j][i] - a[j - 1][i]) < h) || ((a[j][i] - a[j - 1][i - 1]) < h))
				{
					cout << "y(" << x << ") = " << round(a[j][i] / h)*h << endl;
					br = true;
					break;
				}
			}
			if (br) break;
		}
		x = _getch();
	} while (x != 27);
	return 0;
}