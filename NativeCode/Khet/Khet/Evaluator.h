#ifndef __EVALUATOR_H__
#define __EVALUATOR_H__

#include "Board.h"
#include "EvalParams.h"
#include "Globals.h"
#include "EvalLaser.h"

// This class contains methods that are used to evaluate a board position.
class Evaluator
{
public:
    Evaluator();
    Evaluator(const EvalParams&);

    int MaxScore() const { return _params.CheckmateVal(); }
    
    // Evaluate the specified position.
    int operator()(const Board&) const;

private:
    static EvalLaser _laser;
    EvalParams _params;

    int Distance(int, int) const;

    // Check if the board is in a terminal state and score appropriately if so.
    bool TerminalScore(const Board&, int*) const;

    // Compute the material part of the evaluation.
    int MaterialScore(const Board&) const;

    // Compute the "laserability" part of the evaluation.
    int LaserableScore(const Board&) const;

    // Compute the number of laserable squares for the specified player.
    inline int LaserableScore(Player, const Board&) const;
};

#endif // __EVALUATOR_H__
