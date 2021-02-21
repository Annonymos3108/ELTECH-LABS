#include <iostream>

typedef unsigned int uint;
using namespace std;

int* createArray(int*& array, uint num)
{
	array = new int[num];
	return array;
}

int* fillArrayRand(int*& array, uint num)
{
	for (uint i = 0; i < num; i++)
	{
		array[i] = rand() % 1000 + 1;
	}
	return array;
}

int* fillArrayFromUser(int*& array, uint num)
{
	cout << "Введите данные: после каждого литерала ставьте ПРОБЕЛ, полсе ввода нажмите ENTER " << endl;
	for (uint i = 0; i < num; i++)
	{
		int temp;
		cin >> temp;
		array[i] = temp;
	}
	return array;
}

void printArray(int* array, uint num)
{
	for (uint i = 0; i < num; i++)
	{
		cout << array[i] << "  ";
	}
	cout << endl;
}

void deleteArray(int* array)
{
	delete[] array;
}