//
//  pattern3.cpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>

#include "weiqi_pattern3.hpp"

namespace weiqi
{
    hash_t p3hashes[8][2][S_MAX];
    
    // bo static
    void pattern_record(struct pattern3s *p, int32_t pi, char *str, hash3_t pat, int32_t fixed_color)
    {
        hash_t h = hash3_to_hash(pat);
        while (p->hash[h & pattern3_hash_mask].pattern != pat
               && p->hash[h & pattern3_hash_mask].value != 0)
            h++;
#if 0
        if (h != hash3_to_hash(pat) && p->hash[h & pattern3_hash_mask].pattern != pat)
            printf("collision of %06x: %llx(%x)\n", pat, hash3_to_hash(pat)&pattern3_hash_mask, p->hash[hash3_to_hash(pat)&pattern3_hash_mask].pattern);
#endif
        p->hash[h & pattern3_hash_mask].pattern = pat;
        p->hash[h & pattern3_hash_mask].value = (fixed_color ? fixed_color : 3) | (pi << 2);
        //printf("[%s] %04x %d\n", str, pat, fixed_color);
    }
    
    // bo static
    int32_t pat_vmirror(hash3_t pat)
    {
        /* V mirror pattern; reverse order of 3-2-3 color chunks and
         * 1-2-1 atari chunks */
        return ((pat & 0xfc00) >> 10) | (pat & 0x03c0) | ((pat & 0x003f) << 10)
        | ((pat & 0x80000) >> 3) | (pat & 0x60000) | ((pat & 0x10000) << 3);
    }
    
    // bo static
    int32_t pat_hmirror(hash3_t pat)
    {
        /* H mirror pattern; reverse order of 2-bit values within the chunks,
         * and the 2-bit middle atari chunk. */
#define rev3(p) ((p >> 4) | (p & 0xc) | ((p & 0x3) << 4))
#define rev2(p) ((p >> 2) | ((p & 0x3) << 2))
        return (rev3((pat & 0xfc00) >> 10) << 10)
        | (rev2((pat & 0x03c0) >> 6) << 6)
        | rev3((pat & 0x003f))
        | ((pat & 0x20000) << 1)
        | ((pat & 0x40000) >> 1)
        | (pat & 0x90000);
#undef rev3
#undef rev2
    }
    
    // bo static
    int32_t pat_90rot(hash3_t pat)
    {
        /* Rotate by 90 degrees:
         * 5 6 7  3     7 4 2     2
         * 3   4 1 2 -> 6   1 -> 3 0
         * 0 1 2  0     5 3 0     1  */
        /* I'm too lazy to optimize this :) */

        int32_t p2 = 0;
        
        /* Stone info */
        int32_t vals[8];
        for (int32_t i = 0; i < 8; i++)
            vals[i] = (pat >> (i * 2)) & 0x3;
        int32_t vals2[8];
        vals2[0] = vals[5]; vals2[1] = vals[3]; vals2[2] = vals[0];
        vals2[3] = vals[6];                     vals2[4] = vals[1];
        vals2[5] = vals[7]; vals2[6] = vals[4]; vals2[7] = vals[2];
        for (int32_t i = 0; i < 8; i++)
            p2 |= vals2[i] << (i * 2);
        
        /* Atari info */
        int32_t avals[4];
        for (int32_t i = 0; i < 4; i++)
            avals[i] = (pat >> (16 + i)) & 0x1;
        int32_t avals2[4];
        avals2[3] = avals[2];
        avals2[1] = avals[3]; avals2[2] = avals[0];
        avals2[0] = avals[1];
        for (int32_t i = 0; i < 4; i++)
            p2 |= avals2[i] << (16 + i);
        
        return p2;
    }
    
    void pattern3_transpose(hash3_t pat, hash3_t (*transp)[8])
    {
        int32_t i = 0;
        (*transp)[i++] = pat;
        (*transp)[i++] = pat_vmirror(pat);
        (*transp)[i++] = pat_hmirror(pat);
        (*transp)[i++] = pat_vmirror(pat_hmirror(pat));
        (*transp)[i++] = pat_90rot(pat);
        (*transp)[i++] = pat_90rot(pat_vmirror(pat));
        (*transp)[i++] = pat_90rot(pat_hmirror(pat));
        (*transp)[i++] = pat_90rot(pat_vmirror(pat_hmirror(pat)));
    }
    
