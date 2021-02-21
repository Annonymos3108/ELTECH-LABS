#include <iostream>
#include <conio.h>

using namespace std;

int fact(int n)
{
	if (n == 1) return 1;
	else return n*fact(n - 1);
}

int main()
{
	double a[6][10], x, q, h, result, temp;
	int k;
	do
	{
		cout << "x = ";
		cin >> x;
		for (int i = 0; i < 10; ++i)
		{
			cout << "x" << i << " = ";
			cin >> a[0][i];
			cout << "y" << i << " = ";
			cin >> a[1][i];
		}
		h = a[0][1] - a[0][0];
		for (int j = 2; j < 6; ++j)
			for (int i = 0; i < 9; ++i)
				a[j][i] = a[j - 1][i + 1] - a[j - 1][i];
		if (x > a[0][4])
		{
			for (k = 5; k < 10; ++k)
				if (a[0][k] > x) break;
			q = (x - a[0][k]) / h;
			result = a[1][k];
			temp = 1;
			for (int i = 1; i < 5; ++i)
			{
				temp *= q + i - 1;
				result += a[i + 1][k - i] / fact(i)*temp;
			}
		}
		else
		{
			for (k = 4; k > 0; --k)
				if (a[0][k] < x) break;
			q = (x - a[0][k]) / h;
			result = a[1][k];
			temp = 1;
			for (int i = 1; i < 5; ++i)
			{
				temp *= q - i + 1;
				result += a[i+1][k-1] / fact(i)*temp;
			}
		}
		cout << "y(" << x << ") = " << result << endl;
		x = _getch();
	} while (x != 27);
}