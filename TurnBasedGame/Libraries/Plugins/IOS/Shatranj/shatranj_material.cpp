//
//  material.cpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <algorithm>
#include <cassert>
#include <cstring>   // For std::memset

#include "shatranj_material.hpp"
#include "shatranj_thread.hpp"

using namespace std;

namespace Shatranj
{
    namespace {
        
        // Polynomial material imbalance parameters
        
        const int32_t QuadraticOurs[][PIECE_TYPE_NB] = {
            //            OUR PIECES
            // pair pawn bishop queen knight rook
            {1523                               }, // Bishop pair
            {  39,    0                         }, // Pawn
            {   0,  101,    0                   }, // Bishop     OUR PIECES
            {-187,   25,  137,    0             }, // Queen
            {  32,  260,    4,  122,   -3       }, // Knight
            { -26,   -2,  102, -135,   48, -147 }  // Rook
        };
        
        const int32_t QuadraticTheirs[][PIECE_TYPE_NB] = {
            //           THEIR PIECES
            // pair pawn bishop queen knight rook
            {   0                               }, // Bishop pair
            {  36,    0                         }, // Pawn
            {  58,   64,    0                   }, // Bishop      OUR PIECES
            { 100,   99,  143,    0             }, // Queen
            {   9,   63,  -42,   37,    0       }, // Knight
            {  47,   39,  -25, -267,   24,    0 }  // Rook
        };
        
        // Endgame evaluation and scaling functions are accessed directly and not through
        // the function maps because they correspond to more than one material hash key.
        Endgame<KPKP>   ScaleKPKP[]   = { Endgame<KPKP>(WHITE),   Endgame<KPKP>(BLACK) };
        
        /// imbalance() calculates the imbalance by comparing the piece count of each
        /// piece type for both colors.
        template<Color Us> int32_t imbalance(const int32_t pieceCount[][PIECE_TYPE_NB]) {
            
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
            
            // OK, we didn't find any special evaluation function for the current material
            // configuration. Is there a suitable specialized scaling function?
            EndgameBase<ScaleFactor>* sf;
            
            if ((sf = pos.this_thread()->endgames.probe<ScaleFactor>(key)) != nullptr)
            {
                e->scalingFunction[sf->strongSide] = sf; // Only strong color assigned
                return e;
            }
            
            // Evaluate the material imbalance. We use PIECE_TYPE_NONE as a place holder
            // for the bishop pair "extended piece", which allows us to be more flexible
            // in defining bishop pair bonuses.
            const int32_t PieceCount[COLOR_NB][PIECE_TYPE_NB] = {
                { pos.count<BISHOP>(WHITE) > 1, pos.count<PAWN  >(WHITE), pos.count<BISHOP>(WHITE),
                    pos.count<QUEEN >(WHITE)    , pos.count<KNIGHT>(WHITE), pos.count<ROOK  >(WHITE) },
                { pos.count<BISHOP>(BLACK) > 1, pos.count<PAWN  >(BLACK), pos.count<BISHOP>(BLACK),
                    pos.count<QUEEN >(BLACK)    , pos.count<KNIGHT>(BLACK), pos.count<ROOK  >(BLACK) } };
            
            e->value = int16_t((imbalance<WHITE>(PieceCount) - imbalance<BLACK>(PieceCount)) / 16);
            return e;
        }
        
    } // namespace Material
}
