#pragma once
#include "Card.h"
#include <vector>

class Deck
{
private:
	std::vector<Card> cards;	// A vector of cards in the deck
	const std::string value[13] = { "ACE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "JACK", "QUEEN", "KING" };	// All available card values
	const std::string suit[4] = { "CLUBS", "DIAMONDS", "HEARTS", "SPADES" };	// All available card suits
	void createDeck();	// Creates a fresh deck
	void swapCardPositions(Card &cardOne, Card &cardTwo);	// Swaps two cards in position
	

public:
	Deck();
	void sortDeck();	// Sorts deck in order clubs -> diamonds -> hearts -> spades
	void shuffleDeck(int rounds = 1);	// Shuffles the deck however many rounds are input
	Card dealCard(bool dealFaceDown = false);	// Deals the top card
	int getSize();
	void addCard(Card card);
};