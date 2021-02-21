#pragma once
#include <iostream>
#include <string>
#include <vector>
#include <fstream>


const unsigned short MIN_DIST = 0;		// Мин дистанция (вес) ребера
const unsigned short MAX_DIST = 1023;
const int MAX_NODES = 50;				// Максимальное кол-во вершин
const int MAX_EDGES = 1225;				// Полный граф с N вершинами имеет N(N-1)/2 рёбер

// класс ребра
class Edge
{
private:
	std::string FirstV, SecondV;	// вершины между которыми связь 
	int FirstVcolor, SecondVcolor;	// цвета вершин 
	unsigned short dist;			// вес ребра с диапазоном 0-1023, проверяеться при вводе
public:
	Edge() : dist(0), FirstVcolor(0), SecondVcolor(0), FirstV(""), SecondV("") {}

	void setDist(unsigned short dist) {
		this->dist = dist;
	}
	void setFirstV(std::string FirstV) {
		this->FirstV = FirstV;
	}
	void setSecondV(std::string SecondV) {
		this->SecondV = SecondV;
	}
	void setFirstVcolor(int FirstVcolor) {
		this->FirstVcolor = FirstVcolor;
	}
	void setSecondVcolor(int SecondVcolor) {
		this->SecondVcolor = SecondVcolor;
	}


	unsigned short getDist() const {
		return dist;
	}
	std::string getFirstV() const {
		return FirstV;
	}
	std::string getSecondV() const {
		return SecondV;
	}
	int getFirstVcolor() const {
		return FirstVcolor;
	}
	int getSecondVcolor() const {
		return SecondVcolor;
	}
};

// класс Графа
class Graph
{
private:

	std::vector<Edge> edges;				// ГРАФ - по сути массив объектов класса Edge (ребер с вершинами)
	std::vector<Edge> disjointSet;			// Минимальное остовное дерево Disjoint-set/Union-find Forest
	std::vector<std::string> collection;	// Колекция вершин

	// вспомогательные функции-члены
	int colorOf(std::string str);			// принимает строку возвращает ASCII код первого элемента
	int maxOf(int a, int b);				// возвращает максимум из аргументов
	int minOf(int a, int b);				// возвращает минимум из аргументов
	bool isABC(char str);					// определяет являеться ли символ буквой
	bool isInCollection(std::string str);	// принимает символ (строку) определяет есть ли такое в коллекции вершин
	void quickSort(std::vector<Edge>& arr, size_t first, size_t last);
	
public:
	Graph() : edges(0), disjointSet(0) {}
	void initGraphFromFileAngry();			// Инициализация ГРАФА, чтение из файла // любая вход. послед.
	void QuickSort();						// сортировка ребер по возрастанию весов
	void Kruskal();							// алгоритм Краскала
	void sortEdgesОfDisjointSetAtLex();		// Сортировка вершины в лекиикографичеком порядке
	void printUnionFindForest();			// Вывод минимального остогого дерева в консоль
};