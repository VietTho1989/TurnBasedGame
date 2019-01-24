//
//  move.cpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <ctype.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "weiqi_board.hpp"
#include "weiqi_move.hpp"
#include "../Platform.h"

namespace weiqi
{
    /* The S_OFFBOARD margin is not addressable by coordinates. */
    
    const char asdf[] = "abcdefghjklmnopqrstuvwxyz";
    
    void coord2bstr(char* ret, coord_t c, struct board *board)
    {
        ret[0] = 0;
        if (is_pass(c)) {
            // strcpy(ret, "pass");
            sprintf(ret, "%spass", ret);
            return;
        } else if (is_resign(c)) {
            // strcpy(ret, "resign");
            sprintf(ret, "%sresign", ret);
            return;
        } else {
            // Some GTP servers are broken and won't grok lowercase coords
            if(board!=NULL){
                board_statics* board_statics = &board->board_statics;
                snprintf(ret, 20, "%c%d", toupper(asdf[coord_x(board_statics, c, board) - 1]), coord_y(board_statics, c, board));
            } else{
                printf("error, board null\n");
            }
        }
    }
    
    /* Return coordinate in dynamically allocated buffer. */
    void coord2str(char* ret, coord_t c, struct board *board)
    {
        coord2bstr(ret, c, board);
    }
    
    /* Return coordinate in statically allocated buffer, with some backlog for
     * multiple independent invocations. Useful for debugging. */
    void coord2sstr(char* ret, coord_t c, struct board *board)
    {
        coord2bstr(ret, c, board);
    }
    
    /* No sanity checking */
    coord_t str2coord(char *str, int32_t size)
    {
        if (!strcasecmp(str, "pass"))
            return pass;
        if (!strcasecmp(str, "resign"))
            return resign;
        
        char xc = tolower(str[0]);
        return xc - 'a' - (xc > 'i') + 1 + atoi(str + 1) * size;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////// convert /////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////

    int32_t move::convertToByteArray(struct move* move, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = move::getByteSize();
        byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // convert properties
            {
                // coord_t coord;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = move->coord;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: coord: %d, %d\n", pointerIndex, length);
                    }
                }
                // enum stone color;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = move->color;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: color: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // check return
            if(pointerIndex!=length){
                printf("error: convert not correct: %d; %d\n", pointerIndex, length);
            }else{
                // printf("convert byte array correct\n");
            }
        }
        return length;
    }

    int32_t move::parseByteArray(struct move* move, uint8_t* positionBytes, int32_t length, int32_t start)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // coord_t coord;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&move->coord, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: coord: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                    // enum stone color;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = 0;
                        memcpy(&value, positionBytes + pointerIndex, size);
                        move->color = (stone)value;
                        pointerIndex+=size;
                    }else{
                        printf("length error: color: %d, %d\n", pointerIndex, length);
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
}
