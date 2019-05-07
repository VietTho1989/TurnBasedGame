//
//  pattern.cpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <ctype.h>
#include <inttypes.h>
#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <mutex>
#include <string.h>

#include "weiqi_pattern.hpp"
#include "weiqi_patternprob.hpp"

namespace weiqi
{
#define CAPTURE_COUNTSTONES_MAX ((1 << CAPTURE_COUNTSTONES_PAYLOAD_SIZE) - 1)
    
    
#ifdef _MSC_VER
    struct pattern_config DEFAULT_PATTERN_CONFIG = {
        DEFAULT_PATTERN_CONFIG.bdist_max = 4,
        DEFAULT_PATTERN_CONFIG.spat_min = 3,
        DEFAULT_PATTERN_CONFIG.spat_max = MAX_PATTERN_DIST,
        DEFAULT_PATTERN_CONFIG.spat_largest = true,
    };
#else
    struct pattern_config DEFAULT_PATTERN_CONFIG = {
        .bdist_max = 4,
        .spat_min = 3,
        .spat_max = MAX_PATTERN_DIST,
        .spat_largest = true,
    };
#endif
    
#define PF_MATCH 15
    
    /*pattern_spec PATTERN_SPEC_MATCH_DEFAULT = {
     [FEAT_CAPTURE] = ~(1 << PF_CAPTURE_COUNTSTONES),
     [FEAT_AESCAPE] = ~0,
     [FEAT_SELFATARI] = ~0,
     [FEAT_ATARI] = ~0,
     [FEAT_BORDER] = ~0,
     [FEAT_CONTIGUITY] = 0,
     [FEAT_SPATIAL] = ~0,
     };*/
    
#ifdef _MSC_VER
    pattern_spec PATTERN_SPEC_MATCH_DEFAULT = {
        PATTERN_SPEC_MATCH_DEFAULT[FEAT_CAPTURE] = static_cast<uint16_t>(~(1 << PF_CAPTURE_COUNTSTONES)),
        PATTERN_SPEC_MATCH_DEFAULT[FEAT_AESCAPE] = static_cast<uint16_t>(~0),
        PATTERN_SPEC_MATCH_DEFAULT[FEAT_SELFATARI] = static_cast<uint16_t>(~0),
        PATTERN_SPEC_MATCH_DEFAULT[FEAT_ATARI] = static_cast<uint16_t>(~0),
        PATTERN_SPEC_MATCH_DEFAULT[FEAT_BORDER] = static_cast<uint16_t>(~0),
        PATTERN_SPEC_MATCH_DEFAULT[FEAT_CONTIGUITY] = 0,
        PATTERN_SPEC_MATCH_DEFAULT[FEAT_SPATIAL] = static_cast<uint16_t>(~0),
    };
#else
    pattern_spec PATTERN_SPEC_MATCH_DEFAULT = {
        [FEAT_CAPTURE] = static_cast<uint16_t>(~(1 << PF_CAPTURE_COUNTSTONES)),
        [FEAT_AESCAPE] = static_cast<uint16_t>(~0),
        [FEAT_SELFATARI] = static_cast<uint16_t>(~0),
        [FEAT_ATARI] = static_cast<uint16_t>(~0),
        [FEAT_BORDER] = static_cast<uint16_t>(~0),
        [FEAT_CONTIGUITY] = 0,
        [FEAT_SPATIAL] = static_cast<uint16_t>(~0),
    };
#endif
    
    // tam bo static
    feature_info features[FEAT_MAX];
    
    char* feature2str(char *str, struct feature *f)
    {
        return str + sprintf(str + strlen(str), "%s:%d", features[f->id].name, f->payload);
    }
    
    char* str2feature(char *str, struct feature *f, bool &isCorrect)
    {
        isCorrect = true;
        
        while (isspace(*str)) str++;
        
        uint32_t flen = (uint32_t)strcspn(str, ":");
        for (uint32_t i = 0; i < sizeof(features)/sizeof(features[0]); i++)
            if (strlen(features[i].name) == flen && !strncmp(features[i].name, str, flen)) {
                f->id = (feature_id)i;
                goto found;
            }
        {
            printf("invalid featurespec: %s[%d]\n", str, flen);
            isCorrect = false;
        }
        
        // TODO exit(EXIT_FAILURE);
        
    found:
        str += flen + 1;
        f->payload = (unsigned int)strtoull(str, &str, 10);
        return str;
    }
    
