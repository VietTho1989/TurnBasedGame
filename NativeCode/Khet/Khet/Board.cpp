#include "Board.h"
#include "MoveHelpers.h"
#include "SquareHelpers.h"
#include "Zobrist.h"
#include "Utils.h"
#include <cassert>
#include <cctype>
#include <cstring>
#include <iostream>

Board::Board(const Board& other)
{
    Init();
    _playerToMove = other._playerToMove;
    memcpy(_hashes, other._hashes, MaxGameLength*sizeof(uint64_t));
    memcpy(_board, other._board, BoardArea*sizeof(Square));
    memcpy(_pharaohPositions, other._pharaohPositions, 2*sizeof(int));
}

Board::Board(const std::string& ks)
{
    Init();
    FromString(ks);
}

// If there is no difference then return zero. 
// The comparison takes into account the squares, the player to move and the hash.
int Board::Compare(const Board& other)
{
    int ret = 0;

    // Compare the board squares.
    for (ret = 1; ret <= BoardArea; ret++)
    {
        if (_board[ret - 1] != other._board[ret - 1]) break;
    }

    if (ret > BoardArea)
    {
        ret = _playerToMove == other._playerToMove && 
            _hashes[_moveNumber] != other._hashes[_moveNumber] ?  -1 : 0;
    }

    return ret;
}

void Board::Init()
{
    memset(_hashes, 0, MaxGameLength*sizeof(uint64_t));
    memset(_captureSquare, Empty, MaxGameLength*sizeof(Square));
    memset(_captureLocation, -1, MaxGameLength*sizeof(int));
    memset(_movesWithoutCapture, 0, MaxGameLength*sizeof(int));
}

bool Board::IsLegal(Move move) const
{
    assert(move != NoMove);
    Square start = _board[GetStart(move)];
    Square end = _board[GetEnd(move)];
    bool endOccupancy;
    bool startOccupancy = IsPiece(start) && GetOwner(start) == _playerToMove;
    if (startOccupancy)
        endOccupancy = end == Empty ||
                       GetRotation(move) != 0 ||
                       (GetPiece(start) == Piece::Scarab && (int)GetPiece(end) < 4);

    return startOccupancy && endOccupancy;
}

void Board::MakeMove(Move move)
{
    assert(move != NoMove);
    assert(!_drawn && !_checkmate);
    assert(IsLegal(move));

    auto z = Zobrist::Instance();
    uint64_t hash = _hashes[_moveNumber++];

    int start = GetStart(move);
    int end = GetEnd(move);
    int rotation = GetRotation(move);

    Square movingPiece = _board[start];
    hash ^= z->Key(movingPiece, start);

    if (rotation != 0)
    {
        movingPiece = Rotate(movingPiece, rotation);
    }

    _board[start] = _board[end];
    _board[end] = movingPiece;
    hash ^= z->Key(movingPiece, end);

    // Update pharaoh positions.
    if (GetPiece(movingPiece) == Piece::Pharaoh)
    {
        _pharaohPositions[(int)_playerToMove] = end;
    }

    // Check whether pieces are captured.
    if (_laser.Fire(_playerToMove, *this))
    {
        _movesWithoutCapture[_moveNumber] = 0;
        _captureSquare[_moveNumber] = _laser.TargetSquare();
        _captureLocation[_moveNumber] = _laser.TargetIndex();
        _board[_laser.TargetIndex()] = Empty;
        _checkmate |= _laser.TargetPiece() == (int)Piece::Pharaoh;
        hash ^= Zobrist::Instance()->Key(_laser.TargetSquare(), _laser.TargetIndex());
    }
    else
    {
        _movesWithoutCapture[_moveNumber] = _movesWithoutCapture[_moveNumber - 1] + 1;
        _captureSquare[_moveNumber] = Empty;
    }

    _playerToMove = _playerToMove == Player::Silver ? Player::Red : Player::Silver;
    hash ^= z->Silver();

    _moves[_moveNumber] = move;
    _hashes[_moveNumber] = hash;

    CheckForDraw();
}

// Note: The move that needs to be undone should already be cached.
void Board::UndoMove()
{
    Move move = _moves[_moveNumber];

    // Restore any captured pieces.
    Square cap = _captureSquare[_moveNumber];
    int capLoc = _captureLocation[_moveNumber];

    --_moveNumber;
    if (cap != Empty)
    {
        _board[capLoc] = cap;
    }

    int start = GetStart(move);
    int end = GetEnd(move);
    int rotation = GetRotation(move);

    Square movedPiece = _board[end];

    if (rotation != 0)
    {
        // Reverse the rotation.
        movedPiece = Rotate(movedPiece, -1*rotation);
    }

    _board[end] = _board[start];
    _board[start] = movedPiece;

    _checkmate = false;
    _drawn = false;
    _playerToMove = _playerToMove == Player::Silver ? Player::Red : Player::Silver;

    // Update pharaoh positions.
    if (GetPiece(movedPiece) == Piece::Pharaoh)
    {
        _pharaohPositions[(int)_playerToMove] = start;
    }
}

