#include <cstdlib>
#include "Evaluator.h"
#include "Globals.h"
#include "SquareHelpers.h"

EvalLaser Evaluator::_laser = EvalLaser();

Evaluator::Evaluator()
{
    _params = EvalParams();
}

Evaluator::Evaluator(const EvalParams& params)
{
    _params = params;
}

int Evaluator::operator()(const Board& board) const
{
    int terminalScore = 0;
    return TerminalScore(board, &terminalScore) 
           ? terminalScore
           : MaterialScore(board) + LaserableScore(board);
}

int Evaluator::Distance(int loc1, int loc2) const
{
    int xDiff = std::abs((loc1 - loc2) % BoardWidth);
    int yDiff = std::abs((loc1 - loc2) / BoardWidth);
    return std::max(xDiff, yDiff);
}

bool Evaluator::TerminalScore(const Board& board, int* score) const
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

int Evaluator::MaterialScore(const Board& board) const
{
    int eval = 0, pieceVal, pharaohVal, pharaohLoc;
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

int Evaluator::LaserableScore(const Board& board) const
{
    return LaserableScore(Player::Silver, board) - LaserableScore(Player::Red, board);
}

int Evaluator::LaserableScore(Player player, const Board& board) const
{
    int bonus = 0;
    Player other = player == Player::Silver ? Player::Red : Player::Silver;
    int enemyPharaoh = board.PharaohPosition(other);
    auto stepCalc = [&] (int loc)
    {
        bonus += _params.LaserPharaohVal(Distance(enemyPharaoh, loc));
    };

    _laser.SetStepCallback(stepCalc);
    _laser.Fire(player, board);
    return _params.LaserVal() * _laser.PathLength() + bonus;
}
