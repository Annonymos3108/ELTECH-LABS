#include <iostream>
#include <cstdlib>
#include <vector>
typedef std::vector<std::vector<bool> > matrix;
typedef unsigned int uint;

/* Utils for working with console */
namespace Console {

	// Clear console in *nix
	void clearUnix() {
		system("clear");
	}

	// Clear console in Windows™
	void clearWin() {
		system("cls");
	}

	// Let's draw the field into console space!
	void drawField(matrix &field) {
		// For each row...
		for (uint i = 0; i < field.size(); i++) {
			// ...draw first '|'...
			std::cout << '|';
			// ...then for each value in row...
			for (uint j = 0; j < field[0].size(); j++) {
				// ...draw '*' if the cell is alive, ' ' otherwise...
				std::cout << (field[i][j] ? '*' : ' ') << ' ';
			}
			// ...close row with '|'
			std::cout << "|\n";
		}
	}
}