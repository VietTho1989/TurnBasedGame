//
//  dragon.cpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <stdio.h>
#include <stdlib.h>

#define QUICK_BOARD_CODE

#include "weiqi_dragon.hpp"

namespace weiqi
{
    // bo static
    void print_handler(struct board *board, coord_t c, void *data, char* buf)
    {
        // static char buf[64];
        group_t dragon = *(group_t*)data;
        if (dragon_at(board, c) == dragon) {
            sprintf(buf, "%s%c%s", "\x1b[40;33;1m", stone2char(board_at(board, c)), "\x1b[0m");
        }else{
            sprintf(buf, "%s%c%s", "", stone2char(board_at(board, c)), "");
        }
    }
    
    void dragon_print(struct board *board, char* f, group_t dragon, char* buf)
    {
        // TODO can xem lai board_hprint(board, f, print_handler, &dragon, buf);
    }
    
    char boldGold[]= "\x1b[40;33;1m"; // gold
    char boldGreen[] = "\x1b[40;32;1m"; // green
    char boldRed[] = "\x1b[40;31;1m"; // red
    char boldBlue[] = "\x1b[40;34;1m"; // blue
    char boldPurple[] = "\x1b[40;35;1m"; // purple
    char boldLBlue[] = "\x1b[40;36;1m"; // lblue
    char boldWhite[] = "\x1b[40;37;1m"; // white
    // tam bo static
    char *bold_colors[] = {
        boldGold,
        boldGreen,
        boldRed,
        boldBlue,
        boldPurple,
        boldLBlue,
        boldWhite
    };
    
    char normalGold[] = "\x1b[40;33m"; // gold
    char normalGreen[] = "\x1b[40;32m"; // green
    char normalRed[] = "\x1b[40;31m"; // red
    char normalBlue[] = "\x1b[40;34m"; // blue
    char normalPurple[] = "\x1b[40;35m"; // purple
    char normalLBlue[] = "\x1b[40;36m"; // lblue
    char normalWhite[] = "\x1b[40;37m"; // white, must be last
    // tam bo static
    char *normal_colors[] = {
        normalGold,
        normalGreen,
        normalRed,
        normalBlue,
        normalPurple,
        normalLBlue,
        normalWhite,
    };
    // tam bo static
    char ansi_color_end[] = "\x1b[0m";
    
    char* pick_dragon_color(int32_t i, bool bold, bool white_ok)
    {
        int32_t ncolors = sizeof(normal_colors) / sizeof(char *);
        if (!white_ok)
            ncolors--;
        if (bold)
            return bold_colors[i % ncolors];
        return normal_colors[i % ncolors];
    }
    
    // bo static
    void print_dragons(struct board *board, coord_t c, void *data, char* buf)
    {
        group_t* dragons = (group_t*)data;
        group_t d = dragon_at(board, c);
        
        if (d) {
            int32_t i;  // Dragon index
            for (i = 0; dragons[i] && dragons[i] != d; i++)
                ;
            if (!dragons[i])  {  dragons[i] = d;  }  /* Add new */
            
            char* before = pick_dragon_color(i, (c == d), true);  // Dragon base: bold
            char* after = ansi_color_end;
            sprintf(buf, "%s%c%s", before, stone2char(board_at(board, c)), after);
        }else{
            sprintf(buf, "%s%c%s", "", stone2char(board_at(board, c)), "");
        }
    }
    
