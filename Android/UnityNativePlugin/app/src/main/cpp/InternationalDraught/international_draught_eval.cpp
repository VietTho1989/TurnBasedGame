//
//  eval.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <algorithm>
#include <cmath>
#include <cstdlib>
#include <fstream>
#include <iostream>
#include <vector>

#include "international_draught_bit.hpp"
#include "international_draught_eval.hpp"
#include "international_draught_score.hpp"
#include "../Platform.h"

using namespace std;

namespace InternationalDraught
{
    // types
    
    class Score_2 {
        
        private :

        int32_t p_mg;
        int32_t p_eg;
        
        public :
        
        Score_2() {
            p_mg = 0;
            p_eg = 0;
        }
        
        void add(EvalVariable* evalVariable, int32_t var, int32_t val) {
            p_mg += evalVariable->G_Weight[var + 0] * val;
            p_eg += evalVariable->G_Weight[var + P] * val;
        }

        int32_t mg () const { return p_mg; }
        int32_t eg () const { return p_eg; }
    };
    
    // "constants"
    
    const int32_t Perm    [Pat_Squares] {  0,  1,  4,  5,  8,  9,  2,  3,  6,  7, 10, 11 };
    const int32_t Perm_Rev[Pat_Squares] { 11, 10,  7,  6,  3,  2,  9,  8,  5,  4,  1,  0 };
    
    // prototypes
    
    // bo static
    int32_t conv(int32_t index, int32_t size, int32_t bf, int32_t bt, const int32_t perm[]) {
        {
            // assert(index >= 0 && index < pow(bf, size));
            if(!(index >= 0 && index < pow(bf, size))){
                printf("error, assert(index >= 0 && index < pow(bf, size))\n");
                index = 0;
            }
        }

        int32_t from = index;
        int32_t to = 0;
        
        for (int32_t i = 0; i < size; i++) {

            int32_t digit = from % bf;
            from /= bf;

            int32_t j = perm[i];
            {
                // assert(j >= 0 && j < size);
                if(!(j >= 0 && j < size)){
                    printf("error, assert(j >= 0 && j < size)\n");
                    j = 0;
                }
            }
            
            {
                // assert(digit >= 0 && digit < bt);
                if(!(digit >= 0 && digit < bt)){
                    printf("error, assert(digit >= 0 && digit < bt)\n");
                    digit = 0;
                }
            }
            to += digit * pow(bt, j);
        }
        
        {
            // assert(from == 0);
            if(from!=0){
                printf("error, assert(from == 0)\n");
                // from = 0;
            }
        }
        
        {
            // assert(to >= 0 && to < pow(bt, size));
            if(!(to >= 0 && to < pow(bt, size))){
                printf("error, assert(to >= 0 && to < pow(bt, size))\n");
                to = 0;
            }
        }
        return to;
    }
    
    // bo static
    void pst(EvalVariable* evalVariable, Score_2& s2, int32_t var, Bit wb, Bit bb) {
        
        for (Bit b = wb; b != 0; b = bit::rest(b)) {
            Square sq = bit::first(b);
            s2.add(evalVariable, var + square_dense(sq), +1);
        }
        
        for (Bit b = bb; b != 0; b = bit::rest(b)) {
            Square sq = square_opp(bit::first(b));
            s2.add(evalVariable, var + square_dense(sq), -1);
        }
    }
    
    // bo static
    void king_mob(EvalVariable* evalVariable, Score_2& s2, int32_t var, const Pos& pos) {

        int32_t ns = 0;
        int32_t nd = 0;
        
        Bit wm = pos.wm();
        Bit bm = pos.bm();
        
        Bit e = bit::Squares ^ wm ^ bm;
        
        // white
        
        {
            Bit ee = e & ~(((bm << J1) & (e >> J1)) | ((bm << I1) & (e >> I1))
                           | ((bm >> I1) & (e << I1)) | ((bm >> J1) & (e << J1)));
            
            for (Bit b = pos.wk(); b != 0; b = bit::rest(b)) {
                
                Square from = bit::first(b);
                
                Bit atk  = bit::king_attack(from, pos.empty()) & e;
                Bit safe = atk & ee;
                Bit deny = atk & ~safe;
                
                ns += bit::count(safe);
                nd += bit::count(deny);
            }
        }
        
        // black
        
        {
            Bit ee = e & ~(((wm << J1) & (e >> J1)) | ((wm << I1) & (e >> I1))
                           | ((wm >> I1) & (e << I1)) | ((wm >> J1) & (e << J1)));
            
            for (Bit b = pos.bk(); b != 0; b = bit::rest(b)) {
                
                Square from = bit::first(b);
                
                Bit atk  = bit::king_attack(from, pos.empty()) & e;
                Bit safe = atk & ee;
                Bit deny = atk & ~safe;
                
                ns -= bit::count(safe);
                nd -= bit::count(deny);
            }
        }
        
        s2.add(evalVariable, var + 0, ns);
        s2.add(evalVariable, var + 1, nd);
    }
    
