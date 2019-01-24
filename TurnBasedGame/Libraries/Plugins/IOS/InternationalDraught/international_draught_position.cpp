//
//  Position.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "international_draught_position.hpp"
#include "international_draught_move.hpp"
#include "international_draught_fen.hpp"
#include "../Platform.h"

namespace InternationalDraught
{
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// Book /////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    char BookPath[1024];
    
    std::mutex bookMutext;
    
    book::Book* bookNormal = NULL;
    book::Book* bookKiller = NULL;
    book::Book* bookBT = NULL;
    
    book::Book* getBook(Variant_Type variantType)
    {
        // get immediately
        {
            switch (variantType) {
                case Normal:
                {
                    if(bookNormal!=NULL){
                        return bookNormal;
                    }else{
#ifdef Android
                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "bookNormal null\n");
#else
                        printf("bookNormal null\n");
#endif
                    }
                }
                    break;
                case Killer:
                {
                    if(bookKiller!=NULL){
                        return bookKiller;
                    }else{
#ifdef Android
                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "bookKiller null\n");
#else
                        printf("bookKiller null\n");
#endif
                    }
                }
                    break;
                case BT:
                {
                    if(bookBT!=NULL){
                        return bookBT;
                    }else{
#ifdef Android
                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "bookBT null\n");
#else
                        printf("bookBT null\n");
#endif
                    }
                }
                    break;
                default:
#ifdef Android
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, unknown variantType\n");
#else
                    printf("error, unknown variantType\n");
#endif
                    break;
            }
        }
        // make new
        book::Book* ret = NULL;
        bookMutext.lock();
        {
            // lay lai them 1 lan nua va tao moi
            switch (variantType) {
                case Normal:
                {
                    if(bookNormal!=NULL){
                        ret = bookNormal;
                    }else{
#ifdef Android
                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "make new bookNormal\n");
#else
                        printf("make new bookNormal\n");
#endif
                        bookNormal = (book::Book*)calloc(1, sizeof(book::Book));
                        if(bookNormal->Load(Normal, BookPath)){
#ifdef Android
                            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "load bookNormal success\n");
#else
                            printf("load bookNormal success\n");
#endif
                            ret = bookNormal;
                        }else{
#ifdef Android
                            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, load bookNormal fail\n");
#else
                            printf("error, load bookNormal fail\n");
#endif
                            free(bookNormal);
                            bookNormal = NULL;
                            ret = NULL;
                        }
                    }
                }
                    break;
                case Killer:
                {
                    if(bookKiller!=NULL){
                        ret = bookKiller;
                    }else{
#ifdef Android
                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "make new bookKiller\n");
#else
                        printf("make new bookKiller\n");
#endif
                        bookKiller = (book::Book*)calloc(1, sizeof(book::Book));
                        if(bookKiller->Load(Killer, BookPath)){
#ifdef Android
                            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "load bookKiller success\n");
#else
                            printf("load bookKiller success\n");
#endif
                            ret = bookKiller;
                        }else{
#ifdef Android
                            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, load bookKiller fail\n");
#else
                            printf("error, load bookKiller fail\n");
#endif
                            free(bookKiller);
                            bookKiller = NULL;
                            ret = NULL;
                        }
                    }
                }
                    break;
                case BT:
                {
                    if(bookBT!=NULL){
                        ret = bookBT;
                    }else{
#ifdef Android
                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "make new bookBT\n");
#else
                        printf("make new bookBT\n");
#endif
                        bookBT = (book::Book*)calloc(1, sizeof(book::Book));
                        if(bookBT->Load(BT, BookPath)){
#ifdef Android
                            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "load bookBT success\n");
#else
                            printf("load bookBT success\n");
#endif
                            ret = bookBT;
                        }else{
#ifdef Android
                            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, load bookBT fail\n");
#else
                            printf("error, load bookBT fail\n");
#endif
                            free(bookBT);
                            bookBT = NULL;
                            ret = NULL;
                        }
                    }
                }
                    break;
                default:
#ifdef Android
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, unknown variantType\n");
#else
                    printf("error, unknown variantType\n");
#endif
                    break;
            }
        }
        bookMutext.unlock();
        return ret;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// EvalVariable /////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    char EvalPath[1024];
    
    std::mutex evalMutext;
    
    EvalVariable* evalVariableNormal = NULL;
    EvalVariable* evalVariableKiller = NULL;
    EvalVariable* evalVariableBT = NULL;
    
    EvalVariable* getEvalVariable(Variant_Type variantType)
    {
        // get immediately
        {
            switch (variantType) {
                case Normal:
                {
                    if(evalVariableNormal!=NULL){
                        return evalVariableNormal;
                    }else{
#ifdef Android
                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "evalVariableNormal null\n");
#else
                        printf("evalVariableNormal null\n");
#endif
                    }
                }
                    break;
                case Killer:
                {
                    if(evalVariableKiller!=NULL){
                        return evalVariableKiller;
                    }else{
#ifdef Android
                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "evalVariableKiller null\n");
#else
                        printf("evalVariableKiller null\n");
#endif
                    }
                }
                    break;
                case BT:
                {
                    if(evalVariableBT!=NULL){
                        return evalVariableBT;
                    }else{
#ifdef Android
                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "evalVariableBT null\n");
#else
                        printf("evalVariableBT null\n");
#endif
                    }
                }
                    break;
                default:
