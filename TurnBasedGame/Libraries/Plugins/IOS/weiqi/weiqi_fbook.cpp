//
//  fbook.cpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include "weiqi_fbook.hpp"
#include "weiqi_debug.hpp"
#include "weiqi_random.hpp"

namespace weiqi
{
    coord_t coord_transform(struct board *b, coord_t coord, int32_t i)
    {
#define HASH_VMIRROR     1
#define HASH_HMIRROR     2
#define HASH_XYFLIP      4
        board_statics* board_statics = &b->board_statics;
        if (i & HASH_VMIRROR) {
            coord = coord_xy(b, coord_x(board_statics, coord, b), board_size(b) - 1 - coord_y(board_statics, coord, b));
        }
        if (i & HASH_HMIRROR) {
            coord = coord_xy(b, board_size(b) - 1 - coord_x(board_statics, coord, b), coord_y(board_statics, coord, b));
        }
        if (i & HASH_XYFLIP) {
            coord = coord_xy(b, coord_y(board_statics, coord, b), coord_x(board_statics, coord, b));
        }
        return coord;
    }
    
    /* Check if we can make a move along the fbook right away.
     * Otherwise return pass. */
    coord_t fbook_check(struct board *board)
    {
        if (!board->fbook) return pass;
        
        hash_t hi = board->hash;
        coord_t cf = pass;
        while (!is_pass(board->fbook->moves[hi & fbook_hash_mask])) {
            if (board->fbook->hashes[hi & fbook_hash_mask] == board->hash) {
                cf = board->fbook->moves[hi & fbook_hash_mask];
                break;
            }
            hi++;
        }
        if (!is_pass(cf)) {
            if (DEBUGL(1))
                printf("fbook match %" PRIhash ":%" PRIhash "\n", board->hash, board->hash & fbook_hash_mask);
        } else {
            /* No match, also prevent further fbook usage
             * until the next clear_board. */
            if (DEBUGL(4))
                printf("fbook out %" PRIhash ":%" PRIhash "\n", board->hash, board->hash & fbook_hash_mask);
            fbook_done(board->fbook);
            board->fbook = NULL;
        }
        return cf;
    }
    
    // tam bo static
    struct fbook *fbcache;
    
    struct fbook* fbook_init(char *filename, struct board *b)
    {
        if (fbcache && fbcache->bsize == board_size(b)
            && fbcache->handicap == b->handicap)
            return fbcache;
        
        FILE *f = fopen_data_file(filename, "r");
        if (!f) {
            perror(filename);
            return NULL;
        }
        
        struct fbook *fbook = new struct fbook();// calloc(1, sizeof(*fbook));
        fbook->bsize = board_size(b);
        fbook->handicap = b->handicap;
        /* We do not set handicap=1 in case of too low komi on purpose;
         * we want to go with the no-handicap fbook for now. */
        for (int32_t i = 0; i < 1<<fbook_hash_bits; i++)
            fbook->moves[i] = pass;
        
        if (DEBUGL(1))
            printf("Loading opening fbook %s...\n", filename);
        
        /* Scratch board where we lay out the sequence;
         * one for each transposition. */
        struct board *bs[8];
        for (int32_t i = 0; i < 8; i++) {
            bs[i] = new struct board;
            board_init(bs[i], NULL);
            board_resize(bs[i], fbook->bsize - 2);
        }
        
        char linebuf[1024];
        while (fgets(linebuf, sizeof(linebuf), f)) {
            char *line = linebuf;
            linebuf[strlen(linebuf) - 1] = 0; // chop
            
            /* Format of line is:
             * BSIZE COORD COORD COORD... | COORD
             * BSIZE/HANDI COORD COORD COORD... | COORD */
            int32_t bsize = (int)strtol(line, &line, 10);
            if (bsize != fbook->bsize - 2)
                continue;
            int32_t handi = 0;
            if (*line == '/') {
                line++;
                handi = (int)strtol(line, &line, 10);
            }
            if (handi != fbook->handicap)
                continue;
            while (isspace(*line)) line++;
            
            for (int32_t i = 0; i < 8; i++) {
                board_clear(bs[i]);
                bs[i]->last_move.color = S_WHITE;
            }
            
            while (*line != '|') {
                coord_t c = str2coord(line, fbook->bsize);
                
                for (int32_t i = 0; i < 8; i++) {
                    coord_t coord = coord_transform(b, c, i);
                    struct move m;
                    {
                        m.coord = coord;
                        m.color = stone_other(bs[i]->last_move.color);
                    };
                    int32_t ret = board_play(bs[i], &m);
                    {
                        // assert(ret >= 0);
                        if(!(ret >= 0)){
                            printf("error, assert(ret >= 0)\n");
                        }
                    }
                }
                
                while (!isspace(*line)) line++;
                while (isspace(*line)) line++;
            }
            
            line++;
            while (isspace(*line)) line++;
            
            /* In case of multiple candidates, pick one with
             * exponentially decreasing likelihood. */
            while (strchr(line, ' ') && fast_random(2)) {
                line = strchr(line, ' ');
                while (isspace(*line)) line++;
            }
            
            coord_t c = str2coord(line, fbook->bsize);
            for (int32_t i = 0; i < 8; i++) {
                coord_t coord = coord_transform(b, c, i);
#if 0
                char conflict = is_pass(fbook->moves[bs[i]->hash & fbook_hash_mask]) ? '+' : 'C';
                if (conflict == 'C')
                    for (int32_t j = 0; j < i; j++)
                        if (bs[i]->hash == bs[j]->hash)
                            conflict = '+';
                if (conflict == 'C') {
                    hash_t hi = bs[i]->hash;
                    while (!is_pass(fbook->moves[hi & fbook_hash_mask]) && fbook->hashes[hi & fbook_hash_mask] != bs[i]->hash)
                        hi++;
                    if (fbook->hashes[hi & fbook_hash_mask] == bs[i]->hash)
                        hi = 'c';
                }
                printf("%c %"PRIhash":%"PRIhash" (<%d> %s)\n", conflict, bs[i]->hash & fbook_hash_mask, bs[i]->hash, i, linebuf);
#endif
                hash_t hi = bs[i]->hash;
                while (!is_pass(fbook->moves[hi & fbook_hash_mask]) && fbook->hashes[hi & fbook_hash_mask] != bs[i]->hash)
                    hi++;
                fbook->moves[hi & fbook_hash_mask] = coord;
                fbook->hashes[hi & fbook_hash_mask] = bs[i]->hash;
                fbook->movecnt++;
            }
        }
        
        for (int32_t i = 0; i < 8; i++) {
            board_done(bs[i]);
        }
        
        fclose(f);
        
        if (!fbook->movecnt) {
            /* Empty book is not worth the hassle. */
            fbook_done(fbook);
            return NULL;
        }
        
        struct fbook *fbold = fbcache;
        fbcache = fbook;
        if (fbold)
            fbook_done(fbold);
        
        return fbook;
    }
    
    void fbook_done(struct fbook *fbook)
    {
        if (fbook != fbcache){
            if(fbook!=NULL){
                // delete fbook;
                free(fbook);
            }else{
                printf("error, why fbook null\n");
            }
        }
    }
}
