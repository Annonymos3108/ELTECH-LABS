#include "conio.h"
#include "iostream.h"
#include "stdio.h"
#include "stdlib.h"
#include "dos.h"
#include "windows.h"
#include "time.h"  // ��� delay();

union supertype  // ���஡��� ���ᠭ�� union � print � ���㬥��
{
	unsigned long long llong;
	double dub;
};

void print(double input)
{
	supertype newType; // supertype - �� ⨯ ������ � ���஬ ��� ���� 
	newType.dub = input; // � ⠬ ��� ���� double, ��ᢠ����� ��祭�� input // ���饭�� � ���� llong � dou �१ ���
	for (int i = 16 * sizeof(newType.llong) - 1; i > -1; i--) // 64 ࠧ� (�� 63 �� 0) ������
	{
		cprintf("%d", newType.llong >> i & 1); // ����⮢�� � � 1, � �⮣� ����� �� 0-�� � 1-��
	}
	cprintf("\n\r"); // ����� �뢥�� �� ����, ��ॢ�� ��ப� � �������� ����
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
	unsigned char bg = colors >> 4;	// ����� ࠧ ������ �᫮ i ᤢ����� ����⮢� �� 4 /⠬ �� 16 梥⮢/
	unsigned char text = colors & 15; // �१ ����⮢�� � � 15, ����砥� �᫮ x ���஥ �ᥣ�� �㤥� 0 <= x <= 15
	
	/*
	
	************���� 梥⮢************** // ��� �ࠢ��
	
	BLACK			���	 			0 
	BLUE 			ᨭ�� 				1
	GREEN 			������ 			2 
	CYAN 			ᨭ�-������ 		3 
	RED 			����				4 
	MAGENTA 		��᭮-ᨭ�� 		5
	BROWN	 		���筥�� 			6
	LIGHTGRAY 		ᢥ⫮-��� 		7 
	DARKGRAY 	 	⥬��-��� 		8 
	LIGHTBLUE 	 	�મ-ᨭ�� 			9 
	LIGHTGREEN		�મ-������		10
	LIGHTCYAN	  	�ન� ᨭ�-������	11
	LIGHTRED 		�મ-���� 		12 
	LIGHTMAGENTA	�ન� ��᭮-ᨭ��	13
	YELLOW	 		�����	 			14
	WHITE  			���� 				15
	
	*/
	
	// ���� ����� ࠧ �������� � ���� �� case-�� � ���⠥� �᫮ 梥� 䮭� � ⥪��
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
}

int main()
{
	double input = 3.14;	// �᫮ ���஥ �㤥� �।�⠢���� � ����筮� ������樨, ������ ��������, �⠢� �� ���������
	clrscr();  //���� ���⪠ �࠭�
	window(25, 10, 55, 20); // ��⠭���� ���� �뢮�� � ���᮫�
	textattr(112);  // ��⠭�������� �����६���� ��� 梥� ��।���� �����, ⠪ � 䮭�
	scroll(0, 0, 9, 24, 19, 54, 6); // �஫���� ᢥ��� ����
	for (int i=0; i<127; i++)  // �.�. 16 梥⮢ 䮭� + 16 梥⮢ ⥪��, �ᥣ� 128 �������樨�, ����� � 0� �� 127
	{
		textattr(i);			// ������ 梥� ⥪��
		print(input);	// ���⠥� ����筮� �।�⠢����� �᫠ ⨯� Double (64 ���)
		GetPrintColor(i);		// ������ 梥� 䮭� � ⥪�� ��� ᫥���饩 ���樨 横��	
		delay(200);  // ����প� � ����ᥪ㭤�� 0.2 ᥪ = 200 �ᥪ  ���ࢠ� T ᥪ
		scroll(6, 3, 9, 24, 19, 54, i); // �஫���� // ��ࢮ� �᫮ - 6- ���ࠢ����� �஫����� (7 ���⭮) 
		//��஥ �᫮ ���ࢠ� S ��ப, �� ��⠫쭮� �� ���� ����� ����砫쭮 �������� ����,
		//�� ��� �� ��६ ����, �� ����� ���������� ⥪�饣� ����, � ⥬� �� ࠧ��ࠬ� � ��������� �� ���� ⥪�饩 
	} 
	cprintf("\n\r The program has been ends... --------\n\r");
	getch();	// ������� ������ ����� � �� ������ �⮡� ��� �� �ணࠬ��
	return 0;
}
