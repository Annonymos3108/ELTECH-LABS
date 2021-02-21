/*
	This program was created for a course project for taking credit
	for the subject of Algorithms and Data Structures in LETI at CyberSecurity department

													(C) Arthur Nersisyan 11/2019
													vk @arthurnersisyan
*/

//  this file contains only main function for this program

#include "graph.h"


int main() {
	setlocale(LC_ALL, "Russian");
	Graph graf;
	graf.initGraphFromFileAngry();
	graf.QuickSort();
	//graf.BubbleSort();
	graf.Kruskal();
	graf.sortEdgesОfDisjointSetAtLex();
	graf.printUnionFindForest();
	std::cin.get();
	return 0;
}