#include <bios.h>
#include <stdio.h>
#include <conio.h>
#include <dos.h>

 /* Note the use of "intr()" instead of "int86()" so we can pass
  segment registers */

char BIOSKEY()    // какая кнопка нажата
{
	union REGS r; 
	r.h.ah = 0x0B;
	int86(0x21, &r, &r);
	return r.h.al;
}

char BIOSKEYD()    // 
{
	union REGS r; 
	r.h.ah = 0x7;
	int86(0x21, &r, &r);
	return r.h.al;
}


int main(void)
{
	
	clrscr();	// очистка экрана
	char key = 0;	// переменная для состояния кнопки
	
	// координаты окна
	int X0 = 15;
	int X1 = 65;
	int Y0 = 8;
	int Y1 = 18;
	
	window(X0, Y0, X1, Y1);

	textbackground(10);	//	цвет заданного окна
	textcolor(4);		//	цвет символа/текста
	/*
	коды цветов
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
	
	clrscr();			// снова очистка, но теперь заданного окна

	int winWidth = X1 - X0 + 1;			// взяли ширину 
	int winHeight = Y1 - Y0 + 1;		// и высоту окна (значение сколько пикселов)

	int curX = 1, curY = 1;			// задали текущее местоположение курсора
	gotoxy(curX, curY);				
	
	printf("*");			// печатали символ *
	gotoxy(curX, curY);		// задали текущее местоположение курсора в изначальное местоположение
							// чтоб потом стереть

	while(key != 39) // пока не нажата ПРОБЕЛ
	{
		key = 0;
		unsigned int temp = 0;
		while(BIOSKEY() == 0);	// Использование прерывания INT 16h // пока НЕ нажата никакая клавиша вообще
			temp = BIOSKEYD(); 	// возвращает нажатую
		key = temp%256;
		if(temp == 0)			// если до сих пор НЕ нажата никакая клавиша
			key = temp/256;		// то значение клавиши нулевое
		clrscr();				// очиска экрана, потому что нужно переместить символ,
		
		//printf("%d", key);
		
		// а переместить означает удалить и рисовать в другом месте
		switch(key)
		{
		case 59:	// нажали F1*/
			gotoxy(curX, curY);	
			clrscr();	// очистка экрана
			--curX; // из текущей позиции курсор перемещаем на один шаг назад
			if(curX == 0)	// а если дошли до начала окна, (уперлись в левую стену)
			{
				curX = winWidth;  // тогда как змейка из NOKIA-3310 выходим из правой стены
				--curY; 
			}
			if(curY == 0)
				curY = winHeight;	// на противоположном уровне
			gotoxy(curX, curY);		// на текущей позиции печатаем символ
			printf("*");
			break;
		 case 60:	// нажали F2
			gotoxy(curX, curY);	
			clrscr();	// очистка экрана
			--curY; // из текущей позиции курсор перемещаем на один шаг вверх
			if(curY == 0)	// а если дошли до вверха окна, (уперлись в потолок)
			{
				curY = winHeight;  // тогда как змейка из NOKIA-3310 выходим из пола
				--curX; 
			}
			if(curX == 0)
				curX = winWidth;	// на той же позиции
			gotoxy(curX, curY);		// на текущей позиции печатаем символ
			printf("*");
			break;	
		 case 61:	// нажали F3
			gotoxy(curX, curY);
			clrscr();	// очистка экрана
			++curY; // из текущей позиции курсор перемещаем на один шаг вниз
			if(curY == winHeight+1)	// а если дошли до конца окна, (уперлись в пол)
			{
				curY = 1;	// выходим из потолка
				++curX;
			}
			if(curX == winWidth+1)	// на том же уровне
				curX = 1;
			gotoxy(curX, curY);   // на текущей позиции печатаем символ
			printf("*");
			break;
		 case 62:	// нажали F4
			gotoxy(curX, curY);
			clrscr();	// очистка экрана
			++curX; // из текущей позиции курсор перемещаем на один шаг вперед
			if(curX == winWidth+1)	// а если дошли до конца окна, (уперлись в правую стену)
			{
				curX = 1;	// выходим из левой стены
				++curY;
			}
			if(curY == winHeight+1)	// на противоположном уровне
				curY = 1;
			gotoxy(curX, curY);   // на текущей позиции печатаем символ
			printf("*");
			break;	
		 default: // default не нужна для правильного функционирования прогр., но если не будет,
				 // когда будет нажата клавиша непредусмотренная программой, то она затупит и ниечго не будет делать...
			break;
		}
	}
}