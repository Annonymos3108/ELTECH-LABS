#include "AVL_Tree.h"

int main()
{
	setlocale(LC_ALL, "ru");
	nodeptr root, min, max;
	int a, choice, findele, delele, maxvalue, randvalue;
	AVLTree bst;
	system("cls");
	root = NULL;
	cout << "\n\t\t\t\tАВЛ Дерево\n" << endl;
	cout << "\t\t0 Сгенерировать случанное дерво по количеству ключов:" << endl;
	cout << "\t\t1 Вставить новый узел:" << endl;
	cout << "\t\t2 Найти минимальный элемент:" << endl;
	cout << "\t\t3 Найти максимальный элемент:" << endl;
	cout << "\t\t4 Поиск по значению:" << endl;
	cout << "\t\t5 Удалить элемент:" << endl;
	cout << "\t\t6 Префиксный обход:" << endl;
	cout << "\t\t7 Инфиксный обход:" << endl;
	cout << "\t\t8 Постфиксный обход:" << endl;
	cout << "\t\t9 Показать высоту дерева:" << endl;
	cout << "\t\t10 Выход:" << endl;
	do
	{
		cout << "\nВыберите нужное действие и нажмите Enter: ";
		cin >> choice;
		switch (choice)
		{
		case 0:
			cout << "Введите количество элементов: ";
			cin >> maxvalue;
			for (int i = 0; i < maxvalue; i++)
			{
				randvalue = rand() % 900 + 1;
				bst.insertRand(randvalue, root);
			}
			cout << "Дерево сгенерированна и заполнена песевдослучайными данными, количеттво ключов: " << maxvalue << endl;
			break;
		case 1:
			cout << "\nДобавление нового узла" << endl;
			cout << "Введите элемент: ";
			cin >> a;
			bst.insert(a, root);
			cout << "\nНовый элемент добавлен успешно\n" << endl;
			break;
		case 2:
			if (root != NULL)
			{
				min = bst.findmin(root);
				cout << "\nМинимальный элемент в дереве: " << min->key << endl;
			}
			break;
		case 3:
			if (root != NULL)
			{
				max = bst.findmax(root);
				cout << "\nМаксимальный элемент в дереве: " << max->key << endl;
			}
			break;
		case 4:
			cout << "\nВведите искомый элемент: ";
			cin >> findele;
			if (root != NULL)
				bst.find(findele, root);
			break;
		case 5:
			cout << "\nКакой узел удалять? : ";
			cin >> delele;
			bst.del(delele, root);
			bst.inorder(root);
			cout << endl;
			break;
		case 6:
			cout << "\nПрефиксный обход" << endl;
			bst.preorder(root);
			cout << endl;
			break;
		case 7:
			cout << "\nИнфиксный обход" << endl;
			bst.inorder(root);
			cout << endl;
			break;
		case 8:
			cout << "\nПостфиксный обход" << endl;
			bst.postorder(root);
			cout << endl;
			break;
		case 9:
			cout << "\nВЫСОТА\n" << endl;
			cout << "\tДерево имеет высоту: " << bst.bsheight(root) << endl;
			break;
		case 10:
			cout << "\n\tПрограмма завершила работу!\n" << endl;
			break;
		default:
			cout << "Такого пункта нет, попробуйте еще раз!\n" << endl;
			break;
		}
	} while (choice != 10);
	system("pause");
	return 0;
}