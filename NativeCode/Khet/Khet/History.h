#ifndef __HISTORY_H__
#define __HISTORY_H__

#include "Globals.h"
#include "MoveHelpers.h"
#include "Types.h"

// This object stores a history of how good each move has proven.
// It is used when ordering moves.
class History
{
public:
    // Get the historical score for the specified move.
    inline int Score(Player player, Move move) const
    {
        return _history[(int)player][GetStart(move)][GetEnd(move)][(GetRotation(move)+1)/2];
    }

    // Increase the score for this move.
    inline void IncrementScore(Player player, Move move, int depth)
    {
        _history[(int)player][GetStart(move)][GetEnd(move)][(GetRotation(move)+1)/2] += depth*depth;
    }

private:
    // The history for each possible move.
    // Indexed by: player to move, start, end, rotation.
    int _history[2][BoardArea][BoardArea][2] = {};
};

#endif // __HISTORY_H__
