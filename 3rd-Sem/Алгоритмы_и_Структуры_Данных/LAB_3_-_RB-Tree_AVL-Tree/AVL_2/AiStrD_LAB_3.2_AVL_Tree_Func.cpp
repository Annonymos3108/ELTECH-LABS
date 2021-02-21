#include <assert.h>	// понадобиться при выводе дерева
#include <stdio.h>	// ^ тоже
#include <iostream>	// cin, cout
#include <conio.h>  // system("pause")
#include <time.h>	// srand(time(NULL))

using namespace std;

struct Node {
	int data;
	Node* left;
	Node* right;
	int height;
};

struct nodePrintState {
	nodePrintState* childState;
	bool printingLastChild;
};

nodePrintState* rootState = NULL;

void printSubtree(const Node* node);
void printTree(const Node* root);
Node* successorRRightRotate(Node*& somePointer);
Node* successorLLeftRotate(Node*& somePointer);
Node* successorRightRotate(Node*& somePointer);
Node* successorLeftRotate(Node*& somePointer);
int AVLTreeHeightReturner(Node* p);
int maxOfTwoValues(int value1, int value2);
int deleteMinimumNode(Node*& p);
void deleteNodeFromData(int x, Node*& p);
void find(int x, Node*& p);
Node* findmaxOfTwoValues(Node* p);
void insert(int x, Node*& p);


// Добавление
void insert(int x, Node*& p) {
	if (p == NULL) {	// создаем ноду
		p = new Node;
		p->data = x;
		p->left = NULL;
		p->right = NULL;
		p->height = 0;
		if (p == NULL)
			cout << "Error! Out of memory!\n" << endl;
	}
	else {
		if (x < p->data) {
			insert(x, p->left);
			if ((AVLTreeHeightReturner(p->left) - AVLTreeHeightReturner(p->right)) == 2) {
				if (x < p->left->data)
					p = successorLeftRotate(p);
				else
					p = successorLLeftRotate(p);
			}
		}
		else if (x > p->data) {
			insert(x, p->right);
			if ((AVLTreeHeightReturner(p->right) - AVLTreeHeightReturner(p->left)) == 2) {
				if (x > p->right->data)
					p = successorRightRotate(p);
				else
					p = successorRRightRotate(p);
			}
		}
	}
	int m, n, d;
	m = AVLTreeHeightReturner(p->left);
	n = AVLTreeHeightReturner(p->right);
	d = maxOfTwoValues(m, n);
	p->height = d + 1;
}

Node* findmaxOfTwoValues(Node* p) {
	if (p == NULL)	{
		cout << "В дереве нет элементов\n" << endl;
		return p;
	}
	else {
		while (p->right != NULL)  // самый большой элемент есть самый правый элемент
			p = p->right;
		return p;
	}
}


void find(int x, Node*& p) {
	if (p == NULL)	//проверка
		cout << "Такого элемента нет\n" << endl;
	else {  // меньше влево, больше вправо...
		if (x < p->data)
			find(x, p->left);
		else if (x > p->data)
			find(x, p->right);
		else
			cout << "Такой элемент есть в дереве!\n" << endl;
	}
}

void deleteNodeFromData(int x, Node*& p) {
	Node* d;
	if (p == NULL)
		cout << "Такого элемента нет\n" << endl;
	else if (x < p->data)
		deleteNodeFromData(x, p->left);
	else if (x > p->data)
		deleteNodeFromData(x, p->right);
	else if ((p->left == NULL) && (p->right == NULL)) {
		d = p;
		free(d);
		p = NULL;
		cout << "Элемент удален\n" << endl;
	}
	else if (p->left == NULL) {
		d = p;
		free(d);
		p = p->right;
		cout << "Элемент удален\n" << endl;
	}
	else if (p->right == NULL)	{
		d = p;
		p = p->left;
		free(d);
		cout << "Элемент удален\n" << endl;
	}
	else
		p->data = deleteMinimumNode(p->right);
}

int deleteMinimumNode(Node*& p) {
	int c;
	cout << "Выбрано удаление минимального значения\n" << endl;
	if (p->left == NULL) {
		c = p->data;
		p = p->right;
		return c;
	}
	else {
		c = deleteMinimumNode(p->left);
		return c;
	}
}

void printTree(const Node* root) {
	assert(rootState == NULL);

	/*
	try (пытаться) - начало блока исключений;
	catch (поймать) - начало блока, "ловящего" исключение;
	throw (бросить) - ключевое слово, "создающее" ("возбуждающее") исключение.
	конструкция try - catch используеться для того, чтобы избежать ошибок в программе
	как она работает?
	сначало выполняеться try, если все хорошо прошло и ошибок не было, тогда catch не выполняеться
	если е ходе работы try, в кокой то строке в теле try произошла ошибка, то сразу послве этой
	строки выпоняется catch
	в данном случае если дерево не существует, т.е. корнь NULL, естественно нечего выводить
	и мы в данном случае получим ошибку, которую обрабатываем в теле catch
	*/

	try {
		if (root == NULL) {
			cout << "Сработало исключение. Дерево пуста!" << endl;
			throw;
		}
		else if (root != NULL)
			printSubtree(root);
	}
	catch (...) {
		// Троеточие в этом случае показывает, что будут пойманы все исключения
		// если что-то пошло не так, принудительно reset-им состояние
		rootState = NULL;
		throw;  //операторы, следующие за throw, никогда не выполнятся
		// ни один оператор, следующий далее (до закрывающей скобки) 
		// выполнен не будет
	}
}