    char* feature_name(enum feature_id f)
    {
        return features[f].name;
    }

    int32_t feature_payloads(struct pattern_setup *pat, enum feature_id f)
    {
        int32_t payloads;
        switch (f) {
            case FEAT_CAPTURE:
                payloads = features[f].payloads;
                if (pat->ps[FEAT_CAPTURE] & (1<<PF_CAPTURE_COUNTSTONES))
                    payloads *= CAPTURE_COUNTSTONES_MAX + 1;
                return payloads;
            case FEAT_SPATIAL:
            {
                // assert(features[f].payloads < 0);
                if(!(features[f].payloads < 0)){
                    printf("error, assert(features[f].payloads < 0)\n");
                }
            }
                return pat->pc.spat_dict->nspatials;
            case FEAT_BORDER:
            {
                // assert(features[f].payloads < 0);
                if(!(features[f].payloads < 0)){
                    printf("error, assert(features[f].payloads < 0)\n");
                }
            }
                return pat->pc.bdist_max + 1;
            default:
            {
                // assert(features[f].payloads > 0);
                if(!(features[f].payloads > 0)){
                    printf("error, assert(features[f].payloads > 0)\n");
                    // features[f].payloads = 1;
                }
            }
                return features[f].payloads;
        }
    }
    
    // std::mutex patternMutext;
    
    void patterns_init(struct pattern_setup *pat, char *arg, bool will_append, bool load_prob)
    {
        // patternMutext.lock();
        
        char *pdict_file = NULL;
        
        memset(pat, 0, sizeof(*pat));
        
        pat->pc = DEFAULT_PATTERN_CONFIG;
        pat->pc.spat_dict = &cached_dict;
        
        memcpy(&pat->ps, PATTERN_SPEC_MATCH_DEFAULT, sizeof(pattern_spec));
        
        if (arg) {
            char *optspec, *next = arg;
            while (*next) {
                optspec = next;
                next += strcspn(next, ":");
                if (*next) { *next++ = 0; } else { *next = 0; }
                
                char *optname = optspec;
                char *optval = strchr(optspec, '=');
                if (optval) *optval++ = 0;
                
                /* See pattern.h:pattern_config for description and
                 * pattern.c:DEFAULT_PATTERN_CONFIG for default values
                 * of the following options. */
                if (!strcasecmp(optname, "bdist_max") && optval) {
                    pat->pc.bdist_max = atoi(optval);
                } else if (!strcasecmp(optname, "spat_min") && optval) {
                    pat->pc.spat_min = atoi(optval);
                } else if (!strcasecmp(optname, "spat_max") && optval) {
                    pat->pc.spat_max = atoi(optval);
                } else if (!strcasecmp(optname, "spat_largest")) {
                    pat->pc.spat_largest = !optval || atoi(optval);
                    
                } else if (!strcasecmp(optname, "pdict_file") && optval) {
                    pdict_file = optval;
                    
                } else {
                    printf("patterns: Invalid argument %s or missing value\n", optname);
                    // exit(EXIT_FAILURE);
                }
            }
        }
        
        if (load_prob && pat->pc.spat_dict) {
            pat->pd = pattern_pdict_init(pdict_file, &pat->pc);
        }
        
        // patternMutext.unlock();
    }
    
    
    /* pattern_spec helpers */
#define PS_ANY(F) (ps[FEAT_ ## F] & (1 << PF_MATCH))
#define PS_PF(F, P) (ps[FEAT_ ## F] & (1 << PF_ ## F ## _ ## P))
    
    // tam bo static
    struct feature* pattern_match_capture(struct pattern_config *pc, pattern_spec ps, struct pattern *p, struct feature *f, struct board *b, struct move *m)
    {
        f->id = FEAT_CAPTURE; f->payload = 0;
#ifdef BOARD_TRAITS
        if (!trait_at(b, m->coord, m->color).cap)
            return f;
        /* Capturable! */
        if ((ps[FEAT_CAPTURE] & ~(1<<PF_CAPTURE_1STONE | 1<<PF_CAPTURE_TRAPPED | 1<<PF_CAPTURE_CONNECTION)) == 1<<PF_MATCH) {
            if (PS_PF(CAPTURE, 1STONE))
                f->payload |= (trait_at(b, m->coord, m->color).cap1 == trait_at(b, m->coord, m->color).cap) << PF_CAPTURE_1STONE;
            if (PS_PF(CAPTURE, TRAPPED))
                f->payload |= (!trait_at(b, m->coord, stone_other(m->color)).safe) << PF_CAPTURE_TRAPPED;
            if (PS_PF(CAPTURE, CONNECTION))
                f->payload |= (trait_at(b, m->coord, m->color).cap < neighbor_count_at(b, m->coord, stone_other(m->color))) << PF_CAPTURE_CONNECTION;
            (f++, p->n++);
            return f;
        }
        /* We need to know details, so we still have to go through
         * the neighbors. */
#endif
        
