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

#include <algorithm>
#include <cassert>

#include "chess_stock_fish_bitboard.hpp"
#include "chess_stock_fish_pawns.hpp"
#include "chess_stock_fish_position.hpp"
#include "chess_stock_fish_thread.hpp"

namespace StockFishChess
{
    namespace {

#define S(mg, eg) make_score(mg, eg)
        
        // Isolated pawn penalty
        const Score Isolated = S(13, 18);
        
        // Backward pawn penalty
        const Score Backward = S(24, 12);
        
        // Connected pawn bonus by opposed, phalanx, #support and rank
        Score Connected[2][2][3][RANK_NB];
        
        // Doubled pawn penalty
        const Score Doubled = S(18, 38);
        
        // Lever bonus by rank
        const Score Lever[RANK_NB] = {
            S( 0,  0), S( 0,  0), S(0, 0), S(0, 0),
            S(17, 16), S(33, 32), S(0, 0), S(0, 0)
        };
        
#undef S
#undef V
        
        template<Color Us> Score evaluate(const Position& pos, Pawns::Entry* e) {
            
            const Color     Them  = (Us == WHITE ? BLACK      : WHITE);
            const Direction Up    = (Us == WHITE ? NORTH      : SOUTH);
            const Direction Right = (Us == WHITE ? NORTH_EAST : SOUTH_WEST);
            const Direction Left  = (Us == WHITE ? NORTH_WEST : SOUTH_EAST);
            
            Bitboard b, neighbours, stoppers, doubled, supported, phalanx;
            Bitboard lever, leverPush;
            Square s;
            bool opposed, backward;
            Score score = SCORE_ZERO;
            const Square* pl = pos.squares<PAWN>(Us);
            
            Bitboard ourPawns   = pos.pieces(  Us, PAWN);
            Bitboard theirPawns = pos.pieces(Them, PAWN);
            
            e->passedPawns[Us] = e->pawnAttacksSpan[Us] = e->weakUnopposed[Us] = 0;
            e->semiopenFiles[Us] = 0xFF;
            e->kingSquares[Us]   = SQ_NONE;
            e->pawnAttacks[Us]   = shift<Right>(ourPawns) | shift<Left>(ourPawns);
            e->pawnsOnSquares[Us][BLACK] = popcount(ourPawns & DarkSquares);
            e->pawnsOnSquares[Us][WHITE] = pos.count<PAWN>(Us) - e->pawnsOnSquares[Us][BLACK];
            
            // Loop through all pawns of the current color and score each pawn
            while ((s = *pl++) != SQ_NONE) {
                // assert(pos.piece_on(s) == make_piece(Us, PAWN));
                if(!(pos.piece_on(s) == make_piece(Us, PAWN))){
                    printf("error, assert(pos.piece_on(s) == make_piece(Us, PAWN))\n");
                }
                
                File f = file_of(s);
                
                e->semiopenFiles[Us]   &= ~(1 << f);
                e->pawnAttacksSpan[Us] |= pawn_attack_span(Us, s);
                
                // Flag the pawn
                opposed    = theirPawns & forward_file_bb(Us, s);
                stoppers   = theirPawns & passed_pawn_mask(Us, s);
                lever      = theirPawns & PawnAttacks[Us][s];
                leverPush  = theirPawns & PawnAttacks[Us][s + Up];
                doubled    = ourPawns   & (s - Up);
                neighbours = ourPawns   & adjacent_files_bb(f);
                phalanx    = neighbours & rank_bb(s);
                supported  = neighbours & rank_bb(s - Up);
                
                // A pawn is backward when it is behind all pawns of the same color on the
                // adjacent files and cannot be safely advanced.
                if (!neighbours || lever || relative_rank(Us, s) >= RANK_5)
                    backward = false;
                else
                {
                    // Find the backmost rank with neighbours or stoppers
                    b = rank_bb(backmost_sq(Us, neighbours | stoppers));
                    
                    // The pawn is backward when it cannot safely progress to that rank:
                    // either there is a stopper in the way on this rank, or there is a
                    // stopper on adjacent file which controls the way to that rank.
                    backward = (b | shift<Up>(b & adjacent_files_bb(f))) & stoppers;
                    
                    // assert(!(backward && (forward_ranks_bb(Them, s + Up) & neighbours)));
                    if((backward && (forward_ranks_bb(Them, s + Up) & neighbours))){
                        printf("error, assert(!(backward && (forward_ranks_bb(Them, s + Up) & neighbours)))\n");
                    }
                }
                
                // Passed pawns will be properly scored in evaluation because we need
                // full attack info to evaluate them. Include also not passed pawns
                // which could become passed after one or two pawn pushes when are
                // not attacked more times than defended.
                if (   !(stoppers ^ lever ^ leverPush)
                    && !(ourPawns & forward_file_bb(Us, s))
                    && popcount(supported) >= popcount(lever)
                    && popcount(phalanx)   >= popcount(leverPush))
                    e->passedPawns[Us] |= s;
                
                else if (   stoppers == SquareBB[s + Up]
                         && relative_rank(Us, s) >= RANK_5)
                {
                    b = shift<Up>(supported) & ~theirPawns;
                    while (b)
                        if (!more_than_one(theirPawns & PawnAttacks[Us][pop_lsb(&b)]))
                            e->passedPawns[Us] |= s;
                }
                
                // Score this pawn
                if (supported | phalanx)
                    score += Connected[opposed][bool(phalanx)][popcount(supported)][relative_rank(Us, s)];
                
                else if (!neighbours)
                    score -= Isolated, e->weakUnopposed[Us] += !opposed;
                
                else if (backward)
                    score -= Backward, e->weakUnopposed[Us] += !opposed;
                
                if (doubled && !supported)
                    score -= Doubled;
                
                if (lever)
                    score += Lever[relative_rank(Us, s)];
            }
            
            return score;
        }
        
    } // namespace
    
