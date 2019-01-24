//
//  bb_index.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <algorithm>
#include "international_draught_bb_index.hpp"
#include "international_draught_bit.hpp"
#include "international_draught_pos.hpp"

using namespace std;

namespace InternationalDraught
{
    namespace bb {
        
        // constants
        
        const int32_t Size { 7 };
        
        const int32_t N_Max { Dense_Size };
        const int32_t P_Max { 8 };
        
        // types
        
        typedef uint32 Tuple;
        
        // variables
        
        static Tuple Tuple_Size[P_Max + 1][64];
        
        // prototypes
        
        // bo static
        Tuple tuple_size(int32_t p, int32_t n) {
            {
                // assert(p >= 0 && p <= P_Max);
                if(!(p >= 0 && p <= P_Max)){
                    printf("error, assert(p >= 0 && p <= P_Max)\n");
                    p = 0;
                }
            }
            {
                // assert(n >= 0 && n <= N_Max);
                if(!(n >= 0 && n <= N_Max)){
                    printf("error, assert(n >= 0 && n <= N_Max)\n");
                    n = 0;
                }
            }
            return Tuple_Size[p][n];
        }
        
        // bo static
        uint64 after(Square sq) {
            {
                // assert(sq < 63);
                if(sq>=63){
                    printf("error, assert(sq < 63)\n");
                    sq = Square(62);
                }
            }
            return 0 - ml::bit(sq + 1); // HACK: some compilers complain if "0" is omitted
        }
        
        // bo static
        int32_t bit_pos_rev(Square sq, Bit squares) {
            {
                // assert(bit::has(squares, sq));
                if(!bit::has(squares, sq)){
                    printf("error, assert(bit::has(squares, sq))\n");
                }
            }
            return bit::count(squares & after(sq));
        }
        
        // bo static
        Tuple tuple_index_rev(Bit pieces, Bit squares, int32_t p, int32_t n) {
            {
                // assert(p >= 0 && p <= P_Max);
                if(!(p >= 0 && p <= P_Max)){
                    printf("error, assert(p >= 0 && p <= P_Max)\n");
                    p = 0;
                }
            }
            {
                // assert(n >= p && n <= N_Max);
                if(!(n >= p && n <= N_Max)){
                    printf("error, assert(n >= p && n <= N_Max)\n");
                    n = p;
                }
            }
            
            {
                // assert(bit::count(pieces) == p);
                if(bit::count(pieces) != p){
                    printf("error, assert(bit::count(pieces) == p)\n");
                    p = bit::count(pieces);
                }
            }
            {
                // assert(bit::count(squares) == n);
                if(bit::count(squares) != n){
                    printf("error, assert(bit::count(squares) == n)\n");
                    n = bit::count(squares);
                }
            }
            {
                // assert(bit::is_incl(pieces, squares));
                if(!(bit::is_incl(pieces, squares))){
                    printf("error, assert(bit::is_incl(pieces, squares))\n");
                }
            }
            
            Tuple index = 0;
            
            Square square[P_Max + 1];
            
            Bit b;
            int32_t i;
            
            for (b = pieces, i = 0; b != 0; b = bit::rest(b), i++) {
                Square sq = bit::first(b);
                {
                    // assert(i < p);
                    if(i>=p){
                        printf("error, assert(i < p)\n");
                        i = p - 1;
                    }
                }
                square[p - i - 1] = sq;
            }
            
            {
                // assert(i == p);
                if(i!=p){
                    printf("error, assert(i == p)\n");
                    // i = p;
                }
            }

            // for (int32_t i = 0; i < p; i++) {
            for (i = 0; i < p; i++) {
                Square sq = square[i];
                int32_t pos = bit_pos_rev(sq, squares);
                index += tuple_size(i + 1, pos);
            }
            
            {
                // assert(index < tuple_size(p, n));
                if(index>=tuple_size(p, n)){
                    printf("error, assert(index < tuple_size(p, n))\n");
                    index = tuple_size(p, n) - 1;
                }
            }
            return index;
        }
        
        // bo static
        uint64 before(Square sq) {
            return ml::bit(sq) - 1;
        }
        
        // bo static
        int32_t bit_pos(Square sq, Bit squares) {
            {
                // assert(bit::has(squares, sq));
                if(!bit::has(squares, sq)){
                    printf("error, assert(bit::has(squares, sq))\n");
                }
            }
            return bit::count(squares & before(sq));
        }
        