// просто рисуем дерево в консоли
// R-правый потомок, L-левый потомок
void printSubtree(const Node* node) {
	nodePrintState* parent_state;
	if (rootState != NULL) {
		printf(" ");
		nodePrintState* s = rootState;
		while (s->childState != NULL) {
			printf(s->printingLastChild ? "  " : "| ");
			s = s->childState;
		}
		parent_state = s;
		printf(parent_state->printingLastChild ? "R" : "L");
	}
	else
		parent_state = NULL;
	printf(">%i\n", node->data);

	if ((node->left != NULL) || (node->right != NULL)) { // если есть дети
		nodePrintState s;
		if (parent_state != NULL)
			parent_state->childState = &s;
		else
			rootState = &s;
		s.childState = NULL;

		// печатаем детей
		if (node->left != NULL) {
			s.printingLastChild = (node->right == NULL);
			printSubtree(node->left);
		}
		if (node->right != NULL) {
			s.printingLastChild = true;
			printSubtree(node->right);
		}
		if (parent_state != NULL)
			parent_state->childState = NULL;
		else
			rootState = NULL;
	}
}

// простая функиия максимума
int maxOfTwoValues(int value1, int value2) {
	return ((value1 > value2) ? value1 : value2);
}

int AVLTreeHeightReturner(Node* p) {
	int t;
	if (p == NULL)
		return -1;
	else {
		t = p->height;
		return t;
	}
}

// баланиировщик
// правый поворот
Node* successorLeftRotate(Node*& somePointer) {
	Node* p2;
	p2 = somePointer->left;
	somePointer->left = p2->right;
	p2->right = somePointer;
	somePointer->height = maxOfTwoValues(AVLTreeHeightReturner(somePointer->left), AVLTreeHeightReturner(somePointer->right)) + 1;
	p2->height = maxOfTwoValues(AVLTreeHeightReturner(p2->left), somePointer->height) + 1;
	return p2;
}

// левый поворот
Node* successorRightRotate(Node*& somePointer) {
	Node* p2;
	p2 = somePointer->right;
	somePointer->right = p2->left;
	p2->left = somePointer;
	somePointer->height = maxOfTwoValues(AVLTreeHeightReturner(somePointer->left), AVLTreeHeightReturner(somePointer->right)) + 1;
	p2->height = maxOfTwoValues(somePointer->height, AVLTreeHeightReturner(p2->right)) + 1;
	return p2;
}

//  левый поворот
Node* successorLLeftRotate(Node*& somePointer) {
	somePointer->left = successorRightRotate(somePointer->left);
	return successorLeftRotate(somePointer);
}

//  правый поворот
Node* successorRRightRotate(Node*& somePointer) {
	somePointer->right = successorLeftRotate(somePointer->right);
	return successorRightRotate(somePointer);
}


int main(void) {
	setlocale(LC_ALL, "ru");
	srand(time(NULL)); // Сгенерированные случанные данные по настоящему будут случайными...
	Node* root = nullptr;
	int max, random, mode, whilecy, newNode, search, deletableNode;
	cout << "----------- АВЛ Дерево -----------" << endl;
	cout << "\t1: Сгенерировать дерево" << endl;
	cout << "\t2: Вставить новый узел" << endl;
	cout << "\t3: Поиск по ключу в дереве" << endl;
	cout << "\t4: Удалить узел" << endl;
	cout << "\t5: Вывод дерева на экран" << endl;
	cout << "\t : Введите луюбое другое значение для выхода..." << endl;
	do {
		cout << endl <<  "Выберите действие!" << endl;
		cin >> mode;
		switch (mode)
		{
		case 1:  //Сгенерировать дерево
			cout << "Введите количество узлов для генерации случайных элементов { srand(time(NULL)) }: " << endl;
			cin >> max;
			for (size_t i = 0; i < max; i++)
			{
				random = rand() % 9999;
				insert(random, root);
			}
			break;
		case 2:	//Вставить новый узел
			cout << "Ввeдите данные для вставки в дерево" << endl;
			cin >> newNode;
			insert(newNode, root);		
			break;
		case 3:	//Поиск по значению
			cout << "Ввeдите искомый узел для поиска" << endl;
			cin >> search;
			find(search, root);
			break;
		case 4: //Удалить элемент
			cout << "Ввeдите узел, которую нужно удалить" << endl;
			cin >> deletableNode;
			deleteNodeFromData(deletableNode, root);
			break;
		case 5:	//Вывод дерева
			printTree(root);
			break;
		default:
			exit(0);
			break;
		}
	} while (true);
	system("pause");
}