    namespace Pawns {
        
        /// Pawns::init() initializes some tables needed by evaluation. Instead of using
        /// hard-coded tables, when makes sense, we prefer to calculate them with a formula
        /// to reduce independent parameters and to allow easier tuning and better insight.
        
        void init() {
            
            static const int32_t Seed[RANK_NB] = { 0, 13, 24, 18, 76, 100, 175, 330 };
            
            for (int32_t opposed = 0; opposed <= 1; ++opposed)
                for (int32_t phalanx = 0; phalanx <= 1; ++phalanx)
                    for (int32_t support = 0; support <= 2; ++support)
                        for (Rank r = RANK_2; r < RANK_8; ++r) {
                            int32_t v = 17 * support;
                            v += (Seed[r] + (phalanx ? (Seed[r + 1] - Seed[r]) / 2 : 0)) >> opposed;
                            
                            Connected[opposed][phalanx][support][r] = make_score(v, v * (r - 2) / 4);
                        }
        }
        
        
        /// Pawns::probe() looks up the current position's pawns configuration in
        /// the pawns hash table. It returns a pointer to the Entry if the position
        /// is found. Otherwise a new Entry is computed and stored there, so we don't
        /// have to recompute all when the same pawns configuration occurs again.
        
        Entry* probe(const Position& pos) {
            
            Key key = pos.pawn_key();
            Entry* e = pos.this_thread()->pawnsTable[key];
            
            if (e->key == key)
                return e;
            
            e->key = key;
            e->score = evaluate<WHITE>(pos, e) - evaluate<BLACK>(pos, e);
            e->asymmetry = popcount(e->semiopenFiles[WHITE] ^ e->semiopenFiles[BLACK]);
            e->openFiles = popcount(e->semiopenFiles[WHITE] & e->semiopenFiles[BLACK]);
            return e;
        }
        
    } // namespace Pawns
}