        // bo static
        Tuple tuple_index(Bit pieces, Bit squares, int32_t p, int32_t n) {
            
            {
                // assert(p >= 0 && p <= P_Max);
                if(!(p >= 0 && p <= P_Max)){
                    printf("error, assert(p >= 0 && p <= P_Max)\n");
                    p = 0;
                }
            }
            {
                // assert(n >= p && n <= N_Max);
                if(!(n >= p && n <= N_Max)){
                    printf("error, assert(n >= p && n <= N_Max)\n");
                    n = p;
                }
            }
            {
                // assert(bit::count(pieces) == p);
                if(bit::count(pieces) != p){
                    printf("error, assert(bit::count(pieces) == p)\n");
                    p = bit::count(pieces);
                }
            }
            {
                // assert(bit::count(squares) == n);
                if(bit::count(squares) != n){
                    printf("error, assert(bit::count(squares) == n)\n");
                    n = bit::count(squares);
                }
            }
            {
                // assert(bit::is_incl(pieces, squares));
                if(!bit::is_incl(pieces, squares)){
                    printf("error, assert(bit::is_incl(pieces, squares))\n");
                }
            }
            
            Tuple index = 0;
            
            Bit b;
            int32_t i;
            
            for (b = pieces, i = 0; b != 0; b = bit::rest(b), i++) {
                Square sq = bit::first(b);
                int32_t pos = bit_pos(sq, squares);
                index += tuple_size(i + 1, pos);
            }
            
            {
                // assert(i == p);
                if(i!=p){
                    printf("error, assert(i == p)\n");
                    // i = p;
                }
            }
            
            {
                // assert(index < tuple_size(p, n));
                if(index>=tuple_size(p, n)){
                    printf("error, assert(index < tuple_size(p, n))\n");
                    index = tuple_size(p, n) - 1;
                }
            }
            return index;
        }
        
        // bo static
        Index pos_index_wtm(ID id, Bit wm, Bit bm, Bit wk, Bit bk) {

            int32_t nwm = id_wm(id);
            int32_t nbm = id_bm(id);
            int32_t nwk = id_wk(id);
            int32_t nbk = id_bk(id);
            
            Index index = 0;
            
            index *= tuple_size(nwm, 45);
            index += tuple_index_rev(wm, bit::WM_Squares, nwm, 45);
            
            index *= tuple_size(nbm, 45);
            index += tuple_index(bm, bit::BM_Squares, nbm, 45);
            
            index *= tuple_size(nwk, 50 - nwm - nbm);
            index += tuple_index_rev(wk, Bit(bit::Squares ^ wm ^ bm), nwk, 50 - nwm - nbm);
            
            index *= tuple_size(nbk, 50 - nwm - nbm - nwk);
            index += tuple_index(bk, Bit(bit::Squares ^ wm ^ bm ^ wk), nbk, 50 - nwm - nbm - nwk);
            
            {
                // assert(index < index_size(id));
                if(index>=index_size(id)){
                    printf("error, assert(index < index_size(id))\n");
                    index = index_size(id) - 1;
                }
            }
            return index;
        }
        
        // bo static
        Index pos_index_btm(ID id, Bit wm, Bit bm, Bit wk, Bit bk) {

            int32_t nwm = id_wm(id);
            int32_t nbm = id_bm(id);
            int32_t nwk = id_wk(id);
            int32_t nbk = id_bk(id);
            
            Index index = 0;
            
            index *= tuple_size(nwm, 45);
            index += tuple_index(wm, bit::BM_Squares, nwm, 45);
            
            index *= tuple_size(nbm, 45);
            index += tuple_index_rev(bm, bit::WM_Squares, nbm, 45);
            
            index *= tuple_size(nwk, 50 - nwm - nbm);
            index += tuple_index(wk, Bit(bit::Squares ^ wm ^ bm), nwk, 50 - nwm - nbm);
            
            index *= tuple_size(nbk, 50 - nwm - nbm - nwk);
            index += tuple_index_rev(bk, Bit(bit::Squares ^ wm ^ bm ^ wk), nbk, 50 - nwm - nbm - nwk);
            
            {
                // assert(index < index_size(id));
                if(index>=index_size(id)){
                    printf("error, assert(index < index_size(id))\n");
                    index = index_size(id) - 1;
                }
            }
            return index;
        }
        
        // functions
        
