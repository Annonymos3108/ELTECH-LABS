#include "RBTree.h"

using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");
	RBtree Tree;
	int switchOne, numForRand, y = 0, max, switchTwo;
	cout << "Красно-черное дерево:\nКаким образом вы хотите добавить данные в дерево?\n";
	cout << "1. Псевдослучайными данными\n2. Ввод с клавиатуры\n";
	cin >> switchOne;
	switch (switchOne)
	{
	case 1:
		cout << "Вы выбрали 1. заполнение дерева псевдослучайными данными\n";
		cout << "Введите количесто узлов, данные будут генерироваться автоматически\n";
		cin >> numForRand;
		Tree.createNodeRand(Tree, numForRand);
		cout << "\nДерево было созданно и заполнено, доступные операции";
		cout << "\n\t 1. Добавление нового узла в дерево";
		cout << "\n\t 2. Удаление узла из дерево";
		cout << "\n\t 3. Поиск узла в дереве";
		cout << "\n\t 4. Вывод дерева на экран";
		cout << "\n\t 5. Вывод корня дерева на экран";
		cout << "\n\t 6. Выход";
		cout << "\nВаш выбор: ";
		do
		{
			cin >> switchTwo;
			switch (switchTwo)
			{
			case 1:
				cout << "\nВведите ключ для внесения в дерево.\n";
				Tree.createNodeFromUser(Tree);
				cout << "\nДанные были внесены в дерево.\n";
				break;
			case 2:
				cout << "\nВведите ключ, который подлежит удалению.\n";
				dataType key;
				cin >> key;
				Tree.del(key);
				break;
			case 3:
				cout << "\nВведите ключ, по которому будем делать поиск.\n";
				dataType key2;
				cin >> key2;
				Tree.search(key2);
				break;
			case 4:
				cout << "\n Вывод дерева на экран\n";
				Tree.disp();
				break;
			case 5:
				Tree.displayroot();
				break;
			case 6:
				y = 1;
				break;
			default:
				cout << "\nОшибка! Введите правильный вариант.";
				break;
			}
			cout << "\nВведите следующую операцию:  ";
		} while (y != 1);
		break;
	case 2:
		cout << "Вы выбрали 2. заполнение дерева вручную\n";
		cout << "Введите целое положительное число для определения количества узлов\n";
		cin >> max;
		cout << "Введите данные, разделяя их пробелами\n";
		for (int i = 0; i < max; i++)
			Tree.createNodeFromUser(Tree);
		cout << "\nДерево было созданно и заполнено, доступные операции";
		cout << "\n\t 1. Добавление нового узла в дерево";
		cout << "\n\t 2. Удаление узла из дерево";
		cout << "\n\t 3. Поиск узла в дереве";
		cout << "\n\t 4. Вывод дерева на экран";
		cout << "\n\t 5. Вывод корня дерева на экран";
		cout << "\n\t 6. Выход";
		cout << "\nВаш выбор: ";
		do
		{
			cin >> switchTwo;
			switch (switchTwo)
			{
			case 1:
				cout << "\nВведите ключ для внесения в дерево.\n";
				Tree.createNodeFromUser(Tree);
				cout << "\nДанные были внесены в дерево.\n";
				break;
			case 2:
				cout << "\nВведите ключ, который подлежит удалению.\n";
				dataType key;
				cin >> key;
				Tree.del(key);
				break;
			case 3:
				cout << "\nВведите ключ, по которому будем делать поиск.\n";
				dataType key2;
				cin >> key2;
				Tree.search(key2);
				break;
			case 4:
				cout << "\n Вывод дерева на экран\n";
				Tree.disp();
				break;
			case 5:
				Tree.displayroot();
				break;
			case 6:
				y = 1;
				break;
			default:
				cout << "\nОшибка! Введите правильный вариант.";
				break;
			}
			cout << "\nВведите следующую операцию:  ";
		} while (y != 1);
		break;
	default:
		cout << "Ошибка! Вы ввели некорректные данные!";
		break;
	}
	return 0;
}