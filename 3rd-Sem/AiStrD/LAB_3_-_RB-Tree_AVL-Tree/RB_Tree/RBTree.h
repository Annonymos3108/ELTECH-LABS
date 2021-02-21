#pragma once
#include <iostream>

typedef int dataType;   // чтоб можно было выбрать любой тип хранения данных за секунду
enum color {RED, BLACK};

struct Node
{
	Node* left;
	Node* right;
	Node* parent;
	color color;
	dataType data;
};

class RBtree
{
private:
	Node* root;
	void insertfix(Node*);			// балансировка после ввода узла
	void leftrotate(Node*);			// левый  поворот
	void rightrotate(Node*);		// правый поворот
	Node* successor(Node*);			// балансировка
	void delfix(Node*);				// балансировка после удаления узла
	void display(Node*);			// вывод узла
	bool searchbool(dataType x);	// есть такой узел в дереве или нет, дополнение поиска
	void insert(Node* t);			// ввод узла в дерево
	void Destruct(Node *current);	// дополнение к деструктору
public:
	RBtree() :root(nullptr) {};		// конструктор
	~RBtree();						// деструктор
	void createNodeFromUser(RBtree& tree);			// метод добавления узла в дерево
	void createNodeRand(RBtree& tree, int maxnum);	// метод генерации дерева
	void search(dataType data);						// метод поиска в дереве
	void del(dataType x);							// метод удаления узла из дерева
	void disp();									// метод вывода всего дерева
	void displayroot();								// метод вывода корня дерева
};