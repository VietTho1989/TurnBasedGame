#ifndef __PATH_LASER_H__
#define __PATH_LASER_H__

#include "Globals.h"
#include "Laser.h"
#include <cstring>

class PathLaser : public Laser
{
public:
    bool Fire(const Player& player, const ILaserable& board)
    {
        memset(_laserPath, -1, BoardArea*sizeof(int));
        return Laser::Fire(player, board);
    }

    // This method calculates whether a piece will die when the laser is fired after the specified
    // move has been made.
    int FireWillKill(const Player& player, const ILaserable& board, int start, int end, Square finalSq, Square initialEndSq)
    {
       // Find the starting location and direction for the laserbeam.
        int ti = Sphinx[(int)player];
        int ts = Empty;
        int dirIndex = GetOrientation(board.Get(ti));
        while (ts != OffBoard && dirIndex >= 0)
        {
            // Take a step with the laserbeam.
            ti += Directions[dirIndex];

            // Is this location occupied?
            if (ti == start && start != end)
            {
                ts = initialEndSq; // This way we support swaps.
            }
            else if (ti == end)
            {
                ts = finalSq;
            }
            else
            {
                ts = board.Get(ti);
            }

            if (IsPiece(ts))
            {
                int tp = (int)GetPiece(ts);
                dirIndex = Reflections[dirIndex][tp - 2][GetOrientation(ts)];
            }
        }

        return ti;
    }

	void OnStep(int targetIndex, int postDir)
    {
        _laserPath[targetIndex] = postDir;
    }

    inline int PathAt(int loc) const { return _laserPath[loc]; }

private:
    int _laserPath[BoardArea];
};

#endif // __PATH_LASER_H__