        /* We look at neighboring groups we could capture, and also if the
         * opponent could save them. */
        /* This is very similar in spirit to board_safe_to_play(), and almost
         * a color inverse of pattern_match_aescape(). */
        
        /* Whether an escape move would be safe for the opponent. */
        int32_t captures = 0;
        coord_t onelib = -1;
        int32_t extra_libs = 0, connectable_groups = 0;
        bool onestone = false, multistone = false;
        int32_t captured_stones = 0;
        
        foreach_neighbor(b, m->coord, {
            if (board_at(b, c) != stone_other(m->color)) {
                if (board_at(b, c) == S_NONE)
                    extra_libs++; // free point
                else if (board_at(b, c) == m->color && board_group_info(b, group_at(b, c))->libs == 1)
                    extra_libs += 2; // capturable enemy group
                continue;
            }
            
            group_t g = group_at(b, c);
            {
                // assert(g);
                if(!g){
                    printf("error, assert(g)\n");
                    g = 1;
                }
            }
            if (board_group_info(b, g)->libs > 1) {
                connectable_groups++;
                if (board_group_info(b, g)->libs > 2) {
                    extra_libs += 2; // connected out
                } else {
                    /* This is a bit tricky; we connect our 2-lib
                     * group to another 2-lib group, which counts
                     * as one liberty, but only if the other lib
                     * is not shared too. */
                    if (onelib == -1) {
                        onelib = board_group_other_lib(b, g, c);
                        extra_libs++;
                    } else {
                        if (c == onelib)
                            extra_libs--; // take that back
                        else
                            extra_libs++;
                    }
                }
                continue;
            }
            
            /* Capture! */
            captures++;
            
            if (PS_PF(CAPTURE, LADDER))
                f->payload |= is_ladder(b, m->coord, g, true) << PF_CAPTURE_LADDER;
            /* TODO: is_ladder() is too conservative in some
             * very obvious situations, look at complete.gtp. */
            
            if (PS_PF(CAPTURE, ATARIDEF))
                foreach_in_group(b, g) {
                    foreach_neighbor(b, c, {
                        {
                            // assert(board_at(b, c) != S_NONE || c == m->coord);
                            if(!(board_at(b, c) != S_NONE || c == m->coord)){
                                printf("error, assert(board_at(b, c) != S_NONE || c == m->coord)\n");
                                c = m->coord - 1;
                                board_set(b, c, S_NONE);
                            }
                        }
                        if (board_at(b, c) != m->color)
                            continue;
                        group_t g = group_at(b, c);
                        if (!g || board_group_info(b, g)->libs != 1)
                            continue;
                        /* A neighboring group of ours is in atari. */
                        f->payload |= 1 << PF_CAPTURE_ATARIDEF;
                    });
                } foreach_in_group_end;
            
            if (PS_PF(CAPTURE, KO)
                && group_is_onestone(b, g)
                && neighbor_count_at(b, m->coord, stone_other(m->color))
                + neighbor_count_at(b, m->coord, S_OFFBOARD) == 4)
                f->payload |= 1 << PF_CAPTURE_KO;
            
            if (PS_PF(CAPTURE, COUNTSTONES)
                && captured_stones < CAPTURE_COUNTSTONES_MAX)
                captured_stones += group_stone_count(b, g, CAPTURE_COUNTSTONES_MAX - captured_stones);
            
            if (group_is_onestone(b, g))
                onestone = true;
            else
                multistone = true;
        });
        
