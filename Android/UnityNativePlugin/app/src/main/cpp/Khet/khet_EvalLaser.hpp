#ifndef __KHET_EVAL_LASER_H__
#define __KHET_EVAL_LASER_H__

#include "khet_Globals.hpp"
#include "khet_Laser.hpp"
#include <cstring>
#include <functional>

namespace Khet
{
    class EvalLaser : public Laser
    {
    public:
        bool Fire(const Player& player, const ILaserable& board)
        {
            _pathLength = 0;
            return Laser::Fire(player, board);
        }
        
        void SetStepCallback(std::function<void(int32_t)> callback)
        {
            _callback = callback;
        }
        
        void OnStep(int32_t targetIndex, int32_t postDir)
        {
            ++_pathLength;
            _callback(targetIndex);
        }
        
        inline int32_t PathLength() const { return _pathLength; }
        
    private:
        int32_t _pathLength;
        std::function<void(int32_t)> _callback;
    };
}

#endif // __EVAL_LASER_H__