        void index_init() {
            
            // Pascal triangle
            
            for (int32_t n = 0; n <= N_Max; n++) {
                
                Tuple_Size[0][n] = 1;
                
                for (int32_t p = 1; p <= P_Max; p++) {
                    Tuple_Size[p][n] = 0;
                }
            }
            
            for (int32_t n = 1; n <= N_Max; n++) {
                for (int32_t p = 1; p <= min(n, P_Max); p++) {
                    Tuple_Size[p][n] = Tuple_Size[p][n - 1] + Tuple_Size[p - 1][n - 1];
                }
            }
        }
        
        bool id_is_ok(ID id) {
            return (id & ~07777) == 0 && id_size(id) <= Size;
        }
        
        ID id_make(int32_t wm, int32_t bm, int32_t wk, int32_t bk) {
            // printf("id_max: %d, %d, %d, %d\n", wm, bm, wk, bk);
            {
                // assert(wm >= 0);
                if(wm<0){
                    printf("error, assert(wm >= 0)\n");
                    wm = 0;
                }
            }
            {
                // assert(bm >= 0);
                if(bm<0){
                    printf("error, bm<0");
                    bm = 0;
                }
            }
            {
                // assert(wk >= 0);
                if(wk<0){
                    printf("error, assert(wk >= 0)\n");
                    wk = 0;
                }
            }
            {
                // assert(bk >= 0);
                if(bk<0){
                    printf("error, assert(bk >= 0)\n");
                    bk = 0;
                }
            }
            {
                // assert(wm + bm + wk + bk <= Size);
                if(wm + bm + wk + bk > Size){
                    printf("error, assert(wm + bm + wk + bk <= Size)\n");
                    wm = 0;
                    bm = 0;
                    wk = 0;
                    bk = 0;
                }
            }
            
            return ID((wm << 9) | (bm << 6) | (wk << 3) | (bk << 0));
        }
        
        bool id_is_illegal(Variant_Type variantType, ID id) {
            return (id & 00707) == 0 || (variantType == BT && (id & 00070) != 0);
        }
        
        bool id_is_loss(Variant_Type variantType, ID id) {
            return (id & 07070) == 0 || (variantType == BT && (id & 00007) != 0);
        }

        int32_t id_size(ID id) {
            return id_wm(id) + id_bm(id) + id_wk(id) + id_bk(id);
        }

        int32_t id_wm(ID id) {
            return (id >> 9) & 07;
        }

        int32_t id_bm(ID id) {
            return (id >> 6) & 07;
        }

        int32_t id_wk(ID id) {
            return (id >> 3) & 07;
        }

        int32_t id_bk(ID id) {
            return (id >> 0) & 07;
        }
        
        std::string id_name(ID id) {
            
            std::string name;
            name += '0' + id_wm(id);
            name += '0' + id_bm(id);
            name += '0' + id_wk(id);
            name += '0' + id_bk(id);
            
            return name;
        }
        
        std::string id_file(ID id) {
            return std::to_string(id_size(id)) + "/" + id_name(id);
        }
        
        ID pos_id(const Pos & pos) {

            int32_t nwm = bit::count(pos.wm());
            int32_t nbm = bit::count(pos.bm());
            int32_t nwk = bit::count(pos.wk());
            int32_t nbk = bit::count(pos.bk());
            
            if (pos.turn() == White) {
                return id_make(nwm, nbm, nwk, nbk);
            } else {
                return id_make(nbm, nwm, nbk, nwk);
            }
        }
        
        Index pos_index(ID id, const Pos & pos) {
            {
                // assert(id == pos_id(pos));
                if(id!=pos_id(pos)){
                    printf("error, assert(id == pos_id(pos))\n");
                    id = pos_id(pos);
                }
            }
            
            if (pos.turn() == White) {
                return pos_index_wtm(id, pos.wm(), pos.bm(), pos.wk(), pos.bk());
            } else {
                return pos_index_btm(id, pos.bm(), pos.wm(), pos.bk(), pos.wk());
            }
        }
        
        Index index_size(ID id) {

            int32_t nwm = id_wm(id);
            int32_t nbm = id_bm(id);
            int32_t nwk = id_wk(id);
            int32_t nbk = id_bk(id);
            
            Index size = 1;
            
            size *= tuple_size(nwm, 45);
            size *= tuple_size(nbm, 45);
            size *= tuple_size(nwk, 50 - nwm - nbm);
            size *= tuple_size(nbk, 50 - nwm - nbm - nwk);
            
            return size;
        }
        
    }
}