    // bo static
    void indices_column(uint64 b, int32_t & i0, int32_t & i2) {
        
        uint64 left = b & U64(0x0C3061830C1860C3); // 4 left files
        uint64 shuffle = (left >> 0) | (left >> 11) | (left >> 22);
        
        uint64 mask = (1 << 12) - 1;
        i0 = (int)((shuffle >>  0) & mask);
        i2 = (int)((shuffle >> 26) & mask);
    }
    
    // bo static
    void indices_column(EvalVariable* evalVariable, uint64 white, uint64 black, int32_t & index_top, int32_t & index_bottom) {

        int32_t wt, wb;
        int32_t bt, bb;
        
        indices_column(white, wt, wb);
        indices_column(black, bt, bb);
        
        index_top    = evalVariable->Index_3    [bt] - evalVariable->Index_3    [wt];
        index_bottom = evalVariable->Index_3_Rev[bb] - evalVariable->Index_3_Rev[wb];
    }
    
    // bo static
    void pattern(EvalVariable* evalVariable, Score_2& s2, int32_t var, const Pos& pos) {

        int32_t i0, i1, i2, i3; // top
        int32_t i4, i5, i6, i7; // bottom
        
        Bit wm = pos.wm();
        Bit bm = pos.bm();
        
        indices_column(evalVariable, wm >> 0, bm >> 0, i0, i4);
        indices_column(evalVariable, wm >> 1, bm >> 1, i1, i5);
        indices_column(evalVariable, wm >> 2, bm >> 2, i2, i6);
        indices_column(evalVariable, wm >> 3, bm >> 3, i3, i7);
        
        s2.add(evalVariable, var +  265720 + i0, +1);
        s2.add(evalVariable, var +  797161 + i1, +1);
        s2.add(evalVariable, var + 1328602 + i2, +1);
        s2.add(evalVariable, var + 1860043 + i3, +1);
        
        s2.add(evalVariable, var + 1860043 - i4, -1);
        s2.add(evalVariable, var + 1328602 - i5, -1);
        s2.add(evalVariable, var +  797161 - i6, -1);
        s2.add(evalVariable, var +  265720 - i7, -1);
    }
    
    // functions
    
    bool EvalVariable::eval_init(const std::string & file_name) {
        bool isAndroidAsset = false;
#ifdef Android
        {
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "init eval\n");
            assetistream file(assetManager, file_name.c_str());
            if(file.isOpen()){
                isAndroidAsset = true;
                G_Weight.resize(P * 2);
                for (int32_t i = 0; i < P * 2; i++) {
                    // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "ml::get_bytes\n");
                    G_Weight[i] = int16(ml::get_bytes(file, 2)); // HACK: extend sign
                    // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "after ml::get_bytes\n");
                }
                // init base conversion (2 -> 3)
                int32_t size = Pat_Squares;
                int32_t bf = 2;
                int32_t bt = 3;
                for (int32_t i = 0; i < pow(bf, size); i++) {
                    Index_3    [i] = conv(i, size, bf, bt, Perm_Rev);
                    Index_3_Rev[i] = conv(i, size, bf, bt, Perm);
                }
                __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "GWeight length: %lu, %d\n", G_Weight.size(), pow(2, Pat_Squares));
                return true;
            } else {
                __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "EvalVariable::eval_init: cannot open file: %s\n", file_name.c_str());
            }
        }
