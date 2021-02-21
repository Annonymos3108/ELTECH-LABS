#include "conio.h"
#include "iostream.h"
#include "stdio.h"
#include "stdlib.h"
#include "dos.h"
#include "windows.h"
#include "time.h"  // для delay();

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
			cprintf("Черный\r");
			break;
		case 1:
			cprintf("Синий\r");
			break;
		case 2:
			cprintf("Зеленый\r");
			break;
		case 3:
			cprintf("Циановый\r");
			break;
		case 4:
			cprintf("Красный\r");
			break;
		case 5:
			cprintf("Пурпурный\r");
			break;
		case 6:
			cprintf("Коричневый\r");
			break;
		case 7:
			cprintf("Светло-серый\r");
			break;
		case 8:
			cprintf("Темно-серый\r");
			break;
		case 9:
			cprintf("Светло-голубой\r");
			break;
		case 10:
			cprintf("Светло-зеленый\r");
			break;
		case 11:
			cprintf("Светло-циановый\r");
			break;
		case 12:
			cprintf("Светло-красный\r");
			break;
		case 13:
			cprintf("Светло-пурный\r");
			break;
		case 14:
			cprintf("Желтый\r");
			break;
		case 15:
			cprintf("Белый\r");
			break;
	}
}

int main()
{
	char t;
	long double inputLongDouble;
	scroll(0, 0, 0, 0, 25, 80, 7);
	window(20, 10, 60, 20); // установка окна вывода в консоле
	textattr(112);  // устанавливает одновременно как цвета переднего плана, так и фона
	scroll(0, 0, 9, 19, 19, 59, 7); // скроллинг снизу вверх
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
			delay(1500);  // задержка в милисекундах
			scroll(6, 2, 9, 19, 19, 59, i); // скроллинг
		}while(i < 127); // т.к. 16 цветов фона + 16 цветов текста, всего 128 комбинациий, отсчет с 0я
		cprintf("Что теперь? (y - снова сначала / n - выход): ");
		do{
			cscanf("%c", &t);
		}while(t != 'y' && t  != 'n');
	}while(t == 'y');
	cprintf("\n\r ----- ВСЕ, 2-ЯЛАБА ГОТОВА! --------\n\r");
	getch();
	return 0;
}
