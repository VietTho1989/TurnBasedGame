/*
  Stockfish, a UCI chess playing engine derived from Glaurung 2.1
  Copyright (C) 2004-2008 Tord Romstad (Glaurung author)
  Copyright (C) 2008-2015 Marco Costalba, Joona Kiiski, Tord Romstad
  Copyright (C) 2015-2017 Marco Costalba, Joona Kiiski, Gary Linscott, Tord Romstad

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
#include <cstring>   // For std::memset

#include "makruk_material.hpp"
#include "makruk_thread.hpp"

using namespace std;

namespace Makruk
{
    namespace {
        
        // Polynomial material imbalance parameters
        
        const int32_t QuadraticOurs[][PIECE_TYPE_NB] = {
            //            OUR PIECES
            // pair pawn queen bishop knight rook
            { 1000                                }, // Pair
            {    0,    0                          }, // Pawn
            {    0,   24,    0                    }, // Queen
            {    0,  104,  137,    50             }, // Bishop
            {    0,  255,  122,     4,   -3       }, // Knight      OUR PIECES
            {    0,   -2, -134,   105,   47, -149 }  // Rook
        };
        
        const int32_t QuadraticTheirs[][PIECE_TYPE_NB] = {
            //           THEIR PIECES
            // pair pawn queen bishop knight rook
            {    0                                }, // Pair
            {    0,    0                          }, // Pawn
            {    0,  100,     0                   }, // Queen
            {    0,   65,  -141,     0            }, // Bishop
            {    0,   63,    37,   -42,    0      }, // Knight      OUR PIECES
            {    0,   39,  -268,   -24,   24,   0 }  // Rook
        };
        
        // Endgame evaluation and scaling functions are accessed directly and not through
        // the function maps because they correspond to more than one material hash key.
        Endgame<KXK>    EvaluateKXK[]    = { Endgame<KXK>(WHITE),    Endgame<KXK>(BLACK) };
        Endgame<KQsPsK> EvaluateKQsPsK[] = { Endgame<KQsPsK>(WHITE), Endgame<KQsPsK>(BLACK) };
        
        Endgame<KPKP>   ScaleKPKP[]   = { Endgame<KPKP>(WHITE),   Endgame<KPKP>(BLACK) };
        
        // Helper used to detect a given material distribution
        bool is_KXK(const Position& pos, Color us) {
            return   pos.count<ALL_PIECES>(~us) <= 2
            && pos.non_pawn_material(~us) < BishopValueMg
            && pos.non_pawn_material(us) - pos.non_pawn_material(~us) > KnightValueMg;
        }
        
        bool is_KQsPsK(const Position& pos, Color us) {
            return   !more_than_one(pos.pieces(~us))
            && (pos.count<QUEEN >(us) || pos.count<PAWN>(us))
            && !pos.count<ROOK  >(us)
            && !pos.count<BISHOP>(us)
            && !pos.count<KNIGHT>(us);
        }
        
        /// imbalance() calculates the imbalance by comparing the piece count of each
        /// piece type for both colors.
        template<Color Us>
        int32_t imbalance(const int32_t pieceCount[][PIECE_TYPE_NB]) {
            
            const Color Them = (Us == WHITE ? BLACK : WHITE);

            int32_t bonus = 0;
            
            // Second-degree polynomial material imbalance by Tord Romstad
            for (int32_t pt1 = NO_PIECE_TYPE; pt1 <= ROOK; ++pt1)
            {
                if (!pieceCount[Us][pt1])
                    continue;

                int32_t v = 0;
                
                for (int32_t pt2 = NO_PIECE_TYPE; pt2 <= pt1; ++pt2)
                    v +=  QuadraticOurs[pt1][pt2] * pieceCount[Us][pt2]
                    + QuadraticTheirs[pt1][pt2] * pieceCount[Them][pt2];
                
                bonus += pieceCount[Us][pt1] * v;
            }
            
            return bonus;
        }
        
    } // namespace
    
    namespace Material {
        
        /// Material::probe() looks up the current position's material configuration in
        /// the material hash table. It returns a pointer to the Entry if the position
        /// is found. Otherwise a new Entry is computed and stored there, so we don't
        /// have to recompute all when the same material configuration occurs again.
        
        Entry* probe(const Position& pos) {
            
            Key key = pos.material_key();
            Entry* e = pos.this_thread()->materialTable[key];
            
            if (e->key == key)
                return e;
            
            std::memset(e, 0, sizeof(Entry));
            e->key = key;
            e->factor[WHITE] = e->factor[BLACK] = (uint8_t)SCALE_FACTOR_NORMAL;
            
            Value npm_w = pos.non_pawn_material(WHITE);
            Value npm_b = pos.non_pawn_material(BLACK);
            Value npm = max(EndgameLimit, min(npm_w + npm_b, MidgameLimit));
            
            // Map total non-pawn material into [PHASE_ENDGAME, PHASE_MIDGAME]
            e->gamePhase = Phase(((npm - EndgameLimit) * PHASE_MIDGAME) / (MidgameLimit - EndgameLimit));
            
            // Let's look if we have a specialized evaluation function for this particular
            // material configuration. Firstly we look for a fixed configuration one, then
            // for a generic one if the previous search failed.
            if ((e->evaluationFunction = pos.this_thread()->endgames.probe<Value>(key)) != nullptr)
                return e;
            
            // Only queens and pawns against bare king
            for (Color c = WHITE; c <= BLACK; ++c)
                if (is_KQsPsK(pos, c))
                {
                    e->evaluationFunction = &EvaluateKQsPsK[c];
                    return e;
                }
            
            // All other KXK situations
            for (Color c = WHITE; c <= BLACK; ++c)
                if (is_KXK(pos, c))
                {
                    e->evaluationFunction = &EvaluateKXK[c];
                    return e;
                }
            
            // OK, we didn't find any special evaluation function for the current material
            // configuration. Is there a suitable specialized scaling function?
            EndgameBase<ScaleFactor>* sf;
            
            if ((sf = pos.this_thread()->endgames.probe<ScaleFactor>(key)) != nullptr)
            {
                e->scalingFunction[sf->strongSide] = sf; // Only strong color assigned
                return e;
            }
            
            // A small material advantage makes it difficult to win.
            // This catches some trivial draws like KK, KBK and KNK and gives a
            // drawish scale factor for cases such as KRKBP and KmmKm (except for KBBKN).
            if (npm_w + pos.count<PAWN>(WHITE) * QueenValueEg - npm_b <= KnightValueMg)
                e->factor[WHITE] = uint8_t(npm_w + pos.count<PAWN>(WHITE) * QueenValueEg <= KnightValueMg ? SCALE_FACTOR_DRAW :
                                           npm_b <= BishopValueMg ? 4 : 14);
            
            if (npm_b + pos.count<PAWN>(BLACK) * QueenValueEg - npm_w <= KnightValueMg)
                e->factor[BLACK] = uint8_t(npm_b + pos.count<PAWN>(BLACK) * QueenValueEg <= KnightValueMg ? SCALE_FACTOR_DRAW :
                                           npm_w <= BishopValueMg ? 4 : 14);
            
            // Evaluate the material imbalance. We use PIECE_TYPE_NONE as a place holder
            // for the bishop pair "extended piece", which allows us to be more flexible
            // in defining bishop pair bonuses.
            const int32_t PieceCount[COLOR_NB][PIECE_TYPE_NB] = {
                { pos.queen_pair(WHITE), pos.count<PAWN>(WHITE), pos.count<QUEEN >(WHITE),
                    pos.count<BISHOP>(WHITE), pos.count<KNIGHT>(WHITE), pos.count<ROOK>(WHITE) },
                { pos.queen_pair(BLACK), pos.count<PAWN>(BLACK), pos.count<QUEEN >(BLACK),
                    pos.count<BISHOP>(BLACK), pos.count<KNIGHT>(BLACK), pos.count<ROOK>(BLACK) } };
            
            e->value = int16_t((imbalance<WHITE>(PieceCount) - imbalance<BLACK>(PieceCount)) / 16);
            return e;
        }
        
    } // namespace Material
}