#endif
        if(!isAndroidAsset){
            printf("init eval\n");
            // load weights
            std::ifstream file(file_name.c_str(), std::ios::binary);
            if (!file) {
                std::cerr << "unable to open file \"" << file_name << "\"" << std::endl;
                // std::exit(EXIT_FAILURE);
                return false;
            }
            G_Weight.resize(P * 2);
            for (int32_t i = 0; i < P * 2; i++) {
                G_Weight[i] = int16(ml::get_bytes(file, 2)); // HACK: extend sign
            }
            // init base conversion (2 -> 3)
            int32_t size = Pat_Squares;
            int32_t bf = 2;
            int32_t bt = 3;
            for (int32_t i = 0; i < pow(bf, size); i++) {
                Index_3    [i] = conv(i, size, bf, bt, Perm_Rev);
                Index_3_Rev[i] = conv(i, size, bf, bt, Perm);
            }
            printf("GWeight length: %lu, %d\n", G_Weight.size(), pow(2, Pat_Squares));
            return true;
        } else {
            return false;
        }
    }
    
    Score eval(struct var::Var* myVar, const Pos& pos, Side sd) {
        if(!myVar->evalVariable){
            printf("error, don't have evalVariable\n");
            return Score(0);
        }
        
        // features
        
        Score_2 s2;
        int32_t var = 0;
        
        // material

        int32_t nwm = bit::count(pos.wm());
        int32_t nbm = bit::count(pos.bm());
        int32_t nwk = bit::count(pos.wk());
        int32_t nbk = bit::count(pos.bk());
        
        s2.add(myVar->evalVariable, var + 0, nwm - nbm);
        s2.add(myVar->evalVariable, var + 1, (nwk >= 1) - (nbk >= 1));
        s2.add(myVar->evalVariable, var + 2, max(nwk - 1, 0) - max(nbk - 1, 0));
        var += 3;
        
        // king position
        
        pst(myVar->evalVariable, s2, var, pos.wk(), pos.bk());
        var += Dense_Size;
        
        // king mobility
        
        king_mob(myVar->evalVariable, s2, var, pos);
        var += 2;
        
        // left/right balance
        
        s2.add(myVar->evalVariable, var, std::abs(pos::skew(pos, Black)) - std::abs(pos::skew(pos, White)));
        var += 1;
        
        // patterns
        
        pattern(myVar->evalVariable, s2, var, pos);
        var += pow(3, 12) * 4;
        
        // game phase

        int32_t stage = pos::stage(pos);
        {
            // assert(stage >= 0 && stage <= Stage_Size);
            if(!(stage >= 0 && stage <= Stage_Size)){
                printf("error, assert(stage >= 0 && stage <= Stage_Size)\n");
                stage = 0;
            }
        }

        int32_t sc = ml::div_round(s2.mg() * (Stage_Size - stage) + s2.eg() * stage, Unit * Stage_Size);
        
        // drawish material
        
        if (myVar->Variant == Normal) {
            
            if (sc > 0 && nbk != 0) { // white ahead
                
                if (nwm + nwk <= 3) {
                    sc /= 8;
                } else if (nwk == nbk && std::abs(nwm - nbm) <= 1) {
                    sc /= 2;
                }
                
            } else if (sc < 0 && nwk != 0) { // black ahead
                
                if (nbm + nbk <= 3) {
                    sc /= 8;
                } else if (nwk == nbk && std::abs(nwm - nbm) <= 1) {
                    sc /= 2;
                }
            }
        }
        
        Score score = score::clamp(Score(score::side(sc, sd))); // for sd
        // printf("eval score: %d\n", ret);
        {
            // TODO co le se random o day
            if(myVar->pickBestMove>=0 && myVar->pickBestMove<100){
                int32_t randomPercent = fastRandom(100 - myVar->pickBestMove);
                Score newScore = score - randomPercent*score/100.0;
                // printf("eval: newScore: %f, %f, %d\n", score, newScore, randomPercent);
                return newScore;
            }else{
                if(myVar->pickBestMove!=100){
                    printf("error, pickBestMove wrong: %d\n", myVar->pickBestMove);
                }
                return score;
            }
        }
    }
}
