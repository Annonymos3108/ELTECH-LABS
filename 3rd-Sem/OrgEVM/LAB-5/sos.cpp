// Аппаратное прерывание от таймера, генерация сигнала SOS  // звука в 700 Гц каждые 2 секунды и в секудну соотв,.
#include <dos.h> 
#include <stdio.h>
#include <conio.h>
#include <bios.h>
 
unsigned long far *count =  (unsigned long far*) MK_FP(0x0040, 0x006c); // тут храниться время
 
void interrupt mybeep(...) // моё прерывание
{
    for(unsigned int k = 0; k <= sizeof(unsigned int); k++) {
		if (k % 2 == 0) { // четные интерации короткие 1 сек
			if (*count % 18L == 0) // берем каждую секунду 9
			{
				for(unsigned int i = 0; i <= 3; i++) {
					sound(700);  // 700 это Герц
					delay(70);
					nosound(); 
					
					/*
					if (*count % 9L == 0) {  //delay(1000)  берем каждую секунду    // 9 - is 1 sec
						nosound(); 
					}*/
				}
			}
		}
	
		if(k % 2 == 1) { //и нечетные интерации длинные 2 сек
			if (*count % 36L == 0) // берем каждую 2 секунду 9*2
			{
				for(unsigned int i = 0; i < 3; i++) {
					sound(700);
					delay(210);
					nosound(); 
				}
			}
		
		}
	}
}
 
int main(void)
 {
    clrscr();
    void interrupt (*oldvect)(...);
    oldvect = getvect(0x1c); // получаем значение вектора прерываний
    setvect(0x1c, mybeep);  // создаем свое прерывание
    printf("Для выхода из тишины, нажмите любую клавишу...\n"); 
    getch();
    setvect(0x1c, oldvect);  // восстанавливаем значения
    return 0;
 }