    void board_print_dragons(struct board *board, char* f, char* buf)
    {
        // TODO group_t dragons[BOARD_MAX_GROUPS] = { 0, };
        // TODO can xem lai board_hprint(board, f, print_dragons, dragons, buf);
    }
    
#define no_stone_at(c)          (board_at(b, (c)) == S_NONE)
#define own_stone_at(c)         (board_at(b, (c)) == color)
#define enemy_stone_at(c)       (board_at(b, (c)) == stone_other(color))
#define no_stone_atxy(x, y)     (board_atxy(b, (x), (y)) == S_NONE)
#define own_stone_atxy(x, y)    (board_atxy(b, (x), (y)) == color)
#define enemy_stone_atxy(x, y)  (board_atxy(b, (x), (y)) == stone_other(color))
    
    
    /* Check if g and g2 are virtually connected through lib.
     * c2 is a stone of g2 next to lib */
    // bo static
    bool virtual_connection_at(struct board *b, enum stone color, coord_t lib, coord_t c2, group_t g1, group_t g2)
    {
        {
            // assert(board_at(b, lib) == S_NONE);
            if(!(board_at(b, lib) == S_NONE)){
                printf("error, assert(board_at(b, lib) == S_NONE)\n");
            }
        }
        {
            // assert(board_at(b, c2) == color);
            if(!(board_at(b, c2) == color)){
                printf("error, assert(board_at(b, c2) == color)\n");
            }
        }
        {
            // assert(group_at(b, c2) == g2);
            if(!(group_at(b, c2) == g2)){
                printf("error, assert(group_at(b, c2) == g2)\n");
            }
        }
        
        /* Eye / Hanging connection ? */
        if (is_controlled_eye_point(b, lib, color))
            return true;
        
        /* Diagonal connection ? */
        board_statics* board_statics = &b->board_statics;
        int32_t x2 = coord_x(board_statics, c2, b);
        int32_t y2 = coord_y(board_statics, c2, b);
        foreach_diag_neighbor(board_statics, b, c2) {
            if (board_at(b, c) != color || group_at(b, c) != g1)
                continue;
            int32_t x = coord_x(board_statics, c, b);    coord_t d1 = coord_xy(b, x, y2);
            int32_t y = coord_y(board_statics, c, b);    coord_t d2 = coord_xy(b, x2, y);
            if (no_stone_at(d1) && no_stone_at(d2))
                return true;
        } foreach_diag_neighbor_end;

        int32_t x = coord_x(board_statics, lib, b);
        int32_t dx = coord_dx(board_statics, lib, c2, b);
        int32_t y = coord_y(board_statics, lib, b);
        int32_t dy = coord_dy(board_statics, lib, c2, b);
        int32_t x1 = x + dx;
        int32_t y1 = y + dy;
        coord_t c1 = coord_xy(b, x1, y1);  // other side of lib wrt c2
        
        /* Bamboo joint or stronger ? */
        if ( own_stone_at(c1) && group_at(b, c1) == g1 &&
            ( (!dx && own_stone_atxy(x1-1, y1) && own_stone_atxy(x2-1, y2) && !enemy_stone_atxy(x-1, y)) ||
             (!dx && own_stone_atxy(x1+1, y1) && own_stone_atxy(x2+1, y2) && !enemy_stone_atxy(x+1, y)) ||
             (!dy && own_stone_atxy(x1, y1-1) && own_stone_atxy(x2, y2-1) && !enemy_stone_atxy(x, y-1)) ||
             (!dy && own_stone_atxy(x1, y1+1) && own_stone_atxy(x2, y2+1) && !enemy_stone_atxy(x, y+1))   ))
            return true;
        
        /* TODO more fancy stuff ... */
        
        return false;
    }
    
    
    
    /* Handler should return -1 to stop iterating */
    typedef int32_t (*foreach_in_connected_groups_t)(struct board *b, enum stone color, coord_t c, void *data);
    
