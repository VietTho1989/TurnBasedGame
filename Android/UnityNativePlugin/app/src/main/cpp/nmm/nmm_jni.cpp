//
//  nmm_jni.cpp
//  NativeCore
//
//  Created by Viet Tho on 1/3/19.
//  Copyright © 2019 Viet Tho. All rights reserved.
//

#include "nmm_jni.hpp"
#include "nmmagent.hpp"
#include "nmm_board.hpp"

namespace NMM
{
    
    int32_t nmm_makeDefaultPosition(uint8_t* &outRet)
    {
        int32_t ret = 0;
        {
            // Make position
            SmrtState root = SmrtState(new State(SmrtBoard(new Board()), 0, Place, 0, false, false));
            // printf("makeDefaultPosition: %d\n", root->removed);
            // return
            ret = State::convertToByteArray(root.get(), outRet);
        }
        return ret;
    }
    
    int32_t nmm_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        int32_t ret = 0;
        // make position
        SmrtState root = SmrtState(new State(SmrtBoard(new Board()), 0, Place, 0, false, false));
        {
            State::parseByteArray(root.get(), positionBytes, length, 0, canCorrect);
        }
        // check
        {
            if(root->turn>=DrawTurn){
                ret = 3;
            }else{
                if(root->isWhiteTurn()){
                    // white turn
                    if(root->board->get_num_white_pieces()<=2 && root->getPhase()==Playing){
                        // don't have enough pieces
                        ret = 2;
                    }else{
                        // have any move?
                        // make agent
                        NMMAgent* a = new NMMAgent();
                        {
                            int32_t aphase1[6] = {18, 26, 1, 6, 12, 7};
                            int32_t aphase2[7] = {14, 43, 10, 8, 7, 47, 1086};
                            int32_t aphase3[4] = {10, 1, 16, 1190};
                            a->set_evaluator_weights(aphase1, aphase2, aphase3);
                            a->set_color_pieces(true);
                        }
                        // set agent
                        a->set_game_phase(root->getPhase());
                        a->set_color_pieces(true);
                        // get successor state
                        std::vector<SmrtState> suc = a->expand(root, true);
                        if(suc.size()<=0){
                            // don't have any move
                            ret = 2;
                        }
                        // free data
                        {
                            delete a->eval;
                            delete a;
                        }
                    }
                }else{
                    // black turn
                    if(root->board->get_num_black_pieces()<=2 && root->getPhase()==Playing){
                        // don't have enough pieces
                        ret = 1;
                    }else{
                        // have any move?
                        // make agent
                        NMMAgent* b = new NMMAgent();
                        {
                            int32_t bphase1[6] = {18, 26, 1, 6, 21, 7};
                            int32_t bphase2[7] = {42, 28, 16, 8, 24, 19, 949};
                            int32_t bphase3[4] = {23, 18, 5, 1096};
                            b->set_evaluator_weights(bphase1, bphase2, bphase3);
                            b->set_color_pieces(false);
                        }
                        // set agent
                        b->set_game_phase(root->getPhase());
                        b->set_color_pieces(false);
                        // get successor state
                        std::vector<SmrtState> suc = b->expand(root, false);
                        if(suc.size()<=0){
                            // don't have any move
                            ret = 1;
                        }
                        // free data
                        {
                            delete b->eval;
                            delete b;
                        }
                    }
                }
            }
        }
        // return
        return ret;
    }
    
    int32_t nmm_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t MaxNormal, int32_t MaxPositioning, int32_t MaxBlackAndWhite3, int32_t MaxBlackOrWhite3, int32_t pickBestMove, uint8_t* &outRet)
    {
        // Make Pos
        SmrtState root = SmrtState(new State(SmrtBoard(new Board()), 0, Place, 0, false, false));
        {
            State::parseByteArray(root.get(), positionBytes, length, 0, canCorrect);
        }
        // Search
        Move move;
        {
            // make agent
            NMMAgent* a = new NMMAgent();
            {
                // evaluator weight
                {
                    if(root->isWhiteTurn()){
                        int32_t aphase1[6] = {18, 26, 1, 6, 12, 7};
                        int32_t aphase2[7] = {14, 43, 10, 8, 7, 47, 1086};
                        int32_t aphase3[4] = {10, 1, 16, 1190};
                        a->set_evaluator_weights(aphase1, aphase2, aphase3);
                    }else{
                        int32_t aphase1[6] = {18, 26, 1, 6, 21, 7};
                        int32_t aphase2[7] = {42, 28, 16, 8, 24, 19, 949};
                        int32_t aphase3[4] = {23, 18, 5, 1096};
                        a->set_evaluator_weights(aphase1, aphase2, aphase3);
                    }
                }
                a->set_color_pieces(root->isWhiteTurn());
                a->set_game_phase(root->getPhase());
                // set ai paramenters
                {
                    a->MaxNormal = MaxNormal;
                    a->MaxPositioning = MaxPositioning;
                    a->MaxBlackAndWhite3 = MaxBlackAndWhite3;
                    a->MaxBlackOrWhite3 = MaxBlackOrWhite3;
                    a->eval->pickBestMove = pickBestMove;
                }
            }
            // search
            SmrtState bestRoot = a->decide(root);
            // correct bestRoot
            {
                if(bestRoot==nullptr){
                    printf("error, why cannot find best root\n");
                    std::vector<SmrtState> suc = a->expand(root, root->isWhiteTurn());
                    if(suc.size()>0){
                        bestRoot = suc[0];
                    }else{
                        printf("error, search best root: why cannot have any suc\n");
                    }
                }
            }
            // set move
            if(bestRoot!=nullptr){
                move.moved = bestRoot->moved;
                move.moved_to = bestRoot->moved_to;
                move.action = bestRoot->action;
                move.mill = bestRoot->mill;
                move.removed = bestRoot->removed;
                printf("move removed: %d, %d\n", move.removed, move.mill);
            }else{
                printf("error, why root null\n");
            }
            // free data
            {
                delete a->eval;
                delete a;
            }
        }
        // get result
        int32_t ret = 0;
        {
            ret = Move::convertToByteArray(&move, outRet);
        }
        // return
        return ret;
    }
    
    bool nmm_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength)
    {
        // Make Pos
        SmrtState root = SmrtState(new State(SmrtBoard(new Board()), 0, Place, 0, false, false));
        {
            State::parseByteArray(root.get(), positionBytes, length, 0, canCorrect);
        }
        // Make Move
        Move move;
        {
            Move::parseByteArray(&move, moveBytes, moveLength, 0, canCorrect);
        }
        // Check
        bool ret = false;
        {
            // make agent
            NMMAgent* a = new NMMAgent();
            {
                // evaluator weight
                {
                    if(root->isWhiteTurn()){
                        int32_t aphase1[6] = {18, 26, 1, 6, 12, 7};
                        int32_t aphase2[7] = {14, 43, 10, 8, 7, 47, 1086};
                        int32_t aphase3[4] = {10, 1, 16, 1190};
                        a->set_evaluator_weights(aphase1, aphase2, aphase3);
                    }else{
                        int32_t aphase1[6] = {18, 26, 1, 6, 21, 7};
                        int32_t aphase2[7] = {42, 28, 16, 8, 24, 19, 949};
                        int32_t aphase3[4] = {23, 18, 5, 1096};
                        a->set_evaluator_weights(aphase1, aphase2, aphase3);
                    }
                }
                a->set_color_pieces(root->isWhiteTurn());
                a->set_game_phase(root->getPhase());
            }
            // get successor state
            std::vector<SmrtState> suc = a->expand(root, root->isWhiteTurn());
            for(int32_t i=0; i<suc.size(); i++){
                SmrtState state = suc[i];
                // printf("successor state: %d\n", state->removed);
                if(state->moved == move.moved && state->moved_to == move.moved_to && state->action == move.action && state->mill == move.mill && state->removed == move.removed){
                    ret = true;
                    break;
                }
            }
            // free data
            {
                delete a->eval;
                delete a;
            }
        }
        // return
        return ret;
    }
    
    int32_t nmm_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, uint8_t* &outRet)
    {
        // Make Pos
        SmrtState root = SmrtState(new State(SmrtBoard(new Board()), 0, Place, 0, false, false));
        {
            State::parseByteArray(root.get(), positionBytes, length, 0, canCorrect);
        }
        // Make Move
        Move move;
        {
            Move::parseByteArray(&move, moveBytes, moveLength, 0, canCorrect);
        }
        // doMove
        {
            // make agent
            NMMAgent* a = new NMMAgent();
            {
                // evaluator weight
                {
                    if(root->isWhiteTurn()){
                        int32_t aphase1[6] = {18, 26, 1, 6, 12, 7};
                        int32_t aphase2[7] = {14, 43, 10, 8, 7, 47, 1086};
                        int32_t aphase3[4] = {10, 1, 16, 1190};
                        a->set_evaluator_weights(aphase1, aphase2, aphase3);
                    }else{
                        int32_t aphase1[6] = {18, 26, 1, 6, 21, 7};
                        int32_t aphase2[7] = {42, 28, 16, 8, 24, 19, 949};
                        int32_t aphase3[4] = {23, 18, 5, 1096};
                        a->set_evaluator_weights(aphase1, aphase2, aphase3);
                    }
                }
                a->set_color_pieces(root->isWhiteTurn());
                a->set_game_phase(root->getPhase());
            }
            // get successor state
            bool isFound = false;
            std::vector<SmrtState> suc = a->expand(root, root->isWhiteTurn());
            for(int32_t i=0; i<suc.size(); i++){
                SmrtState state = suc[i];
                if(state->moved == move.moved && state->moved_to == move.moved_to && state->action == move.action && state->mill == move.mill && state->removed == move.removed){
                    isFound = true;
                    int32_t oldTurn = root->turn;
                    root = state;
                    root->turn = oldTurn + 1;
                    if(root->turn<0){
                        printf("error, why turn < 0\n");
                        root->turn = 0;
                    }
                    break;
                }
            }
            // check found
            if(!isFound){
                printf("error, why cannot find new root\n");
            }
            // free data
            {
                delete a->eval;
                delete a;
            }
        }
        // return
        int32_t ret = State::convertToByteArray(root.get(), outRet);
        return ret;
    }
    
    int32_t nmm_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves)
    {
        // Make Pos
        SmrtState root = SmrtState(new State(SmrtBoard(new Board()), 0, Place, 0, false, false));
        {
            State::parseByteArray(root.get(), positionBytes, length, 0, canCorrect);
        }
        // get move
        int32_t outLegalMovesLength = 0;
        {
            // make agent
            NMMAgent* a = new NMMAgent();
            {
                // evaluator weight
                {
                    if(root->isWhiteTurn()){
                        int32_t aphase1[6] = {18, 26, 1, 6, 12, 7};
                        int32_t aphase2[7] = {14, 43, 10, 8, 7, 47, 1086};
                        int32_t aphase3[4] = {10, 1, 16, 1190};
                        a->set_evaluator_weights(aphase1, aphase2, aphase3);
                    }else{
                        int32_t aphase1[6] = {18, 26, 1, 6, 21, 7};
                        int32_t aphase2[7] = {42, 28, 16, 8, 24, 19, 949};
                        int32_t aphase3[4] = {23, 18, 5, 1096};
                        a->set_evaluator_weights(aphase1, aphase2, aphase3);
                    }
                }
                a->set_color_pieces(root->isWhiteTurn());
                a->set_game_phase(root->getPhase());
            }
            // get successor state
            std::vector<SmrtState> suc = a->expand(root, root->isWhiteTurn());
            // convert
            if(suc.size()>0){
                // init
                outLegalMovesLength = (int32_t)suc.size()*Move::getByteSize();
                outLegalMoves = (uint8_t*)calloc(outLegalMovesLength, sizeof(uint8_t));
                // copy bytes
                {
                    for(int32_t i=0; i<suc.size(); i++){
                        uint8_t* moveBytes;
                        {
                            Move move;
                            {
                                SmrtState state = suc[i];
                                // set
                                move.moved = state->moved;
                                move.moved_to = state->moved_to;
                                move.action = state->action;
                                move.mill = state->mill;
                                move.removed = state->removed;
                            }
                            Move::convertToByteArray(&move, moveBytes);
                        }
                        memcpy(outLegalMoves + Move::getByteSize()*i, moveBytes , Move::getByteSize());
                        free(moveBytes);
                    }
                }
            }else{
                printf("why don't have any legal moves\n");
            }
            // free data
            {
                delete a->eval;
                delete a;
            }
        }
        return outLegalMovesLength;
    }
    
    int32_t nmm_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrPosition)
    {
        // make pos
        SmrtState root = SmrtState(new State(SmrtBoard(new Board()), 0, Place, 0, false, false));
        {
            State::parseByteArray(root.get(), positionBytes, length, 0, canCorrect);
        }
        // make strPosition
        int32_t outLength = 0;
        {
            // get
            char ret[1000];
            {
                root->board->print(ret);
                printf("\n%s\n", ret);
            }
            // make
            {
                outLength = (int32_t)(strlen(ret) + 1);
                // make out
                {
                    outStrPosition = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outStrPosition, ret, outLength);
                }
            }
        }
        // return
        return outLength;
    }
    
}
