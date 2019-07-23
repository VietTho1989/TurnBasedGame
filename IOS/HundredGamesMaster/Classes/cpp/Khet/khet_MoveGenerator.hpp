#ifndef __KHET_MOVE_GENERATOR_H__
#define __KHET_MOVE_GENERATOR_H__

#include "khet_Board.hpp"
#include "khet_Globals.hpp"
#include "khet_History.hpp"
#include "khet_PathLaser.hpp"
#include "khet_Types.hpp"

namespace Khet
{
    // Generate all of the moves for the specified position in order of urgency.
    class MoveGenerator
    {
    public:
        // Which stage of moves we are currently on.
        enum Stage
        {
            Priority = 0,
            Dynamic = 1,
            Quiet = 2,
            Suicide = 3,
            Done = 4
        };
        
        MoveGenerator() = delete;
        MoveGenerator(const Board&, int32_t finalStage = Suicide);
        MoveGenerator(const Board&, Move, Move, int32_t finalStage = Suicide);
        
        // Sort the moves in the specified stage according to historical score.
        void Sort(Stage, const History&);
        
        Move Next();
        
    private:
        bool _passiveCapture = false;
        int32_t _moveIndex = -1;
        int32_t _stage = Priority;
        int32_t _stoppedStage;
        Player _playerToMove;
        PathLaser _laser;
        
        // Maintain a buffer for each stage.
        std::vector<Move> _moveBuffers[Done];
        std::vector<Move>* _currentMoves = &_moveBuffers[Priority];
        
        void AddMove(const Board&, int32_t, int32_t, int32_t);
        
        void NextStage();
        void Generate(const Board&);
        void GenerateAnubisMoves(const Board&, int32_t);
        void GeneratePyramidMoves(const Board&, int32_t);
        void GenerateScarabMoves(const Board&, int32_t);
        void GeneratePharaohMoves(const Board&, int32_t);
        void GenerateSphinxMoves(const Board&, int32_t);
    };
}

#endif // __MOVE_GENERATOR_H__
