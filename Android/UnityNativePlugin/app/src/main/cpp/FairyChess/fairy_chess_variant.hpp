/*
  Stockfish, a UCI chess playing engine derived from Glaurung 2.1
  Copyright (C) 2004-2008 Tord Romstad (Glaurung author)
  Copyright (C) 2008-2015 Marco Costalba, Joona Kiiski, Tord Romstad
  Copyright (C) 2015-2018 Marco Costalba, Joona Kiiski, Gary Linscott, Tord Romstad

  Stockfish is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Stockfish is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#ifndef FAIRY_CHESS_VARIANT_HPP_INCLUDED
#define FAIRY_CHESS_VARIANT_HPP_INCLUDED

#include <set>
#include <map>
#include <vector>
#include <string>
#include <functional>

#include "fairy_chess_types.hpp"
#include "fairy_chess_bitboard.hpp"

namespace FairyChess
{
    /// Variant struct stores information needed to determine the rules of a variant.
    
    struct Variant {
        Rank maxRank = RANK_8;
        File maxFile = FILE_H;
        std::set<PieceType> pieceTypes = { PAWN, KNIGHT, BISHOP, ROOK, QUEEN, KING };
        std::string pieceToChar =  " PNBRQ" + std::string(KING - QUEEN - 1, ' ') + "K" + std::string(PIECE_TYPE_NB - KING - 1, ' ')
        + " pnbrq" + std::string(KING - QUEEN - 1, ' ') + "k" + std::string(PIECE_TYPE_NB - KING - 1, ' ');
        std::string startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        Rank promotionRank = RANK_8;
        std::set<PieceType, std::greater<PieceType> > promotionPieceTypes = { QUEEN, ROOK, BISHOP, KNIGHT };
        PieceType promotedPieceType[PIECE_TYPE_NB] = {};
        bool mandatoryPiecePromotion = false;
        bool endgameEval = false;
        bool doubleStep = true;
        bool castling = true;
        bool checking = true;
        bool mustCapture = false;
        bool pieceDrops = false;
        bool dropLoop = false;
        bool capturesToHand = false;
        bool firstRankDrops = false;
        // game end
        Value stalemateValue = VALUE_DRAW;
        Value checkmateValue = -VALUE_MATE;
        Value bareKingValue = VALUE_NONE;
        Value extinctionValue = VALUE_NONE;
        bool bareKingMove = false;
        std::set<PieceType> extinctionPieceTypes = {};
        Bitboard whiteFlag = 0;
        Bitboard blackFlag = 0;
        bool flagMove = false;
        CheckCount maxCheckCount = CheckCount(0);
        
        void add_piece(PieceType pt, char c) {
            pieceToChar[make_piece(WHITE, pt)] = toupper(c);
            pieceToChar[make_piece(BLACK, pt)] = tolower(c);
            pieceTypes.insert(pt);
        }
        
        void remove_piece(PieceType pt) {
            pieceToChar[make_piece(WHITE, pt)] = ' ';
            pieceToChar[make_piece(BLACK, pt)] = ' ';
            pieceTypes.erase(pt);
        }
        
        void reset_pieces() {
            pieceToChar = std::string(PIECE_NB, ' ');
            pieceTypes.clear();
        }
    };
    
    struct VariantMap : public std::map<std::string, const Variant*> {
        void init();
        void add(std::string s, const Variant* v);
        void clear_all();
        std::vector<std::string> get_keys();
    };
    
    extern VariantMap variants;
    
    enum VariantType
    {
        chess,
        standard,
        makruk,
        asean,
        ai_wok,
        shatranj,
        amazon,
        hoppelpoppel,
        kingofthehill,
        racingkings,
        losers,
        giveaway,
        antichess,
        extinction,
        kinglet,
        three_check,
        five_check,
        crazyhouse,
        loop,
        chessgi,
        pocketknight,
        euroshogi,
        judkinshogi,
        minishogi,
        losalamos,
        almost,
        chigorin,
        shatar
    };
    
    void getStartFen(char* ret, VariantType variantType);
    
    const Variant* getVariantByType(VariantType variantType);
    
    VariantType getVariantTypeByVar(const Variant* var);
    
    void getStrVariant(char* ret, const Variant* var);
    
}

#endif // #ifndef VARIANT_H_INCLUDED
