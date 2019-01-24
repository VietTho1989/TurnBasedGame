#ifndef __KHET_EVALUATOR_H__
#define __KHET_EVALUATOR_H__

#include "khet_Board.hpp"
#include "khet_EvalParams.hpp"
#include "khet_Globals.hpp"
#include "khet_EvalLaser.hpp"

namespace Khet
{
    // This class contains methods that are used to evaluate a board position.
    class Evaluator
    {
    public:
        Evaluator();
        Evaluator(const EvalParams&);
        
        int32_t MaxScore() const { return _params.CheckmateVal(); }
        
        // Evaluate the specified position.
        int32_t operator()(const Board&) const;
        
    public:
        int32_t pickBestMove = 90;
        
    public:
        // static EvalLaser _laser;
        EvalLaser* _laser = NULL;// TODO Test tam bo static
        
        ~Evaluator()
        {
            if(_laser!=NULL){
                delete _laser;
                _laser = NULL;
            }else{
                printf("error, why _laser NULL\n");
            }
        }
        
        EvalParams _params;
        
        int32_t Distance(int32_t, int32_t) const;
        
        // Check if the board is in a terminal state and score appropriately if so.
        bool TerminalScore(const Board&, int32_t*) const;
        
        // Compute the material part of the evaluation.
        int32_t MaterialScore(const Board&) const;
        
        // Compute the "laserability" part of the evaluation.
        int32_t LaserableScore(const Board&) const;
        
        // Compute the number of laserable squares for the specified player.
        inline int32_t LaserableScore(Player, const Board&) const;
    };
}

#endif // __EVALUATOR_H__
