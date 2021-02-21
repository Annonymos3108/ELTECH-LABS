//  ࠡ�� � �������⥬�� � ����᪮� ०���
#include "conio.h"  // clrscr
#include "math.h"  // M_PI, sin, cos, sqrt, pow
#include "dos.h"    // delay
#include "graphics.h" // graph
#include "iostream.h"	// printf, scanf3

	

int Xmax, Ymax, X0, X1, Y0, Y1, DRIVER, MODE, NomedDots[1000];

float Result[1000], Rmax=0.;


// ��ନ஢���� ���ᨢ� ���祭�� �⮡ࠦ����� �㭪樨

void counting(int N)
{	
	float x, dx=17.*M_PI/N;
	int i;
	for (i=0, x=3*M_PI/2.; i<N; i++, x+=dx)
	{
		Result[i]=(float)(pow(sin(x/4),2)+sqrt(x));  // ᠬ� �㭪��
		if(Rmax<Result[i]) {
			Rmax=Result[i];
		}
    }
}


void main()
{
	int N;
	clrscr();                         // ���⪠ �࠭�
	detectgraph(&DRIVER,&MODE);        // ���뫨 ����ᨩ ०��
	/* 	�� ⠪�� detectgraph(&DRIVER,&MODE);
		detectgraph	��� ��।������ ⨯� �����������, ���室�饣� ����᪮�� �ࠩ��� 
		� ����᪮�� ०��� ���ᨬ��쭮�� ࠧ�襭�� (���ᨬ��쭮�� ०���)
		��� ��⨢���� ����������� ��⥬�. ���祭�� ��� �ࠩ��� � 
		���ᨬ��쭮�� ०��� ���������� � �祩��� �����, �� �����
		㪠�뢠�� DRIVER � MODE	
		
	*/
	initgraph(&DRIVER,&MODE,"..//BORLANDC//BGI");  // ��ᯮ������� �ࠩ��஢ BGI
	/*
	initgraph ���樠������� ������� ��⥬�, ����㦠� .BGI-�ࠩ���, 
	��।��塞� 㪠��⥫�� DRIVER, � ��⠭������� ����������� 
	� ����᪨� ०��, ��������� 㪠��⥫�� MODE
	*/
	
	Xmax=getmaxx(); 
	Ymax=getmaxy(); // ��⠭����� ࠧ���� �࠭�
	X0=40;          Y0=Ymax-30;     // ���� ������ 㣮� ��䨪�
	X1=Xmax-30;     Y1=30;          // �ࠢ� ���孨� 㣮� ��䨪�  
	N = X1-X0;      // ������⢮ �祪 �� �� X
	
	
	char Ox[9][6] = {"3Pi/2", "3Pi", "5Pi", "7Pi", "9Pi", "11Pi", "13Pi", "15Pi", "17Pi"};
	setlinestyle(0,1,1); 
	//setlinestyle(0,1,3);            // ��ࠬ���� �����
	
	outtextxy(200, 400, "f(x)=sin^2(x/4)+sqrt(x) on 3*P/2 to 17P");
	counting(N);                    // ���᫨�� ���祭�� �㭪樨
	
	
	for (int i=0;i<N;i++) {          // ��ନ�㥬 �� ���祭�� �㭪樨
		NomedDots[i]=Y0-(int)(Result[i]/Rmax*(float)(Y0-Y1));
	}
	
	setlinestyle(0,1,2);
	//setlinestyle(0,1,1);            // ���㥬 ���न���� ��
	line(X0, Y0, X0, Y1-20);      	// y
	line(X0, Y0, X1+2, Y0);			// x 
	
	
	outtextxy(X0+5,Y1-20,"f(x)");    // ����砥� ��
	outtextxy(X1+3,Y0-10,"x");
	outtextxy(X0-10, Y0-10, "0");
	outtextxy(X0-10, Y1-20, "1");
		
	for (int j=0; j<10; j++)	//���㥬 ��⪨ � ������ �� �� �
	{
		line(X0+(int)(N/8)*j+4, Y0-3, X0+(int)(N/8)*j+4, Y0+3); //��⪨
		outtextxy(X0+(int)(N/8)*j-15, Y0+5, Ox[j]); 	//������
	};
	
	// �� ⢮����� � ��ப� ��⪨? X0+(int)(N/8)*i -- ��६ ��砫� ���न��� � � ���� ����㥬 ����� ���न��� � 
	// ࠧ�������� �� 8 ��⥩ (��⮬� �� ��⮪ 8) 㬭����� �� ����� (����� ࠧ ஢�� �� ���� � � 
	// �� ��१�� ��������� ���।) �.� i = 1,2,3,....9 // � (int) - �� ���㣫塞 �᫮ ���ᥫ�� �� 楫���
	// �� �� ����祬 ���न���� �� �, � �� � ��﫨 �஢��� � � +-3 ���ᥫ� ����� � ����
	// � �⮣� � ��� ��� ���� ���न��� (�,�) �� ����� ��⨬ �����
	// � ⠪ 9 ࠧ (��稭��� � 1, ��⮬� �� 0 - �� ��� �, �� �� ⮣� �� ��稭��� � 1, �����稢��� �� 10 � �� 9;
	
	// � ��ப� ������
	// ��६ �� �� ����� (����� ������� ��१��), ���� ���⭮ 15 ���ᥫ�� �� �, ��᪥��� ���� �� 5 ���ᥫ�� �� �
	// � ��⠢�塞 ��।��� ������� �� ���ᨢ� Ox //"3Pi/2",....,"17Pi" //
	
		
	// ���㥬 ��䨪 �㭪樨
	for (int k=0; k<N; k++)  
	{
		putpixel(k+X0,NomedDots[k],14);  // 12 - �� �E� ����� ��䨪�
		delay(20);
	}
	
	outtextxy (200, 50, "Maximum of F(x) is 0.92");
	getch();                        // ������� ������ ������...
	closegraph();                   // ����뢠�� ����ᨩ ०��
	getch();  
}