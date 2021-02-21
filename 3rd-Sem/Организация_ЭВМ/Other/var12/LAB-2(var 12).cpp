#include "conio.h"
#include "iostream.h"
#include "stdio.h"
#include "stdlib.h"
#include "dos.h"
#include "windows.h"
#include "time.h"  // для delay();

union supertype  // подробное описание union и print в документе
{
	unsigned long long llong;
	double dub;
};

void print(double input)
{
	supertype newType; // supertype - это тип данных в котором два поля 
	newType.dub = input; // и там где поле double, присваиваем зачение input // обращение к полям llong и dou через точку
	for (int i = 16 * sizeof(newType.llong) - 1; i > -1; i--) // 64 раза (от 63 до 0) делаем
	{
		cprintf("%d", newType.llong >> i & 1); // побитовое И с 1, в итоге набор из 0-ей и 1-иц
	}
	cprintf("\n\r"); // когда вывели все биты, перевог строки в заданной окне
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
	unsigned char bg = colors >> 4;	// каждый раз получая число i сдвигаем побитово на 4 /там же 16 цветов/
	unsigned char text = colors & 15; // через побитовое И с 15, получаем число x которое всегда будет 0 <= x <= 15
	
	/*
	
	************карта цветов************** // для справки
	
	BLACK			черный	 			0 
	BLUE 			синий 				1
	GREEN 			зеленый 			2 
	CYAN 			сине-зеленый 		3 
	RED 			красный				4 
	MAGENTA 		красно-синий 		5
	BROWN	 		коричневый 			6
	LIGHTGRAY 		светло-серый 		7 
	DARKGRAY 	 	темно-серый 		8 
	LIGHTBLUE 	 	ярко-синий 			9 
	LIGHTGREEN		ярко-зеленый		10
	LIGHTCYAN	  	яркий сине-зеленый	11
	LIGHTRED 		ярко-красный 		12 
	LIGHTMAGENTA	яркий красно-синий	13
	YELLOW	 		желтый	 			14
	WHITE  			белый 				15
	
	*/
	
	// просто каждый раз попадаем в один из case-ов и печатаем число цвета фона и текста
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
	double input = 3.14;	// число которое будет представлена в двоичном интерпретации, можещь изменить, ставь что пожелаешь
	clrscr();  //просто очистка экрана
	window(25, 10, 55, 20); // установка окна вывода в консоле
	textattr(112);  // устанавливает одновременно как цвета переднего плана, так и фона
	scroll(0, 0, 9, 24, 19, 54, 6); // скроллинг сверху вниз
	for (int i=0; i<127; i++)  // т.к. 16 цветов фона + 16 цветов текста, всего 128 комбинациий, отсчет с 0я до 127
	{
		textattr(i);			// задаем цвет текста
		print(input);	// пеатаем двоичное представление числа типа Double (64 бита)
		GetPrintColor(i);		// задаем цвет фона и текста для следующей итерации цикла	
		delay(200);  // задержка в милисекундах 0.2 сек = 200 мсек  интервал T сек
		scroll(6, 3, 9, 24, 19, 54, i); // скроллинг // первое число - 6- направление скроллинга (7 обратно) 
		//второе число интервал S строк, все остальное на один меньше изначально заднного окна,
		//по сути мы берем окно, на строчку нижестоящую текущего окна, с теми же размерами и поднимаем на место текущей 
	} 
	cprintf("\n\r The program has been ends... --------\n\r");
	getch();	// ожидаем нажатия какой то любой кнопки чтобы выйти из программы
	return 0;
}
