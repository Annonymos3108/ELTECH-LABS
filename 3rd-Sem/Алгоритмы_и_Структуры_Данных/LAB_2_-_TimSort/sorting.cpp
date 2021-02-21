#include <iostream>
#include <vector>		// для vector
#include <algorithm>	// для min

using namespace std;

typedef unsigned int uint;

void printArray(int* array, uint num);
void swap(int* array, int a, int b);
int getMinrun(int n);
void sortInsertionPart(int* array, int start, int end, int num);
void merge(int* array, int fStart, int fLength, int sStart, int sLength, int num);
void sortTimsort(int* array, int N);

typedef struct Default_Range	// Структура для хранения  
{
	int start;			// начала подмассива
	int length;			// и его длины.
} Range;


void swap(int* array, int a, int b) // функция для замены элементов между собой //swap
{
	int temp = array[a];
	array[a] = array[b];
	array[b] = temp;
}

int getMinrun(int n)  // получение размеров подмассивов 
{
	int r = 0;
	while (n >= 64)
	{
		r |= n & 1;
		n >>= 1; // = n / 2
	}
	return n + r;
}

//Функция сортировки вставки
//Получает на вход массив и диапазоны подмассива производит сортировку

void sortInsertionPart(int* array, int start, int end, int num)
{
	for (int i = start + 1; i < end; ++i)
	{
		int current = array[i];
		int j = i - 1;
		while ((j >= start) && (current < array[j]))
		{
			swap(array[j], array[j + 1]);
			--j;
			printArray(array, num);
		}
	}
}

//Функция слияния подмассивов
//Получает на вход массив и диапазоны подмассивов (Range x, Range y), производит слияние.
void merge(int* array, int fStart, int fLength, int sStart, int sLength, int num)
{
	int* tmp = new int[fLength];   // По размеру первого диапазона (x) создает временный массив
	memcpy(tmp, &array[fStart], sizeof(int) * (fLength));  // копирует туда значения из первого диапазона,
	int fIndex = 0;
	int sIndex = sStart;
	int i = fStart;
	while (i < sStart + sLength - 1)    // сравнивая значения из первого(x) и второго диапазона(y) постепенно заполняет 
	{									// в отсортированном виде часть массива равную двум диапазонам (начиная от x.start до x.length+y.length).
		if (array[sIndex] > tmp[fIndex])
		{
			array[i] = tmp[fIndex];
			++fIndex;
			fIndex = min(fIndex, fLength);
		}
		else if (array[sIndex] <= tmp[fIndex])
		{
			array[i] = array[sIndex];
			++sIndex;
			sIndex = min(sIndex, sStart + sLength);
		}
		if (sIndex == sStart + sLength)
		{
			if (fIndex != fLength)
			{
				memcpy(&array[i + 1], &tmp[fIndex], sizeof(int) * (fLength - fIndex));
				i = sStart + sLength;
			}
		}
		if (fIndex == fLength)
		{
			i = sStart + sLength;
		}
		++i;
		printArray(array, num);;
	}
	delete[] tmp;
}


// Функция состоит из двух основных частей -- сортировки Insertion, и сортировки merge.
void sortTimsort(int* array, int N)
{
	int minrun = getMinrun(N); // считаем MIN RUN для определения размера подмассивов 
	vector <Range> minrunStack; // коллекция (подмассив) для перечисления отсортированных (Insertion) кусков хранит значения 
									 // типа Структуры Default_Range, т.е значение начальной позиции подмасива и его длина 
	//vector -- это замена стандартному динамическому массиву, память для которого выделяется вручную, с помощью оператора new.
	int currentIndex = 0; // текущий индекс (который обрабатываеться в данный момент) подмасива для Insertion-sort
	while (currentIndex < N - 1)
	{
		int currentRunIndex = currentIndex; // не трогаем изначальное currentIndex, она нам еще понадобится
		int nextIndex = currentRunIndex + 1;
		if (array[currentRunIndex] > array[nextIndex]) // сравниваем зачения и при получении TRUE в результате
		{
			swap(array[currentRunIndex], array[nextIndex]);  // меняем местами данные находящиеся в соответсв. ячейках массива
		}

		bool goNext = true;
		while (goNext)
		{
			if (array[currentRunIndex] > array[nextIndex]) // если снова  TRUE
			{	
				goNext = false; // то FALSE, чтоб выполнялся след. условие
			}	
			if (!(goNext) && (currentRunIndex - currentIndex < minrun)) // Если все еще в пределах массива
			{
				goNext = true; 
			}
			// если не вошли в 1-й if, то не войдем во 2-й if 
			if (currentRunIndex == N - 1) // если массив закончился, не входим в следующую if, т.е. не ходим на след. позицию
			{
				goNext = false;
			}
			if (goNext) //если массив закончился, не ходим на след. позицию
			{
				++currentRunIndex;
				++nextIndex;
			}
		}
		sortInsertionPart(array, currentIndex, currentRunIndex + 1, N); // передаем подмассив для сортировки Insertion-sort
		Range r;
		r.start = currentIndex;
		r.length = currentRunIndex - currentIndex;
		minrunStack.push_back(r); // плюсуем к коллекции сортированных "кусков"
		// push_back(element) — добавить элемент в конец объект-вектора
		currentIndex = currentRunIndex;
	} 

	// слияние, часть mergeSort
	while (minrunStack.size() > 1) // пока не соединяли все куски
	{
		Range x = minrunStack.at(0);
		// at(index) — Метод доступа к элементам коллекции, в отличие от операции [ ] 
		// проверяет выход из-за границ коллекции, и в случае чего генерит исключение.
		minrunStack.erase(minrunStack.begin());
		// begin() — Возвращает итератор, указывающий на начало коллекции.	
		// erase(iterator или iterator от, и до) — Удаляет элемент или последовательность элементов из объект-вектора.
		Range y = minrunStack.at(0);
		minrunStack.erase(minrunStack.begin());
		// Взяли первые два подмассива + удалили из колекции, чтоб  в след раз тоже всять первуе два.
		if (x.start > y.start) // если х находиться "после" у, свапаем знаения начала и длины
		{
			swap(x.start, y.start);
			swap(x.length, y.length);
		}
		if (y.start != x.start + x.length) //если у не следует за х-ом, т.е. в массиве не Х,У, то
		{
			minrunStack.push_back(y); // плюсуем к конце коллекции сортированных "кусков" у, потом х
			minrunStack.push_back(x);
			continue;
		}
		merge(array, x.start, x.length, y.start, y.length, N);  // слияние х и у
		x.length = x.length + y.length; // подмассив стал отсортированным и его длина увеличился на х+у
		minrunStack.push_back(x); // только что отсортированный (под)массив плюсуем к конце коллекции сортированных "кусков" 
		printArray(array, N); // выводим весь массив для показа шага сортировки
	}
}