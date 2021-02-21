#pragma warning(disable: 4996) // для  чтобы не заебал warning C4996 о проблемах этих двоих -- 'getch', 'itoa'
#include <iostream> // для setlocale(), std::cin ,std::cout, std::endl, _getwch()
#include <windows.h> // для SetConsoleCP(1251), SetConsoleOutputCP(1251), SetConsoleCursorPosition(), Sleep(), TRUE, FALSE;

void gotoxy(int x, int y);

union type
{
	unsigned long long ll;
	long double d;
};

void printLongDouble(long double x)
{
	//std::cout << std::endl;
//gotoxy(20, 10);
	type m;
	m.d = x;
	int k = 0;
	for (int i = 8 * sizeof(m.ll) - 1; i > -1; i--)
	{
		printf("%d", m.ll >> i & 1);
		k++;
		if (k == 23)
		{
			std::cout << std::endl;
			gotoxy(20, 10);
		}
	}
	printf("\n");
}

void printChar(char input)
{
	std::cout << std::endl;
	gotoxy(20, 11);
	unsigned int bit;
	for (int i = 0; i < 8; i++)
	{
		bit = ((input >> (8 - i - 1)) & 1);
		std::cout << bit;
	}
	printf("\n");
}
// Установка курсора в координаты X,Y
void gotoxy(int x, int y)
{
	COORD point;
	point.X = x;
	point.Y = y;
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), point);
}

// Устанавливает цвет текста и фона в консоли
void SetColorOutput(int text, int background, bool console)
{
	if (console)
	{
		char color[] = "color 00";
		itoa(background, color + 6, 16);
		itoa(text, color + 7, 16);
		system(color);
	}
	else
	{
		HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
		SetConsoleTextAttribute(hStdOut, (WORD)((background << 4) | text));
	}
}

// Прокрутка буффера экрана
void GetScroll(unsigned int sx, unsigned int sy, unsigned int sxx, unsigned int syy, int dx, int dy)
{
	HANDLE hStdout = GetStdHandle(STD_OUTPUT_HANDLE); // Установка дескрпитора  экранного буффера
	CONSOLE_SCREEN_BUFFER_INFO csbiInfo; // Информация о буффере экрана
	GetConsoleScreenBufferInfo(hStdout, &csbiInfo);
	SMALL_RECT srctScrollRect; // Область 	перемещаемая
	if (sx != NULL)
		srctScrollRect.Left = sx;
	else
		srctScrollRect.Left = 0;
	if (sxx != NULL)
		srctScrollRect.Right = sxx;
	else
		srctScrollRect.Right = csbiInfo.dwSize.X;
	if (sy != NULL)
		srctScrollRect.Top = sy;
	else
		srctScrollRect.Top = 0;
	if (syy != NULL)
		srctScrollRect.Bottom = syy;
	else
		srctScrollRect.Bottom = csbiInfo.dwSize.Y;
	COORD coordDest; // Координаты перемещения
	coordDest.X = 0 + dx;
	coordDest.Y = 0 + dy;
	SMALL_RECT srctClipRect; // Область отсечения (для неизменности результата равна области перемещаемой)
	srctClipRect = srctScrollRect;
	CHAR_INFO chiFill; // Символ-заполнитель для области вне перемещаемой области
	chiFill.Attributes = 0 | 0;
	chiFill.Char.UnicodeChar = '*';
	ScrollConsoleScreenBuffer(hStdout, &srctScrollRect, &srctClipRect, coordDest, &chiFill); // Прокрутка
}

// Перечисление цветов для консольного вывода
enum ConsoleColor
{
	Black = 0,
	Blue = 1,
	Green = 2,
	Cyan = 3,
	Red = 4,
	Magenta = 5,
	Brown = 6,
	LightGray = 7,
	DarkGray = 8,
	LightBlue = 9,
	LightGreen = 10,
	LightCyan = 11,
	LightRed = 12,
	LightMagenta = 13,
	Yellow = 14,
	White = 15
};

