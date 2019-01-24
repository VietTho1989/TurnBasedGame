#ifndef __KHET_SQUARE_HELPERS_H__
#define __KHET_SQUARE_HELPERS_H__

#include "khet_Globals.hpp"

namespace Khet
{
    // The format for a Square (in bits) is:
    // B1: Reserved.
    // B2: Player
    // B3-B5: Piece type
    // B6-B8: Orientation
    
    inline Square MakeSquare(Player player, Piece piece, Orientation orientation)
    {
        return (Square)((int32_t)player << 1 | (int32_t)piece << 2 | orientation << 5);
    }
    
    inline Player GetOwner(Square s)
    {
        return (Player)(s >> 1 & 0x1);
    }
    
    inline Piece GetPiece(Square s)
    {
        return (Piece)(s >> 2 & 0x7);
    }
    
    inline Orientation GetOrientation(Square s)
    {
        return (Orientation)(s >> 5 & 0x7);
    }
    
    inline Square Rotate(Square s, int32_t rotation)
    {
        int32_t o = GetOrientation(s);
        o = (o + rotation) % 4;
        if (o < 0) o += 4;
        return (s & 0x1F) + (o << 5);
    }
    
    inline bool IsPiece(Square s)
    {
        return s != Empty && s != OffBoard;
    }
}

#endif // __SQUARE_HELPERS_H__
