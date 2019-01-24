#include "Board.h"

/// <summary>
/// Creates a log file.
/// </summary>
Board::Board()
{
	// Creates a log file
	// logFile.open("log.txt");
}

/// <summary>
/// Closes the log file.
/// </summary>
Board::~Board()
{
	// logFile.close();
}

/// <summary>
/// Sets the board with fresh cards
/// </summary>
void Board::setBoard()
{
	int cardsPerSlot = 1; // How many cards should be dealt into each column (start at 1, end at 7)

	for (int i = 0; i < 7; i++) // Loop through board slots
	{
		for (int j = 0; j < cardsPerSlot; j++) // Loop for how many cards should be added to this column
		{
			if (j < cardsPerSlot - 1)	// If the next card isn't going to be at the front of the slot
				boardSlots[i].push_back(deck.dealCard(true));	// hide it 
			else
				boardSlots[i].push_back(deck.dealCard(false));	// show it 
		}

		// increment the cardsPerSlot for the next column
		cardsPerSlot++;
	}

	boardSet = true;
}

/// <summary>
/// Clears the board and resets the deck
/// </summary>
void Board::clearBoard()
{
	if (!boardSet)
		return;

	// Clear board slots
	for (int i = 0; i < 7; i++)
	{
		while(!boardSlots[i].empty())
			boardSlots[i].pop_back();
	}

	// Clear suit slots
	for (int i = 0; i < 4; i++)
	{
		while (!suitSlots[i].empty())
			suitSlots[i].pop();
	}


	// Clear hand
	while (!hand.empty())
		hand.pop();

	// Create a new, ordered deck
	deck.sortDeck();

	// logFile.close();
	// logFile.open("log.txt");

	// Clear the screen
	std::system("cls");

	boardSet = false;
}

/// <summary>
/// Tries to deal three cards from the deck to the hand
/// </summary>
void Board::dealThree()
{
	if (!boardSet)
		return;

	// If there is no more cards to draw
	if (deck.getSize() == 0)
	{
		while (!hand.empty()) // Deal hand back into deck
		{
			deck.addCard(hand.top());
			hand.pop();
		}
		return;
	}

	int cardsDealt = 0;

	// While there are cards left in the hand, and less than three cards have been drawn
	while (cardsDealt < 3 && deck.getSize() != 0)
	{
		hand.push(deck.dealCard());	// Push cards from the deck into the hand

		cardsDealt++;				// Increment the amount of cards dealt
	}
}

