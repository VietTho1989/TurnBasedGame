//
//  common.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <cstdio>
#include <cstdlib>
#include <iostream>

#include "international_draught_common.hpp"
#include "international_draught_util.hpp"

namespace InternationalDraught
{
    // "constants"
    
    const Inc Dir_Inc[Dir_Size] { -J1, -I1, +I1, +J1 };
    
    // variables
    
    static int32_t Square_Sparse[Dense_Size];
    static int32_t Square_Dense[Square_Size];
    
    static int32_t Square_File[Square_Size];
    static int32_t Square_Rank[Square_Size];
    
    // functions
    
    void common_init() {
        
        // square numbering

        int32_t dense = 0;
        int32_t sparse = 0;
        
        for (int32_t rk = 0; rk < Line_Size; rk++) {
            
            for (int32_t fl = 0; fl < Line_Size + 3; fl++) { // 3 ghost files
                
                {
                    // assert(dense < Dense_Size);
                    if(dense>=Dense_Size){
                        printf("error, assert(dense < Dense_Size)\n");
                        dense = Dense_Size - 1;
                    }
                }
                {
                    // assert(sparse < Square_Size);
                    if(sparse>=Square_Size){
                        printf("error, assert(sparse < Square_Size)\n");
                        sparse = Square_Size - 1;
                    }
                }
                
                if (square_is_light(fl, rk)) { // invalid square
                    
                } else if (square_is_ok(fl, rk)) { // board square
                    
                    Square_Sparse[dense] = sparse;
                    Square_Dense[sparse] = dense;
                    
                    Square_File[sparse] = fl;
                    Square_Rank[sparse] = rk;
                    
                    {
                        // assert(square_make(fl, rk) == sparse);
                        if(square_make(fl, rk) != sparse){
                            printf("error, assert(square_make(fl, rk) == sparse)\n");
                            sparse = square_make(fl, rk);
                        }
                    }
                    
                    dense++;
                    sparse++;
                    
                    if (dense >= Dense_Size) break; // all squares have been covered
                    
                } else { // ghost square
                    
                    Square_Dense[sparse] = -1;
                    
                    Square_File[sparse] = -1;
                    Square_Rank[sparse] = -1;
                    
                    sparse++;
                }
            }
        }
    }
    
    bool square_is_ok(int32_t fl, int32_t rk) {
        return (fl >= 0 && fl < Line_Size)
        && (rk >= 0 && rk < Line_Size)
        && square_is_dark(fl, rk);
    }
    
    bool square_is_ok(int32_t sq) {
        return (sq >= 0 && sq < Square_Size) && Square_Dense[sq] >= 0;
    }
    
    bool square_is_light(int32_t fl, int32_t rk) {
        return !square_is_dark(fl, rk);
    }
    
    bool square_is_dark(int32_t fl, int32_t rk) {
        return (fl + rk) % 2 != 0;
    }
    
    Square square_make(int32_t fl, int32_t rk) {
        {
            // assert(square_is_ok(fl, rk));
            if(!(square_is_ok(fl, rk))){
                printf("error, assert(square_is_ok(fl, rk))\n");
            }
        }
        int32_t dense = (rk * Line_Size + fl) / 2;
        return square_sparse(dense);
    }
    
    Square square_make(int32_t sq) {
        {
            // assert(square_is_ok(sq));
            if(!square_is_ok(sq)){
                printf("error, assert(square_is_ok(sq))\n");
            }
        }
        return Square(sq);
    }
    
    Square square_sparse(int32_t dense) {
        {
            // assert(dense >= 0 && dense < Dense_Size);
            if(!(dense >= 0 && dense < Dense_Size)){
                printf("error, assert(dense >= 0 && dense < Dense_Size)\n");
                dense = 0;
            }
        }
        return Square(Square_Sparse[dense]);
    }

    int32_t square_dense(Square sq) {
        return Square_Dense[sq];
    }
    
    Square square_from_std(int32_t std) { // used for input
        if (std < 1 || std > Dense_Size) {
            // throw Bad_Input();
            printf("error, bad input\n");
        }
        return square_sparse(std - 1);
    }

    int32_t square_to_std(Square sq) {
        int32_t std = square_dense(sq) + 1;
        {
            // assert(std >= 1 && std <= Dense_Size);
            if(!(std >= 1 && std <= Dense_Size)){
                printf("error, assert(std >= 1 && std <= Dense_Size)\n");
                std = 1;
            }
        }
        return std;
    }

    int32_t square_file(Square sq) {
        return Square_File[sq];
    }

    int32_t square_rank(Square sq) {
        return Square_Rank[sq];
    }
    
    Square square_opp(Square sq) {
        return square_make((Square_Size - 1) - sq);
    }

    int32_t square_rank(Square sq, Side sd) {

        int32_t rk = square_rank(sq);
        
        if (sd == White) {
            return (Line_Size - 1) - rk;
        } else {
            return rk;
        }
    }
    
    bool square_is_promotion(Square sq, Side sd) {
        return square_rank(sq, sd) == Line_Size - 1;
    }
    
    std::string square_to_string(Square sq) {
        return std::to_string(square_to_std(sq));
    }
    
    bool string_is_square(const std::string & s) {
        
        if (!string_is_nat(s)) return false;

        int32_t std = std::stoi(s);
        return std >= 1 && std <= Dense_Size;
    }
    
    Square square_from_string(const std::string & s) {
        if (!string_is_nat(s)) {
            // throw Bad_Input();
            printf("error, bad input\n");
        }
        return square_from_std(std::stoi(s));
    }
    
    Inc inc_make(int32_t inc) {
        {
            // assert(inc != 0);
            if(inc==0){
                printf("error, assert(inc != 0)\n");
                inc = 1;
            }
        }
        return Inc(inc);
    }
    
    Inc dir_inc(int32_t dir) {
        {
            // assert(dir >= 0 && dir < Dir_Size);
            if(!(dir >= 0 && dir < Dir_Size)){
                printf("error, assert(dir >= 0 && dir < Dir_Size)\n");
                dir = 0;
            }
        }
        return Dir_Inc[dir];
    }
    
    Side side_make(int32_t sd) {
        {
            // assert(sd >= 0 && sd < Side_Size);
            if(!(sd >= 0 && sd < Side_Size)){
                printf("error, assert(sd >= 0 && sd < Side_Size)\n");
                sd = 0;
            }
        }
        return Side(sd);
    }
    
    Side side_opp(Side sd) {
        return side_make(sd ^ 1);
    }
    
    std::string side_to_string(Side sd) {
        return (sd == White) ? "white" : "black";
    }
    
    Piece_Side piece_side_make(int32_t ps) {
        {
            // assert(ps >= 0 && ps < Piece_Side_Size);
            if(!(ps >= 0 && ps < Piece_Side_Size)){
                printf("error, assert(ps >= 0 && ps < Piece_Side_Size)\n");
                ps = 0;
            }
        }
        return Piece_Side(ps);
    }
    
    Piece piece_side_piece(Piece_Side ps) {
        {
            // assert(ps != Empty);
            if(ps==Empty){
                printf("error, assert(ps != Empty)\n");
                ps = White_Man;
            }
        }
        return Piece(ps >> 1);
    }
    
    Side piece_side_side(Piece_Side ps) {
        {
            // assert(ps != Empty);
            if(ps==Empty){
                printf("error, assert(ps != Empty)\n");
                ps = White_Man;
            }
        }
        return side_make(ps & 1);
    }
}
// B:W22,26,31-36,40-45,47-50:B1-4,6-9,11,13-17,19,20,24,25
