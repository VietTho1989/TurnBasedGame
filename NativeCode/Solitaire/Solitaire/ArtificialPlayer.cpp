#include "ArtificialPlayer.h"

/// <summary>
/// Starts a new game if the board has not been set
/// </summary>
/// <param name="board">The game board</param>
ArtificialPlayer::ArtificialPlayer(Board *board)
{
	this->board = board;

	// If the board is not set, start a new game
	if (!board->isSet())
		nextCommand = "NEWGAME";
	else
		nextCommand = "NULL";
}

/// <summary>
/// Decides what move to play next.
/// (called by getCommand()).
/// </summary>
/// <returns>A command for the board</returns>
std::string ArtificialPlayer::think()
{
	// Check if any cards can move into the suit slots
	{
		int curSuitSlot = 0;

		do
		{
			// Decide what value is needed
			int reqValue = board->suitSlots[curSuitSlot].size();
			std::string reqSuit;

			// If suit slot isn't empty
			if (reqValue != 0)
				reqSuit = board->suitSlots[curSuitSlot].top().getSuit();

			for (int i = 0; i < 7; i++)
			{
				// If the board slot is not empty
				if (!board->boardSlots[i].empty())
				{
					std::vector<Card>::reverse_iterator iter = board->boardSlots[i].rbegin();

					// If the required value is found, and the required suit is either null or matches the test card's suit
					if (iter->getValueNum() == reqValue && (reqSuit == "" || reqSuit == iter->getSuit()))
					{
						std::string command = "MOVE ";
						command.append(std::to_string(i));
						command.append(" ");
						command.append(std::to_string(board->boardSlots[i].size() - 1));
						command.append(" ");
						command.append(std::to_string(curSuitSlot + 7));
						return command;
					}
				}
			}

			// If the hand is not empty
			if (!board->hand.empty())
			{
				// If the required value is found, and the required suit is either null or matches the test card's suit
				if (board->hand.top().getValueNum() == reqValue && (reqValue == NULL || reqSuit == board->hand.top().getSuit()))					
					return "MOVE 11";
			}

			curSuitSlot++;
		} while (curSuitSlot <= 3);
	}


	// Check if a card on the board can move
	{
		int curColumn = 0;
		while (curColumn <= 6)
		{
			if (!board->boardSlots[curColumn].empty())
			{
				int row = 0;
				std::vector<Card>::iterator movingCard = board->boardSlots[curColumn].begin();

				// Get the coordinates for the current card
				point card;
				card.x = curColumn;
				card.y = row;
				std::vector<Card> movingColumn;

				// If the card can move
				while (movingCard != board->boardSlots[curColumn].end())
				{
					if (board->canMove(card, movingColumn, *movingCard))
					{
						// If the card is king and it isn't in the bottom row
						if (movingCard->getValue() == "KING" && card.y != 0)
						{
							int i = 0;
							do
							{
								if (i != curColumn)
								{
									if (board->boardSlots[i].empty())
									{
										std::string command = "MOVE ";
										command.append(std::to_string(curColumn));
										return command;
									}
								}

								i++;
							} while (i <= 6);
						}

						// check other columns to see if this card can move there
						for (int i = 0; i < 7; i++)
						{
							// If i isn't the same column as current and column i isn't empty
							if (i != curColumn && !board->boardSlots[i].empty())
							{
								std::vector<Card>::reverse_iterator target = board->boardSlots[i].rbegin();

								// If the target value is one greater than moving card's value, and opposite colour
								if (target->getValueNum() == movingCard->getValueNum() + 1 && target->getColour() != movingCard->getColour())
								{
									int originalGreatness = 0;
									int targetGreatness = 0;
									bool hiddenCard = false;

									// Check if the column it is joining is greater than the old column
									while (hiddenCard == false && target != board->boardSlots[i].rend())
									{
										if (!target->isHidden())
											targetGreatness++;
										else
											hiddenCard = true;

										target++;
									}
									hiddenCard = false;

									std::vector<Card>::reverse_iterator originalCol = board->boardSlots[curColumn].rbegin();
									while (originalCol->getCardNum() != movingCard->getCardNum())
									{
										originalCol++;
									}				
									originalCol++;

									while (hiddenCard == false && originalCol != board->boardSlots[curColumn].rend())
									{
										if (!originalCol->isHidden())
											originalGreatness++;
										else
											hiddenCard = true;

										originalCol++;
									}

									if (targetGreatness > originalGreatness)
									{
										std::string command = "MOVE ";
										command.append(std::to_string(curColumn));
										return command;
									}

								}
							}
						}
						movingCard++;
						card.y++;
					}
					else
					{
						movingCard++;
						card.y++;
					}
				}
			}
			curColumn++;
		}
	}


	// Check if a card from the hand can move
	{
		int dest = 0;
		
		while (dest <= 6)
		{
			if (!board->boardSlots[dest].empty())
			{
				std::vector<Card>::reverse_iterator target = board->boardSlots[dest].rbegin();

				if (target->getValueNum() == board->hand.top().getValueNum() + 1 && target->getColour() != board->hand.top().getColour())
					return "MOVE 11";
			}
			else if (board->hand.top().getValue() == "KING")
			{
				return "MOVE 11";
			}
			
			dest++;
		}
	}


	// No available moves, draw a new hand
	return "DRAW";
}

/// <summary>
/// Returns the command to start a new game
/// </summary>
/// <returns>The command "NEWGAME"</returns>
std::string ArtificialPlayer::startNewGame()
{
	return "NEWGAME";
}

/// <summary>
/// Gets a command to play to give to the game board.
/// </summary>
/// <returns>A valid command</returns>
std::string ArtificialPlayer::getCommand()
{
	// If a command has been set by another function, use that command
	if (nextCommand != "NULL")
	{	
		std::string com = nextCommand;
		nextCommand = "NULL";
		return com;
	}

	// If the hand is empty, draw a card
	if (board->hand.empty() && board->deck.getSize() > 0)
		return "DRAW";

	std::string command = think();
	if (command == "DRAW")
		drawCount++;
	else
		drawCount = 0;

	/*if (drawCount > 10) // Give up after 10 unsuccessful draws
	{
		std::cout << "\n\n\tNo solution found :(\n\n";
		return "EXIT";
	}*/

	return think();
}
