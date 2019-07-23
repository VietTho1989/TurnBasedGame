#ifndef __reversi_HASH_H__
#define __reversi_HASH_H__

#include "reversi_board.hpp"
#include "reversi_common.hpp"

namespace Reversi
{
    struct BoardData {
        bitbrd taken;
        bitbrd black;
        int32_t score;
        uint8_t move;
        uint8_t ptm;
        uint8_t turn;
        uint8_t depth;
        uint8_t nodeType;
        
        BoardData() {
            setData(0, 0, 0, 0, 0, 0, 0, 0);
        }
        
        BoardData(bitbrd t, bitbrd b, int32_t s, int32_t m, int32_t p, uint8_t tu, int32_t d,
                  uint8_t nt) {
            setData(t, b, s, m, p, tu, d, nt);
        }
        
        void setData(bitbrd t, bitbrd b, int32_t s, int32_t m, int32_t p, uint8_t tu, int32_t d,
                     uint8_t nt) {
            taken = t;
            black = b;
            score = s;
            move = (uint8_t) m;
            ptm = (uint8_t) p;
            turn = tu;
            depth = (uint8_t) d;
            nodeType = nt;
        }
    };
    
    class HashLL {
        
    public:
        BoardData entry1;
        BoardData entry2;
        
        HashLL() {}
        
        HashLL(bitbrd t, bitbrd b, int32_t s, int32_t m, int32_t ptm, uint8_t tu, int32_t d,
               uint8_t nt) {
            entry1 = BoardData(t, b, s, m, ptm, tu, d, nt);
        }
        
        ~HashLL() {}
    };
    
    class Hash {
        
    private:
        HashLL *table;
        int32_t size;
        
        Hash(const Hash &other);
        Hash& operator=(const Hash &other);
        
    public:
        int32_t keys;
        
        Hash(int32_t isize);
        ~Hash();
        
        void add(Board &b, int32_t score, int32_t move, int32_t ptm, uint8_t turn, int32_t depth,
                 uint8_t nodeType);
        BoardData *get(Board &b, int32_t ptm);
    };
}

#endif