// Функция вывода на экран номера цвета фона и название цвета текста
void GetPrintColor(int text, int background, long double info, char inform, bool charOrNot)
{
	switch (background)
	{
	case Black:			std::cout << "1 ";   break;
	case Blue:			std::cout << "2 ";   break;
	case Green:			std::cout << "3 ";   break;
	case Cyan:			std::cout << "4 ";   break;
	case Red:			std::cout << "5 ";   break;
	case Magenta:		std::cout << "6 ";   break;
	case Brown:			std::cout << "7 ";   break;
	case LightGray:		std::cout << "8 ";   break;
	case DarkGray:		std::cout << "9 ";   break;
	case LightBlue:		std::cout << "10 ";  break;
	case LightGreen:	std::cout << "11 ";  break;
	case LightCyan:		std::cout << "12 ";  break;
	case LightRed:		std::cout << "13 ";  break;
	case LightMagenta:	std::cout << "14 ";  break;
	case Yellow:		std::cout << "15 ";  break;
	case White:			std::cout << "16 ";  break;
	}
	switch (text)
	{
	case Black:
		std::cout << "Черный          ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case Blue:
		std::cout << "Синий           ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case Green:
		std::cout << "Зеленый         ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case Cyan:
		std::cout << "Циановый        ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case Red:
		std::cout << "Красный         ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case Magenta:
		std::cout << "Пурпурный       ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case Brown:
		std::cout << "Коричневый      ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case LightGray:
		std::cout << "Светло-серый    ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case DarkGray:
		std::cout << "Темно-серый     ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case LightBlue:
		std::cout << "Светло-голубой  ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case LightGreen:
		std::cout << "Светло-зеленый  ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case LightCyan:
		std::cout << "Светло-циановый ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case LightRed:
		std::cout << "Светло-красный  ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case LightMagenta:
		std::cout << "Светло-пурный   ";  // Светло-пурпурный - место в консоли не хватает, пусть будет так
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case Yellow:
		std::cout << "Желтый          ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	case White:
		std::cout << "Белый           ";
		if (charOrNot == true) printChar(inform);
		else printLongDouble(info);
		break;
	}
}
int main()
{
	setlocale(LC_CTYPE, "rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	system("CLS");
	char inputChar;
	long double inputLongDouble;
	int m, t;
	do
	{
		t = 0;
		std::cout << "Выберите с каким типом вы хотите работать: 1 - long double; 2 - char\n";
		std::cin >> m;
		if (m == 1)
		{
			std::cout << "Введите данные:\n";
			std::cin >> inputLongDouble;
			if ((inputLongDouble > -9223372036854775808.0)& (inputLongDouble < 9223372036854775807.0))
			{
				system("CLS");
				for (int background = 0; background <= 15; background++)
				{
					for (int text = 0; text <= 15; text++)
					{
						gotoxy(20, 9);
						SetColorOutput(text, background, FALSE);
						GetPrintColor(text, background, inputLongDouble, 0, false);
						// GetScroll(Left, top,right,bottom, dx, dy Координаты перемещения)
						GetScroll(0, 1, 60, 20, 0, 3);
						Sleep(1500); // ШАГ Т (время в милисекундах) 1500 - мой вариант
					}
					SetColorOutput(15, 0, FALSE);
				}
				gotoxy(0, 0);
				system("PAUSE");
			}
			else
			{
				std::cout << "\nОшибка!!!\n";
			}
		}
		else if (m == 2)
		{
			std::cout << "Введите данные:\n";
			std::cin >> inputChar;
			if ((inputChar > -128)& (inputChar < 127))
			{

				system("CLS");
				for (int background = 0; background <= 15; background++)
				{
					for (int text = 0; text <= 15; text++)
					{
						gotoxy(20, 10);
						SetColorOutput(text, background, FALSE);
						GetPrintColor(text, background, 0, inputChar, true);
						GetScroll(0, 1, 60, 21, 0, 3);
						/*
						1st is
						2nd is ширина между строк
						3th is длина строки
						4th is размер прокручаемого окна относительно начального х у
						5th is отклонение по наклонной
						6th is ширина между строк
						*/
						Sleep(1500); // ШАГ Т (время в милисекундах)
					}
					SetColorOutput(15, 0, FALSE);
				}
				gotoxy(0, 0);
				system("PAUSE");
			}
			else
			{
				std::cout << "\nОшибка!!!\n";
			}
		}
		else
		{
			std::cout << "\nОшибка!!!\n";
		}
		std::cin.get();
		std::cout << "Хотите продолжить? да - 1; нет - 0\n";
		std::cin >> t;
		system("cls");
	} while (t != 0);
	return 0;
}