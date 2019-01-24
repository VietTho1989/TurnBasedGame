//
//  patternprob.cpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <ctype.h>
#include <stdio.h>
#include <stdlib.h>

#include "weiqi_patternprob.hpp"
#include "weiqi_patternsp.hpp"
#include "weiqi_debug.hpp"
#include "weiqi_jni.hpp"
#include "../Platform.h"

namespace weiqi
{
    /* We try to avoid needlessly reloading probability dictionary
     * since it may take rather long time. */
    // tam bo static
    struct pattern_pdict cached_pdict;
    
    char patternFileName[500] = "";// = "/Users/viettho/Desktop/NewProject/TurnbaseGame/NativeCode/Go/weiqi/Resources/patterns.prob";
    
    bool my_pattern_pdict_init(char* filename)
    {
        bool ret = false;
        {
            if (!filename){
                filename = patternFileName;
            }
            bool isAndroidAsset = false;
#ifdef Android
            {
                assetistream f(assetManager, filename);
                if(f.isOpen()){
                    isAndroidAsset = true;
                    // reset cached_pdict
                    {
                        if(cached_pdict.table){
                            printf("error, have old table\n");
                            free(cached_pdict.table);
                        }
                        memset(&cached_pdict, 0, sizeof(pattern_pdict));
                    }

                    struct pattern_pdict* dict = &cached_pdict;
                    struct pattern_config* pc = &DEFAULT_PATTERN_CONFIG;
                    dict->pc = pc;
                    // init
                    if(pc->spat_dict!=NULL){
                        dict->table = (struct pattern_prob**)calloc2(pc->spat_dict->nspatials + 1, sizeof(*dict->table));
                        char* sphcachehit = (char*)calloc2(pc->spat_dict->nspatials, 1);
                        hash_t (*sphcache)[PTH__ROTATIONS] = (hash_t(*)[8])malloc(pc->spat_dict->nspatials * sizeof(sphcache[0]));

                        int32_t i = 0;
                        std::string sbuf;
                        while (getline(f, sbuf)) {
                            // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "my_pattern_pdict_init: %s\n", sbuf.c_str());
                            // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "%d", i);
                            struct pattern_prob* pb = (struct pattern_prob*)calloc2(1, sizeof(*pb));
                            // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "1 %d", i);
                            if(pb){
                                int32_t c, o;

                                char *buf = const_cast<char*>(sbuf.c_str());
                                if (buf[0] == '#') continue;
                                while (isspace(*buf)) buf++;
                                while (!isspace(*buf)) buf++; // we recompute the probability
                                while (isspace(*buf)) buf++;
                                c = (int)strtol(buf, &buf, 10);
                                while (isspace(*buf)) buf++;
                                o = (int)strtol(buf, &buf, 10);
                                pb->prob = (floating_t) c / o;
                                while (isspace(*buf)) buf++;

                                // parse pattern
                                {
                                    bool isCorrect = true;
                                    str2pattern(buf, &pb->p, isCorrect);
                                    if(!isCorrect){
                                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, pattern not correct: %s\n", buf);
                                        ret = false;
                                        break;
                                    }
                                }

                                uint32_t spi = pattern2spatial(dict, &pb->p);
                                pb->next = dict->table[spi];
                                dict->table[spi] = pb;

                                /* Some spatials may not have been loaded if they correspond
                                 * to a radius larger than supported. */
                                if (pc->spat_dict->spatials[spi].dist > 0) {
                                    /* We rehash spatials in the order of loaded patterns. This way
                                     * we make sure that the most popular patterns will be hashed
                                     * last and therefore take priority. */
                                    if (!sphcachehit[spi]) {
                                        sphcachehit[spi] = 1;
                                        for (uint32_t r = 0; r < PTH__ROTATIONS; r++)
                                            sphcache[spi][r] = spatial_hash(r, &pc->spat_dict->spatials[spi]);
                                    }
                                    for (uint32_t r = 0; r < PTH__ROTATIONS; r++)
                                        spatial_dict_addh(pc->spat_dict, sphcache[spi][r], spi);
                                }

                                i++;
                            } else{
                                __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Cannot alloc, out of memory");
                                break;
                            }
                        }
                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "my_pattern_pdict_init: success\n");

                        free(sphcache);
                        free(sphcachehit);
                        if (DEBUGL(3))
                            spatial_dict_hashstats(pc->spat_dict);
                        if (DEBUGL(1))
                            printf("Loaded %d pattern-probability pairs.\n", i);
                    }else{
                        printf("error, pc->spat_dict null\n");
                        // TODO setSpatialDictFilename
                    }
                    printf("create new cached_pdict sucess\n");
                } else {
                    printf("error, No pattern probtable, will not use learned patterns.\n");
                }
            }
#endif
            if(!isAndroidAsset){
                FILE *f = fopen_data_file(filename, "r");
                if (!f) {
                    printf("error, No pattern probtable, will not use learned patterns.\n");
                    return ret;
                }

                // reset cached_pdict
                {
                    if(cached_pdict.table){
                        printf("error, have old table\n");
                        free(cached_pdict.table);
                    }
                    memset(&cached_pdict, 0, sizeof(pattern_pdict));
                }

                struct pattern_pdict* dict = &cached_pdict;
                struct pattern_config* pc = &DEFAULT_PATTERN_CONFIG;
                dict->pc = pc;
                // init
                if(pc->spat_dict!=NULL){
                    dict->table = (struct pattern_prob**)calloc2(pc->spat_dict->nspatials + 1, sizeof(*dict->table));
                    char* sphcachehit = (char*)calloc2(pc->spat_dict->nspatials, 1);
                    hash_t (*sphcache)[PTH__ROTATIONS] = (hash_t(*)[8])malloc(pc->spat_dict->nspatials * sizeof(sphcache[0]));

                    int32_t i = 0;
                    char sbuf[1024];
                    while (fgets(sbuf, sizeof(sbuf), f)) {
                        struct pattern_prob* pb = (struct pattern_prob*)calloc2(1, sizeof(*pb));
                        int32_t c, o;

                        char *buf = sbuf;
                        if (buf[0] == '#') continue;
                        while (isspace(*buf)) buf++;
                        while (!isspace(*buf)) buf++; // we recompute the probability
                        while (isspace(*buf)) buf++;
                        c = (int)strtol(buf, &buf, 10);
                        while (isspace(*buf)) buf++;
                        o = (int)strtol(buf, &buf, 10);
                        pb->prob = (floating_t) c / o;
                        while (isspace(*buf)) buf++;

                        // parse pattern
                        {
                            bool isCorrect = true;
                            str2pattern(buf, &pb->p, isCorrect);
                            if(!isCorrect){
                                printf("error, pattern not correct: %s\n", buf);
                                ret = false;
                                break;
                            }
                        }

                        uint32_t spi = pattern2spatial(dict, &pb->p);
                        pb->next = dict->table[spi];
                        dict->table[spi] = pb;

                        /* Some spatials may not have been loaded if they correspond
                         * to a radius larger than supported. */
                        if (pc->spat_dict->spatials[spi].dist > 0) {
                            /* We rehash spatials in the order of loaded patterns. This way
                             * we make sure that the most popular patterns will be hashed
                             * last and therefore take priority. */
                            if (!sphcachehit[spi]) {
                                sphcachehit[spi] = 1;
                                for (uint32_t r = 0; r < PTH__ROTATIONS; r++)
                                    sphcache[spi][r] = spatial_hash(r, &pc->spat_dict->spatials[spi]);
                            }
                            for (uint32_t r = 0; r < PTH__ROTATIONS; r++)
                                spatial_dict_addh(pc->spat_dict, sphcache[spi][r], spi);
                        }

                        i++;
                        // printf("%d\n", i);
                    }

                    free(sphcache);
                    free(sphcachehit);
                    if (DEBUGL(3))
                        spatial_dict_hashstats(pc->spat_dict);
                    if (DEBUGL(1))
                        printf("Loaded %d pattern-probability pairs.\n", i);
                }else{
                    printf("error, pc->spat_dict null\n");
                    // TODO setSpatialDictFilename
                }

                fclose(f);
                printf("create new cached_pdict sucess\n");
            }
        }
        ret = true;
        return ret;
    }
    
    struct pattern_pdict* pattern_pdict_init(char *filename, struct pattern_config *pc)
    {
        cached_pdict.pc = pc;
        return &cached_pdict;
    }
    
    floating_t pattern_rate_moves(struct pattern_setup *pat, struct board *b, enum stone color, struct pattern *pats, floating_t *probs)
    {
        double total = 0;
        for (int32_t f = 0; f < b->flen; f++) {
            probs[f] = NAN;
            
            struct move mo;
            {
                mo.coord = b->f[f];
                mo.color = color;
            }
            if (is_pass(mo.coord))
                continue;
            if (!board_is_valid_move(b, &mo))
                continue;
            
            pattern_match(&pat->pc, pat->ps, &pats[f], b, &mo);
            floating_t prob = pattern_prob(pat->pd, &pats[f]);
            if (!isnan(prob)) {
                probs[f] = prob;
                total += prob;
            }
            if (DEBUGL(5)) {
                char buf[256];
                pattern2str(buf, &pats[f]);
                char strCoord[256];
                {
                    coord2sstr(strCoord, mo.coord, b);
                }
                printf("=> move %s pattern %s prob %.3f\n", strCoord, buf, prob);
            }
        }
        return total;
    }
}
// Loaded 2760778 pattern-probability pairs.
