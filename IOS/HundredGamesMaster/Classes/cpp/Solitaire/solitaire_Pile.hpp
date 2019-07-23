#ifndef Solitaire_Pile_h
#define Solitaire_Pile_h
#include "solitaire_Card.hpp"

namespace Solitaire
{
    
    enum Piles {
        WASTE = 0,
        TABLEAU1,
        TABLEAU2,
        TABLEAU3,
        TABLEAU4,
        TABLEAU5,
        TABLEAU6,
        TABLEAU7,
        STOCK,
        FOUNDATION1C,
        FOUNDATION2D,
        FOUNDATION3S,
        FOUNDATION4H
    };
    
    class Pile {
        
    public:
        int32_t size;
        
        int32_t downSize;
        Card down[24];
        
        int32_t upSize;
        Card up[24];
        
    public:
        void AddDown(Card card);
        void AddUp(Card card);
        void Remove(Pile & to);
        void Remove(Pile & to, int count);
        void RemoveTalon(Pile & to, int count);
        void Flip();
        void Reset();
        void Initialize();
        int HighValue();
        int Size();
        int DownSize();
        int UpSize();
        Card operator[](int index);
        Card Down(int index);
        Card Up(int index);
        Card Low();
        Card High();
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
        int32_t getByteSize();
        
        static int32_t convertToByteArray(Pile* pile, uint8_t* &byteArray);
        
        static int32_t parseByteArray(Pile* pile, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
        
    };
    
}

#endif