    // bo static
    int32_t foreach_in_connected_groups_(struct board *b, enum stone color, group_t g, foreach_in_connected_groups_t f, void *data, int32_t *visited)
    {
        if (visited[group_base(g)])
            return 0;
        visited[group_base(g)] = 1;
        
        foreach_in_group(b, g) {
            if (f(b, color, c, data) == -1)
                return -1;
        } foreach_in_group_end;
        
        // Look for virtually connected groups
        for (int32_t i = 0; i < board_group_info(b, g)->libs; i++) {
            coord_t lib = board_group_info(b, g)->lib[i];
            // TODO could mark liberties visited, more efficient ?
            foreach_neighbor(b, lib, {
                if (board_at(b, c) != color)
                    continue;
                group_t g2 = group_at(b, c);
                if (visited[g2] || !virtual_connection_at(b, color, lib, c, g, g2))
                    continue;
                if (foreach_in_connected_groups_(b, color, g2, f, data, visited) == -1)
                    return -1;
            });
        }
        return 0;
    }
    
    /* Call f() for each stone in dragon at @to. */
    // bo static
    void foreach_in_connected_groups(struct board *b, enum stone color, coord_t to, foreach_in_connected_groups_t f, void *data)
    {
        int32_t visited[BOARD_MAX_COORDS] = {0, };
        {
            // assert(board_at(b, to) == color);
            if(!(board_at(b, to) == color)){
                printf("error, assert(board_at(b, to) == color)\n");
            }
        }
        group_t g = group_at(b, to);
        foreach_in_connected_groups_(b, color, g, f, data, visited);
    }
    
    
    /* Handler should return -1 to stop iterating. */
    typedef int32_t (*foreach_connected_group_t)(struct board *b, enum stone color, group_t g, void *data);
    
    // bo static
    int32_t foreach_connected_group_(struct board *b, enum stone color, group_t g, foreach_connected_group_t f, void *data, int32_t *visited)
    {
        if (visited[group_base(g)])
            return 0;
        
        visited[group_base(g)] = 1;
        if (f(b, color, g, data) == -1)
            return -1;
        
        // Look for virtually connected groups
        for (int32_t i = 0; i < board_group_info(b, g)->libs; i++) {
            coord_t lib = board_group_info(b, g)->lib[i];
            // TODO could mark liberties visited, more efficient ?
            foreach_neighbor(b, lib, {
                if (board_at(b, c) != color)
                    continue;
                group_t g2 = group_at(b, c);
                if (visited[g2] || !virtual_connection_at(b, color, lib, c, g, g2))
                    continue;
                if (foreach_connected_group_(b, color, g2, f, data, visited) == -1)
                    return -1;
            });
        }
        return 0;
    }
    
    /* Call f() for each group in dragon at @to. */
    // bo static
    void foreach_connected_group(struct board *b, enum stone color, coord_t to, foreach_connected_group_t f, void *data)
    {
        int32_t visited[BOARD_MAX_COORDS] = {0, };
        {
            // assert(board_at(b, to) == color);
            if(!(board_at(b, to) == color)){
                printf("error, assert(board_at(b, to) == color)\n");
            }
        }
        group_t g = group_at(b, to);
        foreach_connected_group_(b, color, g, f, data, visited);
    }
    
    struct foreach_lib_data {
        int32_t *visited;
        foreach_in_connected_groups_t f;
        void *data;
    };
    
    // bo static
    int32_t foreach_lib_handler(struct board *b, enum stone color, group_t g, void *data)
    {
        struct foreach_lib_data* d = (struct foreach_lib_data*)data;
        for (int32_t i = 0; i < board_group_info(b, g)->libs; i++) {
            coord_t lib = board_group_info(b, g)->lib[i];
            if (d->visited[lib])
                continue;
            d->visited[lib] = 1;
            if (d->f(b, color, lib, d->data) == -1)
                return -1;
        }
        return 0;
    }
    
    /* Call f() for each liberty of dragon at @to. */
    // bo static
    void foreach_lib_in_connected_groups(struct board *b, enum stone color, coord_t to, foreach_in_connected_groups_t f, void *data)
    {
        int32_t visited[BOARD_MAX_COORDS] = {0, };
        struct foreach_lib_data d;
        {
            d.visited = visited;
            d.f = f;
            d.data = data;
        };
        foreach_connected_group(b, color, to, foreach_lib_handler, &d);
    }
    
