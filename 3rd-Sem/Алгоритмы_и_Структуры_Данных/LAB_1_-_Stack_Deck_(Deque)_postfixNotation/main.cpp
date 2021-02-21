#include <iostream>
#include "List.h"
#include <cstring>
#include <cstdio>

#define MAX_LEN 256

typedef unsigned int uint;
using namespace std;

int* createArray(int*& array, uint num);
int* fillArray(int*& array, uint num);
void printArray(int* array, uint num);
void deleteArray(int* array);
int* addNewElement(int*& array, uint num, int newData);
int* deleteLastElement(int*& array, uint num);
void PostfixNotation(const char* _infix, char* _postfix);
void push(char* _stack, int& _ptr, char data);
char pop(char* _stack, int& _ptr);

int main()
{
    setlocale(LC_ALL, "rus");
	uint num;
	int t, actType;
	startPoint:
	cout << "Выберите действие: \n 1. Работа с динамическим массивом \n 2. Работа с двухсвязным списком \n";
	cout << " 3. Перевод из инфиксной формы в постфиксную (обратная польская нотация)\n";
	cin >> actType;
	switch (actType)
	{
		case 1:
		{
			cout << "Ввдите целое положительное число для определения длины массива..." << endl;
			std::cin >> num;
			if ((num >= 1) && (num <= 4294967295))
			{
				int* array = NULL;
				createArray(array, num);
				fillArray(array, num);
				cout << "Динамический массив успешно создан и заполнен случайными данными!" << endl;
				cout << "Для продолжения выберите дейстие\n a. Добавить новый элемент в конец. \n b. Убрать последний элемент" << endl;
				char mode;
				std::cin >> mode;
				if ((mode == 97) || (mode == 65)) // 97 is a, 65 is A
				{
					cout << "Данные в массиве: " << endl;
					printArray(array, num);
					int newData = (rand() % 100);
					array = addNewElement(array, num, newData);
					cout << "Новый сгенерированный элемент " << newData << " был добавлен в конец динамического массива" << endl;
					cout << "Данные в массиве: " << endl;
					printArray(array, num+1);
					deleteArray(array);
				}
				else if ((mode == 98) || (mode == 66)) // 98 is b, 66 is B
				{
					cout << "Данные в массиве: " << endl;
					printArray(array, num);
					uint Last_Elm = array[sizeof(array) / sizeof(array[0])]; // копируем значение последнего элемента для вывода
					array = deleteLastElement(array, num);
					cout << "Последний элемент " << array[Last_Elm] << " был удален из динамического массива" << endl;
					cout << "Данные в массиве: " << endl;
					printArray(array, num-1);
					deleteArray(array);
				}
				else
				{
					deleteArray(array);
					cout << endl << "Ошибка! " << endl;
				}
			}
			else
			{
				cout << endl << "Ошибка! " << endl;
			}
			break;
		}
		case 2:
		{
			cout << "Ввдите целое положительное число для определения длины списка..." << endl;
			cin >> num;
			if (num >= 1)
			{
				List deQue;						//Объявляем переменную, тип которой есть список
				for (uint i = 0; i < num; i++) deQue.AddLast(rand() % 100 + 1); //Добавляем в список элементы
				cout << "Данные в списке. Вывод сначала списка: " << endl;
				deQue.ShowStart();				//Отображаем список на экране
				int listmode;
				cout << "Выберите действие: \n 1. Добавить новый элемент в начало. \n 2. Убрать первый элемент.\n";
				cout <<	" 3. Добавить новый элемент в конец.\n 4. Убрать последний элемент. \n";
				cin >> listmode;
				switch (listmode)
				{
					case 1: //Добавить новый элемент в начало
					{
						cout << "Данные в списке. Вывод сначала списка: " << endl;
						deQue.ShowStart();
						deQue.AddFirst(rand() % 100);
						cout << "Новый сгенерированный элемент ";
						deQue.ShowFirst();
						cout << " был добавлен в начало списка\n";
						cout << "Данные в списке. Вывод сначала списка: " << endl;
						deQue.ShowStart();
						break;
					}
					case 2: //Убрать первый элемент
					{
						cout << "Данные в списке. Вывод сначала списка: " << endl;
						deQue.ShowStart();
						deQue.DeleteFirst(1); // ?? what is argument ??
						cout << "Первый элемент был удален\n";
						cout << "Данные в списке. Вывод сначала списка: " << endl;
						deQue.ShowStart();
						break;
					}
					case 3: //Добавить новый элемент в конец
					{
						cout << "Данные в списке. Вывод с конца списка: " << endl;
						deQue.ShowEnd();
						deQue.AddLast(rand() % 100);
						cout << "Новый сгенерированный элемент ";
						deQue.ShowLast();
						cout << " был добавлен в конец списка\n";
						cout << "Данные в списке. Вывод с конца списка: " << endl;
						deQue.ShowEnd();
						break;
					}
					case 4: //Убрать последний элемент
					{
						cout << "Данные в списке. Вывод с конца списка: " << endl;
						deQue.ShowEnd();
						deQue.DeleteLast(1); // ?? what is argument ??
						cout << "Последний элемент был удален\n";
						cout << "Данные в списке. Вывод с конца списка: " << endl;
						deQue.ShowEnd();
						break;
					}
					default:
					{
						break;
					}
				}
			}
			else
			{
				break;
			}
			break;
		}
		case 3:
		{
			cout << "Преобразование записи математ. выражения из инфиксной в постфиксную (в обратную польскую запись)\n";
			cout << "Допустимые операторы: +,-,*,/,(,),^; все операции будем считать лево-ассоциативными\n";
			cout << "Все операнды - односимвольные.\nВведите выражение для перевода из инфиксной формы в постфиксную\n";
			char str_infix[MAX_LEN];
			cin.get();
			gets_s(str_infix);  // тот же gets для Visual Studio
			char str_postfix[MAX_LEN];
			cout << "Вы ввели: " << str_infix << endl;
			PostfixNotation(str_infix, str_postfix);
			cout << "Постфиксная форма выражения: " << str_postfix << endl;
			break;
		}
		default:
		{
			break;
		}
	}
	cout << "\n Хотите продолжить? да - 1; нет - 0" << endl;
	std::cin >> t;
	if (t == 1)
	{
		std::system("cls");
		goto startPoint;
	}
	else return 0;
}