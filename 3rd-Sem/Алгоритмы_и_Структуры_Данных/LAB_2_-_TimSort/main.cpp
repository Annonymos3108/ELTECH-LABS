#include <iostream>

using namespace std;

typedef unsigned int uint;

int* createArray(int*& array, uint num);
int* fillArrayRand(int*& array, uint num);
int* fillArrayFromUser(int*& array, uint num);
void printArray(int* array, uint num);
void deleteArray(int* array);
void sortTimsort(int* array, int N);

int main()
{
	setlocale(LC_ALL, "rus");
	int t;
	do
	{
		t = 0;
		std::system("cls");
		cout << "Введите целое положительное число для определения размера массива" << endl;
		int num;
		int* array = NULL;
		cin >> num;
		createArray(array, num);
		fillArrayRand(array, num);
		//fillArrayFromUser(array, num);
		cout << "Данные: ";
		printArray(array, num);
		cout << "Сортировка... \n" ;
		sortTimsort(array, num);
		cout << "\nСортировка закончена, отсортированные данные: \n";
		printArray(array, num);
		deleteArray(array);
		cout << "\n Хотите продолжить? да - 1; нет - 0" << endl;
		cin >> t;
	} while (t == 1);
	return 0;
}