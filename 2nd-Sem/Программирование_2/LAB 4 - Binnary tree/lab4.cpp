#include <iostream> 

using namespace std;

struct Node
{
	char info;
	Node *left;
	Node *right;
};

int i = 0;

void Add_Node(int x, Node *&p)
{
	if (NULL == p)
	{
		p = new Node;
		p->info = x;
		p->left = p->right = NULL;
	}

	if (x < p->info)
	{
		if (p->left != NULL) Add_Node(x, p->left);
		else
		{
			p->left = new Node;
			p->left->left = p->left->right = NULL;
			p->left->info = x;
		}
	}

	if (x > p->info)
	{
		if (p->right != NULL) Add_Node(x, p->right);
		else
		{
			p->right = new Node;
			p->right->left = p->right->right = NULL;
			p->right->info = x;
		}
	}
}

void Show_Prefics(Node *p)
{
	if (p)
	{
		cout << p->info << ' ';
		Show_Prefics(p->left);
		Show_Prefics(p->right);
	}
}

void Show_Infics(Node *p)
{
	if (p)
	{
		Show_Infics(p->left);
		cout << p->info << ' ';
		Show_Infics(p->right);
	}
}

void Show_Postfics(Node *p)
{
	if (p)
	{
		Show_Postfics(p->left);
		Show_Postfics(p->right);
		cout << p->info << ' ';
	}
}

void Delete_Tree(Node *&p)
{
	if (p != NULL)
	{
		Delete_Tree(p->left);
		Delete_Tree(p->right);
		delete p;
		p = NULL;
	}
}

int main()
{
	Node *Root, *p;
	char x = 0;
	Root = 0;
	p = 0;

	while (i < 8)
	{
		i++;
		x = rand() % 62;
		if (x < 10) x += 48;
		else
		{
			x -= 10;
			if (x < 26) x += 65;
			else
			{
				x -= 26;
				if (x < 26) x += 97;
			}
		}
		Add_Node(x, Root);
	}

	cout << "Prefics\n";
	Show_Prefics(Root);
	cout << "\nInfics\n";
	Show_Infics(Root);
	cout << "\nPostfics\n";
	Show_Postfics(Root);
	cin.get();
	Delete_Tree(Root);
	return 0;
}