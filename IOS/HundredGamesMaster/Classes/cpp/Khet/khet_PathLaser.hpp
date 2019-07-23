#ifndef __KHET_PATH_LASER_H__
#define __KHET_PATH_LASER_H__

#include "khet_Globals.hpp"
#include "khet_Laser.hpp"
#include <cstring>

namespace Khet
{
    class PathLaser : public Laser
    {
    public:
        bool Fire(const Player& player, const ILaserable& board)
        {
            memset(_laserPath, -1, BoardArea*sizeof(int32_t));
            return Laser::Fire(player, board);
        }
        
        // This method calculates whether a piece will die when the laser is fired after the specified
        // move has been made.
        int32_t FireWillKill(const Player& player, const ILaserable& board, int32_t start, int32_t end, Square finalSq, Square initialEndSq)
        {
            // Find the starting location and direction for the laserbeam.
            int32_t ti = Sphinx[(int32_t)player];
            int32_t ts = Empty;
            int32_t dirIndex = GetOrientation(board.Get(ti));
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
                    int32_t tp = (int32_t)GetPiece(ts);
                    dirIndex = Reflections[dirIndex][tp - 2][GetOrientation(ts)];
                }
            }
            
            return ti;
        }
        
        void OnStep(int32_t targetIndex, int32_t postDir)
        {
            // printf("laserPath: %d, %d\n", targetIndex, postDir);
            _laserPath[targetIndex] = postDir;
        }
        
        inline int32_t PathAt(int32_t loc) const { return _laserPath[loc]; }
        
    public:
        int32_t _laserPath[BoardArea];
    };
    
    class MyPathLaser : public Laser
    {
    public:
        bool Fire(const Player& player, const ILaserable& board)
        {
            _laserPath.clear();
            return Laser::Fire(player, board);
        }
        
        // This method calculates whether a piece will die when the laser is fired after the specified
        // move has been made.
        int32_t FireWillKill(const Player& player, const ILaserable& board, int32_t start, int32_t end, Square finalSq, Square initialEndSq)
        {
            // Find the starting location and direction for the laserbeam.
            int32_t ti = Sphinx[(int32_t)player];
            int32_t ts = Empty;
            int32_t dirIndex = GetOrientation(board.Get(ti));
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
                    int32_t tp = (int32_t)GetPiece(ts);
                    dirIndex = Reflections[dirIndex][tp - 2][GetOrientation(ts)];
                }
            }
            
            return ti;
        }
        
        void OnStep(int32_t targetIndex, int32_t postDir)
        {
            // printf("laserPath: %d, %d\n", targetIndex, postDir);
            _laserPath.push_back(targetIndex);
        }
        
    public:
        std::vector<int> _laserPath;
    };
    
}

#endif // __PATH_LASER_H__
