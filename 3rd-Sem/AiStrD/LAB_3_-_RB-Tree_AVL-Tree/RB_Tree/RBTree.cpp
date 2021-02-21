#include<iostream>
#include "RBTree.h"

RBtree::~RBtree()   // ����������
{
	if (root != NULL)
	{
		Destruct(root);  // ������ ��� ������ ������� ���������� ����������
	}
}

void RBtree::Destruct(Node *current)  // ��� ����������� -- ����������� �������� ������
{
	if (current != nullptr) 
	{
		Destruct(current->left);
		Destruct(current->right);
		delete current;
	}
}


void RBtree::createNodeRand(RBtree &tree, int maxnum)  // ��������� ������ ���� 
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
			delete t;  // ���� ��� ���� -- �������
		else
			tree.insert(t);	 // ���� � ������ ���� -- �������
	}
}

void RBtree::createNodeFromUser(RBtree &tree)  // �������� ���� -- ������ �������� � ����������
{
	dataType input;
	std::cin >> input;
	Node* t = new Node;
	t->data = input;
	t->left = NULL;
	t->right = NULL;
	t->color = RED;
	if (tree.searchbool(t->data))
		delete t;  // ���� ��� ���� -- �������
	else 
		tree.insert(t);					 // ���� � ������ ���� -- �������
}

void RBtree::insert(Node *t)	// t -- ����������� � �������� ����
{
	Node* rootCopy = root, * q = NULL;
	if (root == NULL)  // ���� ������ �� ����������, �� ����������� ���� ���������� ������
	{
		root = t;
		t->parent = NULL;
	}
	else  // ���� ������ ����������... ������� ����� ���� �������� ����
	{
		while (rootCopy != NULL)	// ������� � ������, ���� �� ����� �� ������
		{
			q = rootCopy;
			if (rootCopy->data < t->data)		// ���� ����������� ������ �����/���� �� �� � ������ ���������
				rootCopy = rootCopy->right;
			else								// ����� �� � ����� ���������
				rootCopy = rootCopy->left;
		}
		t->parent = q;						// q ������������ t
		if (q->data < t->data)				// ������ �� �������� t, ������ ���� ������
			q->right = t;
		else								// ���� ����� �������� q
			q->left = t;
	}
	insertfix(t);	// �����������, �������������, ������ ��������...
}

void RBtree::insertfix(Node* t)
{
	Node* uncle = NULL;
	if (root == t) // ���� � ������ ������ ������ ���� ������ � ����� � ���
	{
		t->color = BLACK;
		t->parent = NULL;
		return;
	}
	// �����
	while (t->parent != NULL && t->parent->color == RED)
	{
		Node* grandpa = t->parent->parent;	// ���
		if (grandpa->left == t->parent)		// ���� ���� t ����� ������� ����
		{
			if (grandpa->right != NULL)		// � ��� ���� ��� ������� �������
			{
				uncle = grandpa->right;		// ����� ���� ������ ������� ����
				if (uncle->color == RED)	// � ���� �������
				{
					t->parent->color = BLACK;	// �� ���� t -- ������
					uncle->color = BLACK;		// ���� ���� ������
					grandpa->color = RED;		// ��� �������
					t = grandpa;				
				}
			}
			else  // ���� ��� ������� ����������...
			{
				if (t->parent->right == t)  // ���� t ������ ������� ����, ����� ����� ������� �� ����
				{
					t = t->parent;
					leftrotate(t);
				}
				t->parent->color = BLACK;	// ���� ������
				grandpa->color = RED;		// ��� �������
				rightrotate(grandpa);		// ������ ������� �� ����
			}
		}
		else  // ���� ���� t ������ ������� ����, ���� ����� ��������� ������������...
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
		// ��������� �������� �����
		root->color = BLACK;
		root->parent = NULL;
	}
}

void RBtree::del(dataType x)
{
	if (root == NULL)
	{
		std::cout << "\n������ ������, ������ �������!";
		return;
	}
	Node* p = root;
	Node* y = NULL;
	Node* q = NULL;
	bool found = false;
	while (p != NULL && found == false)  // ����
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
	if (found == false) // �� �����
	{
		std::cout << "\n������ �������� ��� � ������!";
		return;
	}
	else // �����, �������
	{
		std::cout << "\n��������� �������: " << p->data;
		std::cout << "\n����: ";
		if (p->color == BLACK)
			std::cout << "������\n";
		else
			std::cout << "�������\n";

		if (p->parent != NULL)
			std::cout << "\n��������: " << p->parent->data;
		else
			std::cout << "\n� ���� ��� ��������.  ";
		if (p->right != NULL)
			std::cout << "\n������ �������: " << p->right->data;
		else
			std::cout << "\n� ���� ��� ������� �������.  ";
		if (p->left != NULL)
			std::cout << "\n����� �������: " << p->left->data;
		else
			std::cout << "\n� ���� ��� ������ �������.  ";
		
		if (p->left == NULL || p->right == NULL)  // ���� ���� �� ���� ������� ����
			y = p;
		else
			y = successor(p);
		if (y->left != NULL)		// ���� ����� ������� ����������
			q = y->left;
		else						// ���� ���
		{
			if (y->right != NULL)	// � ��� ���� ������ ������� ���� ����������
				q = y->right;
			else					// ���� ���
				q = NULL;
		}
		if (q != NULL)		// ����� ���� ������������� ���� q �� ���� �� ��� ���� ��� ���� � ����
			q->parent = y->parent;
		if (y->parent == NULL)			// ���� ��� ��������, �� �� ������
			root = q;
		else							// �����
		{
			if (y == y->parent->left)	// ���� � ����� ������� ����
				y->parent->left = q;
			else						// ���� ������
				y->parent->right = q;
		}
		if (y != p)
		{
			p->color = y->color;
			p->data = y->data;
		}
		if (y->color == BLACK)  // ���� � ��� ������, ����� �������������
			delfix(q);
		std::cout << "\n���� ��� ������, ������ - �������������!\n";
	}
	
}

