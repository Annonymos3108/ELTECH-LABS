#include <iostream>
#include <cstring>
#include <cstdio>

using namespace std;

#define MAX_LEN 256
char stack[MAX_LEN];		// ���� ��� �������� ���������� ��� ��������������
int st_ptr = 0;             // ��������� ������� �����

void push(char* _stack, int& _ptr, char data);
char pop(char* _stack, int& _ptr);

void PostfixNotation(const char* _infix, char* _postfix)
{
	int out_index = 0;      // ������ �������� ������
	int in_index = 0;       // ������  ������� ������
	if (_infix)				// �������� ������ �� ������ ���� ������
	{
		do
		{
			char c = _infix[in_index];  // ����� ������� ������ ������� ������
			switch (c)
			{
				case '+':
				case '-':
					// � ������ ���������� / > ��� = / ����������� �� ����� � �������� ������ ��� ��������� 
					while (st_ptr != 0)
					{
						char op = stack[st_ptr - 1];  // �������� � ������� �����
						if (op != '(')  // ��� ���������, ����� ����. ������ ����� ������� ��� ������ ���������
						{
							_postfix[out_index++] = op; // ��������� �������� � �������� ������
							pop(stack, st_ptr);         // ������� �������� �� �����
						}
						else break;
					}
					// �������� �������� � ����
					push(stack, st_ptr, c);
					break;
			case '*':
			case '/':
				while (st_ptr != 0)
				{
					char op = stack[st_ptr - 1];
					if ((op == '^') || (op == '*') || (op == '/'))
					{
						_postfix[out_index++] = op; // ��������� �������� � �������� ������
						pop(stack, st_ptr);         // ������� �������� �� �����
					}
					else
						break;
				}
				// �������� �������� � ����
				push(stack, st_ptr, c);
				break;

			case '(':
				// ������ �������� � ����
				push(stack, st_ptr, c);
				break;

			case ')':
				// ����������� �� ����� � �������� ������ ��� �������� �� ����������� ������ (����. ������ ������ �����������)
				while (st_ptr != 0)
				{
					char op = pop(stack, st_ptr);   // �������� �� ����� ��������
					if (op == '(')                  // ���� �������� ����������� ������
						break;                      // ������������ ���������
					else
					{
						_postfix[out_index++] = op; // �������� �������� � �������� ������
					}
				}
				break;

			case '^':
				// �������� �������� � ���� /����������� ������ �� �����, ��� ���������� � ������� �����������/
				push(stack, st_ptr, c);
				break;

			default:        // ������ �����
				_postfix[out_index] = c;    // ���������� �� �������� ������
				out_index++;
				break;
			}
			in_index++;
		} while (_infix[in_index] != 0);
	}
	else
	{
		cout << "\n������! ������ �����! ������� Enter, ����� ������ �������." << endl;
	};

	while (st_ptr != 0)		// ����������� ��� ��������� � �������� ������
		{
			_postfix[out_index++] = pop(stack, st_ptr);
			cout << st_ptr << endl;
		}
	_postfix[out_index] = 0;			// ����������� ������ ����
}

void push(char* _stack, int& _ptr, char data)
{
	_stack[_ptr++] = data;
}

char pop(char* _stack, int& _ptr)
{
	return _stack[--_ptr];
}