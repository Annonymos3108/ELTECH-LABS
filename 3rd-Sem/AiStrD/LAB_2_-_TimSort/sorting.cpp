#include <iostream>
#include <vector>		// ��� vector
#include <algorithm>	// ��� min

using namespace std;

typedef unsigned int uint;

void printArray(int* array, uint num);
void swap(int* array, int a, int b);
int getMinrun(int n);
void sortInsertionPart(int* array, int start, int end, int num);
void merge(int* array, int fStart, int fLength, int sStart, int sLength, int num);
void sortTimsort(int* array, int N);

typedef struct Default_Range	// ��������� ��� ��������  
{
	int start;			// ������ ����������
	int length;			// � ��� �����.
} Range;


void swap(int* array, int a, int b) // ������� ��� ������ ��������� ����� ����� //swap
{
	int temp = array[a];
	array[a] = array[b];
	array[b] = temp;
}

int getMinrun(int n)  // ��������� �������� ����������� 
{
	int r = 0;
	while (n >= 64)
	{
		r |= n & 1;
		n >>= 1; // = n / 2
	}
	return n + r;
}

//������� ���������� �������
//�������� �� ���� ������ � ��������� ���������� ���������� ����������

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

//������� ������� �����������
//�������� �� ���� ������ � ��������� ����������� (Range x, Range y), ���������� �������.
void merge(int* array, int fStart, int fLength, int sStart, int sLength, int num)
{
	int* tmp = new int[fLength];   // �� ������� ������� ��������� (x) ������� ��������� ������
	memcpy(tmp, &array[fStart], sizeof(int) * (fLength));  // �������� ���� �������� �� ������� ���������,
	int fIndex = 0;
	int sIndex = sStart;
	int i = fStart;
	while (i < sStart + sLength - 1)    // ��������� �������� �� �������(x) � ������� ���������(y) ���������� ��������� 
	{									// � ��������������� ���� ����� ������� ������ ���� ���������� (������� �� x.start �� x.length+y.length).
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


// ������� ������� �� ���� �������� ������ -- ���������� Insertion, � ���������� merge.
void sortTimsort(int* array, int N)
{
	int minrun = getMinrun(N); // ������� MIN RUN ��� ����������� ������� ����������� 
	vector <Range> minrunStack; // ��������� (���������) ��� ������������ ��������������� (Insertion) ������ ������ �������� 
									 // ���� ��������� Default_Range, �.� �������� ��������� ������� ��������� � ��� ����� 
	//vector -- ��� ������ ������������ ������������� �������, ������ ��� �������� ���������� �������, � ������� ��������� new.
	int currentIndex = 0; // ������� ������ (������� ��������������� � ������ ������) ��������� ��� Insertion-sort
	while (currentIndex < N - 1)
	{
		int currentRunIndex = currentIndex; // �� ������� ����������� currentIndex, ��� ��� ��� �����������
		int nextIndex = currentRunIndex + 1;
		if (array[currentRunIndex] > array[nextIndex]) // ���������� ������� � ��� ��������� TRUE � ����������
		{
			swap(array[currentRunIndex], array[nextIndex]);  // ������ ������� ������ ����������� � ���������. ������� �������
		}

		bool goNext = true;
		while (goNext)
		{
			if (array[currentRunIndex] > array[nextIndex]) // ���� �����  TRUE
			{	
				goNext = false; // �� FALSE, ���� ���������� ����. �������
			}	
			if (!(goNext) && (currentRunIndex - currentIndex < minrun)) // ���� ��� ��� � �������� �������
			{
				goNext = true; 
			}
			// ���� �� ����� � 1-� if, �� �� ������ �� 2-� if 
			if (currentRunIndex == N - 1) // ���� ������ ����������, �� ������ � ��������� if, �.�. �� ����� �� ����. �������
			{
				goNext = false;
			}
			if (goNext) //���� ������ ����������, �� ����� �� ����. �������
			{
				++currentRunIndex;
				++nextIndex;
			}
		}
		sortInsertionPart(array, currentIndex, currentRunIndex + 1, N); // �������� ��������� ��� ���������� Insertion-sort
		Range r;
		r.start = currentIndex;
		r.length = currentRunIndex - currentIndex;
		minrunStack.push_back(r); // ������� � ��������� ������������� "������"
		// push_back(element) � �������� ������� � ����� ������-�������
		currentIndex = currentRunIndex;
	} 

	// �������, ����� mergeSort
	while (minrunStack.size() > 1) // ���� �� ��������� ��� �����
	{
		Range x = minrunStack.at(0);
		// at(index) � ����� ������� � ��������� ���������, � ������� �� �������� [ ] 
		// ��������� ����� ��-�� ������ ���������, � � ������ ���� ������� ����������.
		minrunStack.erase(minrunStack.begin());
		// begin() � ���������� ��������, ����������� �� ������ ���������.	
		// erase(iterator ��� iterator ��, � ��) � ������� ������� ��� ������������������ ��������� �� ������-�������.
		Range y = minrunStack.at(0);
		minrunStack.erase(minrunStack.begin());
		// ����� ������ ��� ���������� + ������� �� ��������, ����  � ���� ��� ���� ����� ������ ���.
		if (x.start > y.start) // ���� � ���������� "�����" �, ������� ������� ������ � �����
		{
			swap(x.start, y.start);
			swap(x.length, y.length);
		}
		if (y.start != x.start + x.length) //���� � �� ������� �� �-��, �.�. � ������� �� �,�, ��
		{
			minrunStack.push_back(y); // ������� � ����� ��������� ������������� "������" �, ����� �
			minrunStack.push_back(x);
			continue;
		}
		merge(array, x.start, x.length, y.start, y.length, N);  // ������� � � �
		x.length = x.length + y.length; // ��������� ���� ��������������� � ��� ����� ���������� �� �+�
		minrunStack.push_back(x); // ������ ��� ��������������� (���)������ ������� � ����� ��������� ������������� "������" 
		printArray(array, N); // ������� ���� ������ ��� ������ ���� ����������
	}
}