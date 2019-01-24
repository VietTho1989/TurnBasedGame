//
//  pawns.hpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shatranj_pawns_hpp
#define shatranj_pawns_hpp

#include <stdio.h>
#include "shatranj_misc.hpp"
#include "shatranj_position.hpp"
#include "shatranj_types.hpp"

namespace Shatranj
{
    namespace Pawns {
        
        /// Pawns::Entry contains various information about a pawn structure. A lookup
        /// to the pawn hash table (performed by calling the probe function) returns a
        /// pointer to an Entry object.
        
        struct Entry {
            
            Score pawns_score() const
            {
                return score;
            }
            
            Bitboard pawn_attacks(Color c) const
            {
                return pawnAttacks[c];
            }
            
            Bitboard passed_pawns(Color c) const
            {
                return passedPawns[c];
            }
            
            Bitboard pawn_attacks_span(Color c) const
            {
                return pawnAttacksSpan[c];
            }

            int32_t weak_unopposed(Color c) const
            {
                return weakUnopposed[c];
            }

            int32_t pawn_asymmetry() const
            {
                return asymmetry;
            }

            int32_t open_files() const
            {
                return openFiles;
            }

            int32_t semiopen_file(Color c, File f) const
            {
                return semiopenFiles[c] & (1 << f);
            }

            int32_t semiopen_side(Color c, File f, bool leftSide) const
            {
                return semiopenFiles[c] & (leftSide ? (1 << f) - 1 : ~((1 << (f + 1)) - 1));
            }

            int32_t pawns_on_same_color_squares(Color c, Square s) const
            {
                return pawnsOnSquares[c][!!(DarkSquares & s)];
            }
            
            template<Color Us> Score king_safety(const Position& pos, Square ksq)
            {
                return  kingSquares[Us] == ksq
                ? kingSafety[Us] : (kingSafety[Us] = do_king_safety<Us>(pos, ksq));
            }
            
            template<Color Us> Score do_king_safety(const Position& pos, Square ksq);
            
            template<Color Us> Value shelter_storm(const Position& pos, Square ksq);
            
            Key key;
            Score score;
            Bitboard passedPawns[COLOR_NB];
            Bitboard pawnAttacks[COLOR_NB];
            Bitboard pawnAttacksSpan[COLOR_NB];
            Square kingSquares[COLOR_NB];
            Score kingSafety[COLOR_NB];
            int32_t weakUnopposed[COLOR_NB];
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

#endif /* pawns_hpp */
