#include <iostream>
#include <cstring>
#include <cstdio>

using namespace std;

#define MAX_LEN 256
char stack[MAX_LEN];		// стек дл€ хранени€ операторов при преобразовании
int st_ptr = 0;             // указатель вершины стека

void push(char* _stack, int& _ptr, char data);
char pop(char* _stack, int& _ptr);

void PostfixNotation(const char* _infix, char* _postfix)
{
	int out_index = 0;      // индекс выходной строки
	int in_index = 0;       // индекс  входной строки
	if (_infix)				// вход€ща€ строка не должна быть пустым
	{
		do
		{
			char c = _infix[in_index];  // берем текущий символ входной строки
			switch (c)
			{
				case '+':
				case '-':
					// — учетом приоритета / > или = / выталкиваем из стека в выходную строку все операторы 
					while (st_ptr != 0)
					{
						char op = stack[st_ptr - 1];  // оператор в вершине стека
						if (op != '(')  // все операторы, кроме откр. скобки имеют больший или равный приоритет
						{
							_postfix[out_index++] = op; // добавл€ем оператор в выходную строку
							pop(stack, st_ptr);         // удал€ем оператор из стека
						}
						else break;
					}
					// помещаем оператор в стек
					push(stack, st_ptr, c);
					break;
			case '*':
			case '/':
				while (st_ptr != 0)
				{
					char op = stack[st_ptr - 1];
					if ((op == '^') || (op == '*') || (op == '/'))
					{
						_postfix[out_index++] = op; // добавл€ем оператор в выходную строку
						pop(stack, st_ptr);         // удал€ем оператор из стека
					}
					else
						break;
				}
				// помещаем оператор в стек
				push(stack, st_ptr, c);
				break;

			case '(':
				// просто помещаем в стек
				push(stack, st_ptr, c);
				break;

			case ')':
				// выталкиваем из стека в выходную строку все элементы до открывающей скобки (откр. скобку просто отбрасываем)
				while (st_ptr != 0)
				{
					char op = pop(stack, st_ptr);   // забираем из стека оператор
					if (op == '(')                  // если достигли открывающей скобки
						break;                      // выталкивание закончили
					else
					{
						_postfix[out_index++] = op; // добавили оператор в выходную строку
					}
				}
				break;

			case '^':
				// помещаем оператор в стек /выталкивать ничего не нужно, нет операторов с большим приоритетом/
				push(stack, st_ptr, c);
				break;

			default:        // символ цифры
				_postfix[out_index] = c;    // добавление во выходную строку
				out_index++;
				break;
			}
			in_index++;
		} while (_infix[in_index] != 0);
	}
	else
	{
		cout << "\nќшибка! —трока ѕуста! Ќажмите Enter, чтобы начать сначала." << endl;
	};

	while (st_ptr != 0)		// выталкиваем все операторы в выходную строку
		{
			_postfix[out_index++] = pop(stack, st_ptr);
			cout << st_ptr << endl;
		}
	_postfix[out_index] = 0;			// завершающий символ нул€
}

void push(char* _stack, int& _ptr, char data)
{
	_stack[_ptr++] = data;
}

char pop(char* _stack, int& _ptr)
{
	return _stack[--_ptr];
}