/// <summary>
/// Prints the current board to the console
/// </summary>
void Board::printBoard()
{
	if (!boardSet)
		return;

	// Clear the screen
	std::system("cls");

	/////////////////////////////////// Draw suit slots
	std::cout << "    ";
	for (int i = 0; i < 4; i++)
		std::cout << i + 7 << "\t\t  ";

	std::cout << "\n  ";

	for (int i = 0; i < 4; i++) // Loop through the four slots
	{
		if (suitSlots[i].empty())	// If the slot is empty
		{
			std::cout << "[   ]" << "\t\t";	// Draw a blank card
		}
		else						// If the slot is not empty
		{
			// Get the top card of that slot and store its suit and value
			Card curCard = suitSlots[i].top();
			std::string suit = curCard.getSuit();
			std::string value = curCard.getValueAbrv();

			// Output
			std::cout << "[" << value;
			
			// Add an extra space if the value isn't double digits
			if (value != "10")
				std::cout << " " << suit[0] << "]\t\t";
			else
				std::cout << suit[0] << "\t\t";
		}
	}


	std::cout << "\n\n";


	///////////////////////////////////// Draw board slots
	std::cout << "    ";
	for (int i = 0; i < 7; i++)
		std::cout << i << "\t    ";

	std::cout << "\n";
	bool finished = false;	// Gets flipped to true when all slots are drawn to stop the loop
	int row = 0;			// The current row being drawn

	while (!finished)		// While drawing isn't finished
	{
		bool cardDrawn = false;	// Gets flipped to true if a card has been drawn this turn (to sense when to stop looping)

		for (int i = 0; i < 7; i++) // Loop across slots
		{
			if (boardSlots[i].size() > row)	// If the current slot has a card in the current row
			{
				// Get the card of this row and column
				std::vector<Card>::iterator iter = boardSlots[i].begin();
				std::advance(iter, row);
				Card curCard = *iter;

				
				if (curCard.isHidden())	// If the card is hidden, draw a blank card
					std::cout << "  [   ]\t";
				else					// Else, if the card is not hidden
				{
					// Store the suit and value of the card
					std::string suit = curCard.getSuit();
					std::string value = curCard.getValueAbrv();


					// Output
					std::cout << "  [" << value;
					
					// Draw an extra space if value is double digit
					if (value != "10")
						std::cout << " " << suit[0] << "]\t";
					else
						std::cout << suit[0] << "]\t";
				}

				// Set cardDrawn to true so it can loop next turn too.
				cardDrawn = true;
			}
			else
			{
				// If this column doesn't have a card in this rown, tab across to the next column
				std::cout << "\t";
			}
		}

		// If no card has been drawn this turn, signal that drawing has finished
		if (!cardDrawn)
			finished = true;
		else
		{
			std::cout << "  " << row << "\n";
			// Move onto the next row
			row++;
		}
	}

	std::cout << "\n\n  ";

	///////////////////////////////////// Draw hand
	if (hand.size() == 0) // If there is no hand, end prematurely
		return;
	else
		std::cout << "\t11: ";
	std::vector<Card> visibleHand;

	// Store the size of the hand, but cap it at three (only the top 3 cards should be drawn)
	int handSize = hand.size();
	if (handSize > 3)
		handSize = 3;

	// Loop through the top 3 or less cards in the hand and store them in visibleHand 
	for (int i = 0; i < handSize; i++)
	{
		visibleHand.push_back(hand.top());
		hand.pop();
	}
	
	int count = 1;

	// Loop through visible hand
	for (std::vector<Card>::reverse_iterator iter = visibleHand.rbegin(); iter != visibleHand.rend(); iter++)
	{
		// Get the card and store its suit and value
		Card curCard = *iter;
		std::string suit = curCard.getSuit();
		std::string value = curCard.getValueAbrv();

		// Output
		std::cout << "[" << value;

		// Print an extra space if the value is single-digit
		if (value != "10")
			std::cout << " " << suit[0];
		else
			std::cout << suit[0];

		if (count == handSize)
			std::cout << "]\t";

		// Push this card back into the hand
		hand.push(*iter);
		count++;
	}

	std::cout << "\n\n  ";
}

/// <summary>
/// Prints the deck (debug)
/// </summary>
void Board::printDeck()
{
	while (deck.getSize() > 0)
	{
		Card curCard = deck.dealCard();
		std::string suit = curCard.getSuit();
		std::string value = curCard.getValue();

		std::cout << suit << " " << value << "\n";
	}
}

/// <summary>
/// Handles a command
/// <summary>
/// <param name="command">The input command that will be handled</param>
/// <returns>0 if successfull, -1 if command is invalid</returns>
int Board::handle(std::string command)
{
	if (command == "DRAW")
	{
		dealThree();
		return 0;
	}
	else if (command == "NEWGAME")
	{
		clearBoard();
		deck.shuffleDeck(50);
		setBoard();
		return 0;
	}
	else if (command[0] == 'M' && command[1] == 'O' && command[2] == 'V' && command[3] == 'E')
	{
		// Erase 'MOVE '
		command.erase(0, 5);

		// If the command is empty, return early
		if (command.empty())
			return 1;

		// Store the column value and delete it from command
		std::string val1 = command.substr(0, command.find_first_of(' '));
		command.erase(0, val1.length() + 1);

		// If the command only contained one value, call first variation of move()
		if (command.empty())
		{
			return move(std::stoi(val1));
		}
		// Store the row value and delete it from command
		std::string val2 = command.substr(0, command.find_first_of(' '));
		command.erase(0, val2.length() + 1);

		// If the command contained two values, call the second variation of move()
		if (command.empty())
		{
			return move(std::stoi(val1), std::stoi(val2));
		}

		// Store the destination
		std::string val3 = command;

		// Create the point to move
		point movCard;
		movCard.x = std::stoi(val1);
		movCard.y = std::stoi(val2);

		move(movCard, std::stoi(val3));
        
        printf("error, why not return here");
        return 0;
	}
	else
		return -1;
}

