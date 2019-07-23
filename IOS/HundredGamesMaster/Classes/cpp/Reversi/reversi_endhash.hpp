#ifndef __reversi_ENDHASH_H__
#define __reversi_ENDHASH_H__

#include "reversi_board.hpp"
#include "reversi_common.hpp"

namespace Reversi
{
    struct EndgameEntry {
        bitbrd white;
        bitbrd black;
        int8_t score;
        uint8_t move;
        uint8_t ptm;
        uint8_t depth;
        
        EndgameEntry() {
            setEntry(0, 0, 0, 0, 0, 0);
        }
        
        void setEntry(bitbrd w, bitbrd b, int32_t s, int32_t m, int32_t p, int32_t d) {
            white = w;
            black = b;
            score = (int8_t) s;
            move = (uint8_t) m;
            ptm = (uint8_t) p;
            depth = (uint8_t) d;
        }
    };
    
    class EndHash {
        
    private:
        EndgameEntry *table;
        int32_t size;
        
        EndHash(const EndHash &other);
        EndHash& operator=(const EndHash &other);
        
    public:
        int32_t keys;
        
        EndHash(int32_t bits);
        ~EndHash();
        
        void add(Board &b, int32_t score, int32_t move, int32_t ptm, int32_t depth);
        EndgameEntry *get(Board &b, int32_t ptm);
    };
}

#endif
