//************************************************
//*                                               *
//*               Kallisto support                *
//*                                               *
//*************************************************


#include <fstream>
#include <thread>
using namespace std;
   
//*************************************************
//*                                               *
//*               KestoG sources                  *
//*                                               *
//*************************************************

/* includes */
#include <assert.h>
#include <cmath>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

#include "russian_draught_EdAccess.hpp"
#include "russian_draught_KALLISTO.hpp" // f-ion prototypes
#include "russian_draught_EdAccessImp.hpp"
#include "../Platform.h"

namespace RussianDraught
{
    // ������� ��������� ������ ��� ����������� ���������� � ���� ����������
    // pv - ������ �������
    // cm - ��� ������������� � ������ ������
    PF_SearchInfo pfSearchInfo = 0;
    // ������ �������
    // ��� ��������� ���������
    // ��� ����������� ����������� ���������� � ��������
    PF_SearchInfoEx pfSearchInfoEx = 0;
    
    /* function prototypes */
    
    static void QuickSort(int32_t SortVals[MAXMOVES], struct move2 movelist[MAXMOVES], int32_t inf, int32_t sup);
    static int32_t evaluation(int32_t b[46], int32_t color, int32_t alpha, int32_t beta, Position* pos, int32_t pickBestMove);
    static int32_t fast_eval(int32_t b[46], int32_t color, Position* pos);
    static void domove2(int32_t *b, struct move2 *move, int32_t stm, Position* pos);
    static void __inline  doprom(int32_t *b, struct move *move, int32_t stm, Position* pos);
    static void __inline  undoprom(int32_t *b, struct move *move, int32_t stm, Position* pos);
    static void undomove(int32_t *b, struct move2 *move, int32_t stm, Position* pos);
    static void update_hash(struct move2 *move, U64& HASH_KEY);
    static uint32_t Gen_Proms(int32_t *b, struct move *movelist, int32_t color);
    static void black_king_capture(int32_t *b, int32_t *n, struct move2 *movelist, int32_t j, int32_t in_dir);
    static void black_man_capture(int32_t *b, int32_t *n, struct move2 *movelist, int32_t j, int32_t in_dir);
    static void white_king_capture(int32_t *b, int32_t *n, struct move2 *movelist, int32_t j, int32_t in_dir);
    static void white_man_capture(int32_t *b, int32_t *n, struct move2 *movelist, int32_t j, int32_t in_dir);
    static uint32_t Test_Capture(int32_t *b, int32_t color, Position* pos);
    static int32_t Test_From_pb(int32_t *b, int32_t mloc, int32_t dir);
    static int32_t Test_From_cb(int32_t *b, int32_t mloc, int32_t dir);
    static int32_t Test_From_pw(int32_t *b, int32_t mloc, int32_t dir);
    static int32_t Test_From_cw(int32_t *b, int32_t mloc, int32_t dir);
    
    static struct coor numbertocoor(int32_t n);
    
    static U64 rand64(void);
    static U64 Position_to_Hashnumber(int32_t b[46], int32_t color);
    static void Create_HashFunction(void);
    static int32_t value_to_tt(int32_t value, int32_t& realdepth);
    static void Perft(int32_t* b, int32_t color, uint32_t depth, Position* pos);
    static bool is_move_to_7(int32_t b[46], struct move2 *move);
    static int32_t __inline is_promotion(struct move2 *move);
    static int32_t is_blk_kng(int32_t b[46]);
    static int32_t is_wht_kng(int32_t b[46]);
    static int32_t is_blk_kng_1(int32_t b[46]);
    static int32_t is_wht_kng_1(int32_t b[46]);
    static int32_t is_blk_kng_2(int32_t b[46]);
    static int32_t is_wht_kng_2(int32_t b[46]);
    static int32_t is_blk_kng_3(int32_t b[46]);
    static int32_t is_wht_kng_3(int32_t b[46]);
    static int32_t is_blk_kng_4(int32_t b[46]);
    static int32_t is_wht_kng_4(int32_t b[46]);
    static int32_t pick_next_move(int32_t *marker, int32_t SortVals[MAXMOVES], int32_t n);
    static void Sort(int32_t start, int32_t num, int32_t SortVals[MAXMOVES], struct move2 movelist[MAXMOVES]);
    static void init_piece_lists(int32_t b[46], Position* pos);
    __inline int32_t value_mate_in(int32_t ply);
    __inline int32_t value_mated_in(int32_t ply);
    static bool move_to_a1h8(struct move2 *move );
    static int32_t has_man_on_7th(int32_t b[46], int32_t color);
    static int32_t EdProbe(int32_t c[46], int32_t color);
    static __inline U8 FROM(struct move2 *move);
    static __inline U8 TO(struct move2 *move);
    
    /*----------> globals  */
    // CRITICAL_SECTION AnalyseSection;
    static U64 ZobristNumbers[41][16];
    static U64 HashSTM; // random number - side to move
    
    uint32_t size = 48; // default size 8 MB
    
    double PerftNodes;
    static const int32_t directions[4] =  { -0x5,-0x4,0x5,0x4 };
    static const int32_t NodeAll = -1;
    static const int32_t NodePV  =  0;
    static const int32_t NodeCut = +1;
    static const int32_t MVALUE[11] = {0,0,0,0,0,100,100,0,0,250,250};
    const int32_t SearchNormal = 0;
    const int32_t SearchShort  = 1;
    
    const int32_t SquareTo32[41] = { 0,0,0,0,0,           // 0 .. 4
        0,1,2,3,0,           // 5 .. 8 (9)
        4,5,6,7,             // 10 .. 13
        8,9,10,11,0,       // 14 .. 17 (18)
        12,13,14,15,       // 19 .. 22
        16,17,18,19,0,    // 23 .. 26 (27)
        20,21,22,23,       // 28 .. 31
        24,25,26,27,0,      // 32 .. 35 (36)
        28,29,30,31          // 37 .. 40
    };
    
    EdAccess *ED = NULL;
    
    uint32_t EdPieces = 0;
    bool EdNocaptures = false;
    
    const int32_t GrainSize = 2;
    bool ZobristInitialized = false;
    //#pragma warn -8057 // disable warning #8057 when compiling
    //#pragma warn -8004 // disable warning #8004 when compiling
    
    int32_t Search::getmove (int32_t board[8][8], int32_t color, double maxtime, char str[1024], int32_t* playnow,int32_t info, int32_t unused, struct CBmove *move)
    {
        /* getmove is what checkerboard calls. you get the parameters:
         
         - b[8][8]
         is the current position. the values in the array are
         determined by the #defined values of BLACK, WHITE, KING,
         MAN. a black king for instance is represented by BLACK|KING.
         
         - color
         is the side to make a move. BLACK or WHITE.
         
         - maxtime
         is the time your program should use to make a move. this
         is what you specify as level in checkerboard. so if you
         exceed this time it's not too bad - just don't exceed it
         too much...
         
         - str
         is a pointer to the output string of the checkerboard status bar.
         you can use sprintf(str,"information"); to print any information you
         want into the status bar.
         
         - *playnow
         is a pointer to the playnow variable of checkerboard. if
         the user would like your engine to play immediately, this
         value is nonzero, else zero. you should respond to a
         nonzero value of *playnow by interrupting your search
         IMMEDIATELY.
         
         - CBmove
         tells checkerboard what your move is, see above.
         */
        
        int32_t i;
        int32_t value;
        int32_t b[46];
        int32_t time = (int32_t)(maxtime * 1000.0);
        double t, elapsed;
        /* initialize board */
        for (i=45; i>=0; i--)
            b[i] = OCCUPIED;
        for (i=5; i<=40; i++)
            b[i]=FREE;
        /*    (white)
         37  38  39  40
         32  33  34  35
         28  29  30  31
         23  24  25  26
         19  20  21  22
         14  15  16  17
         10  11  12  13
         5   6   7   8
         (black)   */
        b[5] = board[0][0]; b[6] = board[2][0]; b[7] = board[4][0]; b[8] = board[6][0];
        b[10] = board[1][1]; b[11] = board[3][1]; b[12] = board[5][1]; b[13] = board[7][1];
        b[14] = board[0][2]; b[15] = board[2][2]; b[16] = board[4][2]; b[17] = board[6][2];
        b[19] = board[1][3]; b[20] = board[3][3]; b[21] = board[5][3]; b[22] = board[7][3];
        b[23] = board[0][4]; b[24] = board[2][4]; b[25] = board[4][4]; b[26] = board[6][4];
        b[28] = board[1][5]; b[29] = board[3][5]; b[30] = board[5][5]; b[31] = board[7][5];
        b[32] = board[0][6]; b[33] = board[2][6]; b[34] = board[4][6]; b[35] = board[6][6];
        b[37] = board[1][7]; b[38] = board[3][7]; b[39] = board[5][7]; b[40] = board[7][7];
        for (i=5; i<=40; i++)
            if (b[i] == 0)
                b[i] = FREE;
        for (i=9; i<=36; i+=9)
            b[i] = OCCUPIED;
        play = *playnow;
        
#ifdef PERFT
        t = now();
        init_piece_lists(b);
        PerftNodes = 0;
        realdepth = 0;
        Perft(b,color,10);
        elapsed = (now()-t)/(double)CLK_TCK;
        sprintf(str, "[done][time %.2fs][PerftNodes %.0f]" , elapsed, PerftNodes);
#else
        // init_piece_lists(b);
        if((info & 1) || (ttable == NULL)){
            TTableInit(size);
            pos->EvalHashClear();
            searches_performed_in_game = 0;
            Create_HashFunction();
            ClearHistory();
        }
        value = compute(b, color,time, str);
#endif
        
        for (i=5; i<=40; i++)
            if (b[i]==FREE)
                b[i] = 0;
        /* return the board */
        board[0][0] = b[5]; board[2][0] = b[6]; board[4][0] = b[7]; board[6][0] = b[8];
        board[1][1] = b[10]; board[3][1] = b[11]; board[5][1] = b[12]; board[7][1] = b[13];
        board[0][2] = b[14]; board[2][2] = b[15]; board[4][2] = b[16]; board[6][2] = b[17];
        board[1][3] = b[19]; board[3][3] = b[20]; board[5][3] = b[21]; board[7][3] = b[22];
        board[0][4] = b[23]; board[2][4] = b[24]; board[4][4] = b[25]; board[6][4] = b[26];
        board[1][5] = b[28]; board[3][5] = b[29]; board[5][5] = b[30]; board[7][5] = b[31];
        board[0][6] = b[32]; board[2][6] = b[33]; board[4][6] = b[34]; board[6][6] = b[35];
        board[1][7] = b[37]; board[3][7] = b[38]; board[5][7] = b[39]; board[7][7] = b[40];
        
        /* set the move */
        *move = GCBmove;
        if (value>=HASHMATE)
            return WIN;
        if(value<=-HASHMATE)
            return LOSS;
        return UNKNOWN;
    }
    
    __inline int32_t value_mate_in(int32_t ply){
        return (MATE - ply);
    }
    
    __inline int32_t value_mated_in(int32_t ply) {
        return (-MATE + ply);
    }
    
    static void black_king_capture(int32_t *b, int32_t *n, struct move2 *movelist, int32_t j, int32_t in_dir){
        int32_t capsq, dir,found_cap=0, found_pd, next_dir = 0, temp;
        uint32_t i,m;
        struct move2 move, orgmove;
        //orgmove = movelist[*n];
        for(i =0; i < 4; i++){    // scan all 4 directions
            if((in_dir & (1 << i)) == 0)
                continue;
            dir = directions[i];
            temp = j; // from square
            do {
                temp += dir;
            } while(b[temp] == FREE);
            if ((b[temp] & WHITE) != 0) {
                temp = temp + dir;
                if (b[temp])
                    continue;
                capsq = temp - dir; // fix captured square address in capsq
                found_pd = 0;
                if(found_cap == 0)
                    orgmove = movelist[*n];
                do{
                    if (Test_From_pb(b,temp,dir)) {
                        // add to movelist
                        move = orgmove;
                        move.path[move.l - 1] = temp;
                        m = SHIFT_BK|temp;
                        move.m[1] = m;
                        m = (b[capsq]<<6)|capsq;
                        move.m[move.l] = m;
                        move.l++;
                        found_pd++;
                        found_cap++;
                        movelist[*n] = move;
                        b[capsq]++;
                        // further jumps
                        switch (i){
                            case 0:
                                next_dir = ( found_pd == 1 ) ? 13:5;
                                break; // in binary form 1101:0101
                            case 1:
                                next_dir = ( found_pd == 1 ) ? 14:10;
                                break; // in binary form 1110:1010
                            case 2:
                                next_dir = ( found_pd == 1 ) ? 7:5;
                                break; // in binary form 0111:0101
                            case 3:
                                next_dir = ( found_pd == 1 ) ? 11:10;
                                break; // in binary form 1011:1010
                        }
                        black_king_capture(b, n, movelist, temp, next_dir);
                        b[capsq]--;
                    } // if
                    temp = temp + dir;
                } while (b[temp] == FREE);
                
                if (found_pd == 0) {
                    if ((b[temp] & WHITE) != 0 && (b[temp+dir] == FREE)) {
                        temp = capsq + dir;
                        // add to movelist
                        move = orgmove;
                        move.path[move.l - 1] = temp;
                        m = SHIFT_BK|temp;
                        move.m[1] = m;
                        m = (b[capsq]<<6)|capsq;
                        move.m[move.l] = m;
                        move.l++;
                        found_cap++;
                        movelist[*n] = move;
                        b[capsq]++;
                        // further jump in same direction
                        next_dir = 1 << ( 3 - i );
                        black_king_capture(b, n, movelist, temp,next_dir);
                        b[capsq]--;
                    } else {
                        temp = capsq + dir;
                        do {
                            // add to movelist
                            move = orgmove;
                            move.path[move.l - 1] = temp;
                            m = SHIFT_BK|temp;
                            move.m[1] = m;
                            m = (b[capsq]<<6)|capsq;
                            move.m[move.l] = m;
                            move.l++;
                            found_cap++;
                            movelist[*n] = move;
                            (*n)++;
                            temp = temp + dir;
                        }while (b[temp] == FREE);
                    }
                }
            } //   /*   ----===========----   */
        } // for
        
        if(found_cap == 0)
            (*n)++;
    }
    
    
    static void black_man_capture(int32_t *b, int32_t *n, struct move2 *movelist, int32_t j, int32_t in_dir) {
        int32_t dir,found_cap=0,sq1,sq2;
        uint32_t i,m;
        struct move2 move, orgmove;
        for (i = 0; i < 4; i++){ // scan all 4 directions
            dir = directions[i];
            if(dir == in_dir)
                continue;
            sq1 = j + dir;
            if((b[sq1] & WHITE )!= 0){
                sq2 = j + (dir<<1);
                if(b[sq2] == FREE){
                    // add to movelist
                    if(found_cap == 0)
                        orgmove = movelist[*n];
                    move = orgmove;
                    move.path[move.l - 1] = sq2;
                    m = (b[sq1]<<6)|sq1;
                    move.m[move.l] = m;
                    move.l++;
                    if(sq2>35){  // promotion
                        m = SHIFT_BK|sq2;
                        move.m[1] = m;
                        movelist[*n] = move;
                        found_cap++;
                        if((sq2 == 37) || (sq2 == 40)){
                            (*n)++;
                            continue;
                        } else {
                            //dir = (dir == 4)?1:2;
                            dir = dir - 3;
                            b[sq1]++;
                            // further jump as king
                            black_king_capture(b, n, movelist,sq2,dir);
                            b[sq1]--;
                        }
                    } // promotion
                    else{     // non-promotion
                        m = SHIFT_BM|sq2;
                        move.m[1] = m;
                        found_cap++;
                        movelist[*n] = move;
                        b[sq1]++;
                        //
                        black_man_capture(b, n, movelist,sq2,-dir);
                        b[sq1]--;
                    }
                } //
            } //
        } // for
        if(found_cap == 0)
            (*n)++;
    }
    
    
    static void white_king_capture(int32_t *b, int32_t *n, struct move2 *movelist, int32_t j, int32_t in_dir){
        int32_t capsq, dir, found_cap = 0, found_pd,next_dir = 0, temp;
        uint32_t i, m;
        struct move2 move, orgmove;
        //orgmove = movelist[*n];
        for(i = 0; i < 4; i++){ // scan all 4 directions
            if((in_dir & (1 << i)) == 0)
                continue;
            dir = directions[i];
            temp = j; // from square
            do {
                temp += dir;
            } while(b[temp] == FREE);
            if((b[temp] & BLACK) != 0){
                temp = temp + dir;
                if (b[temp])
                    continue;
                capsq = temp - dir; // fix captured square address in capsq
                found_pd = 0;
                if(found_cap == 0)
                    orgmove = movelist[*n];
                do{
                    if(Test_From_pw(b,temp,dir)){
                        // add to movelist
                        move = orgmove;
                        move.path[move.l - 1] = temp;
                        m = SHIFT_WK|temp;
                        move.m[1] = m;
                        m = (b[capsq]<<6)|capsq;
                        move.m[move.l] = m;
                        move.l++;
                        found_pd++;
                        found_cap++;
                        movelist[*n] = move;
                        b[capsq]--;
                        // further jumps
                        switch (i){
                            case 0:
                                next_dir = ( found_pd == 1 ) ? 13:5;
                                break; // in binary form 1101:0101
                            case 1:
                                next_dir = ( found_pd == 1 ) ? 14:10;
                                break; // in binary form 1110:1010
                            case 2:
                                next_dir = ( found_pd == 1 ) ? 7:5;
                                break; // in binary form 0111:0101
                            case 3:
                                next_dir = ( found_pd == 1 ) ? 11:10;
                                break; // in binary form 1011:1010
                        }
                        white_king_capture(b, n, movelist, temp,next_dir);
                        b[capsq]++;
                    } // if
                    temp = temp + dir;
                } while(b[temp] == FREE);
                
                if(found_pd == 0){
                    if((b[temp] & BLACK) != 0 && (b[temp+dir] == FREE)){
                        temp = capsq + dir;
                        // add to movelist
                        move = orgmove;
                        move.path[move.l - 1] = temp;
                        m = SHIFT_WK|temp;
                        move.m[1] = m;
                        m = (b[capsq]<<6)|capsq;
                        move.m[move.l] = m;
                        move.l++;
                        found_cap++;
                        movelist[*n] = move;
                        b[capsq]--;
                        // further 1  jump
                        next_dir = 1 << ( 3 - i );
                        white_king_capture(b, n, movelist, temp,next_dir);
                        b[capsq]++;
                    } // if
                    else {
                        temp = capsq + dir;
                        do {
                            // add to movelist
                            move = orgmove;
                            move.path[move.l - 1] = temp;
                            m = SHIFT_WK|temp;
                            move.m[1] = m;
                            m = (b[capsq]<<6)|capsq;
                            move.m[move.l] = m;
                            move.l++;
                            found_cap++;
                            movelist[*n] = move;
                            (*n)++;
                            temp = temp + dir;
                        } while (b[temp] == FREE);
                    }
                }
            }
        } // for
        
        if (found_cap == 0)
            (*n)++;
    }
    
    static void white_man_capture(int32_t *b, int32_t *n, struct move2 *movelist , int32_t j, int32_t in_dir) {
        int32_t dir, found_cap = 0, sq1, sq2;
        uint32_t i,m;
        struct move2 move,orgmove;
        for (i = 0; i < 4; i++){ // scan all 4 directions
            dir = directions[i]; // -5,-4,5,4
            if(dir == in_dir)
                continue;
            sq1 = j + dir;
            if ((b[sq1] & BLACK) != 0){
                sq2 = j + (dir<<1);
                if (b[sq2] == FREE){
                    // add to movelist
                    if(found_cap == 0)
                        orgmove = movelist[*n];
                    move = orgmove;
                    move.path[move.l - 1] = sq2;
                    m = (b[sq1]<<6)|sq1;
                    move.m[move.l] = m;
                    move.l++;
                    if (sq2 < 10) {  // promotion
                        m = SHIFT_WK|sq2;
                        move.m[1] = m;
                        found_cap++;
                        movelist[*n] = move;
                        
                        if ((sq2 == 5) || (sq2 == 8)) {
                            (*n)++;
                            continue;
                        } else {
                            dir = (i== 1) ? 4 : 8;
                            b[sq1]--;
                            //
                            white_king_capture(b, n, movelist,sq2,dir);
                            b[sq1]++;
                        }
                    } // promotion
                    else{  // non-promotion
                        m = SHIFT_WM|sq2;
                        move.m[1] = m;
                        found_cap++;
                        movelist[*n] = move;
                        b[sq1]--;
                        //
                        white_man_capture(b, n, movelist,sq2,-dir);
                        b[sq1]++;
                    }
                }
            }
        } // for
        if (found_cap == 0)
            (*n)++;
    }
    
    
    static int32_t Test_From_pb(int32_t *b, int32_t temp, int32_t dir) {
        // test if there is capture in perpendicular direction to dir from square
        // for black color
        int32_t d, square;
        
        if ((dir&1) == 0)
            d = 5;
        else
            d = 4;
        
        square = temp;
        
        do {
            square = square + d;
        } while (b[square] == FREE);
        if ((b[square] & WHITE) != 0)
            if (b[square + d] == FREE)
                return (1);
        
        square = temp;
        d = -d; // another perp. direction
        do {
            square = square + d;
        } while (b[square] == FREE);
        if ((b[square] & WHITE) != 0)
            if (b[square + d] == FREE)
                return (1);
        return (0);
    }
    
    static int32_t Test_From_cb(int32_t *b, int32_t temp, int32_t dir) {
        // test if there is capture in current direction dir
        // for black color
        do {
            temp = temp + dir;
        } while (b[temp] == FREE);
        if ((b[temp] & WHITE) != 0)
            if (b[temp + dir] == FREE)
                return (1);
        return (0);
    }
    
    
    static int32_t Test_From_pw(int32_t *b, int32_t temp, int32_t dir) {
        // test if there is capture in perpendicular direction to dir from square
        // for white color
        int32_t d, square;
        
        if ((dir&1) == 0)
            d = 5;
        else
            d = 4;
        
        square = temp;
        
        do{
            square = square + d;
        } while (b[square] == FREE);
        if ((b[square] & BLACK) != 0)
            if (b[square + d] == FREE)
                return (1);
        
        square = temp;
        d = -d; // another perp. direction
        
        do {
            square = square + d;
        } while (b[square] == FREE);
        if ((b[square] & BLACK) != 0)
            if (b[square + d] == FREE)
                return (1);
        return (0);
    }
    
    
    static int32_t Test_From_cw(int32_t *b, int32_t temp, int32_t dir) {
        // test if there is capture in current direction dir from square
        // for white color
        do{
            temp = temp + dir;
        } while (b[temp] == FREE);
        if ((b[temp] & BLACK) != 0)
            if (b[temp + dir] == FREE)
                return (1);
        return (0);
    }
    
    static uint32_t Test_Capture(int32_t *b, int32_t color, Position* pos) {
        uint32_t square;
        if (color == WHITE){
            // for( unsigned register i = 1;i <= num_wpieces;i++ ){
            for(uint32_t i = 1;i <= pos->num_wpieces;i++ ){
                if ((square = pos->p_list[WHITE][i] ) == 0)
                    continue;
                if ((b[square] & MAN) != 0) {
                    if (square > 13) {
                        if ((b[square-4] & BLACK) !=0)
                            if(b[square-8] == FREE)
                                return(i);
                        if((b[square-5] & BLACK) !=0)
                            if(b[square-10] == FREE)
                                return(i);
                    }
                    if (square < 32) {
                        if((b[square+4] & BLACK) !=0)
                            if(b[square+8] == FREE)
                                return (i);
                        if((b[square+5] & BLACK)!=0)
                            if(b[square+10] == FREE)
                                return (i);
                    }
                } else {  // KING
                    if (square < 32) {
                        if (Test_From_cw(b,square, 4))
                            return (i);
                        if (Test_From_cw(b,square, 5))
                            return (i);
                    }
                    if (square > 13) {
                        if (Test_From_cw(b, square, -4))
                            return (i);
                        if (Test_From_cw(b, square, -5) )
                            return (i);
                    }
                }
            } // for
            return (0);
        } // if ( color == WHITE )
        else {
            // for(unsigned register i = 1; i <= num_bpieces; i++) {
            for (uint32_t i = 1; i <= pos->num_bpieces; i++) {
                if ((square = pos->p_list[BLACK][i]) == 0)
                    continue;
                if ((b[square] & MAN) != 0 ){
                    if ( square < 32 ){
                        if( (b[square+4] & WHITE) !=0)
                            if( b[square+8] == FREE )
                                return(i);
                        if( (b[square+5] & WHITE) !=0)
                            if( b[square+10] == FREE )
                                return(i);
                    }
                    if ( square > 13 ){
                        if( (b[square-4] & WHITE) !=0)
                            if( b[square-8] == FREE )
                                return(i);
                        if( (b[square-5] & WHITE) !=0)
                            if( b[square-10] == FREE )
                                return(i);
                    }
                }
                else{ // KING
                    if ( square < 32 ){
                        if ( Test_From_cb(b,square,4) ) return (i);
                        if ( Test_From_cb(b,square,5) ) return (i);
                    }
                    if ( square > 13 ){
                        if ( Test_From_cb(b,square,-4) ) return (i);
                        if ( Test_From_cb(b,square,-5) ) return (i);
                    }
                }
            } // for
            return (0);
        } // if ( color == BLACK )
    }
    