/// <summary>
/// Performs the deepest available move from a column
/// <summary>
/// <param name="column">The column to move the card(s) from</param>
/// <returns>0 if successful, -1 if column is empty, -2 if no valid moves</returns>
int Board::move(int column)
{
	point cardPos;
	cardPos.x = column;
	cardPos.y = -1;
	
	// Return early if the column is empty
	if (column <= 6 && boardSlots[column].empty())
		return -1;
	else if ((column >= 7 && column <= 10) && suitSlots[column - 7].empty())
		return -1;
	else if (column == 11 && hand.empty())
		return -1;

	if (column <= 6 && boardSlots[column].size() >= 2) {
		std::vector<Card>::reverse_iterator testCard = boardSlots[column].rbegin();
		testCard++;
		std::vector<Card>::reverse_iterator topOfCurrentChain = boardSlots[column].rbegin();
		int row = boardSlots[column].size() - 1;

		do {
			// If the card we are testing isn't hidden and either has no connected card (must be top of pile) or is connected to the card we definitely want to move
			if (row >= 1 && !testCard->isHidden() && (testCard->getConnectedCard() == NULL || testCard->getConnectedCard() == &*topOfCurrentChain)) {
				testCard++;
				topOfCurrentChain++;
				row--;
			}
			else {
				cardPos.y = row;
			}
		} while (cardPos.y == -1);

		if (cardPos.y == -1)
			return -2;
	}

	if (cardPos.y == -1)
		cardPos.y = 0;

	std::vector<Card> movingColumn;
	Card movingCard;

	if (!canMove(cardPos, movingColumn, movingCard))
		return -2;
	
	do {

		for (int i = 7; i < 11; i++) {
			// If move(point, int) finishes with no errors, end early with no errors
			if (move(cardPos, i) == 0)
				return 0;
		}

		for (int i = 0; i < 7; i++) {
			// If move(point, int) finishes with no errors, end early with no errors
			if (move(cardPos, i) == 0)
				return 0;
		}

		cardPos.y++;

	} while (column <= 6 && cardPos.y < boardSlots[column].size());
    
    printf("error, why return here\n");
    return -2;
}

/// <summary>
/// Performs the deepest available move from one column to another
/// </summary>
/// <param name="column">The column to move the card(s) from</param>
/// <param name="destination">The column to move the card(s) to</param>
/// <returns>0 if successful, -1 if column is invalid</param>
int Board::move(int column, int destination)
{
	point cardPos;
	cardPos.x = column;

	// Find what row the card is in or return early if the card is invalid
	if (column <= 6 && !boardSlots[column].empty())
		cardPos.y = boardSlots[column].size() - 1;
	else if (column <= 10 && !suitSlots[column].empty())
		cardPos.y = suitSlots[column - 7].size() - 1;
	else if (column == 11 && !hand.empty())
		cardPos.y = hand.size() - 1;
	else
		return -1;

	// Find what row the card is in
	if (column <= 6)
		cardPos.y = boardSlots[column].size() - 1;
	else if (column <= 10)
		cardPos.y = suitSlots[column - 7].size() - 1;
	else
		cardPos.y = hand.size() - 1;

	return move(cardPos, destination);
}

