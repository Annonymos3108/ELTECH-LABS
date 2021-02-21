#include <iostream>
#include <fstream> // для работы с файламис
#include <stdlib.h>
#include <string>
#include <vector>
#include <iterator>
#include <cstdlib>
#include <clocale> //  для setlocale

using namespace std;

#pragma pack(push, 1)

typedef struct
{
   unsigned char   BLUE;
   unsigned char   GREEN;
   unsigned char   RED;
}RGB;

typedef struct
{
    unsigned char   b1,b2;
    unsigned long   bfSize;
    unsigned short  bfReserved1;
    unsigned short  bfReserved2;
    unsigned long   bfOffBits;

    unsigned int    biSize;
    int             biWidth;
    int             biHeight;
    unsigned short  biPlanes;
    unsigned short  biBitCount;
    unsigned int    biCompression;
    unsigned int    biSizeImage;
    int             biXPelsPerMeter;
    int             biYPelsPerMeter;
    unsigned int    biClrUsed;
    unsigned int    biClrImportant;
}BITMAPFILEHEADER;
#pragma pack(pop)

bool cesar(string &line, string Optional_Alphabet, int key)
{
	setlocale(LC_ALL,"Russian");
	for (int i = 0; i < line.size(); i++)
	{
		if (line[i] == ' ') continue;
		int alphabet = Optional_Alphabet.find(line[i]);
		if (alphabet < 0)
		{
			return false;
		}
		else{
			if (abs(key) > Optional_Alphabet.size()) key = key % Optional_Alphabet.size();
			int index = (alphabet + key + Optional_Alphabet.size()) % Optional_Alphabet.size();
			line[i] = Optional_Alphabet[index];
		}
	}
	return true;
}

void file(string Optional_Alphabet, int key, string source, string dest)
{
	setlocale(LC_ALL,"Russian");
	string line;
	vector<string> ::iterator it;
	vector <string> text;

	bool gd_alpgabet = true;
	ifstream fin(source.c_str()); // файл для чтения
	if (!fin.is_open()) // открывается ли файл
		cout << source <<" файл не найден " << endl;
	else{
		while (!fin.eof()) // файл открылся
		{ 
			getline(fin, line); // считываем первую строку файла
			if (cesar(line, Optional_Alphabet, key)) // шифрование строки
				text.push_back(line); // занесение зашифрованного строки в вектор
			else {
				gd_alpgabet = false;
				break;
			}
		}
	}
	fin.close(); // закрываем текстовой файл
	if (gd_alpgabet)
	{
		ofstream fout(dest.c_str()); // файл для записи
		for (it = text.begin(); it < text.end(); it++) // запись вектора в файл
			fout << *it << endl;
		fout.close();
	}
}

void copy_to_memory(void* dest, void* src, size_t size)
{
    for(int i = 0; i < size; i++)
    {
        *((unsigned char*)dest + i) = *((unsigned char*)src + i);
    }
}

// запись текста в файл BMP
void encoding(string textfilepath, string bmpfilepath)
{
  setlocale(LC_ALL,"Russian");
  fstream bmpfile;
  bmpfile.open(bmpfilepath.c_str(), ios::binary | ios::in); // открываем bmp файл в бинарном режиме
  if (bmpfile.fail()) // если не открывается выводим ошибку
   {
     cout << "ошибка! bmp файл не открывается! " << endl;
     exit(0);
    }
  bmpfile.seekg(0, ios::end); // определение размера bmp файла
  size_t bmpfileSize = bmpfile.tellg();
  bmpfile.seekg(0, ios::beg); //
  unsigned char *sizeOfBmpFile = new unsigned char[bmpfileSize]; // записывам данные в указатель
  bmpfile.read((char*)sizeOfBmpFile, bmpfileSize);
  bmpfile.close(); // закрываем bmp файл
  fstream textfile;
  textfile.open(textfilepath.c_str(), ios::binary | ios::in); // открываем текстовой файл в бинарном режиме
  if (textfile.fail())
   {
     cout << "ошибка! текстовой файл не открывается" << endl;
     exit(0);
    }
  textfile.seekg(0, ios::end); /// определяем размер текстового файла
  unsigned short textfileSize = textfile.tellg();
  textfile.seekg(0, ios::beg); 
  unsigned char *sizeOfTextFile = new unsigned char[textfileSize + 2];// записывам данные в указатель
  textfile.read((char*)sizeOfTextFile + 2, textfileSize);
  textfile.close(); // закрываем

  BITMAPFILEHEADER *bmpHeader = (BITMAPFILEHEADER*)sizeOfBmpFile;
  int M = bmpHeader->biHeight;
  int N = bmpHeader->biWidth;

  if (textfileSize + 2 >M*N)  // проверим размер текста, для дальнейших действий
    {
	 cout << "текст слишком большой, возмите текст покороче или изображение побольше" << endl;
	 exit(0);
    }

  RGB *currentLine = (RGB*)(sizeOfBmpFile + bmpHeader->bfOffBits);
  int LineSize = 3 * N + (4 - ((3 * N) % 4)) % 4; // размер строки с выравниванием 4

  unsigned short* sSize = &textfileSize;

  // ввод текста в картинку
  copy_to_memory(sizeOfTextFile, sSize, 2);

  zxcv:
  for (int i=0;i<M;i++)
   {
	 for (int j=0;j<N;j++)
	   {
		 if(i * N + j == textfileSize + 2)
		   {
			 bmpfile.open(bmpfilepath.c_str(), ios::binary | ios::out | ios::trunc);
			 bmpfile.write((char*)sizeOfBmpFile,bmpfileSize);
			 bmpfile.close();
			 return;
		    }
		 currentLine[j].RED = currentLine[j].RED >> 2; //обнуляем
		 currentLine[j].RED = currentLine[j].RED << 2;

		 currentLine[j].GREEN = currentLine[j].GREEN >> 3; //обнуляем
         currentLine[j].GREEN = currentLine[j].GREEN << 3;

         currentLine[j].BLUE = currentLine[j].BLUE >> 3; //обнуляем
         currentLine[j].BLUE = currentLine[j].BLUE << 3;

         currentLine[j].RED |= sizeOfTextFile[i*N+j] & 3; // записываем символы текста в красный канал
         currentLine[j].GREEN |= (sizeOfTextFile[i*N+j] & 28)>>2; // записываем символы текста в зелений канал
         currentLine[j].BLUE|= (sizeOfTextFile[i*N+j] & 224)>>5; // записываем символы текста в синий канал
        }
     currentLine=(RGB*)((unsigned char*)currentLine+LineSize);
    }
}

