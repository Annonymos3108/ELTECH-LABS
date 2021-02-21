#include <iostream>
#include <cstdlib>  // для функции atoi
#include <fstream>  // для чтения и записи файлов
#include <clocale>
#include <cstring>
#include <string>

using namespace std;


// проверим является ли аргумент ключом...
bool isNumber(const char* str)
 {
	bool delta = true;
	for (int i = 0; i < strlen(str); i++) {
		if (isdigit(str[i]) || (str[0] == '-' && strlen(str) != 1)) //является ли цифрой...
			delta = true;
		else
			delta = false;
		break;
	}
	return delta;    // если да, возвращаем ключ к программе...
}



int main(int argc, char *argv[])
{
	bool is_Key = false;
	bool source_0r_dest = false;
	bool encode = true;
	bool decode = false;
	int key;
	setlocale(LC_ALL, "Russian"); // подкючаем эту штуку для отображения русского языка в коммандной строке...
	string alphabet = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789"; // сам алфавит...
	string source; // объявляем переменные для хранения исходного и конечного файла...
	string dest;
	string buffer; // а также буффер для временного хранения информации.....

	for (int i = 1; i < argc; i++)
    { // цыкл, чтобы определить какой аргумент каким параметро является... // определения алфавита и т.п.
		if (strcmp(argv[i], "-a") == 0 && i != argc - 1)
		 {
			if (strcmp(argv[i + 1], "-t") != 0 || strcmp(argv[i + 1], "--type=decode") != 0 || strcmp(argv[i + 1], "--type=encode") != 0 || strcmp(argv[i + 1], "-h") != 0 || strcmp(argv[i + 1], "--help") != 0)
				alphabet = argv[i + 1];
			else {
				cout << "Неверно заданы параметры";
				
				return 0;
			}
		}
		if (strncmp(argv[i], "--alphabet=", 11) == 0) // является ли аргумент алфавитом?
		 {
			alphabet = "";
			for (int j = 11; j < strlen(argv[i]); j++) {
				alphabet += argv[i][j];
			}
		}
		if (strcmp(argv[i], "--type=decode") == 0) // определяем тим операции (encode, decode)
		{ 
			encode = false;
			decode = true;
		}
		if (strcmp(argv[i], "--type=encode") == 0) // то же самое....
		 {
			encode = true;
			decode = false;
		}
		if (strcmp(argv[i], "-t") == 0 && i != argc - 1)
		 {
			if (strcmp(argv[i + 1], "decode") == 0) {
				encode = false;
				decode = true;
			}
			else if (strcmp(argv[i + 1], "encode") == 0) {
				decode = false;
				encode = true;
			}
			else
			 {
				cout << "Неверно заданы параметры";
				
				return 0;
			}
		}
      
		if (strcmp(argv[i], "-h") == 0 || strcmp(argv[i], "--help") == 0)
		 {
			cout << "$ crypt [options] <key> <source> [<dest>]" << endl;
			cout << "\t options:" << endl;
			cout << "-a, --alphabet = <alphabet>  alphabet— алфавит для работы алгоритма (по умолчанию" << endl;
			cout << " содержит буквы из латниского алфавита и цифры: AaBbCc..Zz0..9)" << endl;
			cout << "-t, --type = <type> type может быть 'encode' или 'decode', по умолчанию — encode" << endl;
			cout << "- h, --help выводит эту справку" << endl;
			cout << "\t key:" << endl;
			cout << "ключ для шифрования/дешифрования" << endl;
			cout << "\t source:" << endl;
			cout << "исходный файл для шифрования/дешифрования" << endl;
			cout << "\t dest:" << endl;
			cout << "файл, куда будет записан новый, зашифрованный текст. Если не указан, то переписывает source" << endl;
			
			return 0;
		}
		if (isNumber(argv[i]) == true && strcmp(argv[i-1], "-a") != 0) // проверим параметры ключа... 
		 {
				if (atoi(argv[i]) < 0) // сравниваем, ... 
					// чтобы это было возможным, нужно переобразовать строку string в целое значение типа int
					// для этого используем функцию atoi
					// для функции atoi нужно подключить cstdlib
				 {
					cout << "Ошибка: Отрицательный Ключ !";
					return 0;
				}
				if (atoi(argv[i]) > 0)
				 {
					key = atoi(argv[i]);
				}
		}
		if (argv[i][strlen(argv[i]) - 1] == 't' && argv[i][strlen(argv[i]) - 2] == 'x' && argv[i][strlen(argv[i]) - 3] == 't' && argv[i][strlen(argv[i]) - 4] == '.')
		 {
			if (!source_0r_dest)  // определим какой из аргументов source файл, какой из них dest
			 {
				source_0r_dest = true;
				source = argv[i];
				dest = argv[i];
			}
			else {
				dest = argv[i];

			}
		}
	}

	ifstream fin(source.c_str());
	string k;
	if (!fin.good()) // открывается ли файл.
	{
		cout << "no such file";
		return 0;
	}

	string Mr_Been;
	while (!fin.eof())
	 { // и собственно шифрование
		getline(fin, Mr_Been);
		int Mrs_Been = Mr_Been.rfind('\r');
		Mr_Been = Mr_Been.substr(0, (Mrs_Been < 0) ? Mr_Been.length() : Mrs_Been);
		buffer = Mr_Been;
		for (int i = 0; i < buffer.length(); i++) 
		{
			for (int j = 0; j < alphabet.length(); j++) 
			{
				if (encode == true && buffer[i] == alphabet[j]) 
				{
					buffer[i] = alphabet[(j + key) % alphabet.length()];
					break;
				}
				else if (decode == true && buffer[i] == alphabet[j])
				 {
					buffer[i] = alphabet[(j - key + alphabet.length()) % alphabet.length()];
					break;
				}
			}
		}
		k += buffer + "\n";
	}
	ofstream fout(dest.c_str());
	if (!fout.good()) {
		cout << "no such file ";
		return 0;
	}
	// закрываем файлы и программу...
	fout << k;  
	fin.close();
	fout.close();
	cout << "Answer: " << endl << k; // выводим ответ в консось и ключь шифрования/дешифрования...
	cout << "Key:" << key << " ";
	return 0;
}