//
//  endgame.cpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <algorithm>
#include <cassert>

#include "shatranj_endgame.hpp"
#include "shatranj_bitboard.hpp"
#include "shatranj_movegen.hpp"

using std::string;
using namespace std;

namespace Shatranj
{
    namespace {
        
        // Table used to drive the king towards the edge of the board
        // in KX vs K and KQ vs KR endgames.
        const int32_t PushToEdges[SQUARE_NB] = {
            100, 90, 80, 70, 70, 80, 90, 100,
            90, 70, 60, 50, 50, 60, 70,  90,
            80, 60, 40, 30, 30, 40, 60,  80,
            70, 50, 30, 20, 20, 30, 50,  70,
            70, 50, 30, 20, 20, 30, 50,  70,
            80, 60, 40, 30, 30, 40, 60,  80,
            90, 70, 60, 50, 50, 60, 70,  90,
            100, 90, 80, 70, 70, 80, 90, 100
        };
        
        // Tables used to drive a piece towards or away from another piece
        const int32_t PushClose[8] = { 0, 0, 100, 80, 60, 40, 20, 10 };
        const int32_t PushAway [8] = { 0, 5, 20, 40, 60, 80, 90, 100 };
        
        // Pawn Rank based scaling factors used in KRPPKRP endgame
        const int32_t KRPPKRPScaleFactors[RANK_NB] = { 0, 9, 10, 14, 21, 44, 0, 0 };
        
// #ifndef NDEBUG
        bool verify_material(const Position& pos, Color c, Value npm, int32_t pawnsCnt) {
            return pos.non_pawn_material(c) == npm && pos.count<PAWN>(c) == pawnsCnt;
        }
// #endif
        
        // Map the square as if strongSide is white and strongSide's only pawn
        // is on the left half of the board.
        Square normalize(const Position& pos, Color strongSide, Square sq) {
            
            // assert(pos.count<PAWN>(strongSide) == 1);
            if(!(pos.count<PAWN>(strongSide) == 1)){
                printf("error, assert(pos.count<PAWN>(strongSide) == 1)\n");
            }
            
            if (file_of(pos.square<PAWN>(strongSide)) >= FILE_E)
                sq = Square(sq ^ 7); // Mirror SQ_H1 -> SQ_A1
            
            if (strongSide == BLACK)
                sq = ~sq;
            
            return sq;
        }
        
    } // namespace
    
    
    /// Endgames members definitions
    
    Endgames::Endgames() {
        
        add<KRKP>("KRKP");
        add<KRKB>("KRKB");
        add<KRKN>("KRKN");
        add<KNKB>("KNKB");
        add<KQKP>("KQKP");
        add<KRKQ>("KRKQ");
        add<KPKP>("KPKP");
        add<KQQKQ>("KQQKQ");
        
        add<KNPKB>("KNPKB");
        add<KRPKR>("KRPKR");
        add<KBPKB>("KBPKB");
        add<KBPKN>("KBPKN");
        add<KBPPKB>("KBPPKB");
        add<KRPPKRP>("KRPPKRP");
    }
    