// расшифровывание,а точнее - считывание скрытово текста из картинки
void decoding(string textfilepath, string bmpfilepath)
{
	setlocale(LC_ALL,"Russian");
 	fstream bmpfile;
    bmpfile.open(bmpfilepath.c_str(), ios::binary | ios::in); //открываем bmp файл в бинарном режиме
    if (bmpfile.fail()) // если не открывается
    {
      cout << "ошибка! bmp файл не открывается!" <<  endl; // выводим ошибку
      exit(0);
    }
    bmpfile.seekg(0, ios::end); // определение размера bmp
    size_t bmpfileSize = bmpfile.tellg();
    bmpfile.seekg(0, ios::beg); //
    unsigned char *sizeOfBmpFile = new unsigned char[bmpfileSize]; // запись файла в указатель
    bmpfile.read((char*)sizeOfBmpFile, bmpfileSize);
    bmpfile.close(); // закрываем файл
    fstream textfile;
    textfile.open(textfilepath.c_str(), ios::binary | ios::trunc | ios::out); // открываем текстовой файл в бинарном режиме
    if (textfile.fail())
     {
     cout << "ошибка! текстовой файл не открывается" << endl;
     exit(0);
    }
    BITMAPFILEHEADER *bmpHeader = (BITMAPFILEHEADER*)sizeOfBmpFile;
    int M = bmpHeader->biHeight;
    int N = bmpHeader->biWidth;
    RGB *currentLine = (RGB*)(sizeOfBmpFile + bmpHeader->bfOffBits);
    int LineSize = 3 * N + (4 - ((3 * N) % 4)) % 4; // размер строки с выравние=ванием до 4-х

    unsigned short SizeSize = 0;
    unsigned char* Size_Size = (unsigned char*)&SizeSize;

    for (int i=0;i<M;i++)
    {
	  for (int j=0;j<N;j++)
	   {
		 if(i * N + j == 2)
		   {
			 goto emergencyOUT;
		   }
		 Size_Size[i*N+j] |=  (currentLine[j].RED & 3);  // переносим в файл
         Size_Size[i*N+j] |=  (currentLine[j].GREEN & 7)<<2;
         Size_Size[i*N+j] |=  (currentLine[j].BLUE & 7)<<5;
        }
      currentLine=(RGB*)((unsigned char*)currentLine+LineSize); //переход на след. строку
    }

    emergencyOUT:
    currentLine = (RGB*)(sizeOfBmpFile + bmpHeader->bfOffBits);
    char *TEXTTXT = new char[SizeSize + 2];
    for(int i = 0; i < SizeSize + 2 ; i++)
       {
         TEXTTXT[i] = '\0';
        }
    for (int i=0;i<M;i++)
       {
	      for (int j=0;j<N;j++)
	        {
		      if(i * N + j == SizeSize + 2)
		        {
			      bmpfile.open(textfilepath.c_str(), ios::binary | ios::out | ios::trunc); // открываем bmp в бинарном режиме
			      bmpfile.write(TEXTTXT + 2,SizeSize); // записываем данные в файл
			      bmpfile.close(); // закрываем файл
			      return;
		        }
              TEXTTXT[i*N+j] |=  currentLine[j].RED & 3; // запись текста
              TEXTTXT[i*N+j] |=  (currentLine[j].GREEN & 7)<<2 ;
              TEXTTXT[i*N+j] |=  (currentLine[j].BLUE & 7)<<5;
            }
            currentLine=(RGB*)((unsigned char*)currentLine+LineSize); // перход на след. строку
        }
}

// основная функция для передачи параметров в программу
int main(int argc, char* argv[])
{
	setlocale(LC_ALL,"Russian");
	string OptType = "encode", textfile , bmpfile , source; // параметры
	string Optional_Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
	int key = 0;
	if (argc<3) 
	    {
		  cout <<"ошибка, не заданы параметры или заданы неправильно" << endl;
		  exit(1);
	    }

    textfile = argv[1];
    OptType  = argv[2];
    bmpfile  = argv[3];
    key      = atoi(argv[4]);
    source   = string(textfile);
    if (OptType=="encode") 
       {
	     file(Optional_Alphabet, key, source, source );
	     encoding(textfile,  bmpfile);
        }
    if (OptType=="decode") 
        {
          decoding(textfile,bmpfile);
          key=-key;
	      file(Optional_Alphabet, key, source , source);
        }
    return 0;
}
