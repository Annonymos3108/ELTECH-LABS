#include<iostream>
#include "RBTree.h"

RBtree::~RBtree()   // деструктор
{
	if (root != NULL)
	{
		Destruct(root);  // потому что нельзя вызвать деструктор рекурсивно
	}
}

void RBtree::Destruct(Node *current)  // для деструктора -- рекурсивное удаление дерева
{
	if (current != nullptr) 
	{
		Destruct(current->left);
		Destruct(current->right);
		delete current;
	}
}


void RBtree::createNodeRand(RBtree &tree, int maxnum)  // генерация нового узла 
{
	for (int i = 0; i < maxnum; i++)
	{
		Node* t = new Node;
		t->left = NULL;
		t->right = NULL;
		t->parent = NULL;
		t->color = RED;
		t->data = rand() % 998 + 1;
		if (tree.searchbool(t->data))
			delete t;  // если уже есть -- удаляем
		else
			tree.insert(t);	 // если в дереве нету -- заносим
	}
}

void RBtree::createNodeFromUser(RBtree &tree)  // создание узла -- данные вводятся с клавиатуры
{
	dataType input;
	std::cin >> input;
	Node* t = new Node;
	t->data = input;
	t->left = NULL;
	t->right = NULL;
	t->color = RED;
	if (tree.searchbool(t->data))
		delete t;  // если уже есть -- удаляем
	else 
		tree.insert(t);					 // если в дереве нету -- заносим
}

void RBtree::insert(Node *t)	// t -- вставляемый в деререво узел
{
	Node* rootCopy = root, * q = NULL;
	if (root == NULL)  // если дерево не существует, то добавляемый узел становится корнем
	{
		root = t;
		t->parent = NULL;
	}
	else  // если дерево существует... находим место куда вставить узел
	{
		while (rootCopy != NULL)	// смотрим в дерево, пока не дошли до листов
		{
			q = rootCopy;
			if (rootCopy->data < t->data)		// если вставляемый больше корня/узла то ГО в правое поддерево
				rootCopy = rootCopy->right;
			else								// иначе ГО в левое поддерево
				rootCopy = rootCopy->left;
		}
		t->parent = q;						// q усонавливает t
		if (q->data < t->data)				// исходя из значения t, ставим либо правым
			q->right = t;
		else								// либо левым потомком q
			q->left = t;
	}
	insertfix(t);	// балансируем, перекрашиваем, делаем повороты...
}

void RBtree::insertfix(Node* t)
{
	Node* uncle = NULL;
	if (root == t) // если в дереве только данный узел красим в ченое и все
	{
		t->color = BLACK;
		t->parent = NULL;
		return;
	}
	// иначе
	while (t->parent != NULL && t->parent->color == RED)
	{
		Node* grandpa = t->parent->parent;	// дед
		if (grandpa->left == t->parent)		// если отец t левый потомок деда
		{
			if (grandpa->right != NULL)		// и при этом нет правого потомка
			{
				uncle = grandpa->right;		// тогда дядя правый потомок деда
				if (uncle->color == RED)	// и если красный
				{
					t->parent->color = BLACK;	// то отец t -- черный
					uncle->color = BLACK;		// дядя тоже черный
					grandpa->color = RED;		// дед красный
					t = grandpa;				
				}
			}
			else  // если оба потомка существуют...
			{
				if (t->parent->right == t)  // если t правый потомок отца, тогда левый поворот от отца
				{
					t = t->parent;
					leftrotate(t);
				}
				t->parent->color = BLACK;	// отец черный
				grandpa->color = RED;		// дед красный
				rightrotate(grandpa);		// правый поворот от деда
			}
		}
		else  // если отец t правый потомок деда, тоже самое зеркально отображенное...
		{
			if (grandpa->left != NULL)
			{
				uncle = grandpa->left;
				if (uncle->color == RED)
				{
					t->parent->color = BLACK;
					uncle->color = BLACK;
					grandpa->color = RED;
					t = grandpa;
				}
			}
			else
			{
				if (t->parent->left == t)
				{
					t = t->parent;
					rightrotate(t);
				}
				t->parent->color = BLACK;
				grandpa->color = RED;
				leftrotate(grandpa);
			}
		}
		// сохраняем свойства корня
		root->color = BLACK;
		root->parent = NULL;
	}
}