    // bo static
    void pattern_gen(struct pattern3s *p, int32_t pi, hash3_t pat, char *src, int32_t srclen, int32_t fixed_color)
    {
        for (; srclen > 0; src++, srclen--) {
            if (srclen == 5)
                continue;
            // tam bo static
            const int32_t ataribits[] = { -1, 0, -1, 1, 2, -1, 3, -1 };
            int32_t patofs = (srclen > 5 ? srclen - 1 : srclen) - 1;
            switch (*src) {
                    /* Wildcards. */
                case '?':
                    *src = '.'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'X'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'O'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = '#'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = '?'; // for future recursions
                    return;
                case 'x':
                    *src = '.'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'O'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = '#'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'x'; // for future recursions
                    return;
                case 'o':
                    *src = '.'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'X'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = '#'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'o'; // for future recursions
                    return;
                    
                case 'X':
                    *src = 'Y'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    if (ataribits[patofs] >= 0) {
                        *src = '|'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    }
                    *src = 'X'; // for future recursions
                    return;
                case 'O':
                    *src = 'Q'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    if (ataribits[patofs] >= 0) {
                        *src = '@'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    }
                    *src = 'O'; // for future recursions
                    return;
                    
                case 'y':
                    *src = '.'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = '|'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'O'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = '#'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'y'; // for future recursions
                    return;
                case 'q':
                    *src = '.'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = '@'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'X'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = '#'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'q'; // for future recursions
                    return;
                    
                case '=':
                    *src = '.'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'Y'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'O'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = '#'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = '='; // for future recursions
                    return;
                case '0':
                    *src = '.'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'Q'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = 'X'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = '#'; pattern_gen(p, pi, pat, src, srclen, fixed_color);
                    *src = '0'; // for future recursions
                    return;
                    
                    /* Atoms. */
                case '.': /* 0 */ break;
                case 'Y': pat |= S_BLACK << (patofs * 2); break;
                case 'Q': pat |= S_WHITE << (patofs * 2); break;
                case '|':
                {
                    {
                        // assert(ataribits[patofs] >= 0);
                        if(!(patofs >= 0 && patofs<8)){
                            printf("error, assert(ataribits[patofs] >= 0)\n");
                            if(!(ataribits[patofs] >= 0)){
                                printf("error, assert(ataribits[patofs] >= 0)\n");
                                patofs = 1;
                            }
                        }
                    }
                    pat |= (S_BLACK << (patofs * 2)) | (1 << (16 + ataribits[patofs]));
                }
                    break;
                case '@':
                {
                    // assert(ataribits[patofs] >= 0);
                    if(!(patofs >= 0 && patofs<8)){
                        printf("error, assert(ataribits[patofs] >= 0)\n");
                        if(!(ataribits[patofs] >= 0)){
                            printf("error, assert(ataribits[patofs] >= 0)\n");
                            patofs = 1;
                        }
                    }
                    pat |= (S_WHITE << (patofs * 2)) | (1 << (16 + ataribits[patofs]));
                }
                    break;
                case '#': pat |= S_OFFBOARD << (patofs * 2); break;
            }
        }
        
        /* Original pattern, all transpositions and rotations */
        hash3_t transp[8];
        pattern3_transpose(pat, &transp);
        for (int32_t i = 0; i < 8; i++) {
            /* Original color assignment */
            pattern_record(p, pi, src - 9, transp[i], fixed_color);
            /* Reverse color assignment */
            if (fixed_color)
                fixed_color = 2 - (fixed_color == 2);
            pattern_record(p, pi, src - 9, pattern3_reverse(transp[i]), fixed_color);
        }
    }
    
    // bo static
    void patterns_gen(struct pattern3s *p, char src[][11], int32_t src_n)
    {
        for (int32_t i = 0; i < src_n; i++) {
            //printf("<%s>\n", src[i]);
            int32_t fixed_color = 0;
            switch (src[i][9]) {
                case 'X': fixed_color = S_BLACK; break;
                case 'O': fixed_color = S_WHITE; break;
            }
            //printf("** %s **\n", src[i]);
            pattern_gen(p, i, 0, src[i], 9, fixed_color);
        }
    }
    
    // bo static
    bool patterns_load(char src[][11], int32_t src_n)
    {
        FILE *f = fopen_data_file("moggy.patterns", "r");
        if (!f) return false;

        int32_t i;
        for (i = 0; i < src_n; i++) {
            char line[32];
            if (!fgets(line, sizeof(line), f))
                goto error;
            int32_t l = (int32_t)strlen(line);
            if (l != 10 + (line[l - 1] == '\n'))
                goto error;
            memcpy(src[i], line, 10);
        }
        printf("moggy.patterns: %d patterns loaded\n", i);
        fclose(f);
        return true;
    error:
        printf("Error loading moggy.patterns.\n");
        fclose(f);
        return false;
    }
    
    void pattern3s_init(struct pattern3s *p, char src[][11], int32_t src_n)
    {
        /*char nsrc[src_n][11];
        
        if (!patterns_load(nsrc, src_n)) {
            // Use default pattern set.
            for (int32_t i = 0; i < src_n; i++)
                strcpy(nsrc[i], src[i]);
        }
        
        patterns_gen(p, nsrc, src_n);*/
        
        char (*nsrc)[11] = new char[src_n][11];
        
        if (!patterns_load(nsrc, src_n)) {
            // Use default pattern set.
            for (int32_t i = 0; i < src_n; i++)
                strcpy(nsrc[i], src[i]);
        }
        
        patterns_gen(p, nsrc, src_n);
        
        delete [] nsrc;
    }
    
    // bo static
    void p3hashes_init(void)
    {
        printf("chu y: p3hashes_init\n");
        /* tuned for 11482 collisions */
        /* XXX: tune better */
        hash_t h = 0x35373c;
        for (int32_t i = 0; i < 8; i++) {
            for (int32_t a = 0; a < 2; a++) {
                p3hashes[i][a][S_NONE] = (h = h * 16803-7);
                p3hashes[i][a][S_BLACK] = (h = h * 16805-2);
                p3hashes[i][a][S_WHITE] = (h = h * 16807-11);
                p3hashes[i][a][S_OFFBOARD] = (h = h * 16809+7);
            }
        }
    }
}
