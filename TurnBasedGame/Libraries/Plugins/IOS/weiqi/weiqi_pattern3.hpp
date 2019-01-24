//
//  pattern3.hpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_pattern3_hpp
#define weiqi_pattern3_hpp

#include <stdio.h>
#include "weiqi_board.hpp"
#include "weiqi_move.hpp"

namespace weiqi
{
    
    void p3hashes_init(void);
    
    /* hash3_t pattern: ignore middle point, 2 bits per intersection (color)
     * plus 1 bit per each direct neighbor => 8*2 + 4 bits. Bitmap point order:
     * 7 6 5    b
     * 4   3  a   9
     * 2 1 0    8   */
    /* Value bit 0: black pattern; bit 1: white pattern */
    
    /* XXX: See <board.h> for hash3_t typedef. */
    
    struct pattern2p {
        hash3_t pattern;
        unsigned char value;
    };
    
    struct pattern3s {
        /* In case of a collision, following hash entries are
         * used. value==0 indicates an unoccupied hash entry. */
        /* The hash indices are zobrist hashes based on p3hashes. */
#define pattern3_hash_bits 19
#define pattern3_hash_size (1 << pattern3_hash_bits)
#define pattern3_hash_mask (pattern3_hash_size - 1)
        struct pattern2p hash[pattern3_hash_size];
    };
    
    /* Zobrist hashes for the various 3x3 points. */
    /* [point][is_atari][color] */
    extern hash_t p3hashes[8][2][S_MAX];
    
    /* Source pattern encoding:
     * X: black;  O: white;  .: empty;  #: edge
     * x: !black; o: !white; ?: any
     *
     * |/=: black in atari/anything but black in atari
     * @/0: white in atari
     * Y/y: black notin atari; Q/q: white notin atari
     *
     * extra X: pattern valid only for one side;
     * middle point ignored. */
    
    void pattern3s_init(struct pattern3s *p, char src[][11], int32_t src_n);
    
    /* Compute pattern3 hash at local position. */
    // bo static
    inline hash3_t pattern3_hash(struct board *b, coord_t c)
    {
        hash3_t pat = 0;
        board_statics* board_statics = &b->board_statics;
        int32_t x = coord_x(board_statics, c, b);
        int32_t y = coord_y(board_statics, c, b);
        /* Stone info. */
        pat |= (board_atxy(b, x - 1, y - 1) << 14)
        | (board_atxy(b, x, y - 1) << 12)
        | (board_atxy(b, x + 1, y - 1) << 10);
        pat |= (board_atxy(b, x - 1, y) << 8)
        | (board_atxy(b, x + 1, y) << 6);
        pat |= (board_atxy(b, x - 1, y + 1) << 4)
        | (board_atxy(b, x, y + 1) << 2)
        | (board_atxy(b, x + 1, y + 1));
        /* Atari info. */
#define atari_atxy(b, x, y) (group_atxy(b, x, y) && board_group_info(b, group_atxy(b, x, y)).libs == 1)
        pat |= (atari_atxy(b, x, y - 1) << 19);
        pat |= (atari_atxy(b, x - 1, y) << 18)
        | (atari_atxy(b, x + 1, y) << 17);
        pat |= (atari_atxy(b, x, y + 1) << 16);
#undef atari_atxy
        return pat;
    }
    
    // bo static
#ifdef _MSC_VER
    inline hash_t hash3_to_hash(hash3_t pat)
#else
    inline __attribute__((const)) hash_t hash3_to_hash(hash3_t pat)
#endif
    {
        hash_t h = 0;
        // tam bo static
        const int32_t ataribits[8] = { -1, 0, -1, 1, 2, -1, 3, -1 };
        for (int32_t i = 0; i < 8; i++) {
            h ^= p3hashes[i][ataribits[i] >= 0 ? (pat >> (16 + ataribits[i])) & 1 : 0][(pat >> (i*2)) & 3];
        }
        return h;
    }
    
    /* Check if we match any 3x3 pattern centered on given move. */
    // bo static
    inline bool pattern3_move_here(struct pattern3s *p, struct board *b, struct move *m, char *idx)
    {
#ifdef BOARD_PAT3
        hash3_t pat = b->pat3[m->coord];
#else
        hash3_t pat = pattern3_hash(b, m->coord);
#endif
        hash_t h = hash3_to_hash(pat);
        while (p->hash[h & pattern3_hash_mask].pattern != pat
               && p->hash[h & pattern3_hash_mask].value != 0)
            h++;
        if (p->hash[h & pattern3_hash_mask].value & m->color) {
            *idx = p->hash[h & pattern3_hash_mask].value >> 2;
            return true;
        } else {
            return false;
        }
    }
    
    /* Generate all transpositions of given pattern, stored in an
     * hash3_t[8] array. */
    void pattern3_transpose(hash3_t pat, hash3_t (*transp)[8]);
    
    /* Reverse pattern to opposite color assignment. */
    // bo static
    inline hash3_t pattern3_reverse(hash3_t pat)
    {
        /* Reverse color assignment - achieved by swapping odd and even bits */
        return ((pat >> 1) & 0x5555) | ((pat & 0x5555) << 1) | (pat & 0xf0000);
    }
}

#endif /* pattern3_hpp */
