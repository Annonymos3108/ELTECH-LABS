#pragma once
#include <iostream>

using namespace std;

struct node
{
	int key;
	node* left;
	node* right;
	int height;
};

typedef struct node* nodeptr;

class AVLTree
{
public:
	void insert(int, nodeptr&);		// добавление
	void insertRand(int, nodeptr&);
	void del(int, nodeptr&);		// удаление	
	void find(int, nodeptr&);		// поиск
	int bsheight(nodeptr);			// высота
	
	// min, max
	nodeptr findmin(nodeptr);
	nodeptr findmax(nodeptr);

	// обход и вывод
	void preorder(nodeptr);
	void inorder(nodeptr);
	void postorder(nodeptr);
private:
	// балансировка и повороты
	nodeptr successorLeftRotate(nodeptr&);
	nodeptr successorDeleteLeftRotate(nodeptr&);
	nodeptr successorRightRotate(nodeptr&);
	nodeptr successorDeleteRightRotate(nodeptr&);	
	int deletemin(nodeptr& p);
	int max(int, int);	// возвращает максимум из аргументов
};


