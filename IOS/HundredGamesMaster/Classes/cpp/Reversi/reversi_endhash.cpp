#include "reversi_endhash.hpp"

namespace Reversi
{
    // Creates a endgame hashtable, with argument in number of bits for the bitmask
    // The table will have 2^bits entries
    EndHash::EndHash(int32_t bits) {
        size = 1 << bits;
        table = new EndgameEntry[size];
        keys = 0;
    }
    
    EndHash::~EndHash() {
        delete[] table;
    }
    
    // Adds key (b, ptm) and item move into the hashtable.
    // Assumes that this key has been checked with get and is not in the table.
    void EndHash::add(Board &b, int32_t score, int32_t move, int32_t ptm, int32_t depth) {
        uint32_t index = b.getHashCode() & (size-1);
        EndgameEntry *node = &(table[index]);
        // Replacement strategy
        if (depth + 2 >= node->depth) {
            if (node->depth == 0)
                keys++;
            node->setEntry(b.getBits(CWHITE), b.getBits(CBLACK), score, move, ptm, depth);
        }
    }
    
    // Get the move, if any, associated with a board b and player to move.
    EndgameEntry *EndHash::get(Board &b, int32_t ptm) {
        uint32_t index = b.getHashCode() & (size-1);
        EndgameEntry *node = &(table[index]);
        
        if (node->white == b.getBits(CWHITE) && node->black == b.getBits(CBLACK)
            && node->ptm == (uint8_t) ptm)
            return node;
        
        return nullptr;
    }
}
