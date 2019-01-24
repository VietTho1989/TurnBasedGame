#ifndef Solitaire_Move_h
#define Solitaire_Move_h
#include <memory>
using namespace std;

namespace Solitaire
{
    
    struct Move {
        
        unsigned char From;
        unsigned char To;
        unsigned char Count;
        unsigned char Extra;
        
        Move();
        Move(unsigned char from, unsigned char to, unsigned char count, unsigned char extra);
        void Set(unsigned char from, unsigned char to, unsigned char count, unsigned char extra);
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
        static int32_t getByteSize();
        
        static int32_t convertToByteArray(Move* move, uint8_t* &byteArray);
        
        static int32_t parseByteArray(Move* move, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
        
    };
    
    struct MoveNode {
        shared_ptr<MoveNode> Parent;
        Move Value;
        
        MoveNode(Move move);
        MoveNode(Move move, shared_ptr<MoveNode> const& parent);
    };
    
}

#endif
