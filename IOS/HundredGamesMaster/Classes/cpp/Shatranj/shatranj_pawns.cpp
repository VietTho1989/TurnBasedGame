//
//  pawns.cpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "shatranj_pawns.hpp"
#include <algorithm>
#include <cassert>

#include "shatranj_bitboard.hpp"
#include "shatranj_position.hpp"
#include "shatranj_thread.hpp"

using namespace std;

namespace Shatranj
{
    namespace {
        
#define V Value
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
        
        // Weakness of our pawn shelter in front of the king by [isKingFile][distance from edge][rank].
        // RANK_1 = 0 is used for files where we have no pawns or our pawn is behind our king.
        const Value ShelterWeakness[][int(FILE_NB) / 2][RANK_NB] = {
            { { V( 97), V(17), V( 9), V(44), V( 84), V( 87), V( 99) }, // Not On King file
                { V(106), V( 6), V(33), V(86), V( 87), V(104), V(112) },
                { V(101), V( 2), V(65), V(98), V( 58), V( 89), V(115) },
                { V( 73), V( 7), V(54), V(73), V( 84), V( 83), V(111) } },
            { { V(104), V(20), V( 6), V(27), V( 86), V( 93), V( 82) }, // On King file
                { V(123), V( 9), V(34), V(96), V(112), V( 88), V( 75) },
                { V(120), V(25), V(65), V(91), V( 66), V( 78), V(117) },
                { V( 81), V( 2), V(47), V(63), V( 94), V( 93), V(104) } }
        };
        
        // Danger of enemy pawns moving toward our king by [type][distance from edge][rank].
        // For the unopposed and unblocked cases, RANK_1 = 0 is used when opponent has
        // no pawn on the given file, or their pawn is behind our king.
        const Value StormDanger[][4][RANK_NB] = {
            { { V( 0),  V(-290), V(-274), V(57), V(41) },  // BlockedByKing
                { V( 0),  V(  60), V( 144), V(39), V(13) },
                { V( 0),  V(  65), V( 141), V(41), V(34) },
                { V( 0),  V(  53), V( 127), V(56), V(14) } },
            { { V( 4),  V(  73), V( 132), V(46), V(31) },  // Unopposed
                { V( 1),  V(  64), V( 143), V(26), V(13) },
                { V( 1),  V(  47), V( 110), V(44), V(24) },
                { V( 0),  V(  72), V( 127), V(50), V(31) } },
            { { V( 0),  V(   0), V(  79), V(23), V( 1) },  // BlockedByPawn
                { V( 0),  V(   0), V( 148), V(27), V( 2) },
                { V( 0),  V(   0), V( 161), V(16), V( 1) },
                { V( 0),  V(   0), V( 171), V(22), V(15) } },
            { { V(22),  V(  45), V( 104), V(62), V( 6) },  // Unblocked
                { V(31),  V(  30), V(  99), V(39), V(19) },
                { V(23),  V(  29), V(  96), V(41), V(15) },
                { V(21),  V(  23), V( 116), V(41), V(15) } }
        };
        
        // Max bonus for king safety. Corresponds to start position with all the pawns
        // in front of the king and no enemy pawn on the horizon.
        const Value MaxSafetyBonus = V(258);
        
#undef S
#undef V
        
        template<Color Us>
        Score evaluate(const Position& pos, Pawns::Entry* e) {
            
            const Color  Them  = (Us == WHITE ? BLACK      : WHITE);
            const Square Up    = (Us == WHITE ? NORTH      : SOUTH);
            const Square Right = (Us == WHITE ? NORTH_EAST : SOUTH_WEST);
            const Square Left  = (Us == WHITE ? NORTH_WEST : SOUTH_EAST);
            
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
            while ((s = *pl++) != SQ_NONE)
            {
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
                    if(backward && (forward_ranks_bb(Them, s + Up) & neighbours)){
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
                    score += Connected[opposed][!!phalanx][popcount(supported)][relative_rank(Us, s)];
                
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
            
            static const int32_t Seed[RANK_NB] = { 0, 10, 20, 20, 60, 80, 120, 200 };
            
            for (int32_t opposed = 0; opposed <= 1; ++opposed)
                for (int32_t phalanx = 0; phalanx <= 1; ++phalanx)
                    for (int32_t support = 0; support <= 2; ++support)
                        for (Rank r = RANK_2; r < RANK_8; ++r)
                        {
                            int32_t v = 17 * support;
                            v += (Seed[r] + (phalanx ? (Seed[r + 1] - Seed[r]) / 2 : 0)) >> opposed;
                            
                            Connected[opposed][phalanx][support][r] = make_score(v, v);
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
        
        
        /// Entry::shelter_storm() calculates shelter and storm penalties for the file
        /// the king is on, as well as the two closest files.
        
        template<Color Us>
        Value Entry::shelter_storm(const Position& pos, Square ksq) {
            
            const Color Them = (Us == WHITE ? BLACK : WHITE);
            
            enum { BlockedByKing, Unopposed, BlockedByPawn, Unblocked };
            
            Bitboard b = pos.pieces(PAWN) & (forward_ranks_bb(Us, ksq) | rank_bb(ksq));
            Bitboard ourPawns = b & pos.pieces(Us);
            Bitboard theirPawns = b & pos.pieces(Them);
            Value safety = MaxSafetyBonus;
            File center = max(FILE_B, min(FILE_G, file_of(ksq)));
            
            for (File f = center - File(1); f <= center + File(1); ++f)
            {
                b = ourPawns & file_bb(f);
                Rank rkUs = b ? relative_rank(Us, backmost_sq(Us, b)) : RANK_1;
                
                b = theirPawns & file_bb(f);
                Rank rkThem = b ? relative_rank(Us, frontmost_sq(Them, b)) : RANK_1;

                int32_t d = min(f, FILE_H - f);
                safety -=  ShelterWeakness[f == file_of(ksq)][d][rkUs]
                + StormDanger
                [f == file_of(ksq) && rkThem == relative_rank(Us, ksq) + 1 ? BlockedByKing  :
                 rkUs   == RANK_1                                          ? Unopposed :
                 rkThem == rkUs + 1                                        ? BlockedByPawn  : Unblocked]
                [d][rkThem];
            }
            
            return safety;
        }
        
        
        /// Entry::do_king_safety() calculates a bonus for king safety. It is called only
        /// when king square changes, which is about 20% of total king_safety() calls.
        
        template<Color Us> Score Entry::do_king_safety(const Position& pos, Square ksq) {
            
            kingSquares[Us] = ksq;
            int32_t minKingPawnDistance = 0;
            
            Bitboard pawns = pos.pieces(Us, PAWN);
            if (pawns)
                while (!(DistanceRingBB[ksq][minKingPawnDistance++] & pawns)) {}
            
            Value bonus = shelter_storm<Us>(pos, ksq);
            
            return make_score(bonus, -16 * minKingPawnDistance);
        }
        
        // Explicit template instantiation
        template Score Entry::do_king_safety<WHITE>(const Position& pos, Square ksq);
        template Score Entry::do_king_safety<BLACK>(const Position& pos, Square ksq);
        
    } // namespace Pawns
}
