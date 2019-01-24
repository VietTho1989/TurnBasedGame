#include "reversi_hash.hpp"

namespace Reversi
{
    // Creates a hashtable, with argument in number of bits for the bitmask
    // The table will have 2^bits entries
    Hash::Hash(int32_t bits) {
        size = 1 << bits;
        table = new HashLL[size];
        keys = 0;
    }
    
    Hash::~Hash() {
        delete[] table;
    }
    
    /**
     * @brief Adds key (b,ptm) and item move into the hashtable.
     * Assumes that this key has been checked with get and is not in the table.
     */
    void Hash::add(Board &b, int32_t score, int32_t move, int32_t ptm, uint8_t turn,
                   int32_t depth, uint8_t nodeType) {
        uint32_t index = b.getHashCode() & (size-1);
        HashLL *node = &(table[index]);
        if (node->entry1.taken == 0) {
            keys++;
            node->entry1.setData(b.getTaken(), b.getBits(CBLACK), score, move,
                                 ptm, turn, depth, nodeType);
            return;
        }
        else if (node->entry2.taken == 0) {
            keys++;
            node->entry2.setData(b.getTaken(), b.getBits(CBLACK), score, move,
                                 ptm, turn, depth, nodeType);
            return;
        }
        // Always update the same position with newer information
        if (node->entry1.taken == b.getTaken()
            && node->entry1.black == b.getBits(CBLACK)
            && node->entry1.ptm == (uint8_t) ptm) {
            node->entry1.setData(b.getTaken(), b.getBits(CBLACK), score, move,
                                 ptm, turn, depth, nodeType);
        }
        else if (node->entry2.taken == b.getTaken()
                 && node->entry2.black == b.getBits(CBLACK)
                 && node->entry2.ptm == (uint8_t) ptm) {
            node->entry2.setData(b.getTaken(), b.getBits(CBLACK), score, move,
                                 ptm, turn, depth, nodeType);
        }
        else {
            BoardData *toReplace = nullptr;
            // Prioritize entries with a higher depth, but also from a more
            // recent search space
            int32_t score1 = 4*(turn - node->entry1.turn) + depth - node->entry1.depth;
            int32_t score2 = 4*(turn - node->entry2.turn) + depth - node->entry2.depth;
            if (score1 >= score2)
                toReplace = &(node->entry1);
            else
                toReplace = &(node->entry2);
            if (score1 <= 0 && score2 <= 0)
                toReplace = nullptr;
            
            if (toReplace != nullptr) {
                toReplace->setData(b.getTaken(), b.getBits(CBLACK), score, move,
                                   ptm, turn, depth, nodeType);
            }
        }
    }
    
    /**
     * @brief Get the move, if any, associated with a board b and player to move.
     */
    BoardData *Hash::get(Board &b, int32_t ptm) {
        uint32_t index = b.getHashCode() & (size-1);
        HashLL *node = &(table[index]);
        
        if (node->entry1.taken == b.getTaken()
            && node->entry1.black == b.getBits(CBLACK)
            && node->entry1.ptm == (uint8_t) ptm)
            return &(node->entry1);
        
        if (node->entry2.taken == b.getTaken()
            && node->entry2.black == b.getBits(CBLACK)
            && node->entry2.ptm == (uint8_t) ptm)
            return &(node->entry2);
        
        return nullptr;
    }
}
