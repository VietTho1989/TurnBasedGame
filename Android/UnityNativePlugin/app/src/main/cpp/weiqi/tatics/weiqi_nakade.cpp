//
//  nakade.cpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <stdio.h>
#include <stdlib.h>

#define QUICK_BOARD_CODE

#include "weiqi_nakade.hpp"

namespace weiqi
{
#define NAKADE_MAX 6
    
    // bo static
    inline int32_t nakade_area(struct board *b, coord_t around, enum stone color, coord_t *area)
    {
        /* First, examine the nakade area. For sure, it must be at most
         * six points. And it must be within color group(s). */
        int32_t area_n = 0;
        
        area[area_n++] = around;
        
        for (int32_t i = 0; i < area_n; i++) {
            foreach_neighbor(b, area[i], {
                if (board_at(b, c) == stone_other(color))
                    return -1;
                if (board_at(b, c) == S_NONE) {
                    bool dup = false;
                    for (int32_t j = 0; j < area_n; j++)
                        if (c == area[j]) {
                            dup = true;
                            break;
                        }
                    if (dup) continue;
                    
                    if (area_n >= NAKADE_MAX) {
                        /* Too large nakade area. */
                        return -1;
                    }
                    area[area_n++] = c;
                }
            });
        }
        
        return area_n;
    }
    
    // bo static
    inline void get_neighbors(struct board *b, coord_t *area, int32_t area_n, int32_t *neighbors, int32_t *ptbynei)
    {
        /* We also collect adjecency information - how many neighbors
         * we have for each area point, and histogram of this. This helps
         * us verify the appropriate bulkiness of the shape. */
        memset(neighbors, 0, area_n * sizeof(int32_t));
        for (int32_t i = 0; i < area_n; i++) {
            for (int32_t j = i + 1; j < area_n; j++)
                if (coord_is_adjecent(area[i], area[j], b)) {
                    ptbynei[neighbors[i]]--;
                    neighbors[i]++;
                    ptbynei[neighbors[i]]++;
                    ptbynei[neighbors[j]]--;
                    neighbors[j]++;
                    ptbynei[neighbors[j]]++;
                }
        }
    }
    
    // bo static
    inline coord_t nakade_point_(coord_t *area, int32_t area_n, int32_t *neighbors, int32_t *ptbynei)
    {
        /* For each given neighbor count, arbitrary one coordinate
         * featuring that. */
        coord_t coordbynei[9];
        for (int32_t i = 0; i < area_n; i++)
            coordbynei[neighbors[i]] = area[i];
        
        switch (area_n) {
            case 1: return pass;
            case 2: return pass;
            case 3:
            {
                {
                    // assert(ptbynei[2] == 1);
                    if(!(ptbynei[2] == 1)){
                        printf("error, assert(ptbynei[2] == 1)\n");
                    }
                }
                return coordbynei[2]; // middle point
            }
            case 4: if (ptbynei[3] != 1) return pass; // int64_t line, L shape, or square
                return coordbynei[3]; // tetris four
            case 5: if (ptbynei[3] == 1 && ptbynei[1] == 1) return coordbynei[3]; // bulky five
                if (ptbynei[4] == 1) return coordbynei[4]; // cross five
                return pass; // long line
            case 6: if (ptbynei[4] == 1 && ptbynei[2] == 3)
                return coordbynei[4]; // rabbity six
                return pass; // anything else
            default:
            {
                // assert(0);
                printf("error, assert(0)\n");
            }
        }
        
        return 0; /* NOTREACHED */
    }
    
    coord_t nakade_point(struct board *b, coord_t around, enum stone color)
    {
        {
            // assert(board_at(b, around) == S_NONE);
            if(!(board_at(b, around) == S_NONE)){
                printf("error, assert(board_at(b, around) == S_NONE)\n");
            }
        }
        coord_t area[NAKADE_MAX]; int32_t area_n = 0;
        area_n = nakade_area(b, around, color, area);
        if (area_n == -1)
            return pass;

        int32_t* neighbors = new int32_t[area_n];
        int32_t ptbynei[9] = {area_n, 0};
        get_neighbors(b, area, area_n, neighbors, ptbynei);
        
        coord_t ret = nakade_point_(area, area_n, neighbors, ptbynei);
        delete [] neighbors;
        return ret;
    }
    
    bool nakade_dead_shape(struct board *b, coord_t around, enum stone color)
    {
        {
            // assert(board_at(b, around) == S_NONE);
            if(!(board_at(b, around) == S_NONE)){
                printf("error, assert(board_at(b, around) == S_NONE)\n");
            }
        }
        coord_t area[NAKADE_MAX]; int32_t area_n = 0;
        area_n = nakade_area(b, around, color, area);
        if (area_n == -1)	return false;
        if (area_n <= 3)	return true;

        int32_t* neighbors = new int32_t[area_n];
        int32_t ptbynei[9] = {area_n, 0};
        get_neighbors(b, area, area_n, neighbors, ptbynei);
        
        if (area_n == 4 && ptbynei[2] == 4){  // square 4
            delete [] neighbors;
            return true;
        }
        
        /* nakade_point() should be able to deal with the rest ... */
        coord_t nakade = nakade_point_(area, area_n, neighbors, ptbynei);
        delete [] neighbors;
        return  nakade != pass;
    }
}
