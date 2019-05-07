//
//  board.hpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_board_hpp
#define weiqi_board_hpp

#include <stdio.h>
#include <inttypes.h>
#include <stdbool.h>
#include <stdint.h>
#include <stdlib.h>

#include "../Platform.h"
#include "weiqi_util.hpp"
#include "weiqi_stone.hpp"
#include "weiqi_move.hpp"
#include "playout/weiqi_moggy.hpp"

namespace weiqi
{
    /* Maximum supported board size. (Without the S_OFFBOARD edges.) */
#define BOARD_MAX_SIZE 19
    
    
    /* The board implementation has bunch of optional features.
     * Turn them on below: */
    
#define WANT_BOARD_C // capturable groups queue
    
    //#define BOARD_SIZE 9 // constant board size, allows better optimization
    
#define BOARD_PAT3 // incremental 3x3 pattern codes
    
#define BOARD_UNDO_CHECKS 1  // Guard against invalid quick_play() / quick_undo() uses
    
#define BOARD_MAX_COORDS  ((BOARD_MAX_SIZE+2) * (BOARD_MAX_SIZE+2))
#define BOARD_MAX_MOVES (BOARD_MAX_SIZE * BOARD_MAX_SIZE)
#define BOARD_MAX_GROUPS (BOARD_MAX_SIZE * BOARD_MAX_SIZE * 2 / 3)
    /* For 19x19, max 19*2*6 = 228 groups (stacking b&w stones, each third line empty) */
    
    enum e_sym {
        SYM_FULL,
        SYM_DIAG_UP,
        SYM_DIAG_DOWN,
        SYM_HORIZ,
        SYM_VERT,
        SYM_NONE
    };
    
    
    /* Some engines might normalize their reading and skip symmetrical
     * moves. We will tell them how can they do it. */
    struct board_symmetry {
        /* Playground is in this rectangle. */
        int32_t x1, x2, y1, y2;
        /* d ==  0: Full rectangle
         * d ==  1: Top triangle */
        int32_t d;
        /* General symmetry type. */
        /* Note that the above is redundant to this, but just provided
         * for easier usage. */
        enum e_sym type;
        
    public:
        inline static int32_t getByteSize()
        {
            int32_t ret = 0;
            {
                // int32_t x1, x2, y1, y2;
                ret+=4*sizeof(int32_t);
                // int32_t d;
                ret+=sizeof(int32_t);
                // enum e_sym type;
                ret+=sizeof(int32_t);
            }
            return ret;
        }
        
