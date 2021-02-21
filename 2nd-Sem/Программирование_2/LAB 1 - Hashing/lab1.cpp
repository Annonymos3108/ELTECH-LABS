#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <clocale>
#include <fstream>

using namespace std;

unsigned long long hash_function(char* str)
{
	const int p = 32;
    long hash = 0, pow = 1;
    for (size_t i=0; i<strlen(str); ++i)
     {
	    hash += (str[i] - 'a' + 1) * pow;
		pow *= p;
	}
    return hash;
}

int main()
{   
	// choosing programm mode //
	printf("Please choose the programm mode\n");
	printf("Enter 1 to enter new password\n");
	printf("Enter 2 for cheking password\n ");
	int mode;
	cin >> mode;  
    if(mode !=1 && mode!=2)
	{
		printf("%sError!");
	}

	if(mode == 1)
	{
        cout << "Enter the new password, and press ENTER\n";
        cout << "Password length is 32 symbols\n";
	    char str[33];
	    cin >> str;
	    ifstream fin("hash.txt");
	    if (!fin.good())
	     {
			printf("Error, file does not open!");
	    }
		long long hash = hash_function(str);
		fin << hash;
		fin.close();	
	}

	if(mode == 2)
	 {
		cout << "Enter password\n";
		char stw[33];
		cin >> stw;
		long long newhash = hash_function(stw);
        ofstream fout("hash.txt");
		if (!fout.good())
	     {
			printf("Error, file does not open!");
	    }
		unsigned long compare;
		fout >> compare;
		if(newhash == compare)
		 {
			cout <<  "ACCESS DENIED!";
		} 
		else
		 {
            cout << "ACCESS GRATED!";
		}
		fout.close();	
    }
    return 0;
}