#ifndef __EVAL_LASER_H__
#define __EVAL_LASER_H__

#include "Globals.h"
#include "Laser.h"
#include <cstring>
#include <functional>

class EvalLaser : public Laser
{
public:
    bool Fire(const Player& player, const ILaserable& board)
    {
        _pathLength = 0;
        return Laser::Fire(player, board);
    }

    void SetStepCallback(std::function<void(int)> callback)
    {
        _callback = callback;
    }

    void OnStep(int targetIndex, int postDir)
    {
        ++_pathLength;
        _callback(targetIndex);
    }

    inline int PathLength() const { return _pathLength; }

private:
    int _pathLength;
    std::function<void(int)> _callback;
};

#endif // __EVAL_LASER_H__