    uint32_t Gen_Captures(int32_t *b, struct move2 *movelist, int32_t color, uint32_t start, Position* pos) {
        int32_t dir = 0, next_dir = 0, sq1=0, sq2=0, n = 0, temp = 0;
        uint32_t capsq,found_pd,i;
        uint32_t m = 0;
        uint32_t j = 0;
        if (color == WHITE ){
            // for (unsigned register square=start; square <= num_wpieces; square++) {
            for (uint32_t square=start; square <= pos->num_wpieces; square++) {
                if ((j = pos->p_list[WHITE][square]) == 0)
                    continue;
                if ((b[j] & MAN) != 0) {
                    b[j] = FREE;
                    for (i = 0; i < 4; i++) {          // scan all 4 directions
                        dir = directions[i];             // dir = -5,-4,5,4
                        sq1 = j + dir;
                        if ((b[sq1] & BLACK) != 0) {
                            sq2 = j + (dir<<1);
                            if (b[sq2] == FREE) {
                                // add to movelist
                                movelist[n].l = 3;
                                movelist[n].path[1] = sq2;
                                m = SHIFT_WM|j;
                                movelist[n].m[0] = m;
                                m = (b[sq1]<<6)|(sq1);
                                movelist[n].m[2] = m;
                                if (sq2 < 10) { // promotion
                                    m = SHIFT_WK|sq2;
                                    movelist[n].m[1] = m;
                                    if ((sq2 == 5) || (sq2 == 8)) {
                                        n++;
                                        continue;
                                    } else {
                                        next_dir = (i == 1) ? 4:8; // in binary form 0100:1000
                                        b[sq1]--;
                                        // assert dir != 4 && dir != 5
                                        white_king_capture(b, &n, movelist, sq2, next_dir);
                                        b[sq1]++;
                                    }
                                } else { // non-promotion
                                    m = SHIFT_WM|sq2;
                                    movelist[n].m[1] = m;
                                    b[sq1]--;
                                    //next_dir = -dir;
                                    white_man_capture(b, &n, movelist, sq2, -dir);
                                    b[sq1]++;
                                }
                            } // if
                        } // if
                    } // for
                    b[j] =WHT_MAN;
                }    // if MAN
                else { // b[j] is a KING
                    b[j] = FREE;
                    for (i = 0; i < 4; i++) { // scan all 4 directions
                        dir = directions[i];
                        temp = j; // from square
                        do {
                            temp += dir;
                        } while (b[temp] == FREE);
                        if ((b[temp] & BLACK) != 0) {
                            temp = temp + dir;
                            if (b[temp])
                                continue;
                            capsq = temp - dir;
                            found_pd = 0;
                            do {
                                if (Test_From_pw(b, temp, dir)) {
                                    found_pd++;
                                    // add to movelist
                                    movelist[n].l = 3;
                                    movelist[n].path[1] = temp;
                                    m = SHIFT_WK|temp;
                                    movelist[n].m[1] = m;
                                    m = SHIFT_WK|j;
                                    movelist[n].m[0] = m;
                                    m = (b[capsq]<<6)|capsq;
                                    movelist[n].m[2] = m;
                                    b[capsq]--;
                                    // further jumps
                                    switch (i){
                                        case 0:
                                            next_dir = (found_pd == 1) ? 13 : 5;
                                            break; // in binary form 1101:0101
                                        case 1:
                                            next_dir = (found_pd == 1) ? 14 : 10;
                                            break; // in binary form 1110:1010
                                        case 2:
                                            next_dir = (found_pd == 1) ? 7 : 5;
                                            break; // in binary form 0111:0101
                                        case 3:
                                            next_dir = (found_pd == 1) ? 11 : 10;
                                            break; // in binary form 1011:1010
                                    }
                                    white_king_capture(b, &n, movelist, temp, next_dir);
                                    b[capsq]++;
                                } // if
                                temp = temp + dir;
                            } while (b[temp] == FREE);
                            
                            if (found_pd == 0) {
                                if ((b[temp] & BLACK) != 0 && (b[temp + dir] == FREE)) {
                                    temp = capsq + dir;
                                    // add to movelist
                                    movelist[n].l = 3;
                                    movelist[n].path[1] = temp;
                                    m = SHIFT_WK|temp;
                                    movelist[n].m[1] = m;
                                    m = SHIFT_WK|j;
                                    movelist[n].m[0] = m;
                                    m = (b[capsq]<<6)|capsq;
                                    movelist[n].m[2] = m;
                                    b[capsq]--;
                                    // further 1 jump
                                    next_dir = 1 << (3 - i);
                                    white_king_capture(b, &n, movelist, temp, next_dir);
                                    b[capsq]++;
                                } // if
                                else {
                                    temp = capsq + dir;
                                    do {
                                        // add to movelist
                                        movelist[n].l = 3;
                                        movelist[n].path[1] = temp;
                                        m = SHIFT_WK|temp;
                                        movelist[n].m[1] = m;
                                        m = SHIFT_WK|j;
                                        movelist[n].m[0] = m;
                                        m = (b[capsq]<<6)|capsq;
                                        movelist[n].m[2] = m;
                                        n++;
                                        temp = temp + dir;
                                    }while (b[temp] == FREE);
                                }
                            }
                        }
                    } // for
                    b[j] = WHT_KNG;
                } // else
            } // for
        } else {
            // for (unsigned register square=start; square <= num_bpieces; square++) {
            for (uint32_t square=start; square <= pos->num_bpieces; square++) {
                if ((j = pos->p_list[BLACK][square]) == 0)
                    continue;
                if ((b[j] & MAN) != 0) {
                    b[j] = FREE;
                    for (i = 0; i < 4; i++) {  // scan all 4 directions
                        dir = directions[i];
                        sq1 = j + dir;
                        if ((b[sq1] & WHITE) != 0) {
                            sq2 = j + (dir<<1);
                            if (b[sq2] == FREE) {
                                // add to movelist
                                movelist[n].l = 3;
                                movelist[n].path[1] = sq2;
                                m = SHIFT_BM|j;
                                movelist[n].m[0] = m;
                                m = (b[sq1]<<6)|sq1;
                                movelist[n].m[2] = m;
                                if (sq2 > 35) { // promotion
                                    m = SHIFT_BK|sq2;
                                    movelist[n].m[1] = m;
                                    if ((sq2 == 37) || (sq2 == 40)) {
                                        n++;
                                        continue;
                                    } else {
                                        //next_dir = (dir == 4)?1:2; // in binary form 0001:0010
                                        next_dir = dir - 3;
                                        b[sq1]++;
                                        // assert dir != -4 dir != -5 because can't promote capturing backwards
                                        black_king_capture(b, &n, movelist, sq2, next_dir);
                                        b[sq1]--;
                                    }
                                } else { // non-promotion
                                    m = SHIFT_BM|sq2;
                                    movelist[n].m[1] = m;
                                    b[sq1]++;
                                    // next_dir = -dir;
                                    black_man_capture(b, &n, movelist,sq2,-dir);
                                    b[sq1]--;
                                }
                            }
                        }
                    }
                    b[j] = BLK_MAN;
                } else {     // b[j] is a KING
                    b[j] = FREE;
                    for (i = 0; i < 4; i++) {          // scan all 4 directions
                        dir = directions[i];
                        temp = j; // from square
                        do {
                            temp += dir;
                        } while (b[temp] == FREE);
                        if ((b[temp] & WHITE) != 0) {
                            temp = temp + dir;
                            if (b[temp])
                                continue;
                            capsq = temp - dir;
                            found_pd = 0;
                            do {
                                if (Test_From_pb(b, temp, dir)) {
                                    found_pd++;
                                    // add to movelist
                                    movelist[n].l = 3;
                                    movelist[n].path[1] = temp;
                                    m = SHIFT_BK|temp;
                                    movelist[n].m[1] = m;
                                    m = SHIFT_BK|j;
                                    movelist[n].m[0] = m;
                                    m = (b[capsq]<<6)|capsq;
                                    movelist[n].m[2] = m;
                                    b[capsq]++;
                                    // further jumps
                                    switch (i){
                                        case 0:
                                            next_dir = (found_pd == 1) ? 13 : 5;
                                            break; // in binary form 1101:0101
                                        case 1:
                                            next_dir = (found_pd == 1) ? 14 : 10;
                                            break; // in binary form 1110:1010
                                        case 2:
                                            next_dir = (found_pd == 1) ? 7 : 5;
                                            break; // in binary form 0111:0101
                                        case 3:
                                            next_dir = (found_pd == 1) ? 11 : 10;
                                            break; // in binary form 1011:1010
                                    }
                                    black_king_capture(b, &n, movelist, temp, next_dir);
                                    b[capsq]--;
                                } // if
                                temp = temp + dir;
                            } while (b[temp] == FREE);
                            
                            if (found_pd == 0) {
                                if ((b[temp] & WHITE) != 0 && (b[temp + dir]==FREE)) {
                                    temp = capsq + dir;
                                    // add to movelist
                                    movelist[n].l = 3;
                                    movelist[n].path[1] = temp;
                                    m = SHIFT_BK|temp;
                                    movelist[n].m[1] = m;
                                    m = SHIFT_BK|j;
                                    movelist[n].m[0] = m;
                                    m = (b[capsq]<<6)|capsq;
                                    movelist[n].m[2] = m;
                                    b[capsq]++;
                                    // further 1 jump
                                    next_dir = 1 << ( 3 - i );
                                    black_king_capture(b, &n, movelist, temp, next_dir);
                                    b[capsq]--;
                                } // if
                                else {
                                    temp = capsq + dir;
                                    do {
                                        // add to movelist
                                        movelist[n].l = 3;
                                        movelist[n].path[1] = temp;
                                        m = SHIFT_BK|temp;
                                        movelist[n].m[1] = m;
                                        m = SHIFT_BK|j;
                                        movelist[n].m[0] = m;
                                        m = (b[capsq]<<6)|capsq;
                                        movelist[n].m[2] = m;
                                        n++;
                                        temp = temp + dir;
                                    } while (b[temp]==FREE);
                                }
                            }
                        }
                    } // for
                    b[j] = BLK_KNG;
                } // else
            }
        }
        return (n);  // returns number of captures n
    }
    
    uint32_t Gen_Moves(int32_t *b, struct move2 *movelist, int32_t color, Position* pos) {
        uint32_t m, n=0, square=0, temp=0;
        if (color == WHITE) {
            // for ( unsigned register i = 1;i <= num_wpieces;i++){
            for (uint32_t i = 1; i <= pos->num_wpieces; i++) {
                if ((square = pos->p_list[WHITE][i]) == 0)
                    continue;
                if ((b[square] & MAN) != 0) {
                    temp = square - 5;
                    if (b[temp] == FREE) {
                        movelist[n].l = 2;
                        if (square < 14)
                            m = SHIFT_WK|temp;
                        else
                            m = SHIFT_WM|temp;
                        movelist[n].m[1] = m;
                        m = SHIFT_WM|square;
                        movelist[n].m[0] = m;
                        n++;
                    }
                    temp++;
                    if (b[temp] == FREE) {
                        movelist[n].l = 2;
                        if (square < 14)
                            m = SHIFT_WK|temp;
                        else
                            m = SHIFT_WM|temp;
                        movelist[n].m[1] = m;
                        m = SHIFT_WM|square;
                        movelist[n].m[0] = m;
                        n++;
                    }
                } // MAN
                else{ // KING
                    temp = square + 4;
                    while (b[temp] == FREE) {
                        movelist[n].l = 2;
                        m = SHIFT_WK|temp;
                        movelist[n].m[1] = m;
                        m = SHIFT_WK|square;
                        movelist[n++].m[0] = m;
                        temp += 4;
                    } // while
                    temp = square + 5;
                    while (b[temp] == FREE) {
                        movelist[n].l = 2;
                        m = SHIFT_WK|temp;
                        movelist[n].m[1] = m;
                        m = SHIFT_WK|square;
                        movelist[n++].m[0] = m;
                        temp += 5;
                    } // while
                    temp = square - 4;
                    while (b[temp] == FREE) {
                        movelist[n].l = 2;
                        m = SHIFT_WK|temp;
                        movelist[n].m[1] = m;
                        m = SHIFT_WK|square;
                        movelist[n++].m[0] = m;
                        temp -= 4;
                    } // while
                    temp = square - 5;
                    while (b[temp] == FREE) {
                        movelist[n].l = 2;
                        m = SHIFT_WK|temp;
                        movelist[n].m[1] = m;
                        m = SHIFT_WK|square;
                        movelist[n++].m[0] = m;
                        temp -= 5;
                    } // while
                } // else
            } // for
        } // color == WHITE
        else{
            // for (unsigned register i = 1;i <= num_bpieces;i++){
            for (uint32_t i = 1;i <= pos->num_bpieces; i++) {
                if ((square = pos->p_list[BLACK][i] ) == 0)
                    continue;
                if ((b[square] & MAN) != 0) {
                    temp = square + 4;
                    if (b[temp] == FREE) {
                        movelist[n].l = 2;
                        if (square > 31)
                            m = SHIFT_BK|temp;
                        else
                            m = SHIFT_BM|temp;
                        movelist[n].m[1] = m;
                        m = SHIFT_BM|square;
                        movelist[n].m[0] = m;
                        n++;
                    }
                    temp++;
                    if (b[temp] == FREE) {
                        movelist[n].l = 2;
                        if (square > 31)
                            m = SHIFT_BK|temp;
                        else
                            m = SHIFT_BM|temp;
                        movelist[n].m[1] = m;
                        m = SHIFT_BM|square;
                        movelist[n].m[0] = m;
                        n++;
                    }
                } // MAN
                else {   // KING
                    temp = square + 4;
                    while (b[temp] == FREE) {
                        movelist[n].l = 2;
                        m = SHIFT_BK|temp;
                        movelist[n].m[1] = m;
                        m = SHIFT_BK|square;
                        movelist[n++].m[0] = m;
                        temp += 4;
                    } // while
                    temp = square + 5;
                    while (b[temp] == FREE) {
                        movelist[n].l = 2;
                        m = SHIFT_BK|temp;
                        movelist[n].m[1] = m;
                        m = SHIFT_BK|square;
                        movelist[n++].m[0] = m;
                        temp += 5;
                    } // while
                    temp = square - 4;
                    while (b[temp] == FREE) {
                        movelist[n].l = 2;
                        m = SHIFT_BK|temp;
                        movelist[n].m[1] = m;
                        m = SHIFT_BK|square;
                        movelist[n++].m[0] = m;
                        temp -= 4;
                    } // while
                    temp = square - 5;
                    while (b[temp] == FREE) {
                        movelist[n].l = 2;
                        m = SHIFT_BK|temp;
                        movelist[n].m[1] = m;
                        m = SHIFT_BK|square;
                        movelist[n++].m[0] = m;
                        temp -= 5;
                    } // while
                }  // else
            } // for
        }
        return (n); // returns number of moves n
    }
    
    static uint32_t Gen_Proms(int32_t *b, struct move *movelist, int32_t color) {
        // generates only promotions
        // used in quiescent search
        uint32_t n = 0;
        
        if (color == WHITE) {
            if ((b[13] & WHITE) != 0) {
                if ((b[13] & MAN) != 0) {
                    if (b[8] == FREE) {
                        movelist[n].m[1] = 0x248;
                        movelist[n++].m[0] = 0x14D;
                    }
                }
            }
            
            if ((b[10] & WHITE) != 0) {
                if ((b[10] & MAN) != 0) {
                    if (b[5] == FREE) {
                        movelist[n].m[1] = 0x245;
                        movelist[n++].m[0] = 0x14A;
                    }
                    if (b[6] == FREE) {
                        movelist[n].m[1] = 0x246;
                        movelist[n++].m[0] = 0x14A;
                    }
                }
            }
            
            if ((b[11] & WHITE) != 0) {
                if ((b[11] & MAN) != 0) {
                    if (b[6] == FREE) {
                        movelist[n].m[1] = 0x246;
                        movelist[n++].m[0] = 0x14B;
                    }
                    if (b[7] == FREE) {
                        movelist[n].m[1] = 0x247;
                        movelist[n++].m[0] = 0x14B;
                    }
                }
            }
            
            if ((b[12] & WHITE) != 0) {
                if ((b[12] & MAN) != 0) {
                    if (b[7] == FREE) {
                        movelist[n].m[1] = 0x247;
                        movelist[n++].m[0] = 0x14C;
                    }
                    if (b[8] == FREE) {
                        movelist[n].m[1] = 0x248;
                        movelist[n++].m[0] = 0x14C;
                    }
                }
            }
        } else {
            if ((b[32] & BLACK) != 0) {
                if ((b[32] & MAN) != 0) {
                    if (b[37] == FREE) {
                        movelist[n].m[1] = 0x2A5;
                        movelist[n++].m[0] = 0x1A0;
                    }
                }
            }
            
            if ((b[33] & BLACK) != 0) {
                if ((b[33] & MAN) != 0) {
                    if (b[37] == FREE) {
                        movelist[n].m[1] = 0x2A5;
                        movelist[n++].m[0] = 0x1A1;
                    }
                    if (b[38] == FREE) {
                        movelist[n].m[1] = 0x2A6;
                        movelist[n++].m[0] = 0x1A1;
                    }
                }
            }
            
            if ((b[34] & BLACK) != 0) {
                if ((b[34] & MAN) != 0) {
                    if (b[38] == FREE) {
                        movelist[n].m[1] = 0x2A6;
                        movelist[n++].m[0] = 0x1A2;
                    }
                    if (b[39] == FREE) {
                        movelist[n].m[1] = 0x2A7;
                        movelist[n++].m[0] = 0x1A2;
                    }
                }
            }
            
            if ((b[35] & BLACK) != 0) {
                if ((b[35] & MAN) != 0) {
                    if (b[39] == FREE) {
                        movelist[n].m[1] = 0x2A7;
                        movelist[n++].m[0] = 0x1A3;
                    }
                    if (b[40] == FREE) {
                        movelist[n].m[1] = 0x2A8;
                        movelist[n++].m[0] = 0x1A3;
                    }
                }
            }
        }
        return (n); // returns number of promotions n
    }
    
    void Position::domove(struct move2 *move)
    /*----> purpose: execute move on board and update HASH_KEY */
    {
        bool needResetDepth = false;
        uint32_t contents, from, target;
        
        HASH_KEY ^= HashSTM;
        
        from = ((move->m[0]) & 0x3f);
        // check from
        if(!(from>=0 && from<46)){
            printf("from error\n", from);
            return;
        }
        // check need reset
        {
            printf("move length: %d\n", move->l);
            if (Board[from]==WHT_MAN || Board[from]==BLK_MAN) {
                needResetDepth = true;
            } else {
                if(move->l>=3){
                    printf("king eat, need reset\n");
                    needResetDepth = true;
                }
            }
        }
        Board[from] = FREE;
        contents = ((move->m[0]) >> 6);
        Reversible[realdepth] = ((contents & KING) && (move->l == 2));
        
        HASH_KEY ^= ZobristNumbers[from][contents];
        g_pieces[contents]--;
        
        target = ((move->m[1]) & 0x3f);
        contents = ((move->m[1]) >> 6);
        HASH_KEY ^= ZobristNumbers[target][contents];
        Board[target] = contents;
        g_pieces[contents]++;
        
        indices[target] = indices[from];
        p_list[Color][indices[target]] = target;
        
        // for(unsigned register i=(move->l)-1;i>1;i--) {
        for(uint32_t i=(move->l)-1; i>1; i--) {
            target = ((move->m[i]) & 0x3f);
            Board[target] = FREE;
            contents = ((move->m[i]) >> 6);
            HASH_KEY ^= ZobristNumbers[target][contents];
            g_pieces[contents]--;
            c_num[realdepth][i] = indices[target];
            p_list[(Color^CC)][indices[target]] = 0;
        }
        if (needResetDepth) {
            realdepth = 0;
        } else {
            realdepth++;
        }
        RepNum[realdepth] = HASH_KEY;
        Color = Color^CC;
    }
    
    void domove(int32_t *b, struct move2 *move, int32_t stm, Position* pos)
    /*----> purpose: execute move on board and update HASH_KEY */
    {
        uint32_t contents, from, target;
        
        pos->HASH_KEY ^= HashSTM;
        
        from = ((move->m[0]) & 0x3f);
        b[from] = FREE;
        contents = ((move->m[0]) >> 6);
        pos->Reversible[pos->realdepth] = ((contents & KING) && (move->l == 2));
        
        pos->HASH_KEY ^= ZobristNumbers[from][contents];
        pos->g_pieces[contents]--;
        
        target = (( move->m[1]) & 0x3f);
        contents = ((move->m[1]) >> 6);
        pos->HASH_KEY ^= ZobristNumbers[target][contents];
        b[target] = contents;
        pos->g_pieces[contents]++;
        
        pos->indices[target] = pos->indices[from];
        pos->p_list[stm][pos->indices[target]] = target;
        
        // for(unsigned register i=(move->l)-1;i>1;i--) {
        for(uint32_t i=(move->l)-1; i>1; i--) {
            target = ((move->m[i]) & 0x3f);
            b[target] = FREE;
            contents = ((move->m[i]) >> 6);
            pos->HASH_KEY ^= ZobristNumbers[target][contents];
            pos->g_pieces[contents]--;
            pos->c_num[pos->realdepth][i] = pos->indices[target];
            pos->p_list[(stm^CC)][pos->indices[target]] = 0;
        }
        pos->realdepth++;
    }
    
    static void domove2(int32_t *b, struct move2 *move, int32_t stm, Position* pos)
    /*----> purpose: execute move on board without HASH_KEY updating */
    {
        uint32_t contents, from, target;
        from = ((move->m[0]) & 0x3f);
        b[from] = FREE;
        contents = ((move->m[0]) >> 6);
        // Reversible[realdepth] = ((contents & KING) && (move->l == 2));
        pos->g_pieces[contents]--;
        target = ((move->m[1]) & 0x3f);
        contents = ((move->m[1]) >> 6);
        b[target] = contents;
        pos->g_pieces[contents]++;
        pos->indices[target] = pos->indices[from];
        pos->p_list[stm][pos->indices[target]] = target;
        // for(unsigned register i=(move->l)-1; i>1; i--) {
        for (uint32_t i=(move->l)-1; i>1; i--) {
            target = ((move->m[i]) & 0x3f);
            pos->c_num[pos->realdepth][i] = pos->indices[target];
            pos->p_list[(stm^CC)][pos->indices[target]] = 0;
            contents = ((move->m[i]) >> 6);
            pos->g_pieces[contents]--;
            b[target] = FREE;
        }
        pos->realdepth++;
    }
    
    static void __inline doprom(int32_t *b, struct move *move, int32_t stm, Position* pos)
    /*----> purpose: execute promotion on board and update HASH_KEY */
    {
        uint32_t contents, from, target;
        pos->HASH_KEY ^= HashSTM;
        from = ((move->m[0]) & 0x3f);
        b[from] = FREE;
        contents = ((move->m[0]) >> 6);
        pos->HASH_KEY ^= ZobristNumbers[from][contents];
        // Reversible[realdepth] = ((contents & KING) && (move->l == 2));
        pos->g_pieces[contents]--;
        
        target = ((move->m[1]) & 0x3f);
        contents = ((move->m[1]) >> 6);
        pos->HASH_KEY ^= ZobristNumbers[target][contents];
        b[target] = contents;
        
        pos->g_pieces[contents]++;
        
        pos->indices[target] = pos->indices[from];
        pos->p_list[stm][pos->indices[target]] = target;
        pos->realdepth++;
    }
    
    
    static void __inline undoprom(int32_t *b, struct move *move, int32_t stm, Position* pos)
    /*----> purpose: undo what doprom did */
    {
        uint32_t contents, from, to;
        
        pos->realdepth--;
        to = ((move->m[1]) & 0x3f); // to
        b[to] = FREE;
        contents = ((move->m[1]) >> 6); // contents
        pos->g_pieces[contents]--;
        
        from = ((move->m[0]) & 0x3f); // from
        contents = ((move->m[0]) >> 6); // contents
        b[from] = contents;
        pos->g_pieces[contents]++;
        
        pos->indices[from] = pos->indices[to];
        pos->p_list[stm][pos->indices[from]] = from;
    }
    
    
    static void undomove(int32_t *b, struct move2 *move, int32_t stm, Position* pos)
    /*----> purpose: undo what domove did */
    {
        uint32_t contents, from, to;
        pos->realdepth--;
        to = ((move->m[1]) & 0x3f); // to
        b[to] = FREE;
        contents = ((move->m[1]) >> 6); // contents
        pos->g_pieces[contents]--;
        from = ((move->m[0]) & 0x3f); // from
        contents = ((move->m[0]) >> 6); // contents
        b[from] = contents;
        pos->g_pieces[contents]++;
        pos->indices[from] = pos->indices[to];
        pos->p_list[stm][pos->indices[from]] = from;
        // for (unsigned register i=(move->l)-1; i>1; i--) {
        for (uint32_t i=(move->l)-1; i>1; i--) {
            contents = ((move->m[i]) >> 6);
            pos->g_pieces[contents]++;
            to = ((move->m[i]) & 0x3f);
            b[to] = contents;
            pos->indices[to] = pos->c_num[pos->realdepth][i];
            pos->p_list[(stm^CC)][pos->indices[to]] = to;
        }
    }
    
