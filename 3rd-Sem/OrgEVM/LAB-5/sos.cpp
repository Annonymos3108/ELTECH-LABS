// �����⭮� ���뢠��� �� ⠩���, ������� ᨣ���� SOS  // ��㪠 � 700 �� ����� 2 ᥪ㭤� � � ᥪ㤭� ᮮ�,.
#include <dos.h> 
#include <stdio.h>
#include <conio.h>
#include <bios.h>
 
unsigned long far *count =  (unsigned long far*) MK_FP(0x0040, 0x006c); // ��� �࠭����� �६�
 
void interrupt mybeep(...) // ��� ���뢠���
{
    for(unsigned int k = 0; k <= sizeof(unsigned int); k++) {
		if (k % 2 == 0) { // ��� ����樨 ���⪨� 1 ᥪ
			if (*count % 18L == 0) // ��६ ������ ᥪ㭤� 9
			{
				for(unsigned int i = 0; i <= 3; i++) {
					sound(700);  // 700 �� ����
					delay(70);
					nosound(); 
					
					/*
					if (*count % 9L == 0) {  //delay(1000)  ��६ ������ ᥪ㭤�    // 9 - is 1 sec
						nosound(); 
					}*/
				}
			}
		}
	
		if(k % 2 == 1) { //� ����� ����樨 ������ 2 ᥪ
			if (*count % 36L == 0) // ��६ ������ 2 ᥪ㭤� 9*2
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
    oldvect = getvect(0x1c); // ����砥� ���祭�� ����� ���뢠���
    setvect(0x1c, mybeep);  // ᮧ���� ᢮� ���뢠���
    printf("��� ��室� �� �設�, ������ ���� �������...\n"); 
    getch();
    setvect(0x1c, oldvect);  // ����⠭�������� ���祭��
    return 0;
 }