#include "Search.h"
#include "Evaluator.h"
#include "MoveGenerator.h"
#include "MoveHelpers.h"
#include <iostream>
#include <cassert>
#include <climits>

// Iterative deepening framework.
Move Search::Start(TT& table, const SearchParams& params, Board& board, int& score)
{
    const int MaxDepth = 100;
    Move killers[MaxDepth] = { NoMove };

    _stopped = false;
    _params = params;
    _startTime = clock();

    Move bestMove = NoMove, tempMove = NoMove;
    int tempScore;
    bool keepSearching = true;

    History history;

    // Use the default evaluator.
    EvalParams evalParams;
    Evaluator eval(evalParams);
    for (int d = 1; keepSearching && d <= MaxDepth; d++)
    {
        tempMove = AlphaBetaRoot(table, history, killers, eval, board, d, tempScore);
        keepSearching = CheckTime();
        if (keepSearching)
        {
            bestMove = tempMove;
            score = tempScore;

            // Is this mate for either side?
            if (abs(score) == evalParams.CheckmateVal())
            {
                int sign = score > 0 ? 1 : -1;
                MateInfo(d * sign);
                keepSearching = false;
            }
            else
            {
                ScoreInfo(d, score);
            }

            if (_params.Depth() > 0 && d >= _params.Depth())
            {
                keepSearching = false;
            }
        }
    }

    BestMove(bestMove);

    return bestMove;
}

void Search::Stop()
{
    _stopped = true;
}

void Search::ScoreInfo(int depth, int score) const
{
    std::cout << "info"
              << " time " << TimeElapsed() 
              << " depth " << depth
              << " score " << score << std::endl;
}

void Search::MateInfo(int pliesToMate) const
{
    std::cout << "info"
              << " time " << TimeElapsed()
              << " mate " << pliesToMate << std::endl;
}

void Search::BestMove(Move move) const
{
    std::string m = move != NoMove ? ToString(move) : "none";
    std::cout << "bestmove " << m << std::endl;
}

clock_t Search::TimeElapsed() const
{
    clock_t ret = 1000 * (double)(clock() - _startTime) / CLOCKS_PER_SEC;
    // printf("timeElapsed: %lu\n", ret);
    return ret;
}

// Check whether there is still time remaining for this search.
bool Search::CheckTime() const
{
    bool hasTime = true;
    if (!_params.Infinite() && _params.Depth() <= 0)
    {
        hasTime = TimeElapsed() < _params.MoveTime();
    }
    // printf("checkTime: %d\n", hasTime);
    return hasTime && !_stopped;
}

// Initial alpha-beta call which assesses the root nodes and returns the best move.
Move Search::AlphaBetaRoot(TT& table, History& history, Move killers[], const Evaluator& eval, Board& board, int depth, int& score)
{
    score = -eval.MaxScore();
    Move bestMove = NoMove;
    int sign = board.PlayerToMove() == Player::Silver ? 1 : -1;
    if (depth == 0 || board.IsCheckmate() || board.IsDraw())
    {
        score = sign * eval(board);
    }
    else
    {
        MoveGenerator gen(board);
        Move move = NoMove;
        int val;
        const int MaxDepth = depth;
        while ((move = gen.Next()) != NoMove && CheckTime())
        {
            board.MakeMove(move);
            val = -AlphaBeta(table, history, killers, eval, board, depth-1, MaxDepth, -eval.MaxScore(), eval.MaxScore(), -sign);

            board.UndoMove();

            // If this move is better then store the move and score.
            if (val > score)
            {
                score = std::max(score, val);
                bestMove = move;
            }
        }
    }

    // Adjust the score so that it's from silver's perspective.
    score *= sign;

    return bestMove;
}

// Alpha-beta call which returns the value of the specified board state.
int Search::AlphaBeta(TT& table, History& history, Move killers[], const Evaluator& eval, Board& board, int depth, const int MaxDepth, int alpha, int beta, int sign)
{
    int score = -eval.MaxScore();
    if (depth == 0 || board.IsCheckmate() || board.IsDraw())
    {
        score = Quiesce(eval, board, 2, alpha, beta, sign);
    }
    else
    {
        int alphaOrig = alpha;

        // Lookup the current position in the TT.
        Move hashMove = NoMove;
        Entry* e = table.Find(board.HashKey());
        if (e != nullptr && e->Depth >= depth)
        {
            if (e->Type == EntryType::Exact)
                return e->Value;
            else if (e->Type == EntryType::Alpha)
                alpha = std::max(alpha, e->Value);
            else
                beta = std::min(beta, e->Value);

            if (alpha >= beta)
                return e->Value;

            if (e->HashMove != NoMove && board.IsLegal(e->HashMove))
                hashMove = e->HashMove;
        }

        Move killer = killers[MaxDepth - depth];
        if (killer != NoMove && !board.IsLegal(killer))
        {
            killer = NoMove;
        }

        MoveGenerator gen(board, hashMove, killer);
        gen.Sort(MoveGenerator::Stage::Quiet, history);
        Move move = NoMove;
        int val;
        bool inTime = false;
        while ((move = gen.Next()) != NoMove && (inTime = CheckTime()))
        {
            board.MakeMove(move);
            val = -AlphaBeta(table, history, killers, eval, board, depth-1, MaxDepth, -beta, -alpha, -sign);
            board.UndoMove();

            // Update the bounds.
            score = std::max(score, val);;
            alpha = std::max(alpha, val);

            if (alpha >= beta)
            {
                history.IncrementScore(board.PlayerToMove(), move, depth);
                killers[MaxDepth - depth] = move;
                break;
            }
        }

        // Insert the newly evaluated position.
        auto type = score <= alphaOrig ? EntryType::Beta
            : score >= beta ? EntryType::Alpha
            : EntryType::Exact;

        table.Insert(board.HashKey(), type, move, depth, score);
    }

    return score;
}

int Search::Quiesce(const Evaluator& eval, Board& board, int depth, int alpha, int beta, int sign)
{
    int score = sign * eval(board);
    if (depth > 0 && !board.IsCheckmate() && !board.IsDraw())
    {
        alpha = std::max(alpha, score);

        MoveGenerator gen(board, MoveGenerator::Dynamic);
        Move move = NoMove;
        int val;
        while ((move = gen.Next()) != NoMove && alpha < beta && CheckTime())
        {
            board.MakeMove(move);
            val = -Quiesce(eval, board, depth-1, -beta, -alpha, -sign);
            board.UndoMove();

            // Update the bounds.
            score = std::max(score, val);
            alpha = std::max(alpha, val);
        }
    }

    return score;
}
