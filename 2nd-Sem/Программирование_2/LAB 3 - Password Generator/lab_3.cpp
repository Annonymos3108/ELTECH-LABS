#include <iostream>
#include <time.h>

using namespace std;

struct Node
{
	char info;
	Node* next;
	Node* prev;
};

int main()
{
	srand(time(NULL));
	int num = 0, i = 0;
	printf ("Enter password length: ");
	cin >> num; // получение длины пароля
	Node *top, *back, *p, *f;
	top = new Node;
	p = top;
	while (i < num - 1) // ввод пароля
	{
		f = new Node;
		f->prev = p;
		p->next = f;
		p = f;
		i++;
	}
	// "привязка концов списка"
	back = p;
	back->next = top;
	top->prev = back;
	// заполнение цписка псевдослучайниыми симвоами
	top->info = rand() % 26 + 97;
	p = top->next;
	i = 1;
	
	while (p != top)
	{
		if (i % 2 == 0) p->info = rand() % 26 + 97;
		p = p->next;
		i++;
	}

	if (num % 2 == 0) back->info = rand() % 10 + 48;
	i = i - 2;
	p = back->prev;

	while (p != back)
	{
		if (i % 2 == 1) p->info = rand() % 10 + 48;
		p = p->prev;
		i--;
	}
	// вывод полученного пароля
	cout << top->info;
	p = top->next;
	while (p != top)
	{
		cout << p->info;
		p = p->next;
	}
	cin.get(); 
	cin.get();
	// удаление списка
	p = top;
	while (p != back)
	{
		f = p->next;
		delete p;
		p = f;
	}
	delete p;
	return 0;
}