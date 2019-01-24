#ifndef __KHET_EVAL_PARAMS_H__
#define __KHET_EVAL_PARAMS_H__

#include "khet_Globals.hpp"
#include "khet_Types.hpp"
#include <cstring>

namespace Khet
{
    // Store the parameters which define how the evaluation function is calculated.
    class EvalParams
    {
    public:
        EvalParams()
        {
            // Setup the default parameter configuration.
            // With the piece vals only the Anubis and Pyramid values are significant.
            const int32_t AnubisVal = 500;
            const int32_t PyramidVal = 1000;
            _pieceVals = new int32_t[7] { 0, 0, AnubisVal, PyramidVal, 0, 0, 0 };
            _pieceToPharaohVals = new int32_t[16]
            { 0, 50, 40, 30, 20, 10, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            _laserToPharaohVals = new int32_t[16]
            { 0, 200, 50, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            _laserVal = 20;
            
            // This evaluation is only attainable if a player is in checkmate.
            _checkmateVal = 1000000;
        }
        
        ~EvalParams()
        {
            if (_pieceVals != nullptr)
            {
                delete _pieceVals;
                _pieceVals = nullptr;
            }
            
            if (_pieceToPharaohVals != nullptr)
            {
                delete _pieceToPharaohVals;
                _pieceToPharaohVals = nullptr;
            }
            
            if (_laserToPharaohVals != nullptr)
            {
                delete _laserToPharaohVals;
                _laserToPharaohVals = nullptr;
            }
        }
        
        EvalParams(const EvalParams& other)
        {
            CopyFrom(other);
        }
        
        EvalParams& operator=(const EvalParams& other)
        {
            if (this != &other)
            {
                CopyFrom(other);
            }
            
            return *this;
        }
        
        inline int32_t PieceVal(Piece p) const { return _pieceVals[(int32_t)p]; }
        inline int32_t PiecePharaohVal(int32_t dist) const { return _pieceToPharaohVals[dist]; }
        inline int32_t LaserPharaohVal(int32_t dist) const { return _laserToPharaohVals[dist]; }
        inline int32_t LaserVal() const { return _laserVal; }
        inline int32_t CheckmateVal() const { return _checkmateVal; }
        
    private:
        int32_t* _pieceVals = nullptr;
        int32_t* _pieceToPharaohVals = nullptr;
        int32_t* _laserToPharaohVals = nullptr;
        int32_t _laserVal;
        int32_t _checkmateVal;
        
        void CopyFrom(const EvalParams& other)
        {
            memcpy(_pieceVals, other._pieceVals, 7*sizeof(int32_t));
            memcpy(_pieceToPharaohVals, other._pieceToPharaohVals, 16*sizeof(int32_t));
            memcpy(_laserToPharaohVals, other._laserToPharaohVals, 16*sizeof(int32_t));
            _laserVal = other._laserVal;
            _checkmateVal = other._checkmateVal;
        }
    };
}

#endif // __EVAL_PARAMS_H__
