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

#include "fairy_chess_bitboard.hpp"
#include "fairy_chess_pawns.hpp"
#include "fairy_chess_position.hpp"
#include "fairy_chess_thread.hpp"

using namespace std;

namespace FairyChess
{
    namespace {
        
#define V Value
#define S(mg, eg) make_score(mg, eg)
        
        // Pawn penalties
        constexpr Score Isolated = S(13, 16);
        constexpr Score Backward = S(17, 11);
        constexpr Score Doubled  = S(13, 40);
        
        // Connected pawn bonus by opposed, phalanx, #support and rank
        Score Connected[2][2][3][RANK_NB];
        
        // Strength of pawn shelter for our king by [distance from edge][rank].
        // RANK_1 = 0 is used for files where we have no pawn, or pawn is behind our king.
        constexpr Value ShelterStrength[int(FILE_NB) / 2][RANK_NB] = {
            { V(  7), V(76), V( 84), V( 38), V(  7), V( 30), V(-19) },
            { V(-13), V(83), V( 42), V(-27), V(  2), V(-32), V(-45) },
            { V(-26), V(63), V(  5), V(-44), V( -5), V(  2), V(-59) },
            { V(-19), V(53), V(-11), V(-22), V(-12), V(-51), V(-60) }
        };
        
        // Danger of enemy pawns moving toward our king by [distance from edge][rank].
        // RANK_1 = 0 is used for files where the enemy has no pawn, or their pawn
        // is behind our king.
        constexpr Value UnblockedStorm[int(FILE_NB) / 2][RANK_NB] = {
            { V( 25), V( 79), V(107), V( 51), V( 27), V(  0), V(  0) },
            { V(  5), V( 35), V(121), V( -2), V( 15), V(-10), V(-10) },
            { V(-20), V( 22), V( 98), V( 36), V(  7), V(-20), V(-20) },
            { V(-27), V( 24), V( 80), V( 25), V( -4), V(-30), V(-30) }
        };
        
        // Danger of blocked enemy pawns storming our king, by rank
        constexpr Value BlockedStorm[RANK_NB] =
        { V(  0), V(  0), V( 75), V(-10), V(-20), V(-20), V(-20) };
        
#undef S
#undef V
        
        template<Color Us> Score evaluate(Position* pos, Pawns::Entry* e) {
            
            constexpr Color     Them = (Us == WHITE ? BLACK : WHITE);
            constexpr Direction Up   = (Us == WHITE ? NORTH : SOUTH);
            
            Bitboard b, neighbours, stoppers, doubled, supported, phalanx;
            Bitboard lever, leverPush;
            Square s;
            bool opposed, backward;
            Score score = SCORE_ZERO;
            const Square* pl = pos->Position::squares<PAWN>(Us);
            
            Bitboard ourPawns   = pos->pieces(  Us, PAWN);
            Bitboard theirPawns = pos->pieces(Them, PAWN);
            
            e->passedPawns[Us] = e->pawnAttacksSpan[Us] = e->weakUnopposed[Us] = 0;
            e->semiopenFiles[Us] = 0xFF;
            e->kingSquares[Us]   = SQ_NONE;
            e->pawnAttacks[Us]   = pawn_attacks_bb<Us>(ourPawns);
            e->pawnsOnSquares[Us][BLACK] = popcount(ourPawns & DarkSquares);
            e->pawnsOnSquares[Us][WHITE] = pos->count<PAWN>(Us) - e->pawnsOnSquares[Us][BLACK];
            
            // Loop through all pawns of the current color and score each pawn
            while ((s = *pl++) != SQ_NONE)
            {
                // assert(pos->piece_on(s) == make_piece(Us, PAWN));
                if(pos->piece_on(s) != make_piece(Us, PAWN)){
                    printf("error, assert(pos->piece_on(s) == make_piece(Us, PAWN))\n");
                }
                
                File f = file_of(s);
                
                e->semiopenFiles[Us]   &= ~(1 << f);
                e->pawnAttacksSpan[Us] |= pawn_attack_span(Us, s);
                
                // Flag the pawn
                opposed    = theirPawns & forward_file_bb(Us, s);
                stoppers   = theirPawns & passed_pawn_mask(Us, s);
                lever      = theirPawns & PseudoAttacks[Us][PAWN][s];
                leverPush  = theirPawns & PseudoAttacks[Us][PAWN][s + Up];
                doubled    = relative_rank(Us, s, pos->max_rank()) > RANK_1 ? ourPawns & (s - Up) : 0;
                neighbours = ourPawns   & adjacent_files_bb(f);
                phalanx    = neighbours & rank_bb(s);
                supported  = relative_rank(Us, s, pos->max_rank()) > RANK_1 ? neighbours & rank_bb(s - Up) : 0;
                
                // A pawn is backward when it is behind all pawns of the same color
                // on the adjacent files and cannot be safely advanced.
                backward =  !(ourPawns & pawn_attack_span(Them, s + Up))
                && (stoppers & (leverPush | (s + Up)));
                
                // Passed pawns will be properly scored in evaluation because we need
                // full attack info to evaluate them. Include also not passed pawns
                // which could become passed after one or two pawn pushes when are
                // not attacked more times than defended.
                if (   !(stoppers ^ lever ^ leverPush)
                    && !(ourPawns & forward_file_bb(Us, s))
                    && popcount(supported) >= popcount(lever) - 1
                    && popcount(phalanx)   >= popcount(leverPush))
                    e->passedPawns[Us] |= s;
                
                else if (   stoppers == SquareBB[s + Up]
                         && relative_rank(Us, s) >= RANK_5)
                {
                    b = shift<Up>(supported) & ~theirPawns;
                    while (b)
                        if (!more_than_one(theirPawns & PseudoAttacks[Us][PAWN][pop_lsb(&b)]))
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
            }
            
            return score;
        }
        
    } // namespace
    
