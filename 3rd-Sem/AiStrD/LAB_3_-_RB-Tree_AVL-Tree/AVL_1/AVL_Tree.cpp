#include "AVL_Tree.h"

// Добавление
void AVLTree::insert(int x, nodeptr& p)
{
	if (p == NULL)	// создаем ноду
	{
		p = new node;
		p->key = x;
		p->left = NULL;
		p->right = NULL;
		p->height = 0;
		if (p == NULL)
		{
			cout << "Недостаточно памяти!\n" << endl;
		}
	}
	else // если не nullptr 
	{
		if (x < p->key)
		{
			insert(x, p->left);
			if ((bsheight(p->left) - bsheight(p->right)) == 2)
			{
				if (x < p->left->key)
				{
					p = successorLeftRotate(p);
				}
				else
				{
					p = successorDeleteLeftRotate(p);
				}
			}
		}
		else if (x > p->key)
		{
			insert(x, p->right);
			if ((bsheight(p->right) - bsheight(p->left)) == 2)
			{
				if (x > p->right->key)
				{
					p = successorRightRotate(p);
				}
				else
				{
					p = successorDeleteRightRotate(p);
				}
			}
		}
		else   // нашли, не добавляем
			cout << "Элемет существует!\n" << endl;
	}
	int m, n, d;
	m = bsheight(p->left);
	n = bsheight(p->right);
	d = max(m, n);
	p->height = d + 1;
}

void AVLTree::insertRand(int x, nodeptr& p)
{
	if (p == NULL)	// создаем ноду
	{
		p = new node;
		p->key = x;
		p->left = NULL;
		p->right = NULL;
		p->height = 0;
		if (p == NULL)
		{
			cout << "Недостаточно памяти!\n" << endl;
		}
	}
	else // если не nullptr 
	{
		if (x < p->key)
		{
			insertRand(x, p->left);
			if ((bsheight(p->left) - bsheight(p->right)) == 2)
			{
				if (x < p->left->key)
				{
					p = successorLeftRotate(p);
				}
				else
				{
					p = successorDeleteLeftRotate(p);
				}
			}
		}
		else if (x > p->key)
		{
			insertRand(x, p->right);
			if ((bsheight(p->right) - bsheight(p->left)) == 2)
			{
				if (x > p->right->key)
				{
					p = successorRightRotate(p);
				}
				else
				{
					p = successorDeleteRightRotate(p);
				}
			}
		}
	}
	int m, n, d;
	m = bsheight(p->left);
	n = bsheight(p->right);
	d = max(m, n);
	p->height = d + 1;
}

// нахождение самого меньшего ключа в дереве
nodeptr AVLTree::findmin(nodeptr p)
{
	if (p == NULL)
	{
		cout << "В дереве нет элементов\n" << endl;
		return p;
	}
	else
	{
		while (p->left != NULL)	// самый меньший элемент есть самый левый элемент
			p = p->left;
		return p;
	}
}

// нахождение самого большого ключа в дереве
nodeptr AVLTree::findmax(nodeptr p)
{
	if (p == NULL)
	{
		cout << "В дереве нет элементов\n" << endl;
		return p;
	}
	else
	{
		while (p->right != NULL)  // самый большой элемент есть самый правый элемент
		{
			p = p->right;
		}
		return p;
	}
}

// поиск в дереве... рекурсией
void AVLTree::find(int x, nodeptr& p)
{
	if (p == NULL)	//проверка
	{
		cout << "Такого элемента нет\n" << endl;
	}
	else   // меньше влево, больше вправо...
	{
		if (x < p->key)
			find(x, p->left);
		else if (x > p->key)
			find(x, p->right);
		else
			cout << "Такой элемент есть в дереве!\n" << endl;
	}
}

// удаление ключа
void AVLTree::del(int x, nodeptr& p)
{
	nodeptr d;
	if (p == NULL)
	{
		cout << "Такого элемента нет\n" << endl;
	}
	else if (x < p->key)
	{
		del(x, p->left);
	}
	else if (x > p->key)
	{
		del(x, p->right);
	}
	else if ((p->left == NULL) && (p->right == NULL))
	{
		d = p;
		free(d);
		p = NULL;
		cout << "Элемент удален\n" << endl;
	}
	else if (p->left == NULL)
	{
		d = p;
		free(d);
		p = p->right;
		cout << "Элемент удален\n" << endl;
	}
	else if (p->right == NULL)
	{
		d = p;
		p = p->left;
		free(d);
		cout << "Элемент удален\n" << endl;
	}
	else
		p->key = deletemin(p->right);
}

int AVLTree::deletemin(nodeptr& p)
{
	int c;
	cout << "Выбрано удаление минимального значения\n" << endl;
	if (p->left == NULL)
	{
		c = p->key;
		p = p->right;
		return c;
	}
	else
	{
		c = deletemin(p->left);
		return c;
	}
}

// Вывод
// Префикс
void AVLTree::preorder(nodeptr p)
{
	if (p != NULL)
	{
		cout << p->key << "\t";
		preorder(p->left);
		preorder(p->right);
	}
}

// Инфикс
void AVLTree::inorder(nodeptr p)
{
	if (p != NULL)
	{
		inorder(p->left);
		cout << p->key << "\t";
		inorder(p->right);
	}
}

// Постфикс
void AVLTree::postorder(nodeptr p)
{
	if (p != NULL)
	{
		postorder(p->left);
		postorder(p->right);
		cout << p->key << "\t";
	}
}

// простая функиия максимума
int AVLTree::max(int value1, int value2)
{
	return ((value1 > value2) ? value1 : value2);
}

// Высота
int AVLTree::bsheight(nodeptr p)
{
	int t;
	if (p == NULL)
	{
		return -1;
	}
	else
	{
		t = p->height;
		return t;
	}
}

// баланиировщик
// правый поворот
nodeptr AVLTree::successorLeftRotate(nodeptr& p1)	
{
	nodeptr p2;
	p2 = p1->left;
	p1->left = p2->right;
	p2->right = p1;
	p1->height = max(bsheight(p1->left), bsheight(p1->right)) + 1;
	p2->height = max(bsheight(p2->left), p1->height) + 1;
	return p2;
}

// левый поворот
nodeptr AVLTree::successorRightRotate(nodeptr& p1)
{
	nodeptr p2;
	p2 = p1->right;
	p1->right = p2->left;
	p2->left = p1;
	p1->height = max(bsheight(p1->left), bsheight(p1->right)) + 1;
	p2->height = max(p1->height, bsheight(p2->right)) + 1;
	return p2;
}

// после удаления левый поворот
nodeptr AVLTree::successorDeleteLeftRotate(nodeptr& p1)
{
	p1->left = successorRightRotate(p1->left);
	return successorLeftRotate(p1);
}

// после удаления правый поворот
nodeptr AVLTree::successorDeleteRightRotate(nodeptr& p1)
{
	p1->right = successorLeftRotate(p1->right);
	return successorRightRotate(p1);
}