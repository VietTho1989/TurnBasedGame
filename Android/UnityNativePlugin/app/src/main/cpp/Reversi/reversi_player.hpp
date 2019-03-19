#ifndef __reversi_PLAYER_H__
#define __reversi_PLAYER_H__

#include "reversi_common.hpp"
#include "reversi_board.hpp"
#include "reversi_openings.hpp"
#include "reversi_endgame.hpp"
#include "reversi_hash.hpp"
#include "reversi_eval.hpp"

namespace Reversi
{
    
    extern Openings* openingBook;
    
    class Player {
        
    private:
        int32_t maxDepth;
        int32_t minDepth;
        int32_t sortDepth;
        int32_t endgameDepth;
        // The last max depth achieved, for entering endgame solver
        int32_t lastMaxDepth;
        
        uint64_t nodes;
        
        Endgame endgameSolver;
        
        // Openings openingBook;
    public:
        bool useBook;
        int32_t percent = 95;
    private:
        int32_t randomScore(int32_t score);
        
    private:
        bool bookExhausted;
        Hash *transpositionTable;

        int32_t turn;
        int32_t timeLimit;
        OthelloTime timeElapsed;

        int32_t getBestMoveIndex(Board &b, MoveList &moves, MoveList &scores, int32_t side,
                                 int32_t depth);
        int32_t pvs(Board &b, int32_t side, int32_t depth, int32_t alpha, int32_t beta, bool passedLast);
        void sortMoves(Board &b, MoveList &legalMoves, int32_t s, int32_t depth,
                       int32_t alpha, bool isPVNode);
        void sortSearch(Board &b, MoveList &moves, MoveList &scores, int32_t side,
                        int32_t depth);
        Move *indexToMove(int32_t m);
        
    public:
        Board game;
        int32_t mySide;
        Eval *evaluater;
        bool otherHeuristic;
        
        Player(Side side);
        ~Player();
        
        Move *doMove(Move *opponentsMove, int32_t msLeft);
        int8_t myDoMove(int32_t msLeft);
        
        void setDepths(int32_t sort, int32_t min, int32_t max, int32_t end);
        uint64_t getNodes();
        void setPosition(bitbrd takenBits, bitbrd blackBits);
    };
}

#endif
