#include <iostream>

using namespace std;

union type
{
	unsigned long long INTEGER;
	double FLOATING;
};

void DoubleOut(double data)
{
	cout << endl << endl;
	{
		type LD;
		LD.FLOATING = data;
		for (int i = 8 * sizeof(LD.INTEGER) - 1; i > -1; i--)
			printf("%d", LD.INTEGER >> i & 1);
		printf("\n");
	}
}

void ShortIntOut(short int shortData)
{
	cout << endl << endl;
	unsigned short int temp;
	for (int i = 0; i < 16; i++)
	{
		temp = ((shortData >> (16 - i - 1)) & 1);
		cout << temp;
	}
	cout << endl;
}

//Выполнить циклический сдвиг в заданную сторону на некоторое вводимое с клавиатуры количество разрядов.

void ShiftDouble(double data, unsigned long long side, unsigned long long count)
{
	type LD;
	LD.FLOATING = data;
	if (side == 1)  // 1-left, 2-right
	{
		for (int i = 0; i <= 63; i++) 
		{
			// что то ... вместо double data использовать LD.FLOATING
			// если сдвигать << этим в противоположном стороне будут появляться 0-и
			// нужно использовать маску как в функции reverseLongDouble...
		}
	}
	if (side == 2)
	{
		for (int i = 0; i <= 63; i++)
		{
			// что то ... вместо double data использовать LD.FLOATING
			// если сдвигать >> этим в противоположном стороне будут появляться 0-и
		}
	}
	else cout << "Error!" << endl;
}

void ShiftShortInt(short int shortData, unsigned short int side, unsigned short int count)
{
	if (side == 1) // 1-left, 2-right
	{
		for (int i = 0; i <= 15; i++)
		{
			// что то ... тут нужно использовать shortData напрямую
		}
	}
	if (side == 2)
	{
		for (int i = 0; i <= 15; i++)
		{
			// что то ... тут нужно использовать shortData напрямую
		}
	}
	else cout << "Error!" << endl;
}

int main()
{
	setlocale(LC_ALL, "rus");
	short int shortData;
	double data;
	int mode;
startpoint:
	cout << "Выберите тип: 1 - double; 2 - short int " << endl;
	cin >> mode;
	switch (mode)
	{
		case 1:
		{
			cout << "Введите число: " << endl;
			cin >> data;
			DoubleOut(data);
			unsigned long long side;
			cout << "Задайте сторону: 1-left, 2-right " << endl;
			cin >> side;
			unsigned long long count;
			cout << "Введите количество разрядов: " << endl;
			cin >> count;
			ShiftDouble(data, side, count);
			break;
		}
		case 2:
		{
			cout << "Введите число: " << endl;
			cin >> shortData;
			ShortIntOut(shortData);
			unsigned short int sideshort;
			cout << "Задайте сторону: 1-left, 2-right " << endl;
			cin >> sideshort;
			unsigned short int countshort;
			cout << "Введите количество разрядов: " << endl;
			cin >> countshort;
			ShiftShortInt(shortData, sideshort, countshort);
			break;
		}
		default:
		{
			cout << "\nОшибка!!!\n";
			break;
		}
	}
	char t;
	cout << "Все сначала? y / n \n";
	cin >> t;
	if (t == 'y')
	{
		system("cls");
		goto startpoint;
	}
	else return 0;
}