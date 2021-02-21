#include <iostream>
typedef unsigned int uint;
using namespace std; 

int* createArray(int*& array, uint num)
{
	array = new int[num];
	return array;
}

int* fillArray(int*& array, uint num)
{
	for (uint i = 0; i < num; i++)
	{
		array[i] = rand() % 100 + 1;
	}
	return array;
}

void printArray(int* array, uint num)
{
	for (uint i = 0; i < num; i++)
	{
		cout << array[i] << "\t";
	}
	cout << endl;
}

void deleteArray(int* array)
{
	delete[] array;
}

int* addNewElement(int*& array, uint num, int newData)
{
	int *temp = NULL;
	uint numTemp = num + 1;
	temp = createArray(temp, numTemp); // создаем временный массив
	for (uint i = 0; i < num; i++) temp[i] = array[i]; // копируем данные со старого массива
	temp[numTemp-1] = newData; // добавляем новый элемент в конец нового массива 
	deleteArray(array);
	return temp;
}

int* deleteLastElement(int*& array, uint num)
{
	int* temp = NULL;
	int numTemp = num - 1;
	temp = createArray(temp, numTemp);
	for (int i = 0; i < numTemp; i++) temp[i] = array[i]; // копируем данные со старого массива
	deleteArray(array); // удаляем старый массив
	return temp;
}