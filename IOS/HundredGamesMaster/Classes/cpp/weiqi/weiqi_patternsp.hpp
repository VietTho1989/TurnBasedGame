//
//  patternsp.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_patternsp_hpp
#define weiqi_patternsp_hpp

#include <stdio.h>
#include "weiqi_board.hpp"
#include "weiqi_move.hpp"
#include "weiqi_pattern.hpp"
#include "weiqi_debug.hpp"

namespace weiqi
{
    
    void spatial_init(void);
    
    /* Spatial stone configuration pattern features - like pattern3 handles
     * 3x3-area, this handles general N-area (where N is distance in
     * gridcular metric). These routines define the dictionary of spatial
     * configurations (accessible by zobrist hashes or indices) and related
     * data structures; eventually, they support the FEAT_SPATIAL pattern
     * feature implementation in the General Pattern Matcher (pattern.[ch]). */
    
    /* Maximum spatial pattern diameter. */
#define MAX_PATTERN_DIST 7
    /* Maximum number of points in spatial pattern (upper bound).
     * TODO: Better upper bound to save more data. */
#define MAX_PATTERN_AREA (MAX_PATTERN_DIST*MAX_PATTERN_DIST)
    
#define PATTERN_BOARD_SIZE ((MAX_PATTERN_DIST + 1) * (MAX_PATTERN_DIST + 1))
    
#define PTH_VMIRROR	1
#define PTH_HMIRROR	2
#define PTH_90ROT	4
    
    /* For each encountered configuration of stones, we keep it "spelled out"
     * in the spatial dictionary records, index them and refer just the indices
     * in the feature payloads. This achieves several things:
     * * We can handle patterns of arbitrary length.
     * * We can recognize isomorphous configurations (color reversions,
     *   rotations) within the dataset.
     * * We can visualise patterns corresponding to chosen features.
     *
     * Thus, it goes like this:
     *
     * +----------------+   +----------------+
     * | struct pattern | - | struct feature |
     * +----------------+   |  payload    id |
     *                      +----------------+
     *                            |       FEAT_SPATIAL
     *                            |
     *                            |   ,--<--.
     *                            |   |     |
     * +-----------------------------------------+
     * | struct spatial_dict  spatials[]  hash[] |
     * +-----------------------------------------+
     *                            |
     *                    +----------------+
     *                    | struct spatial |
     *                    +----------------+
     */
    
    
    /* Spatial record - single stone configuration. */
    
    struct spatial {
        /* Gridcular radius of matched pattern. */
        unsigned char dist;
        /* The points; each point is two bits, corresponding
         * to {enum stone}. Points are ordered in gridcular-defined
         * spiral from middle to the edge; the dictionary file has
         * a comment describing the ordering at the top. */
        unsigned char points[MAX_PATTERN_AREA / 4];
#define spatial_point_at(s, i) (((s).points[(i) / 4] >> (((i) % 4) * 2)) & 3)
    };
    
    /* Fill up the spatial record from @m vincinity, up to full distance
     * given by pattern config. */
    void spatial_from_board(struct pattern_config *pc, struct spatial *s, struct board *b, struct move *m);
    
    /* Compute hash of given spatial pattern. */
    hash_t spatial_hash(uint32_t rotation, struct spatial *s);
    
    /* Convert given spatial pattern to string. */
    void spatial2str(char* ret, struct spatial *s);
    
    /* Mapping from point sequence to coordinate offsets (to determine
     * coordinates relative to pattern center). */
    extern struct ptcoord { int16_t x, y; } ptcoords[MAX_PATTERN_AREA];
    /* For each radius, starting index in ptcoords[]. */
    extern uint32_t ptind[MAX_PATTERN_DIST + 2];
    
    /* Zobrist hashes used for points in patterns. */
#define PTH__ROTATIONS	8
    extern hash_t pthashes[PTH__ROTATIONS][MAX_PATTERN_AREA][S_MAX];
    
#define ptcoords_at(board_statics, x_, y_, c_, b_, j_) \
int32_t x_ = coord_x(board_statics, (c_), (b_)) + ptcoords[j_].x; \
int32_t y_ = coord_y(board_statics, (c_), (b_)) + ptcoords[j_].y; \
if (x_ >= board_size(b_)) x_ = board_size(b_) - 1; else if (x_ < 0) x_ = 0; \
if (y_ >= board_size(b_)) y_ = board_size(b_) - 1; else if (y_ < 0) y_ = 0;
    
    /* Spatial dictionary - collection of stone configurations. */
    
    /* Hashed access; all isomorphous configurations
     * are also hashed */
#define spatial_hash_bits 26 // ~256mib array
#define spatial_hash_mask ((1 << spatial_hash_bits) - 1)
    
    /* Two ways of lookup: (i) by index (ii) by hash of the configuration. */
    struct spatial_dict {
        /* Indexed base store */
        uint32_t nspatials; /* Number of records. */
        struct spatial* spatials; /* Actual records. */
        /* Maps to spatials[] indices. The hash function
         * used is zobrist hashing with fixed values. */
        uint32_t hash[1 << spatial_hash_bits];
        /* Auxiliary counters for statistics. */
        int32_t fills, collisions;
    };
    
    /* Initializes spatial dictionary, pre-loading existing records from
     * default filename if exists. If will_append is true, it will not
     * complain about non-existing file and initialize the dictionary anyway.
     * If hash is true, loaded spatials will be added to the hashtable;
     * use false if this is to be done later (e.g. by patternprob). */
    bool spatial_dict_init(struct spatial_dict* dict, bool will_append, bool hash);
    
    /* Lookup specified spatial pattern in the dictionary; return index
     * of the pattern. If the pattern is not found, 0 will be returned. */
    // bo static
    uint32_t spatial_dict_get(struct spatial_dict *dict, int32_t dist, hash_t h);
    
    /* Store specified spatial pattern in the dictionary if it is not known yet.
     * Returns pattern id. Note that the pattern is NOT written to the underlying
     * file automatically. */
    uint32_t spatial_dict_put(struct spatial_dict *dict, struct spatial *s, hash_t);
    
    /* Readds given rotation of given pattern to the hash. This is useful only
     * if you want to tweak hash priority of various patterns. */
    bool spatial_dict_addh(struct spatial_dict *dict, hash_t hash, uint32_t id);
    
    /* Print stats about the hash to stderr. Companion to spatial_dict_addh(). */
    void spatial_dict_hashstats(struct spatial_dict *dict);
    
    
    /* Spatial dictionary file manipulation. */
    
    /* Loading routine is not exported, it is called automatically within
     * spatial_dict_init(). */
    
    /* Default spatial dict filename to use. */
    extern char spatial_dict_filename[500];
    
    /* Write comment lines describing the dictionary (e.g. point order
     * in patterns) to given file. */
    void spatial_dict_writeinfo(struct spatial_dict *dict, FILE *f);
    
    /* Append specified spatial pattern to the given file. */
    void spatial_write(struct spatial_dict *dict, struct spatial *s, uint32_t id, FILE *f);
    
    
    // bo static
    inline uint32_t spatial_dict_get(struct spatial_dict *dict, int32_t dist, hash_t hash)
    {
        uint32_t id = dict->hash[hash];
#ifdef DEBUG
        if (id && dict->spatials[id].dist != dist) {
            if (DEBUGL(6))
                printf("Collision dist %d vs %d (hash [%d]%" PRIhash")\n", dist, dict->spatials[id].dist, id, hash);
            return 0;
        }
#endif
        return id;
    }
    
    extern struct spatial_dict cached_dict;
}

#endif /* patternsp_hpp */
