#include "Card.h"

/// <summary>
/// Creates a card
/// </summary>
/// <param name="value">A string representation of the value of the card  (ACE, ONE, KING, etc.)</param>
/// <param name="suit">The suit of the card</param>
/// <param name="cardNum">The card's number within an ordered deck(0-52)</param>
Card::Card(std::string value, std::string suit, int cardNum)
{
	this->value = value;
	this->suit = suit;
	this->cardNum = cardNum;

	if ((suit == "CLUBS") || (suit == "SPADES"))
		colour = "BLACK";
	else if ((suit == "DIAMONDS") || (suit == "HEARTS"))
		colour = "RED";
	else
		throw std::exception();
}

/// <summary>
/// Gets the value of the card if it is unhidden
/// <summary>
/// <returns>The string value or "HIDDEN"</returns>
std::string Card::getValue()
{
	if (!hidden)
		return value;
	else
		return "HIDDEN";
}

/// <summary>
/// Gets the abbreviated value of the card (for displaying on screen)
/// <summary>
/// <returns>An abbreviated version of the card's value</returns>
std::string Card::getValueAbrv()
{
	int cardVal = cardNum % 13;

	switch (cardVal)
	{
	case (0):
		return "A";
	case(1):
		return "2";
	case(2):
		return "3";
	case(3):
		return "4";
	case(4):
		return "5";
	case(5):
		return "6";
	case(6):
		return "7";
	case(7):
		return "8";
	case(8):
		return "9";
	case(9):
		return "10";
	case(10):
		return "J";
	case(11):
		return "Q";
	case(12):
		return "K";
	default:
		return "0";
	}
}

/// <summary>
/// Gets the integer value of the card 
/// <summary>
/// <returns>Returns the value of the card as an integer (ACE = 0, KING = 12)</returns>
int Card::getValueNum()
{
	return cardNum % 13;
}

/// <summary>
/// Sets the value of the card
/// <summary>
/// <param name="value">The new value to assign</param>
void Card::setValue(std::string value)
{
	this->value = value;
}

/// <summary>
/// Gets the suit of the card if it is unhidden
/// <summary>
/// <returns>The string suit or "HIDDEN"</returns>
std::string Card::getSuit()
{
	if (!hidden)
		return suit;
	else
		return "HIDDEN";
}

/// <summary>
/// Sets the suit of the card
/// <summary>
/// <param name="suit">The new suit to assign</param>
void Card::setSuit(std::string suit)
{
	this->suit = suit;
}

/// <summary>
/// Gets the number of the card
/// </summary>
/// <returns>The number of the card or -1 if hidden</returns>
int Card::getCardNum()
{
	if (!hidden)
		return cardNum;
	else
		return -1;
}

/// <summary>
/// Sets the number of the card
/// <summary>
/// <param name="cardNum">The new number to assign</param>
void Card::setCardNum(int cardNum)
{
	this->cardNum = cardNum;
}

/// <summary>
/// Sets whether the card is hidden or nto
/// <summary>
/// <param name="hide">The new value to assign</param>
void Card::setHidden(bool hide)
{
	hidden = hide;
}

/// <summary>
/// Gets whether or not the card is hidden
/// </summary>
/// <returns>True if the card is hidden, else false</returns>
bool Card::isHidden()
{
	return hidden;
}

/// <summary>
/// Gets the colour of the card depending on the suit
/// </summary>
/// <returns>"RED", "BLACK", or "UNKNOWN" if no suit set</returns>
std::string Card::getColour()
{
	if ((suit == "CLUBS") || (suit == "SPADES"))
		return "BLACK";
	else if ((suit == "DIAMONDS") || (suit == "HEARTS"))
		return "RED";
	else
		return "UNKNOWN";
}

/// <summary>
/// Gets the card on top of this card that could be blocking it from moving
/// </summary>
/// <returns>The child card</returns>
Card* Card::getConnectedCard()
{
	if (connectedCard)
		return connectedCard;
	else
		return nullptr;
}

/// <summary>
/// Sets the card on top of this card
/// </summary>
/// <param name="card">The card to set as a child of this</param>
void Card::setConnectedCard(Card *card)
{
	connectedCard = card;
}
