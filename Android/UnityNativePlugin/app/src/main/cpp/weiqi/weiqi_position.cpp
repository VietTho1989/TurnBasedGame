//
//  position.cpp
//  weiqi
//
//  Created by Viet Tho on 3/29/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "weiqi_position.hpp"
#include "weiqi_board.hpp"

#include "../Platform.h"
#include "uct/weiqi_uct.hpp"

namespace weiqi
{
    
    void Position::updateScoreAndOwnerMap()
    {
        struct move_queue q;
        {
            q.moves = 0;
        }
        {
            struct board board;
            board_copy(&board, &b);
            // make uct
            struct uct* u = uct_state_init(NULL, &board);
            // init thread
            {
#ifndef UsePThread
                // init
                boost::thread* thread_manager = NULL;
                boost::mutex* finish_mutex = new boost::mutex();// (0);
                boost::condition_variable* finish_cond = new boost::condition_variable();// (0);
                // volatile int finish_thread;
                boost::mutex* finish_serializer = new boost::mutex();// (0);
                // set
                u->thread_manager = thread_manager;
                u->finish_mutex = finish_mutex;
                u->finish_cond = finish_cond;
                u->finish_thread = 0;// -1;
                u->finish_serializer = finish_serializer;
#else
                // init
                pthread_t thread_manager;
                pthread_mutex_t finish_mutex = PTHREAD_MUTEX_INITIALIZER;
                pthread_cond_t finish_cond = PTHREAD_COND_INITIALIZER;
                // volatile int finish_thread;
                pthread_mutex_t finish_serializer = PTHREAD_MUTEX_INITIALIZER;
                // set
                u->thread_manager = &thread_manager;
                u->finish_mutex = &finish_mutex;
                u->finish_cond = &finish_cond;
                u->finish_thread = 0;// -1;
                u->finish_serializer = &finish_serializer;
#endif
            }
            // find dead group list
            uct_dead_group_list(u, &board, &q);
            // update position
            {
                // struct move_queue deadgroup;
                memcpy(&deadgroup, &q, sizeof(struct move_queue));
            }
            // release data
            my_uct_done(u);
        }
        // update score
        my_board_official_score_and_dame(this, &q);
    }

    int32_t Position::getByteSize()
    {
        int32_t ret = 0;
        {
            // struct board b;
            ret+=b.getByteSize();
            // struct move_queue deadgroup;
            ret+=sizeof(struct move_queue);
            // int32_t scoreOwnerMap[(BOARD_MAX_SIZE+2)*(BOARD_MAX_SIZE+2)];
            ret+=(BOARD_MAX_SIZE+2)*(BOARD_MAX_SIZE+2)*sizeof(int32_t);
            // int32_t scoreOwnerMapSize = 0;
            ret+=sizeof(int32_t);
            // int32_t scoreBlack = 0;
            ret+=sizeof(int32_t);
            // int32_t scoreWhite = 0;
            ret+=sizeof(int32_t);
            // int32_t dame = 0;
            ret+=sizeof(int32_t);
            // float score = 0;
            ret+=sizeof(float);
        }
        return ret;
    }

    int32_t Position::convertToByteArray(struct Position* position, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = position->getByteSize();
        byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // convert property
            {
                // struct board b;
                {
                    uint8_t* boardByteArray;
                    int32_t size = board::convertToByteArray(&position->b, boardByteArray);
                    // write
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, boardByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: b: %d, %d\n", pointerIndex, length);
                    }
                    free(boardByteArray);
                }
                // struct move_queue deadgroup;
                {
                    int32_t size = sizeof(struct move_queue);
                    if(pointerIndex+size<=length){
                        struct move_queue value = position->deadgroup;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: deadgroup: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t scoreOwnerMap[(BOARD_MAX_SIZE+2)*(BOARD_MAX_SIZE+2)];
                {
                    int32_t size = (BOARD_MAX_SIZE+2)*(BOARD_MAX_SIZE+2)*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &position->scoreOwnerMap, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: scoreOwnerMap: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t scoreOwnerMapSize = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->scoreOwnerMapSize;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: scoreOwnerMapSize: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t scoreBlack = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->scoreBlack;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: scoreBlack: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t scoreWhite = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->scoreWhite;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: scoreWhite: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t dame = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->dame;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: dame: %d, %d\n", pointerIndex, length);
                    }
                }
                // float score = 0;
                {
                    int32_t size = sizeof(float);
                    if(pointerIndex+size<=length){
                        float value = position->score;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: score: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // check convert correct
            if(pointerIndex!=length){
                printf("error: convert not correct: %d; %d\n", pointerIndex, length);
            }else{
                // printf("convert byte array correct\n");
            }
        }
        return length;
    }

    int32_t Position::parseByteArray(struct Position* position, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // struct board b;
                {
                    // printf("position parse: b: %d\n", pointerIndex);
                    int32_t boardByteLength = board::parseByteArray(&position->b, positionBytes, length, pointerIndex, canCorrect);
                    if (boardByteLength > 0) {
                        pointerIndex+= boardByteLength;
                    } else {
                        printf("error, cannot parse: board\n");
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                    // struct move_queue deadgroup;
                {
                    // printf("position parse: deadgroup: %d\n", pointerIndex);
                    int32_t size = sizeof(struct move_queue);
                    if(pointerIndex+size<=length){
                        memcpy(&position->deadgroup, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: deadgroup: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                    // int32_t scoreOwnerMap[(BOARD_MAX_SIZE+2)*(BOARD_MAX_SIZE+2)];
                {
                    // printf("position parse: scoreOwnerMap: %d\n", pointerIndex);
                    int32_t size = (BOARD_MAX_SIZE+2)*(BOARD_MAX_SIZE+2)*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->scoreOwnerMap, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: scoreOwnerMap: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 3:
                    // int32_t scoreOwnerMapSize = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->scoreOwnerMapSize, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: scoreOwnerMapSize: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 4:
                    // int32_t scoreBlack = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->scoreBlack, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: scoreBlack: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 5:
                    // int32_t scoreWhite = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->scoreWhite, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: scoreWhite: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 6:
                    // int32_t dame = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->dame, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: dame: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 7:
                    // float score = 0;
                {
                    int32_t size = sizeof(float);
                    if(pointerIndex+size<=length){
                        memcpy(&position->score, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: score: %d, %d\n", pointerIndex, length);
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
                printf("not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // check position ok: if not, correct it
        {
            if(canCorrect){
                // TODO can hoan thien
            }
        }
        
        // return
        if (!isParseCorrect) {
            printf("error position parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }
}
