#include "conio.h"
#include "iostream.h"
#include "stdio.h"
#include "stdlib.h"
#include "dos.h"
#include "windows.h"
#include "time.h"  // ��� delay();

union type
{
	unsigned long long ll;
	long double d;
};

void printLongDouble(long double x)
{
	type m;
	m.d = x;
	for (int i = 16 * sizeof(m.ll) - 1; i > -1; i--)
	{
		cprintf("%d", m.ll >> i & 1);
	}
	cprintf("\n\r");
}

void scroll(int direction, int lines, char l_row, char l_col, char r_row, char r_col, char attr)
{
	union REGS r;
	if(direction)
	{
		r.h.al = lines;
		r.h.ah = direction; 
	}
	else
	{
		r.h.al = lines;
		r.h.ah = 6;
	}
	r.h.ch = l_row;
	r.h.cl = l_col;
	r.h.dh = r_row;
	r.h.dl = r_col;
	r.h.bh = attr;
	int86(0x10, &r, &r);
}

void GetPrintColor(unsigned char colors)
{
	unsigned char bg = colors >> 4;
	unsigned char text = colors & 15;
	
	switch(bg)
	{
		case 0:
			cprintf("1 ");
			break;
		case 1:
			cprintf("2 ");
			break;
		case 2:
			cprintf("3 ");
			break;
		case 3:
			cprintf("4 ");
			break;
		case 4:
			cprintf("5 ");
			break;
		case 5:
			cprintf("6 ");
			break;
		case 6:
			cprintf("7 ");
			break;
		case 7:
			cprintf("8 ");
			break;
		case 8:
			cprintf("9 ");
			break;
		case 9:
			cprintf("10 ");
			break;
		case 10:
			cprintf("11 ");
			break;
		case 11:
			cprintf("12 ");
			break;
		case 12:
			cprintf("13 ");
			break;
		case 13:
			cprintf("14 ");
			break;
		case 14:
			cprintf("15 ");
			break;
		case 15:
			cprintf("16 ");
			break;
	}
	switch(text)
	{
		case 0:
			cprintf("����\r");
			break;
		case 1:
			cprintf("�����\r");
			break;
		case 2:
			cprintf("������\r");
			break;
		case 3:
			cprintf("�������\r");
			break;
		case 4:
			cprintf("����\r");
			break;
		case 5:
			cprintf("������\r");
			break;
		case 6:
			cprintf("���筥��\r");
			break;
		case 7:
			cprintf("���⫮-���\r");
			break;
		case 8:
			cprintf("�����-���\r");
			break;
		case 9:
			cprintf("���⫮-���㡮�\r");
			break;
		case 10:
			cprintf("���⫮-������\r");
			break;
		case 11:
			cprintf("���⫮-樠����\r");
			break;
		case 12:
			cprintf("���⫮-����\r");
			break;
		case 13:
			cprintf("���⫮-����\r");
			break;
		case 14:
			cprintf("�����\r");
			break;
		case 15:
			cprintf("����\r");
			break;
	}
}

int main()
{
	char t;
	long double inputLongDouble;
	scroll(0, 0, 0, 0, 25, 80, 7);
	window(20, 10, 60, 20); // ��⠭���� ���� �뢮�� � ���᮫�
	textattr(112);  // ��⠭�������� �����६���� ��� 梥� ��।���� �����, ⠪ � 䮭�
	scroll(0, 0, 9, 19, 19, 59, 7); // �஫���� ᭨�� �����
	cprintf("\n\n\n\n\n\n\n\n\r");
	do{
		unsigned char i = 0;
		do
		{
			textattr(i);
			inputLongDouble = ((0.956358714)*(rand() % 12501));
			printLongDouble(inputLongDouble);
			GetPrintColor(i);
			i++;			
			delay(1500);  // ����প� � ����ᥪ㭤��
			scroll(6, 2, 9, 19, 19, 59, i); // �஫����
		}while(i < 127); // �.�. 16 梥⮢ 䮭� + 16 梥⮢ ⥪��, �ᥣ� 128 �������樨�, ����� � 0�
		cprintf("�� ⥯���? (y - ᭮�� ᭠砫� / n - ��室): ");
		do{
			cscanf("%c", &t);
		}while(t != 'y' && t  != 'n');
	}while(t == 'y');
	cprintf("\n\r ----- ���, 2-����� ������! --------\n\r");
	getch();
	return 0;
}
