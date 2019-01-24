#pragma once
#include <iostream>
#include "Board.h"

class ArtificialPlayer
{
private:
	Board *board;				// The game board that will be played.
	std::string nextCommand;	// A queued command to be played next turn.
	int drawCount = 0;			// How many draws have been made since a move was played.

	std::string think(); // Decides a move to play and returns the command.

public:
	ArtificialPlayer(Board *board); // Stores the game board and queues a "NEWGAME" command if no game is started.
	std::string startNewGame(); // Returns the "NEWGAME" command.
	std::string getCommand(); // Returns either a queued command or uses think() to decide on a command.
};