    /// KR vs KP.
    template<> Value Endgame<KRKP>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, RookValueMg, 0));
        if(!(verify_material(pos, strongSide, RookValueMg, 0))){
            printf("error, assert(verify_material(pos, strongSide, RookValueMg, 0))\n");
        }
        // assert(verify_material(pos, weakSide, VALUE_ZERO, 1));
        if(!(verify_material(pos, weakSide, VALUE_ZERO, 1))){
            printf("error, assert(verify_material(pos, weakSide, VALUE_ZERO, 1))\n");
        }
        
        Square wksq = relative_square(strongSide, pos.square<KING>(strongSide));
        Square psq  = relative_square(strongSide, pos.square<PAWN>(weakSide));
        
        Value result = RookValueEg - distance(wksq, psq);
        
        return strongSide == pos.side_to_move() ? result : -result;
    }
    
    
    /// KR vs KB.
    template<> Value Endgame<KRKB>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, RookValueMg, 0));
        if(!(verify_material(pos, strongSide, RookValueMg, 0))){
            printf("error, assert(verify_material(pos, strongSide, RookValueMg, 0))\n");
        }
        // assert(verify_material(pos, weakSide, BishopValueMg, 0));
        if(!(verify_material(pos, weakSide, BishopValueMg, 0))){
            printf("error, assert(verify_material(pos, weakSide, BishopValueMg, 0))\n");
        }
        
        Square winnerKSq = pos.square<KING>(strongSide);
        Square loserKSq = pos.square<KING>(weakSide);
        
        Value result =  RookValueEg
        - BishopValueEg
        + PushToEdges[loserKSq]
        + PushClose[distance(winnerKSq, loserKSq)];
        
        return strongSide == pos.side_to_move() ? result : -result;
    }
    
    
    /// KR vs KN. The attacking side has some winning chances,
    /// particularly if the king and the knight are far apart.
    template<> Value Endgame<KRKN>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, RookValueMg, 0));
        if(!(verify_material(pos, strongSide, RookValueMg, 0))){
            printf("error, assert(verify_material(pos, strongSide, RookValueMg, 0))\n");
        }
        // assert(verify_material(pos, weakSide, KnightValueMg, 0));
        if(!(verify_material(pos, weakSide, KnightValueMg, 0))){
            printf("error, assert(verify_material(pos, weakSide, KnightValueMg, 0))\n");
        }
        
        Square bksq = pos.square<KING>(weakSide);
        Square bnsq = pos.square<KNIGHT>(weakSide);
        Value result = Value(PushToEdges[bksq] + PushAway[distance(bksq, bnsq)]);
        return strongSide == pos.side_to_move() ? result : -result;
    }
    
    
    /// KN vs KB. Drawish.
    template<> Value Endgame<KNKB>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, KnightValueMg, 0));
        if(!(verify_material(pos, strongSide, KnightValueMg, 0))){
            printf("error, assert(verify_material(pos, strongSide, KnightValueMg, 0))\n");
        }
        // assert(verify_material(pos, weakSide, BishopValueMg, 0));
        if(!(verify_material(pos, weakSide, BishopValueMg, 0))){
            printf("error, assert(verify_material(pos, weakSide, BishopValueMg, 0))\n");
        }
        
        Square wksq = pos.square<KING>(strongSide);
        Square wnsq = pos.square<KNIGHT>(strongSide);
        Square bksq = pos.square<KING>(weakSide);
        Square bbsq = pos.square<BISHOP>(weakSide);
        
        Value result =  Value(PushToEdges[bbsq])
        + PushClose[distance(wksq, bbsq)]
        + PushClose[distance(wnsq, bbsq)]
        + PushAway[distance(bksq, bbsq)];
        
        return strongSide == pos.side_to_move() ? result : -result;
    }
    
    
    /// KQ vs KP.
    template<> Value Endgame<KQKP>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, QueenValueMg, 0));
        if(!(verify_material(pos, strongSide, QueenValueMg, 0))){
            printf("error, assert(verify_material(pos, strongSide, QueenValueMg, 0))\n");
        }
        // assert(verify_material(pos, weakSide, VALUE_ZERO, 1));
        if(!(verify_material(pos, weakSide, VALUE_ZERO, 1))){
            printf("error, assert(verify_material(pos, weakSide, VALUE_ZERO, 1))\n");
        }
        
        Square winnerKSq = pos.square<KING>(strongSide);
        Square queenSq = pos.square<QUEEN>(strongSide);
        Square pawnSq = pos.square<PAWN>(weakSide);
        
        Value result =  QueenValueEg
        + PushClose[distance(winnerKSq, pawnSq)]
        + PushClose[distance(winnerKSq, queenSq)];
        
        return strongSide == pos.side_to_move() ? result : -result;
    }
    
    
    /// KR vs KQ.
    template<> Value Endgame<KRKQ>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, RookValueMg, 0));
        if(!(verify_material(pos, strongSide, RookValueMg, 0))){
            printf("error, assert(verify_material(pos, strongSide, RookValueMg, 0))\n");
        }
        // assert(verify_material(pos, weakSide, QueenValueMg, 0));
        if(!(verify_material(pos, weakSide, QueenValueMg, 0))){
            printf("error, assert(verify_material(pos, weakSide, QueenValueMg, 0))\n");
        }
        
        Square winnerKSq = pos.square<KING>(strongSide);
        Square loserKSq = pos.square<KING>(weakSide);
        
        Value result =  RookValueEg
        - QueenValueEg
        + PushToEdges[loserKSq]
        + PushClose[distance(winnerKSq, loserKSq)];
        
        return strongSide == pos.side_to_move() ? result : -result;
    }
    
    /// KQQ vs KQ.
    template<> Value Endgame<KQQKQ>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, 2 * QueenValueMg, 0));
        if(!(verify_material(pos, strongSide, 2 * QueenValueMg, 0))){
            printf("error, assert(verify_material(pos, strongSide, 2 * QueenValueMg, 0))\n");
        }
        // assert(verify_material(pos, weakSide, QueenValueMg, 0));
        if(!(verify_material(pos, weakSide, QueenValueMg, 0))){
            printf("error, assert(verify_material(pos, weakSide, QueenValueMg, 0))\n");
        }
        
        Square wksq = pos.square<KING>(strongSide);
        Square bksq = pos.square<KING>(weakSide);
        Square bqsq = pos.square<QUEEN>(weakSide);
        
        Value result =  Value(PushToEdges[bqsq])
        + PushToEdges[bksq]
        + PushClose[distance(wksq, bqsq)]
        + PushAway[distance(bksq, bqsq)];
        
        if (!(pos.pieces(QUEEN) & DarkSquares) || !(pos.pieces(QUEEN) & ~DarkSquares))
            result += VALUE_KNOWN_WIN;
        
        return strongSide == pos.side_to_move() ? result : -result;
    }
    
    /// KP vs KP.
    template<> Value Endgame<KPKP>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, VALUE_ZERO, 1));
        if(!(verify_material(pos, strongSide, VALUE_ZERO, 1))){
            printf("error, assert(verify_material(pos, strongSide, VALUE_ZERO, 1))\n");
        }
        // assert(verify_material(pos, weakSide,   VALUE_ZERO, 1));
        if(!(verify_material(pos, weakSide,   VALUE_ZERO, 1))){
            printf("error, assert(verify_material(pos, weakSide,   VALUE_ZERO, 1))\n");
        }
        
        // Assume strongSide is white and the pawn is on files A-D
        Square wksq = normalize(pos, strongSide, pos.square<KING>(strongSide));
        Square bksq = normalize(pos, strongSide, pos.square<KING>(weakSide));
        Square wpsq = normalize(pos, strongSide, pos.square<PAWN>(strongSide));
        Square bpsq = normalize(pos, strongSide, pos.square<PAWN>(weakSide));
        
        Value result =  Value(PushClose[distance(wksq, bpsq)])
        - Value(PushClose[distance(bksq, wpsq)]);
        
        return strongSide == pos.side_to_move() ? result : -result;
    }
    
    
    /// KRP vs KR. This function knows a handful of the most important classes of
    /// drawn positions, but is far from perfect. It would probably be a good idea
    /// to add more knowledge in the future.
    ///
    /// It would also be nice to rewrite the actual code for this function,
    /// which is mostly copied from Glaurung 1.x, and isn't very pretty.
    template<> ScaleFactor Endgame<KRPKR>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, RookValueMg, 1));
        if(!(verify_material(pos, strongSide, RookValueMg, 1))){
            printf("error, assert(verify_material(pos, strongSide, RookValueMg, 1))\n");
        }
        // assert(verify_material(pos, weakSide,   RookValueMg, 0));
        if(!(verify_material(pos, weakSide,   RookValueMg, 0))){
            printf("error, assert(verify_material(pos, weakSide,   RookValueMg, 0))\n");
        }
        
        // Assume strongSide is white and the pawn is on files A-D
        Square wksq = normalize(pos, strongSide, pos.square<KING>(strongSide));
        Square bksq = normalize(pos, strongSide, pos.square<KING>(weakSide));
        Square wrsq = normalize(pos, strongSide, pos.square<ROOK>(strongSide));
        Square wpsq = normalize(pos, strongSide, pos.square<PAWN>(strongSide));
        Square brsq = normalize(pos, strongSide, pos.square<ROOK>(weakSide));
        
        File f = file_of(wpsq);
        Rank r = rank_of(wpsq);
        Square queeningSq = make_square(f, RANK_8);
        int32_t tempo = (pos.side_to_move() == strongSide);
        
        // If the pawn is not too far advanced and the defending king defends the
        // queening square, use the third-rank defence.
        if (   r <= RANK_5
            && distance(bksq, queeningSq) <= 1
            && wksq <= SQ_H5
            && (rank_of(brsq) == RANK_6 || (r <= RANK_3 && rank_of(wrsq) != RANK_6)))
            return SCALE_FACTOR_DRAW;
        
        // The defending side saves a draw by checking from behind in case the pawn
        // has advanced to the 6th rank with the king behind.
        if (   r == RANK_6
            && distance(bksq, queeningSq) <= 1
            && rank_of(wksq) + tempo <= RANK_6
            && (rank_of(brsq) == RANK_1 || (!tempo && distanceT<File>(brsq, wpsq) >= 3)))
            return SCALE_FACTOR_DRAW;
        
        if (   r >= RANK_6
            && bksq == queeningSq
            && rank_of(brsq) == RANK_1
            && (!tempo || distance(wksq, wpsq) >= 2))
            return SCALE_FACTOR_DRAW;
        
        // White pawn on a7 and rook on a8 is a draw if black's king is on g7 or h7
        // and the black rook is behind the pawn.
        if (   wpsq == SQ_A7
            && wrsq == SQ_A8
            && (bksq == SQ_H7 || bksq == SQ_G7)
            && file_of(brsq) == FILE_A
            && (rank_of(brsq) <= RANK_3 || file_of(wksq) >= FILE_D || rank_of(wksq) <= RANK_5))
            return SCALE_FACTOR_DRAW;
        
        // If the defending king blocks the pawn and the attacking king is too far
        // away, it's a draw.
        if (   r <= RANK_5
            && bksq == wpsq + NORTH
            && distance(wksq, wpsq) - tempo >= 2
            && distance(wksq, brsq) - tempo >= 2)
            return SCALE_FACTOR_DRAW;
        
        // Pawn on the 7th rank supported by the rook from behind usually wins if the
        // attacking king is closer to the queening square than the defending king,
        // and the defending king cannot gain tempi by threatening the attacking rook.
        if (   r == RANK_7
            && f != FILE_A
            && file_of(wrsq) == f
            && wrsq != queeningSq
            && (distance(wksq, queeningSq) < distance(bksq, queeningSq) - 2 + tempo)
            && (distance(wksq, queeningSq) < distance(bksq, wrsq) + tempo))
            return ScaleFactor(SCALE_FACTOR_MAX - 2 * distance(wksq, queeningSq));
        
        // Similar to the above, but with the pawn further back
        if (   f != FILE_A
            && file_of(wrsq) == f
            && wrsq < wpsq
            && (distance(wksq, queeningSq) < distance(bksq, queeningSq) - 2 + tempo)
            && (distance(wksq, wpsq + NORTH) < distance(bksq, wpsq + NORTH) - 2 + tempo)
            && (  distance(bksq, wrsq) + tempo >= 3
                || (    distance(wksq, queeningSq) < distance(bksq, wrsq) + tempo
                    && (distance(wksq, wpsq + NORTH) < distance(bksq, wrsq) + tempo))))
            return ScaleFactor(  SCALE_FACTOR_MAX
                               - 8 * distance(wpsq, queeningSq)
                               - 2 * distance(wksq, queeningSq));
        
        // If the pawn is not far advanced and the defending king is somewhere in
        // the pawn's path, it's probably a draw.
        if (r <= RANK_4 && bksq > wpsq)
        {
            if (file_of(bksq) == file_of(wpsq))
                return ScaleFactor(10);
            if (   distanceT<File>(bksq, wpsq) == 1
                && distance(wksq, bksq) > 2)
                return ScaleFactor(24 - 2 * distance(wksq, bksq));
        }
        return SCALE_FACTOR_NONE;
    }
    
    
    /// KRPP vs KRP. There is just a single rule: if the stronger side has no passed
    /// pawns and the defending king is actively placed, the position is drawish.
    template<> ScaleFactor Endgame<KRPPKRP>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, RookValueMg, 2));
        if(!(verify_material(pos, strongSide, RookValueMg, 2))){
            printf("error, assert(verify_material(pos, strongSide, RookValueMg, 2))\n");
        }
        // assert(verify_material(pos, weakSide,   RookValueMg, 1));
        if(!(verify_material(pos, weakSide,   RookValueMg, 1))){
            printf("error, assert(verify_material(pos, weakSide,   RookValueMg, 1))\n");
        }
        
        Square wpsq1 = pos.squares<PAWN>(strongSide)[0];
        Square wpsq2 = pos.squares<PAWN>(strongSide)[1];
        Square bksq = pos.square<KING>(weakSide);
        
        // Does the stronger side have a passed pawn?
        if (pos.pawn_passed(strongSide, wpsq1) || pos.pawn_passed(strongSide, wpsq2))
            return SCALE_FACTOR_NONE;
        
        Rank r = max(relative_rank(strongSide, wpsq1), relative_rank(strongSide, wpsq2));
        
        if (   distanceT<File>(bksq, wpsq1) <= 1
            && distanceT<File>(bksq, wpsq2) <= 1
            && relative_rank(strongSide, bksq) > r)
        {
            // assert(r > RANK_1 && r < RANK_7);
            if(!(r > RANK_1 && r < RANK_7)){
                printf("error, assert(r > RANK_1 && r < RANK_7)\n");
            }
            return ScaleFactor(KRPPKRPScaleFactors[r]);
        }
        return SCALE_FACTOR_NONE;
    }
    
    
    /// KBP vs KB. There are two rules: if the defending king is somewhere along the
    /// path of the pawn, and the square of the king is not of the same color as the
    /// stronger side's bishop, it's a draw. If the two bishops have opposite color,
    /// it's almost always a draw.
    template<> ScaleFactor Endgame<KBPKB>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, BishopValueMg, 1));
        if(!(verify_material(pos, strongSide, BishopValueMg, 1))){
            printf("error, assert(verify_material(pos, strongSide, BishopValueMg, 1))\n");
        }
        // assert(verify_material(pos, weakSide,   BishopValueMg, 0));
        if(!(verify_material(pos, weakSide,   BishopValueMg, 0))){
            printf("error, assert(verify_material(pos, weakSide,   BishopValueMg, 0))\n");
        }
        
        Square pawnSq = pos.square<PAWN>(strongSide);
        Square strongBishopSq = pos.square<BISHOP>(strongSide);
        Square weakBishopSq = pos.square<BISHOP>(weakSide);
        Square weakKingSq = pos.square<KING>(weakSide);
        
        // Case 1: Defending king blocks the pawn, and cannot be driven away
        if (   file_of(weakKingSq) == file_of(pawnSq)
            && relative_rank(strongSide, pawnSq) < relative_rank(strongSide, weakKingSq)
            && (   opposite_colors(weakKingSq, strongBishopSq)
                || relative_rank(strongSide, weakKingSq) <= RANK_6))
            return SCALE_FACTOR_DRAW;
        
        // Case 2: Opposite colored bishops
        if (opposite_colors(strongBishopSq, weakBishopSq))
        {
            // We assume that the position is drawn in the following three situations:
            //
            //   a. The pawn is on rank 5 or further back.
            //   b. The defending king is somewhere in the pawn's path.
            //   c. The defending bishop attacks some square along the pawn's path,
            //      and is at least three squares away from the pawn.
            //
            // These rules are probably not perfect, but in practice they work
            // reasonably well.
            
            if (relative_rank(strongSide, pawnSq) <= RANK_5)
                return SCALE_FACTOR_DRAW;
            
            Bitboard path = forward_file_bb(strongSide, pawnSq);
            
            if (path & pos.pieces(weakSide, KING))
                return SCALE_FACTOR_DRAW;
            
            if (  (pos.attacks_from<BISHOP>(weakBishopSq) & path)
                && distance(weakBishopSq, pawnSq) >= 3)
                return SCALE_FACTOR_DRAW;
        }
        return SCALE_FACTOR_NONE;
    }
    
    
    /// KBPP vs KB. It detects a few basic draws with opposite-colored bishops
    template<> ScaleFactor Endgame<KBPPKB>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, BishopValueMg, 2));
        if(!(verify_material(pos, strongSide, BishopValueMg, 2))){
            printf("error, assert(verify_material(pos, strongSide, BishopValueMg, 2))\n");
        }
        // assert(verify_material(pos, weakSide,   BishopValueMg, 0));
        if(!(verify_material(pos, weakSide,   BishopValueMg, 0))){
            printf("error, assert(verify_material(pos, weakSide,   BishopValueMg, 0))\n");
        }
        
        Square wbsq = pos.square<BISHOP>(strongSide);
        Square bbsq = pos.square<BISHOP>(weakSide);
        
        if (!opposite_colors(wbsq, bbsq))
            return SCALE_FACTOR_NONE;
        
        Square ksq = pos.square<KING>(weakSide);
        Square psq1 = pos.squares<PAWN>(strongSide)[0];
        Square psq2 = pos.squares<PAWN>(strongSide)[1];
        Rank r1 = rank_of(psq1);
        Rank r2 = rank_of(psq2);
        Square blockSq1, blockSq2;
        
        if (relative_rank(strongSide, psq1) > relative_rank(strongSide, psq2))
        {
            blockSq1 = psq1 + pawn_push(strongSide);
            blockSq2 = make_square(file_of(psq2), rank_of(psq1));
        }
        else
        {
            blockSq1 = psq2 + pawn_push(strongSide);
            blockSq2 = make_square(file_of(psq1), rank_of(psq2));
        }
        
        switch (distanceT<File>(psq1, psq2))
        {
            case 0:
                // Both pawns are on the same file. It's an easy draw if the defender firmly
                // controls some square in the frontmost pawn's path.
                if (   file_of(ksq) == file_of(blockSq1)
                    && relative_rank(strongSide, ksq) >= relative_rank(strongSide, blockSq1)
                    && opposite_colors(ksq, wbsq))
                    return SCALE_FACTOR_DRAW;
                else
                    return SCALE_FACTOR_NONE;
                
            case 1:
                // Pawns on adjacent files. It's a draw if the defender firmly controls the
                // square in front of the frontmost pawn's path, and the square diagonally
                // behind this square on the file of the other pawn.
                if (   ksq == blockSq1
                    && opposite_colors(ksq, wbsq)
                    && (   bbsq == blockSq2
                        || (pos.attacks_from<BISHOP>(blockSq2) & pos.pieces(weakSide, BISHOP))
                        || distance(r1, r2) >= 2))
                    return SCALE_FACTOR_DRAW;
                
                else if (   ksq == blockSq2
                         && opposite_colors(ksq, wbsq)
                         && (   bbsq == blockSq1
                             || (pos.attacks_from<BISHOP>(blockSq1) & pos.pieces(weakSide, BISHOP))))
                    return SCALE_FACTOR_DRAW;
                else
                    return SCALE_FACTOR_NONE;
                
            default:
                // The pawns are not on the same file or adjacent files. No scaling.
                return SCALE_FACTOR_NONE;
        }
    }
    
    
    /// KBP vs KN. There is a single rule: If the defending king is somewhere along
    /// the path of the pawn, and the square of the king is not of the same color as
    /// the stronger side's bishop, it's a draw.
    template<> ScaleFactor Endgame<KBPKN>::operator()(const Position& pos) const {
        
        // assert(verify_material(pos, strongSide, BishopValueMg, 1));
        if(!(verify_material(pos, strongSide, BishopValueMg, 1))){
            printf("error, assert(verify_material(pos, strongSide, BishopValueMg, 1))\n");
        }
        // assert(verify_material(pos, weakSide, KnightValueMg, 0));
        if(!(verify_material(pos, weakSide, KnightValueMg, 0))){
            printf("error, assert(verify_material(pos, weakSide, KnightValueMg, 0))\n");
        }
        
        Square pawnSq = pos.square<PAWN>(strongSide);
        Square strongBishopSq = pos.square<BISHOP>(strongSide);
        Square weakKingSq = pos.square<KING>(weakSide);
        
        if (   file_of(weakKingSq) == file_of(pawnSq)
            && relative_rank(strongSide, pawnSq) < relative_rank(strongSide, weakKingSq)
            && (   opposite_colors(weakKingSq, strongBishopSq)
                || relative_rank(strongSide, weakKingSq) <= RANK_6))
            return SCALE_FACTOR_DRAW;
        
        return SCALE_FACTOR_NONE;
    }
    
    
    /// KNP vs KB. If knight can block bishop from taking pawn, it's a win.
    /// Otherwise the position is drawn.
    template<> ScaleFactor Endgame<KNPKB>::operator()(const Position& pos) const {
        
        Square pawnSq = pos.square<PAWN>(strongSide);
        Square bishopSq = pos.square<BISHOP>(weakSide);
        Square weakKingSq = pos.square<KING>(weakSide);
        
        // King needs to get close to promoting pawn to prevent knight from blocking.
        // Rules for this are very tricky, so just approximate.
        if (forward_file_bb(strongSide, pawnSq) & pos.attacks_from<BISHOP>(bishopSq))
            return ScaleFactor(distance(weakKingSq, pawnSq));
        
        return SCALE_FACTOR_NONE;
    }

}
