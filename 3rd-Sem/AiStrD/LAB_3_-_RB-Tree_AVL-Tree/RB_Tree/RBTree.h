#pragma once
#include <iostream>

typedef int dataType;   // ���� ����� ���� ������� ����� ��� �������� ������ �� �������
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
	void insertfix(Node*);			// ������������ ����� ����� ����
	void leftrotate(Node*);			// �����  �������
	void rightrotate(Node*);		// ������ �������
	Node* successor(Node*);			// ������������
	void delfix(Node*);				// ������������ ����� �������� ����
	void display(Node*);			// ����� ����
	bool searchbool(dataType x);	// ���� ����� ���� � ������ ��� ���, ���������� ������
	void insert(Node* t);			// ���� ���� � ������
	void Destruct(Node *current);	// ���������� � �����������
public:
	RBtree() :root(nullptr) {};		// �����������
	~RBtree();						// ����������
	void createNodeFromUser(RBtree& tree);			// ����� ���������� ���� � ������
	void createNodeRand(RBtree& tree, int maxnum);	// ����� ��������� ������
	void search(dataType data);						// ����� ������ � ������
	void del(dataType x);							// ����� �������� ���� �� ������
	void disp();									// ����� ������ ����� ������
	void displayroot();								// ����� ������ ����� ������
};