        static int32_t convertToByteArray(struct board_symmetry* board_symmetry, uint8_t* &byteArray)
        {
            // find length of return
            int32_t length = board_symmetry::getByteSize();
            byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
            {
                int32_t pointerIndex = 0;
                // convert properties
                {
                    // int32_t x1;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            int32_t value = board_symmetry->x1;
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: x1: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // int32_t x2;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            int32_t value = board_symmetry->x2;
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: x2: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // int32_t y1;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            int32_t value = board_symmetry->y1;
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: y1: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // int32_t y2;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            int32_t value = board_symmetry->y2;
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: y2: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // int32_t d;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            int32_t value = board_symmetry->d;
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: d: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // enum e_sym type;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            int32_t value = board_symmetry->type;
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: type: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
                // check convert correct
                if(pointerIndex!=length){
                    printf("error: convert not correct: %d; %d\n", pointerIndex, length);
                }else{
                    // printf("convert byte array correct\n");
                }
            }
            return length;
        }
        
        static int32_t parseByteArray(struct board_symmetry* board_symmetry, uint8_t* positionBytes, int32_t length, int32_t start)
        {
            int32_t pointerIndex = start;
            int32_t index = 0;
            bool isParseCorrect = true;
            while (pointerIndex < length) {
                bool alreadyPassAll = false;
                switch (index) {
                    case 0:
                        // int32_t x1;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&board_symmetry->x1, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: x1: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 1:
                        // int32_t x2;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&board_symmetry->x2, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: x2: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 2:
                        // int32_t y1;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&board_symmetry->y1, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: y1: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 3:
                        // int32_t y2;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&board_symmetry->y2, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: y1: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 4:
                        // int32_t d;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&board_symmetry->d, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: d: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 5:
                        // enum e_sym type;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            int32_t value = 0;
                            memcpy(&value, positionBytes + pointerIndex, size);
                            board_symmetry->type = (e_sym)value;
                            pointerIndex+=size;
                        }else{
                            printf("length error: type: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    default:
                    {
                        alreadyPassAll = true;
                    }
                        break;
                }
                // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
                index++;
                if (!isParseCorrect) {
                    printf("error, not parse correct\n");
                    break;
                }
                if (alreadyPassAll) {
                    break;
                }
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
    };
    
    
    typedef uint64_t hash_t;
#define PRIhash PRIx64
    
    /* XXX: This really belongs in pattern3.h, unfortunately that would mean
     * a dependency hell. */
    typedef uint32_t hash3_t; // 3x3 pattern hash
    
    
    /* Note that "group" is only chain of stones that is solidly
     * connected for us. */
    typedef coord_t group_t;
    
    struct group {
        /* We keep track of only up to GROUP_KEEP_LIBS; over that, we
         * don't care. */
        /* _Combination_ of these two values can make some difference
         * in performance - fine-tune. */
#define GROUP_KEEP_LIBS 10
        // refill lib[] only when we hit this; this must be at least 2!
        // Moggy requires at least 3 - see below for semantic impact.
#define GROUP_REFILL_LIBS 5
        coord_t lib[GROUP_KEEP_LIBS];
        /* libs is only LOWER BOUND for the number of real liberties!!!
         * It denotes only number of items in lib[], thus you can rely
         * on it to store real liberties only up to <= GROUP_REFILL_LIBS. */
        int32_t libs;
        
    public:
        inline static int32_t getByteSize()
        {
            int32_t ret = 0;
            {
                // coord_t lib[GROUP_KEEP_LIBS];
                ret+=sizeof(int32_t)*GROUP_KEEP_LIBS;
                // int32_t libs;
                ret+=sizeof(int32_t);
            }
            return ret;
        }
        
        static int32_t convertToByteArray(struct group* group, uint8_t* &byteArray)
        {
            // find length of return
            int32_t length = group::getByteSize();
            byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
            {
                int32_t pointerIndex = 0;
                // convert property
                {
                    // coord_t lib[GROUP_KEEP_LIBS];
                    {
                        int32_t size = sizeof(int32_t);
                        for(int32_t i=0; i<GROUP_KEEP_LIBS; i++){
                            if(pointerIndex+size<=length){
                                int32_t value = group->lib[i];
                                memcpy(byteArray + pointerIndex, &value, size);
                                pointerIndex+=size;
                            }else{
                                printf("length error: lib: %d, %d\n", pointerIndex, length);
                            }
                        }
                    }
                    // int32_t libs;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            int32_t value = group->libs;
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: libs: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
                // check convert correct
                if(pointerIndex!=length){
                    printf("error: convert not correct: %d; %d\n", pointerIndex, length);
                }else{
                    // printf("convert byte array correct\n");
                }
            }
            return length;
        }
        
        static int32_t parseByteArray(struct group* group, uint8_t* positionBytes, int32_t length, int32_t start)
        {
            int32_t pointerIndex = start;
            int32_t index = 0;
            bool isParseCorrect = true;
            while (pointerIndex < length) {
                bool alreadyPassAll = false;
                switch (index) {
                    case 0:
                        // coord_t lib[GROUP_KEEP_LIBS];
                    {
                        int32_t size = sizeof(int32_t);
                        for(int32_t i=0; i<GROUP_KEEP_LIBS; i++){
                            if(pointerIndex+size<=length){
                                memcpy(&group->lib[i], positionBytes + pointerIndex, size);
                                pointerIndex+=size;
                            }else{
                                printf("length error: lib: %d, %d\n", pointerIndex, length);
                                isParseCorrect = false;
                            }
                        }
                    }
                        break;
                    case 1:
                        // int32_t libs;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&group->libs, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: libs: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    default:
                    {
                        alreadyPassAll = true;
                    }
                        break;
                }
                // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
                index++;
                if (!isParseCorrect) {
                    printf("error, not parse correct\n");
                    break;
                }
                if (alreadyPassAll) {
                    break;
                }
            }
            // return
            if (!isParseCorrect) {
                printf("error parse fail: %d; %d; %d\n", pointerIndex, length, start);
                return -1;
            } else {
                // printf(*"parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
                return (pointerIndex - start);
            }
        }
    };
    
    struct neighbor_colors {
        char colors[S_MAX];
        
    public:
        inline static int32_t getByteSize()
        {
            return sizeof(char)*S_MAX;
        }
    };
    
    
    /* Quick hack to help ensure tactics code stays within quick board limitations.
     * Ideally we'd have two different types for boards and quick_boards. The idea
     * of having casts / duplicate api all over the place isn't so appealing though... */
#ifndef QUICK_BOARD_CODE
#define FB_ONLY(field)  field
#else
#define FB_ONLY(field)  field ## _disabled
    // Try to make error messages more helpful ...
#define clen clen_field_not_supported_for_quick_boards
#define flen flen_field_not_supported_for_quick_boards
#endif
    
    /* The ruleset is currently almost never taken into account;
     * the board implementation is basically Chinese rules (handicap
     * stones compensation) w/ suicide (or you can look at it as
     * New Zealand w/o handi stones compensation), while the engine
     * enforces no-suicide, making for real Chinese rules.
     * However, we accept suicide moves by the opponent, so we
     * should work with rules allowing suicide, just not taking
     * full advantage of them. */
    enum go_ruleset {
        RULES_CHINESE, /* default value */
        RULES_AGA,
        RULES_NEW_ZEALAND,
        RULES_JAPANESE,
        RULES_STONES_ONLY, /* do not count eyes */
        /* http://home.snafu.de/jasiek/siming.html */
        /* Simplified ING rules - RULES_CHINESE with handicaps
         * counting as points and pass stones. Also should
         * allow suicide, but Pachi will never suicide
         * nevertheless. */
        /* XXX: I couldn't find the point about pass stones
         * in the rule text, but it is Robert Jasiek's
         * interpretation of them... These rules were
         * used e.g. at the EGC2012 13x13 tournament.
         * They are not supported by KGS. */
        RULES_SIMING,
    };
    
    /* Data shared by all boards of a given size */
    struct board_statics {
        int32_t size;
        
        /* Iterator offsets for foreach_neighbor*() */
        int32_t nei8[8];
        int32_t dnei[4];
        
        /* Coordinates zobrist hashes (black and white) */
        hash_t h[BOARD_MAX_COORDS][2];
        
        /* Cached information on x-y coordinates so that we avoid division. */
        uint8_t coord[BOARD_MAX_COORDS][2];
        
    public:
        static int32_t getByteSize()
        {
            int32_t ret = 0;
            {
                // int32_t size;
                ret+=sizeof(int32_t);
                // int32_t nei8[8];
                ret+=sizeof(int32_t)*8;
                // int32_t dnei[4];
                ret+=sizeof(int32_t)*4;
                // hash_t h[BOARD_MAX_COORDS][2]
                ret+=sizeof(hash_t)*BOARD_MAX_COORDS*2;
                // uint8_t coord[BOARD_MAX_COORDS][2]
                ret+=sizeof(uint8_t)*BOARD_MAX_COORDS*2;
            }
            return ret;
        }
        
        static int32_t convertToByteArray(struct board_statics* board_statics, uint8_t* &byteArray);
        
        static int32_t parseByteArray(struct board_statics* board_statics, uint8_t* positionBytes, int32_t length, int32_t start);
    };
    
    /* Per simulation state (moggy_policy is shared by all threads) */
    struct moggy_state {
        /* Selfatari move rejected by permit() during the last move(s).
         * Logic may not kick in immediately so we have room for both colors. */
        coord_t last_selfatari[S_MAX];
    };
    
    /* You should treat this struct as read-only. Always call functions below if
     * you want to change it. */
    
    struct board {
        int32_t size; /* Including S_OFFBOARD margin - see below. */
        int32_t size2; /* size^2 */
        int32_t bits2; /* ceiling(log2(size2)) */
        int32_t captures[S_MAX];
        floating_t komi;
        int32_t handicap;
        enum go_ruleset rules;
        char *fbookfile;
        struct fbook *fbook = NULL;

        int32_t moves;
        struct move last_move;
        struct move last_move2; /* second-to-last move */
        FB_ONLY(struct move last_move3); /* just before last_move2, only set if last_move is pass */
        FB_ONLY(struct move last_move4); /* just before last_move3, only set if last_move & last_move2 are pass */
        /* Whether we tried to add a hash twice; board_play*() can
         * set this, but it will still carry out the move as well! */
        FB_ONLY(bool superko_violation);
        
        /* The following two structures are goban maps and are indexed by
         * coord.pos. The map is surrounded by a one-point margin from
         * S_OFFBOARD stones in order to speed up some internal loops.
         * Some of the foreach iterators below might include these points;
         * you need to handle them yourselves, if you need to. */
        
        /* Stones played on the board */
        enum stone b[BOARD_MAX_COORDS];
        /* Group id the stones are part of; 0 == no group */
        group_t g[BOARD_MAX_COORDS];
        /* Positions of next stones in the stone group; 0 == last stone */
        coord_t p[BOARD_MAX_COORDS];
        /* Neighboring colors; numbers of neighbors of index color */
        struct neighbor_colors n[BOARD_MAX_COORDS];
        
#ifdef BOARD_PAT3
        /* 3x3 pattern code for each position; see pattern3.h for encoding
         * specification. The information is only valid for empty points. */
        FB_ONLY(hash3_t pat3)[BOARD_MAX_COORDS];
#endif
        
        /* Group information - indexed by gid (which is coord of base group stone) */
        struct group gi[BOARD_MAX_COORDS];
        
        /* List of free positions */
        /* Note that free position here is any valid move; including single-point eyes!
         * However, pass is not included. */
        FB_ONLY(coord_t f)[BOARD_MAX_COORDS];
        FB_ONLY(int32_t flen);
        /* Map free positions coords to their list index, for quick lookup. */
        FB_ONLY(int32_t fmap)[BOARD_MAX_COORDS];
        
#ifdef WANT_BOARD_C
        /* Queue of capturable groups */
        FB_ONLY(group_t c)[BOARD_MAX_GROUPS];
        FB_ONLY(int32_t clen);
#endif
        
        /* Symmetry information */
        FB_ONLY(struct board_symmetry symmetry);
        
        /* Last ko played on the board. */
        FB_ONLY(struct move last_ko);
        FB_ONLY(int32_t last_ko_age);
        
        /* Basic ko check */
        struct move ko;
        
#ifdef BOARD_UNDO_CHECKS
        /* Guard against invalid quick_play() / quick_undo() uses */
        int32_t quicked;
#endif
        
        /* Engine-specific state; persistent through board development,
         * is reset only at clear_board. */
        void *es;
        
        /* Playout-specific state; persistent through board development,
         * initialized by play_random_game() and free()'d at board destroy time */
        // ban dau la void
        struct moggy_state ps;// = NULL;
        
        
        /* --- PRIVATE DATA --- */
        
        /* For superko check: */
        
        /* Board "history" - hashes encountered. Size of the hash should be
         * >> board_size^2. */
#define history_hash_bits 12
#define history_hash_mask ((1 << history_hash_bits) - 1)
#define history_hash_prev(i) ((i - 1) & history_hash_mask)
#define history_hash_next(i) ((i + 1) & history_hash_mask)
        FB_ONLY(hash_t history_hash)[1 << history_hash_bits];
        /* Hash of current board position. */
        FB_ONLY(hash_t hash);
        /* Hash of current board position quadrants. */
        FB_ONLY(hash_t qhash)[4];
        
        // TODO them vao
        struct board_statics board_statics;
        // cho vao o ladder.cpp
        int32_t length = 0;
    public:
        int32_t getByteSize();
        
        static int32_t convertToByteArray(struct board* board, uint8_t* &byteArray);
        
        static int32_t parseByteArray(struct board* position, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect);
    };
    
    struct undo_merge {
        group_t	     group;
        coord_t	     last;
        struct group info;
    };
    
    struct undo_enemy {
        group_t      group;
        struct group info;
        coord_t      stones[BOARD_MAX_MOVES];  // TODO try small array
    };
    
    struct board_undo {
        struct move last_move2;
        struct move ko;
        struct move last_ko;
        int32_t	    last_ko_age;
        
        coord_t next_at;
        
        coord_t	inserted;
        struct undo_merge merged[4];
        int32_t nmerged;
        int32_t nmerged_tmp;
        
        struct undo_enemy enemies[4];
        int32_t nenemies;
        int32_t captures; /* number of stones captured */
    };
    
    
#ifdef BOARD_SIZE
    /* Avoid unused variable warnings */
#define board_size(b_) (((b_) == (b_)) ? BOARD_SIZE + 2 : 0)
#define board_size2(b_) (board_size(b_) * board_size(b_))
#define real_board_size(b_)  (((b_) == (b_)) ? BOARD_SIZE : 0)
#else
#define board_size(b_) ((b_)->size)
#define board_size2(b_) ((b_)->size2)
#define real_board_size(b_) ((b_)->size - 2)
#endif
    
    /* This is a shortcut for taking different action on smaller
     * and large boards (e.g. picking different variable defaults).
     * This is of course less optimal than fine-tuning dependency
     * function of values on board size, but that is difficult and
     * possibly not very rewarding if you are interested just in
     * 9x9 and 19x19. */
#define board_large(b_) (board_size(b_)-2 >= 15)
#define board_small(b_) (board_size(b_)-2 <= 9)
    
#if BOARD_SIZE == 19
#  define board_bits2(b_) 9
#elif BOARD_SIZE == 13
#  define board_bits2(b_) 8
#elif BOARD_SIZE == 9
#  define board_bits2(b_) 7
#else
#  define board_bits2(b_) ((b_)->bits2)
#endif
    
// #define board_at(b_, c) ((b_)->b[c])
    enum stone board_at(struct board *b, coord_t c);
    
    void board_set(struct board *b, coord_t c, enum stone stone);
    
// #define board_atxy(b_, x, y) ((b_)->b[(x) + board_size(b_) * (y)])
    enum stone board_atxy(struct board *b, int x, int y);
    
// #define group_at(b_, c) ((b_)->g[c])
    group_t group_at(struct board *b, coord_t c);
    
    void group_set(struct board *b, coord_t c, group_t group);
    
// #define group_atxy(b_, x, y) ((b_)->g[(x) + board_size(b_) * (y)])
    group_t group_atxy(struct board *b, int x, int y);
    
    /* Warning! Neighbor count is not kept up-to-date for S_NONE! */
// #define neighbor_count_at(b_, coord, color) ((b_)->n[coord].colors[(enum stone) color])
    char neighbor_count_at(struct board *b_, coord_t coord, enum stone color);
    
// #define set_neighbor_count_at(b_, coord, color, count) (neighbor_count_at(b_, coord, color) = (count))
    void set_neighbor_count_at(struct board *b_, coord_t coord, enum stone color, char count);
    
// #define inc_neighbor_count_at(b_, coord, color) (neighbor_count_at(b_, coord, color)++)
    void inc_neighbor_count_at(struct board *b_, coord_t coord, enum stone color);
    
// #define dec_neighbor_count_at(b_, coord, color) (neighbor_count_at(b_, coord, color)--)
    void dec_neighbor_count_at(struct board *b_, coord_t coord, enum stone color);
    
#define immediate_liberty_count(b_, coord) (4 - neighbor_count_at(b_, coord, S_BLACK) - neighbor_count_at(b_, coord, S_WHITE) - neighbor_count_at(b_, coord, S_OFFBOARD))
    
// #define trait_at(b_, coord, color) (b_)->t[coord][(color) - 1]
    
// #define groupnext_at(b_, c) ((b_)->p[c])
    coord_t groupnext_at(struct board *b_, coord_t c);
    void groupnext_set(struct board *b_, coord_t c, coord_t nextCoord);
    
// #define groupnext_atxy(b_, x, y) ((b_)->p[(x) + board_size(b_) * (y)])
    coord_t groupnext_atxy(struct board *b_, int32_t x, int32_t y);
    
#define group_base(g_) (g_)
#define group_is_onestone(b_, g_) (groupnext_at(b_, group_base(g_)) == 0)

    
// #define board_group_info(b_, g_) ((b_)->gi[(g_)])
    struct group* board_group_info(struct board *b_, group_t g_);
    
#define board_group_captured(b_, g_) (board_group_info(b_, g_)->libs == 0)
    /* board_group_other_lib() makes sense only for groups with two liberties. */
#define board_group_other_lib(b_, g_, l_) (board_group_info(b_, g_)->lib[board_group_info(b_, g_)->lib[0] != (l_) ? 0 : 1])
    
// #define hash_at(board_statics, b_, coord, color) (board_statics->h[coord][((color) == S_BLACK ? 1 : 0)])
    hash_t hash_at(board_statics* board_statics, struct board *board, coord_t coord, enum stone color);
    
    void board_init(struct board* b, char *fbookfile);
    struct board *board_copy(struct board *board2, struct board *board1);
    void board_done_noalloc(struct board *board);
    void board_done(struct board *board);
    /* size here is without the S_OFFBOARD margin. */
    void board_resize(struct board *board, int32_t size);
    void board_clear(struct board *board);
    
    typedef void  (*board_cprint)(struct board *b, coord_t c, strbuf_t *buf, void *data);
    typedef char *(*board_print_handler)(struct board *b, coord_t c, void *data, char* buf);
    void board_print(struct board *board, FILE* f);
    void board_print_custom(struct board *board, FILE* f, board_cprint cprint, void *data);
    // void board_hprint(struct board *board, FILE *f, board_print_handler handler, void *data);
    
    typedef void (*my_board_cprint)(struct board *b, coord_t c, char* f, void *data);
    void board_print(struct board *board, char* f);
    void board_print_custom(struct board *board, char* f, my_board_cprint cprint, void *data);
    void board_hprint(struct board *board, char *f, board_print_handler handler, void *data, char* buf);
    
    /* Debugging: Compare 2 boards byte by byte. Don't use that for sorting =) */
    int32_t board_cmp(struct board *b1, struct board *b2);
    /* Same but only care about fields maintained by quick_play() / quick_undo() */
    int32_t board_quick_cmp(struct board *b1, struct board *b2);
    
    /* Place given handicap on the board; coordinates are printed to f. */
    void board_handicap(struct board *board, int32_t stones, FILE *f);
    
    /* Returns group id, 0 on allowed suicide, pass or resign, -1 on error */
    int32_t board_play(struct board *board, struct move *m);
    /* Like above, but plays random move; the move coordinate is recorded
     * to *coord. This method will never fill your own eye. pass is played
     * when no move can be played. You can impose extra restrictions if you
     * supply your own permit function; the permit function can also modify
     * the move coordinate to redirect the move elsewhere. */
    typedef bool (*ppr_permit)(struct board *b, struct move *m, void *data);
    bool board_permit(struct board *b, struct move *m, void *data);
    void board_play_random(struct board *b, enum stone color, coord_t *coord, ppr_permit permit, void *permit_data);
    
    /* Undo, supported only for pass moves. Returns -1 on error, 0 otherwise. */
    int32_t board_undo(struct board *board);
    
    /* Returns true if given move can be played. */
    bool board_is_valid_play(struct board *b, enum stone color, coord_t coord);// bo static
    bool board_is_valid_move(struct board *b, struct move *m);// bo static
    /* Returns true if ko was just taken. */
    bool board_playing_ko_threat(struct board *b);// bo static
    /* Returns 0 or ID of neighboring group in atari. */
    group_t board_get_atari_neighbor(struct board *b, coord_t coord, enum stone group_color);// bo static
    /* Returns true if the move is not obvious self-atari. */
    bool board_safe_to_play(struct board *b, coord_t coord, enum stone color);// bo static
    
    /* Determine number of stones in a group, up to @max stones. */
    int32_t group_stone_count(struct board *b, group_t group, int32_t max);// bo static
    
#ifndef QUICK_BOARD_CODE
    /* Adjust symmetry information as if given coordinate has been played. */
    void board_symmetry_update(struct board *b, struct board_symmetry *symmetry, coord_t c);
    /* Check if coordinates are within symmetry base. (If false, they can
     * be derived from the base.) */
    bool board_coord_in_symmetry(struct board *b, coord_t c);// bo static
#endif
    
    /* Returns true if given coordinate has all neighbors of given color or the edge. */
    bool board_is_eyelike(struct board *board, coord_t coord, enum stone eye_color);// bo static
    /* Returns true if given coordinate could be a false eye; this check makes
     * sense only if you already know the coordinate is_eyelike(). */
    bool board_is_false_eyelike(struct board *board, coord_t coord, enum stone eye_color);
    /* Returns true if given coordinate is a 1-pt eye (checks against false eyes, or
     * at least tries to). */
    bool board_is_one_point_eye(struct board *board, coord_t c, enum stone eye_color);
    /* Returns color of a 1pt eye owner, S_NONE if not an eye. */
    enum stone board_get_one_point_eye(struct board *board, coord_t c);
    
    /* board_official_score() is the scoring method for yielding score suitable
     * for external presentation. For fast scoring of entirely filled boards
     * (e.g. playouts), use board_fast_score(). */
    /* Positive: W wins */
    /* Compare number of stones + 1pt eyes. */
    floating_t board_fast_score(struct board *board);
    /* Tromp-Taylor scoring, assuming given groups are actually dead. */
    struct move_queue;
    floating_t board_official_score(struct board *board, struct move_queue *mq);
    floating_t board_official_score_and_dame(struct board *board, struct move_queue *mq, int32_t *dame);
    
    void my_board_official_score_and_dame(struct Position* pos, struct move_queue *q);
    
    /* Set board rules according to given string. Returns false in case
     * of unknown ruleset name. */
    bool board_set_rules(struct board *board, char *name);
    
    /* Quick play/undo to try out a move.
     * WARNING  Only core board structures are maintained !
     *          Code in between can't rely on anything else.
     *
     * Currently this means these can't be used:
     *   - incremental patterns (pat3)
     *   - hashes, superko_violation (spathash, hash, qhash, history_hash)
     *   - list of free positions (f / flen)
     *   - list of capturable groups (c / clen)
     *   - traits (btraits, t, tq, tqlen)
     *   - last_move3, last_move4, last_ko_age
     *   - symmetry information
     *
     * #define QUICK_BOARD_CODE at the top of your file to get compile-time
     * error if you try to access a forbidden field.
     *
     * Invalid quick_play()/quick_undo() combinations (missing undo for example)
     * are caught at next board_play() if BOARD_UNDO_CHECKS is defined.
     */
    int32_t  board_quick_play(struct board *board, struct move *m, struct board_undo *u);
    void board_quick_undo(struct board *b, struct move *m, struct board_undo *u);
    
    /* quick_play() + quick_undo() combo.
     * Body is executed only if move is valid (silently ignored otherwise).
     * Can break out in body, but definitely *NOT* return / jump around !
     * (caught at run time if BOARD_UNDO_CHECKS defined). Can use
     * with_move_return(val) to return value for non-nested with_move()'s
     * though. */
#define with_move(board_, coord_, color_, body_) \
do { \
struct board *board__ = (board_);  /* For with_move_return() */		\
struct move m_; m_.coord = (coord_); m_.color = (color_); \
struct board_undo u_; \
if (board_quick_play(board__, &m_, &u_) >= 0) {	  \
do { body_ } while(0);                     \
board_quick_undo(board__, &m_, &u_); \
}					   \
} while (0)

/* Return value from within with_move() statement.
 * Valid for non-nested with_move() *ONLY* */

#ifndef Android
#define with_move_return(val_)  \
	do {  typeof(val_) val__ = (val_); board_quick_undo(board__, &m_, &u_); return val__;  } while (0)
#else
#define with_move_return(val_)  \
	do {  typeof(val_) val__ = (val_); board_quick_undo(board__, &m_, &u_); return val__;  } while (0)
#endif
    
    /* Same as with_move() but assert out in case of invalid move. */
#define with_move_strict(board_, coord_, color_, body_) \
do { \
struct board *board__ = (board_);  /* For with_move_return() */		\
struct move m_; m_.coord = (coord_); m_.color = (color_); \
struct board_undo u_; \
assert (board_quick_play(board__, &m_, &u_) >= 0);  \
do { body_ } while(0);                     \
board_quick_undo(board__, &m_, &u_); \
} while (0)
    
    
    /** Iterators */
    
#define foreach_point(board_) \
do { \
coord_t c = 0; \
for (; c < board_size(board_) * board_size(board_); c++)
#define foreach_point_and_pass(board_) \
do { \
coord_t c = pass; \
for (; c < board_size(board_) * board_size(board_); c++)
#define foreach_point_end \
} while (0)
    
#define foreach_free_point(board_) \
do { \
int32_t fmax__ = (board_)->flen; \
for (int32_t f__ = 0; f__ < fmax__; f__++) { \
coord_t c = (board_)->f[f__];
#define foreach_free_point_end \
} \
} while (0)
    
#define foreach_in_group(board_, group_) \
do { \
struct board *board__ = board_; \
coord_t c = group_base(group_); \
coord_t c2 = c; c2 = groupnext_at(board__, c2); \
do {
#define foreach_in_group_end \
c = c2; c2 = groupnext_at(board__, c2); \
} while (c != 0); \
} while (0)
    
    /* NOT VALID inside of foreach_point() or another foreach_neighbor(), or rather
     * on S_OFFBOARD coordinates. */
#define foreach_neighbor(board_, coord_, loop_body) \
do { \
struct board *board__ = board_; \
coord_t coord__ = coord_; \
coord_t c; \
c = coord__ - board_size(board__); do { loop_body } while (0); \
c = coord__ - 1; do { loop_body } while (0); \
c = coord__ + 1; do { loop_body } while (0); \
c = coord__ + board_size(board__); do { loop_body } while (0); \
} while (0)
    
#define foreach_8neighbor(board_statics, board_, coord_) \
do { \
int32_t fn__i; \
coord_t c = (coord_); \
for (fn__i = 0; fn__i < 8; fn__i++) { \
c += board_statics->nei8[fn__i];
#define foreach_8neighbor_end \
} \
} while (0)
    
#define foreach_diag_neighbor(board_statics, board_, coord_) \
do { \
int32_t fn__i; \
coord_t c = (coord_); \
for (fn__i = 0; fn__i < 4; fn__i++) { \
c += board_statics->dnei[fn__i];
#define foreach_diag_neighbor_end \
} \
} while (0)
    
    
    inline bool board_is_eyelike(struct board *board, coord_t coord, enum stone eye_color)
    {
        return (neighbor_count_at(board, coord, eye_color)
                + neighbor_count_at(board, coord, S_OFFBOARD)) == 4;
    }
    
    /* Group suicides allowed */
    inline bool board_is_valid_play(struct board *board, enum stone color, coord_t coord)// bo static
    {
        if (board_at(board, coord) != S_NONE)
            return false;
        if (!board_is_eyelike(board, coord, stone_other(color)))
            return true;
        /* Play within {true,false} eye-ish formation */
        if (board->ko.coord == coord && board->ko.color == color)
            return false;
        int32_t groups_in_atari = 0;
        foreach_neighbor(board, coord, {
            group_t g = group_at(board, c);
            groups_in_atari += (board_group_info(board, g)->libs == 1);
        });
        return !!groups_in_atari;
    }
    
    /* Check group suicides, slower than board_is_valid_play() */
    inline bool board_is_valid_play_no_suicide(struct board *board, enum stone color, coord_t coord)// bo static
    {
        if (board_at(board, coord) != S_NONE)
            return false;
        if (immediate_liberty_count(board, coord) >= 1)
            return true;
        if (board_is_eyelike(board, coord, stone_other(color)) &&
            board->ko.coord == coord && board->ko.color == color)
            return false;
        
        // Capturing something ?
        foreach_neighbor(board, coord, {
            if (board_at(board, c) == stone_other(color) &&
                board_group_info(board, group_at(board, c))->libs == 1)
                return true;
        });
        
        // Neighbour with 2 libs ?
        foreach_neighbor(board, coord, {
            if (board_at(board, c) == color &&
                board_group_info(board, group_at(board, c))->libs > 1)
                return true;
        });
        
        return false;  // Suicide
    }
    
    
    inline bool board_is_valid_move(struct board *board, struct move *m)// bo static
    {
        return board_is_valid_play(board, m->color, m->coord);
    }
    
    inline bool board_playing_ko_threat(struct board *b)// bo static
    {
        return !is_pass(b->ko.coord);
    }
    
    inline group_t board_get_atari_neighbor(struct board *b, coord_t coord, enum stone group_color)
    {
        foreach_neighbor(b, coord, {
            group_t g = group_at(b, c);
            if (g && board_at(b, c) == group_color && board_group_info(b, g)->libs == 1)
                return g;
            /* We return first match. */
        });
        return 0;
    }
    
    inline bool board_safe_to_play(struct board *b, coord_t coord, enum stone color)
    {
        /* number of free neighbors */
        int32_t libs = immediate_liberty_count(b, coord);
        if (libs > 1)
            return true;
        
        /* ok, but we need to check if they don't have just two libs. */
        coord_t onelib = -1;
        foreach_neighbor(b, coord, {
            if (board_at(b, c) == stone_other(color) && board_group_info(b, group_at(b, c))->libs == 1)
                return true; // can capture; no snapback check
            
            if (board_at(b, c) != color) continue;
            group_t g = group_at(b, c);
            if (board_group_info(b, g)->libs == 1) continue; // in atari
            if (board_group_info(b, g)->libs == 2) { // two liberties
                if (libs > 0) return true; // we already have one real liberty
                /* we might be connecting two 2-lib groups, which is ok;
                 * so remember the other liberty and just make sure it's
                 * not the same one */
                if (onelib >= 0 && c != onelib) return true;
                onelib = board_group_other_lib(b, g, c);
                continue;
            }
            // many liberties
            return true;
        });
        // no good support group
        return false;
    }
    
    inline int32_t group_stone_count(struct board *b, group_t group, int32_t max)
    {
        int32_t n = 0;
        foreach_in_group(b, group) {
            n++;
            if (n >= max) return max;
        } foreach_in_group_end;
        return n;
    }
    
#ifndef QUICK_BOARD_CODE
    inline bool board_coord_in_symmetry(struct board *b, coord_t c, struct board_statics* statics)// bo static
    {
        printf("board_coord_in_symmetry\n");
        if (coord_y(statics, c, b) < b->symmetry.y1 || coord_y(statics, c, b) > b->symmetry.y2)
            return false;
        if (coord_x(statics, c, b) < b->symmetry.x1 || coord_x(statics, c, b) > b->symmetry.x2)
            return false;
        if (b->symmetry.d) {
            int32_t x = coord_x(statics, c, b);
            if (b->symmetry.type == SYM_DIAG_DOWN)
                x = board_size(b) - 1 - x;
            if (x > coord_y(statics, c, b))
                return false;
        }
        return true;
        
    }
#endif
    
    void board_statics_init(struct board *board);
}

#endif /* board_hpp */
