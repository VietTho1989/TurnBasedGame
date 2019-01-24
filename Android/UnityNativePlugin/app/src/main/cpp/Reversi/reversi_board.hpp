#ifndef __reversi_BOARD_H__
#define __reversi_BOARD_H__

#include "reversi_common.hpp"

namespace Reversi
{
    /**
     * @brief For converting a move number 0-63 to a bitmask.
     */
    const bitbrd MOVEMASK[64] = {
        0x0000000000000001, 0x0000000000000002, 0x0000000000000004, 0x0000000000000008,
        0x0000000000000010, 0x0000000000000020, 0x0000000000000040, 0x0000000000000080,
        0x0000000000000100, 0x0000000000000200, 0x0000000000000400, 0x0000000000000800,
        0x0000000000001000, 0x0000000000002000, 0x0000000000004000, 0x0000000000008000,
        0x0000000000010000, 0x0000000000020000, 0x0000000000040000, 0x0000000000080000,
        0x0000000000100000, 0x0000000000200000, 0x0000000000400000, 0x0000000000800000,
        0x0000000001000000, 0x0000000002000000, 0x0000000004000000, 0x0000000008000000,
        0x0000000010000000, 0x0000000020000000, 0x0000000040000000, 0x0000000080000000,
        0x0000000100000000, 0x0000000200000000, 0x0000000400000000, 0x0000000800000000,
        0x0000001000000000, 0x0000002000000000, 0x0000004000000000, 0x0000008000000000,
        0x0000010000000000, 0x0000020000000000, 0x0000040000000000, 0x0000080000000000,
        0x0000100000000000, 0x0000200000000000, 0x0000400000000000, 0x0000800000000000,
        0x0001000000000000, 0x0002000000000000, 0x0004000000000000, 0x0008000000000000,
        0x0010000000000000, 0x0020000000000000, 0x0040000000000000, 0x0080000000000000,
        0x0100000000000000, 0x0200000000000000, 0x0400000000000000, 0x0800000000000000,
        0x1000000000000000, 0x2000000000000000, 0x4000000000000000, 0x8000000000000000
    };
    
    const bitbrd NEIGHBORS[64] = {
        0x0000000000000302, 0x0000000000000705, 0x0000000000000e0a, 0x0000000000001c14,
        0x0000000000003828, 0x0000000000007050, 0x000000000000e0a0, 0x000000000000c040,
        0x0000000000030203, 0x0000000000070507, 0x00000000000e0a0e, 0x00000000001c141c,
        0x0000000000382838, 0x0000000000705070, 0x0000000000e0a0e0, 0x0000000000c040c0,
        0x0000000003020300, 0x0000000007050700, 0x000000000e0a0e00, 0x000000001c141c00,
        0x0000000038283800, 0x0000000070507000, 0x00000000e0a0e000, 0x00000000c040c000,
        0x0000000302030000, 0x0000000705070000, 0x0000000e0a0e0000, 0x0000001c141c0000,
        0x0000003828380000, 0x0000007050700000, 0x000000e0a0e00000, 0x000000c040c00000,
        0x0000030203000000, 0x0000070507000000, 0x00000e0a0e000000, 0x00001c141c000000,
        0x0000382838000000, 0x0000705070000000, 0x0000e0a0e0000000, 0x0000c040c0000000,
        0x0003020300000000, 0x0007050700000000, 0x000e0a0e00000000, 0x001c141c00000000,
        0x0038283800000000, 0x0070507000000000, 0x00e0a0e000000000, 0x00c040c000000000,
        0x0302030000000000, 0x0705070000000000, 0x0e0a0e0000000000, 0x1c141c0000000000,
        0x3828380000000000, 0x7050700000000000, 0xe0a0e00000000000, 0xc040c00000000000,
        0x0203000000000000, 0x0507000000000000, 0x0a0e000000000000, 0x141c000000000000,
        0x2838000000000000, 0x5070000000000000, 0xa0e0000000000000, 0x40c0000000000000
    };
    
    const int32_t SQ_VAL[64] = {
        9, 1, 7, 6, 6, 7, 1, 9,
        1, 0, 2, 3, 3, 2, 0, 1,
        7, 2, 5, 4, 4, 5, 2, 7,
        6, 3, 4, 0, 0, 4, 3, 6,
        6, 3, 4, 0, 0, 4, 3, 6,
        7, 2, 5, 4, 4, 5, 2, 7,
        1, 0, 2, 3, 3, 2, 0, 1,
        9, 1, 7, 6, 6, 7, 1, 9
    };
    
    class Board {
        
    public:
        bitbrd pieces[2];
        
    private:
        // 16 x 256 zobrist table array
        static uint32_t **zobristTable;
        static uint32_t **initZobristTable();
        
        bitbrd northFill(int32_t index, bitbrd self, bitbrd pos);
        bitbrd southFill(int32_t index, bitbrd self, bitbrd pos);
        bitbrd eastFill(int32_t index, bitbrd self, bitbrd pos);
        bitbrd westFill(int32_t index, bitbrd self, bitbrd pos);
        bitbrd neFill(int32_t index, bitbrd self, bitbrd pos);
        bitbrd nwFill(int32_t index, bitbrd self, bitbrd pos);
        bitbrd swFill(int32_t index, bitbrd self, bitbrd pos);
        bitbrd seFill(int32_t index, bitbrd self, bitbrd pos);
        
    public:
        Board();
        Board(bitbrd w, bitbrd b);
        ~Board();
        Board copy();
        Board *dynamicCopy();
        
        uint32_t getHashCode();
        
        bool checkMove(int32_t index, int32_t side);
        void doMove(int32_t index, int32_t side);
        bitbrd getDoMove(int32_t index, int32_t side);
        void makeMove(int32_t index, bitbrd changeMask, int32_t side);
        void undoMove(int32_t index, bitbrd changeMask, int32_t side);
        bitbrd getLegal(int32_t side);
        MoveList getLegalMoves(int32_t side);
        int32_t getLegalMoves4(int32_t side, int32_t *moves);
        int32_t getLegalMoves3(int32_t side, int32_t *moves);

        int32_t numLegalMoves(int32_t side);
        int32_t potentialMobility(int32_t side);
        int32_t getStability(int32_t side);
        
        void setBoard(char data[]);
        char *toString();
        bitbrd getBits(int32_t side);
        int32_t count(int32_t side);
        bitbrd getTaken();
        int32_t countEmpty();
        
        void print(Side side);
    };
}

#endif
