#include <stdio.h>
#include <conio.h>
#include <bios.h>
#include <dos.h> //delay

//esc - 27
//up - 0 72
//left -  0 75
//right - 0 77
//down - 0 80
// F3 - 61
// F4 - 62

char keyIsPressed(int x) {
	union REGS r;
	if (x==1) {	// какая кнопка нажата
		r.h.ah = 0x0B;  // AH=0Bh проверка состояния стандартного ввода.
						//	Возвращает в регистре AL значение FFh,
						// если буфер клавиатуры не пуст, и 0 в противном случае.
		int86(0x21, &r, &r); 
		return r.h.al;	
	}
	if(x==0) {	// проверка на нажатие кнопок вообще
		
		r.h.ah = 0x7;  	// AH=07h - ввод с консоли с ожиданием без "эха" на экран
						// ASCII-код прочитанного символа возвращается в AL.
		int86(0x21, &r, &r);  // int int86(int intnum, union REGS *regsin, union REGS *regsout)
							  // int int86(номер прерывания, откуда , куда)
							  // является указателем на структуру, в которую записываются
							  // возвращаемые значения регистров
							  // int86 выполняeт  программное  прерывание 
							  
							
		return r.h.al;		 // на этом этапе просто возвращается ASCII код считонного символа
	}
	return 0;
}

int main() {
	textbackground(0);
	clrscr();
	char c = 0;

	int xMin = 20;
	int xMax = 60;
	int yMin = 10;
	int yMax = 20;
	window(xMin, yMin, xMax, yMax);

	textbackground(4);
	clrscr();

	int winWidth = xMax - xMin + 1;
	int winHeight = yMax - yMin + 1;

	int curX = 1, curY = 1;
	gotoxy(curX, curY);
	printf("*");
	gotoxy(curX, curY);

	while(c != 27) // // пока не нажали ESC
	{
		c = 0;
		unsigned int tmp = 0;
		while(keyIsPressed(1) == 0);	//  bioskey(1)  проверка на нажатие кнопок вообще
			tmp = keyIsPressed(0); 		//    bioskey(0)  возвращает нажатую
		c = tmp%256;
		if(c == 0)
			c = tmp/256;
		clrscr();
		switch(c)
		{
		 case 75:	// <-
		 case 61:	// F3
			while(c != 77 || c != 61)
			{
				gotoxy(curX, curY);
				printf(" ");
				--curX;
				if(curX == 0)
				{
					curX = winWidth;
					--curY;
				}
				if(curY == 0)
					curY = winHeight;
				gotoxy(curX, curY);
				printf("*");
				gotoxy(curX, curY);
				if (keyIsPressed(1) != 0)
					break;
				delay(70);
			}
			break;
		 case 77:	// ->
		 case 62:	// F4
			while(c != 75 || c != 62)
			{
				gotoxy(curX, curY);
				printf(" ");
				++curX;
				if(curX == winWidth+1)
				{
					curX = 1;
					++curY;
				}
				if(curY == winHeight+1)
					curY = 1;
				gotoxy(curX, curY);
				printf("*");
				gotoxy(curX, curY);
				if (keyIsPressed(1) != 0)
					break;
				delay(70);
			}
			break;
		default:
			break;
		}
	}
return 0;
}