void RBtree::del(dataType x)
{
	if (root == NULL)
	{
		std::cout << "\nПустое дерево, нечего удалить!";
		return;
	}
	Node* p = root;
	Node* y = NULL;
	Node* q = NULL;
	bool found = false;
	while (p != NULL && found == false)  // ищем
	{
		if (p->data == x)
			found = true;
		if (found == false)
		{
			if (p->data < x)
				p = p->right;
			else
				p = p->left;
		}
	}
	if (found == false) // не нашли
	{
		std::cout << "\nТакого элемента нет в дереве!";
		return;
	}
	else // нашли, удаляем
	{
		std::cout << "\nУдаленный элемент: " << p->data;
		std::cout << "\nЦвет: ";
		if (p->color == BLACK)
			std::cout << "Черный\n";
		else
			std::cout << "Красный\n";

		if (p->parent != NULL)
			std::cout << "\nРодитель: " << p->parent->data;
		else
			std::cout << "\nУ него нет родителя.  ";
		if (p->right != NULL)
			std::cout << "\nПравый потомок: " << p->right->data;
		else
			std::cout << "\nУ него нет правого потомка.  ";
		if (p->left != NULL)
			std::cout << "\nЛевый потомок: " << p->left->data;
		else
			std::cout << "\nУ него нет левого потомка.  ";
		
		if (p->left == NULL || p->right == NULL)  // если хотя бы один потомок лист
			y = p;
		else
			y = successor(p);
		if (y->left != NULL)		// если левый потомок существует
			q = y->left;
		else						// если нет
		{
			if (y->right != NULL)	// и при этом правый потомок тоже существует
				q = y->right;
			else					// если нет
				q = NULL;
		}
		if (q != NULL)		// после выше происходящего если q не лист то его отец это отец у тоже
			q->parent = y->parent;
		if (y->parent == NULL)			// если нет родителя, то он корень
			root = q;
		else							// иначе
		{
			if (y == y->parent->left)	// если у левый потомок отца
				y->parent->left = q;
			else						// если правый
				y->parent->right = q;
		}
		if (y != p)
		{
			p->color = y->color;
			p->data = y->data;
		}
		if (y->color == BLACK)  // если у был черным, нужно балансировать
			delfix(q);
		std::cout << "\nУзел был удален, дерево - сбалансирован!\n";
	}
	
}

void RBtree::delfix(Node* p)
{
	Node* s = NULL; // дядя
	while (p != root && p->color == BLACK)	// пока не корень и не черный одновременно
	{
		if (p->parent->left == p)	// если р левый потомок
		{
			s = p->parent->right;	// s - дядя
			if (s->color == RED)	// если дядя красный
			{
				s->color = BLACK;		// дядя черный
				p->parent->color = RED;	// отец красный
				leftrotate(p->parent);	// левый поворот от отца
				s = p->parent->right;	// дядя стал правым потомком отца
			}
			if (s->right->color == BLACK && s->left->color == BLACK)  // племянники черные одновременно
			{
				s->color = RED; // тогда дядя красный
				p = p->parent;
			}
			else
			{
				if (s->right->color == BLACK)	//если правый племянник черный
				{
					s->left->color = BLACK; // левый тоже будет
					s->color = RED;			// дядя опять красный
					rightrotate(s);			// правый поворот от дяди
					s = p->parent->right;	// дядя стал правым потомком отца
				}
				s->color = p->parent->color;
				p->parent->color = BLACK;
				s->right->color = BLACK;
				leftrotate(p->parent);
				p = root;
			}
		}
		else  // если р правый потомок, аналогично зеркально отображенно
		{
			s = p->parent->left;
			if (s->color == RED)
			{
				s->color = BLACK;
				p->parent->color = RED;
				rightrotate(p->parent);
				s = p->parent->left;
			}
			if (s->left->color == BLACK && s->right->color == BLACK)
			{
				s->color = RED;
				p = p->parent;
			}
			else
			{
				if (s->left->color == BLACK)
				{
					s->right->color = BLACK;
					s->color = RED;
					leftrotate(s);
					s = p->parent->left;
				}
				s->color = p->parent->color;
				p->parent->color = BLACK;
				s->left->color = BLACK;
				rightrotate(p->parent);
				p = root;
			}
		}
		p->color = BLACK;
		root->color = BLACK;
		root->parent = NULL;
	}
}

void RBtree::leftrotate(Node* p)	// левый поворот
{
	if (p->right == NULL)
		return;
	else
	{
		Node* y = p->right;
		if (y->left != NULL)
		{
			p->right = y->left;
			y->left->parent = p;
		}
		else
			p->right = NULL;
		if (p->parent != NULL)
			y->parent = p->parent;
		if (p->parent == NULL)
			root = y;
		else
		{
			if (p == p->parent->left)
				p->parent->left = y;
			else
				p->parent->right = y;
		}
		y->left = p;
		p->parent = y;
	}
}
void RBtree::rightrotate(Node* p)	// правый поворот
{
	if (p->left == NULL)
		return;
	else
	{
		Node* y = p->left;
		if (y->right != NULL)
		{
			p->left = y->right;
			y->right->parent = p;
		}
		else
			p->left = NULL;
		if (p->parent != NULL)
			y->parent = p->parent;
		if (p->parent == NULL)
			root = y;
		else
		{
			if (p == p->parent->left)
				p->parent->left = y;
			else
				p->parent->right = y;
		}
		y->right = p;
		p->parent = y;
	}
}

