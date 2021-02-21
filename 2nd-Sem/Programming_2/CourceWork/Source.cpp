#include <iostream>
#include <string>
#include <fstream>
#include <cmath>

using namespace std;

int decode(int key, string alphabet)
{
	fstream crypted_text_file_1;
	crypted_text_file_1.open("crypted_text.txt");
	if (crypted_text_file_1.fail()) {
		cout << "Error! File does not open!";
		return 1;
	};
	string buffer;
	getline(crypted_text_file_1, buffer, (char)crypted_text_file_1.eof());
	for (int i = 0; i < buffer.size(); i++) {
		for (int j = 0; j < alphabet.size(); j++) {
			if (buffer[i] == alphabet[j]) {
				buffer[i] = alphabet[(j + alphabet.size() - key % alphabet.size()) % alphabet.size()];
				break;
			};
		};
	};
	fstream decryptet_text_file;
	decryptet_text_file.open("decrypted_text.txt", ios::trunc | ios::out);
	if (decryptet_text_file.fail()) {
		cout << "Error! File does not open!";
		return 1;
	};
	decryptet_text_file.write(buffer.c_str(), buffer.size());
	crypted_text_file_1.close();
	decryptet_text_file.close();
	return 0;
}

int main()
{
	fstream crypted_text_file("crypted_text.txt", ios::binary | ios::in);
	if (!crypted_text_file)
	{
		printf("Error! File does not open!\n");
		return 1;
	}
	char ch;
	int i = 0, j = 0;
	long long characters[2][26] = { { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z' },{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 } };
	while (crypted_text_file.get(ch))
	{
		switch (ch)
		{
		case 'a':
			characters[1][0]++;
			break;
		case 'b':
			characters[1][1]++;
			break;
		case 'c':
			characters[1][2]++;
			break;
		case 'd':
			characters[1][3]++;
			break;
		case 'e':
			characters[1][4]++;
			break;
		case 'f':
			characters[1][5]++;
			break;
		case 'g':
			characters[1][6]++;
			break;
		case 'h':
			characters[1][7]++;
			break;
		case 'i':
			characters[1][8]++;
			break;
		case 'j':
			characters[1][9]++;
			break;
		case 'k':
			characters[1][10]++;
			break;
		case 'l':
			characters[1][11]++;
			break;
		case 'm':
			characters[1][12]++;
			break;
		case 'n':
			characters[1][13]++;
			break;
		case 'o':
			characters[1][14]++;
			break;
		case 'p':
			characters[1][15]++;
			break;
		case 'q':
			characters[1][16]++;
			break;
		case 'r':
			characters[1][17]++;
			break;
		case 's':
			characters[1][18]++;
			break;
		case 't':
			characters[1][19]++;
			break;
		case 'u':
			characters[1][20]++;
			break;
		case 'v':
			characters[1][21]++;
			break;
		case 'w':
			characters[1][22]++;
			break;
		case 'x':
			characters[1][23]++;
			break;
		case 'y':
			characters[1][24]++;
			break;
		case 'z':
			characters[1][25]++;
			break;
		default:
			break;
		}
	}

	long long buf, buf1;
	for (int j = 0; j < 26; j++)
	{
		for (int i = 0; i < 26 - 1; i++)
		{
			if (characters[1][i] < characters[1][i + 1])
			{
				buf = characters[1][i];
				characters[1][i] = characters[1][i + 1];
				characters[1][i + 1] = buf;
				if (buf)
				{
					buf1 = characters[0][i];
					characters[0][i] = characters[0][i + 1];
					characters[0][i + 1] = buf1;
				}
			}
		}
	}

	double symbol_sum = 0;
	for (int numb = 0; numb < 26; numb++) symbol_sum += characters[1][numb];
	double native_e = 12.702, native_t = 9.056, native_a = 8.167, native_o = 7.507;
	double analyzed_per1 = 0, analyzed_per2 = 0, analyzed_per3 = 0, analyzed_per4 = 0;
	analyzed_per1 = (characters[1][0] * 100) / symbol_sum;
	analyzed_per2 = (characters[1][1] * 100) / symbol_sum;
	analyzed_per3 = (characters[1][2] * 100) / symbol_sum;
	analyzed_per4 = (characters[1][3] * 100) / symbol_sum;
	float e_e = 0, t_t = 0, a_a = 0, o_o = 0;
	if (fabs(analyzed_per1 - native_e) < 0.600)
		e_e = analyzed_per1;
	if (fabs(analyzed_per2 - native_t) < 0.300)
		t_t = analyzed_per2;
	if (fabs(analyzed_per3 - native_a) < 0.150)
		a_a = analyzed_per3;
	if (fabs(analyzed_per4 - native_o) < 0.400)
		o_o = analyzed_per4;
	int cesar_key_0, cesar_key_1, cesar_key_2, cesar_key_3;
	string alphabet = "abcdefghijklmnopqrstuvwxyz";
	char e_ee, t_tt, a_aa, o_oo;
	if (e_e)
	{
		e_ee = characters[0][0];
		cesar_key_0 = (e_ee - 'e') % alphabet.length();
	}
	if (t_t)
	{
		t_tt = characters[0][1];
		cesar_key_1 = (t_tt - 't') % alphabet.length();
	}
	if (a_a)
	{
		a_aa = characters[0][2];
		cesar_key_2 = (a_aa - 'a') % alphabet.length();
	}
	if (o_o)
	{
		o_oo = characters[0][3];
		cesar_key_3 = (o_oo - 'o') % alphabet.length();
	}
	int Get_key;
	if ((cesar_key_0 == cesar_key_1) && (((cesar_key_1 == cesar_key_2) || (cesar_key_1 != cesar_key_2)) && ((cesar_key_2 == cesar_key_3) || (cesar_key_2 != cesar_key_3))))
		Get_key = cesar_key_0;
	if ((cesar_key_0 != cesar_key_1) && (cesar_key_1 == cesar_key_2 == cesar_key_3))
		Get_key == cesar_key_1;
	if ((cesar_key_0 != cesar_key_1) && (cesar_key_0 != cesar_key_2) && (cesar_key_0 != cesar_key_3) && (cesar_key_1 != cesar_key_2) && (cesar_key_1 != cesar_key_3) && (cesar_key_2 && cesar_key_3))
	{
		cout << "Error! key not found..." << endl;
		cin.get();
		return 1;
	}
	crypted_text_file.close();

	decode(Get_key, alphabet);

	cout << "The task is completed, text has been decrypted..." << endl;
	cout << "Key: " << Get_key << endl;
	cin.get();
	return 0;
}