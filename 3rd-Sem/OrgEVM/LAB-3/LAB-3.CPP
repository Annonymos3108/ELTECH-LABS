//  работа с видеосистемой в графическом режиме
#include "stdio.h"
#include "conio.h"
#include "math.h"
#include "dos.h"
#include "graphics.h"
#include "iostream.h"
#include "stdlib.h"
#include "windows.h"
#include "time.h" 

int Xmax, Ymax, X0, X1, Y0, Y1, GrDr, GrM, RN[200];

float R[200], Rmax=0.;

char GrP[50]="..//BORLANDC//BGI"; // Расположение драйверов BGI
// Формирование массива значений отображаемой функции

void make_fun(int N)
{	
	double x, dx=7.*M_PI/N;
	int i;
	for (i=0, x=M_PI/2.; i<N; i++, x+=dx)
	{
		R[i]=(float)(pow(sin(x),2)-pow(cos(x),2));  // сама функция
		if(Rmax<R[i]) Rmax=R[i];
    }
}

// Программа вывода графика функции на экран

void main(void)
{
	int i, N;
	clrscr();                         // Очистка экрана
	gotoxy(20,5);
	cprintf("Программа вывода графика функции на экран");
	gotoxy(13,10);
	cprintf("Для перехода в графический режим нажмите любую клавишу");
	getch();                        // Ожидаем нажатия клавиши...
	detectgraph(&GrDr,&GrM);        // Открыли графичесий режим
	initgraph(&GrDr,&GrM,GrP);
	if (graphresult()<0)
	{	
		gotoxy(18,13);
		cprintf("\nОШИБКА! НЕ МОГУ ОТКРЫТЬ ГРАФИЧЕСКИЙ РЕЖИМ...\n");
		getch(); 
		return;
	}
	else
	{
		Xmax=getmaxx(); 
		Ymax=getmaxy(); // Установили размеры экрана
		X0=40;          
		Y0=Ymax-200;     // Левый нижний угол графика
		X1=Xmax-200;     
		Y1=200;          // Правый верхний угол графика
		N = X1-X0;      // Количество точек по оси X
		char Ox[14][6] = {" ", "Pi", " ", "2Pi", " ", "3Pi", " ", "4Pi", " ", "5Pi", " ", "6Pi", " ", "7Pi"};
		setlinestyle(0,1,3);            // параметры линий
		int textLen = textwidth("f(x)=sin^2(x)-cos^2(x) on Pi/2 to 7Pi");
		outtextxy((Xmax/2)-(textLen/2), 30, "f(x)=sin^2(x)-cos^2(x) на отрезке от Pi/2 до 7Pi");
		make_fun(N);                    // Вычислили значения функции
		for (i=0;i<N;i++)                // Нормируем все значения функции
			RN[i]=Y0-(int)(R[i]/Rmax*(float)(Y0-Y1));
		setlinestyle(0,1,1);            // Рисуем координатные оси
		line(X0, Y0+85, X0, Y1);
		line(X0, Y0, X1+2, Y0);
		outtextxy(X0+5,Y1,"f(x)");    // Помечаем оси
		outtextxy(X1+3,Y0+1,"x");
		outtextxy(X0-10, Y0-10, "0");
		outtextxy(X0-10, Y1, "1");
		outtextxy(X0-17, Y1+155, "-1");
		
  		for (i=1; i<14; i++)	//Рисуем метки и подписи на оси Х
		{
			if(i%4==0 || i%6==0 || i%9==0 || i%11==0 || i%13==0)
			{
				line(X0+(int)(N/14)*i+4, Y0-3, X0+(int)(N/14)*i+4, Y0+3); //Метки
				outtextxy(X0+(int)(N/14)*i-15, Y0+5, Ox[i]); 	//Подписи
			}
			else
			{
				line(X0+(int)(N/14)*i, Y0-3, X0+(int)(N/14)*i, Y0+3); //Метки
				outtextxy(X0+(int)(N/14)*i-10, Y0+5, Ox[i]); 	//Подписи
			}
		};
		
		for (i=0;i<N;i++)  
		{
			// Рисуем график функции
			putpixel(i+X0,RN[i],12);
			delay(20);
		}
		
		window(10, 12, 70, 23);
		outtextxy (200, 50, "Максимальное значение функции 1");
		getch();                        // Ожидаем нажатия клавиши...
		closegraph();                   // Закрываем графичесий режим
	}
	getch();
	getch();  
	system("pause");
	getch();  
}
