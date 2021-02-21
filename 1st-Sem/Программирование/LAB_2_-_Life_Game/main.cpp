#include "game.h"
#include "console.h"
#include <time.h>

// Start program
int main()
{
	// Set rows and cols of the future field
	size_t rows = 20, cols = 40;
	// Get a blank field
	matrix *field = Game::getBlankField(rows, cols);
	// Some magic things for getting random numbers
	srand(time(NULL));
	// Set randomly alive or dead cell
	for (uint i = 0; i < rows; i++) {
		for (uint j = 0; j < cols; j++) {
			field->at(i).at(j) = rand() % 2;
		}
	}

	// 1000 times will be shown
	for (uint i = 0; i < 1000; i++) {
		// Clear console
		Console::clearUnix();
		// Draw the field into console
		Console::drawField(*field);
		// Save the current field...
		matrix *oldField = Game::getBlankField(rows, cols);
		Game::copy(*oldField, *field);
		// ...and update field
		Game::step(*field);
		// Check if life is frozen. If so break the loop
		if (Game::isEqual(*oldField, *field))
			break;
		// Sleep time
		usleep(250 * 1000);
	}
	return 0;
}