    namespace Pawns {
        
        /// Pawns::init() initializes some tables needed by evaluation. Instead of using
        /// hard-coded tables, when makes sense, we prefer to calculate them with a formula
        /// to reduce independent parameters and to allow easier tuning and better insight.
        
        void init() {
            
            static constexpr int32_t Seed[RANK_NB] = { 0, 13, 24, 18, 65, 100, 175, 330 };
            
            for (int32_t opposed = 0; opposed <= 1; ++opposed)
                for (int32_t phalanx = 0; phalanx <= 1; ++phalanx)
                    for (int32_t support = 0; support <= 2; ++support)
                        for (Rank r = RANK_1; r < RANK_8; ++r)
                        {
                            int32_t v = 17 * support;
                            v += (Seed[r] + (phalanx ? (Seed[r + 1] - Seed[r]) / 2 : 0)) >> opposed;
                            
                            Connected[opposed][phalanx][support][r] = make_score(v, v * (r - 2) / 4);
                        }
        }
        
        
        /// Pawns::probe() looks up the current position's pawns configuration in
        /// the pawns hash table. It returns a pointer to the Entry if the position
        /// is found. Otherwise a new Entry is computed and stored there, so we don't
        /// have to recompute all when the same pawns configuration occurs again.
        
        Entry* probe(Position* pos) {
            
            Key key = pos->pawn_key();
            Entry* e = (*(pos->this_thread()->pawnsTable))[key];
            
            if (e->key == key)
                return e;
            
            e->key = key;
            e->scores[WHITE] = evaluate<WHITE>(pos, e);
            e->scores[BLACK] = evaluate<BLACK>(pos, e);
            e->openFiles = popcount(e->semiopenFiles[WHITE] & e->semiopenFiles[BLACK]);
            e->asymmetry = popcount(  (e->passedPawns[WHITE]   | e->passedPawns[BLACK])
                                    | (e->semiopenFiles[WHITE] ^ e->semiopenFiles[BLACK]));
            
            return e;
        }
        
        
        /// Entry::evaluate_shelter() calculates the shelter bonus and the storm
        /// penalty for a king, looking at the king file and the two closest files.
        
        template<Color Us> Value Entry::evaluate_shelter(Position* pos, Square ksq) {
            
            constexpr Color     Them = (Us == WHITE ? BLACK : WHITE);
            constexpr Direction Down = (Us == WHITE ? SOUTH : NORTH);
            constexpr Bitboard  BlockRanks = (Us == WHITE ? Rank1BB | Rank2BB : Rank8BB | Rank7BB);
            
            Bitboard b = pos->pieces(PAWN) & (forward_ranks_bb(Us, ksq) | rank_bb(ksq));
            Bitboard ourPawns = b & pos->pieces(Us);
            Bitboard theirPawns = b & pos->pieces(Them);
            
            Value safety = (ourPawns & file_bb(ksq)) ? Value(5) : Value(-5);
            
            if (shift<Down>(theirPawns) & (FileABB | FileHBB) & BlockRanks & ksq)
                safety += Value(374);
            
            File center = max(FILE_B, min(FILE_G, file_of(ksq)));
            for (File f = File(center - 1); f <= File(center + 1); ++f)
            {
                b = ourPawns & file_bb(f);
                int32_t ourRank = b ? relative_rank(Us, backmost_sq(Us, b)) : 0;
                
                b = theirPawns & file_bb(f);
                int32_t theirRank = b ? relative_rank(Us, frontmost_sq(Them, b)) : 0;

                int32_t d = min(f, ~f);
                safety += ShelterStrength[d][ourRank];
                safety -= (ourRank && (ourRank == theirRank - 1)) ? BlockedStorm[theirRank]
                : UnblockedStorm[d][theirRank];
            }
            
            return safety;
        }
        
        
        /// Entry::do_king_safety() calculates a bonus for king safety. It is called only
        /// when king square changes, which is about 20% of total king_safety() calls.
        
        template<Color Us> Score Entry::do_king_safety(Position* pos, Square ksq) {
            
            kingSquares[Us] = ksq;
            castlingRights[Us] = pos->can_castle(Us);
            int32_t minKingPawnDistance = 0;
            
            Bitboard pawns = pos->pieces(Us, PAWN);
            if (pawns)
                while (!(DistanceRingBB[ksq][minKingPawnDistance++] & pawns)) {}
            
            Value bonus = evaluate_shelter<Us>(pos, ksq);
            
            // If we can castle use the bonus after the castling if it is bigger
            if (pos->can_castle(MakeCastling<Us, KING_SIDE>::right))
                bonus = max(bonus, evaluate_shelter<Us>(pos, relative_square(Us, SQ_G1)));
            
            if (pos->can_castle(MakeCastling<Us, QUEEN_SIDE>::right))
                bonus = max(bonus, evaluate_shelter<Us>(pos, relative_square(Us, SQ_C1)));
            
            return make_score(bonus, -16 * minKingPawnDistance);
        }
        
        // Explicit template instantiation
        template Score Entry::do_king_safety<WHITE>(Position* pos, Square ksq);
        template Score Entry::do_king_safety<BLACK>(Position* pos, Square ksq);
        
    } // namespace Pawns
}
