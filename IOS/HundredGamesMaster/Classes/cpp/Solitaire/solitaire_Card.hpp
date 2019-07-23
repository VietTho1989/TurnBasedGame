#ifndef Solitaire_Card_h
#define Solitaire_Card_h

#include <cstdint>

namespace Solitaire
{
    
    enum Cards {
        EMPTY = 0,
        ACE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING
    };
    
    enum Suits {
        CLUBS = 0,
        DIAMONDS,
        SPADES,
        HEARTS,
        NONE = 255
    };
    
    struct Card {
        
        unsigned char Suit;
        unsigned char Rank;
        unsigned char IsOdd;
        unsigned char IsRed;
        unsigned char Foundation;
        unsigned char Value;
        
        void Clear();
        void Set(unsigned char value);
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
        static int32_t getByteSize();
        
        static int32_t convertToByteArray(Card* card, uint8_t* &byteArray);
        
        static int32_t parseByteArray(Card* card, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
        
    };
    
}

#endif
