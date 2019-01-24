//
//  josekibase.cpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "../../../Platform.h"
#include <assert.h>
#include <stdio.h>
#include <stdlib.h>

#include "weiqi_josekibase.hpp"
#include "../../weiqi_debug.hpp"
#include "../../weiqi_util.hpp"

namespace weiqi
{
    struct joseki_dict* joseki_init(int32_t bsize)
    {
        struct joseki_dict* jd = (struct joseki_dict*)calloc(1, sizeof(*jd));
        jd->bsize = bsize;
        jd->patterns = (struct joseki_pattern*)calloc(1 << joseki_hash_bits, sizeof(jd->patterns[0]));
        return jd;
    }
    
    struct joseki_dict* joseki_load(int32_t bsize)
    {
        char fname[1024];
        snprintf(fname, 1024, "joseki%d.pdict", bsize - 2);
        // use asset or file
        bool isAndroidAsset = false;
#ifdef Android
        {
            assetistream f(assetManager, fname);
            if(f.isOpen()){
                isAndroidAsset = true;
                struct joseki_dict *jd = joseki_init(bsize);

                std::string linebuf;
                while (getline(f, linebuf)) {
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "linebuf: %s\n", linebuf.c_str());
                    char *line = const_cast<char*>(linebuf.c_str());

                    while (isspace(*line)) line++;
                    if (*line == '#')
                        continue;
                    hash_t h = strtoull(line, &line, 16);
                    while (isspace(*line)) line++;
                    enum stone color = *line++ == 'b' ? S_BLACK : S_WHITE;
                    while (isspace(*line)) line++;

                    /* Get count. */
                    char *cs = strrchr(line, ' ');
                    {
                        // assert(cs);
                        if(!cs){
                            printf("error, assert(cs)\n");
                        }
                    }
                    *cs++ = 0;
                    int32_t count = atoi(cs);

                    coord_t **ccp = &jd->patterns[h].moves[color - 1];
                    {
                        // assert(!*ccp);
                        if(*ccp){
                            printf("error, assert(!*ccp)\n");
                        }
                    }
                    *ccp = (coord_t*)calloc2(count + 1, sizeof(coord_t));
                    coord_t *cc = *ccp;
                    while (*line) {
                        {
                            // assert(cc - *ccp < count);
                            if(!(cc - *ccp < count)){
                                printf("error, assert(cc - *ccp < count)\n");
                            }
                        }
                        *cc++ = str2coord(line, bsize);
                        line += strcspn(line, " ");
                        line += strspn(line, " ");
                    }
                    *cc = pass;
                }
                return jd;
            }
        }
#endif
        if(!isAndroidAsset){
            FILE *f = fopen_data_file(fname, "r");
            if (!f) {
                return NULL;
            }
            struct joseki_dict *jd = joseki_init(bsize);

            char linebuf[1024];
            while (fgets(linebuf, 1024, f)) {
                char *line = linebuf;

                while (isspace(*line)) line++;
                if (*line == '#')
                    continue;
                hash_t h = strtoull(line, &line, 16);
                while (isspace(*line)) line++;
                enum stone color = *line++ == 'b' ? S_BLACK : S_WHITE;
                while (isspace(*line)) line++;

                /* Get count. */
                char *cs = strrchr(line, ' ');
                {
                    // assert(cs);
                    if(!cs){
                        printf("error, assert(cs)\n");
                    }
                }
                *cs++ = 0;
                int32_t count = atoi(cs);

                coord_t **ccp = &jd->patterns[h].moves[color - 1];
                {
                    // assert(!*ccp);
                    if(*ccp){
                        printf("error, assert(!*ccp)\n");
                    }
                }
                *ccp = (coord_t*)calloc2(count + 1, sizeof(coord_t));
                coord_t *cc = *ccp;
                while (*line) {
                    {
                        // assert(cc - *ccp < count);
                        if(!(cc - *ccp < count)){
                            printf("error, assert(cc - *ccp < count)\n");
                        }
                    }
                    *cc++ = str2coord(line, bsize);
                    line += strcspn(line, " ");
                    line += strspn(line, " ");
                }
                *cc = pass;
            }

            fclose(f);
            return jd;
        } else {
            return NULL;
        }
    }
    
    void joseki_done(struct joseki_dict *jd)
    {
        if (!jd) return;
        for( uint64_t pid = 0; pid < 1<<joseki_hash_bits ; pid++){
            free(jd->patterns[pid].moves[0]);
            free(jd->patterns[pid].moves[1]);
        }
        free(jd->patterns);
        free(jd);
    }
}
