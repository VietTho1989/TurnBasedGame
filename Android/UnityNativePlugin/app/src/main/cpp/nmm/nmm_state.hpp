/*
* Copyright (C) 2015 Sergio Nunes da Silva Junior 
*
* C++ Nine Men's Morris Agent using alpha-beta prunning algorithm
* Assignment of Artificial Intelligence Course - 2/2015
*
* This program is free software; you can redistribute it and/or modify it
* under the terms of the GNU General Public License as published by the Free
* Software Foundation; either version 2 of the License.
*
* This program is distributed in the hope that it will be useful, but WITHOUT
* ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
* FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
* more details.
*
* author: Sergio Nunes da Silva Junior
* contact: sergio.nunes@dcc.ufmg.com.br
* Universidade Federal de Minas Gerais (UFMG) - Brazil
*/

#ifndef NMM_STATE_H
#define NMM_STATE_H

#include <stdio.h>
#include <memory>
#include "nmm_board.hpp"

using namespace std;

namespace NMM
{
    
    struct Move
    {
    public:
        int32_t moved = -1;
        int32_t moved_to = -1;
        NMMAction action = Place;
        bool mill = false;
        int32_t removed = -1;
        
    public:
        static int32_t getByteSize()
        {
            int32_t ret = 0;
            {
                // int32_t moved
                ret+= sizeof(int32_t);
                // int32_t moved_to;
                ret+= sizeof(int32_t);
                // NMMAction action
                ret+= sizeof(int32_t);
                // bool mill
                ret+= sizeof(bool);
                // int32_t removed
                ret+= sizeof(int32_t);
            }
            return ret;
        }
        
