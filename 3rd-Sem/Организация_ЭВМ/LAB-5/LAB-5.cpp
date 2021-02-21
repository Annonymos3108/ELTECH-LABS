// Аппаратное прерывание от таймера, генерация сигнала SOS  // звука в 700 Гц с интервалом в 1 сек.
#include <dos.h> 
#include <stdio.h>
#include <conio.h>
#include <bios.h>

unsigned long far *count =  (unsigned long far*) MK_FP(0x0040, 0x006c); // тут храниться время

void interrupt mybeep(...) // моё прерывание
{
	static char a = 0;
	if (*count % 18L == 0)
	{
		switch(a)
		{
			case 0:
			case 1:
			case 2:
			case 6:
			case 7:
			case 8:
			{
				sound(700);
				delay(500);
				nosound();
				delay(180);
				a++;
				if( a == 9) a = 0;
				break;
			}
			case 3:
			case 4:
			case 5:
			{
				sound(700);
				delay(1000);
				nosound();
				delay(180);
				a++;
				break;
			}
			default:
				break;
		}
	}
	return;
}

 
int main(void)
 {
    clrscr();
    void interrupt (*oldvect)(...);  // переменная
    oldvect = getvect(0x1c); // получаем значение вектора прерываний
    setvect(0x1c, mybeep);  // создаем свое прерывание
    printf("Для выхода из тишины, нажмите любую клавишу...\n"); 
    getch();
    setvect(0x1c, oldvect);  // восстанавливаем значения
    return 0;
 }