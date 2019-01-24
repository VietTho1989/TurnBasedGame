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

#ifndef CHESS_STOCK_FISH_PAWNS_H_INCLUDED
#define CHESS_STOCK_FISH_PAWNS_H_INCLUDED

#include <algorithm>
#include "chess_stock_fish_misc.hpp"
#include "chess_stock_fish_position.hpp"
#include "chess_stock_fish_types.hpp"

using namespace std;

namespace StockFishChess
{
    namespace Pawns {

#define V Value

        // Max bonus for king safety. Corresponds to start position with all the pawns
        // in front of the king and no enemy pawn on the horizon.
        const Value MaxSafetyBonus = V(258);

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
        
        /// Pawns::Entry contains various information about a pawn structure. A lookup
        /// to the pawn hash table (performed by calling the probe function) returns a
        /// pointer to an Entry object.
        
        struct Entry {
            
            Score pawns_score() const { return score; }
            Bitboard pawn_attacks(Color c) const { return pawnAttacks[c]; }
            Bitboard passed_pawns(Color c) const { return passedPawns[c]; }
            Bitboard pawn_attacks_span(Color c) const { return pawnAttacksSpan[c]; }
            int32_t weak_unopposed(Color c) const { return weakUnopposed[c]; }
            int32_t pawn_asymmetry() const { return asymmetry; }
            int32_t open_files() const { return openFiles; }

            int32_t semiopen_file(Color c, File f) const {
                return semiopenFiles[c] & (1 << f);
            }

            int32_t semiopen_side(Color c, File f, bool leftSide) const {
                return semiopenFiles[c] & (leftSide ? (1 << f) - 1 : ~((1 << (f + 1)) - 1));
            }

            int32_t pawns_on_same_color_squares(Color c, Square s) const {
                return pawnsOnSquares[c][bool(DarkSquares & s)];
            }
            
            template<Color Us> Score king_safety(const Position& pos, Square ksq) {
                return  kingSquares[Us] == ksq && castlingRights[Us] == pos.can_castle(Us)
                ? kingSafety[Us] : (kingSafety[Us] = do_king_safety<Us>(pos, ksq));
            }

            template<Color Us> Score do_king_safety(const Position& pos, Square ksq)
            {
                kingSquares[Us] = ksq;
                castlingRights[Us] = pos.can_castle(Us);
                int32_t minKingPawnDistance = 0;

                Bitboard pawns = pos.pieces(Us, PAWN);
                if (pawns)
                    while (!(DistanceRingBB[ksq][minKingPawnDistance++] & pawns)) {}

                Value bonus = shelter_storm<Us>(pos, ksq);

                // If we can castle use the bonus after the castling if it is bigger
                if (pos.can_castle(MakeCastling<Us, KING_SIDE>::right))
                    bonus = max(bonus, shelter_storm<Us>(pos, relative_square(Us, SQ_G1)));

                if (pos.can_castle(MakeCastling<Us, QUEEN_SIDE>::right))
                    bonus = max(bonus, shelter_storm<Us>(pos, relative_square(Us, SQ_C1)));

                return make_score(bonus, -16 * minKingPawnDistance);
            }

            template<Color Us> Value shelter_storm(const Position& pos, Square ksq)
            {
                const Color Them = (Us == WHITE ? BLACK : WHITE);

                enum { BlockedByKing, Unopposed, BlockedByPawn, Unblocked };

                Bitboard b = pos.pieces(PAWN) & (forward_ranks_bb(Us, ksq) | rank_bb(ksq));
                Bitboard ourPawns = b & pos.pieces(Us);
                Bitboard theirPawns = b & pos.pieces(Them);
                Value safety = MaxSafetyBonus;
                File center = max(FILE_B, min(FILE_G, file_of(ksq)));

                for (File f = File(center - 1); f <= File(center + 1); ++f) {
                    b = ourPawns & file_bb(f);
                    Rank rkUs = b ? relative_rank(Us, backmost_sq(Us, b)) : RANK_1;

                    b = theirPawns & file_bb(f);
                    Rank rkThem = b ? relative_rank(Us, frontmost_sq(Them, b)) : RANK_1;

                    int32_t d = min(f, ~f);
                    safety -=  ShelterWeakness[f == file_of(ksq)][d][rkUs]
                               + StormDanger
                               [f == file_of(ksq) && rkThem == relative_rank(Us, ksq) + 1 ? BlockedByKing  :
                                rkUs   == RANK_1                                          ? Unopposed :
                                rkThem == rkUs + 1                                        ? BlockedByPawn  : Unblocked]
                               [d][rkThem];
                }

                return safety;
            }
            
            Key key;
            Score score;
            Bitboard passedPawns[COLOR_NB];
            Bitboard pawnAttacks[COLOR_NB];
            Bitboard pawnAttacksSpan[COLOR_NB];
            Square kingSquares[COLOR_NB];
            Score kingSafety[COLOR_NB];
            int32_t weakUnopposed[COLOR_NB];
            int32_t castlingRights[COLOR_NB];
            int32_t semiopenFiles[COLOR_NB];
            int32_t pawnsOnSquares[COLOR_NB][COLOR_NB]; // [color][light/dark squares]
            int32_t asymmetry;
            int32_t openFiles;

        };
        
        typedef HashTable<Entry, 16384> Table;
        
        void init();
        Entry* probe(const Position& pos);
        
    } // namespace Pawns
}

#endif // #ifndef PAWNS_H_INCLUDED
