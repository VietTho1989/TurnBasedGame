#ifndef __KHET_BOARD_H__
#define __KHET_BOARD_H__

#include "khet_Globals.hpp"
#include "khet_ILaserable.hpp"
#include "khet_Laser.hpp"
#include "khet_Types.hpp"
#include <string>

namespace Khet
{
    // Represents the Khet board state.
    // Exposes methods for updating the state.
    class Board : public ILaserable
    {
    public:
        Board();
        
        Board(const Board&);
        Board(const std::string&);
        
        int32_t Compare(const Board&);
        bool IsLegal(Move) const;
        
        // Accessors.
        inline Player PlayerToMove() const { return _playerToMove; }
        inline Square Get(int32_t i) const { return _board[i]; }
        inline bool IsCheckmate() const { return _checkmate; }
        inline bool IsDraw() const { return _drawn; }
        inline Square LastCapture() const { return _captureSquare[_moveNumber]; }
        inline uint64_t HashKey() const { return _hashes[_moveNumber]; }
        inline int32_t PharaohPosition(Player player) const { return _pharaohPositions[(int32_t)player]; }
        
        // Making/unmaking moves.
        void MakeMove(Move);
        void UndoMove();
        
        std::string ToString() const;
        
    public:
        Player _playerToMove;
        bool _checkmate = false;
        bool _drawn = false;
        int32_t _moveNumber = 0;
        uint64_t _hashes[MaxGameLength];
        Laser _laser;
        
        // Mailbox style storage is used with one layer of padding.
        Square _board[BoardArea];
        
        // Move list.
        Move _moves[MaxGameLength] = { NoMove };
        
        // The current pharaoh positions.
        int32_t _pharaohPositions[2];
        
        // Cache the capture square and location so that it can be restored.
        Square _captureSquare[MaxGameLength];
        int32_t _captureLocation[MaxGameLength];
        
        // Cache the number of moves since the last capture.
        int32_t _movesWithoutCapture[MaxGameLength];
        
    public:
        void Init();
        
        void CheckForDraw();
        
        void FromString(const std::string&);
        
        void makeFen(char* strFen);
        
        // Serialisation.
        void ParseLine(int32_t, const std::string&);
        Piece PieceFromChar(char) const;
        char CharFromPiece(Player, Piece) const;
        
    public:
        static void Board_Init();
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
        int32_t getByteSize();
        
        static int32_t convertToByteArray(Board* board, uint8_t* &byteArray);
        
        static int32_t parseByteArray(Board* board, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
    };
}

#endif // __BOARD_H__