        if (captures > 0) {
            if (PS_PF(CAPTURE, 1STONE))
                f->payload |= (onestone && !multistone) << PF_CAPTURE_1STONE;
            if (PS_PF(CAPTURE, TRAPPED))
                f->payload |= (extra_libs < 2) << PF_CAPTURE_TRAPPED;
            if (PS_PF(CAPTURE, CONNECTION))
                f->payload |= (connectable_groups > 0) << PF_CAPTURE_CONNECTION;
            if (PS_PF(CAPTURE, COUNTSTONES))
                f->payload |= captured_stones << PF_CAPTURE_COUNTSTONES;
            (f++, p->n++);
        }
        return f;
    }
    
    // tam bo static
    struct feature* pattern_match_aescape(struct pattern_config *pc, pattern_spec ps, struct pattern *p, struct feature *f, struct board *b, struct move *m)
    {
        f->id = FEAT_AESCAPE; f->payload = 0;
#ifdef BOARD_TRAITS
        if (!trait_at(b, m->coord, stone_other(m->color)).cap)
            return f;
        /* Opponent can capture something! */
        if ((ps[FEAT_AESCAPE] & ~(1<<PF_AESCAPE_1STONE | 1<<PF_AESCAPE_TRAPPED | 1<<PF_AESCAPE_CONNECTION)) == 1<<PF_MATCH) {
            if (PS_PF(AESCAPE, 1STONE))
                f->payload |= (trait_at(b, m->coord, stone_other(m->color)).cap1 == trait_at(b, m->coord, stone_other(m->color)).cap) << PF_AESCAPE_1STONE;
            if (PS_PF(AESCAPE, TRAPPED))
                f->payload |= (!trait_at(b, m->coord, m->color).safe) << PF_AESCAPE_TRAPPED;
            if (PS_PF(AESCAPE, CONNECTION))
                f->payload |= (trait_at(b, m->coord, stone_other(m->color)).cap < neighbor_count_at(b, m->coord, m->color)) << PF_AESCAPE_CONNECTION;
            (f++, p->n++);
            return f;
        }
        /* We need to know details, so we still have to go through
         * the neighbors. */
#endif
        
        /* Find if a neighboring group of ours is in atari, AND that we provide
         * a liberty to connect out. XXX: No connect-and-die check. */
        /* This is very similar in spirit to board_safe_to_play(). */
        group_t in_atari = -1;
        coord_t onelib = -1;
        int32_t extra_libs = 0, connectable_groups = 0;
        bool onestone = false, multistone = false;
        
        foreach_neighbor(b, m->coord, {
            if (board_at(b, c) != m->color) {
                if (board_at(b, c) == S_NONE)
                    extra_libs++; // free point
                else if (board_at(b, c) == stone_other(m->color) && board_group_info(b, group_at(b, c))->libs == 1) {
                    extra_libs += 2; // capturable enemy group
                    /* XXX: We just consider this move safe
                     * unconditionally. */
                }
                continue;
            }
            group_t g = group_at(b, c);
            {
                // assert(g);
                if(!g){
                    printf("error, assert(g)\n");
                    g = 1;
                }
            }
            if (board_group_info(b, g)->libs > 1) {
                connectable_groups++;
                if (board_group_info(b, g)->libs > 2) {
                    extra_libs += 2; // connected out
                } else {
                    /* This is a bit tricky; we connect our 2-lib
                     * group to another 2-lib group, which counts
                     * as one liberty, but only if the other lib
                     * is not shared too. */
                    if (onelib == -1) {
                        onelib = board_group_other_lib(b, g, c);
                        extra_libs++;
                    } else {
                        if (c == onelib)
                            extra_libs--; // take that back
                        else
                            extra_libs++;
                    }
                }
                continue;
            }
            
            /* In atari! */
            in_atari = g;
            
            if (PS_PF(AESCAPE, LADDER))
                f->payload |= is_ladder(b, m->coord, g, true) << PF_AESCAPE_LADDER;
            /* TODO: is_ladder() is too conservative in some
             * very obvious situations, look at complete.gtp. */
            
            if (group_is_onestone(b, g))
                onestone = true;
            else
                multistone = true;
        });
        
        if (in_atari >= 0) {
            if (PS_PF(AESCAPE, 1STONE))
                f->payload |= (onestone && !multistone) << PF_AESCAPE_1STONE;
            if (PS_PF(AESCAPE, TRAPPED))
                f->payload |= (extra_libs < 2) << PF_AESCAPE_TRAPPED;
            if (PS_PF(AESCAPE, CONNECTION))
                f->payload |= (connectable_groups > 0) << PF_AESCAPE_CONNECTION;
            (f++, p->n++);
        }
        return f;
    }
    