    // bo static
    int32_t stones_all_connected_handler(struct board *b,  enum stone color, coord_t c, void *data)
    {
        int32_t* connected = (int*)data;
        connected[c] = 1;  return 0;
    }
    
    // bo static
    bool stones_all_connected(struct board *b, enum stone color, coord_t *stones, int32_t n)
    {
        // TODO optimize: check if all same group first ...
        int32_t connected[BOARD_MAX_COORDS] = {0, };
        
        foreach_in_connected_groups(b, color, stones[0], stones_all_connected_handler, connected);
        
        for (int32_t i = 0; i < n; i++)
            if (!connected[stones[i]])
                return false;
        return true;
    }
    
    /* Try to detect big eye area, ie:
     *  - completely enclosed area, not too big,
     *  - surrounding stones all connected to each other
     *  - size >= 2  (so no false eye issues)
     * Returns size of the area, or 0 if doesn't match.  */
    int32_t big_eye_area(struct board *b, enum stone color, coord_t around, int32_t *visited)
    {
        int32_t NAKADE_MAX = 8;  // min area size for living group (corner)
        // could increase to 10 (side) and 12 (middle)
        // and/or check prisoners
        coord_t area[8];// [NAKADE_MAX];
        int32_t area_n = 0;
        int32_t STONES_MAX = 50;
        int32_t stones[50];// [STONES_MAX];
        int32_t stones_n = 0;
        area[area_n++] = around;
        
        {
            // assert(!visited[around]);
            if(visited[around]){
                printf("error, assert(!visited[around])\n");
            }
        }
        for (int32_t i = 0; i < area_n; i++) {
            foreach_neighbor(b, area[i], {
                if (board_at(b, c) == S_OFFBOARD)
                    continue;
                
                if (board_at(b, c) == color) {	// Found border, save it and continue
                    bool dup = false;
                    for (int32_t j = 0; j < stones_n; j++)
                        if (c == stones[j]) {
                            dup = true;
                            break;
                        }
                    if (dup) continue;
                    
                    {
                        // assert(stones_n < STONES_MAX);
                        if(!(stones_n < STONES_MAX)){
                            printf("error, assert(stones_n < STONES_MAX)\n");
                        }
                    }
                    stones[stones_n++] = c;
                    continue;
                }
                
                // Empty spot or prisoner, add it to area
                bool dup = false;
                for (int32_t j = 0; j < area_n; j++)
                    if (c == area[j]) {
                        dup = true;
                        break;
                    }
                if (dup) continue;
                
                if (area_n >= NAKADE_MAX)
                    return 0;
                
                area[area_n++] = c;
            });
        }
        
        if (area_n < 3 || !stones_all_connected(b, color, stones, stones_n))
            return 0;
        
        // Ok good, mark area visited
        // TODO if (area_n < 7) ...
        for (int32_t i = 0; i < area_n; i++)
            visited[area[i]] = 1;
        
        return area_n;
    }
    
    
    /* Point we control:
     * Opponent can't play there or we can capture if he does.
     * TODO - could make tiger mouth check smarter (check selfatari)
     *      - handle more exotic cases (ladders ?) */
    bool is_controlled_eye_point(struct board *b, coord_t to, enum stone color)
    {
        {
            // assert(no_stone_at(to));
            if(!(no_stone_at(to))){
                printf("error, assert(no_stone_at(to))\n");
            }
        }
        
        /* Eye-like ? */
        if (!board_is_valid_play_no_suicide(b, stone_other(color), to))
            return true;
        
        /* Tiger mouth ?
         * Check no opponent stone nearby and we can't be captured.
         * also works for side connection */
        if (immediate_liberty_count(b, to) == 1) {
            int32_t good = 0;
            foreach_neighbor(b, to, {
                if (enemy_stone_at(c))
                    return false;
                if ((own_stone_at(c) && board_group_info(b, group_at(b, c))->libs > 1) ||
                    board_at(b, c) == S_OFFBOARD)
                    good++;
            });
            return (good == 3);
        }
        
        return false;
    }
    