Node* RBtree::successor(Node* p)	// от переданного узла возвращает возвращает 
{
	Node* y = NULL;					// 1. на NULL если нет потомков; 
	if (p->left != NULL)			// 2. на правый последний элемент левого поддерева
	{
		y = p->left;
		while (y->right != NULL)
			y = y->right;
	}
	else							// 2. на левый последний элемент правого поддерева
	{
		y = p->right;
		while (y->left != NULL)
			y = y->left;
	}
	return y;
}

void RBtree::disp()
{
	display(root);
}

void RBtree::display(Node* p)
{
	if (root == NULL)
	{
		std::cout << "\nДерево пуста!.";
		return;
	}
	if (p != NULL)
	{
		if (p == root)
			std::cout << "\n Корень: ";
		else
			std::cout << " Узел: ";
		std::cout << "\n\tДанные:\t\t" << p->data;
		std::cout << "\n\tЦвет:\t";
		if (p->color == BLACK)
			std::cout << "\tЧерный";
		else
			std::cout << "\tКрасный";
		if (p->parent != NULL)  // && p != root
			std::cout << "\n\tРодитель:\t" << p->parent->data;
		else
			std::cout << "\n\tУ него нет родителя.";
		if (p->right != NULL)
			std::cout << "\n\tПравый потомок:\t" << p->right->data;
		else
			std::cout << "\n\tУ него нет правого потомка.";
		if (p->left != NULL)
			std::cout << "\n\tЛевый потомок:\t" << p->left->data;
		else
			std::cout << "\n\tУ него нет левого потомка.";

		if (p->left)
		{
			std::cout << "\n Левый";
			display(p->left);
		}
		else
			std::cout<<"\n\tНет левого потомка.";
		if (p->right)
		{
			std::cout << "\n Правый";
			display(p->right);
		}
		else
			std::cout << "\n\tНет правого потомка.";
	}
}

bool RBtree::searchbool(dataType x)		// дополнение для поиска
{
	if (root == NULL)  //Дерево пуста!
		return false;
	Node* p = root;
	bool found = false;
	while (p != NULL && found == false)
	{
		if (p->data == x)
			found = true;
		if (found == false)
		{
			if (p->data < x)
				p = p->right;
			else
				p = p->left;
		}
	}
	if (found == false)
		return false;	// не нашел 
	else
		return true;	// нашел 
}


void RBtree::search(dataType x) 
{
	if (root == NULL)
	{
		std::cout << "\nПустое дерево\n";
		return;
	}
	Node* p = root;
	bool found = false;
	while (p != NULL && found == false)
	{
		if (p->data == x)
			found = true;
		if (found == false)
		{
			if (p->data < x)
				p = p->right;
			else
				p = p->left;
		}
	}
	if (found == false)
	{
		std::cout << "\nЭлемент не найден!";
		return;
	}
	else
	{
		std::cout << "\n Найденный элемент: ";
		std::cout << "\n\tДанные:\t\t" << p->data;
		std::cout << "\n\tЦвет:\t";
		if (p->color == BLACK)
			std::cout << "\tЧерный";
		else
			std::cout << "\tКрасный";
		if (p->parent != NULL)
			std::cout << "\n\tРодитель:\t" << p->parent->data;
		else
			std::cout << "\n\tУ него нет родителя.";
		if (p->right != NULL)
			std::cout << "\n\tПравый потомок:\t" << p->right->data;
		else
			std::cout << "\n\tУ него нет правого потомка.";
		if (p->left != NULL)
			std::cout << "\n\tЛевый потомок:\t" << p->left->data;
		else
			std::cout << "\n\tУ него нет левого потомка.";
		std::cout << std::endl;
	}
}


void RBtree::displayroot()
{
	if (root == NULL)
	{
		std::cout << "\nДерево пуста!.";
		return;
	}
	else
	{
		std::cout << "\n Корень: ";
		std::cout << "\n\tДанные:\t\t" << root->data;
		std::cout << "\n\tЦвет:\t";
		if (root->color == BLACK)
			std::cout << "\tЧерный";
		else
			std::cout << "\tКрасный";
		if (root->parent != NULL)
			std::cout << "\n\tРодитель:\t" << root->parent->data;
		else
			std::cout << "\n\tУ него нет родителя.";
		if (root->right != NULL)
			std::cout << "\n\tПравый потомок:\t" << root->right->data;
		else
			std::cout << "\n\tУ него нет правого потомка.";
		if (root->left != NULL)
			std::cout << "\n\tЛевый потомок:\t" << root->left->data;
		else
			std::cout << "\n\tУ него нет левого потомка.";
	}
}