    static int32_t evaluation(int32_t b[46], int32_t color, int32_t alpha, int32_t beta, Position* pos, int32_t pickBestMove) {
        /*----> purpose: static evaluation of the board */
        //U64 TESTHASH = Position_to_Hashnumber(b,color);
        //assert( TESTHASH == HASH_KEY );
        int32_t eval;
        int32_t GLAV = 0;
        if (((pos->HASH_KEY ^ pos->EvalHash[(U32)(pos->HASH_KEY & EC_MASK ) ]) & 0xffffffffffff0000 ) == 0) {
            eval = (int)((S16)(pos->EvalHash[(U32)(pos->HASH_KEY & EC_MASK)] & 0xffff));
            return eval;
        }
        int32_t nbm = pos->g_pieces[BLK_MAN]; // number of black men
        int32_t nwm = pos->g_pieces[WHT_MAN]; // number of white men
        int32_t nbk = pos->g_pieces[BLK_KNG]; // number of black kings
        int32_t nwk = pos->g_pieces[WHT_KNG]; // number of white kings
        
        if ((nbm == 0) && (nbk == 0)) {
            eval = pos->realdepth - MATE;
            //	assert( color == BLACK );
            //EvalHash[(U32)(HASH_KEY & EC_MASK)] = (HASH_KEY & 0xffffffffffff0000) | (eval & 0xffff);
            return eval;
        }
        if ((nwm == 0) && (nwk == 0)) {
            eval = pos->realdepth - MATE;
            //	assert(color == WHITE);
            //EvalHash[(U32)(HASH_KEY & EC_MASK)] = (HASH_KEY & 0xffffffffffff0000) | (eval & 0xffff);
            return eval;
        }
        
        int32_t White = nwm + nwk; // total number of white pieces
        int32_t Black = nbm + nbk;     // total number of black pieces
        int32_t v1 = 100 * nbm + 300 * nbk;
        int32_t v2 = 100 * nwm + 300 * nwk;
        eval = v1 - v2;         // material values
        
        // draw situations
        if (nbm == 0 && nwm == 0 && abs(nbk - nwk) <= 1) {
            pos->EvalHash[(U32)(pos->HASH_KEY & EC_MASK)] = (pos->HASH_KEY & 0xffffffffffff0000) | ( 0 & 0xffff);
            return (0); // only kings left
        }
        if ((eval > 0) && (nwk > 0) && (Black < (nwk+2))) {
            pos->EvalHash[(U32)(pos->HASH_KEY & EC_MASK)] = (pos->HASH_KEY & 0xffffffffffff0000) | (0 & 0xffff);
            return (0); // black cannot win
        }
        
        if ((eval < 0) && (nbk > 0) && (White < (nbk+2))) {
            pos->EvalHash[(U32)(pos->HASH_KEY & EC_MASK)] = (pos->HASH_KEY & 0xffffffffffff0000) | (0 & 0xffff);
            return (0); //  white cannot win
        }
        
        static U8 PST_man_op[41] = {
            0,0,0,0,0,   // 0 .. 4
            15,40,42,45,0,              // 5 .. 8 (9)
            12,38,36,15,                     // 10 .. 13
            28,26,30,20,0,               // 14 .. 17 (18)
            18,26,36,28,                    // 19 .. 22
            32,38,10,18,0,                // 23 .. 26 (27)
            18,22,24,20,                 //  28 .. 31
            26,0,0,0,0,                      // 32 .. 35 (36)
            0,0,0,0                          // 37 .. 40
        };
        
        static U8 PST_man_en[41] = {
            0,0,0,0,0,  // 0 .. 4
            0,2,2,2,    0,                  // 5 .. 8 (9)
            4,4,4,4,                     // 10 .. 13
            6,6,6,6,    0,               // 14 .. 17 (18)
            10,10,10,10,                  // 19 .. 22
            16,16,16,16,   0,              // 23 .. 26 (27)
            22,22,22,22,                //  28 .. 31
            30,0,0,0,         0,            // 32 .. 35 (36)
            0,0,0,0                        // 37 .. 40
        };
        
        static U8 PST_king[41] = {
            0,0,0,0,0,  // 0..4
            20,5,0,10,0, // 5..8 (9)
            20,5,10,10, // 10..13
            5,20,12,10,0, // 14..18
            5,20,12,0, // 19..22
            0,12,20,5,0, // 23..27
            10,12,20,5, // 28..31
            10,10,5,20,0, // 32..36
            10,0,5,20 // 37..40
        };
        uint32_t i;
        int32_t square;
        int32_t opening = 0;
        int32_t endgame = 0;
        //a piece of code to encourage exchanges
        //in case of material advantage:
        // king's balance
        if (nbk != nwk) {
            if (nwk == 0) {
                if (nwm <= 4) {
                    endgame += 50;
                    if (nwm <= 3) {
                        endgame += 100;
                        if (nwm <=2) {
                            endgame += 100;
                            if (nwm <= 1)
                                endgame += 100;
                        }
                    }
                }
            }
            if (nbk == 0) {
                if (nbm <= 4) {
                    endgame -= 50;
                    if (nbm <= 3) {
                        endgame -= 100;
                        if (nbm <= 2) {
                            endgame -= 100;
                            if (nbm <= 1)
                                endgame -= 100;
                        }
                    }
                }
            }
        } else {
            if ((nbk == 0) && (nwk == 0))
                eval += 250*(v1 - v2)/(v1 + v2);
            if (nbk + nwk != 0)
                eval += 100*(v1 - v2)/(v1 + v2);
        }
        
        // special case : very very late endgame
        if ((White < 4) && (Black < 4)) {
            GLAV = 0; // main diagonal a1-h8 control
            for (i = 5; i < 41; i+= 5)
                GLAV += b[i];
            if (eval < 0 && nbk == 1 && GLAV == BLK_KNG) {
                if (nbm == 0 || b[32] == BLK_MAN) {
                    pos->EvalHash[(U32)(pos->HASH_KEY & EC_MASK)] = (pos->HASH_KEY & 0xffffffffffff0000) | (0 & 0xffff);
                    return (0);
                }
            }
            if (eval > 0 && nwk == 1 && GLAV == WHT_KNG) {
                if (nwm == 0 || b[13] == WHT_MAN) {
                    pos->EvalHash[(U32)(pos->HASH_KEY & EC_MASK)] = (pos->HASH_KEY & 0xffffffffffff0000) | (0 & 0xffff);
                    return (0);
                }
            }
            if ((nwk != 0) && (nbk != 0) && (nbm == 0) && (nwm == 0)) {
                // only kings left
                if (nbk == 1 && nwk == 3) {
                    int32_t double_r1 = is_wht_kng_1(b); //
                    int32_t double_r2 = is_wht_kng_2(b); //
                    if ((double_r1 < 3) && (double_r2 < 3)) {
                        if (double_r1 + double_r2 == 3)
                            eval -= 300;
                        if (double_r1 + double_r2 == 2)
                            eval -= 300;
                        if (double_r1 + double_r2 == 1)
                            eval -= 100;
                    }
                    
                    int32_t triple_r1 = is_wht_kng_3(b); //
                    int32_t triple_r2 = is_wht_kng_4(b); //
                    if ((triple_r1 < 3) && (triple_r2 < 3)) {
                        if (triple_r1 + triple_r2 == 3)
                            eval -= 200;
                        if (triple_r1 + triple_r2 == 2)
                            eval -= 200;
                        if (triple_r1 + triple_r2 == 1)
                            eval -= 100;
                    }
                    if (is_blk_kng_1(b) == 0 && is_blk_kng_2(b) == 0) {
                        if (is_blk_kng_3(b) == 0 && is_blk_kng_4(b) == 0) {
                            if (color == BLACK) {
                                if ((b[15] == WHT_KNG) && (b[29] == WHT_KNG) && (b[16] == WHT_KNG))
                                    eval -= 1000;
                                if ((b[29] == WHT_KNG) && (b[16] == WHT_KNG) && (b[30] == WHT_KNG))
                                    eval -= 1000;
                                if ((b[15] == WHT_KNG) && (b[24] == WHT_KNG) && (b[21] == WHT_KNG))
                                    eval -= 1000;
                                if ((b[24] == WHT_KNG) && (b[21] == WHT_KNG) && (b[30] == WHT_KNG))
                                    eval -= 1000;
                            }
                        }
                    }
                }
                if (nwk == 1 && nbk == 3) {
                    int32_t double_r1 = is_blk_kng_1(b); //
                    int32_t double_r2 = is_blk_kng_2(b); //
                    if ((double_r1 < 3) && (double_r2 < 3)) {
                        if (double_r1 + double_r2 == 3)
                            eval += 300;
                        if (double_r1 + double_r2 ==2)
                            eval += 300;
                        if (double_r1 + double_r2 == 1)
                            eval += 100;
                    }
                    int32_t triple_r1 = is_blk_kng_3(b); //
                    int32_t triple_r2 = is_blk_kng_4(b); //
                    if ((triple_r1  < 3 ) && (triple_r2 < 3)) {
                        if (triple_r1 + triple_r2 == 3)
                            eval += 200;
                        if (triple_r1 + triple_r2 == 2)
                            eval += 200;
                        if (triple_r1 + triple_r2 == 1)
                            eval += 100;
                    }
                    if (is_wht_kng_1(b) == 0 && is_wht_kng_2(b) == 0) {
                        if (is_wht_kng_3(b) == 0 && is_wht_kng_4(b) == 0) {
                            if (color == WHITE) {
                                if ((b[15] == BLK_KNG) && (b[29] == BLK_KNG) && (b[16] == BLK_KNG))
                                    eval += 1000;
                                if ((b[29] == BLK_KNG) && (b[16] == BLK_KNG) && (b[30] == BLK_KNG))
                                    eval += 1000;
                                if ((b[15] == BLK_KNG) && (b[24] == BLK_KNG) && (b[21] == BLK_KNG))
                                    eval += 1000;
                                if ((b[24] == BLK_KNG) && (b[21] == BLK_KNG) && (b[30] == BLK_KNG))
                                    eval += 1000;
                            }
                        }
                    }
                }
                for (i = 1; i <= pos->num_bpieces; i++) {
                    if ((square = pos->p_list[BLACK][i]) == 0)
                        continue;
                    if ((b[square] & KING) != 0) // black king
                        eval += PST_king[square];
                } // for
                
                for (i = 1; i <= pos->num_wpieces; i++) {
                    if ((square = pos->p_list[WHITE][i]) == 0)
                        continue;
                    if ((b[square] & KING) != 0) // white king
                        eval -= PST_king[square];
                } // for
                // negamax formulation requires this:
                eval = ( color == BLACK ) ? eval : -eval;
                pos->EvalHash[(U32)(pos->HASH_KEY & EC_MASK)] = (pos->HASH_KEY & 0xffffffffffff0000) | (eval & 0xffff);
                return (eval);
            } // only kings left
            if (nbk == 0 && nwk == 0) { // only men left
                // strong opposition
                if (b[19] == BLK_MAN)
                    if ((b[32] == WHT_MAN) && (b[28] == WHT_MAN))
                        if ((b[23] == FREE) && (b[24] == FREE))
                            eval += 24;
                if (b[26] == BLK_MAN)
                    if ((b[40] == WHT_MAN) && (b[35] == WHT_MAN))
                        if ((b[30] == FREE) && (b[31] == FREE))
                            eval += 24;
                
                if (b[26] == WHT_MAN)
                    if ((b[13] == BLK_MAN) && (b[17] == BLK_MAN))
                        if ((b[21] == FREE) && (b[22] == FREE))
                            eval -= 24;
                if (b[19] == WHT_MAN)
                    if ((b[5] == BLK_MAN) && (b[10] == BLK_MAN))
                        if ((b[14] == FREE) && (b[15] == FREE))
                            eval -= 24;
                
                // most favo(u)rable opposition
                
                if ((b[28] == BLK_MAN) && (b[37] == WHT_MAN) && (b[38] == FREE))
                    if ((b[32] == FREE) && (b[33] == FREE))
                        eval += 28;
                if ((b[17] == WHT_MAN) && (b[8] == BLK_MAN) && (b[7] == FREE))
                    if ((b[12] == FREE ) && (b[13] == FREE))
                        eval -= 28;
            } // only men left
        } // special case : very very late endgame
        
        
        // piece-square-tables
        
        for (i = 1; i <= pos->num_bpieces; i++) {
            if ((square = pos->p_list[BLACK][i] ) == 0)
                continue;
            if ((b[square] & MAN ) != 0) { // black man
                opening += PST_man_op[square];
                endgame += PST_man_en[square];
            }
        } // for
        
        for (i = 1;i <= pos->num_wpieces; i++) {
            if ((square = pos->p_list[WHITE][i]) == 0)
                continue;
            if ((b[square] & MAN) != 0) {  // white man
                opening -= PST_man_op[ 45 - square];
                endgame -= PST_man_en[ 45 - square];
            }
        } // for
        
        int32_t phase = nbm + nwm - nbk - nwk;
        if (phase < 0)
            phase = 0;
        int32_t antiphase = 24 - phase;
        
        eval += ((opening * phase + endgame * (antiphase))/24);
        if ((White + Black < 8) && nbk != 0 && nwk != 0 && nbm != 0 && nwm != 0) {
            if (abs(nbm - nwm) <= 1 && abs(nbk - nwk) <= 1 && abs(White - Black ) <= 1) {
                eval /= 2;
            }
        }
        //Lazy evaluation
        // Early exit from evaluation if eval already is extremely low or extremely high
        if (beta - alpha == 1) {
            int32_t teval = (color == WHITE) ? -eval : eval;
            if ((teval - 130) > beta)
                return teval;
            if ((teval + 130) < alpha)
                return teval;
        }
        
        static U8 edge1[4] = { 5, 14, 23, 32};
        static U8 edge2[3] = { 13, 22, 31};
        // 0   1    2    3    4     5    6     7     8   9  10  11 12
        static U8 edge_malus[13] = {0 ,60 , 40 ,30, 20 , 5 ,  5 ,   5 ,   0 , 0 , 0 ,   0 , 0 };
        int32_t nbme = 0;
        int32_t nwme = 0;
        /* men on edges */
        if (nbm <= 4 && nwm <= 4) {
            for(i = 0; i < 4; i++) {
                if (b[edge1[i]] == BLK_MAN) {
                    if ((b[edge1[i] + 5] == FREE) && (b[edge1[i] + 10] == WHT_MAN))
                        nbme++;
                    else if(b[edge1[i] + 1 ] == WHT_MAN)
                        nbme++;
                }
                if (b[edge1[i]] == WHT_MAN) {
                    if ((b[edge1[i] - 4] == FREE) && (b[edge1[i] - 8 ] == BLK_MAN))
                        nwme++;
                    else if(b[edge1[i] + 1] == BLK_MAN)
                        nwme++;
                }
            };
            for (i = 0; i < 3; i++) {
                if (b[edge2[i]] == BLK_MAN) {
                    if ((b[edge2[i] + 4 ] == FREE) && (b[edge2[i] + 8] == WHT_MAN))
                        nbme++;
                    else if (b[edge2[i] - 1] == WHT_MAN)
                        nbme++;
                }
                if (b[edge2[i]] == WHT_MAN) {
                    if ((b[edge2[i] - 5] == FREE) && (b[edge2[i] - 10] == BLK_MAN))
                        nwme++;
                    else if (b[edge2[i] - 1] == BLK_MAN)
                        nwme++;
                }
            };
        }
        eval -= nbme*edge_malus[nbm];
        eval += nwme*edge_malus[nwm];
        // back rank ( a1,c1,e1,g1 ) guard
        // back rank values
        static S8 br[16] = {0,-1,1, 0,3,3,3,3,2,2,2,2,4,4,8,8  };
        
        int32_t code;
        int32_t backrank;
        code = 0;
        if (b[5] & MAN)
            code++;
        if (b[6] & MAN)
            code+=2;
        if (b[7] & MAN)
            code+=4; // Golden checker
        if (b[8] & MAN)
            code+=8;
        backrank = br[code];
        code = 0;
        if (b[37] & MAN)
            code+=8;
        if (b[38] & MAN)
            code+=4; // Golden checker
        if (b[39] & MAN)
            code+=2;
        if (b[40] & MAN)
            code++;
        backrank -= br[code];
        int32_t* g_pieces = pos->g_pieces;
        int32_t brv = (NOT_ENDGAME ? 2 : 1);  // multiplier for back rank -- back rank value
        eval += brv * backrank;
        
        opening = 0;
        endgame = 0;
        
        if ((nbk == 0) && (nwk == 0)) {
            int32_t j;
            
            // the move : the move is an endgame term that defines whether one side
            // can force the other to retreat
            if (nbm == nwm && nbm + nwm <= 12) {
                // int32_t move;
                
                int32_t stonesinsystem = 0;
                if (color == BLACK && has_man_on_7th(b, BLACK) == 0) {
                    for (i=5; i <= 8; i++) {
                        for (j=0; j < 4; j++) {
                            if (b[i+9*j] != FREE)
                                stonesinsystem++;
                        }
                    }
                    if (b[32] == BLK_MAN)
                        stonesinsystem++; // exception from the rule
                    if (stonesinsystem % 2) // the number of stones in blacks system is odd -> he has the move
                        endgame += 4;
                    else
                        endgame -= 4;
                }
                
                if (color == WHITE && has_man_on_7th(b , WHITE) == 0) {
                    for (i=10; i <= 13; i++) {
                        for (j=0; j < 4; j++) {
                            if (b[i+9*j] != FREE)
                                stonesinsystem++;
                        }
                    }
                    if (b[13] == WHT_MAN)
                        stonesinsystem++;
                    if (stonesinsystem % 2) // the number of stones in whites system is odd -> he has the move
                        endgame -= 4;
                    else
                        endgame += 4;
                }
            }
            /* balance                */
            /* how equally the pieces are distributed on the left and right sides of the board */
            if (nbm == nwm) {
                int32_t balance = 0;
                int32_t code;
                int32_t index;
                static int32_t value[7] = {0, 0, 0, 0, 0, 1, 256};
                int32_t nbma, nbmb, nbmc, nbmd; // number black men left a-b-c-d
                int32_t nbme, nbmf, nbmg, nbmh; // number black men right e-f-g-h
                int32_t nwma, nwmb, nwmc, nwmd; // number white men left a-b-c-d
                int32_t nwme, nwmf, nwmg, nwmh;  // number white men right e-f-g-h
                // left flank
                code = 0;
                // count file-a men ( on 5,14,23,32 )
                code += value[b[5]];
                code += value[b[14]];
                code += value[b[23]];
                code += value[b[32]];
                nwma = code & 15;
                nbma = (code>>8) & 15;
                code = 0;
                // count file-b men ( on 10,19,28,37 )
                code += value[b[10]];
                code += value[b[19]];
                code += value[b[28]];
                code += value[b[37]];
                nwmb = code & 15;
                nbmb = (code>>8) & 15;
                
                code = 0;
                // count file-c men (on 6, 15, 24, 33)
                code += value[b[6]];
                code += value[b[15]];
                code += value[b[24]];
                code += value[b[33]];
                nwmc = code & 15;
                nbmc = (code>>8) & 15;
                code = 0;
                // count file-d men (on 11, 20, 29, 38)
                code += value[b[11]];
                code += value[b[20]];
                code += value[b[29]];
                code += value[b[38]];
                nwmd = code & 15;
                nbmd = (code>>8) & 15;
                
                // right flank
                code = 0;
                // count file-e men (on 7, 16, 25, 34)
                code += value[b[7]];
                code += value[b[16]];
                code += value[b[25]];
                code += value[b[34]];
                nwme = code & 15;
                nbme = (code>>8) & 15;
                code = 0;
                // count file-f men (on 12, 21, 30, 39)
                code += value[b[12]];
                code += value[b[21]];
                code += value[b[30]];
                code += value[b[39]];
                nwmf = code & 15;
                nbmf = (code>>8) & 15;
                code = 0;
                // count file-g men ( on 8,17,26,35 )
                code += value[b[8]];
                code += value[b[17]];
                code += value[b[26]];
                code += value[b[35]];
                nwmg = code & 15;
                nbmg = (code>>8) & 15;
                code = 0;
                // count file-h men (on 13, 22, 31, 40)
                code += value[b[13]];
                code += value[b[22]];
                code += value[b[31]];
                code += value[b[40]];
                nwmh = code & 15;
                nbmh = (code>>8) & 15;
                
                // 2 blacks stops 3 whites in right flank
                if ((nwmf+nwmg+nwmh+nwme) == 3) {
                    if ((nbmf+nbmg+nbmh+nbme ) == 2) {
                        if ((b[21] == BLK_MAN) && (b[22] == BLK_MAN)) {
                            if ((b[35] == WHT_MAN) && (b[30] == WHT_MAN) && (b[31] == WHT_MAN))
                                endgame += 24;
                        }
                        if ((b[26] == WHT_MAN) && (b[30] == WHT_MAN) && (b[31] == WHT_MAN)) {
                            if ((b[22] == BLK_MAN) && (b[17] == BLK_MAN))
                                endgame += 24;
                        }
                    }
                }
                
                // 2 blacks stops 3 whites in left flank
                int32_t nbmabcd = nbma + nbmb + nbmc + nbmd;
                int32_t nwmabcd = nwma + nwmb + nwmc + nwmd;
                if ((nbmabcd == 2) && (nwmabcd == 3)) {
                    if ((b[23] == BLK_MAN) && (b[20] == BLK_MAN))
                        if ((b[28] == WHT_MAN) && (b[32] == WHT_MAN) && (b[33] == WHT_MAN))
                            endgame += 24;
                    if ((b[14] == BLK_MAN) && (b[11] == BLK_MAN))
                        if ((b[19] == WHT_MAN) && (b[23] == WHT_MAN) && (b[24] == WHT_MAN))
                            endgame += 24;
                }
                // for white color
                // 2 whites stops 3 blacks
                if ((nwma + nwmb + nwmc + nwmd) == 2) {
                    if ((nbma + nbmb + nbmc + nbmd) == 3) {
                        if ((b[23] == WHT_MAN) && (b[24] == WHT_MAN)) {
                            if ((b[10] == BLK_MAN) && (b[14] == BLK_MAN) && (b[15] == BLK_MAN))
                                endgame -= 24;
                        }
                        if ((b[23] == WHT_MAN) && (b[28] == WHT_MAN)) {
                            if ((b[14] == BLK_MAN) && (b[15] == BLK_MAN) && (b[19] == BLK_MAN))
                                endgame -= 24;
                        }
                    }
                }
                
                // 2 whites stops 3 blacks
                int32_t nwmfghe = nwmf + nwmg + nwmh + nwme;
                int32_t nbmfghe = nbmf + nbmg + nbmh + nbme;
                if ((nwmfghe ==2) && (nbmfghe == 3)) {
                    if ((b[22] == WHT_MAN) && (b[25] == WHT_MAN))
                        if ((b[12] == BLK_MAN) && (b[13] == BLK_MAN) && (b[17] == BLK_MAN))
                            endgame -= 24;
                    if ((b[31] == WHT_MAN) && (b[34] == WHT_MAN)) {
                        if ((b[26] == BLK_MAN) && (b[21] == BLK_MAN) && (b[22] == BLK_MAN))
                            endgame -= 24;
                    }
                }
                
                const S8 cscore_center[4][4] = {
                    0 , -8,-20,-30,       // 0 versus 0,1,2,3
                    8,   0,   -8, -20,        // 1 versus 0,1,2,3
                    20,  8,    0,  -4,           // 2 versus  0,1,2,3
                    30, 20,  4,   0           // 3 versus  0,1,2,3
                };
                
                const S8 cscore_edge[4][4] = {
                    0 , -8,-10,-12,       // 0 versus 0,1,2,3
                    8,   0,   -4, -6,        // 1 versus 0,1,2,3
                    10,  4,    0,  - 2,           // 2 versus  0,1,2,3
                    12,  6,    2,   0           // 3 versus  0,1,2,3
                };
                int32_t nbmab = nbma + nbmb;
                int32_t nbmcd = nbmc + nbmd;
                int32_t nbmgh = nbmg + nbmh;
                int32_t nbmef = nbme + nbmf;
                
                
                if (nbmab > 3)
                    nbmab = 3;
                if (nbmcd > 3)
                    nbmcd = 3;
                if (nbmef > 3)
                    nbmef = 3;
                if (nbmgh > 3)
                    nbmgh = 3;
                
                int32_t nwmab = nwma + nwmb;
                int32_t nwmcd = nwmc + nwmd;
                int32_t nwmef = nwme + nwmf;
                int32_t nwmgh = nwmg + nwmh;
                
                if (nwmab > 3)
                    nwmab = 3;
                if (nwmcd > 3)
                    nwmcd = 3;
                if (nwmef > 3)
                    nwmef = 3;
                if (nwmgh > 3)
                    nwmgh = 3;
                
                eval += cscore_edge[nbmab][nwmab];
                eval += cscore_edge[nbmgh][nwmgh];
                eval += cscore_center[nbmcd][nwmcd];
                eval += cscore_center[nbmef][nwmef];
                
                index = -8*nbma - 4*nbmb -2*nbmc -1*nbmd + 1*nbme + 2*nbmf + 4*nbmg + 8*nbmh;
                balance -= abs(index);
                index = -8*nwma - 4*nwmb -2*nwmc - 1*nwmd  + 1*nwme + 2*nwmf + 4*nwmg + 8*nwmh;
                balance += abs(index);
                eval += balance;
            } // balance
            // mobility check
            int32_t b_free = 0; // black's free moves counter
            int32_t b_exchanges = 0; // black's exchanges counter
            int32_t b_losing = 0; // black's apparently losing moves counter
            
            static U8 bonus[25] = {0,6,12,18,24,30,36,42,48,54,60,64,70,76,82,88,94,100,100,100,100,100,100,100,100};
            for (i = 1; i <= pos->num_bpieces; i++) {
                if ((square = pos->p_list[BLACK][i]) == 0)
                    continue;
                if (b[square+5] == FREE) {
                    do {
                        int32_t is_square_safe = 1;
                        int32_t can_recapture = 0;
                        if ((b[square+10] & WHITE ) != 0) { // (1) danger
                            is_square_safe = 0;
                            // can white capture from square
                            if (((b[square-4] & BLACK) != 0) && (b[square-8] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square-5] & BLACK) != 0) && (b[square-10] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square+4] & BLACK ) != 0) && (b[square+8] == FREE)) {
                                b_losing++;
                                break;
                            }
                            // can black recapture square
                            if ((b[square-5] & BLACK) != 0)
                                can_recapture = 1;
                            else if (((b[square-4] & BLACK) != 0)  && (b[square+4] == FREE))
                                can_recapture = 1;
                            else if ((b[square-4] == FREE) && ((b[square+4] & BLACK) != 0))
                                can_recapture = 1;
                            else {
                                b_losing++;
                                break;
                            }
                        } // (1) danger
                        
                        if (((b[square+9] & WHITE) != 0) && (b[square+1] == FREE)) { // (2) danger
                            is_square_safe = 0;
                            // can white capture from (square+1)
                            if (((b[square-3] & BLACK) != 0) && (b[square-7] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square-4] & BLACK) != 0) && (b[square-9] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square+6] & BLACK) != 0) && (b[square+11] == FREE)) {
                                b_losing++;
                                break;
                            }
                            // can black recapture (square+1)
                            if ((b[square-3] & BLACK ) != 0)
                                can_recapture = 1;
                            else if (((b[square-4] & BLACK) != 0)  && (b[square+6] == FREE))
                                can_recapture = 1;
                            else if ((b[square-4] == FREE) && ((b[square+6] & BLACK) != 0))
                                can_recapture = 1;
                            else {
                                b_losing++;
                                break;
                            }
                        } // (2) danger
                        
                        if (((b[square+4] & BLACK) != 0) && ((b[square+8] & WHITE) != 0)) { // (3) danger
                            is_square_safe = 0;
                            // can white capture from square
                            if (b[square+10] == FREE) {
                                b_losing++;
                                break;
                            }
                            if (((b[square-5] & BLACK) != 0) && (b[square-10] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square-4] & BLACK) != 0) && (b[square-8] == FREE)) {
                                b_losing++;
                                break;
                            }
                            // can black recapture square
                            if (b[square-5] == FREE)
                                can_recapture = 1;
                            else if ((b[square-4] & BLACK) != 0)
                                can_recapture = 1;
                            else {
                                b_losing++;
                                break;
                            }
                        } // (3) danger
                        
                        if ((b[square+9] == FREE) && ((b[square+1] & WHITE) != 0)) { // (4) danger
                            is_square_safe = 0;
                            // can white capture from square+9
                            if (((b[square+4] & BLACK) != 0) && (b[square-1] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square+14] & BLACK) != 0) && (b[square+19] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square+13] & BLACK) != 0) && (b[square+17] == FREE)) {
                                b_losing++;
                                break;
                            }
                            // can black recapture square+9
                            if ((b[square+13] & BLACK) != 0)
                                can_recapture = 1;
                            else if (((b[square+4] & BLACK) != 0)  && (b[square+14] == FREE))
                                can_recapture = 1;
                            else if ((b[square+4] == FREE) && ((b[square+14] & BLACK) != 0))
                                can_recapture = 1;
                            else {
                                b_losing++;
                                break;
                            }
                        } // (4) danger
                        
                        // incomplete dangers
                        if (((b[square-5] & BLACK) != 0) && ((b[square-10] & WHITE) != 0)) {
                            break;
                        } // (5)
                        if (((b[square-4] & BLACK) != 0) && ((b[square-8] & WHITE) != 0)) {
                            break;
                        } // (6)
                        // assert( is_square_safe^can_recapture == 1 );
                        b_free += is_square_safe;
                        b_exchanges += can_recapture;
                    } while (0);
                };
                
                if (b[square+4] == FREE) {
                    do {
                        int32_t is_square_safe = 1;
                        int32_t can_recapture = 0;
                        if ((b[square+8] & WHITE) != 0) { // (1) danger
                            is_square_safe = 0;
                            // can white capture from square
                            if (((b[square-4] & BLACK) != 0) && (b[square-8] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square+5] & BLACK) != 0) && (b[square+10] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square-5] & BLACK ) != 0) && (b[square-10] == FREE)) {
                                b_losing++;
                                break;
                            }
                            // can black recapture square
                            if ((b[square-4] & BLACK) != 0)
                                can_recapture = 1;
                            else if (((b[square-5] & BLACK) != 0) && (b[square+5] == FREE))
                                can_recapture = 1;
                            else if ((b[square-5] == FREE) && ((b[square+5] & BLACK) != 0))
                                can_recapture = 1;
                            else {
                                b_losing++;
                                break;
                            }
                        } // (1) danger
                        
                        if (((b[square+9] & WHITE) != 0) && (b[square-1] == FREE)) { // (2) danger
                            is_square_safe = 0;
                            // can white capture from (square-1)
                            if (((b[square-5] & BLACK) != 0) && (b[square-9] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square-6] & BLACK) != 0) && (b[square-11] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square+3] & BLACK) != 0) && (b[square+7] == FREE)) {
                                b_losing++;
                                break;
                            }
                            // can black recapture (square-1)
                            if ((b[square-6] & BLACK) != 0)
                                can_recapture = 1;
                            else if (((b[square-5] & BLACK ) != 0)  && (b[square+3] == FREE))
                                can_recapture = 1;
                            else if ((b[square-5] == FREE) && ((b[square+3] & BLACK ) != 0))
                                can_recapture = 1;
                            else {
                                b_losing++;
                                break;
                            }
                        } // (2) danger
                        
                        if (((b[square+5] & BLACK) != 0) && ((b[square+10] & WHITE) != 0)) { // (3) danger
                            is_square_safe = 0;
                            // can white capture from square
                            if (b[square+8] == FREE) {
                                b_losing++;
                                break;
                            }
                            if (((b[square-5] & BLACK) != 0) && (b[square-10] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square-4] & BLACK) != 0) && (b[square-8] == FREE)) {
                                b_losing++;
                                break;
                            }
                            // can black recapture square
                            if (b[square-4] == FREE)
                                can_recapture = 1;
                            else if ((b[square-5] & BLACK) != 0)
                                can_recapture = 1;
                            else {
                                b_losing++;
                                break;
                            }
                        } // (3) danger
                        
                        if ((b[square+9] == FREE) && ((b[square-1] & WHITE) != 0)) {  // (4) danger
                            is_square_safe = 0;
                            // can white capture from square+9
                            if (((b[square+5] & BLACK) != 0) && (b[square+1] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square+14] & BLACK) != 0) && (b[square+19] == FREE)) {
                                b_losing++;
                                break;
                            }
                            if (((b[square+13] & BLACK) != 0) && (b[square+17] == FREE)) {
                                b_losing++;
                                break;
                            }
                            // can black recapture square+9
                            if ((b[square+14] & BLACK) != 0)
                                can_recapture = 1;
                            else if (((b[square+5] & BLACK) != 0) && (b[square+13] == FREE))
                                can_recapture = 1;
                            else if ((b[square+5] == FREE) && ((b[square+13] & BLACK ) != 0))
                                can_recapture = 1;
                            else {
                                b_losing++;
                                break;
                            }
                        }
                        // incomplete dangers
                        if (((b[square-4] & BLACK) != 0) && ((b[square-8] & WHITE) != 0)) {
                            break;
                        } // (5)
                        if (((b[square-5] & BLACK) != 0) && ((b[square-10] & WHITE) != 0)) {
                            break;
                        } // (6)
                        // assert( is_square_safe^can_recapture == 1 );
                        b_free += is_square_safe;
                        b_exchanges += can_recapture;
                    } while (0);
                };
            } // for
            
            int32_t w_free = 0; // white's free moves counter
            int32_t w_exchanges = 0; // white's exchanges counter
            int32_t w_losing = 0; // whites's apparently losing moves counter
            
            for (i = 1; i <= pos->num_wpieces; i++) {
                if ((square = pos->p_list[WHITE][i]) == 0)
                    continue;
                if (b[square-5] == FREE) {
                    do {
                        int32_t is_square_safe = 1;
                        int32_t can_recapture = 0;
                        if ((b[square-10] & BLACK) != 0) { // (1) danger
                            is_square_safe = 0;
                            // can black capture from square
                            if (((b[square+5] & WHITE) != 0) && (b[square+10] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square+4] & WHITE) != 0) && (b[square+8] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square-4] & WHITE) != 0) && (b[square-8] == FREE)) {
                                w_losing++;
                                break;
                            }
                            // can white recapture square
                            if ((b[square+5] & WHITE) != 0)
                                can_recapture = 1;
                            else if (((b[square+4] & WHITE) != 0) && (b[square-4] == FREE))
                                can_recapture = 1;
                            else if ((b[square+4] == FREE) && ((b[square-4] & WHITE ) != 0))
                                can_recapture = 1;
                            else {
                                w_losing++;
                                break;
                            }
                        } // (1) danger
                        
                        if ((b[square-9] & BLACK) != 0 && (b[square-1] == FREE)) { // (2) danger
                            is_square_safe = 0;
                            // can black capture from (square-1)
                            if (((b[square+3] & WHITE) != 0) && (b[square+7] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square+4] & WHITE) != 0) && (b[square+9] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square-6] & WHITE) != 0) && (b[square-11] == FREE)) {
                                w_losing++;
                                break;
                            }
                            // can white recapture (square-1)
                            if ((b[square+3] & WHITE) != 0)
                                can_recapture = 1;
                            else if (((b[square-6] & WHITE) != 0) && (b[square+4] == FREE))
                                can_recapture = 1;
                            else if ((b[square-6] == FREE) && ((b[square+4] & WHITE ) !=0))
                                can_recapture = 1;
                            else {
                                w_losing++;
                                break;
                            }
                        } // (2) danger
                        
                        if ((b[square-4] & WHITE) != 0 && (b[square-8] & BLACK) != 0) { // (3) danger
                            is_square_safe = 0;
                            // can black capture from square
                            if (b[square-10] == FREE ) {
                                w_losing++;
                                break;
                            }
                            if (((b[square+5] & WHITE) != 0) && (b[square+10] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square+4] & WHITE) != 0) && (b[square+8] == FREE)) {
                                w_losing++;
                                break;
                            }
                            // can white recapture square
                            if (b[square+5] == FREE)
                                can_recapture = 1;
                            else if ((b[square+4] & WHITE) != 0)
                                can_recapture = 1;
                            else {
                                w_losing++;
                                break;
                            }
                        } // (3) danger
                        
                        if ((b[square-9] == FREE) && (b[square-1] & BLACK ) != 0) { // (4) danger
                            is_square_safe = 0;
                            // can black capture from square-9
                            if (((b[square-4] & WHITE) != 0) && (b[square+1] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square-14] & WHITE) != 0) && (b[square-19] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square-13] & WHITE) != 0) && (b[square-17] == FREE)) {
                                w_losing++;
                                break;
                            }
                            // can white recapture square-9
                            if ((b[square-13] & WHITE) != 0)
                                can_recapture = 1;
                            else if (((b[square-14] & WHITE) != 0) && (b[square-4] == FREE))
                                can_recapture = 1;
                            else if ((b[square-14] == FREE) && ((b[square-4] & WHITE) !=0))
                                can_recapture = 1;
                            else {
                                w_losing++;
                                break;
                            }
                        } // (4)
                        
                        // incomplete
                        if ((b[square+5] & WHITE)!=0 && (b[square+10] & BLACK)!=0) {
                            break;
                        } // (5)
                        if ((b[square+4] & WHITE)!=0 && (b[square+8] & BLACK)!=0) {
                            break;
                        } // (6)
                        
                        // assert( is_square_safe^can_recapture == 1 );
                        w_free += is_square_safe;
                        w_exchanges += can_recapture;
                    } while (0);
                };
                
                if (b[square-4] == FREE) {
                    do {
                        int32_t is_square_safe = 1;
                        int32_t can_recapture = 0;
                        if ((b[square-8] & BLACK) != 0) { // (1) danger
                            is_square_safe = 0;
                            // can black capture from square
                            if (((b[square+4] & WHITE) != 0) && (b[square+8] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square+5] & WHITE) != 0) && (b[square+10] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square-5] & WHITE) != 0) && (b[square-10] == FREE)) {
                                w_losing++;
                                break;
                            }
                            // can white recapture square
                            if ((b[square+4] & WHITE) != 0)
                                can_recapture = 1;
                            else if (((b[square+5] & WHITE) != 0) && (b[square-5] == FREE))
                                can_recapture = 1;
                            else if ((b[square+5] == FREE) && ((b[square-5] & WHITE) != 0))
                                can_recapture = 1;
                            else {
                                w_losing++;
                                break;
                            }
                        } // (1) danger
                        
                        if ((b[square-9] & BLACK) != 0 && (b[square+1] == FREE)) { // (2) danger
                            is_square_safe = 0;
                            // can black capture from (square+1)
                            if (((b[square+6] & WHITE) != 0) && (b[square+11] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square+5] & WHITE) != 0) && (b[square+9] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square-3] & WHITE) != 0) && (b[square-7] == FREE)) {
                                w_losing++;
                                break;
                            }
                            // can white recapture (square+1)
                            if (((b[square+6] & WHITE) != 0))
                                can_recapture = 1;
                            else if (((b[square-3] & WHITE) != 0) && (b[square+5] == FREE))
                                can_recapture = 1;
                            else if ((b[square-3] == FREE) && ((b[square+5] & WHITE ) != 0))
                                can_recapture = 1;
                            else {
                                w_losing++;
                                break;
                            }
                        } // (2) danger
                        
                        if ((b[square-5] & WHITE) != 0 && (b[square-10] & BLACK) != 0) { // (3) danger
                            is_square_safe = 0;
                            // can black capture from square
                            if (b[square-8] == FREE) {
                                w_losing++;
                                break;
                            }
                            if (((b[square+5] & WHITE) != 0) && (b[square+10] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square+4] & WHITE) != 0) && (b[square+8] == FREE)) {
                                w_losing++;
                                break;
                            }
                            // can white recapture square
                            if (b[square+4] == FREE)
                                can_recapture = 1;
                            else if ((b[square+5] & WHITE) != 0)
                                can_recapture = 1;
                            else {
                                w_losing++;
                                break;
                            }
                        } // (3) danger
                        
                        if ((b[square-9] == FREE) && ((b[square+1] & BLACK) != 0)) { // (4) danger
                            is_square_safe = 0;
                            // can black capture from square-9
                            if (((b[square-14] & WHITE) != 0) && (b[square-19] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square-13] & WHITE) != 0) && (b[square-17] == FREE)) {
                                w_losing++;
                                break;
                            }
                            if (((b[square-5] & WHITE) != 0) && (b[square-1] == FREE)) {
                                w_losing++;
                                break;
                            }
                            // can white recapture square-9
                            if ((b[square-14] & WHITE) != 0)
                                can_recapture = 1;
                            else if (((b[square-13] & WHITE) != 0) && (b[square-5] == FREE))
                                can_recapture = 1;
                            else if ((b[square-13] == FREE) && ((b[square-5] & WHITE ) !=0))
                                can_recapture = 1;
                            else {
                                w_losing++;
                                break;
                            }
                        } // (4)
                        
                        // incomplete dangers
                        if (((b[square+4] & WHITE) !=0) && ((b[square+8] & BLACK) !=0)) {
                            break;
                        } // (5)
                        if (((b[square+5] & WHITE) !=0) && ((b[square+10] & BLACK) !=0)) {
                            break;
                        } // (6)
                        // assert( is_square_safe^can_recapture == 1 );
                        w_free += is_square_safe;
                        w_exchanges += can_recapture;
                    } while (0);
                };
                
                
            } // for
            
            if (b_exchanges) {
                eval += 4*b_exchanges;
            }
            
            if (w_exchanges) {
                eval -= 4*w_exchanges;
            }
            
            eval += w_losing;
            eval -= b_losing;
            // free moves bonuses
            eval += bonus[b_free];
            eval -= bonus[w_free];
            
            if (b_free == 0 && b_exchanges == 0)
                eval -= 36;
            if (b_free == 0 && b_exchanges == 1)
                eval -= 36;
            
            if (w_free == 0 && w_exchanges == 0)
                eval += 36;
            if (w_free == 0 && w_exchanges == 1)
                eval += 36;
        } // if ( (nbk == 0) && (nwk == 0) )
        
        // developed black's single corner
        if ((b[5] == FREE ) && (b[10] == FREE)) {
            opening += 20;
            if ((b[14] != WHT_MAN) && (b[15] != WHT_MAN))
                endgame += 20;
        }
        // developed white's single corner
        if ((b[40] == FREE) && (b[35] == FREE)) {
            opening -= 20;
            if ((b[30] != BLK_MAN) && (b[31] != BLK_MAN))
                endgame -= 20;
        }
        // one pattern ( V. K. Adamovich , Genadij I. Xackevich , Viktor Litvinovich )
        if ((b[15] == BLK_MAN) && (b[30] == WHT_MAN)) {
            if ((b[16] == BLK_MAN) && (b[21] == BLK_MAN)) {
                if ((b[24] == WHT_MAN) && (b[29] == WHT_MAN)) {
                    if ((b[20] == FREE) && (b[25] == FREE)) {
                        if (color == BLACK)
                            if ((b[23] != WHT_MAN) || (b[19] != BLK_MAN))
                                eval += 8;
                        if (color == WHITE)
                            if ((b[22] != BLK_MAN) || (b[26] != WHT_MAN))
                                eval -= 8;
                    }
                }
            }
        }
        // parallel checkers
        if ((b[8] == BLK_MAN) && (b[16] == BLK_MAN))
            if (b[12] + b[7] + b[20] == FREE)
                endgame -= 24;
        if ((b[13] == BLK_MAN) && (b[21] == BLK_MAN))
            if (b[12] + b[17] + b[25] == FREE)
                endgame -= 24;
        if ((b[37] == WHT_MAN) && (b[29] == WHT_MAN))
            if (b[38] + b[33] + b[25] == FREE )
                endgame += 24;
        if ((b[32] == WHT_MAN) && (b[24] == WHT_MAN))
            if (b[33] + b[28] + b[20] == FREE)
                endgame += 24;
        // passers on b6,d6,f6,h6
        if (b[28] == BLK_MAN) { // b6 ?
            do {
                if ((b[32] == FREE) && (b[37] == FREE)) {
                    endgame += 24;
                    break;
                }
                if (color != BLACK)
                    break;
                if ((b[38] & WHITE) != 0)
                    break;
                if (b[33] != FREE)
                    break;
                if (((b[37] & WHITE) != 0) && (b[29] == FREE))
                    break;
                if (((b[29] & WHITE) != 0) && (b[37] == FREE))
                    break;
                endgame += 12;
            } while(0);
        }
        
        if (b[29] == BLK_MAN) { // d6 ?
            do {
                if (color != BLACK)
                    break;
                if (b[34] != FREE)
                    break;
                if ((b[39] & WHITE) != 0)
                    break;
                if ((b[38] == FREE) && ((b[30] & WHITE) != 0))
                    break;
                if (((b[38] & WHITE) != 0) && (b[30] == FREE))
                    break;
                endgame += 12;
            } while(0);
            do {
                if (color != BLACK)
                    break;
                if (b[33] != FREE)
                    break;
                if ((b[37] & WHITE) != 0)
                    break;
                if ((b[38] == FREE) && ((b[28] & WHITE) != 0))
                    break;
                if (((b[38] & WHITE) != 0) && (b[28] == FREE))
                    break;
                endgame += 12;
            } while(0);
        }
        
        if (b[30] == BLK_MAN) { // f6 ?
            do {
                if (color != BLACK)
                    break;
                if (b[35] != FREE)
                    break;
                if ((b[40] & WHITE) != 0)
                    break;
                if ((b[39] == FREE) && ((b[31] & WHITE) != 0))
                    break;
                if (((b[39] & WHITE) != 0) && (b[31] == FREE))
                    break;
                endgame += 12;
            } while(0);
            do {
                if (color != BLACK)
                    break;
                if (b[34] != FREE)
                    break;
                if ((b[38] & WHITE) != 0)
                    break;
                if ((b[39] == FREE) && ((b[29] & WHITE) != 0))
                    break;
                if (((b[39] & WHITE) != 0) && (b[29] == FREE))
                    break;
                endgame += 12;
            } while(0);
        }
        
        if (b[31] == BLK_MAN) { // h6 ?
            if (is_wht_kng(b) == 0) {
                if (b[39] == FREE && b[40] == WHT_MAN)
                    endgame += 8;
                if (b[24] == BLK_MAN)  // h6 + c5
                    endgame += 8;
                do {
                    if (color != BLACK)
                        break;
                    if ((b[39] & WHITE ) != 0)
                        break;
                    if (b[35] != FREE)
                        break;
                    if (((b[30] & WHITE) != 0) && (b[40] == FREE))
                        break;
                    if ((b[30] == FREE) && ((b[40] & WHITE) != 0))
                        break;
                    endgame += 12;
                } while(0);
            }
        }
        // passers on a3,c3,e3,g3
        if (b[14] == WHT_MAN) { // a3 ?
            if (is_blk_kng(b) == 0) {
                if (b[6] == FREE && b[5] == BLK_MAN)
                    endgame -= 8;
                if (b[21] == WHT_MAN) // a3 + f4
                    endgame -= 8;
                do {
                    if (color != WHITE)
                        break;
                    if ((b[6] & BLACK) != 0)
                        break;
                    if (b[10] != FREE)
                        break;
                    if (((b[5] & BLACK) != 0) && (b[15] == FREE))
                        break;
                    if ((b[5] == FREE) && ((b[15] & BLACK) != 0))
                        break;
                    endgame -= 12;
                } while(0);
            }
        }
        
        if (b[15] == WHT_MAN) { // c3 ?
            do {
                if (color != WHITE)
                    break;
                if (b[10] != FREE)
                    break;
                if ((b[5] & BLACK) != 0)
                    break;
                if ((b[6] == FREE) && ((b[14] & BLACK) != 0))
                    break;
                if (((b[6] & BLACK) != 0) && (b[14] == FREE))
                    break;
                endgame -= 12;
            } while(0);
            do {
                if (color != WHITE)
                    break;
                if (b[11] != FREE)
                    break;
                if ((b[7] & BLACK) != 0)
                    break;
                if ((b[6] == FREE) && ((b[16] & BLACK) != 0))
                    break;
                if (((b[6] & BLACK) != 0) && (b[16] == FREE))
                    break;
                endgame -= 12;
            } while(0);
        }
        
        if (b[16] == WHT_MAN) { // e3 ?
            do {
                if (color != WHITE)
                    break;
                if (b[11] != FREE)
                    break;
                if ((b[6] & BLACK) != 0)
                    break;
                if ((b[7] == FREE) && ((b[15] & BLACK ) != 0))
                    break;
                if (((b[7] & BLACK) != 0) && (b[15] == FREE))
                    break;
                endgame -= 12;
            } while(0);
            do {
                if (color != WHITE)
                    break;
                if (b[12] != FREE)
                    break;
                if ((b[8] & BLACK) != 0)
                    break;
                if ((b[7] == FREE) && ((b[17] & BLACK ) != 0))
                    break;
                if (((b[7] & BLACK) != 0) && (b[17] == FREE))
                    break;
                endgame -= 12;
            } while(0);
        }
        
        if (b[17] == WHT_MAN) { // g3 ?
            do {
                if ((b[8] == FREE) && (b[13] == FREE)) {
                    endgame -= 24;
                    break;
                }
                if (color != WHITE)
                    break;
                if ((b[7] & BLACK) != 0)
                    break;
                if (b[12] != FREE)
                    break;
                if (((b[8] & BLACK) != 0) && (b[16] == FREE))
                    break;
                if ((b[8] == FREE) && ((b[16] & BLACK) != 0))
                    break;
                endgame -= 12;
            } while(0);
        }
        // stroennost shashek
        const int32_t shadow = 5; // bonus for stroennost
        // stroennost for black
        if ((b[16] & BLACK) != 0)
            if ((b[11] & BLACK) != 0)
                if ((b[6] & BLACK) != 0)
                    if (b[21] == FREE)
                        eval += shadow;
        if ((b[16] & BLACK) != 0)
            if ((b[12] & BLACK) != 0)
                if ((b[8] & BLACK) != 0)
                    if (b[20] == FREE)
                        eval += shadow;
        if ((b[20] & BLACK) != 0)
            if ((b[15] & BLACK) != 0)
                if ((b[10] & BLACK) != 0)
                    if (b[25] == FREE)
                        eval += shadow;
        if ((b[20] & BLACK) != 0)
            if ((b[16] & BLACK) != 0)
                if ((b[12] & BLACK) != 0)
                    if (b[24] == FREE)
                        eval += shadow;
        if ((b[25] & BLACK) != 0)
            if ((b[20] & BLACK) != 0)
                if ((b[15] & BLACK) != 0)
                    if (b[30] == FREE)
                        eval += shadow;
        
        // stroennost for white
        if ((b[29] & WHITE) != 0)
            if ((b[34] & WHITE) != 0)
                if ((b[39] & WHITE) != 0)
                    if (b[24] == FREE)
                        eval -= shadow;
        if ((b[29] & WHITE) != 0)
            if ((b[33] & WHITE) != 0)
                if ((b[37] & WHITE) != 0)
                    if (b[25] == FREE)
                        eval -= shadow;
        if ((b[25] & WHITE) != 0)
            if ((b[30] & WHITE) != 0)
                if ((b[35] & WHITE) != 0)
                    if (b[20] == FREE)
                        eval -= shadow;
        if ((b[25] & WHITE) != 0)
            if ((b[29] & WHITE) != 0)
                if ((b[33] & WHITE) != 0)
                    if (b[21] == FREE)
                        eval -= shadow;
        if ((b[20] & WHITE) != 0)
            if ((b[25] & WHITE) != 0)
                if ((b[30] & WHITE) != 0)
                    if (b[15] == FREE)
                        eval -= shadow;
        // end stroennost
        int32_t attackers, defenders;
        if (b[24] == BLK_MAN) { // b[24] safety
            if (b[25] == WHT_MAN)
                eval -= 10;
            if ((b[31] != BLK_MAN) && (b[34] == WHT_MAN) && (b[39] == WHT_MAN))
                eval -= 10; // bad for b[24]
            if ((b[23] == WHT_MAN) && (b[14] != FREE) && (b[15] == FREE) && (b[19] == FREE))
                eval -= 10; // bad for b[24]
            attackers = defenders = 0;
            if (b[5] == BLK_MAN)
                defenders++;
            if (b[6] == BLK_MAN)
                defenders++;
            if (b[10] == BLK_MAN)
                defenders++;
            if (b[14] == BLK_MAN)
                defenders++;
            if (b[29] == WHT_MAN)
                attackers++;
            if (b[33] == WHT_MAN)
                attackers++;
            if (b[37] == WHT_MAN)
                attackers++;
            if (b[38] == WHT_MAN)
                attackers++;
            // must be defenders >= attackers
            if (defenders < attackers)
                eval -= 20;
        }
        
        if (b[21] == WHT_MAN) { // b[21] safety
            if (b[20] == BLK_MAN)
                eval += 10;
            if ((b[14] != WHT_MAN) && (b[6] == BLK_MAN) && (b[11] == BLK_MAN))
                eval += 10; // bad for b[21]
            if ((b[22] == BLK_MAN) && (b[31] != FREE) && (b[30] == FREE) && (b[26] == FREE))
                eval += 10; // bad for b[21]
            attackers = defenders = 0;
            if (b[39] == WHT_MAN)
                defenders++;
            if (b[40] == WHT_MAN)
                defenders++;
            if (b[35] == WHT_MAN)
                defenders++;
            if (b[31] == WHT_MAN)
                defenders++;
            if (b[16] == BLK_MAN)
                attackers++;
            if (b[12] == BLK_MAN)
                attackers++;
            if (b[8] == BLK_MAN)
                attackers++;
            if (b[7] == BLK_MAN)
                attackers++;
            // must be defenders >= attackers
            if (defenders < attackers)
                eval += 20;
        }
        
        // blocked pieces in quadrants
        if ((b[23] == WHT_MAN) && (b[14] == BLK_MAN) && (b[15] == BLK_MAN) && (b[19] == BLK_MAN)) {
            eval -= 40;
        }
        
        if ((b[11] == BLK_MAN) && (b[15] == BLK_MAN) && (b[16] == BLK_MAN) && (b[20] == BLK_MAN)) {
            if ((b[24] == WHT_MAN) && (b[28] == WHT_MAN) && (b[25] == WHT_MAN) && (b[30] == WHT_MAN)) {
                eval -= 40;
                if ((b[6] == BLK_MAN) && (b[10] == FREE) && (b[14] != WHT_MAN))
                    eval += 10;
                if ((b[7] == BLK_MAN) && (b[12] == FREE) && (b[17] != WHT_MAN))
                    eval += 10;
            }
        }
        
        if ((b[12] == BLK_MAN) && (b[16] == BLK_MAN) && (b[17] == BLK_MAN) && (b[21] == BLK_MAN)) {
            if ((b[22] == WHT_MAN) && (b[26] == WHT_MAN) && (b[31] == WHT_MAN)) {
                eval -= 40;
                if (b[23] == BLK_MAN)
                    eval += 5;
                if ((b[8] == BLK_MAN) && (b[13] == FREE))
                    eval += 5;
            }
        }
        
        if ((b[15] == BLK_MAN) && (b[19] == BLK_MAN) && (b[20] == BLK_MAN) && (b[24] == BLK_MAN)) {
            eval -= 40;
            if ((b[10] == BLK_MAN) && (b[14] == FREE))
                eval += 10;
            if ((b[11] == BLK_MAN) && (b[16] == FREE) && (b[21] != WHT_MAN))
                eval += 10;
        }
        
        if ((b[16] == BLK_MAN) && (b[20] == BLK_MAN) && (b[21] == BLK_MAN) && (b[25] == BLK_MAN)) {
            eval -= 40;
            if ((b[11] == BLK_MAN) && (b[15] == FREE) && (b[19] != WHT_MAN))
                eval += 10;
            if ((b[12] == BLK_MAN) && (b[17] == FREE) && (b[22] != WHT_MAN))
                eval += 10;
        }
        
        if ((b[34] == WHT_MAN) && (b[31] == WHT_MAN) && (b[17] == BLK_MAN) && (b[21] == BLK_MAN) && (b[22] == BLK_MAN) && (b[26] == BLK_MAN)) {
            eval -= 40;
        }
        //*********************************** for white color
        if ((b[22] == BLK_MAN) && (b[30] == WHT_MAN) && (b[31] == WHT_MAN) && (b[26] == WHT_MAN)) {
            eval += 40;
        }
        
        if ((b[33] == WHT_MAN) && (b[28] == WHT_MAN) && (b[29] == WHT_MAN) && (b[24] == WHT_MAN)) {
            if ((b[23] == BLK_MAN) && (b[19] == BLK_MAN ) && (b[14] == BLK_MAN)) {
                eval += 40;
                if (b[22] == WHT_MAN)
                    eval -= 5;
                if ((b[37] == WHT_MAN ) && (b[32] == FREE))
                    eval -= 5;
            }
        }
        
        if ((b[34] == WHT_MAN) && (b[29] == WHT_MAN) && (b[30] == WHT_MAN) && (b[25] == WHT_MAN)) {
            if ((b[15] == BLK_MAN) && (b[20] == BLK_MAN) && (b[21] == BLK_MAN) && (b[17] == BLK_MAN)) {
                eval += 40;
                if ((b[38] == WHT_MAN) && (b[33] == FREE) && (b[28] != BLK_MAN))
                    eval -= 10;
                if ((b[39] == WHT_MAN) && (b[35] == FREE) && (b[31] != BLK_MAN))
                    eval -= 10;
            }
        }
        if ((b[11] == BLK_MAN) && (b[14] == BLK_MAN) && (b[28] == WHT_MAN) && (b[23] == WHT_MAN) && (b[24] == WHT_MAN) && (b[19] == WHT_MAN)) {
            eval += 40;
        }
        
        if ((b[29] == WHT_MAN) && (b[24] == WHT_MAN) && (b[25] == WHT_MAN) && (b[20] == WHT_MAN)) {
            eval += 40;
            if ((b[33] == WHT_MAN) && (b[28] == FREE) && (b[23] != BLK_MAN))
                eval -= 10;
            if ((b[34] == WHT_MAN) && (b[30] == FREE) && (b[26] != BLK_MAN))
                eval -= 10;
        }
        if ((b[30] == WHT_MAN) && (b[25] == WHT_MAN) && (b[26] == WHT_MAN) && (b[21] == WHT_MAN)) {
            eval += 40;
            if ((b[34] == WHT_MAN) && (b[29] == FREE) && (b[24] != BLK_MAN))
                eval -= 10;
            if ((b[35] == WHT_MAN) && (b[31] == FREE))
                eval -= 10;
        }
        
        // phase mix
        // smooth transition between game phases
        eval += ((opening * phase + endgame * antiphase )/24);
        eval &= ~(GrainSize - 1);
        // negamax formulation requires this:
        eval = ( color == BLACK ) ? eval : -eval;
        pos->EvalHash[(U32)(pos->HASH_KEY & EC_MASK )] = (pos->HASH_KEY & 0xffffffffffff0000) | (eval & 0xffff);
        {
            if(pickBestMove>=0 && pickBestMove<100){
                int32_t random = rand() % (100-pickBestMove);
                int32_t newEval = eval*(100-random)/100;
                // printf("random: %d, %d, %d\n", eval, newEval, random);
                return newEval;
            }
        }
        return (eval);
    }
    
    static struct  coor numbertocoor(int32_t n) {
        /* turns square number n into a coordinate for checkerboard */
        struct coor c;
        
        switch(n) {
            case 5:
                c.x = 0;
                c.y = 0;
                break;
            case 6:
                c.x=2;
                c.y=0;
                break;
            case 7:
                c.x=4;
                c.y=0;
                break;
            case 8:
                c.x=6;
                c.y=0;
                break;
            case 10:
                c.x=1;
                c.y=1;
                break;
            case 11:
                c.x=3;
                c.y=1;
                break;
            case 12:
                c.x=5;
                c.y=1;
                break;
            case 13:
                c.x=7;
                c.y=1;
                break;
            case 14:
                c.x=0;
                c.y=2;
                break;
            case 15:
                c.x=2;
                c.y=2;
                break;
            case 16:
                c.x=4;
                c.y=2;
                break;
            case 17:
                c.x=6;
                c.y=2;
                break;
            case 19:
                c.x=1;
                c.y=3;
                break;
            case 20:
                c.x=3;
                c.y=3;
                break;
            case 21:
                c.x=5;
                c.y=3;
                break;
            case 22:
                c.x=7;
                c.y=3;
                break;
            case 23:
                c.x=0;c.y=4;
                break;
            case 24:
                c.x=2;c.y=4;
                break;
            case 25:
                c.x=4;c.y=4;
                break;
            case 26:
                c.x=6;c.y=4;
                break;
            case 28:
                c.x=1;c.y=5;
                break;
            case 29:
                c.x=3;c.y=5;
                break;
            case 30:
                c.x=5;c.y=5;
                break;
            case 31:
                c.x=7;c.y=5;
                break;
            case 32:
                c.x=0;c.y=6;
                break;
            case 33:
                c.x=2;c.y=6;
                break;
            case 34:
                c.x=4;c.y=6;
                break;
            case 35:
                c.x=6;c.y=6;
                break;
            case 37:
                c.x=1;c.y=7;
                break;
            case 38:
                c.x=3;c.y=7;
                break;
            case 39:
                c.x=5;c.y=7;
                break;
            case 40:
                c.x=7;c.y=7;
                break;
        }
        return c;
    }
    
    
    void Search::setbestmove(struct move2 move)
    {
        int32_t i;
        U8 from, to;
        int32_t jumps;
        struct coor c1;
        
        jumps = move.l - 2;
        
        from = FROM(&move);
        to = TO(&move);
        
        GCBmove.from = numbertocoor(from);
        GCBmove.to = numbertocoor(to);
        GCBmove.jumps = jumps;
        GCBmove.newpiece = (uint32_t)((move.m[1]) >> 6);
        GCBmove.oldpiece = (uint32_t)((move.m[0]) >> 6);
        
        
        for (i = 2; i < move.l; i++) {
            GCBmove.del[i-2] = numbertocoor((uint32_t)((move.m[i]) & 63));
            GCBmove.delpiece[i-2] = ((uint32_t)((move.m[i]) >> 6));
        }
        
        if (jumps > 1) {
            for (i = 2; i < move.l; i++) {
                c1 = numbertocoor( move.path[i - 1] );
                GCBmove.path[i - 1] = c1;
            }
        } else {
            GCBmove.path[1] = numbertocoor(to);
        }
    }
    
    static __inline U8 FROM(struct move2 *move) {
        return ((move->m[0]) & 0x3f);
    }
    
    static __inline U8 TO( struct move2 *move) {
        return ((move->m[1]) & 0x3f);
    }
    
    void movetonotation(struct move2 move, char str[80])
    {
        uint32_t j,from,to;
        char c;
        
        from = FROM(&move);
        to = TO(&move);
        from = from-(from/9);
        to = to-(to/9);
        from -= 5;
        to -= 5;
        j=from%4; from-=j; j=3-j; from+=j;
        j=to%4; to-=j; j=3-j; to+=j;
        from++;
        to++;
        c = '-';
        if(move.l>2)
            c='x'; // capture or normal ?
        sprintf(str,"%2u%c%2u", from, c, to);
    }
    
    U64 rand64(void){
        // Credits: JLKISS64 RNG from David Jones, UCL Bioinformatics Group
        // seed variables
        static U64 x = 123456789123, y = 987654321987;
        static U32 z1 = 43219876, c1 = 6543217, z2 = 21987643, c2 = 1732654;
        
        x = ((U64)1490024343005336237 )* x + 123456789;
        y ^= y << 21; y ^= y >> 17; y ^= y << 30;	// do not set y=0
        
        U64 t;
        t = ((U64)4294584393 ) * z1 + c1; c1 = t >> 32; z1 = t;
        t = ((U64)4246477509) * z2 + c2; c2 = t >> 32; z2 = t;
        
        return x + y + z1 + ((U64)z2 << 32);	// return 64-bit result
    }
    
    static void Create_HashFunction(void){
        // fills ZobristNumbers array with big random numbers
        if (ZobristInitialized)
            return;
        else
            ZobristInitialized = true;
        
        int32_t p,q;
        //srand((unsigned int) time(NULL));
        for (p=5; p<=40 ; p++)
            for ( q=0; q <=15 ; q++)
                ZobristNumbers[p][q] = 0;
        for (p = 5; p <= 40 ; p++) {
            for(q = 0; q <= 15 ; q++) {
                ZobristNumbers[p][q] = rand64();
            }
        }
        HashSTM = rand64(); // constant random number - side to move
        // printf("HashSTM: %llu\n: ", HashSTM);
    }
    
    static U64 Position_to_Hashnumber(int32_t b[46], int32_t color)
    {
        U64 CheckSum = 0;
        int32_t cpos;
        
        for (cpos=5; cpos<41; cpos++) {
            if ((b[cpos] != OCCUPIED) && (b[cpos] != FREE))
                CheckSum ^= ZobristNumbers[cpos][b[cpos]];
        }
        
        if (color == BLACK)
            CheckSum ^= HashSTM;
        
        return (CheckSum);
    }
    
    static void update_hash(struct move2 *move, U64& HASH_KEY) {
        // update HASH_KEY incrementally
        
        uint32_t contents,square;
        
        HASH_KEY ^= HashSTM;
        
        square = (move->m[0]) & 0x3f;
        contents = ((move->m[0]) >> 6);
        HASH_KEY ^= ZobristNumbers[square][contents];
        
        square = (move->m[1]) & 0x3f;
        contents = ((move->m[1]) >> 6);
        HASH_KEY ^= ZobristNumbers[square][contents];
        // captured pieces are below:
        // for(register int32_t i=move->l-1;i>1;i--){
        for (int32_t i=move->l-1; i>1; i--) {
            square = ((move->m[i]) & 0x3f);
            contents = ((move->m[i]) >> 6);
            HASH_KEY ^= ZobristNumbers[square][contents];
        }
    }
    
    void Search::TTableInit(uint32_t hash_mb)
    {
        int32_t j;
        U32 size;
        U32 target;
        
        if (ttable != NULL ){
            free(ttable);
            ttable = NULL;
        }
        
        target = hash_mb;
        target *= 1024 * 1024;
        
        j = sizeof(TEntry);
        
        // printf("TEntry size: %lu\n", sizeof(TEntry));
        assert(j==16); // must be 16 bytes
        
        for (size = 1; ((size != 0) && (size <= target)); size *= 2)
            ;
        size /= 2;
        assert( (size > 0) && (size <= target) );
        // allocate table
        size /= 16;
        assert( (size != 0) && ( (size & (size-1))) == 0 ); // power of 2
        ttable  = (TEntry*) malloc(size*16);
        tableSize = size*16;
        memset(ttable, 0, size*16);
        MASK = size - 4;
    }
    
    void Position::EvalHashClear()
    {
        int32_t c;
        for (c = 0; c < EC_SIZE ; c++)
            EvalHash[c] = 0;
    }
    
    int32_t Search::rootsearch(int32_t b[46], int32_t alpha, int32_t beta, int32_t depth, int32_t color, int32_t search_type)
    {
        int32_t bestvalue;
        int32_t value;
        int32_t i;
        int32_t bestindex = 0;
        U8 bestfrom;
        U8 bestto;
        int32_t root_scores[MAXMOVES]; // root moves scores
        int32_t newdepth;
        U64 L_HASH_KEY;
        
        // for displaying search info
        char ci_str[32]; // current index
        char value_str[16]; // current best value
        char depth_str[16];  // current depth
        char seldepth_str[16]; // current selective depth
        char speed_str[16]; // current speed
        char cm_str[64]; // currently executed move
        
        char string1[255];
        char string2[255];
        char string3[255];
        
        double elapsed; // time variable
        
        if (play)
            return(0);
        nodes++; // increase node count
        const int32_t old_alpha = alpha;
        
        // total number of pieces on board
        uint32_t Pieces = pos->g_pieces[BLK_MAN] + pos->g_pieces[BLK_KNG] + pos->g_pieces[WHT_MAN] + pos->g_pieces[WHT_KNG];
        
        if ( search_type == SearchShort ){
            capture = Test_Capture(b, color, pos);
            if ( capture )
                n = Gen_Captures(b, movelist, color, capture, pos);
            else
                n = Gen_Moves(b,movelist, color, pos);
            if( n == 0 )
                return (-MATE);
        }
        
        EdRoot[color] = EdAccess::not_found;
        /* check for database use */
        if (Pieces <= EdPieces) {
            if ((!EdNocaptures) || (capture == 0) ){
                EdRoot[color] = EdProbe(b, color);
            }
        }
        
        if (EdRoot[color] == EdAccess::win)
            EdRoot[color ^ CC] = EdAccess::lose;
        else if (EdRoot[color] == EdAccess::lose)
            EdRoot[color ^ CC] = EdAccess::win;
        else
            EdRoot[color ^ CC] = EdRoot[color];
        
        for (i = 0; i < n; i++)
            root_scores[i] = -INFINITY1;
        
        L_HASH_KEY = pos->RepNum[pos->realdepth] = pos->HASH_KEY; // save HASH_KEY
        char pv_str[2][1024];
        {
            pv_str[0][0] = 0;
            pv_str[1][0] = 0;
        }
        for ( i = 0;i <= 3;i++ ){
            killersf1[i] = 0;
            killerst1[i] = 0;
            killersf2[i] = 0;
            killerst2[i] = 0;
        }
        
        // MoveToStr(movelist[0], *pv_str); // best move found so far
        inSearch = false;
        bestvalue = -INFINITY1; // preset bestvalue
        // loop through all the moves in the root move list
        for (i = 0; i<n; i++) {
            domove(b, &movelist[i], color, pos);
            inSearch = false;
            newdepth = depth - 1;
            /******************* recursion**************************************************/
            if (bestvalue == -INFINITY1 || depth <= 2)
                value = -PVSearch(b, newdepth, -beta, -alpha, color^CC);
            else{
                if (newdepth <= 3)
                    value = -LowDepth(b, newdepth, -alpha, color^CC);
                else
                    value = -search(b, newdepth, -alpha, color^CC, NodeCut, false);
                if (value > alpha) // research
                    value = -PVSearch(b, newdepth, -alpha - 1, -alpha, color^CC);
                if ( value > alpha ) // research
                    value = -PVSearch(b, newdepth, -beta, -alpha, color^CC);
            }
            /********************************************************************************/
            
            undomove(b, &movelist[i], color, pos);
            // restore HASH_KEY
            pos->HASH_KEY = L_HASH_KEY;
            if (play)
                return (0);
            if (capture == 0) // penalty for repeatable move
                if (abs(value) <= HASHMATE)
                    if ((((movelist[i].m[0]) >> 6) & KING) != 0)
                        if (pos->g_pieces[(color|MAN)] != 0)
                            value--;  // penalty for repeatable move
            // update move scores
            if (value <= alpha) {
                root_scores[i] = old_alpha;
            } else if (value >= beta) {
                root_scores[i] = beta;
            } else {
                root_scores[i] = value;
            }
            
            if (value > bestvalue) {
                bestvalue = value;
                bestindex = i;
            }
            if (value > alpha && search_type == SearchNormal)
                alpha = value;
            if (value >= beta)
                break;
#ifdef KALLISTO
            if (pfSearchInfo) {
                elapsed = (now()-start);
                sprintf(string1, "");
                MoveToStr(movelist[i], string1); // currently executed move
                sprintf(string3, "");
                sprintf(string3, "%2i/%2i  ", i+1, n); // current move number / number of moves
                strcat(string3, string1);
                sprintf(string2, "");
                MoveToStr(movelist[bestindex], string2); // best move found so far
                if (pfSearchInfo) pfSearchInfo(bestvalue, depth, elapsed > 0 ? int32_t(nodes / elapsed / 1000) : 0, string2, string3);
            }
            if ( pfSearchInfoEx ){ // ToSha do not supports pfSearchInfoEx
                // itoa(bestvalue, value_str, 10);
                sprintf(value_str, "%s%d", value_str, bestvalue);
                // itoa(depth, depth_str, 10);
                sprintf(depth_str, "%s%d", depth_str, depth);
                // strcat(depth_str,"/");
                sprintf(depth_str, "%s/", depth_str);
                // itoa(g_seldepth,seldepth_str, 10);
                sprintf(seldepth_str, "%s%d", seldepth_str, g_seldepth);
                // strcat(depth_str,seldepth_str);
                sprintf(depth_str, "%s%s", depth_str, seldepth_str);
                elapsed = (now()-start);
                int32_t speed = elapsed > 0 ? int32_t(nodes / elapsed / 1000) : 0;
                // itoa(speed, speed_str, 10);
                sprintf(speed_str, "%s%d", speed_str, speed);
                // strcat(speed_str," kNps");
                sprintf(speed_str, "%s kNps", speed_str);
                sprintf(ci_str,""); // current index string
                sprintf(ci_str,"%2i/%2i   ",i+1,n); // current move number / number of moves
                MoveToStr(movelist[i],cm_str); // currently executed move
                strcat(ci_str,cm_str); // index + current move
                MoveToStr(movelist[bestindex], *pv_str); // best move found so far
                // pfSearchInfoEx(value_str, depth_str,speed_str,pv_str,ci_str);
            }
            
#endif
        }; // end move loop in the root move list
        
        bestrootmove = movelist[bestindex];
        
#ifdef KALLISTO
        
        if (pfSearchInfoEx){
            if ( i == n ) i--;
            // itoa(bestvalue, value_str, 10);
            sprintf(value_str, "%s%d", value_str, bestvalue);
            // itoa(depth, depth_str, 10);
            sprintf(depth_str, "%s%d", depth_str, depth);
            // strcat(depth_str,"/");
            sprintf(depth_str, "%s/", depth_str);
            // itoa(g_seldepth,seldepth_str, 10); // selective depth
            sprintf(seldepth_str, "%s%d", seldepth_str, g_seldepth);
            // strcat(depth_str,seldepth_str); // depth / selective depth
            sprintf(depth_str, "%s%s", depth_str, seldepth_str);
            elapsed = (now()-start);
            int32_t speed = elapsed > 0 ? int32_t(nodes / elapsed / 1000) : 0;
            // itoa(speed, speed_str, 10);
            sprintf(speed_str, "%s%d", speed_str, speed);
            // strcat(speed_str," kNps");
            sprintf(speed_str, "%s kNps", speed_str);
            sprintf(ci_str,""); // current index string
            sprintf(ci_str,"%2i/%2i   ", i+1, n); // current move number / number of moves
            MoveToStr(movelist[i], cm_str); // currently executed move
            strcat(ci_str, cm_str);
            MoveToStr(movelist[bestindex], *pv_str); // best move found so far
            // pfSearchInfoEx(value_str, depth_str, speed_str, pv_str, ci_str);
        }
        
#endif
        
        bestfrom = FROM( &bestrootmove );
        bestto = TO( &bestrootmove );
        // and save the position in the hashtable
        int32_t f = (bestvalue <= old_alpha ? UPPER : bestvalue >= beta ? LOWER : EXACT);
        hashstore(value_to_tt(bestvalue, pos->realdepth), depth, bestfrom, bestto, f, pos->HASH_KEY);
        // and order the movelist with insert ( stable ) sort
        for (i = 1; i < n; i++) {
            int32_t rvalue = root_scores[i];
            move2 tmpmove = movelist[i];
            int32_t j = i - 1;
            for (; j >= 0 && root_scores[j] < rvalue; j--) {
                root_scores[j + 1] =root_scores[j];
                movelist[j + 1] = movelist[j];
            }
            root_scores[j + 1] = rvalue;
            movelist[j + 1] = tmpmove;
        }
        return bestvalue;
    }
    
    int32_t Search::compute(int32_t b[46], int32_t color, int32_t time, char output[256]) {
        // compute searches the best move on position b in time time.
        // it uses iterative deepening to drive the PV_Search.
        int32_t depth;
        int32_t i;
        int32_t value;
        int32_t lastvalue;
        // int32_t newvalue;
        int32_t dummy=0, alpha, beta;
        U8 bestfrom = 0;
        U8 bestto = 0;
        U8 bestfrom2 = 0;
        U8 bestto2 = 0;
        int32_t bestindex = 0;
        int32_t n;
        double t, elapsed=0; // time variables
        struct move2 movelist[MAXMOVES];
        int32_t ValueByIteration[MAXDEPTH+1] ;
        bool Problem = false;
        struct move2 lastbest;
        char str[256];
        char pv[256];
        nodes = 0;
        sprintf(output,"KestoG engine 1.5");
        init_piece_lists(b, pos);
        n = Gen_Captures(b, movelist, color, 1, pos);
        if(!n)
            n = Gen_Moves(b, movelist, color, pos);
        if (n == 0)
            return (-MATE);
        
        searches_performed_in_game++; // increase generation
        
#ifdef KALLISTO
        if (n == 1) { // only one move to do=>return this move instantly
            value = 0;
            bestrootmove = movelist[0];
            MoveToStr(bestrootmove, str);
            if (pfSearchInfo)
                pfSearchInfo(value,0, elapsed > 0 ? int(nodes / elapsed / 1000) : 0, str, 0);
            movetonotation(bestrootmove, str);
            sprintf(output, "[only move][depth %i][move %s][time %.2fs][eval %i][nodes %i]",0,str,elapsed,value,0);
            // printf("\n%s",output);
            setbestmove(bestrootmove);
            domove2(b, &bestrootmove, color, pos);
            return (0);
        }
#endif
        
        // History is not cleared,but scaled down between moves
        // scaling down History
        for (int32_t p = 0; p <= 1023; p++) {
            //history_tabular[p] = 0;
            history_tabular[p] = (history_tabular[p]) / 2;
        }
        // Clear the killer moves
        for (i = 0; i <= (MAXDEPTH + 1); i++) {
            killersf1[i] = 0;
            killerst1[i] = 0;
            killersf2[i] = 0;
            killerst2[i] = 0;
        }
        // clear repetition checker
        memset(pos->RepNum, 0, MAXDEPTH*sizeof(U64));
        maxtime = time;
        pos->HASH_KEY = Position_to_Hashnumber(b, color);
        start = now();
        g_Panic = 2;
        g_seldepth = 0;
        pos->realdepth = 0;
        value = rootsearch(b, -INFINITY1, INFINITY1, 2, color, SearchShort);
        alpha = -INFINITY1;
        beta = INFINITY1;
        for (depth = 3; depth < MAXDEPTH; depth += 2) {
            g_Panic = Problem ? 3 : 2; // if Problem then add more time
            lastvalue = value;
            lastbest = bestrootmove;
        repeat_search:
            g_seldepth = 0;
            pos->HASH_KEY = Position_to_Hashnumber(b, color);
            init_piece_lists(b, pos);
            pos->realdepth = 0;
            /* do a search with aspiration window */
            
            value = rootsearch(b, alpha, beta, depth, color, SearchNormal);
            
            elapsed = (now()-start);
            // interrupt by user or time is up
            if (play){
                value = lastvalue;
                bestrootmove = lastbest;
                depth -= 2;
                movetonotation(bestrootmove, str);
                if (nodes < 1048576)
                    sprintf(output,"[done][depth %i][move %s][time %.2fs][eval %i][nodes %i]",depth,str,elapsed,value,nodes);
                else
                    sprintf(output,"[done][depth %i][move %s][time %.2fs][eval %i][nodes %.1fM]",depth,str,elapsed,value,(float)nodes/(1024*1024));
                printf("\n%s",output);
                setbestmove(bestrootmove);
                domove2(b, &bestrootmove, color, pos);
#ifdef KALLISTO
                char value_str[16];
                {
                    value_str[0] = 0;
                    // itoa(value, value_str, 10);
                    sprintf(value_str, "%s%d", value_str, value);
                }
                char depth_str[16];
                {
                    depth_str[0] = 0;
                    // itoa(depth, depth_str, 10);
                    sprintf(depth_str, "%s%d", depth_str, depth);
                }
                char seldepth_str[16];
                seldepth_str[0] = 0;
                {
                    // itoa(depth, depth_str, 10);
                    sprintf(depth_str, "%s%d", depth_str, depth);
                }
                // strcat(depth_str,"/");
                sprintf(depth_str, "%s/", depth_str);
                // itoa(g_seldepth,seldepth_str, 10);
                sprintf(seldepth_str, "%s%d", seldepth_str, g_seldepth);
                // strcat(depth_str,seldepth_str);
                sprintf(depth_str, "%s%s", depth_str, seldepth_str);
                int32_t speed = elapsed > 0 ? int32_t(nodes / elapsed / 1000) : 0;
                char speed_str[16];
                // itoa(speed, speed_str, 10);
                sprintf(speed_str, "%s%d", speed_str, speed);
                // strcat(speed_str," kNps");
                sprintf(speed_str, "%s kNps", speed_str);
                // pv_str
                char pv_str[2][1024];
                {
                    pv_str[0][0] = 0;
                    pv_str[1][0] = 0;
                }
                
                MoveToStr(bestrootmove, *pv_str);
                char current_move[16];
                sprintf(current_move,"N/A");
                /*if (pfSearchInfoEx)
                 pfSearchInfoEx(value_str, depth_str,speed_str, pv_str ,current_move);*/
                return value;
#endif
                
            } // *play
            /* check if aspiration window holds */
            
            if (abs(value) < 10000 && depth >= 21) {
                if (value >= beta) {
                    alpha = -INFINITY1;
                    beta = INFINITY1;
                    goto repeat_search;
                }
                if (value <= alpha) {
                    alpha = -INFINITY1;
                    beta = INFINITY1;
                    goto repeat_search;
                }
                
                alpha = value - RADIUS;
                if (alpha <= -INFINITY1)
                    alpha = -INFINITY1;
                beta = value + RADIUS;
                if (beta >= INFINITY1 )
                    beta = INFINITY1;
            }
            else{
                alpha = -INFINITY1;
                beta = INFINITY1;
            };
            ValueByIteration[depth] = value;
            Problem = ((depth>=11) && (value<=ValueByIteration[depth-2]-30) && (ValueByIteration[depth-2] <= ValueByIteration[depth-4] - 40));
            bestfrom = bestto = 0;
            bestfrom2 = bestto2 = 0;
            bestindex = 127;
            // get best move from hashtable:
            // we always store in the last call to rootsearch, so there MUST be a move here!
            hashretrieve(&dummy, depth, &dummy, alpha, beta, &bestfrom, &bestto, &bestfrom2, &bestto2, &dummy, pos->realdepth, pos->HASH_KEY);
            
            for (i = 0; i < n; i++) {
                if ((FROM(&movelist[i]) == bestfrom) && (TO(&movelist[i] ) == bestto)) {
                    bestindex = i;
                    break;
                }
            }
            // assert(bestindex != 127);
            if(bestindex==127){
                printf("error, bestIndex error\n");
                bestindex = 0;
            }
            // assert(FROM(&bestrootmove) == FROM(&movelist[bestindex]));
            if(FROM(&bestrootmove) != FROM(&movelist[bestindex])){
                printf("error, assert(FROM(&bestrootmove) == FROM(&movelist[bestindex])\n");
            }
            // assert(TO(&bestrootmove) == TO(&movelist[bestindex]));
            if(TO(&bestrootmove) != TO(&movelist[bestindex])){
                printf("error, assert(TO(&bestrootmove) == TO(&movelist[bestindex]))\n");
            }
            movetonotation(movelist[bestindex], str);
            if (nodes < 1048576)
                sprintf(output, "[thinking][depth %i][move %s][time %.2fs][eval %i][nodes %i]", depth, str, elapsed, value, nodes);
            else
                sprintf(output, "[thinking][depth %i][move %s][time %.2fs][eval %i][nodes %.1fM]", depth, str, elapsed, value, (float)nodes/(1024*1024));
            // printf("\n%s",output);
            
            // break conditions:
            // time elapsed
            t = now();
            /* don't bother going deeper if we've already used 75% of our time since we likely won't finish */
            if ((t-start) > (0.75*maxtime))
                break;
            
            // found a win
            if (depth >= 50 && value >= MATE-depth )
                break;
        };  // end for iterative deepening loop
        movetonotation(movelist[bestindex],str);
        retrievepv(b,pv,color);
        if (nodes < 1048576)
            sprintf(output,"[done][depth %i][move %s][time %.2fs][eval %i][nodes %i][pv %s]", depth, str, elapsed, value, nodes, pv);
        else
            sprintf(output,"[done][depth %i][move %s][time %.2fs][eval %i][nodes %.1fM][pv %s]", depth, str, elapsed, value, (float)nodes/(1024*1024), pv);
        // printf("\n%s",output);
        setbestmove(bestrootmove);
        // domove2(b, &bestrootmove, color, pos);
        printf("realDepth: %d, %d\n", pos->realdepth, nodes);
        return value;
    }
    
    int32_t Search::QSearch(int32_t b[46], int32_t alpha, int32_t beta, int32_t color) {
        // quiescent search
        // expands captures and promotions
        
        /* time check */
        if (!(++nodes & 0x1fff))
            if (((now()-start)>maxtime*g_Panic))
                (play) = 1;
        
        /* return if calculation interrupt */
        if (play)
            return (0);
        
        /* stop search if maximal search depth is reached */
        if (pos->realdepth >= MAXDEPTH)
            return evaluation(b, color, alpha, beta, pos, this->pickBestMove);
        uint32_t capture;
        int32_t value;
        
        capture = Test_Capture(b, color, pos);
        
        if (capture == 0) {
            
            if (pos->realdepth > g_seldepth)
                g_seldepth = pos->realdepth; // new selective depth
            
            int32_t best_value = evaluation(b, color, alpha, beta, pos, this->pickBestMove) + 2; // static value + turn
            if (best_value < -HASHMATE)
                return (best_value - 2);
            if (best_value > alpha) {
                alpha = best_value;
                if (best_value >= beta) // selective deviation
                    return best_value;
            }
            
            uint32_t n;
            struct move pmovelist[7];
            n = Gen_Proms(b, pmovelist, color); // generate promotions
            if (n == 0)
                return best_value; // no promotions => return evaluation
            U64 L_HASH_KEY = pos->HASH_KEY;  // local variable  for saving position's HASH_KEY
            uint32_t i;
            // move loop over promotions
            for (i = 0; i < n; i++) {
                doprom(b, &pmovelist[i], color, pos);
                value = -QSearch(b, -beta, -alpha, color^CC);
                undoprom(b, &pmovelist[i], color, pos);
                pos->HASH_KEY = L_HASH_KEY;
                if (value > best_value) {
                    best_value = value;
                    if (value > alpha) {
                        alpha = value;
                        if (value >= beta)
                            return value;
                    }
                }
            } // move loop
            return best_value;
        } else {
            int32_t i,n;
            struct move2 movelist[MAXMOVES];
            n = Gen_Captures(b, movelist, color, capture, pos);
            int32_t SortVals[MAXMOVES];
            // sort captures list
            for (i=0; i<n; i++) {
                if (is_promotion(&movelist[i]) == 1)
                    SortVals[i] = 4000;
                else
                    SortVals[i] = 0;
                for (int32_t j = 2; j < movelist[i].l; j++)
                    SortVals[i] += MVALUE[ (movelist[i].m[j]) >> 6];
            }
            
            int32_t maxvalue = -INFINITY1;    // preset maxvalue
            U64 L_HASH_KEY = pos->HASH_KEY;  // local variable  for saving position's HASH_KEY
            // move loop
            while (pick_next_move( &i,&SortVals[0], n ) != 0) {
                domove(b, &movelist[i], color, pos);
                value = -QSearch(b, -beta, -alpha, color^CC);
                undomove(b, &movelist[i], color, pos);
                pos->HASH_KEY = L_HASH_KEY;
                if (value > maxvalue){
                    maxvalue = value;
                    if (value > alpha){
                        if (value >= beta)
                            break;
                        alpha = value;
                    }
                }
            } // move loop
            return maxvalue;
        }
    }
    
    /* Main search function */
    /* Principal Variation Search,also known as Nega-Scout */
    int32_t Search::PVSearch(int32_t b[46], int32_t depth, int32_t alpha, int32_t beta, int32_t color) {
        /* mate distance pruning */
        alpha = MAX(value_mated_in(pos->realdepth), alpha);
        beta = MIN(value_mate_in(pos->realdepth+1), beta);
        if (alpha >= beta)
            return alpha;
        
        // horizon ?
        if (depth <= 0)
            return QSearch(b, alpha, beta, color);
        /* time check */
        
        if (!(++nodes & 0x1fff))
            if (((now()-start) > maxtime*g_Panic))
                (play) = 1;
        
        /* return if calculation interrupt */
        if (play)
            return (0);
        
        
        /* stop search if maximal search depth is reached */
        if (pos->realdepth >= MAXDEPTH)
            return evaluation(b, color, alpha, beta, pos, this->pickBestMove);
        
        if (pos->realdepth > g_seldepth)
            g_seldepth = pos->realdepth; // new selective depth
        const int32_t oldalpha = alpha;
        /* check for database use */
        
        uint32_t Pieces = pos->g_pieces[BLK_MAN] + pos->g_pieces[BLK_KNG] + pos->g_pieces[WHT_MAN] + pos->g_pieces[WHT_KNG];
        
        if ((!EdNocaptures) && (Pieces <= EdPieces)) {
            int32_t res = EdProbe(b, color);
            if (res != EdAccess::not_found) {
                if (res != EdRoot[color] || !pos->Reversible[pos->realdepth - 1]) {
                    if (res == EdAccess::win)
                        return ED_WIN - 100*Pieces;
                    if (res == EdAccess::lose)
                        return -ED_WIN + 100*Pieces;
                    if (res == EdAccess::draw)
                        return (0);
                    // MessageBox(0, "unknown value from EdAccess", "Error", 0);
                    printf("error, unknown value from EdAccess\n");
                }
            }
        }
        int32_t value;
        
        U64 L_HASH_KEY = pos->RepNum[pos->realdepth] = pos->HASH_KEY;  // local variable  for saving position's HASH_KEY
        // draw by triple repetition ?
        
        if (pos->g_pieces[WHT_KNG] && pos->g_pieces[BLK_KNG] ){
            for (int32_t i = 4; i <= pos->realdepth; i += 2){
                if (pos->RepNum[pos->realdepth - i ] == pos->HASH_KEY )
                    return (0);
            }
        }
        
        U8 bestfrom,bestto;
        U8 bestfrom2,bestto2;
        bestfrom =  bestto = 0; // best move's from-to squares
        bestfrom2 = bestto2 = 0;
        int32_t tr_depth = 1024;
        int32_t tr_depth2;
        
        // hashlookup
        
        TEntry *entry;
        // register uint32_t j;
        uint32_t j;
        U32 lock;
        int32_t move_depth = 0;
        //entry = ttable + (U32)(HASH_KEY & MASK);
        entry = ttable + (pos->HASH_KEY & MASK);
        lock = (pos->HASH_KEY >> 32); // use the high 32 bits as lock
        
        for (j = 0; j < REHASH; j++,entry++) {
            if ((entry->m_lock) == lock) {
                tr_depth2 = (entry->m_depth); // depth stored in TT
                if (tr_depth2 > move_depth) {
                    move_depth = tr_depth;
                    bestfrom = (entry->m_best_from);
                    bestto = (entry->m_best_to);
                    bestfrom2 = (entry->m_best_from2);
                    bestto2 = (entry->m_best_to2);
                    tr_depth = (entry->m_depth);
                }
            }
        } // for
        
        int32_t i;
        struct move2 movelist[MAXMOVES];
        // check if the side to move has a capture
        int32_t capture;
        capture = Test_Capture(b, color, pos);   // is there a capture for the side to move ?
        
        if (capture == 0) {
            /* check for compressed ( without captures ) database use */
            if (EdNocaptures && (Pieces <= EdPieces)) {
                int32_t res = EdProbe(b, color);
                if (res != EdAccess::not_found) {
                    if (res != EdRoot[color] || !pos->Reversible[pos->realdepth - 1]) {
                        if (res == EdAccess::win)
                            return ED_WIN - 100*Pieces;
                        if (res == EdAccess::lose)
                            return -ED_WIN + 100*Pieces;
                        if (res == EdAccess::draw)
                            return (0);
                        // MessageBox(0, "unknown value from EdAccess", "Error", 0);
                        printf("error, unknown value from EdAccess\n");
                    }
                }
            }
        }
        
        int32_t n;
        if (capture) {
            n = Gen_Captures(b, movelist, color, capture, pos);
        } else {
            n = Gen_Moves(b, movelist, color, pos);
            // if we have no moves and no captures :
            if (n == 0) {
                return (pos->realdepth - MATE); // minus sign will be negated in negamax framework
            };
        }
        
        /* enhanced transposition cutoffs: do every move and check if the resulting
         position is in the hashtable. if yes, check if the value there leads to a cutoff
         if yes, we don't have to search */
        
        if (tr_depth < depth && depth >= ETCDEPTH && beta > -1500) {
            U8 dummy;
            int32_t dummy2;
            dummy = dummy2 = 0;
            int32_t ETCvalue;
            for (i = 0; i < n; i++) {
                // do move
                // domove(b,&movelist[i] );
                update_hash(&movelist[i], pos->HASH_KEY); // instead domove
                // do the ETC lookup:with reduced depth and changed color
                ETCvalue = -INFINITY1;
                if (hashretrieve(&dummy2, depth-1, &ETCvalue, -beta, -alpha, &dummy, &dummy, &dummy, &dummy, &dummy2, pos->realdepth, pos->HASH_KEY)) {
                    // if one of the values we find is > beta we quit!
                    if ((-ETCvalue) >= beta) {
                        // before we quit: restore all stuff
                        // undomove(b,&movelist[i] );
                        pos->HASH_KEY = L_HASH_KEY;
                        hashstore(value_to_tt(-ETCvalue, pos->realdepth), depth, FROM(&movelist[i]), TO(&movelist[i]), LOWER, pos->HASH_KEY);
                        return (-ETCvalue);
                    }
                } // if hashretrieve
                // undomove(b,&movelist[i] );
                pos->HASH_KEY = L_HASH_KEY;
            } // for
        } // ETC
        int32_t SortVals[MAXMOVES];
        // sort move list
        // fill SortVals array with move's values
        
        int32_t hindex;
        if (capture == 0 ){
            for (i = 0; i < n; i++) { // loop over moves
                if (FROM( &movelist[i]) == bestfrom) {
                    if (TO( &movelist[i]) == bestto) {
                        SortVals[i] = 1000000;
                        continue;
                    }
                }
                if (FROM( &movelist[i]) == bestfrom2) {
                    if (TO(&movelist[i]) == bestto2) {
                        SortVals[i] = 1000000 - 2;
                        continue;
                    }
                }
                
                if (is_promotion(&movelist[i]) == 1) {
                    SortVals[i] = 600000;
                    continue;
                }
                if (FROM(&movelist[i]) == killersf1[pos->realdepth]) {
                    if (TO( &movelist[i]) == killerst1[pos->realdepth]) {
                        SortVals[i] = 600000 - 2;
                        continue;
                    }
                }
                
                if (FROM( &movelist[i]) == killersf2[pos->realdepth]) {
                    if (TO( &movelist[i]) == killerst2[pos->realdepth]) {
                        SortVals[i] = 600000 - 4;
                        continue;
                    }
                }
                
                hindex = (SQUARE_TO_32(FROM( &movelist[i]) ) << 5) + SQUARE_TO_32(TO(&movelist[i]));
                SortVals[i] = history_tabular[hindex];
                
            } // loop over moves
            
        } else {
            for (i = 0; i < n; i++) { // loop over captures
                if (FROM(&movelist[i]) == bestfrom)
                    if (TO(&movelist[i]) == bestto) {
                        SortVals[i] = 1000000;
                        continue;
                    }
                if (is_promotion(&movelist[i] ) == 1)
                    SortVals[i] = 4000;
                else
                    SortVals[i] = 0;
                
                for (int32_t j = 2; j < movelist[i].l; j++)
                    SortVals[i] += MVALUE[(movelist[i].m[j]) >> 6];
            } // loop over captures
        }
        // IID
        
        int32_t best_value = -INFINITY1;
        int32_t bestindex = 0;
        int32_t do_singular = 1; //
        if (n == 1 && pos->realdepth*2 < depth) {
            bestfrom = FROM(&movelist[0]);
            bestto = TO(&movelist[0]);
            goto NOIID;
        }
        if (depth >= 4) {
            if (((bestfrom == 0) && (bestto == 0)) || (depth >= 6 && tr_depth < depth - 3 - 1 )) {
                int32_t tempalpha = alpha - 20*depth;
                tempalpha = MAX(-MATE,tempalpha);
                int32_t tempbeta = beta + 20*depth;
                tempbeta = MIN(MATE,tempbeta);
                int32_t new_depth;
                new_depth = depth - 3;
                bool ir = inSearch;
                inSearch = true;
                QuickSort( SortVals,movelist, 0,(n-1));
                for( i = 0; i < n; i++){
                    domove(b, &movelist[i], color, pos);
                    value = -PVSearch(b, new_depth, -tempbeta, -tempalpha, color^CC);
                    undomove(b, &movelist[i], color, pos);
                    // restore HASH_KEY
                    pos->HASH_KEY = L_HASH_KEY;
                    if (play)
                        return (0);
                    if ( value > best_value ){
                        best_value = value;
                        bestindex = i;
                        if ( value > tempalpha ){
                            tempalpha = value;
                            if ( value >= tempbeta )
                                break;
                        }
                    }
                } // for
                inSearch = ir;
                
                if ( best_value < alpha && best_value <= -HASHMATE ) return best_value;
                if ( best_value >= beta && best_value >= HASHMATE ) return best_value;
                
                bestfrom = FROM( &movelist[bestindex] );
                bestto = TO( &movelist[bestindex] );
                SortVals[bestindex] = 1000000;
                if (pos->realdepth*2 >= depth && best_value < alpha - 175){
                    do_singular = 0; // best move is too bad to be singular
                }
            }
            
        }
    NOIID:
        int32_t singular = 0;
        if (do_singular == 1 && bestfrom != 0 && bestto != 0) {
            if (n == 1)
                singular = 1;
            if (n == 2)
                singular = 1;
        }
        // erase deeper killer moves
        
        memset(&killersf1[pos->realdepth+2], 0, sizeof(int));
        memset(&killerst1[pos->realdepth+2], 0, sizeof(int));
        memset(&killersf2[pos->realdepth+2], 0, sizeof(int));
        memset(&killerst2[pos->realdepth+2], 0, sizeof(int));
        
        int32_t played_nb = 0;
        int32_t played[MAXMOVES];
        best_value = -INFINITY1; // preset maxvalue
        int32_t newdepth;
        // int32_t ext;
        int32_t prom; // promotion or not
        int32_t bef_cap = 0; //
        int32_t aft_cap; //
        int32_t extension;
        int32_t bestmovei = 0;
        
        // Ok,let's look now at all moves and pick one with the biggest value
        while (pick_next_move( &i,&SortVals[0], n) != 0) {
            prom = is_promotion(&movelist[i]);
            if ((FROM( &movelist[i]) != bestfrom || TO(&movelist[i]) != bestto))
                singular = 0;
            extension = 0;
            if (capture || prom)
                bef_cap = (pos->g_pieces[BLK_MAN] - pos->g_pieces[WHT_MAN])*100 + (pos->g_pieces[BLK_KNG] - pos->g_pieces[WHT_KNG])*300;
            // domove
            domove(b, &movelist[i], color, pos);
            
            if (capture || prom) { // try to extend
                aft_cap = (pos->g_pieces[BLK_MAN] - pos->g_pieces[WHT_MAN])*100 + (pos->g_pieces[BLK_KNG] - pos->g_pieces[WHT_KNG])*300;
                if ((bef_cap < 0 && aft_cap > 0) || (bef_cap > 0 && aft_cap < 0) || (aft_cap == pos->g_root_mb)) {
                    int32_t& realdepth = pos->realdepth;
                    if (DO_EXTENSIONS)
                        extension = 1;
                }
            }
            newdepth = depth - 1 + MAX(extension,singular);
            if (newdepth > 0 && (FROM(&movelist[i]) != bestfrom || TO(&movelist[i]) != bestto)) {
                if (newdepth <= 3)
                    value = -LowDepth(b, newdepth, -alpha , color^CC);
                else
                    value = -search(b, newdepth, -alpha, color^CC, NodeCut, (played_nb >= 5) ? true : false );
                if (value >alpha) {
                    value = -PVSearch(b, newdepth, -beta, -alpha, color^CC);
                }
            } else
                value = -PVSearch(b, newdepth, -beta, -alpha, color^CC);
            undomove(b, &movelist[i], color, pos);
            played[played_nb] = i;
            played_nb++;
            // restore HASH_KEY
            pos->HASH_KEY = L_HASH_KEY;
            if (play)
                return (0);
            // update best value so far
            // and set alpha and beta bounds
            if (value > best_value) {
                best_value = value;
                if (value > alpha) {
                    bestmovei = i;
                    alpha = value;
                    hashstore(value_to_tt(best_value, pos->realdepth), depth, FROM(&movelist[i] ) , TO(&movelist[i]) , LOWER, pos->HASH_KEY);
                    if (value >= beta){
                        if (capture == 0 && is_promotion(&movelist[i]) == 0) {
                            killer(FROM(&movelist[i]) , TO(&movelist[i]) , pos->realdepth, capture);
                            hist_succ(FROM(&movelist[i]), TO(&movelist[i]) , depth, capture);
                            for (i = 0; i < played_nb - 1; i++){
                                int32_t j = played[i];
                                if (is_promotion(&movelist[j]) == 0)
                                    history_bad(((movelist[j].m[0]) & 0x3f), ((movelist[j].m[1]) & 0x3f),  depth);
                            }
                            
                        }
                        return (value);
                    }
                }
            }
        }; // end main recursive loop of forallmoves
        if (alpha != oldalpha) {
            bestfrom = (movelist[bestmovei].m[0]) & 0x3f;
            bestto = (movelist[bestmovei].m[1]) & 0x3f;
            if (capture == 0 && is_promotion(&movelist[bestmovei]) == 0) {
                killer(bestfrom, bestto, pos->realdepth, capture);
                hist_succ(bestfrom, bestto, depth, capture);
            }
            hashstore(value_to_tt(best_value, pos->realdepth), depth, bestfrom, bestto, EXACT, pos->HASH_KEY);
            return best_value;
        }
        hashstore(value_to_tt(best_value, pos->realdepth), depth, 0, 0, UPPER, pos->HASH_KEY);
        return best_value;
    }
    
    // Search is the search function for zero-width nodes
    int32_t Search::search(int32_t b[46], int32_t depth, int32_t beta , int32_t color, int32_t node_type, bool mcp ){
        // mate distance pruning
        
        if (value_mated_in(pos->realdepth) >= beta)
            return beta;
        
        if (value_mate_in(pos->realdepth + 1) < beta)
            return beta - 1;
        
        /* time check */
        
        if (!( ++nodes & 0x1fff))
            if (((now()-start) > maxtime*g_Panic))
                (play) = 1;
        
        /* return if calculation interrupt */
        if (play)
            return (0);
        
        /* stop search if maximal search depth is reached */
        if (pos->realdepth >= MAXDEPTH)
            return evaluation(b, color, beta-1, beta, pos, this->pickBestMove);
        
        if (pos->realdepth > g_seldepth)
            g_seldepth = pos->realdepth; // new selective depth
        
        /* check for database use */
        
        uint32_t Pieces = pos->g_pieces[BLK_MAN] + pos->g_pieces[BLK_KNG] + pos->g_pieces[WHT_MAN] + pos->g_pieces[WHT_KNG];
        
        if ((!EdNocaptures) && (Pieces <= EdPieces)) {
            int32_t res = EdProbe(b, color);
            if (res != EdAccess::not_found) {
                if (res != EdRoot[color] || !pos->Reversible[pos->realdepth - 1]) {
                    if (res == EdAccess::win)
                        return ED_WIN - 100*Pieces;
                    if (res == EdAccess::lose)
                        return -ED_WIN + 100*Pieces;
                    if (res == EdAccess::draw)
                        return (0);
                    // MessageBox(0, "unknown value from EdAccess", "Error", 0);
                    printf("error, unknown value from EdAccess\n");
                }
            }
        }
        U64 L_HASH_KEY = pos->RepNum[pos->realdepth] = pos->HASH_KEY;  // local variable  for saving position's HASH_KEY
        
        // draw by triple repetition ?
        if (pos->g_pieces[WHT_KNG] && pos->g_pieces[BLK_KNG]) {
            for (int32_t i = 4; i <= pos->realdepth; i += 2) {
                if (pos->RepNum[pos->realdepth - i ] == pos->HASH_KEY)
                    return (0);
            }
        }
        
        int32_t value;
        
        
        U8 bestfrom,bestto;
        U8 bestfrom2,bestto2;
        bestfrom =  bestto = 0; // best move's from-to squares
        bestfrom2 = bestto2 = 0;
        int32_t try_mcp = 1;   // try forward pruning,initially enabled
        int32_t tr_depth = 1024;
        // hashlookup
        if (hashretrieve(&tr_depth,depth,&value,beta-1,beta,&bestfrom,&bestto,&bestfrom2,&bestto2, &try_mcp, pos->realdepth, pos->HASH_KEY))
            return value;
        int32_t i;
        struct move2 movelist[MAXMOVES];
        // check if the side to move has a capture
        int32_t capture;
        capture = Test_Capture(b, color, pos);   // is there a capture for the side to move ?
        
        if (capture == 0) {
            /* check for compressed ( without captures ) database use */
            if (EdNocaptures && (Pieces <= EdPieces)) {
                int32_t res = EdProbe(b, color);
                if (res != EdAccess::not_found) {
                    if (res != EdRoot[color] || !pos->Reversible[pos->realdepth - 1]) {
                        if (res == EdAccess::win)
                            return ED_WIN - 100*Pieces;
                        if (res == EdAccess::lose)
                            return -ED_WIN + 100*Pieces;
                        if (res == EdAccess::draw)
                            return (0);
                        // MessageBox(0, "unknown value from EdAccess", "Error", 0);
                        printf("error, unknown value from EdAccess\n");
                    }
                }
            }
        }
        
        int32_t n;
        if (capture) {
            n = Gen_Captures(b, movelist, color, capture, pos);
        } else {
            n = Gen_Moves(b, movelist, color, pos);
            // if we have no moves and no captures :
            if (n == 0) {
                return (pos->realdepth - MATE); // minus sign will be negated in negamax framework
            };
        }
        /* enhanced transposition cutoffs: do every move and check if the resulting
         position is in the hashtable. if yes, check if the value there leads to a cutoff
         if yes, we don't have to search */
        
        if (tr_depth < depth && depth >= ETCDEPTH && beta > -1500) {
            U8 dummy;
            int32_t dummy2;
            dummy = dummy2 = 0;
            int32_t ETCvalue;
            for (i = 0; i < n; i++) {
                // do move
                // domove(b,&movelist[i] );
                update_hash(&movelist[i], pos->HASH_KEY); // instead domove
                // do the ETC lookup:with reduced depth and changed color
                ETCvalue = -INFINITY1;
                if (hashretrieve(&dummy2, depth-1, &ETCvalue, -beta, -beta+1 , &dummy, &dummy, &dummy, &dummy, &dummy2, pos->realdepth, pos->HASH_KEY)) {
                    // if one of the values we find is > beta we quit!
                    if ((-ETCvalue) >= beta) {
                        // before we quit: restore all stuff
                        // undomove(b,&movelist[i] );
                        pos->HASH_KEY = L_HASH_KEY;
                        hashstore(value_to_tt(-ETCvalue, pos->realdepth), depth, FROM(&movelist[i]), TO( &movelist[i]), LOWER, pos->HASH_KEY);
                        return (-ETCvalue);
                    }
                } // if hashretrieve
                // undomove(b,&movelist[i] );
                pos->HASH_KEY = L_HASH_KEY;
            } // for
        } // ETC
        int32_t SortVals[MAXMOVES];
        // sort move list
        // fill SortVals array with move's values
        
        int32_t hindex;
        if (capture == 0) {
            for (i = 0; i < n; i++) { // loop over moves
                if (FROM(&movelist[i]) == bestfrom) {
                    if (TO(&movelist[i]) == bestto) {
                        SortVals[i] = 1000000;
                        continue;
                    }
                }
                if (FROM(&movelist[i]) == bestfrom2) {
                    if (TO(&movelist[i]) == bestto2) {
                        SortVals[i] = 1000000 - 2;
                        continue;
                    }
                }
                
                if (is_promotion(&movelist[i]) == 1) {
                    SortVals[i] = 600000;
                    continue;
                }
                if (FROM(&movelist[i]) == killersf1[pos->realdepth]) {
                    if (TO(&movelist[i]) == killerst1[pos->realdepth]) {
                        SortVals[i] = 600000 - 2;
                        continue;
                    }
                }
                
                if (FROM(&movelist[i]) == killersf2[pos->realdepth]) {
                    if (TO(&movelist[i]) == killerst2[pos->realdepth]) {
                        SortVals[i] = 600000 - 4;
                        continue;
                    }
                }
                
                hindex = (SQUARE_TO_32(FROM(&movelist[i])) << 5) + SQUARE_TO_32(TO(&movelist[i]));
                SortVals[i] = history_tabular[hindex];
                
            } // loop over moves
            
        } else {
            for (i = 0; i < n; i++) { // loop over captures
                if (FROM(&movelist[i]) == bestfrom)
                    if (TO(&movelist[i]) == bestto) {
                        SortVals[i] = 1000000;
                        continue;
                    }
                if (is_promotion(&movelist[i] ) == 1)
                    SortVals[i] = 4000;
                else
                    SortVals[i] = 0;
                
                for (int32_t j = 2; j < movelist[i].l; j++)
                    SortVals[i] += MVALUE[ (movelist[i].m[j]) >> 6];
            } // loop over captures
        }
        
        // IID
        
        int32_t maxvalue;
        int32_t bestindex = 0;
        int32_t do_singular = 1; //
        if (n == 1 && pos->realdepth*2 < depth) {
            bestfrom = FROM(&movelist[0]);
            bestto = TO(&movelist[0]);
            goto NOIID2;
        }
        if (depth >= 5) {
            if (((bestfrom == 0) && (bestto == 0) ) || (depth >= 6 && tr_depth < depth - 4 - 1)) {
                maxvalue = -INFINITY1;
                bool ir = inSearch;
                inSearch = true;
                int32_t new_depth = depth - 4;
                QuickSort( SortVals,movelist, 0,(n-1));
                for(i = 0; i < n; i++) {
                    domove(b, &movelist[i], color, pos);
                    if (new_depth <= 3)
                        value = -LowDepth(b,new_depth, 1 - beta , color^CC);
                    else
                        value = -search(b,new_depth, 1 - beta, color^CC,NODE_OPP(node_type), false);
                    undomove(b, &movelist[i], color, pos);
                    // restore HASH_KEY
                    pos->HASH_KEY = L_HASH_KEY;
                    if (play)
                        return (0);
                    if (value > maxvalue) {
                        maxvalue = value;
                        bestindex = i;
                        if (value >= beta)
                            break;
                    }
                } // for
                inSearch = ir;
                if (maxvalue < beta && maxvalue <= -HASHMATE)
                    return maxvalue;
                if (maxvalue >= beta && maxvalue >= HASHMATE)
                    return maxvalue;
                
                bestfrom = FROM(&movelist[bestindex]);
                bestto = TO(&movelist[bestindex]);
                SortVals[bestindex] = 1000000;
                if (pos->realdepth*2 >= depth && maxvalue < beta - 1 - 175) {
                    do_singular = 0; // best move is too bad to be singular
                }
            }
        }
    NOIID2:
        int32_t singular = 0;
        if (do_singular == 1 &&  bestfrom != 0 && bestto != 0) {
            if (n == 1)
                singular = 1;
            if (n == 2)
                singular = 1;
        }
        // ----------------------------------------------------------------------------------------------------
        // forward pruning
        // do not works in endgames
        // applied only at expected Cut nodes
        // -----------------------------------------------------------------------------------------------------
        
        int32_t quick_eval;
        if (beta > -1500 && beta < 1500 && mcp && (pos->realdepth > 4) && (node_type == NodeCut) && (n > 1 ) && EARLY_GAME && try_mcp) {
            if (!inSearch && (has_man_on_7th(b,color^CC) == 0)) {
                quick_eval = fast_eval(b, color, pos);
                if (quick_eval +2 >= beta) {
                    int32_t newdepth;
                    int32_t R = 3;
                    newdepth = depth - R;
                    if (quick_eval - beta > 128)
                        newdepth--;
                    int32_t played = 0;
                    int32_t max_moves;
                    max_moves = (pos->g_pieces[(color|KING)] != 0) ? MAXMOVES : 6;
                    U8 best_from,best_to;
                    
                    // loop
                    for (i = 0 ; i < n; i++) {
                        Sort(i, n, SortVals, movelist);
                        // do move
                        domove(b, &movelist[i], color, pos);
                        if (newdepth <= 0)
                            value = -QSearch(b, -beta - MCP_MARGIN , -beta - MCP_MARGIN + 1, color^CC);
                        else {
                            if (newdepth <= 3)
                                value =  -LowDepth(b, newdepth, -beta - MCP_MARGIN + 1, color^CC);
                            else
                                value = -search(b,newdepth, -beta - MCP_MARGIN + 1 ,color^CC, played == 0 ? NodeAll : NodeCut, false);
                        }
                        //  undo move
                        undomove(b, &movelist[i], color, pos);
                        // restore HASH_KEY
                        pos->HASH_KEY = L_HASH_KEY;
                        if (play)
                            return (0);
                        played++;
                        if (value >= beta + MCP_MARGIN) {
                            best_from = FROM(&movelist[i]);
                            best_to = TO(&movelist[i]);
                            if (capture == 0 && is_promotion(&movelist[i]) == 0) {
                                hist_succ(best_from, best_to, depth, capture);
                                killer(best_from, best_to, pos->realdepth, capture);
                            }
                            return (value);
                        }
                        if (played >= max_moves)
                            break;
                    } // for
                }
            } // if
        } // if
        
        // erase deeper killer moves
        
        memset(&killersf1[pos->realdepth+2], 0, sizeof(int));
        memset(&killerst1[pos->realdepth+2], 0, sizeof(int));
        memset(&killersf2[pos->realdepth+2], 0, sizeof(int));
        memset(&killerst2[pos->realdepth+2], 0, sizeof(int));
        
        int32_t played_nb = 0;
        int32_t played[MAXMOVES];
        // maxvalue = -32767; // preset maxvalue
        int32_t newdepth;
        // int32_t ext;
        int32_t prom; // promotion or not
        int32_t bef_cap = 0; //
        int32_t aft_cap; //
        int32_t extension;
        int32_t best_value;
        best_value = -INFINITY1;
        U8 from,to;
        bool do_lmr_1,do_lmr_2;
        // Ok,let's look now at all moves and pick one with the biggest value
        while (pick_next_move( &i,&SortVals[0], n) != 0) {
            
            if ((FROM(&movelist[i]) != bestfrom || TO(&movelist[i]) != bestto))
                singular = 0;
            
            prom = is_promotion(&movelist[i]);
            
            extension = 0;
            
            if (capture || prom)
                bef_cap =  (pos->g_pieces[BLK_MAN] - pos->g_pieces[WHT_MAN])*100 + (pos->g_pieces[BLK_KNG] - pos->g_pieces[WHT_KNG])*300;
            // domove
            domove(b, &movelist[i], color, pos);
            if (capture || prom) { // try to extend
                aft_cap =  (pos->g_pieces[BLK_MAN] - pos->g_pieces[WHT_MAN])*100 + (pos->g_pieces[BLK_KNG] - pos->g_pieces[WHT_KNG])*300;
                if ((bef_cap < 0 && aft_cap > 0) || (bef_cap > 0 && aft_cap < 0) || (aft_cap == pos->g_root_mb)) {
                    int32_t& realdepth = pos->realdepth;
                    if (DO_EXTENSIONS)
                        if (FROM( &movelist[i]) == bestfrom && TO(&movelist[i]) == bestto)
                            extension = 1;
                }
            }
            extension = MAX(extension , singular);
            
            if (played_nb > 1 && capture == 0 && prom == 0 && extension == 0  && !move_to_a1h8(&movelist[i] ) && !is_move_to_7(b, &movelist[i])) {
                from = FROM(&movelist[i]);
                to = TO(&movelist[i]);
                do_lmr_1 = (from != killersf1[pos->realdepth] || to != killerst1[pos->realdepth] ) ? true : false;
                do_lmr_2 = (from != killersf2[pos->realdepth] || to != killerst2[pos->realdepth] ) ? true : false;
                if (do_lmr_1 && do_lmr_2) {
                    newdepth = depth - 3;
                    if (newdepth <= 0)
                        value = -QSearch(b, -beta  , 1 - beta, color^CC);
                    else {
                        if (newdepth <= 3)
                            value = -LowDepth(b, newdepth , 1 - beta, color^CC);
                        else
                            value = -search(b, newdepth, 1 - beta , color^CC, NODE_OPP(node_type), false);
                    }
                    if (value < beta)
                        goto DONE;
                }
            }
            newdepth = depth - 1 + extension;
            if (newdepth <= 3)
                value = -LowDepth(b, newdepth, 1 - beta, color^CC);
            else
                value = -search(b, newdepth, 1 - beta, color^CC, NODE_OPP(node_type), (played_nb >= 5) ? true : false );
        DONE:
            undomove(b, &movelist[i], color, pos);
            played[played_nb] = i;
            played_nb++;
            // restore HASH_KEY
            pos->HASH_KEY = L_HASH_KEY;
            if (play)
                return (0);
            // update best value so far
            // and set alpha and beta bounds
            if (value >= beta) {
                bestfrom = (movelist[i].m[0]) & 0x3f;
                bestto = (movelist[i].m[1]) & 0x3f;
                if (capture == 0 && is_promotion(&movelist[i]) == 0) {
                    killer(bestfrom, bestto, pos->realdepth, capture); // update killers
                    hist_succ(bestfrom, bestto, depth, capture); // update history
                    for (i = 0; i < played_nb - 1; i++) {
                        int32_t j = played[i];
                        if (is_promotion(&movelist[j]) == 0)
                            history_bad(((movelist[j].m[0]) & 0x3f), ((movelist[j].m[1]) & 0x3f),depth);
                    }
                }
                hashstore(value_to_tt(value, pos->realdepth), depth, bestfrom, bestto, LOWER, pos->HASH_KEY);
                return value;
            }
            if (value > best_value)
                best_value = value;
            // if we were supposed to fail high but did not ...
            if (node_type == NodeCut)
                node_type = NodeAll;
        }; // end main recursive loop of forallmoves
        
        hashstore(value_to_tt(best_value, pos->realdepth), depth, 0, 0, UPPER, pos->HASH_KEY);
        return best_value;
    }
    
    int32_t Search::LowDepth(int32_t b[46], int32_t depth, int32_t beta, int32_t color) {
        // mate distance pruning
        
        if (value_mated_in(pos->realdepth) >= beta)
            return beta;
        
        if (value_mate_in(pos->realdepth + 1) < beta)
            return beta - 1;
        /* time check */
        
        if (!(++nodes & 0x1fff))
            if (((now()-start) > maxtime*g_Panic))
                (play) = 1;
        
        /* return if calculation interrupt */
        if (play)
            return (0);
        
        
        /* stop search if maximal search depth is reached */
        if (pos->realdepth >= MAXDEPTH)
            return evaluation(b, color, beta-1, beta, pos, this->pickBestMove);
        
        if (pos->realdepth > g_seldepth)
            g_seldepth = pos->realdepth; // new selective depth
        
        /* check for database use */
        
        uint32_t Pieces = pos->g_pieces[BLK_MAN] + pos->g_pieces[BLK_KNG] + pos->g_pieces[WHT_MAN] + pos->g_pieces[WHT_KNG];
        
        if ((!EdNocaptures) && (Pieces <= EdPieces)) {
            int32_t res = EdProbe(b,color);
            if (res != EdAccess::not_found) {
                if (res != EdRoot[color] || !pos->Reversible[pos->realdepth - 1] ) {
                    if (res == EdAccess::win)
                        return ED_WIN - 100*Pieces;
                    if (res == EdAccess::lose)
                        return -ED_WIN + 100*Pieces;
                    if (res == EdAccess::draw)
                        return (0);
                    // MessageBox(0, "unknown value from EdAccess", "Error", 0);
                    printf("error, unknown value from EdAccess\n");
                }
            }
        }
        
        U64 L_HASH_KEY = pos->RepNum[pos->realdepth] = pos->HASH_KEY;  // local variable  for saving position's HASH_KEY
        
        // draw by triple repetition ?
        if (pos->g_pieces[WHT_KNG] && pos->g_pieces[BLK_KNG] ) {
            for (int32_t i = 4; i <= pos->realdepth; i += 2) {
                if (pos->RepNum[pos->realdepth - i ] == pos->HASH_KEY)
                    return (0);
            }
        }
        
        int32_t value;
        
        U8 bestfrom,bestto;
        U8 bestfrom2,bestto2;
        bestfrom =  bestto = 0; // best move's from-to squares
        bestfrom2 =  bestto2 = 0;
        int32_t tr_depth = -1024;
        int32_t try_mcp = 1;
        // hashlookup
        if (hashretrieve(&tr_depth, depth, &value, beta - 1, beta, &bestfrom, &bestto, &bestfrom2, &bestto2, &try_mcp, pos->realdepth, pos->HASH_KEY))
            return value;
        
        // razoring
        int32_t* g_pieces = pos->g_pieces;
        if (bestfrom == 0 && bestto == 0 && pos->realdepth > 8 && NOT_ENDGAME && !inSearch && abs(beta) < 1500  ) {
            int32_t MARGIN[4] = { 2048, 116 , 150, 270 };
            if (fast_eval(b, color, pos) < beta - MARGIN[depth]) {
                nodes--;
                value = QSearch(b, beta - 1 - MARGIN[depth], beta - MARGIN[depth], color);
                if (play )
                    return (0);
                if (value < beta - MARGIN[depth]) {
                    hashstore(value, depth, 0 , 0, UPPER, pos->HASH_KEY);
                    return value;
                }
            }
        };
        
        int32_t i;
        struct move2 movelist[MAXMOVES];
        // check if the side to move has a capture
        int32_t capture;
        capture = Test_Capture(b, color, pos);   // is there a capture for the side to move ?
        if (capture == 0) {
            /* check for compressed ( without captures ) database use */
            if (EdNocaptures && (Pieces <= EdPieces)) {
                int32_t res = EdProbe(b,color);
                if (res != EdAccess::not_found) {
                    if (res != EdRoot[color] || !pos->Reversible[pos->realdepth - 1]) {
                        if (res == EdAccess::win)
                            return ED_WIN - 100*Pieces;
                        if (res == EdAccess::lose)
                            return -ED_WIN + 100*Pieces;
                        if (res == EdAccess::draw)
                            return (0);
                        // MessageBox(0, "unknown value from EdAccess", "Error", 0);
                        printf("error, unknown value from EdAccess\n");
                    }
                }
            }
        }
        int32_t n;
        if (capture) {
            n = Gen_Captures(b, movelist, color, capture, pos);
        } else {
            n = Gen_Moves(b, movelist, color, pos);
            // if we have no moves and no captures :
            if (n == 0) {
                return (pos->realdepth - MATE); // minus sign will be negated in negamax framework
            };
        }
        int32_t SortVals[MAXMOVES];
        // sort move list
        // fill SortVals array with move's values
        
        int32_t hindex;
        if (capture == 0) {
            for (i = 0; i < n; i++) { // loop over moves
                if (FROM( &movelist[i]) == bestfrom) {
                    if (TO( &movelist[i]) == bestto) {
                        SortVals[i] = 1000000;
                        continue;
                    }
                }
                if (FROM(&movelist[i]) == bestfrom2) {
                    if (TO(&movelist[i]) == bestto2) {
                        SortVals[i] = 1000000 - 2;
                        continue;
                    }
                }
                if (is_promotion(&movelist[i]) == 1) {
                    SortVals[i] = 600000;
                    continue;
                }
                if (FROM(&movelist[i]) == killersf1[pos->realdepth]) {
                    if (TO( &movelist[i]) == killerst1[pos->realdepth]) {
                        SortVals[i] = 600000 - 2;
                        continue;
                    }
                }
                
                if (FROM(&movelist[i]) == killersf2[pos->realdepth]) {
                    if (TO(&movelist[i]) == killerst2[pos->realdepth]) {
                        SortVals[i] = 600000 - 4;
                        continue;
                    }
                }
                
                hindex = (SQUARE_TO_32(FROM( &movelist[i])) << 5) + SQUARE_TO_32(TO(&movelist[i]));
                SortVals[i] = history_tabular[hindex];
                
            } // loop over moves
            
        } else {
            for (i = 0; i < n; i++) { // loop over captures
                if (FROM( &movelist[i]) == bestfrom)
                    if (TO( &movelist[i]) == bestto) {
                        SortVals[i] = 1000000;
                        continue;
                    }
                if (is_promotion(&movelist[i]) == 1)
                    SortVals[i] = 4000;
                else
                    SortVals[i] = 0;
                
                for (int32_t j = 2; j < movelist[i].l; j++)
                    SortVals[i] += MVALUE[ (movelist[i].m[j]) >> 6];
            } // loop over captures
        }
        
        // erase deeper killer moves
        
        memset(&killersf1[pos->realdepth+2], 0, sizeof(int32_t));
        memset(&killerst1[pos->realdepth+2], 0, sizeof(int32_t));
        memset(&killersf2[pos->realdepth+2], 0, sizeof(int32_t));
        memset(&killerst2[pos->realdepth+2], 0, sizeof(int32_t));
        
        int32_t played_nb = 0;
        int32_t played[MAXMOVES];
        int32_t best_value;
        best_value = -INFINITY1;
        int32_t new_depth;
        // Ok,let's look now at all moves and pick one with the biggest value
        while (pick_next_move(&i, &SortVals[0], n) != 0) {
            new_depth = depth - 1;
            // domove
            domove(b, &movelist[i], color, pos);
            
            if (new_depth <= 0)
                value = -QSearch(b, -beta, 1 - beta, color^CC);
            else
                value = -LowDepth(b, new_depth, 1 - beta , color^CC);
            undomove(b, &movelist[i], color, pos);
            played[played_nb] = i;
            played_nb++;
            // restore HASH_KEY
            pos->HASH_KEY = L_HASH_KEY;
            if (play)
                return (0);
            // update best value so far
            // and set alpha and beta bounds
            if (value >= beta) {
                bestfrom = (movelist[i].m[0]) & 0x3f;
                bestto = (movelist[i].m[1]) & 0x3f;
                if (capture == 0 && is_promotion(&movelist[i] ) == 0) {
                    killer(bestfrom, bestto, pos->realdepth, capture); // update killers
                    hist_succ(bestfrom, bestto, depth, capture); // update history
                    for (i = 0; i < played_nb - 1; i++) {
                        int32_t j = played[i];
                        if (is_promotion(&movelist[j]) == 0)
                            history_bad(((movelist[j].m[0]) & 0x3f), ((movelist[j].m[1]) & 0x3f), depth);
                    }
                }
                hashstore(value_to_tt(value, pos->realdepth), depth, bestfrom, bestto, LOWER, pos->HASH_KEY);
                return value;
            }
            if (value >= best_value)
                best_value = value;
        }; // end main recursive loop of forallmoves
        hashstore(value_to_tt(best_value, pos->realdepth), depth, 0, 0, UPPER, pos->HASH_KEY);
        return best_value;
    }
    
    void Search::hashstore(int32_t value, int32_t depth, U8 best_from, U8 best_to, int32_t f, U64& HASH_KEY) {
        int32_t age;
        int32_t oldest = 0;
        TEntry *entry = NULL, *replace = NULL;
        U32 lock;
        // register uint32_t i;
        uint32_t i;
        /*if((HASH_KEY & MASK)>=500000){
         // printf("why too large\n");
         return;
         }*/
        entry = replace = ttable +(HASH_KEY & MASK); // first entry
        // printf("hashstore: %d, %llu, %d, %llu\n", depth, HASH_KEY & MASK, tableSize, HASH_KEY);
        lock = (HASH_KEY >> 32); // use the high 32 bits as lock
        
        for (i = 0; i < REHASH; i++, entry++) {
            if (((entry->m_lock) == 0) || ((entry->m_lock) == lock)){ // empty or hash hit => update existing entry
                // don't overwrite entry's best move with 0
                if ( ( best_from == 0 ) && ( best_to == 0 ) ){
                    best_from = (entry->m_best_from);
                    best_to = (entry->m_best_to);
                }
                entry->m_valuetype = f;
                
                if ((entry->m_best_from != best_from ) || ( entry->m_best_to != best_to)){
                    entry->m_best_from2 = entry->m_best_from;
                    entry->m_best_to2 = entry->m_best_to;
                    entry->m_best_from = best_from;
                    entry->m_best_to = best_to;
                }
                
                entry->m_lock = lock;
                entry->m_depth = depth;
                entry->m_value = value;
                entry->m_age = searches_performed_in_game;
                return;
            } // empty or hash hit
            age = ((( searches_performed_in_game - entry->m_age ) & 255 ) * MAXDEPTH   + MAXDEPTH - (entry->m_depth ));
            if (age > oldest){
                oldest = age;
                replace = entry;
            }
        } // rehash loop
        
        replace->m_valuetype = f;
        if(entry - this->ttable>=2097000){
            // printf("before entry die: %ld\n",  entry - this->ttable);
            return;
        }
        // printf("before entry die: %ld\n",  entry - this->ttable);
        entry->m_best_from = best_from;
        entry->m_best_to = best_to;
        entry->m_best_from2 = 0;
        entry->m_best_to2 = 0;
        replace->m_lock = lock;
        replace->m_depth = depth;
        replace->m_value = value;
        replace->m_age = searches_performed_in_game;
    }
    
    int32_t Search::hashretrieve(int32_t *tr_depth, int32_t depth, int32_t *value, int32_t alpha, int32_t beta, U8 *best_from, U8 *best_to, U8 *best_from2, U8 *best_to2, int32_t *try_mcp, int& realdepth, U64& HASH_KEY) {
        TEntry *beste = NULL,*entry = NULL;
        // register uint32_t i;
        uint32_t i;
        U32 lock;
        int32_t found = 0;
        
        entry = ttable + (U32)(HASH_KEY & MASK); // first entry
        lock = (HASH_KEY >> 32); // use the high 32 bits as lock
        
        for (i = 0; ((i < REHASH ) && (found == 0)); i++,entry++) {
            if ((entry->m_lock) == lock) {
                found++;
                beste = entry;
            }
        } // for
        
        if (found == 0) {
            return (0);
        }
        
        int32_t v = (beste->m_value);
        if(abs(v) >= HASHMATE) {
            if (v > 0)
                v -= realdepth;
            if (v < 0)
                v += realdepth;
        }
        // if we are searching with a higher remaining depth than what is in the hashtable then
        // all we can do is set the best move for move ordering
        if ((beste->m_depth) >= depth) {
            
            // we have sufficient depth in the hashtable to possibly cause a cutoff.
            // if we have a lower bound, we might get a cutoff
            
            if (((beste->m_valuetype) & LOWER) != 0) {
                // the value stored in the hashtable is a lower bound, so it's useful
                if (v >= beta) {
                    // value > beta: we can cutoff!
                    *value = v;
                    beste->m_age = searches_performed_in_game; // to avoid aging
                    return (1);
                }
            };
            
            // if we have an upper bound, we can get a cutoff
            if (((beste->m_valuetype) & UPPER) != 0) {
                // the value stored in the hashtable is an upper bound, so it's useful
                if(v <= alpha){
                    // value < alpha: we can cutoff!
                    *value = v;
                    beste->m_age = searches_performed_in_game; // to avoid aging
                    return (1);
                }
            };
        }
        // ***********************************************************************************
        // use mate values
        
        if (v >= MAX(HASHMATE, beta)) {
            if (((beste->m_valuetype) & LOWER) != 0) {
                if (v >= beta) {
                    *value = v;
                    beste->m_age = searches_performed_in_game;
                    return (1);
                }
            }
        }
        
        if (v <= MIN(-HASHMATE, alpha)) {
            if (((beste->m_valuetype) & UPPER) != 0) {
                if (v <= alpha) {
                    *value = v;
                    beste->m_age = searches_performed_in_game;
                    return (1);
                }
            }
        }
        // forward pruning switch
        if (((beste->m_valuetype) & UPPER) != 0)
            if ((beste->m_depth) >  (depth >= 15) ? (depth - 4 - 2) : (depth - 3 - 2))
                if (v <= beta)
                    *try_mcp = 0; // don't try forward pruning
        // set best move
        *best_from = (beste->m_best_from);
        *best_to = (beste->m_best_to);
        *best_from2 = (beste->m_best_from2);
        *best_to2 = (beste->m_best_to2);
        *tr_depth = (beste->m_depth);
        return (0);
    }
    
    static int32_t value_to_tt(int32_t value, int32_t& realdepth) {
        // modify value
        if (value < -HASHMATE) {
            value -= realdepth;
            if (value < -MATE)
                value = -MATE;
            return (value);
        }
        if (value > HASHMATE) {
            value += realdepth;
            if (value > MATE)
                value = MATE;
            return value;
        }
        return (value);
    }
    
    void Search::retrievepv(int32_t b[46], char *pv, int32_t color) {
        // gets the pv from the hashtable
        // get a pv string:
        int32_t n;
        int32_t i;
        U8 bestfrom;
        U8 bestto;
        U8 bestfrom2;
        U8 bestto2;
        int32_t bestindex = 0;
        struct move2 movelist[MAXMOVES];
        int32_t dummy = 0;
        char pvmove[256];
        int32_t count = 0;
        int32_t copy[46];
        // original board b[46] needs not to be changed
        for (i=0; i<46; i++)
            copy[i] = b[i];
        bestfrom = 0;
        bestto = 0;
        bestfrom2 = 0;
        bestto2 = 0;
        sprintf(pv, "");
        init_piece_lists(copy, pos);
        pos->HASH_KEY = Position_to_Hashnumber(copy,color);
        hashretrieve(&dummy, 100, &dummy, dummy, dummy, &bestfrom, &bestto, &bestfrom2, &bestto2, &dummy, pos->realdepth, pos->HASH_KEY);
        while ((bestfrom != 0) && (bestto != 0) && (count<10)) {
            n = Gen_Captures(copy, movelist, color, 1, pos);
            if(!n)
                n = Gen_Moves(copy, movelist, color, pos);
            if (!n)
                return;
            for (i = 0; i < n ; i++) {
                if ((U8)((movelist[i].m[0]) & 0x3f) == bestfrom &&  (U8)((movelist[i].m[1]) & 0x3f) == bestto) {
                    bestindex = i;
                    break;
                }
            }
            
            movetonotation(movelist[bestindex], pvmove);
            domove2(copy, &movelist[bestindex], color, pos);
            strcat(pv, " ");
            strcat(pv, pvmove);
            color = color^CC;
            pos->HASH_KEY = Position_to_Hashnumber(copy, color);
            // look up next move
            bestfrom = 0;
            bestto = 0;
            bestfrom2 = 0;
            bestto2 = 0;
            hashretrieve(&dummy, 100, &dummy, dummy, dummy, &bestfrom, &bestto, &bestfrom2, &bestto2, &dummy, pos->realdepth, pos->HASH_KEY);
            count++;
        }
    }
    
    void __inline Search::killer(U8 bestfrom, U8 bestto, int32_t realdepth, int32_t capture) {
        if (capture)
            return;
        if ((bestfrom == killersf1[realdepth]) && (bestto == killerst1[realdepth]))
            return;
        killersf2[realdepth] = killersf1[realdepth];
        killerst2[realdepth] = killerst1[realdepth];
        killersf1[realdepth] = bestfrom;
        killerst1[realdepth] = bestto;
        return;
    }
    
    
    void Search::hist_succ(U8 from, U8 to, int32_t depth, int32_t capture) {
        if (capture)
            return;
        int32_t hindex = (SQUARE_TO_32(from) <<5) + SQUARE_TO_32(to);
        int32_t sv =  history_tabular[hindex] ;
        history_tabular[hindex] = sv + depth*depth;
        if (history_tabular[hindex] > MAXHIST)
            for (int32_t p = 0; p <= 1023 ; p++)
                history_tabular[p] = ( history_tabular[p] ) / 2;
    }
    
    void Search::history_bad(U8 from, U8 to, int32_t depth) {
        int32_t hindex = (SQUARE_TO_32(from) <<5) + SQUARE_TO_32(to);
        int32_t sv =  history_tabular[hindex] ;
        history_tabular[hindex] = sv - depth*depth;
        if (history_tabular[hindex] < -MAXHIST)
            for (int32_t p = 0; p <= 1023 ; p++)
                history_tabular[p] = (history_tabular[p]) / 2;
    }
    
    void Search::ClearHistory(void) {
        // clear previous History before each new game
        for (int32_t i = 0; i <= 1023; i++) {
            history_tabular[i] = 0;
        }
        
        // also clear the killer moves
        for (int32_t i = 0; i <= (MAXDEPTH + 1); i++) {
            killersf1[i] = 0;
            killerst1[i] = 0;
            killersf2[i] = 0;
            killerst2[i] = 0;
        }
        // clear repetition checker
        // TODO Tam bo memset(pos->RepNum, 0, MAXDEPTH*sizeof(U64));
    }
    
    static int32_t has_man_on_7th(int32_t b[46], int32_t color) {
        // color has passer
        if (color == WHITE) {
            if ((b[13] == WHT_MAN) && (b[8] == FREE))
                return (1);
            if ((b[12] == WHT_MAN) && ((b[7] == FREE) || (b[8] == FREE)))
                return (1);
            if ((b[11] == WHT_MAN) && ((b[6] == FREE) || (b[7] == FREE)))
                return (1);
            if ((b[10] == WHT_MAN) && ((b[5] == FREE) || (b[6] == FREE)))
                return (1);
            return (0);
        } else {
            if ((b[32] == BLK_MAN) && (b[37] == FREE))
                return (1);
            if ((b[33] == BLK_MAN) && ((b[37] == FREE) || (b[38] == FREE)))
                return (1);
            if ((b[34] == BLK_MAN) && ((b[38] == FREE) || (b[39] == FREE)))
                return (1);
            if ((b[35] == BLK_MAN) && ((b[39] == FREE) || (b[40] == FREE)))
                return (1);
            return (0);
        }
    }
    
    static int32_t fast_eval(int32_t b[46], int32_t color, Position* pos) {
        // returns material balance at given node + PST
        
        int32_t nbm = pos->g_pieces[BLK_MAN];
        int32_t nbk = pos->g_pieces[BLK_KNG];
        int32_t nwm = pos->g_pieces[WHT_MAN];
        int32_t nwk = pos->g_pieces[WHT_KNG];
        
        if ((nbm == 0) && (nbk == 0))
            return (pos->realdepth - MATE);
        if ((nwm == 0) && (nwk == 0))
            return (pos->realdepth - MATE);
        int32_t v1 = 100 * nbm + 300 * nbk;
        int32_t v2 = 100 * nwm + 300 * nwk;
        int32_t  eval = v1 - v2; // total evaluation
        
        int32_t White = nwm + nwk; // total number of white pieces
        int32_t Black = nbm + nbk;     // total number of black pieces
        
        // draw situations
        if (nbm == 0 && nwm == 0 && abs(nbk - nwk) <= 1) {
            return (0); // only kings left
        }
        if ((eval > 0) && (nwk > 0) && (Black < (nwk+2))) {
            return (0); // black cannot win
        }
        
        if ((eval < 0) && (nbk > 0) && (White < (nbk+2))) {
            return (0); //  white cannot win
        }
        
        
        int32_t opening = 0;
        int32_t endgame = 0;
        int32_t square;
        uint32_t i;
        //a piece of code to encourage exchanges
        //in case of material advantage:
        // king's balance
        if (nbk != nwk) {
            if (nwk == 0) {
                if (nwm <= 4) {
                    endgame += 50;
                    if (nwm <= 3) {
                        endgame += 100;
                        if (nwm <= 2) {
                            endgame += 100;
                            if (nwm <= 1)
                                endgame += 100;
                        }
                    }
                }
            }
            if (nbk == 0) {
                if (nbm <= 4) {
                    endgame -= 50;
                    if (nbm <= 3) {
                        endgame -= 100;
                        if (nbm <= 2) {
                            endgame -= 100;
                            if (nbm <= 1)
                                endgame -= 100;
                        }
                    }
                }
            }
        } else {
            if ((nbk == 0) && (nwk == 0))
                eval += 250*(v1 - v2)/(v1+v2);
            if (nbk + nwk != 0)
                eval += 100*(v1 - v2)/(v1 + v2);
        }
        
        static U8 PST_man_op[41] = {
            0,0,0,0,0,   // 0 .. 4
            15,40,42,45,0,              // 5 .. 8 (9)
            12,38,36,15,                     // 10 .. 13
            28,26,30,20,0,               // 14 .. 17 (18)
            18,26,36,28,                    // 19 .. 22
            32,38,10,18,0,                // 23 .. 26 (27)
            18,22,24,20,                 //  28 .. 31
            26,0,0,0,0,                      // 32 .. 35 (36)
            0,0,0,0                          // 37 .. 40
        };
        
        static U8 PST_man_en[41] = {
            0,0,0,0,0,  // 0 .. 4
            0,2,2,2,    0,                  // 5 .. 8 (9)
            4,4,4,4,                     // 10 .. 13
            6,6,6,6,    0,               // 14 .. 17 (18)
            10,10,10,10,                  // 19 .. 22
            16,16,16,16,   0,              // 23 .. 26 (27)
            22,22,22,22,                //  28 .. 31
            30,0,0,0,         0,            // 32 .. 35 (36)
            0,0,0,0                        // 37 .. 40
        };
        
        for (i = 1; i <= pos->num_bpieces; i++) {
            if ((square = pos->p_list[BLACK][i]) == 0)
                continue;
            if ((b[square] & MAN) != 0) {     // black man
                opening += PST_man_op[square];
                endgame += PST_man_en[square];
            }
        }
        
        for (i = 1; i <= pos->num_wpieces; i++) {
            if ((square = pos->p_list[WHITE][i]) ==0)
                continue;
            if ((b[square] & MAN) != 0) {    // white man
                opening -= PST_man_op[45 - square];
                endgame -= PST_man_en[45 - square];
            }
        }
        
        // phase mix
        // smooth transition between game phases
        int32_t phase = nbm + nwm - nbk - nwk;
        if (phase < 0)
            phase = 0;
        int32_t antiphase = 24 - phase;
        eval += ((opening * phase + endgame * antiphase )/24);
        if ((White + Black < 8) && nbk != 0 && nwk != 0 && nbm != 0 && nwm != 0) {
            if (abs(nbm - nwm) <= 1  && abs(nbk - nwk) <= 1 && abs(White - Black) <= 1) {
                eval /= 2;
            }
        }
        // negamax formulation requires this:
        if (color == BLACK) {
            return (eval);
        } else {
            return (-eval);
        }
    }
    
    static int32_t __inline is_promotion(struct move2 *move) {
        //
        //
        if (((move->m[0]) >> 6) == ((move->m[1]) >> 6))
            return (0);
        return (1);
    }
    
    static int32_t is_blk_kng(int32_t b[46] ){
        int32_t retval = 0;
        int32_t i;
        for (i = 5; i < 41 ; i += 5) {
            if (b[i] == WHT_KNG)
                return(0);
            if (b[i] == WHT_MAN)
                return(0);
            if (b[i] == BLK_MAN)
                return(0);
            if (b[i] == BLK_KNG)
                retval = 1;
        }
        return retval;
    }
    
    static int32_t is_blk_kng_1(int32_t b[46]) {
        // 8-32
        int32_t i;
        int32_t cnt = 0;
        for (i = 8; i <= 32 ;i += 4)
            if (b[i] == BLK_KNG)
                cnt++;
        
        return cnt;
    }
    
    static int32_t is_wht_kng_1(int32_t b[46]) {
        // 8-32
        int32_t i;
        int32_t cnt = 0;
        for (i = 8; i <= 32 ; i += 4)
            if (b[i] == WHT_KNG)
                cnt++;
        
        return cnt;
    }
    
    static int32_t is_blk_kng_2(int32_t b[46]) {
        // 13-37
        int32_t i;
        int32_t cnt = 0;
        for (i = 13; i <= 37 ; i += 4)
            if (b[i] == BLK_KNG)
                cnt++;
        
        return cnt;
    }
    
    static int32_t is_wht_kng_2(int32_t b[46]) {
        // 13-37
        int32_t i;
        int32_t cnt = 0;
        for (i = 13; i <= 37 ; i += 4)
            if (b[i] == WHT_KNG)
                cnt++;
        
        return cnt;
    }
    
    static int32_t is_blk_kng_3(int32_t b[46]) {
        // 14-39
        int32_t i;
        int32_t cnt = 0;
        for (i = 14; i <= 39 ; i += 5)
            if (b[i] == BLK_KNG)
                cnt++;
        return cnt;
    }
    
    static int32_t is_wht_kng_3(int32_t b[46]) {
        // 14-39
        int32_t i;
        int32_t cnt = 0;
        for (i = 14; i <= 39 ; i += 5)
            if (b[i] == WHT_KNG)
                cnt++;
        return cnt;
    }
    
    static int32_t is_blk_kng_4(int32_t b[46]) {
        // 6-31
        int32_t i;
        int32_t cnt = 0;
        for (i = 6; i <= 31 ; i += 5)
            if (b[i] == BLK_KNG)
                cnt++;
        return cnt;
    }
    
    static int32_t is_wht_kng_4(int32_t b[46]) {
        // 6-31
        int32_t i;
        int32_t cnt = 0;
        for (i = 6; i <= 31 ; i += 5)
            if (b[i] == WHT_KNG)
                cnt++;
        
        return cnt;
    }
    
    static int32_t is_wht_kng(int32_t b[46]) {
        int32_t retval = 0;
        int32_t i;
        for (i = 5; i < 41 ; i += 5) {
            if (b[i] == WHT_MAN)
                return(0);
            if (b[i] == BLK_MAN)
                return(0);
            if (b[i] == BLK_KNG)
                return(0);
            if (b[i] == WHT_KNG)
                retval = 1;
        }
        return retval;
    }
    
    static int32_t pick_next_move(int32_t *marker, int32_t SortVals[MAXMOVES], int32_t n ) {
        // a function to give pick the top move order, one at a time on each call.
        // Will return 1 while there are still moves left, 0 after all moves
        // have been used
        
        int32_t best = -1000000;
        int32_t i;
        *marker = -32767;
        
        for (i = 0; i < n; i++) {
            if (SortVals[i] > best) {
                *marker = i;
                best = SortVals[i];
            }
        }
        
        if (*marker > -32767) {
            SortVals[*marker] = -1000000;
            return (1);
        }
        return (0);
    }
    
    
    static void Sort(int32_t start, int32_t num, int32_t SortVals[MAXMOVES], struct move2 movelist[MAXMOVES]) {
        // do a linear search through the current ply's movelist starting at start
        // and swap the best one with start
        
        int32_t i,j;
        int32_t Max;
        Max = SortVals[start];
        j = start;
        
        for (i = (start+1); i < num; i++) {
            if (SortVals[i] > Max) {
                Max = SortVals[i];
                j  = i; // best index
            }
        }
        
        if (Max != SortVals[start]) { // swap
            struct move2 m = movelist[start];
            movelist[start] = movelist[j];
            movelist[j] = m;
            int32_t tmp = SortVals[start];
            SortVals[start] = SortVals[j];
            SortVals[j] = tmp;
        }
    }
    
    static void QuickSort(int32_t SortVals[MAXMOVES], struct move2 movelist[MAXMOVES], int32_t inf, int32_t sup) {
        // quick sort algorithm used to sort movelist
        int32_t pivot;
        // register int32_t i,j;
        int32_t i, j;
        int32_t swap;
        struct move2 temp;
        i = inf;
        j = sup;
        pivot = SortVals[(i+j)/2];
        do {
            while (SortVals[i] > pivot)
                i++;
            while (SortVals[j] < pivot)
                j--;
            if (i<j) {
                swap = SortVals[i];
                SortVals[i] = SortVals[j];
                SortVals[j] = swap;
                temp = movelist[i];
                movelist[i] = movelist[j];
                movelist[j] = temp;
            }
            if (i<=j) {
                i++;
                j--;
            }
        } while (i<=j);
        if (inf<j)
            QuickSort(SortVals,movelist,inf,j); // recurse
        if (i<sup)
            QuickSort(SortVals,movelist,i,sup); // recurse
    }
    
    static bool is_move_to_7(int32_t b[46], struct move2 *move)
    {
        // unstopable move to 7th rank is considered as dangerous
        uint32_t piece,to;
        piece = (move->m[0]) >> 6;    // moving piece
        to = (move->m[1]) & 0x3f;     // destination square
        
        if (piece == BLK_MAN) {
            if (to > 31 && to < 36) {
                if (to == 32) {
                    if (b[37] == FREE)
                        return true;
                    return false;
                }
                if (to == 33) {
                    if ((b[37] == WHT_MAN) && (b[29] == FREE)) {
                        if (b[32] == BLK_MAN)
                            return true;
                        return false;
                    }
                    if ((b[38] == WHT_MAN) && (b[28] == FREE))
                        return false;
                    if ((b[28] == WHT_MAN) && (b[38] == FREE))
                        return false;
                    if ((b[29] == WHT_MAN) && (b[37] == FREE))
                        return false;
                    return true;
                }
                if (to == 34) {
                    if ((b[38] == WHT_MAN) && (b[30] == FREE))
                        return false;
                    if ((b[39] == WHT_MAN) && (b[29] == FREE))
                        return false;
                    if ((b[29] == WHT_MAN) && (b[39] == FREE))
                        return false;
                    if ((b[30] == WHT_MAN) && (b[38] == FREE))
                        return false;
                    return true;
                }
                if (to == 35) {
                    if ((b[40] == WHT_MAN) && (b[30] == FREE))
                        return false;
                    if ((b[39] == WHT_MAN) && (b[31] == FREE))
                        return false;
                    if ((b[30] == WHT_MAN) && (b[40] == FREE))
                        return false;
                    if ((b[31] == WHT_MAN) && (b[39] == FREE))
                        return false;
                    return true;
                }
            }
        }
        
        if (piece == WHT_MAN) {
            if (to > 9 && to < 14) {
                if (to == 10) {
                    if ((b[5] == BLK_MAN) && (b[15] == FREE))
                        return false;
                    if ((b[6] == BLK_MAN) && (b[14] == FREE))
                        return false;
                    if ((b[14] == BLK_MAN) && (b[6] == FREE))
                        return false;
                    if ((b[15] == BLK_MAN) && (b[5] == FREE))
                        return false;
                    return true;
                }
                if (to == 11) {
                    if ((b[6] == BLK_MAN) && (b[16] == FREE))
                        return false;
                    if ((b[7] == BLK_MAN) && (b[15] == FREE))
                        return false;
                    if ((b[15] == BLK_MAN) && (b[7] == FREE))
                        return false;
                    if ((b[16] == BLK_MAN) && (b[6] == FREE))
                        return false;
                    return true;
                }
                if (to == 12) {
                    if ((b[7] == BLK_MAN) && (b[17] == FREE))
                        return false;
                    if ((b[8] == BLK_MAN) && (b[16] == FREE)) {
                        if (b[13] == WHT_MAN)
                            return true;
                        return false;
                    }
                    if ((b[16] == BLK_MAN) && (b[8] == FREE))
                        return false;
                    if ((b[17] == BLK_MAN) && (b[7] == FREE))
                        return false;
                    return true;
                }
                if (to == 13) {
                    if (b[8] == FREE)
                        return true;
                    return false;
                }
            }
        }
        return (false);
    }
    
    static bool move_to_a1h8(struct move2 *move) {
        uint32_t from, piece, to;
        piece = (move->m[0]) >> 6; // moving piece
        if ((piece & KING) != 0) { // king move
            to = (move->m[1]) & 0x3f;  // destination square
            from = (move->m[0]) & 0x3f; // from square
            if ((to % 5 == 0) && (from % 5 != 0))
                return (true);
        }
        return (false);
    }
    
    static void init_piece_lists(int32_t b[46], Position* pos) {
        
        int32_t color, i;
        
        pos->num_wpieces = 0;
        pos->num_bpieces = 0;
        
        pos->g_pieces[BLK_MAN] = 0;
        pos->g_pieces[BLK_KNG] = 0;
        pos->g_pieces[WHT_MAN] = 0;
        pos->g_pieces[WHT_KNG] = 0;
        
        for (i=0; i<=40; i++)
            pos->indices[i] = 0;
        
        for (i=0; i<=15; i++) {
            pos->p_list[WHITE][i] = 0;
            pos->p_list[BLACK][i] = 0;
        }
        
        for (i=5; i<=40; i++) {
            if ((b[i] != OCCUPIED) && (b[i] != FREE)) {
                pos->g_pieces[b[i]]++;
                color = (b[i] & WHITE) ? WHITE : BLACK;
                if (color == WHITE) {
                    pos->num_wpieces += 1;
                    pos->p_list[WHITE][pos->num_wpieces] = i;
                    pos->indices[i] = pos->num_wpieces;
                } else {
                    pos->num_bpieces += 1;
                    pos->p_list[BLACK][pos->num_bpieces] = i;
                    pos->indices[i] = pos->num_bpieces;
                }
            } else
                pos->indices[i] = 0;
        }
        pos->g_root_mb = (pos->g_pieces[BLK_MAN] - pos->g_pieces[WHT_MAN])*100 + (pos->g_pieces[BLK_KNG] - pos->g_pieces[WHT_KNG])*300;
    }
    
    
    static void Perft(int32_t *b, int32_t color, uint32_t depth, Position* pos) {
        // perfomance test
        // register uint32_t capture,n;
        uint32_t capture,n;
        int32_t i;
        capture = Test_Capture(b, color, pos);
        if (capture) {
            struct move2 movelist[MAXCAPTURES];
            n = Gen_Captures(b, movelist, color, capture, pos);
            --depth;
            for (i = n-1; i >=0; i--) {
                domove2(b, &movelist[i], color, pos);
                if (depth)
                    Perft(b, color^CC, depth, pos);
                else
                    ++PerftNodes;
                undomove(b, &movelist[i], color, pos);
            }
        } else {
            struct move2 movelist[MAXMOVES];
            n = Gen_Moves(b, movelist, color, pos);
            --depth;
            for (i = n-1; i >= 0; i--) {
                domove2(b, &movelist[i], color, pos);
                if (depth)
                    Perft(b, color^CC, depth, pos);
                else
                    ++PerftNodes;
                undomove(b, &movelist[i], color, pos);
            }
        }
    }
    
    static int32_t EdProbe(int32_t c[46], int32_t color) {
        if (!ED)
            return EdAccess::not_found;
        
        uint32_t i;
        EdAccess::EdBoard1 b;
        static const int32_t Map_32_to_45[32] = {
            8,  7,  6,  5,
            13, 12, 11, 10,
            17, 16, 15, 14,
            22, 21, 20, 19,
            26, 25, 24, 23,
            31, 30, 29, 28,
            35, 34, 33, 32,
            40, 39, 38, 37
        };
        
        if (color == WHITE) {
            for (i = 0; i < 32; i++) {
                switch (c[Map_32_to_45[i]]) {
                    case FREE           :
                        b.board[i] = EdAccess::empty;
                        break;
                    case WHITE | MAN :
                        b.board[i] = EdAccess::white;
                        break;
                    case BLACK | MAN :
                        b.board[i] = EdAccess::black;
                        break;
                    case WHITE | KING:
                        b.board[i] = EdAccess::white | EdAccess::king;
                        break;
                    case BLACK | KING:
                        b.board[i] = EdAccess::black | EdAccess::king;
                        break;
                }
            }
        } else {
            // ��� ���� ������ "��������������" �����
            for (i = 0; i < 32; i++) {
                switch (c[Map_32_to_45[31 - i]]) {
                    case FREE           :
                        b.board[i] = EdAccess::empty;
                        break;
                    case WHITE | MAN :
                        b.board[i] = EdAccess::black;
                        break;
                    case BLACK | MAN :
                        b.board[i] = EdAccess::white;
                        break;
                    case WHITE | KING:
                        b.board[i] = EdAccess::black | EdAccess::king;
                        break;
                    case BLACK | KING:
                        b.board[i] = EdAccess::white | EdAccess::king;
                        break;
                }
            }
        }
        
        return ED->GetResult(&b, 0);
    }
    
    
    //*************************************************
    //*                                               *
    //*               Kallisto support                *
    //*                                               *
    //*************************************************
    
    int32_t AnalyseMode = 0;
    // int32_t PlayNow = 0;
    
    int32_t TimeRemaining;
    int32_t IncTime;
    
    void Wait(int32_t &v)
    {
        while(v) {
            // Sleep(10);
            std::this_thread::sleep_for (std::chrono::milliseconds(10));
        }
    }
    
    void SquareToStr(uint16_t sq, char *s)
    {
        static const int32_t Square64[] = {
            0,  0,  0,  0,  0,
            7,  5,  3,  1,  0,
            14, 12, 10,  8,
            23, 21, 19, 17,  0,
            30, 28, 26, 24,
            39, 37, 35, 33,  0,
            46, 44, 42, 40,
            55, 53, 51, 49,  0,
            62, 60, 58, 56
        };
        
        sq = Square64[sq];
        s[0] = sq % 8 + 'a';
        s[1] = 8 - sq / 8 + '0';
        s[2] = 0;
    }
    
    void MoveToStr(move2 m, char *s)
    {
        SquareToStr(m.m[0] & 63, s);
        for (int32_t i = 2; i < m.l; i++) {
            strcat(s, ":");
            SquareToStr(m.m[i] & 63, s + strlen(s));
        }
        if (m.l > 2)
            strcat(s, ":");
        SquareToStr(m.m[1] & 63, s + strlen(s));
    }
    
    // ������� ��� move
    // ������ �����: "a3b4" � "a3:b4:d6:e7". ����� ������ ��������� ��������� ��� ��������������� ��� �������
    void EI_MakeMove(Position* pos, char *move)
    {
        if (AnalyseMode){
            // PlayNow = 1;
            Wait(AnalyseMode);
            //EnterCriticalSection(&AnalyseSection);
            //LeaveCriticalSection(&AnalyseSection);
        }
        move2 ml[MAXMOVES];
        init_piece_lists(pos->Board, pos);
        int32_t n = Gen_Captures(pos->Board, ml, pos->Color, 1, pos);
        if (!n)
            n = Gen_Moves(pos->Board, ml, pos->Color, pos);
        for (int32_t i = 0; i < n; i++) {
            char s[128];
            MoveToStr(ml[i], s);
            if (!strcmp(s, move)) {
                domove2(pos->Board, &ml[i], pos->Color, pos);
                if (pos->Color == WHITE)
                    pos->Color = BLACK;
                else
                    pos->Color = WHITE;
                return;
            }
        }
        // MessageBox(0, "KestoG: move not found", move, MB_OK);
        printf("KestoG: move not found\n");
    }
    
    // ������ ����������. ����� ������� ������ ���
    // ��� ������� ����� ����������� ��� ������ �����
    // �� ���� ����� � ���� ���������� ����������� ������� (��. EI_SetTimeControl � EI_SetTime)
    void Search::EI_Think()
    {
        // correct
        {
            if(g_seldepth<=0){
                g_seldepth = 1;
            }
            if(g_seldepth>MAX_SEARCH_DEPTH){
                g_seldepth = MAX_SEARCH_DEPTH;
            }
            if(timeLimit<=0){
                timeLimit = 1000;
            }
            if(timeLimit>=MAX_SEARCH_TIME){
                timeLimit = MAX_SEARCH_TIME;
            }
        }
        
        char dummy[256];
        // PlayNow = 0;
        play = 0;//  &PlayNow;
        
        compute(pos->Board, pos->Color, timeLimit, dummy);
        char s[128];
        {
            s[0] = 0;
        }
        MoveToStr(bestrootmove, s);
        if (pos->Color == WHITE)
            pos->Color = BLACK;
        else
            pos->Color = WHITE;
        printf("find move: %s\n", s);
    }
    
    // ����� ����� ������ ��� ������ � ��� ������ �����
    // ��� ������� ���������� � ������ ����� ��������� ������ ��� ����� �����
    void EI_Ponder()
    {
        // ����� ����� ������ � �� ������ :)
        return;
    }
    
    // ��������� ������ ��� move
    // ����� ���� ���������� ������� Ponder
    // ����� ����� ����� ������� ��� �� ������ ����c����� ��������� � Ponder
    // ����� �������� ��� � ������ ����� ����� ������� ���
    void Search::EI_PonderHit(char *move)
    {
        EI_MakeMove(this->pos, move);
        EI_Think();
    }
    
    // ������������� ������
    // si - ��. ���� �������� PF_SearchInfo
    // mem_lim - ����� ������, ������� ����� ������������ ������
    // ����� � �������� ������� ����� ������ ���-�������
    void EI_Initialization(PF_SearchInfo si, int32_t mem_lim)
    {
        pfSearchInfo = si;
        // InitializeCriticalSection(&AnalyseSection);
        size = (uint32_t)mem_lim;
    }
    
    // ��������� ��������� �� ���������� ������� ������ ��������� � ��������
    void EI_SetSearchInfoEx(PF_SearchInfoEx sie)
    {
        pfSearchInfoEx = sie;
    }
    
    // ��������� ���������� � ����� �� ������� EI_Think, EI_Ponder, EI_PonderHit ��� EI_Analyse
    void EI_Stop()
    {
        // PlayNow = 1;
    }
    
    static const int32_t Map[32] = {
        8,  7,  6,  5,
        13, 12, 11, 10,
        17, 16, 15, 14,
        22, 21, 20, 19,
        26, 25, 24, 23,
        31, 30, 29, 28,
        35, 34, 33, 32,
        40, 39, 38, 37
    };
    
    // ���������� ������� pos �� �����
    // ������: ��������� ������� bbbbbbbbbbbb........wwwwwwwwwwwww
    // b - ������� ������
    // B - ������ �����
    // w - ������� �����
    // W - ����� �����
    // . - ������ ����
    // ���� ������������� ���: b8, d8, f8, h8, a7, c7, ..., a1, c1, e1, g1
    // ��������� ������ ���������� ����������� ����
    // w - �����, b - ������
    void Position::EI_SetupBoard(const char *p)
    {
        int32_t i;
        for(i = 0; i < 46; i++)
            Board[i] = OCCUPIED;
        for (i = 0; i < 32; i++) {
            switch (p[i]) {
                case 'w':
                    Board[Map[i]] = WHITE | MAN;
                    break;
                case 'W':
                    Board[Map[i]] = WHITE | KING;
                    break;
                case 'b':
                    Board[Map[i]] = BLACK | MAN;
                    break;
                case 'B':
                    Board[Map[i]] = BLACK | KING;
                    break;
                case '.':
                    Board[Map[i]] = FREE;
                    break;
            }
        }
        if (p[32] == 'w')
            Color = WHITE;
        else
            Color = BLACK;
        EvalHashClear();
        Create_HashFunction();
    }
    
    void Position::toFen(char* fen)
    {
        for (int i = 0; i < 32; i++) {
            switch (Board[Map[i]]) {
                case WHITE | MAN:
                    fen[i] = 'w';
                    break;
                case WHITE | KING:
                    fen[i] = 'W';
                    break;
                case BLACK | MAN:
                    fen[i] = 'b';
                    break;
                case BLACK | KING:
                    fen[i] = 'B';
                    break;
                default:
                    fen[i] = '.';
                    break;
            }
        }
        if (Color == WHITE)
            fen[32] = 'w';
        else
            fen[32] = 'b';
        fen[33] = 0;
    }
    
    void Position::EI_NewGame(const char* fen)
    {
        /*char startFen[100];
        {
            startFen[0] = 0;
            sprintf(startFen, "%s%s", startFen, "bbbbbbbbbbbb........wwwwwwwwwwwww");
            // sprintf(startFen, "%s%s", startFen, "............b.....W.b...B....w..w");
        }*/
        EI_SetupBoard(fen);
        init_piece_lists(this->Board, this);
    }
    
    // ���������� �������� �������
    // time ����� �� ������
    // inc ������ - ����� �� ������ ��������� ��� (���� ������)
    void EI_SetTimeControl(int32_t time, int32_t inc)
    {
        TimeRemaining = time * 60 * 1000;
        IncTime = inc;
    }
    
    // ���������� ����� � ������������� ���������� �� �����
    // time - ���� �����
    // otime - ����� ����������
    void EI_SetTime(int32_t time, int32_t otime)
    {
        TimeRemaining = time;
    }
    
    // ������� �������� ������
    /*char* EI_GetName()
     {
     return "KestoG 1.5 I";
     }*/
    
    // ������������� ������� �������
    // ����� �� ������ ������� �������������� ��� ��������� ������ Stop ��� ����Move
    void Search::EI_Analyse()
    {
        AnalyseMode = true;
        char dummy[256];
        // PlayNow = 0;
        play = 0;// &PlayNow;
        // EnterCriticalSection(&AnalyseSection);
        TTableInit(size);
        pos->EvalHashClear();
        searches_performed_in_game = 0;
        Create_HashFunction();
        ClearHistory();
        compute(pos->Board, pos->Color, 2000000000, dummy); // infinity1 thinking
        undomove(pos->Board, &bestrootmove, pos->Color, pos);
        AnalyseMode = false;
        // LeaveCriticalSection(&AnalyseSection);
    }
    
    
    // ������� ���������� �������������� �� dll
    void EI_EGDB(EdAccess *eda)
    {
        ED = eda;
        if (ED) {
            char gameType[50];
            {
                gameType[0] = 0;
                sprintf(gameType, "%srussian", gameType);
            }
            EdPieces = ED->Load(gameType);
            /*if (strstr(ED->GetBaseType(), "nocaptures")) {
                printf("EdNoCaputres\n");
                EdNocaptures = true;
            }*/
            //MessageBox(0, "Initialization-nocaptures", "", MB_OK);
        }
        //EdPieces = 0;  // comment this line out if EGDB usage works
        //MessageBox(0, "Initialization", "", MB_OK);
    }
    
    void Position::PrintBoard(char* ret)
    {
        ret[0] = 0;
        // Init
        int32_t b[8][8];
        {
            b[0][0] = Board[5]; b[2][0] = Board[6]; b[4][0] = Board[7]; b[6][0] = Board[8];
            b[1][1] = Board[10]; b[3][1] = Board[11]; b[5][1] = Board[12]; b[7][1] = Board[13];
            b[0][2] = Board[14]; b[2][2] = Board[15]; b[4][2] = Board[16]; b[6][2] = Board[17];
            b[1][3] = Board[19]; b[3][3] = Board[20]; b[5][3] = Board[21]; b[7][3] = Board[22];
            b[0][4] = Board[23]; b[2][4] = Board[24]; b[4][4] = Board[25]; b[6][4] = Board[26];
            b[1][5] = Board[28]; b[3][5] = Board[29]; b[5][5] = Board[30]; b[7][5] = Board[31];
            b[0][6] = Board[32]; b[2][6] = Board[33]; b[4][6] = Board[34]; b[6][6] = Board[35];
            b[1][7] = Board[37]; b[3][7] = Board[38]; b[5][7] = Board[39]; b[7][7] = Board[40];
        }
        sprintf(ret, "%s  a b c d e f g h\n", ret);
        for (int32_t y = 0; y < 8; y++) {
            sprintf(ret, "%s%d ", ret, 8-y);
            for (int32_t x = 7; x >= 0; x--) {
                if (x%2==y%2) {
                    switch (b[x][y]) {
                        case WHITE | MAN:
                            sprintf(ret, "%sw", ret);
                            break;
                        case WHITE | KING:
                            sprintf(ret, "%sW", ret);
                            break;
                        case BLACK | MAN:
                            sprintf(ret, "%sb", ret);
                            break;
                        case BLACK | KING:
                            sprintf(ret, "%sB", ret);
                            break;
                        case FREE:
                            sprintf(ret, "%s.", ret);
                            break;
                    }
                } else
                    sprintf(ret, "%s ", ret);
                sprintf(ret, "%s ", ret);
            }
            sprintf(ret, "%s\n", ret);
        }
        // Depth
        sprintf(ret, "%sDepth: %d\n", ret, realdepth);
        // HashKey
        {
            U64 HashKey = 0;
            if(realdepth>=0){
                HashKey = RepNum[realdepth];
            }
            sprintf(ret, "%sHashKey: %llu\n", ret, HashKey);
        }
        // Fen
        {
            char fen[34];
            {
                fen[33] = 0;
                toFen(fen);
            }
            sprintf(ret, "%sFen: %s\n", ret, fen);
        }
    }
    
    int32_t Position::russian_draught_isGameFinish()
    {
        // White
        {
            int32_t probe = EdProbe(Board, WHITE);
            if (probe!=EdAccess::not_found) {
                if (probe==EdAccess::draw) {
                    return 3;
                } else if (probe==EdAccess::win) {
                    return 1;
                } else if (probe==EdAccess::lose) {
                    return 2;
                }
            }
        }
        // Black
        {
            int32_t probe = EdProbe(Board, BLACK);
            if (probe!=EdAccess::not_found) {
                if (probe==EdAccess::draw) {
                    return 3;
                } else if (probe==EdAccess::win) {
                    return 2;
                } else if (probe==EdAccess::lose) {
                    return 1;
                }
            }
        }
        // depth
        {
            if(realdepth>=MAXDEPTH){
                printf("depth too much, so draw\n");
                return 3;
            }
        }
        // draw by triple repetition ?
        {
            if(realdepth>=6){
                int repeatCount = 0;
                for(int i=realdepth-4; i>=0; i-=4) {
                    if(RepNum[i] == RepNum[realdepth]){
                        repeatCount++;
                        if(repeatCount>=2){
                            printf("draw by repeat\n");
                            return 3;
                        }
                    }
                }
            }
        }
        // legalMoves
        {
            Position pos = *this;
            struct move2 movelist[MAXMOVES];
            int32_t n = Gen_Captures(pos.Board, movelist, pos.Color, 1, &pos);
            if(!n) {
                n = Gen_Moves(pos.Board, movelist, pos.Color, this);
            }
            if (n == 0) {
                if(Color==WHITE){
                    return 2;
                }else{
                    return 1;
                }
            }
            
        }
        return 0;
    }
    
    bool alreadyInitRussianDraughtCore = false;
    
    const char* StartFen = "bbbbbbbbbbbb........wwwwwwwwwwwww";
    
    void initCore()
    {
        if(!alreadyInitRussianDraughtCore){
            alreadyInitRussianDraughtCore = true;
            InitIndex();
            Create_HashFunction();
            ED = new EdAccessImp;
            EI_EGDB(ED);
        }
    }
    
    /////////////////////////////////////////////////////////////////////////////////////
    //////////////////// Convert move2 ///////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    
    int32_t move2::getByteSize()
    {
        int32_t ret = 0;
        {
            // uint16_t m[12];
            ret+= 12*sizeof(uint16_t);
            // char path[11];
            ret+= 11*sizeof(char);
            // unsigned char l;
            ret+= sizeof(unsigned char);
        }
        // printf("move2 byte size: %d\n", ret);
        return ret;
    }
    
    int32_t move2::convertToByteArray(move2* move, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = move->getByteSize();
        uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // uint16_t m[12];
            {
                int32_t size = 12*sizeof(uint16_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, move->m, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: m: %d, %d\n", pointerIndex, length);
                }
            }
            // char path[11];
            {
                int32_t size = 11*sizeof(char);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, move->path, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: path: %d, %d\n", pointerIndex, length);
                }
            }
            // unsigned char l;
            {
                int32_t size = sizeof(unsigned char);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &move->l, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: l: %d, %d\n", pointerIndex, length);
                }
            }
            // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
        }
        byteArray = ret;
        return length;
    }
    
    int32_t move2::parseByteArray(move2* move, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                {
                    // uint16_t m[12];
                    int32_t size = 12*sizeof(uint16_t);
                    if(pointerIndex+size<=length){
                        memcpy(move->m, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: m: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                {
                    // char path[11];
                    int32_t size = 11*sizeof(char);
                    if(pointerIndex+size<=length){
                        memcpy(move->path, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: path: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                {
                    // unsigned char l;
                    int32_t size = sizeof(unsigned char);
                    if(pointerIndex+size<=length){
                        memcpy(&move->l, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: l: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                default:
                {
                    // printf("unknown index: %d\n", index);
                    alreadyPassAll = true;
                }
                    break;
            }
            // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
            index++;
            if (!isParseCorrect) {
                printf("not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // return
        if (!isParseCorrect) {
            printf("parse fail\n");
        } else {
            // printf("parse success");
        }
        // check position ok: if not, correct it
        if(canCorrect){
            
        }
        // return
        if (!isParseCorrect) {
            printf("error parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }
    
    /////////////////////////////////////////////////////////////////////////////////////
    //////////////////// Convert ///////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    
    int32_t Position::getByteSize()
    {
        int32_t ret = 0;
        {
            // int32_t Board[46];
            ret+= 46*sizeof(int32_t);
            // uint32_t num_wpieces = 0;
            ret+= sizeof(uint32_t);
            // uint32_t num_bpieces = 0;
            ret+= sizeof(uint32_t);
            // int32_t Color = WHITE;
            ret+= sizeof(int32_t);
            // int32_t g_root_mb = 0;
            ret+= sizeof(int32_t);
            // int32_t realdepth = 0;
            ret+= sizeof(int32_t);
            // U64 RepNum[MAXDEPTH];
            ret+= MAXDEPTH*sizeof(U64);
            // U64 HASH_KEY = 0;
            ret+= sizeof(U64);
            // uint32_t p_list[3][16];
            ret+= 3*16*sizeof(uint32_t);
            // uint32_t indices[41];
            ret+= 41*sizeof(uint32_t);
            // int32_t g_pieces[11];
            ret+= 11*sizeof(int32_t);
            // bool Reversible[MAXDEPTH+1];
            ret+= (MAXDEPTH+1)*sizeof(bool);
            // uint32_t c_num[MAXDEPTH+1][16];
            ret+= (MAXDEPTH+1)*16*sizeof(uint32_t);
        }
        // printf("Position: getByteSize: %d\n", ret);
        return ret;
    }
    
    int32_t Position::convertToByteArray(Position* position, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = position->getByteSize();
        uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // int32_t Board[46];
            {
                int32_t size = 46*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->Board, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: Board: %d, %d\n", pointerIndex, length);
                }
            }
            // uint32_t num_wpieces = 0;
            {
                int32_t size = sizeof(uint32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->num_wpieces, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: num_wpieces: %d, %d\n", pointerIndex, length);
                }
            }
            // uint32_t num_bpieces = 0;
            {
                int32_t size = sizeof(uint32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->num_bpieces, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: num_bpieces: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t Color = WHITE;
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->Color, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: Color: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t g_root_mb = 0;
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->g_root_mb, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: g_root_mb: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t realdepth = 0;
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->realdepth, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: realdepth: %d, %d\n", pointerIndex, length);
                }
            }
            // U64 RepNum[MAXDEPTH];
            {
                int32_t size = MAXDEPTH*sizeof(U64);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->RepNum, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: RepNum: %d, %d\n", pointerIndex, length);
                }
            }
            // U64 HASH_KEY = 0;
            {
                int32_t size = sizeof(U64);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->HASH_KEY, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: HASH_KEY: %d, %d\n", pointerIndex, length);
                }
            }
            // uint32_t p_list[3][16];
            {
                int32_t size = 3*16*sizeof(uint32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->p_list, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: p_list: %d, %d\n", pointerIndex, length);
                }
            }
            // uint32_t indices[41];
            {
                int32_t size = 41*sizeof(uint32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->indices, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: indices: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t g_pieces[11];
            {
                int32_t size = 11*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->g_pieces, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: g_pieces: %d, %d\n", pointerIndex, length);
                }
            }
            // bool Reversible[MAXDEPTH+1];
            {
                int32_t size = (MAXDEPTH+1)*sizeof(bool);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->Reversible, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: Reversible: %d, %d\n", pointerIndex, length);
                }
            }
            // uint32_t c_num[MAXDEPTH+1][16];
            {
                int32_t size = (MAXDEPTH+1)*16*sizeof(uint32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->c_num, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: c_num: %d, %d\n", pointerIndex, length);
                }
            }
            // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
        }
        byteArray = ret;
        return length;
    }
    
    int32_t Position::parseByteArray(Position* position, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                {
                    // int32_t Board[46];
                    int32_t size = 46*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(position->Board, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: Board: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                {
                    // uint32_t num_wpieces = 0;
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->num_wpieces, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: num_wpieces: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                {
                    // uint32_t num_bpieces = 0;
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->num_bpieces, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: num_bpieces: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 3:
                {
                    // int32_t Color = WHITE;
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->Color, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: Color: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 4:
                {
                    // int32_t g_root_mb = 0;
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->g_root_mb, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: g_root_mb: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 5:
                {
                    // int32_t realdepth = 0;
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->realdepth, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: realdepth: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 6:
                {
                    // U64 RepNum[MAXDEPTH];
                    int32_t size = MAXDEPTH*sizeof(U64);
                    if(pointerIndex+size<=length){
                        memcpy(position->RepNum, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: RepNumb: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 7:
                {
                    // U64 HASH_KEY = 0;
                    int32_t size = sizeof(U64);
                    if(pointerIndex+size<=length){
                        memcpy(&position->HASH_KEY, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: HASH_KEY: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 8:
                {
                    // uint32_t p_list[3][16];
                    int32_t size = 3*16*sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        memcpy(position->p_list, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: p_list: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 9:
                {
                    // uint32_t indices[41];
                    int32_t size = 41*sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        memcpy(position->indices, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: indices: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 10:
                {
                    // int32_t g_pieces[11];
                    int32_t size = 11*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(position->g_pieces, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: g_pieces: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 11:
                {
                    // bool Reversible[MAXDEPTH+1];
                    int32_t size = (MAXDEPTH+1)*sizeof(bool);
                    if(pointerIndex+size<=length){
                        memcpy(position->Reversible, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: Reversible: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 12:
                {
                    // uint32_t c_num[MAXDEPTH+1][16];
                    int32_t size = (MAXDEPTH+1)*16*sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        memcpy(position->c_num, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: c_num: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                default:
                {
                    // printf("unknown index: %d\n", index);
                    alreadyPassAll = true;
                }
                    break;
            }
            // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
            index++;
            if (!isParseCorrect) {
                printf("not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // return
        if (!isParseCorrect) {
            printf("parse fail\n");
        } else {
            // printf("parse success");
        }
        // check position ok: if not, correct it
        if(canCorrect){

        }
        // return
        if (!isParseCorrect) {
            printf("error parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }
    
}