void RBtree::delfix(Node* p)
{
	Node* s = NULL; // ����
	while (p != root && p->color == BLACK)	// ���� �� ������ � �� ������ ������������
	{
		if (p->parent->left == p)	// ���� � ����� �������
		{
			s = p->parent->right;	// s - ����
			if (s->color == RED)	// ���� ���� �������
			{
				s->color = BLACK;		// ���� ������
				p->parent->color = RED;	// ���� �������
				leftrotate(p->parent);	// ����� ������� �� ����
				s = p->parent->right;	// ���� ���� ������ �������� ����
			}
			if (s->right->color == BLACK && s->left->color == BLACK)  // ���������� ������ ������������
			{
				s->color = RED; // ����� ���� �������
				p = p->parent;
			}
			else
			{
				if (s->right->color == BLACK)	//���� ������ ��������� ������
				{
					s->left->color = BLACK; // ����� ���� �����
					s->color = RED;			// ���� ����� �������
					rightrotate(s);			// ������ ������� �� ����
					s = p->parent->right;	// ���� ���� ������ �������� ����
				}
				s->color = p->parent->color;
				p->parent->color = BLACK;
				s->right->color = BLACK;
				leftrotate(p->parent);
				p = root;
			}
		}
		else  // ���� � ������ �������, ���������� ��������� �����������
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

void RBtree::leftrotate(Node* p)	// ����� �������
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
void RBtree::rightrotate(Node* p)	// ������ �������
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

Node* RBtree::successor(Node* p)	// �� ����������� ���� ���������� ���������� 
{
	Node* y = NULL;					// 1. �� NULL ���� ��� ��������; 
	if (p->left != NULL)			// 2. �� ������ ��������� ������� ������ ���������
	{
		y = p->left;
		while (y->right != NULL)
			y = y->right;
	}
	else							// 2. �� ����� ��������� ������� ������� ���������
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
		std::cout << "\n������ �����!.";
		return;
	}
	if (p != NULL)
	{
		if (p == root)
			std::cout << "\n ������: ";
		else
			std::cout << " ����: ";
		std::cout << "\n\t������:\t\t" << p->data;
		std::cout << "\n\t����:\t";
		if (p->color == BLACK)
			std::cout << "\t������";
		else
			std::cout << "\t�������";
		if (p->parent != NULL)  // && p != root
			std::cout << "\n\t��������:\t" << p->parent->data;
		else
			std::cout << "\n\t� ���� ��� ��������.";
		if (p->right != NULL)
			std::cout << "\n\t������ �������:\t" << p->right->data;
		else
			std::cout << "\n\t� ���� ��� ������� �������.";
		if (p->left != NULL)
			std::cout << "\n\t����� �������:\t" << p->left->data;
		else
			std::cout << "\n\t� ���� ��� ������ �������.";

		if (p->left)
		{
			std::cout << "\n �����";
			display(p->left);
		}
		else
			std::cout<<"\n\t��� ������ �������.";
		if (p->right)
		{
			std::cout << "\n ������";
			display(p->right);
		}
		else
			std::cout << "\n\t��� ������� �������.";
	}
}

bool RBtree::searchbool(dataType x)		// ���������� ��� ������
{
	if (root == NULL)  //������ �����!
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
		return false;	// �� ����� 
	else
		return true;	// ����� 
}


void RBtree::search(dataType x) 
{
	if (root == NULL)
	{
		std::cout << "\n������ ������\n";
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
		std::cout << "\n������� �� ������!";
		return;
	}
	else
	{
		std::cout << "\n ��������� �������: ";
		std::cout << "\n\t������:\t\t" << p->data;
		std::cout << "\n\t����:\t";
		if (p->color == BLACK)
			std::cout << "\t������";
		else
			std::cout << "\t�������";
		if (p->parent != NULL)
			std::cout << "\n\t��������:\t" << p->parent->data;
		else
			std::cout << "\n\t� ���� ��� ��������.";
		if (p->right != NULL)
			std::cout << "\n\t������ �������:\t" << p->right->data;
		else
			std::cout << "\n\t� ���� ��� ������� �������.";
		if (p->left != NULL)
			std::cout << "\n\t����� �������:\t" << p->left->data;
		else
			std::cout << "\n\t� ���� ��� ������ �������.";
		std::cout << std::endl;
	}
}


void RBtree::displayroot()
{
	if (root == NULL)
	{
		std::cout << "\n������ �����!.";
		return;
	}
	else
	{
		std::cout << "\n ������: ";
		std::cout << "\n\t������:\t\t" << root->data;
		std::cout << "\n\t����:\t";
		if (root->color == BLACK)
			std::cout << "\t������";
		else
			std::cout << "\t�������";
		if (root->parent != NULL)
			std::cout << "\n\t��������:\t" << root->parent->data;
		else
			std::cout << "\n\t� ���� ��� ��������.";
		if (root->right != NULL)
			std::cout << "\n\t������ �������:\t" << root->right->data;
		else
			std::cout << "\n\t� ���� ��� ������� �������.";
		if (root->left != NULL)
			std::cout << "\n\t����� �������:\t" << root->left->data;
		else
			std::cout << "\n\t� ���� ��� ������ �������.";
	}
}