/// <summary>
/// Moves a specific card and all its connected cards to a destination column
/// </summary>
/// <param name="card">The x and y coordinates of the moving card</param>
/// <param name="destination>The column to move the card(s) to</param>
/// <returns>0 if successful, -1 if card invalid, -2 if destination is invalid, -3 if move is against the rules</param>
int Board::move(point card, int destination)
{
	resetConnectedCards();

	// Column 0-6 (columns), 7-10 (suit piles), 11 (hand)
	int column = card.x;
	int row = card.y;

	////////////////////////////////////////////////////////////////////////////////////////// Column Check
	// If column is out of range, end early
	if (column < 0 || column > 12)
		return -1;

	// If the column is one of the board slots, and the row is greater than the slot's size, end early
	if (column <= 6 && row > boardSlots[column].size())
		return -1;

	////////////////////////////////////////////////////////////////////////////////////////// Destination check
	if (destination < 0 || destination > 10)
		return -2;


	////////////////////////////////////////////////////////////////////////////////////////// Check moving card itself
	std::vector<Card> movingColumn; // Get a vector ready just incase multiple cards need to move
	Card movingCard;

	////////////////////////////////////////////////////////////////////////////////////////// Check if card is locked
	if (!canMove(card, movingColumn, movingCard))
		return -1;


	////////////////////////////////////////////////////////////////////////////////////////// Check if destination is valid
	if (destination <= 6) // If destination is a board slot
	{
		// If the column isn't empty
		if (!boardSlots[destination].empty())
		{
			std::vector<Card>::reverse_iterator target = boardSlots[destination].rbegin();
			Card targetCard = *target;

			// If the target and moving cards are the same colour, or the target card value isn't moving card - 1
			if (targetCard.getColour() == movingCard.getColour() || movingCard.getValueNum() != targetCard.getValueNum() - 1)
			{
				return -3;
			}
		}
		else
		{
			// Only let a king move to an empty space
			if (movingCard.getValue() != "KING")
				return -3;
		}
	}
	else	// Destination must be a suit slot
	{
		int suitSlotNum = destination - 7;

		// If trying to move a column to a suit slot, end early
		if (movingColumn.size() > 1)
			return -2;

		// If the slot isn't empty
		if (!suitSlots[suitSlotNum].empty())
		{
			// If the card isn't the same suit as this slot or the value isn't one more than the top card
			if ((movingCard.getSuit() != suitSlots[suitSlotNum].top().getSuit()) || (movingCard.getValueNum() != suitSlots[suitSlotNum].top().getValueNum() + 1))
				return -3; // End early
		}
		else
		{
			// If the card is not an ace, end early
			if (movingCard.getValue() != "ACE")
				return -3;
		}
	}




	////////////////////////////////////////////////////////////////////////////////////////// If both alright, move it
	if (destination <= 6) // Moving to board slot
	{
		if (movingCard.getValue() == "KING" && card.y == 0 && destination > card.x)
			return -3;

		// Remember target's row
		int targetRow = boardSlots[destination].size() - 1;

		// Test if slot is empty before move
		bool movingToEmpty = boardSlots[destination].empty();

		// Append movingColumn to end of destination vector
		boardSlots[destination].insert(boardSlots[destination].end(), movingColumn.begin(), movingColumn.end());

		if (!movingToEmpty)
		{
			std::vector<Card>::iterator targetIter = boardSlots[destination].begin();
			std::advance(targetIter, targetRow);
			std::vector<Card>::iterator newIter = boardSlots[destination].begin();
			std::advance(newIter, targetRow + 1);

			do
			{
				targetIter->setConnectedCard(&*newIter);
				targetIter++;
				newIter++;
			} while (newIter != boardSlots[destination].end());
		}
	}
	else // moving to suit slot
	{
		suitSlots[destination - 7].push(movingCard);

		if (movingCard.getValue() == "KING")
		{
			checkGameComplete();
		}
	}




	if (column <= 6)
	{
		std::vector<Card>::iterator iter = boardSlots[column].begin();
		std::advance(iter, card.y);
		// logFile << "Moving " << iter->getValue() << " of " << iter->getSuit() << " ";

		for (int i = 0; i < movingColumn.size(); i++)
			boardSlots[column].pop_back();

		// If the old column is not empty, turn the last card around
		if (!boardSlots[column].empty())
		{
			std::vector<Card>::reverse_iterator iter = boardSlots[column].rbegin();

			if (iter->isHidden())
				iter->setHidden(false);

			if (iter->getConnectedCard() != NULL)
				iter->setConnectedCard(NULL);
		}
	}
	else if (column <= 10)
	{
		// logFile << "Moving " << suitSlots[column - 7].top().getValue() << " of " << suitSlots[column - 7].top().getSuit() << " ";

		suitSlots[column - 7].pop();
	}
	else
	{
		// logFile << "Moving " << hand.top().getValue() << " of " << hand.top().getSuit() << " ";

		hand.pop();
	}

	// logFile << "from [" << column << "][" << row << "] ";
	// logFile << " to column " << destination << "\n";

	return 0;
}

