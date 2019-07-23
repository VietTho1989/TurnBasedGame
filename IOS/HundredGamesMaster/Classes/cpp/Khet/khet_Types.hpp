#ifndef __KHET_TYPES_H__
#define __KHET_TYPES_H__

#include <cstdint>

namespace Khet
{
    typedef uint8_t Square;
    typedef uint32_t Move;
    
    // The player types.
    enum class Player
    {
        Silver = 0,
        Red = 1
    };
    
    // The piece types.
    enum class Piece
    {
        None = 1,
        Anubis = 2,
        Pyramid = 3,
        Scarab = 4,
        Pharaoh = 5,
        Sphinx = 6
    };
    
    // The orientation of a piece.
    enum Orientation
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    };
}

#endif // __TYPES_H__
