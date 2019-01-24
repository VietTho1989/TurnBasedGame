#ifndef __reversi_ENDGAME_H__
#define __reversi_ENDGAME_H__

#include "reversi_common.hpp"
#include "reversi_board.hpp"
#include "reversi_endhash.hpp"
#include "reversi_eval.hpp"
#include "reversi_hash.hpp"

namespace Reversi
{
#define USE_STABILITY false
    
    struct EndgameStatistics;
    
    /**
     * @brief This class contains a large number of functions to help solve the
     * endgame for a game result or perfect play.
     */
    class Endgame {
        
    private:
        EndHash *endgameTable;
        EndHash *killerTable;
        EndHash *allTable;
        Hash *transpositionTable;
        
        Eval *evaluater;
        
        EndgameStatistics *egStats;
        // For replacement strategy in sort search hash table
        int32_t sortBranch;
        
        OthelloTime timeElapsed;
        int32_t timeout;

        int32_t endgameAspiration(Board &b, MoveList &moves, int32_t s, int32_t depth,
                              int32_t alpha, int32_t beta, int32_t &exactScore);
        int32_t dispatch(Board &b, int32_t s, int32_t depth, int32_t alpha, int32_t beta);
        int32_t endgameDeep(Board &b, int32_t s, int32_t depth, int32_t alpha, int32_t beta,
                        bool passedLast);
        int32_t endgameShallow(Board &b, int32_t s, int32_t depth, int32_t alpha, int32_t beta,
                           bool passedLast);
        int32_t endgame4(Board &b, int32_t s, int32_t alpha, int32_t beta, bool passedLast);
        int32_t endgame3(Board &b, int32_t s, int32_t alpha, int32_t beta, bool passedLast);
        int32_t endgame2(Board &b, int32_t s, int32_t alpha, int32_t beta);
        int32_t endgame1(Board &b, int32_t s, int32_t alpha, int32_t legalMove);
        
        void sortSearch(Board &b, MoveList &moves, MoveList &scores, int32_t side,
                        int32_t depth);
        int32_t pvs(Board &b, int32_t side, int32_t depth, int32_t alpha, int32_t beta);

        int32_t nextMoveShallow(int32_t *moves, int32_t *scores, int32_t size, int32_t index);
        
    public:
        uint64_t nodes;
        
        Endgame();
        ~Endgame();

        int32_t solveEndgame(Board &b, MoveList &moves, bool isSorted, int32_t s, int32_t depth,
                             int32_t timeLimit, Eval *eval, int32_t *exactScore = NULL);
        int32_t solveWLD(Board &b, MoveList &moves, bool isSorted, int32_t s, int32_t depth,
                         int32_t timeLimit, Eval *eval, int32_t *exactScore = NULL);
        int32_t solveEndgameWithWindow(Board &b, MoveList &moves, bool isSorted, int32_t s,
                                   int32_t depth, int32_t alpha, int32_t beta, int32_t timeLimit, Eval *eval,
                                   int32_t *exactScore = NULL);
    };
}

#endif