    // bo static
    bool real_eye_endpoint(struct board *board, coord_t to, enum stone color)
    {
        // enum stone color_diag_libs[S_MAX] = {0, 0, 0, 0};
        int32_t color_diag_libs[S_MAX] = {0, 0, 0, 0};
        
        board_statics* board_statics = &board->board_statics;
        foreach_diag_neighbor(board_statics, board, to) {
            color_diag_libs[(enum stone) board_at(board, c)]++;
        } foreach_diag_neighbor_end;
        /* We need to control 3 corners of the eye in the middle of the board,
         * 2 on the side, and 1 in the corner. */
        if (color_diag_libs[S_OFFBOARD]) {
            color_diag_libs[color] += color_diag_libs[S_OFFBOARD] - 1;
            color_diag_libs[stone_other(color)]++;
        }
        
        /* Corners could be eye-like too ... */
        foreach_diag_neighbor(board_statics, board, to) {
            if (color_diag_libs[color] >= 3)		return true;
            if (color_diag_libs[stone_other(color)] >= 2)	return false;
            
            if (board_at(board, c) != S_NONE)
                continue;
            if (is_controlled_eye_point(board, c, color))   /* No need to recurse, thank goodness */
                color_diag_libs[color]++;
            else
                color_diag_libs[stone_other(color)]++;
        } foreach_diag_neighbor_end;
        
        return (color_diag_libs[color] >= 3);
    }
    
    /* Point is finished one point eye.
     * (board_is_one_point_eye() ones can become false later ...) */
    // bo static
    bool is_real_one_point_eye(struct board *b, coord_t to, enum stone color)
    {
        return (board_is_eyelike(b, to, color) && real_eye_endpoint(b, to, color));
    }
    
    // bo static
    bool is_real_two_point_eye(struct board *b, coord_t to, enum stone color, coord_t *pother)
    {
        if ((neighbor_count_at(b, to, color) +
             neighbor_count_at(b, to, S_OFFBOARD)) != 3)
            return false;
        coord_t other = pass;
        foreach_neighbor(b, to, {	/* Find the other point ... */
            if ((board_at(b, c) == S_NONE ||
                 board_at(b, c) == stone_other(color)) &&
                (neighbor_count_at(b, c, color) +
                 neighbor_count_at(b, c, S_OFFBOARD)) == 3) {
                    other = c;
                    break;
                }
        });
        *pother = other;
        
        return (!is_pass(other) &&
                real_eye_endpoint(b, to, color) &&
                real_eye_endpoint(b, other, color));
    }
    
    struct safe_data {
        int32_t *visited;
        int32_t *eyes;
    };
    
    // bo static
    int32_t count_eyes(struct board *b, enum stone color, coord_t lib, void *data)
    {
        struct safe_data* d = (struct safe_data*)data;
        if (d->visited[lib])  /* Don't visit big eyes multiple times */
            return 0;
        
        if (is_real_one_point_eye(b, lib, color))  {
            if (++(*d->eyes) >= 2)
                return -1;
            return 0;
        }
        
        coord_t other = pass;
        if (is_real_two_point_eye(b, lib, color, &other))  {
            d->visited[other] = 1;
            if (++(*d->eyes) >= 2)
                return -1;
            return 0;
        }
        
        /* TODO check shape ... */
        int32_t area_size = big_eye_area(b, color, lib, d->visited);
        if (area_size) {
            *d->eyes += (area_size > 7 ? 2 : 1);
            if (*d->eyes >= 2)
                return -1;
            return 0;
        }
        
        return 0;
    }
    
