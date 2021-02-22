# Задание № 1. Поиск показателя GC

[Оригинал задания](https://markoutte.me/students/cpp-ass1/)

## Описание проблемы

Цепочка **ДНК** должна быть каким-либо образом обозначена в базе данных. Обычно используют метод обозначения называемый формат **FASTA**. В этом формате цепочка представлена в виде строки, которая начинается со знака **«>»**, за которым следует информация о названии и характере строки. Последующие строки содержат саму строку; следующая строка, начинавшаяся со знака **«>»** указывает на обозначение следующей цепочки. В нашей реализации цепочка в формате **FASTA** будет помечена **ID «Rosalind_XXXX»**, где *«XXXX»* обозначает четырёхзначное число между *0000* и *9999*.

**Дано:** Максимум 10 цепочек ДНК в формате FASTA (каждая длинной не более 1 тыс. знаков).

**Возвращаемое значение:** ID цепочки, имеющей наибольший показатель содержания GC (относительная величина содержания цитозина (C) и гуанина (G) от общего числа нуклеотидов в цепочке, выраженная в процентах), за которым следует сам показатель цепочки с точностью до 2-х десятичных знаков.

**Пример данных:**

```js
>Rosalind_Sequence_6404
CCTGCGGAAGATCGGCACTAGAATAGCCAGAACCGTTTCTCTGAGGCTTCCGGCCTT
CCCTCCCACTAATAATTCTGAGG
>Rosalind_Sequence_5959
CCATCGGTAGCGCATCCTTAGTCCAATTAAGTCCCTATCCAGGCGCTCCGCCGAAGG
TCTATATCCATTTGTCAGCAGACACGC
>Rosalind_Sequence_0808
CCACCCTCGTGGTATGGCTAGGCATTCAGGAACCGGAGAACGCTTCAGACCAGCCC
GGACTGGGAACCTGCGGGCAGTAGGTGGAAT
```

**Пример возвращаемого значения:**

```
>Rosalind_Sequence_0808
60.92%
```

**Задание:** допишите недостающую часть кода в code_template.cpp так, чтобы программа заработала корректно. Файлы code_template.cpp и rosalind_GC.txt следует поместить в одну и ту же папку; если вы работаете с Windows, то путь до папки не должен содержать пробелов или букв не латинского алфавита.

## Исходные данные задания

Файл входных данных: [rosalind_GC.txt](./rosalind_GC.txt)

**Исходный код программы:**

```C++
/* Template of the assignment 1 */

// Include libraries
#include <cstdio>
#include <fstream>
#include <string>
using namespace std;

// Main function
int main() {
	// Open file "rosaling_GC.txt" without any errors check
	ifstream sample;
	sample.open("rosalind_GC.txt");
	if (!sample.good()) { // Check has file been opened
		printf("%s\n", "Bad file. Does it exist?");
		return -1;
	}
	// Define a strands' amount to process	
	const unsigned int STRANDS_AMOUNT = 9;
	// 2 arrays keep a pair of values: id of a strand and the strand itself
	// e.g.
	// >strand1
	// ACTGA
	// GTTC
	// >strand2
	// CTGGC
	// will be kept as ids[0] == "strand1", ids[1] == "strand2"
	// strands[0] == "ACTGAGTTC", strands[1] == "CTGGC"
	string ids[STRANDS_AMOUNT];
	string strands[STRANDS_AMOUNT];

	// Some auxiliary variables
	int pos = -1;
	string currentLine;
	// Loop writes a pair of a strand's id and the strand to arrays
	while (!sample.eof()) {
		getline(sample, currentLine); // read one line from txt

		if (currentLine[0] == '>') { // check if it's id
			pos++;

			ids[pos] = currentLine.substr(1, currentLine.length()); // fill id
			strands[pos] = "";
		} else { // else proceed the strand filling
			int winReturnPos = currentLine.rfind('\r'); // A dirty hack aganst a windows file format
			strands[pos] += currentLine.substr(0, 
				(winReturnPos < 0) ? currentLine.length() : winReturnPos);
		}
	};

	// some auxiliary variables
	int maxValuePosition = 0;
	double maxValue = 0.0;

	// ============ YOUR CODE HERE =======================



	// ====================================================

	printf("%s\n%.2f%%\n" , ids[maxValuePosition].c_str(), maxValue);

	sample.close();
	return 0;
};
```
## Необходимые инструменты

**Windows:** mingw 
**Linux:** gnu gcc compiler
**Mac:** XCode с g++

Для компиляции программы необходимо через командную строку запустить программу g++ с указанием компилируемого файла, например:

```bash
g++ code_template.cpp
```

В результате в папке появится исполняемый файл под название «a.exe» в Windows или просто «a» в *nix-like системах. Запустите его через консоль, чтобы увидеть результат. Если в ходе компиляции возникают ошибки, внимательно изучите где они произошли и что произошло.
