#include "Deck.h"
#include <ctime>
#include <stdlib.h>

Deck::Deck()
{
	srand(time(NULL));
	createDeck();
}

/// <summary>
/// Creates a new ordered deck
/// </summary>
void Deck::createDeck()
{
	// Clear the cards vector
	cards.clear();

	int cardNum = 0;
	for (int j = 0; j < 4; j++) // Suits
	{
		for (int k = 0; k < 13; k++)	// Values
		{
			cards.push_back(Card(value[k], suit[j], cardNum));

			cardNum++;
		}
	}
}

/// <summary>
/// Swaps the position of two cards in the deck
/// </summary>
/// <param name="cardOne">The first card to swap</param>
/// <param name="cardTwo">The second card to swap</param>
void Deck::swapCardPositions(Card &cardOne, Card &cardTwo)
{
	Card tempCard = cardOne;	// Store cardOne in tempCard
	cardOne = cardTwo;			// Store cardTwo in cardOne
	cardTwo = tempCard;			// Store tempCard in cardTwo
}

/// <summary>
/// Sorts the deck
/// </summary>
void Deck::sortDeck()
{
	createDeck();
}

/// <summary>
/// Shuffles the deck randomly.
/// </summary>
/// <param name="rounds">The amount of times the deck should be shuffled</param>
void Deck::shuffleDeck(int rounds)
{	
	while (rounds > 0)
	{
		for (std::vector<Card>::iterator iter = cards.begin(); iter != cards.end(); iter++)
		{
			// Get a random card from the deck
			int randomNum = rand() % cards.size();
			std::vector<Card>::iterator secondIter = cards.begin();
			std::advance(secondIter, randomNum);

			// Swap current card and random card
			swapCardPositions(*iter, *secondIter);
		}
		rounds--;
	}
}

/// <summary>
/// Returns a card from the deck
/// </summary>
/// <param name="dealFaceDown">Whether the card should be hidden when dealt</param>
Card Deck::dealCard(bool dealFaceDown)
{
	// Move iterator to last card
	std::vector<Card>::reverse_iterator rIter = cards.rbegin();

	// Store last card 
	Card returnCard = *rIter;

	// Delete last card from vector
	cards.pop_back();

	// If the card is meant to be delt face down, hide the card
	if (dealFaceDown)
		returnCard.setHidden(true);	

	// Return the stored last card
	return returnCard;
}

/// <summary>
/// Returns the amount of cards left in the deck
/// </summary>
/// <returns>The number of cards in the deck</returns>
int Deck::getSize()
{
	return cards.size();
}

/// <summary>
/// Adds card to the deck
/// </summary>
/// <param name="card">The card to add</card>
void Deck::addCard(Card card)
{
	cards.push_back(card);
}