    bool dragon_is_safe_full(struct board *b, group_t g, enum stone color, int32_t *visited, int32_t *eyes)
    {
        struct safe_data d;
        {
            d.visited = visited;
            d.eyes = eyes;
        };
        foreach_lib_in_connected_groups(b, color, g, count_eyes, &d);
        return (*eyes >= 2);
    }
    
    bool dragon_is_safe(struct board *b, group_t g, enum stone color)
    {
        int32_t visited[BOARD_MAX_COORDS] = {0, };
        int32_t eyes = 0;
        return dragon_is_safe_full(b, g, color, visited, &eyes);
    }
    
    // bo static
    inline bool have_group_in(group_t g, group_t *groups, int32_t ngroups)
    {
        for (int32_t i = 0; i < ngroups; i++)
            if (groups[i] == g)
                return true;
        return false;
    }
    
    // bo static
    int32_t group_neighbors(struct board *b, coord_t to, group_t *neighbors)
    {
        group_t group = group_at(b, to);
        {
            // assert(group);
            if(!group){
                printf("error, assert(group)\n");
            }
        }
        enum stone color = board_at(b, to);
        enum stone other_color = stone_other(color);

        int32_t n = 0;
        foreach_in_group(b, group) {
            foreach_neighbor(b, c, {
                if (board_at(b, c) != other_color)
                    continue;
                group_t g = group_at(b, c);
                if (have_group_in(g, neighbors, n))
                    continue;
                neighbors[n++] = g;
            });
        } foreach_in_group_end;
        return n;
    }
    
    /* At least one neighbor is safe */
    bool neighbor_is_safe(struct board *b, group_t g)
    {
        group_t neighbors[BOARD_MAX_GROUPS];
        int32_t n = group_neighbors(b, g, neighbors);
        for (int32_t i = 0; i < n; i++)
            if (dragon_is_safe(b, neighbors[i], board_at(b, neighbors[i])))
                return true;
        return false;
    }
    
    // bo static
    int32_t count_libs(struct board *b, enum stone color, coord_t c, void *data)
    {
        int32_t* libs = (int*)data;
        (*libs)++;  return 0;
    }

    int32_t dragon_liberties(struct board *b, enum stone color, coord_t to)
    {
        int32_t libs = 0;
        foreach_lib_in_connected_groups(b, color, to, count_libs, &libs);
        return libs;
    }
    
    // bo static
    int32_t dragon_at_handler(struct board *b, enum stone color, group_t g, void *data)
    {
        group_t* d = (group_t*)data;
        *d = (*d > g ? *d : g);  return 0;
    }
    
    group_t dragon_at(struct board *b, coord_t to)
    {
        group_t g = group_at(b, to);
        group_t d = 0;
        enum stone color = board_at(b, to);
        if (!g)
            return 0;
        
        foreach_connected_group(b, color, to, dragon_at_handler, &d);
        return d;
    }
    
    
#define		GAP_LENGTH        4
    
    /* Vertical gap ? */
    // bo static
    inline bool is_vert_gap(struct board *b, enum stone color, int32_t *connected, int32_t lx, int32_t ly, int32_t x, int32_t dy)
    {
        {
            // assert(dy);
            if(!dy){
                printf("error, assert(dy)\n");
            }
        }
        for (int32_t i = 0; i < GAP_LENGTH; i++) {
            int32_t y = ly + dy * i;
            coord_t d = coord_xy(b, x, y);
            if (board_at(b, d) == S_NONE)
                continue;
            if (board_at(b, d) == color && !connected[d])
                return false; // reach other group, could still be cut though ...
            if (board_at(b, d) == color && connected[d])
                return false; // wrong direction
            return false;
        }
        return true;
    }
    