#ifdef Android
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, unknown variantType\n");
#else
                    printf("error, unknown variantType\n");
#endif
                    break;
            }
        }
        // make new
        EvalVariable* ret = NULL;
        evalMutext.lock();
        {
            // lay lai them 1 lan nua va tao moi
            switch (variantType) {
                case Normal:
                {
                    if(evalVariableNormal!=NULL){
                        ret = evalVariableNormal;
                    }else{
                        printf("make new evalVariableNormal\n");
                        evalVariableNormal = (EvalVariable*)calloc(1, sizeof(EvalVariable));
                        // get path
                        char evalPathNormal[1040];
                        {
                            sprintf(evalPathNormal, "%s/eval", EvalPath);
                        }
                        // init
                        if(evalVariableNormal->eval_init(evalPathNormal)){
                            ret = evalVariableNormal;
                        }else{
                            printf("error, cannot init evalVariableNormal\n");
                            free(evalVariableNormal);
                            evalVariableNormal = NULL;
                            ret = NULL;
                        }
                    }
                }
                    break;
                case Killer:
                {
                    if(evalVariableKiller!=NULL){
                        ret = evalVariableKiller;
                    }else{
                        printf("make new evalVariableKiller\n");
                        evalVariableKiller = (EvalVariable*)calloc(1, sizeof(EvalVariable));
                        // get path
                        char evalPathKiller[1040];
                        {
                            sprintf(evalPathKiller, "%s/eval_killer", EvalPath);
                        }
                        // init
                        if(evalVariableKiller->eval_init(evalPathKiller)){
                            ret = evalVariableKiller;
                        }else{
                            printf("error, cannot init evalVariableKiller\n");
                            free(evalVariableKiller);
                            evalVariableKiller = NULL;
                            ret = NULL;
                        }
                    }
                }
                    break;
                case BT:
                {
                    if(evalVariableBT!=NULL){
                        ret = evalVariableBT;
                    }else{
                        printf("make new evalVariableBT\n");
                        evalVariableBT = (EvalVariable*)calloc(1, sizeof(EvalVariable));
                        // get path
                        char evalPathBT[1040];
                        {
                            sprintf(evalPathBT, "%s/eval_bt", EvalPath);
                        }
                        // init
                        if(evalVariableBT->eval_init(evalPathBT)){
                            ret = evalVariableBT;
                        }else{
                            printf("error, cannot init evalVariableBT\n");
                            free(evalVariableBT);
                            evalVariableBT = NULL;
                            ret = NULL;
                        }
                    }
                }
                    break;
                default:
                    printf("error, unknown variantType\n");
                    break;
            }
        }
        evalMutext.unlock();
        return ret;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// Convert /////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////

    int32_t Position::getByteSize()
    {
        int32_t ret = 0;
        {
            // Node* node;
            {
                std::vector<Node*> nodes;
                {
                    Node* temp = node;
                    while(temp){
                        nodes.push_back(temp);
                        temp = temp->p_parent;
                    }
                }
                // add node number
                ret+=sizeof(int32_t);
                // add nodes
                {
                    int32_t nodeSize = Pos::getByteSize() + sizeof(int32_t);
                    ret+=nodes.size()*nodeSize;
                }
            }
            // struct var::Var var;
            ret+=var::Var::getByteSize();
            // uint64 lastMove = 0;
            ret+=sizeof(uint64);
            // int32_t ply = 100;
            ret+=sizeof(int32_t);
            
            // int32_t captureSize = 0;
            ret+=sizeof(int32_t);
            // int32_t captureSquares[20];
            ret+=20*sizeof(int32_t);
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
                // Node* node;
                {
                    std::vector<Node*> nodes;
                    {
                        Node* temp = position->node;
                        while(temp){
                            nodes.push_back(temp);
                            temp = temp->p_parent;
                        }
                    }
                    // add node number
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            int32_t value = (int32_t)nodes.size();
                            // printf("node number: %d\n", value);
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: var: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // add nodes
                    {
                        for(int64_t i=nodes.size()-1; i>=0; i--){
                            Node* node = nodes[i];
                            // Pos p_pos;
                            {
                                uint8_t* posByteArray;
                                int32_t size = Pos::convertToByteArray(&node->p_pos, posByteArray);
                                // write
                                if(pointerIndex+size<=length){
                                    memcpy(byteArray + pointerIndex, posByteArray, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: pos: %d, %d\n", pointerIndex, length);
                                }
                                free(posByteArray);
                            }
                            // int32_t p_ply;
                            {
                                int32_t size = sizeof(int32_t);
                                if(pointerIndex+size<=length){
                                    int32_t value = node->p_ply;
                                    memcpy(byteArray + pointerIndex, &value, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: node: p_ply: %d, %d\n", pointerIndex, length);
                                }
                            }
                        }
                    }
                }
                // struct var::Var var;
                {
                    uint8_t* varByteArray;
                    int32_t size = var::Var::convertToByteArray(&position->var, varByteArray);
                    // write
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, varByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: b: %d, %d\n", pointerIndex, length);
                    }
                    free(varByteArray);
                }
                // uint64 lastMove = 0;
                {
                    int32_t size = sizeof(uint64);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &position->lastMove, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: lastMove: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t ply = 100;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &position->ply, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: ply: %d, %d\n", pointerIndex, length);
                    }
                }
                
                // int32_t captureSize = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &position->captureSize, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: captureSize: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t captureSquares[20];
                {
                    int32_t size = 20*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &position->captureSquares, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: captureSquares: %d, %d\n", pointerIndex, length);
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
                    // Node* node;
                {
                    // printf("parse node: %d\n", pointerIndex);
                    // free old data
                    {
                        if(position->firstNode){
                            free(position->firstNode);
                        }
                    }
                    // make nodeNumber
                    int32_t nodeNumber = 0;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&nodeNumber, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: nodeNumber: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    if(nodeNumber>0){
                        // parse node
                        Node* nodes = (Node*)calloc(nodeNumber, sizeof(Node));
                        // set first node
                        {
                            position->firstNode = nodes;
                        }
                        // parse each node
                        {
                            for(int32_t i=0; i<nodeNumber; i++){
                                Node* node = &nodes[i];
                                {
                                    // Pos p_pos;
                                    {
                                        int32_t posByteLength = Pos::parseByteArray(&node->p_pos, positionBytes, length, pointerIndex, canCorrect);
                                        if (posByteLength > 0) {
                                            pointerIndex+= posByteLength;
                                        } else {
                                            printf("error, cannot parse: pos\n");
                                            isParseCorrect = false;
                                        }
                                    }
                                    // int32_t p_ply;
                                    {
                                        int32_t size = sizeof(int32_t);
                                        if(pointerIndex+size<=length){
                                            memcpy(&node->p_ply, positionBytes + pointerIndex, size);
                                            pointerIndex+=size;
                                        } else{
                                            printf("length error: node: p_ply %d, %d\n", pointerIndex, length);
                                            isParseCorrect = false;
                                        }
                                    }
                                }
                            }
                        }
                        // set parent
                        {
                            for(int32_t i=0; i<nodeNumber; i++){
                                Node* node = &nodes[i];
                                if(i==0){
                                    node->p_parent = NULL;
                                }else{
                                    node->p_parent = &nodes[i-1];
                                }
                            }
                        }
                        // TODO Check node ply correct
                        /*{
                            bool isPlyCorrect = true;
                            for(int32_t i=0; i<nodeNumber; i++){
                                Node* node = &nodes[i];
                                if(node->p_ply!=i){
                                    isPlyCorrect = false;
                                }
                            }
                            if(!isPlyCorrect){
                                printf("ply not correct\n");
                            }
                            {
                                char strPly[3000];
                                {
                                    strPly[0] = 0;
                                }
                                for(int32_t i=0; i<nodeNumber; i++){
                                    Node* node = &nodes[i];
                                    sprintf(strPly, "%s%d, ", strPly, node->p_ply);
                                }
                                printf("strPly: %s\n", strPly);
                            }
                        }*/
                        // add
                        position->node = &nodes[nodeNumber-1];
                    }else{
                        position->node = NULL;
                    }
                }
                    break;
                case 1:
                    // struct var::Var var;
                {
                    // printf("parse var: %d\n", pointerIndex);
                    int32_t varByteLength = var::Var::parseByteArray(&position->var, positionBytes, length, pointerIndex, canCorrect);
                    if (varByteLength > 0) {
                        pointerIndex+= varByteLength;
                    } else {
                        printf("error, cannot parse: board\n");
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                    // lastMove
                {
                    // printf("parse lastMove: %d\n", pointerIndex);
                    int32_t size = sizeof(uint64);
                    if(pointerIndex+size<=length){
                        memcpy(&position->lastMove, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: lastMove: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 3:
                    // int32_t ply = 100;
                {
                    // printf("parse ply: %d\n", pointerIndex);
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->ply, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: ply: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                    
                case 4:
                // int32_t captureSize = 0;
                {
                    // printf("parse captureSize: %d\n", pointerIndex);
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->captureSize, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: captureSize: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 5:
                    // int32_t captureSquares[20];
                {
                    // printf("parse captureSquares: %d\n", pointerIndex);
                    int32_t size = 20*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->captureSquares, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: captureSquares: %d, %d\n", pointerIndex, length);
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
        // Add to var
        {
            // Book
            {
                if(position->var.Book){
                    position->var.myBook = getBook(position->var.Variant);
                    if(!position->var.myBook){
                        printf("cannot load book\n");
                        position->var.Book = false;
                    }
                }else{
                    // printf("parse position: Don't need book\n");
                }
            }
            // EvalVariable
            position->var.evalVariable = getEvalVariable(position->var.Variant);
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
    
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// print /////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    void Position::print(char* ret)
    {
        ret[0] = 0;
        if(this->node){
            Pos* pos = &this->node->p_pos;
            // Variant
            {
                switch (var.Variant) {
                    case Normal:
                        sprintf(ret, "%sVariant: Normal\n", ret);
                        break;
                    case Killer:
                        sprintf(ret, "%sVariant: Killer\n", ret);
                        break;
                    case BT:
                        sprintf(ret, "%sVariant: BT\n", ret);
                        break;
                    default:
                        printf("error, unknown variantType: %d\n", var.Variant);
                        break;
                }
            }
            // turn
            {
                switch (pos->turn()) {
                    case White:
                        sprintf(ret, "%sTurn: White\n", ret);
                        break;
                    case Black:
                        sprintf(ret, "%sTurn: Black\n", ret);
                        break;
                    default:
                        printf("error, unknown turn\n");
                        break;
                }
            }
            // GamePly
            {
                sprintf(ret, "%sPly: %d\n", ret, this->node->p_ply);
            }
            // lastMove
            int32_t from = -1;
            int32_t dest = -1;
            {
                if(this->lastMove>0){
                    Move mv = (Move)this->lastMove;
                    from = move::from(mv);
                    dest = move::to(mv);
                }else{
                    printf("don't have last move\n");
                }
            }
            // board
            {
                // print top
                sprintf(ret, "%s\n    A  B  C  D  E  F  G  H  I  J\n", ret);
                // print piece
                for (int32_t y = 0; y < Line_Size; y++) {// Square.Rank_Size
                    sprintf(ret, "%s%2d ", ret, Line_Size-y);
                    for (int32_t x = 0; x < Line_Size; x++) {// Square.File_Size
                        if(square_is_dark(x, y)){
                            Square sq = square_make(x, y);
                            // check is last move
                            char cLastMove = ' ';
                            {
                                if(sq==from){
                                    cLastMove = '(';
                                }else if(sq==dest){
                                    cLastMove = ')';
                                }else{
                                    cLastMove = ' ';
                                }
                            }
                            // Check capture square
                            char lastCaptureSquare = ' ';
                            {
                                bool isLastCaptureSquare = false;
                                {
                                    if(captureSize>=0 && captureSize<=20){
                                        for(int32_t i=0; i<captureSize; i++){
                                            if(captureSquares[i]==sq){
                                                isLastCaptureSquare = true;
                                                printf("isLastCaptureSquare: %d\n", captureSquares[i]);
                                                break;
                                            }
                                        }
                                    }else{
                                        printf("error, captureSize wrong: %d\n", captureSize);
                                    }
                                }
                                if(isLastCaptureSquare){
                                    lastCaptureSquare = '-';
                                }
                            }
                            // print piece
                            switch (pos->piece_side(sq)) {
                                case White_Man:
                                    sprintf(ret, "%s%cM%c", ret, lastCaptureSquare, cLastMove);
                                    break;
                                case Black_Man:
                                    sprintf(ret, "%s%cm%c", ret, lastCaptureSquare, cLastMove);
                                    break;
                                case White_King:
                                    sprintf(ret, "%s%cK%c", ret, lastCaptureSquare, cLastMove);
                                    break;
                                case Black_King:
                                    sprintf(ret, "%s%ck%c", ret, lastCaptureSquare, cLastMove);
                                    break;
                                case Empty:
                                    sprintf(ret, "%s%c.%c", ret, lastCaptureSquare, cLastMove);
                                    break;
                                default:
                                    printf("error, unknown piece_side\n");
                                    break;
                            }
                        }else{
                            sprintf(ret, "%s   ", ret);
                        }
                    }
                    sprintf(ret, "%s %2d\n", ret, Line_Size-y);
                }
                // print bottom
                sprintf(ret, "%s    A  B  C  D  E  F  G  H  I  J\n", ret);
            }
            // fen
            sprintf(ret, "%s\nFen: %s\n", ret, pos_fen(*pos).c_str());
        }else{
            printf("error, node null\n");
        }
    }
}
