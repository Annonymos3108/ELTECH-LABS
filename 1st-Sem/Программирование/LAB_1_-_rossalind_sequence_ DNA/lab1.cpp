/* Template of the assignment 1 */

// Include libraries
#include <cstdio>
#include <iostream>
#include <fstream>
#include <string>
using namespace std;

// Main function
int main()
{
	// Open file "rosaling_GC.txt" without any errors check
	ifstream sample;
	sample.open("rosalind_GC.txt");
	if (!sample.good())
	{ // Check has file been opened
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
	while (!sample.eof())
	{
		getline(sample, currentLine); // read one line from txt

		if (currentLine[0] == '>')
		{ // check if it's id
			pos++;

			ids[pos] = currentLine.substr(1, currentLine.length()); // fill id
			strands[pos] = "";
		}
		else { // else proceed the strand filling
			int winReturnPos = currentLine.rfind('\r'); // A dirty hack aganst a windows file format
			strands[pos] += currentLine.substr(0,
				(winReturnPos < 0) ? currentLine.length() : winReturnPos);
		}
	};

	// some auxiliary variables
	int maxValuePosition = 0;
	double maxValue = 0.0;

	// ============ YOUR CODE HERE =======================

	double MAXVALUE = 0.0;
	int countC, countG, other; // переменние целового типа чтобы считать количество GC
	char a; 
	int i = 0;
	while (i < STRANDS_AMOUNT)
	{

		string strand1 = strands[i];
		char *buffer1 = &strand1[0];
		countC = countG = other = 0; // присваиваем переменних значения 0 во избежание ошибок в исполнении программы
		while (a = *buffer1++)   // создаем цыкл и расчитаем количество GC и общее количество
		{
			switch (a)
			{
			case 'C':  // если это G или C добавляем значение соответствующей переменной
				countC++;
				break;
			case 'G':
				countG++;
				break;
			default:   // если не G C то добавляем к всему
				other++;
			}
		}
		int sum = countC + countG;  // сумируем количество G,C
		int all = (countC + countG + other); // считраем общее количество

		 //считаем отношение GC к общему (проценты) с погрешностью десятого числа после запятой
		int ka = (sum * 100000 / all) % 10;
		int y = (sum * 100000 / all) / 10;
		if (ka > 5) // округляем
		{
			y++;
		}
		int percent = y / 100;  // сяитаем проценты
		int percent2 = y % 100; // считаем десятичную часть

		float out_value = percent2 % 100;  // переменная с плавающей точкой чтобы хранить значение процентов
		MAXVALUE = percent + out_value / 100;  // складываем значение в один

		if (MAXVALUE>maxValue)
		{
			maxValue = MAXVALUE;
			maxValuePosition = i;


		}
		i++;
	}





	// ====================================================

	printf("%s\n%.2f%%\n", ids[maxValuePosition].c_str(), maxValue);

	sample.close();
	cin.get();
	return 0;
};