    /* Horizontal gap ? */
    // bo static
    inline bool is_horiz_gap(struct board *b, enum stone color, int32_t *connected, int32_t lx, int32_t ly, int32_t y, int32_t dx)
    {
        {
            // assert(dx);
            if(!dx){
                printf("error, is_horiz_gap\n");
            }
        }
        for (int32_t i = 0; i < GAP_LENGTH; i++) {
            int32_t x = lx + dx * i;
            coord_t d = coord_xy(b, x, y);
            if (board_at(b, d) == S_NONE)
                continue;
            if (board_at(b, d) == color && !connected[d])
                return false; // reach other group, could still be cut though ...
            if (board_at(b, d) == color && connected[d])
                return false; // wrong direction
            return false;
        }
        return true;
    }
    
#define vert_gap(x, dy)  is_vert_gap(b,  color, connected, lx, ly,   x, dy)
#define horiz_gap(y, dx) is_horiz_gap(b, color, connected, lx, ly,   y, dx)
    
    /* Looking for 2-stones horizontal/vertical gap of length GAP_LENGTH extending
     * outwards from lib. For example, something like this:
     *
     *    . X X . . .        X X X X X . . .
     *    . O . X . .        X O O O * * * *
     *    . O * * * *        X O . O * * * *
     *    . O * * * *        X . O . . . . .
     *    . O . X . .      
     */
    // bo static
    bool two_stones_gap(struct board *b, enum stone color, coord_t lib, int32_t *connected)
    {
        board_statics* board_statics = &b->board_statics;
        int32_t lx = coord_x(board_statics, lib, b);
        int32_t ly = coord_y(board_statics, lib, b);
        
        for (int32_t dx = -1; dx <= 1; dx++)
            for (int32_t dy = -1; dy <= 1; dy++) {
                if (dy && !dx) 
                    if ( vert_gap(lx, dy) &&  // center gap + 1 on either side
                        (vert_gap(lx - 1, dy) || vert_gap(lx + 1, dy)) )
                        return true;			
                if (dx && !dy) 
                    if ( horiz_gap(ly, dx) &&  // center gap + 1 on either side
                        (horiz_gap(ly - 1, dx) || horiz_gap(ly + 1, dx)) ) 
                        return true;	
            }
        return false;
    }
    
    // bo static
    int32_t mark_connected(struct board *b,  enum stone color, coord_t c, void *data)
    {
        int32_t* connected = (int*)data;
        connected[c] = 1;  return 0;
    }
    
    struct surrounded_data {
        int32_t *connected;
        bool surrounded;
    };
    
    // bo static
    int32_t surrounded_check(struct board *b,  enum stone color, coord_t lib, void *data)
    {    
        struct surrounded_data* d = (struct surrounded_data*)data;
        if (two_stones_gap(b, color, lib, d->connected)) {	
            d->surrounded = 0;    return -1;   
        }
        /* Other group we could connect to ? */
        foreach_neighbor(b, lib, {
            if (board_at(b, c) == color && !d->connected[c]) {
                with_move(b, lib, color, {
                    if (!group_at(b, lib))
                        break;
                    d->surrounded = dragon_is_surrounded(b, lib);
/*#ifndef Android
                    with_move_return(-1);
#else
                    
#endif*/
                    int32_t val_ = -1;
                    do { int32_t val__ = (val_); board_quick_undo(board__, &m_, &u_); return val__;  } while (0);
                });
            }
        });
        return 0;
    }
    
    bool dragon_is_surrounded(struct board *b, coord_t to)
    {
        enum stone color = board_at(b, to);
        {
            // assert(color == S_BLACK || color == S_WHITE);
            if(!(color == S_BLACK || color == S_WHITE)){
                printf("error, assert(color == S_BLACK || color == S_WHITE)\n");
            }
        }
        int32_t connected[BOARD_MAX_COORDS] = {0, };
        
        /* Mark connected stones */
        foreach_in_connected_groups(b, color, to, mark_connected, connected);
        
        struct surrounded_data d;
        {
            d.connected = connected;
            d.surrounded = 1;
        };
        foreach_lib_in_connected_groups(b, color, to, surrounded_check, &d);
        return d.surrounded;
    }
}