    // tam bo static
    struct feature* pattern_match_atari(struct pattern_config *pc, pattern_spec ps, struct pattern *p, struct feature *f, struct board *b, struct move *m)
    {
        foreach_neighbor(b, m->coord, {
            if (board_at(b, c) != stone_other(m->color))
                continue;
            group_t g = group_at(b, c);
            if (!g || board_group_info(b, g)->libs != 2)
                continue;
            
            /* Can atari! */
            f->id = FEAT_ATARI; f->payload = 0;
            
            if (PS_PF(ATARI, LADDER)) {
                /* Opponent will escape by the other lib. */
                coord_t lib = board_group_other_lib(b, g, m->coord);
                /* TODO: is_ladder() is too conservative in some
                 * very obvious situations, look at complete.gtp. */
                f->payload |= wouldbe_ladder(b, g, lib, m->coord, stone_other(m->color)) << PF_ATARI_LADDER;
            }
            
            if (PS_PF(ATARI, KO) && !is_pass(b->ko.coord))
                f->payload |= 1 << PF_ATARI_KO;
            
            (f++, p->n++);
        });
        return f;
    }
    
#ifndef BOARD_SPATHASH
#undef BOARD_SPATHASH_MAXD
#define BOARD_SPATHASH_MAXD 1
#endif
    
    /* Match spatial features that are too distant to be pre-matched
     * incrementally. */
    struct feature* pattern_match_spatial_outer(struct pattern_config *pc, pattern_spec ps, struct pattern *p, struct feature *f, struct board *b, struct move *m, hash_t h)
    {
        /* We record all spatial patterns black-to-play; simply
         * reverse all colors if we are white-to-play. */
        // tam bo static
        enum stone bt_black[4] = { S_NONE, S_BLACK, S_WHITE, S_OFFBOARD };
        // tam bo static
        enum stone bt_white[4] = { S_NONE, S_WHITE, S_BLACK, S_OFFBOARD };
        enum stone (*bt)[4] = m->color == S_WHITE ? &bt_white : &bt_black;
        
        for (uint32_t d = BOARD_SPATHASH_MAXD + 1; d <= pc->spat_max; d++) {
            /* Recompute missing outer circles:
             * Go through all points in given distance. */
            for (uint32_t j = ptind[d]; j < ptind[d + 1]; j++) {
                board_statics* board_statics = &b->board_statics;
                ptcoords_at(board_statics, x, y, m->coord, b, j);
                h ^= pthashes[0][j][(*bt)[board_atxy(b, x, y)]];
            }
            if (d < pc->spat_min)
                continue;
            /* Record spatial feature, one per distance. */
            uint32_t sid = spatial_dict_get(pc->spat_dict, d, h & spatial_hash_mask);
            if (sid > 0) {
                f->id = FEAT_SPATIAL;
                f->payload = sid;
                if (!pc->spat_largest)
                    (f++, p->n++);
            } /* else not found, ignore */
        }
        return f;
    }
    
    struct feature* pattern_match_spatial(struct pattern_config *pc, pattern_spec ps, struct pattern *p, struct feature *f, struct board *b, struct move *m)
    {
        /* XXX: This is partially duplicated from spatial_from_board(), but
         * we build a hash instead of spatial record. */
        
        {
            // assert(pc->spat_min > 0);
            if(!(pc->spat_min > 0)){
                printf("error, assert(pc->spat_min > 0)\n");
                pc->spat_min = 1;
            }
        }
        f->id = (feature_id)-1;
        
