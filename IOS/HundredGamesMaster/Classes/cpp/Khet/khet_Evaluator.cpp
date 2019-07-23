#include <cstdlib>
#include "khet_Evaluator.hpp"
#include "khet_Globals.hpp"
#include "khet_SquareHelpers.hpp"
#include "../Platform.h"

#ifdef _WIN32
#include <algorithm>
#endif

namespace Khet
{
    // EvalLaser Evaluator::_laser = EvalLaser();
    
    Evaluator::Evaluator()
    {
        _params = EvalParams();
        // init _laser
        if(_laser==NULL){
            _laser = new EvalLaser();
        }else{
            printf("error, why _laser not NULL\n");
        }
    }
    
    Evaluator::Evaluator(const EvalParams& params)
    {
        _params = params;
        // init _laser
        if(_laser==NULL){
            _laser = new EvalLaser();
        }else{
            printf("error, why _laser not NULL\n");
        }
    }
    
    int32_t Evaluator::operator()(const Board& board) const
    {
        int32_t terminalScore = 0;
        if(TerminalScore(board, &terminalScore)){
            return terminalScore;
        }else{
            if(pickBestMove>=0 && pickBestMove<100){
                int32_t vl = MaterialScore(board) + LaserableScore(board);
                // random value
                int32_t randomPercent = fastRandom(100-pickBestMove);
                int32_t newVl = vl - randomPercent*vl/100;
                // printf("EvaluateEVA: %d, %d, %d, %d, %d\n", vlAlpha, vlBeta, vl, randomPercent, newVl);
                return newVl;
            }else{
                // printf("EvaluateEVA: %d, %d, %d\n", vlAlpha, vlBeta, vl);
                return MaterialScore(board) + LaserableScore(board);
            }
        }
        // return TerminalScore(board, &terminalScore) ? terminalScore : MaterialScore(board) + LaserableScore(board);
    }
    
    int32_t Evaluator::Distance(int32_t loc1, int32_t loc2) const
    {
        int32_t xDiff = std::abs((loc1 - loc2) % BoardWidth);
        int32_t yDiff = std::abs((loc1 - loc2) / BoardWidth);
        return std::max(xDiff, yDiff);
    }
    
    bool Evaluator::TerminalScore(const Board& board, int32_t* score) const
    {
        bool terminal = board.IsCheckmate() || board.IsDraw();
        if (terminal)
        {
            *score = board.IsDraw()
            ? 0
            : _params.CheckmateVal() * (GetOwner(board.LastCapture()) == Player::Silver ? -1 : 1);
        }
        
        return terminal;
    }
    
    int32_t Evaluator::MaterialScore(const Board& board) const
    {
        int32_t eval = 0, pieceVal, pharaohVal, pharaohLoc;
        Piece piece;
        Player player;
        Square sq;
        for (size_t i = 0; i < BoardArea; i++)
        {
            sq = board.Get(i);
            if (sq != OffBoard && sq != Empty)
            {
                player = GetOwner(sq);
                piece = GetPiece(sq);
                pieceVal = _params.PieceVal(piece);
                pharaohLoc = board.PharaohPosition(player);
                pharaohVal = piece == Piece::Scarab ? _params.PiecePharaohVal(Distance(i, pharaohLoc)) : 0;
                eval += (pieceVal + pharaohVal) * (player == Player::Silver ? 1 : -1);
            }
        }
        
        return eval;
    }
    
    int32_t Evaluator::LaserableScore(const Board& board) const
    {
        return LaserableScore(Player::Silver, board) - LaserableScore(Player::Red, board);
    }
    
    int32_t Evaluator::LaserableScore(Player player, const Board& board) const
    {
        int32_t bonus = 0;
        Player other = player == Player::Silver ? Player::Red : Player::Silver;
        int32_t enemyPharaoh = board.PharaohPosition(other);
        auto stepCalc = [&] (int32_t loc)
        {
            bonus += _params.LaserPharaohVal(Distance(enemyPharaoh, loc));
        };
        
        _laser->SetStepCallback(stepCalc);
        _laser->Fire(player, board);
        return _params.LaserVal() * _laser->PathLength() + bonus;
    }
}
