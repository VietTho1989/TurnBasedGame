#ifndef __KHET_GLOBALS_H__
#define __KHET_GLOBALS_H__

#include "khet_Types.hpp"
#include <string>
#include <vector>

namespace Khet
{
    // The padded dimensions of the board.
    const int32_t BoardWidth = 12;
    const int32_t BoardHeight = 10;
    const int32_t BoardArea = BoardWidth * BoardHeight;
    const int32_t NumPiecesPerPlayer = 13;
    
    // Rules constants.
    const int32_t RepetitionLimit = 3;
    const int32_t TimeSinceCaptureLimit = 100; // 100 plys = 50 moves each.
    
    // Can compute an upper-bound for the maximum game length.
    // Assume that one piece is captured per TimeSinceCaptureLimit of moves.
    const int32_t MaxGameLength = TimeSinceCaptureLimit * 2 * (NumPiecesPerPlayer - 4);
    
    // This constant is used to indicate that a location is off board.
    const Square OffBoard = 0;
    
    // This constant is used to indicate that a location is empty.
    const Square Empty = 1;
    
    // This constant is used to indicate that no move was available.
    const Move NoMove = 0;
    
    // Movement directions.
    const std::vector<int32_t> Directions =
    {
        BoardWidth, 1, -BoardWidth, -1,                                  /* Orthogonals */
        BoardWidth + 1, BoardWidth - 1, -BoardWidth + 1, -BoardWidth - 1 /* Diagonals */
    };
    
    // Rotation directions.
    const std::vector<int32_t> Rotations = {
        1,  /* Clockwise */
        -1, /* Anti-Clockwise */
    };
    
    // Cache the Sphinx locations for each player.
    const int32_t Sphinx[2] = { 22, 97 };
    
    // Cache the locations that each player can move to.
    const int32_t CanMove[2][BoardArea] = {
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0,
            0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
            0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
            0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
            0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
            0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
            0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
            0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
            0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        }
    };
    
    const int32_t Dead = -1;
    const int32_t Absorbed = -2;
    
    // Reflections map indicating the index of the resulting laser direction.
    // 1). Incoming direction (index)
    // 2). Piece type (-2)
    // 3). Piece orientation
    // Can take the special Dead or Absorbed values defined above.
    const int32_t Reflections[4][5][4] = {
        {
            { Dead, Dead, Absorbed, Dead },            // Anubis.
            { Dead, 1, 3, Dead },                      // Pyramid.
            { 3, 1, 3, 1 },                            // Scarab.
            { Dead, Dead, Dead, Dead},                 // Pharaoh.
            { Absorbed, Absorbed, Absorbed, Absorbed } // Sphinx.
        },
        {
            { Dead, Dead, Dead, Absorbed },
            { Dead, Dead, 2, 0 },
            { 2, 0, 2, 0 },
            { Dead, Dead, Dead, Dead},
            { Absorbed, Absorbed, Absorbed, Absorbed }
        },
        {
            { Absorbed, Dead, Dead, Dead },
            { 1, Dead, Dead, 3 },
            { 1, 3, 1, 3 },
            { Dead, Dead, Dead, Dead},
            { Absorbed, Absorbed, Absorbed, Absorbed }
        },
        {
            { Dead, Absorbed, Dead, Dead },
            { 0, 2, Dead, Dead },
            { 0, 2, 0, 2 },
            { Dead, Dead, Dead, Dead},
            { Absorbed, Absorbed, Absorbed, Absorbed }
        }
    };
}

#endif // __GLOBALS_H__
