#include <cstdio>
#include <iostream>
#include <cstdlib>
#include <conio.h> // для getch()

using namespace std;

struct Node
{
	char element;
	Node *next;
};

Node* InPassword()
{
	char element;
	Node *delta, *Head = NULL, *Back;
	while (1)
	{
		element = getch();
		if (element == 13)
		{
			Back->next = NULL;
			break;
		}
		else
		{
			delta = new Node;
			delta->element = element;
			if (!(Head)) Head = delta;
			else Back->next = delta;
			Back = delta;
		}
	}
	return Head;
}

int HashFunc(Node* pass)
{
	int pow = 1, i = 1;
	unsigned long long hash = 0;
	while (pass != NULL)
	{
		hash += ((((((pass->element - 'a') << 5) * 24) ^ (pass->element))*pass->element)*i) ^ i;
		i++;
		Node* password = pass;
		pass = pass->next;
		delete password;
	}
	return hash;
}

int main()
{
	char mode;
	FILE *file;
	Node* pass;
start:
	printf("Please choose the programm mode\n");
	printf("Enter 1 to enter new password\n");
	printf("Enter 2 for cheking password\n ");
	cin >> mode;

	if (mode == 1)
	{

		printf("Enter the new password and press ENTER\n");
		pass = InPassword();
		file = fopen("hash.txt", "wb");
		if (fopen == NULL)
		{
			printf("Error, file does not open!");
			return -1;
		}
		fprintf(file, "%d", HashFunc(pass));
		fclose(file);
		printf("Done");
		return 0;
	}

	if (mode == 2)
	{
		long oldHash;
		file = fopen("hash.txt", "rb");
		if (fopen == NULL)
		{
			printf("Error, file does not open!");
			return -1;
		}
		fscanf(file, "%d", &oldHash);
		fclose(file);
		printf("Enter password:");
		pass = InPassword();
		if (HashFunc(pass) == oldHash) printf("ACCESS GRATED!");
		else printf("ACCESS DENIED!");
		cin.get();
		return 0;
	}
	else
	{
		printf("%sError!");
		goto start;
	}
	return 0;
}