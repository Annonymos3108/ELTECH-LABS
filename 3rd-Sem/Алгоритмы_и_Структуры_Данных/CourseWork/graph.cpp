#include "graph.h"

/*
А. Инициализация ГРАФА											+
Б. Краскал														+
	1. сортировка по возрастанию весов ребер //quickSort		+
	2. раскраска вешин разными цветами							+
	3. Крутится по циклу в методе Kruskal()						+
В. Сортировать вершины в лекиикографичеком порядке				+
Г. Считать сумму вес Минимального остового дерева				+
Д. Вывести МОД и общий вес										+
*/


//=============================== ИНИЦИАЛИЗАЦИЯ ГРАФА =======================
/* Входные данные: любая текстовая последовательность -- без пробелов, с пробелами, как желайте
ОГРАНИЧЕНИЕ вершины и вес должны быть хотя бы на одной строке
открвает файл, считает граф, записывает в класс ребер, каждое созданное ребро добавляет в граф
*/

void Graph::initGraphFromFileAngry() {
	std::string filePath = "mattrix.txt";
	std::string str, getA, getB, getWeight;
	int tempWeight = 0;
	std::ifstream file;

	file.open(filePath);
	if (!file.is_open())
	{
		std::cout << "Oшибка! Не могу открыть файл..." << std::endl;
	}
	else {
		while (!file.eof())
		{
			str = "";
			std::getline(file, str);
			for (size_t i = 0; i < str.length(); i++) {
				getA = ""; getB = "";	getWeight = "";
				while (str[i] == ' ') {
					i++; // перешагаем пробелы если они есть
				}
				if (isABC(str[i])) {
					getA = str[i];
					while (str[i + 1] == ' ') {
						i++;
					}
					if (isABC(str[i + 1])) {  // i+1 безопасно, т.к. если есть 1-ая вершина, то 2-ая точно есть
						getB = str[i + 1];
						while (str[i + 2] == ' ') {
							i++;
						}
						if (!isABC(str[i + 2])) {
							// число нужно проверить, т.к. может быть больше одного знака
							// цикл пока не встретили букву, пробел и пока не кончилась строка
							for (size_t j = i + 2; !isABC(str[j]) && str[j] != ' ' && j < str.length(); j++) {
								getWeight += str[j]; // очередной знак должен быть цифрой, собираем число по символьно
							}
							i += getWeight.length();  // перешагаем длину веса ребра //все число // тоже безопасно
							if (getA.length() && getB.length() && getWeight.length()) {  // если все нашли
								tempWeight = std::stoi(getWeight);	 // извлекаем число из строки в тип int_32
								if (MIN_DIST <= tempWeight && tempWeight <= MAX_DIST) {
									Edge temporay;								// создаем, задаем, добавлем в граф
									temporay.setFirstV(getA);
									temporay.setSecondV(getB);
									temporay.setFirstVcolor(colorOf(getA));		// цвет вершин ASCII-код символа данной вершины
									temporay.setSecondVcolor(colorOf(getB));
									temporay.setDist((unsigned short)tempWeight);  //безопасно т.к tempWeight из [0;1023] см if
									edges.push_back(temporay);
									if (!isInCollection(temporay.getFirstV())) {
										collection.push_back(temporay.getFirstV());
									}
									if (!isInCollection(temporay.getSecondV())) {
										collection.push_back(temporay.getSecondV());
									}
									if (edges.size() > MAX_EDGES) {
										std::cout << "Ошибка! Число ребер должна быть меньше либо равно 1225 !" << std::endl;
										throw;
									}
									if (collection.size() > MAX_NODES) {
										std::cout << "Ошибка! Число ребер вершин должна быть меньше либо равно 50 !" << std::endl;
										throw;
									}
								}
								else {
									std::cout << "Ошибка! Значение веса ребра не входит в диапазон [0; 1023]." << std::endl;
									throw;
								}
							}
						}
					}
				}
			}
		}
		file.close();
		std::cout << "\tРЕБРА" << "\t\t\t\tВЕРШИНЫ" << std::endl << std::endl;
		for (size_t i = 0; i < edges.size(); i++) {
			std::cout << i + 1 << "\t" << edges[i].getFirstV() << "\t" /*<< edges[i].getFirstVcolor() << "\t"*/
				<< edges[i].getSecondV() << "\t" /*<< edges[i].getSecondVcolor() << "\t"*/ << edges[i].getDist();
			if (i < collection.size()) {
				std::cout << "\t\t" << i+1 << "\t" << collection[i] << std::endl;
			}
			else {
				std::cout << std::endl;
			}
		}
	}
	std::cout << std::endl << "Граф задан. Число ребер: " << edges.size()
		<< "\tЧисло вершин: " << collection.size() << std::endl;
}


/*
вспомогающая функция, отвечает за количество вершин графа, пр каждом добавлении новых вершин
ищем в колекции если есть, не включаем, если нету вкулючаем в колекцию
*/
bool Graph::isInCollection(std::string str) {
	for (size_t i = 0; i < collection.size(); i++) {
		if (collection[i] == str || collection[i] == str) {
			return true;
		}
	}
	return false;
}


/*
вспомогающая функция, определяет являеться ли символ буквой
чтобы не писать такое в if-else конструкции
*/
bool Graph::isABC(char str) {
	return (str >= 'A' && str <= 'Z') || (str >= 'a' && str <= 'z');
}


/* ракраска графа -- вспомогательная функиия-метод инициализации графа
принимает строку, возвращает ASCII-код первого символа
*/
int Graph::colorOf(std::string str) {
	int color;
	color = (int)str[0];
	return color;
}


