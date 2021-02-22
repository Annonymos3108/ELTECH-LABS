#include <bios.h>
#include <stdio.h>
#include <conio.h>


int main()
{
	clrscr();			//  очистка экрана, закоментируй эту строку, запускай, смотри что происходит, поймешь зачем она
	char Pressed = 0;		// переменная для состояния кнопки (нажата?/нет?/какая нажата?)
	window(25, 10, 55, 20);	// задаем окно программы в консоли, первые два числа 25,10 - левый вверхний угол (координаты x,y)
							// вторые два числа 55,20 - правый нижний угол (координаты x,y)
	textbackground(6);	//	цвет заданного окна ВЫБИРАЙ САМ
	textcolor(2);		//	цвет символа/текста	ВЫБИРАЙ САМ
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

	int SETTEDWINDOWS_W = 31;		// ширинa  //что за 31?  это Xmax - Xmin + 1 , т.е. 55-25+1
	int SETTEDWINDOWS_H = 11;		// и высотa окна (значение сколько пикселов) //Ymax - Ymin + 1, т.е. 20-10+1

	int curX = 1, curY = 1;					// задали текущее местоположение курсора (мигающая штука _ )
	gotoxy(curX, curY);				
	
	printf("*");			// печатали символ *
	gotoxy(curX, curY);		// задали текущее местоположение курсора в изначальное местоположение чтоб потом стереть
	
	while(Pressed != 27) // пока не нажата ESC
	{
		Pressed = 0;
		unsigned int temp = 0;
		while(kbhit() == 0);	// пока НЕ нажата никакая клавиша вообще
			temp = getch(); 	// возвращает нажатую
		Pressed = temp%256;		// перевод возвращенного значения в char, чтоб потом сравнить с табличными значениями клавиш
		if(Pressed == 0)			// если до сих пор НЕ нажата никакая клавиша
			Pressed = temp/256;		// то значение клавиши нулевое
		clrscr();				// очиска экрана, ...почему? Потому что нужно переместить символ,
								//   а переместить означает удалить и рисовать в другом месте
		if(Pressed==65) {// нажали F7
			gotoxy(curX, curY);	
			clrscr();	// очистка экрана
			--curX; // из текущей позиции курсор перемещаем на один шаг назад
			gotoxy(curX, curY);		// на текущей позиции печатаем символ
			printf("*");
		}
		if(Pressed == 66) {	// нажали F8
			gotoxy(curX, curY);
			clrscr();	// очистка экрана
			++curX; // из текущей позиции курсор перемещаем на один шаг вперед
			gotoxy(curX, curY);   // на текущей позиции печатаем символ
			printf("*");
		}
	}
	return 0;
}