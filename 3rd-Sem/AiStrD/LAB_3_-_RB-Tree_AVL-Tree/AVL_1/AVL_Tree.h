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
	void insert(int, nodeptr&);		// ����������
	void insertRand(int, nodeptr&);
	void del(int, nodeptr&);		// ��������	
	void find(int, nodeptr&);		// �����
	int bsheight(nodeptr);			// ������
	
	// min, max
	nodeptr findmin(nodeptr);
	nodeptr findmax(nodeptr);

	// ����� � �����
	void preorder(nodeptr);
	void inorder(nodeptr);
	void postorder(nodeptr);
private:
	// ������������ � ��������
	nodeptr successorLeftRotate(nodeptr&);
	nodeptr successorDeleteLeftRotate(nodeptr&);
	nodeptr successorRightRotate(nodeptr&);
	nodeptr successorDeleteRightRotate(nodeptr&);	
	int deletemin(nodeptr& p);
	int max(int, int);	// ���������� �������� �� ����������
};


