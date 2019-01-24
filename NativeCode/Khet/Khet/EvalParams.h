#ifndef __EVAL_PARAMS_H__
#define __EVAL_PARAMS_H__

#include "Globals.h"
#include "Types.h"
#include <cstring>

// Store the parameters which define how the evaluation function is calculated.
class EvalParams
{
public:
    EvalParams()
    {
        // Setup the default parameter configuration.
        // With the piece vals only the Anubis and Pyramid values are significant.
        const int AnubisVal = 500;
        const int PyramidVal = 1000;
        _pieceVals = new int[7] { 0, 0, AnubisVal, PyramidVal, 0, 0, 0 };
        _pieceToPharaohVals = new int[16] 
            { 0, 50, 40, 30, 20, 10, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        _laserToPharaohVals = new int[16] 
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

    inline int PieceVal(Piece p) const { return _pieceVals[(int)p]; }
    inline int PiecePharaohVal(int dist) const { return _pieceToPharaohVals[dist]; }
    inline int LaserPharaohVal(int dist) const { return _laserToPharaohVals[dist]; }
    inline int LaserVal() const { return _laserVal; }
    inline int CheckmateVal() const { return _checkmateVal; }
    
private:
    int* _pieceVals = nullptr;
    int* _pieceToPharaohVals = nullptr;
    int* _laserToPharaohVals = nullptr;
    int _laserVal;
    int _checkmateVal;

    void CopyFrom(const EvalParams& other)
    {
        memcpy(_pieceVals, other._pieceVals, 7*sizeof(int));
        memcpy(_pieceToPharaohVals, other._pieceToPharaohVals, 16*sizeof(int));
        memcpy(_laserToPharaohVals, other._laserToPharaohVals, 16*sizeof(int));
        _laserVal = other._laserVal;
        _checkmateVal = other._checkmateVal;
    }
};

#endif // __EVAL_PARAMS_H__

