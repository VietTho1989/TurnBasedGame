#ifndef __KHET_LASER_H__
#define __KHET_LASER_H__

#include "khet_Globals.hpp"
#include "khet_ILaserable.hpp"
#include "khet_SquareHelpers.hpp"

namespace Khet
{
    class Laser
    {
    public:
        // Fire the laser for the current player on the specified laserable object and return a boolean
        // indicating whether a piece gets captured.
        virtual bool Fire(const Player&, const ILaserable&);
        virtual void OnStep(int32_t, int32_t);
        
        inline int32_t TargetIndex() const { return _targetIndex; }
        inline Square TargetSquare() const { return _targetSquare; }
        inline int32_t TargetPiece() const { return _targetPiece; }
        
    public:
        int32_t _targetIndex;
        Square _targetSquare;
        int32_t _targetPiece;
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
        static int32_t getByteSize();
        
        static int32_t convertToByteArray(Laser* laser, uint8_t* &byteArray);
        
        static int32_t parseByteArray(Laser* laser, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
    };
}

#endif // __LASER_H__
