#ifndef __KHET_HISTORY_H__
#define __KHET_HISTORY_H__

#include "khet_Globals.hpp"
#include "khet_MoveHelpers.hpp"
#include "khet_Types.hpp"

namespace Khet
{
    // This object stores a history of how good each move has proven.
    // It is used when ordering moves.
    class History
    {
    public:
        // Get the historical score for the specified move.
        inline int32_t Score(Player player, Move move) const
        {
            return _history[(int32_t)player][GetStart(move)][GetEnd(move)][(GetRotation(move)+1)/2];
        }
        
        // Increase the score for this move.
        inline void IncrementScore(Player player, Move move, int32_t depth)
        {
            _history[(int32_t)player][GetStart(move)][GetEnd(move)][(GetRotation(move)+1)/2] += depth*depth;
        }
        
    private:
        // The history for each possible move.
        // Indexed by: player to move, start, end, rotation.
        int32_t _history[2][BoardArea][BoardArea][2] = {};
    };
}

#endif // __HISTORY_H__