        hash_t h = pthashes[0][0][S_NONE];
#ifdef BOARD_SPATHASH
        bool w_to_play = m->color == S_WHITE;
        for (int32_t d = 2; d <= BOARD_SPATHASH_MAXD; d++) {
            /* Reuse all incrementally matched data. */
            h ^= b->spathash[m->coord][d - 1][w_to_play];
            if (d < pc->spat_min)
                continue;
            /* Record spatial feature, one per distance. */
            uint32_t sid = spatial_dict_get(pc->spat_dict, d, h & spatial_hash_mask);
            if (sid > 0) {
                f->id = FEAT_SPATIAL;
                f->payload = sid;
                if (!pc->spat_largest)
                    (f++, p->n++);
            } /* else not found, ignore */
        }
#else
        {
            // assert(BOARD_SPATHASH_MAXD < 2);
            if(!(BOARD_SPATHASH_MAXD < 2)){
                printf("error, assert(BOARD_SPATHASH_MAXD < 2)\n");
            }
        }
#endif
        if (unlikely(pc->spat_max > BOARD_SPATHASH_MAXD))
            f = pattern_match_spatial_outer(pc, ps, p, f, b, m, h);
        if (pc->spat_largest && f->id == FEAT_SPATIAL)
            (f++, p->n++);
        return f;
    }
    
    
    void pattern_match(struct pattern_config *pc, pattern_spec ps, struct pattern *p, struct board *b, struct move *m)
    {
        p->n = 0;
        struct feature *f = &p->f[0];
        
        /* TODO: We should match pretty much all of these features
         * incrementally. */
        
        if (PS_ANY(CAPTURE)) {
            f = pattern_match_capture(pc, ps, p, f, b, m);
        }
        
        if (PS_ANY(AESCAPE)) {
            f = pattern_match_aescape(pc, ps, p, f, b, m);
        }
        
        if (PS_ANY(SELFATARI)) {
            bool simple = false;
            if (PS_PF(SELFATARI, STUPID)) {
#ifdef BOARD_TRAITS
                if (!b->precise_selfatari)
                    simple = !trait_at(b, m->coord, m->color).safe;
                else
#endif
                    simple = !board_safe_to_play(b, m->coord, m->color);
            }
            bool thorough = false;
            if (PS_PF(SELFATARI, SMART)) {
#ifdef BOARD_TRAITS
                if (b->precise_selfatari)
                    thorough = !trait_at(b, m->coord, m->color).safe;
                else
#endif
                    thorough = is_bad_selfatari(b, m->color, m->coord);
            }
            if (simple || thorough) {
                f->id = FEAT_SELFATARI;
                f->payload = simple << PF_SELFATARI_STUPID;
                f->payload |= thorough << PF_SELFATARI_SMART;
                (f++, p->n++);
            }
        }
        
        if (PS_ANY(ATARI)) {
            f = pattern_match_atari(pc, ps, p, f, b, m);
        }
        
        if (PS_ANY(BORDER)) {
            uint32_t bdist = coord_edge_distance(m->coord, b);
            if (bdist <= pc->bdist_max) {
                f->id = FEAT_BORDER;
                f->payload = bdist;
                (f++, p->n++);
            }
        }
        
        if (PS_ANY(CONTIGUITY) && !is_pass(b->last_move.coord)
            && coord_is_8adjecent(m->coord, b->last_move.coord, b)) {
            f->id = FEAT_CONTIGUITY;
            f->payload = 1;
            (f++, p->n++);
        }
        
        if (PS_ANY(SPATIAL) && pc->spat_max > 0 && pc->spat_dict) {
            f = pattern_match_spatial(pc, ps, p, f, b, m);
        }
    }
    
    char* pattern2str(char *str, struct pattern *p)
    {
#ifndef Android
        str = strcpy(str, "(");
        for (int32_t i = 0; i < p->n; i++) {
            if (i > 0) str = strcpy(str, " ");
            str = feature2str(str, &p->f[i]);
        }
        // str = stpcpy(str, ")");
        str = strcpy(str, ")");
        return str;
#else
        str = strcpy(str, "(");
        for (int32_t i = 0; i < p->n; i++) {
            if (i > 0) str = strcpy(str, " ");
            str = feature2str(str, &p->f[i]);
        }
        str = strcpy(str, ")");
        return str;
#endif
    }
    
    char* str2pattern(char *str, struct pattern *p, bool &isCorrect)
    {
        isCorrect = true;
        
        p->n = 0;
        while (isspace(*str)) str++;
        if (*str++ != '(') {
            printf("error, invalid patternspec: %s\n", str);
            // TODO exit(EXIT_FAILURE);
            isCorrect = false;
        }
        
        if(isCorrect){
            while (*str != ')') {
                bool featureCorrect = true;
                str = str2feature(str, &p->f[p->n++], featureCorrect);
                if(!featureCorrect){
                    isCorrect = false;
                    break;
                }
            }
        }
        
        str++;
        return str;
    }
}