/// <summary>
/// Gets whether or not a board is set and ready to play
/// </summary>
/// <returns>true if set, else false</returns>
bool Board::isSet()
{
	return boardSet;
}

/// <summary>
/// Gets whether or not a card is free to move
/// </summary>
/// <param name="card">The moving card's coordinates on the board</param>
/// <param name="movingColumn">The column the card is moving from</param>
/// <param name="movingCard>The moving card itself</param>
/// <returns>true if move available, else false</returns>
bool Board::canMove(point card, std::vector<Card> &movingColumn, Card &movingCard)
{
	int column = card.x;
	int row = card.y;

	if (column <= 6)	// If the card is in a board slot
	{
		// End early if the slot is empty
		if (boardSlots[column].empty())
			return false;

		if (row >= boardSlots[column].size())
			return false;

		std::vector<Card>::iterator iter = boardSlots[column].begin();
		std::advance(iter, row);
		movingCard = *iter;

		if (movingCard.isHidden())	// If the card is hidden, end early
			return false;

		movingColumn.push_back(movingCard);

		// If there is a card connected
		if (movingCard.getConnectedCard() != NULL)
		{
			bool endOfChain = false;
			Card* currentCard = &movingCard;

			do
			{
				resetConnectedCards();
				Card *lockingCard = currentCard->getConnectedCard();

				// If there is a card locking in the current card
				if (lockingCard != nullptr)
				{
					// If the locking card is an opposite colour AND one value less than the current card
					if ((lockingCard->getColour() != currentCard->getColour()) && (lockingCard->getValueNum() == currentCard->getValueNum() - 1))
					{
						// Move down the chain
						currentCard = lockingCard;
						movingColumn.push_back(*currentCard);
					}
					else
					{
						// Card is locked, can't move
						return false;
					}
				}
				else
					endOfChain = true;

			} while (!endOfChain);
		}
	}
	else if (column <= 10)	// If column isn't a board slot, always take the top card
	{
		// Check the suit slot isn't empty
		if (suitSlots[column - 7].empty())
			return false;

		movingCard = suitSlots[column - 7].top();
		movingColumn.push_back(movingCard);
	}
	else if (column == 11)
	{
		// Check the hand isn't empty
		if (hand.empty())
			return false;

		movingCard = hand.top();
		movingColumn.push_back(movingCard);
	}
	else
		return false;

	// Card can move
	return true;
}

/// <summary>
/// Checks whether the game is complete
/// </summary>
/// <returns>true if game is complete, else false</returns>
bool Board::checkGameComplete()
{
	for (int i = 0; i < 4; i++)
	{
		if (suitSlots[i].top().getValue() != "KING")
			return false;
	}

	std::cout << "\n\n\tCongratulations!\n\n";
	// std::cin;
	boardSet = false;
	return true;
}

/// <summary>
/// Iterates through all cards on the board and resets their connectedCard to the correct card.
///
/// Somewhere in this project, cards are forgetting their connectedCard, causing an exception to be thrown when trying to access it. Temporary fix.
/// </summary>
void Board::resetConnectedCards()
{
	std::vector<Card>::iterator iter;
	std::vector<Card>::iterator iter2;

	for (int i = 0; i < 7; i++)
	{
		if (!boardSlots[i].empty())
		{
			iter = boardSlots[i].begin();

			if (boardSlots[i].size() >= 2)
			{
				iter2 = boardSlots[i].begin();
				iter2++;
				do
				{
					if (!iter->isHidden())
						iter->setConnectedCard(&*iter2);
					iter++;
					iter2++;

				} while (iter2 != boardSlots[i].end());
			}
		}
	}
}