        static int32_t convertToByteArray(Move* move, uint8_t* &byteArray)
        {
            int32_t length = Move::getByteSize();
            uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
            {
                int32_t pointerIndex = 0;
                // int32_t moved
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &move->moved, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: moved: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t moved_to;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &move->moved_to, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: moved_to: %d, %d\n", pointerIndex, length);
                    }
                }
                // NMMAction action
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &move->action, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: action: %d, %d\n", pointerIndex, length);
                    }
                }
                // bool mill
                {
                    int32_t size = sizeof(bool);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &move->mill, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: mill: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t removed
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &move->removed, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: removed: %d, %d\n", pointerIndex, length);
                    }
                }
                // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
            }
            byteArray = ret;
            return length;
        }
        
        static int32_t parseByteArray(Move* move, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
        {
            int32_t pointerIndex = start;
            int32_t index = 0;
            bool isParseCorrect = true;
            while (pointerIndex < length) {
                bool alreadyPassAll = false;
                switch (index) {
                    case 0:
                        // int32_t moved
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&move->moved, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: moved: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 1:
                        // int32_t moved_to;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&move->moved_to, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: moved_to: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 2:
                        // NMMAction action
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&move->action, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: action: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 3:
                        // bool mill
                    {
                        int32_t size = sizeof(bool);
                        if(pointerIndex+size<=length){
                            memcpy(&move->mill, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: mill: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 4:
                        // int32_t removed
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&move->removed, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: removed: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    default:
                    {
                        // printf("unknown index: %d\n", index);
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
            if(canCorrect){
                
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
        
    };
    
    class State
    {
    public:
        State()
        {
            printf("state constructor\n");
            moved = -1;
            moved_to = -1;
            action = Place;
            mill = false;
            terminal = false;
            removed = -1;
            utility = 0;
            turn = 0;
        }
        /*
         Construtor do State
         @param board, guarda o estado do jogo.
         @param piece, a posição inicial da peça jogada.
         @param a, a ação tomada pela peça naquele turno
         @param utility, a utilidade calculada para aquele estado do tablueiro
         @param finish, diz se naquele estado o jogo acabou.
         @param white_win, diz se o branco ganhou, valor atrelado ao finish
         @param mill, diz se formou um mill nesse estado
         @param removed, se houver um mill a posição da peça removida
         */
        State(shared_ptr<Board> b, int32_t piece, NMMAction a, float utility, bool finish, bool mill = false, int32_t removed = -1)
        : board(b), moved(piece), action(a), mill(mill), terminal(finish), removed(removed), utility(utility){
        }
        
        ~State()
        {
            std::get_deleter<SmrtBoard>(board);
        }
        
        shared_ptr<Board> board;
        int32_t moved = -1;
        int32_t moved_to = -1;
        NMMAction action = Place;
        bool mill = false;
        bool terminal = false;
        int32_t removed = -1;
        float utility = 0;
        
        int32_t turn = 0;
        
        bool isWhiteTurn()
        {
            return turn%2==0;
        }
        
        GamePhase getPhase()
        {
            if(turn>=18){
                return Playing;
            }else{
                return Positioning;
            }
        }
        
        friend std::ostream& operator<<(std::ostream& out, State *n)
        {
            out << *n;
            return out;
        }
        
        friend std::ostream& operator<<(std::ostream& out, State &n)
        {
            std:: string ended = n.terminal ? "true" : "false";
            
            // char* c = new char[10];
            char c[10];
#if WIN32
            itoa(n.removed,c , 10);
#else
            snprintf(c, 10, "%d", n.removed);
#endif
            std:: string mill = n.mill ? " MILL(" + std::string(c) + ")" : "";
            out <<  mill << " piece: " << gPos2Id[n.moved]  << " action: "<< gAction2Str[n.action] << " utility: " << n.utility << " terminal: "
            << ended;
            return out;
        }
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
    public:
        static int32_t getByteSize()
        {
            int32_t ret = 0;
            {
                // shared_ptr<Board> board
                ret+= Board::getByteSize();
                // int32_t moved
                ret+= sizeof(int32_t);
                // int32_t moved_to;
                ret+= sizeof(int32_t);
                // NMMAction action
                ret+= sizeof(int32_t);
                // bool mill
                ret+= sizeof(bool);
                // bool terminal
                ret+= sizeof(bool);
                // int32_t removed
                ret+= sizeof(int32_t);
                // float utility
                ret+= sizeof(float);
                // int32_t turn = 0
                ret+= sizeof(int32_t);
            }
            return ret;
        }
        
        static int32_t convertToByteArray(State* state, uint8_t* &byteArray)
        {
            int32_t length = State::getByteSize();
            uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
            {
                int32_t pointerIndex = 0;
                // shared_ptr<Board> board
                {
                    uint8_t* boardByteArray;
                    int32_t size = Board::convertToByteArray (state->board.get(), boardByteArray);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, boardByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: board: %d, %d\n", pointerIndex, length);
                    }
                    free(boardByteArray);
                }
                // int32_t moved
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &state->moved, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: moved: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t moved_to;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &state->moved_to, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: moved_to: %d, %d\n", pointerIndex, length);
                    }
                }
                // NMMAction action
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &state->action, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: action: %d, %d\n", pointerIndex, length);
                    }
                }
                // bool mill
                {
                    int32_t size = sizeof(bool);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &state->mill, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: mill: %d, %d\n", pointerIndex, length);
                    }
                }
                // bool terminal
                {
                    int32_t size = sizeof(bool);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &state->terminal, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: terminal: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t removed
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &state->removed, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: removed: %d, %d\n", pointerIndex, length);
                    }
                }
                // float utility
                {
                    int32_t size = sizeof(float);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &state->utility, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: utility: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t turn = 0
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &state->turn, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: turn: %d, %d\n", pointerIndex, length);
                    }
                }
                // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
            }
            byteArray = ret;
            return length;
        }
        
        static int32_t parseByteArray(State* state, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
        {
            int32_t pointerIndex = start;
            int32_t index = 0;
            bool isParseCorrect = true;
            while (pointerIndex < length) {
                bool alreadyPassAll = false;
                switch (index) {
                    case 0:
                    // shared_ptr<Board> board
                    {
                        int32_t boardByteLength = Board::parseByteArray (state->board.get(), bytes, length, pointerIndex, canCorrect);
                        if (boardByteLength > 0) {
                            pointerIndex+= boardByteLength;
                        } else {
                            printf("cannot parse board\n");
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 1:
                    // int32_t moved
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&state->moved, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: moved: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 2:
                    // int32_t moved_to;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&state->moved_to, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: moved_to: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 3:
                    // NMMAction action
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&state->action, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: action: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 4:
                    // bool mill
                    {
                        int32_t size = sizeof(bool);
                        if(pointerIndex+size<=length){
                            memcpy(&state->mill, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: mill: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 5:
                    // bool terminal
                    {
                        int32_t size = sizeof(bool);
                        if(pointerIndex+size<=length){
                            memcpy(&state->terminal, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: terminal: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 6:
                        // int32_t removed
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&state->removed, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: removed: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 7:
                        // float utility
                    {
                        int32_t size = sizeof(float);
                        if(pointerIndex+size<=length){
                            memcpy(&state->utility, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: utility: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 8:
                        // int32_t turn = 0
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&state->turn, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: turn: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    default:
                    {
                        // printf("unknown index: %d\n", index);
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
            if(canCorrect){

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
        
    };
#define SmrtState std::shared_ptr<State>
}

#endif