// СОРТИРОВКА ПО ВОЗРАТТАНИЮ весов ребер Графа
void Graph::QuickSort() {
	quickSort(edges, 0, edges.size() - 1);
	/*
	std::cout << edges.size() << std::endl;
	for (size_t i = 0; i < edges.size(); i++)
	{
		std::cout << i << " " << edges[i].getFirstV() << " " << edges[i].getFirstVcolor() << " "
			<< edges[i].getSecondV() << " " << edges[i].getSecondVcolor() << " "
			<< edges[i].getDist() << std::endl;
	}
	*/
	//std::cout << std::endl << "Сортировка ребер по возрастанию весов успешно завершена!" << std::endl;
}

void Graph::quickSort(std::vector<Edge> &arr, size_t first, size_t last) {
	if (first < last)
	{
		int left = first, right = last;
		Edge middle = arr[(left + right) / 2];
		do
		{
			while (arr[left].getDist() < middle.getDist()) left++;
			while (arr[right].getDist() > middle.getDist()) right--;
			if (left <= right)
			{
				Edge tmp = arr[left];
				arr[left] = arr[right];
				arr[right] = tmp;
				left++;
				right--;
			}
		} while (left <= right);
		quickSort(arr, first, right);
		quickSort(arr, left, last);
	}
}


/*
вспомогательные функции к Алгортму Краскала
Возвращают соответственно максимум и минимум из двух значений
*/
int Graph::maxOf(int a, int b) {
	if (a >= b) {
		return a;
	}
	else {
		return b;
	}
}

int Graph::minOf(int a, int b) {
	if (a < b) {
		return a;
	}
	else {
		return b;
	}
}


// РАЛИЗАЦИЯ АЛГОРИТМА КРАСКАЛА

void Graph::Kruskal() {
	for (size_t i = 0; i < edges.size(); i++) {							//	ЦИКЛ-ПОКА не кончились ребра, рассматреть очередное ребро
		if (edges[i].getFirstVcolor() != edges[i].getSecondVcolor()) {	//	ЕСЛИ концы ребра окрашены в разные цвета, ТО
			disjointSet.push_back(edges[i]);							//	добавить ребро в стягивающее дерево и
			int maxcolor = maxOf(edges[i].getFirstVcolor(), edges[i].getSecondVcolor());
			int mincolor = minOf(edges[i].getFirstVcolor(), edges[i].getSecondVcolor());
			edges[i].setFirstVcolor(maxcolor);
			edges[i].setSecondVcolor(maxcolor);
			for (size_t j = 0; j < edges.size(); j++) {					//	перекрасить все вершины, 
				if (edges[j].getFirstVcolor() == mincolor) {			//	цвет которых совпадает с цветoм 
					edges[j].setFirstVcolor(maxcolor);					//	одного конца ребра (берем большую) 
				}
				if (edges[j].getSecondVcolor() == mincolor) {			//	перекрасить все отстальное дерево
					edges[j].setSecondVcolor(maxcolor);
				}
			}
		}
	}
}


// СОРТИРОВКА РЕБЕР В ЛЕКСИКОГРАФИЧЕСКОМ ПОРЯДКЕ
/*
	сортировка вершин каждого ребра лексикографически
	все ребра, которые описаны как "D A" перевести в "A D"
	*/
void Graph::sortEdgesОfDisjointSetAtLex() {

	for (size_t i = 0; i < disjointSet.size(); i++) {
		if (colorOf(disjointSet[i].getFirstV()) > colorOf(disjointSet[i].getSecondV())) {
			std::string temp;	//swap
			temp = disjointSet[i].getFirstV();
			disjointSet[i].getFirstV() = disjointSet[i].getSecondV();
			disjointSet[i].getSecondV() = temp;
		}
	}
	
	for (size_t i = 0; i < disjointSet.size(); i++) {
		for (size_t j = disjointSet.size() - 1; j > i; j--) {
			if (colorOf(disjointSet[j].getFirstV()) < colorOf(disjointSet[j - 1].getFirstV())) {
				Edge temp;		//swap
				temp = disjointSet[j];
				disjointSet[j] = disjointSet[j - 1];
				disjointSet[j - 1] = temp;
			}
		}
	}
	/*
	std::cout << edges.size() << std::endl;
	for (size_t i = 0; i < edges.size(); i++)
	{
		std::cout << i << " " << edges[i].FirstV << " " << edges[i].FirstVcolor << " "
			<< edges[i].SecondV << " " << edges[i].SecondVcolor << " "
			<< edges[i].getDist() << std::endl;
	}
	*/
	//std::cout << std::endl << "Лексикографическая сортировка ребер успешно завершена!" << std::endl;
};


// ВЫВОД МИНИМАЛЬНОГО ОСТОВНОГО ДЕРЕВА и общего веса МОД
void Graph::printUnionFindForest()
{
	std::cout << std::endl << "Минимальное остовное дерево" << std::endl;
	int sumOfEdgeWeight = 0;
	for (size_t i = 0; i < disjointSet.size(); i++)
	{
		std::cout << disjointSet[i].getFirstV() << " "
			<< disjointSet[i].getSecondV() << " "
			<< /*disjointSet[i].getDist() <<*/ std::endl;
		sumOfEdgeWeight += disjointSet[i].getDist();
	}
	std::cout << "Суммарный вес ребер в остовном дереве: " << sumOfEdgeWeight << std::endl;;
	std::cout << "Колиичество ребер в остовном дереве: " << disjointSet.size() << std::endl;;
	/*
	std::cout << std::endl << "edges...." << std::endl;
	for (size_t i = 0; i < edges.size(); i++)
	{
		std::cout << i << " " << edges[i].FirstV << " " << edges[i].FirstVcolor << " "
			<< edges[i].SecondV << " " << edges[i].SecondVcolor << " "
			<< edges[i].getDist() << std::endl;
	}
	*/
}