// Check whether the game is now drawn.
void Board::CheckForDraw()
{
    // Check for draw by inactivity.
    int movesWithoutCapture = _movesWithoutCapture[_moveNumber];
    _drawn = movesWithoutCapture >= TimeSinceCaptureLimit;
    if (!_drawn)
    {
        // Check for draw by repetition.
        uint64_t repeatHash = _hashes[_moveNumber];
        int numRepeats = 1;
        for (int m = 1; m < movesWithoutCapture && numRepeats < RepetitionLimit; m++)
        {
            numRepeats += _hashes[_moveNumber-m] == repeatHash ? 1 : 0;
        }

        _drawn = numRepeats >= RepetitionLimit;
    }
}

// Serialise the board to a human-readable string.
std::string Board::ToString() const
{
    std::string pieces;
    std::string orientations;

    for (int r = BoardHeight - 1; r > -1; r--)
    {
        for (int c = 0; c < BoardWidth; c++)
        {
            int i = r*BoardWidth + c;
            if (i % BoardWidth == 0)
            {
                pieces += "\n";
                orientations += "\n";
            }

            if (_board[i] == OffBoard)
            {
                pieces += "*";
                orientations += "*";
            }
            else if (_board[i] == Empty)
            {
                pieces += ".";
                orientations += ".";
            }
            else
            {
                Player player = GetOwner(_board[i]);
                Piece piece = GetPiece(_board[i]);
                Orientation orientation = GetOrientation(_board[i]);

                pieces += CharFromPiece(player, piece);
                orientations += std::to_string((int)orientation);
            }
        }
    }

    return pieces + "\n" + orientations;
}

// Initialise the board from the specified Khet string.
void Board::FromString(const std::string& ks)
{
    memset(_board, OffBoard, BoardArea*sizeof(Square));

    auto utils = Utils::GetInstance();
    auto tokens = utils->Split(ks, ' ');
    _playerToMove = tokens[1] == "0" ? Player::Silver : Player::Red;
    _hashes[0] ^= _playerToMove == Player::Silver ? Zobrist::Instance()->Silver() : 0;

    tokens = utils->Split(tokens[0], '/');
    for (size_t i = 0; i < tokens.size(); i++)
    {
        ParseLine(i, tokens[i]);
    }
}

void Board::ParseLine(int index, const std::string& line)
{
    // The zero-th index is the back rank.
    // Also need to take into account padding.
    int boardIndex = BoardWidth * (BoardHeight - index - 2) + 1;

    // Fill the line with empty initially.
    memset(&_board[boardIndex], Empty, (BoardWidth - 2)*sizeof(Square));

    auto z = Zobrist::Instance();
    uint64_t hash = 0;
    for (size_t i = 0; i < line.size(); i++)
    {
        if (isalpha(line[i]))
        {
            // Specifying a piece.
            Player player = isupper(line[i]) ? Player::Silver : Player::Red;
            Piece piece = PieceFromChar(line[i]);

            Orientation orientation;
            if (piece == Piece::Pharaoh)
            {
                orientation = Orientation::Up;
                _pharaohPositions[(int)player] = boardIndex;
            }
            else
            {
                orientation = (Orientation)(line[++i] - 1 - '0');
            }

            Square sq = MakeSquare(player, piece, orientation);
            hash ^= z->Key(sq, boardIndex);
            _board[boardIndex++] = sq;
        }
        else
        {
            // A gap between pieces.
            boardIndex += (line[i] - '0');
        }
    }

    _hashes[0] = hash;
}

Piece Board::PieceFromChar(char c) const
{
    auto p = Piece::Sphinx;

    c = tolower(c);
    if (c == 'a')
        p = Piece::Anubis;
    else if (c == 'p')
        p = Piece::Pyramid;
    else if (c == 's')
        p = Piece::Scarab;
    else if (c == 'k')
        p = Piece::Pharaoh;

    return p;
}

char Board::CharFromPiece(Player player, Piece piece) const
{
    char c = 'x';

    if (piece == Piece::Anubis)
        c = 'a';
    else if (piece == Piece::Pyramid)
        c = 'p';
    else if (piece == Piece::Scarab)
        c = 's';
    else if (piece == Piece::Pharaoh)
        c = 'k';

    return player == Player::Silver ? toupper(c) : c;
}

