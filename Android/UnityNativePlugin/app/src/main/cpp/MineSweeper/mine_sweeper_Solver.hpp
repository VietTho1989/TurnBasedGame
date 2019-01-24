//
// Created by bozai on 20/10/2016.
//

#ifndef MINE_SWEEPER_SOLVER_HPP
#define MINE_SWEEPER_SOLVER_HPP

#include "mine_sweeper_board.hpp"

namespace MineSweeper
{
#define PROBTHRESHOLD 0.21
#define UNKNOWNTHRESHOLD 10
    
    class Solver {
        
        Matrix distToBoundary();
    public:
        Board* board = NULL;
        
        Solver(Board* board1);
        
        bool safeCellExist();
        bool isInitialized();
        Point chooseSafeCell();
        
        //first-move methods
        Point ranFirstMove();
        Point corFirstMove();
        Point cenFirstMove();
        
        //non-decisive methods
        void sim();
        void csp();
        //Point mdp();
        
        //tie-breaking methods, BEST PERFORMANCE: rSimEnuLoClf; rSimEnuLoAw; rSimEnuAwLo
        Point ranTieBreaking();//ran: picks a cell randomly
        vector<Point> lowProb();//Lo: prefers cells c minimizing pm(c)
        
        Point awayFromBoundary();//Aw: prefers cells away from the boundary
        Point awayFromBoundaryAndFringe(); //Awf: prefers cells away from the boundary and the fringe
        Point closeToBoundary();//Cl: prefers cells c close to the boundary
        Point closeToBoundaryAndFringe();//Clf: prefers cells c close the boundary or the fringe
    };
}

#endif //NEWMINESWEEPERAI_SOLVER_H
