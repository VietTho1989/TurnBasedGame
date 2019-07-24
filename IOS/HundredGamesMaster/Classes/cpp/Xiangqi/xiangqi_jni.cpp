//
//  xiangqi_jni.cpp
//  TestXiangqi
//
//  Created by Viet Tho on 3/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <cstdlib>
#include "xiangqi_jni.hpp"

#include "../Platform.h"
#include "eleeye/xiangqi_position.hpp"
#include "eleeye/xiangqi_search.hpp"
#include "eleeye/xiangqi_hash.hpp"
#include "eleeye/xiangqi_evaluate.hpp"

namespace Xiangqi
{
    
#ifdef _WIN32
#include <windows.h>
    // const char *const cszLibEvalFile = "EVALUATE.DLL";
    const char *WINAPI GetEngineNameEVA(void);
    int32_t WINAPI EvaluateEVA(PositionStruct *lppos, int32_t vlAlpha, int32_t vlBeta, int32_t pickBestMove);
    void WINAPI PreEvaluateEVA(PositionStruct *lppos, PreEvalStruct *lpPreEval);
#else
#include <dlfcn.h>
#define WINAPI
    // const char * const cszLibEvalFile = "libeval.so";
    const char *WINAPI GetEngineNameEVA(void);
    int32_t WINAPI EvaluateEVA(PositionStruct *lppos, int32_t vlAlpha, int32_t vlBeta, int32_t pickBestMove);
    void WINAPI PreEvaluateEVA(PositionStruct *lppos, PreEvalStruct *lpPreEval);
    
#endif
    
    const int32_t INTERRUPT_COUNT = 4096; // Ã€â€”Ã€ËœÂ»Ã™âˆ�â€¦Î©Â·Âµâ€žâˆ«Ã›ÂµËœâ€�âˆšÃ·â€“âˆ‚Å“
    
#ifdef _WIN32
    
    /*inline HMODULE LoadEvalApi(const char *szLibEvalFile) {
        HMODULE hModule;
        hModule = LoadLibrary(szLibEvalFile);
        if (hModule == NULL) {
            Search.GetEngineName = GetEngineNameEVA;
            Search.PreEvaluate = PreEvaluateEVA;
            Search.Evaluate = EvaluateEVA;
        } else {
            Search.GetEngineName = (const char *(WINAPI *)(void)) GetProcAddress(hModule, "_GetEngineName@0");
            Search.PreEvaluate = (void (WINAPI *)(PositionStruct *, PreEvalStruct *)) GetProcAddress(hModule, "_PreEvaluate@8");
            Search.Evaluate = (int32_t (WINAPI *)(PositionStruct *, int32_t, int32_t)) GetProcAddress(hModule, "_Evaluate@12");
        }
        return hModule;
    }
    
    inline void FreeEvalApi(HMODULE hModule) {
        if (hModule != NULL) {
            FreeLibrary(hModule);
        }
    }*/
    
    inline void *LoadEvalApi(SearchStruct* search, const char *szLibEvalFile) {
        search->GetEngineName = GetEngineNameEVA;
        search->PreEvaluate = PreEvaluateEVA;
        search->Evaluate = EvaluateEVA;
        return 0;
    }
    
    inline void FreeEvalApi(void *hModule) {
        if (hModule != NULL) {
            // dlclose(hModule);
        }
    }
    
#else
    
    inline void *LoadEvalApi(SearchStruct* search, const char *szLibEvalFile) {
        search->GetEngineName = GetEngineNameEVA;
        search->PreEvaluate = PreEvaluateEVA;
        search->Evaluate = EvaluateEVA;
        return 0;
    }
    
    inline void FreeEvalApi(void *hModule) {
        if (hModule != NULL) {
            dlclose(hModule);
        }
    }
    
#endif
    
    void makeBanMove(int& nBanMoves, uint16_t* wmvBanList, uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        MoveStruct mvs[MAX_GEN_MOVES];
        // process
        SearchStruct search;
        {
            strcpy(search.szBookFile, xiangqi_bookPath);
            LoadEvalApi(&search, "EVALUATE");
            {
                if(search.pos.myPreGen==nullptr){
                    search.pos.myPreGen = new MyPreGen;
                }else{
                    printf("why myPregen!=null\n");
                }
                search.pos.myPreGen->PreGenInit();
            }
            search.pos.MyNewHash(24);
            // make position
            {
                PositionStruct::parseByteArray(&search.pos, positionBytes, length, 0, canCorrect);
            }
            // preEvaluate
            search.PreEvaluate(&search.pos, &search.pos.myPreGen->PreEval);
            // set other property
            {
                search.bIdle = search.bPonder = search.bQuit = search.bBatch = search.bDebug = search.bAlwaysCheck = false;
                search.bUseHash = search.bNullMove = search.bKnowledge = true;
                search.bUseBook = true;// useBook;
                search.nCountMask = INTERRUPT_COUNT - 1;
                search.nRandomMask = 0;
                search.rc4Random.InitRand();
                
            }
            // time limit
            search.nGoMode = GO_MODE_INFINITY;
        }
        // process
        nBanMoves = 0;
        int32_t nMoveNum = search.pos.GenAllMoves(mvs);
        for (int32_t i = 0; i < nMoveNum; i ++) {
            if (search.pos.MakeMove(mvs[i].wmv)) {
                if (search.pos.RepStatus(2) == REP_WIN) {
                    wmvBanList[nBanMoves] = mvs[i].wmv;
                    nBanMoves ++;
                }
                search.pos.UndoMakeMove();
            }
        }
        if(nBanMoves!=0){
            printf("error, make ban moves: nBanMoves different: %d\n", nBanMoves);
        }
        // free data
        {
            search.pos.MyDelHash();
            delete search.pos.myPreGen;
        }
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////// set path ////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    inline bool exist(const char* bookPath)
    {
        /*FILE * pFile;
        pFile = fopen (bookPath, "rb");
        if (pFile!=NULL)
        {
            fclose (pFile);
            return true;
        }else{
            return false;
        }*/
        return true;
    }
    
    char xiangqi_bookPath[1024];// = new char[1000];
    
    bool xiangqi_setBookPath(const char* newBookPath)
    {
        bool isExist = exist(newBookPath);
        if(isExist){
            strcpy(xiangqi_bookPath, newBookPath);
        }else{
            // strcpy(bookPath, "");
            strcpy(xiangqi_bookPath, newBookPath);
        }
        return isExist;
    }
    
    void xiangqi_initCore()
    {
        
    }
    
    ///////////////////////////////////////////////////////////////////////////////
    ///////////////////// Core ////////////////////
    ///////////////////////////////////////////////////////////////////////////////

    int32_t xiangqi_makePositionByFen(const char* strFen, uint8_t* &outRet)
    {
        // make position
        PositionStruct pos;// (strFen, NULL, NULL);
        {
            {
                if(pos.myPreGen==nullptr){
                    pos.myPreGen = new MyPreGen;
                }else{
                    printf("error, myPregen !=null\n");
                }
                pos.myPreGen->PreGenInit();
            }
            pos.FromFen(strFen);
        }
        // convert
        int32_t length = PositionStruct::convertToByteArray(&pos, outRet);
        // release data
        {
            delete pos.myPreGen;
        }
        // return
        return length;
    }
    
    void xiangqi_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        // make position
        PositionStruct pos;
        {
            PositionStruct::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // process
        pos.print();
    }
    
    void xiangqi_printPositionFen(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        // make position
        PositionStruct pos;
        {
            PositionStruct::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // find fen
        char strFen[1000];
        pos.ToFen(strFen);
        printf("positionFen: %s\n", strFen);
    }

    int32_t xiangqi_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        int32_t ret = 0;
        {
            // prepare
            SearchStruct search;
            {
                strcpy(search.szBookFile, xiangqi_bookPath);
                LoadEvalApi(&search, "EVALUATE");
                {
                    if(search.pos.myPreGen==nullptr){
                        search.pos.myPreGen = new MyPreGen;
                    }else{
                        printf("error, myPregen!=null\n");
                    }
                    search.pos.myPreGen->PreGenInit();
                }
                search.pos.MyNewHash(24);
                // make position
                {
                    PositionStruct::parseByteArray(&search.pos, positionBytes, length, 0, canCorrect);
                    //printf("isGameFinish0: check game draw: %d, %d\n", search->pos.LastMove().CptDrw, search->pos.nMoveNum);
                }
                // preEvaluate
                search.PreEvaluate(&search.pos, &search.pos.myPreGen->PreEval);
                // set other property
                {
                    search.bIdle = search.bPonder = search.bQuit = search.bBatch = search.bDebug = search.bAlwaysCheck = false;
                    search.bUseHash = search.bNullMove = search.bKnowledge = true;
                    search.bUseBook = true;// useBook;
                    search.nCountMask = INTERRUPT_COUNT - 1;
                    search.nRandomMask = 0;
                    search.rc4Random.InitRand();
                }
                // time limit
                search.nGoMode = GO_MODE_INFINITY;
                // banMoves
                makeBanMove(search.nBanMoves, search.wmvBanList, positionBytes, length, canCorrect);
            }
            // process
            if(search.pos.isOK()){
                // printf("isGameFinish: check game draw: %d, %d\n", search.pos.LastMove().CptDrw, search.pos.nMoveNum);
                // check game draw
                if(search.pos.IsDraw()){
                    // printf("game is draw\n");
                    ret = 3;
                }else{
                    int32_t repStatus = search.pos.RepStatus(3);
                    switch (repStatus) {
                        case REP_NONE:
                            // printf("position: repStatus: REP_NONE\n");
                        {
                            // sd player mate
                            int32_t sdPlayer = -1;
                            if(search.pos.IsMate()){
                                // printf("position is mate\n");
                                sdPlayer = search.pos.sdPlayer;
                            }else{
                                search.pos.ChangeSide();
                                if(search.pos.IsMate()){
                                    sdPlayer = search.pos.sdPlayer;
                                }
                            }
                            // set value
                            switch (sdPlayer) {
                                case -1:
                                    break;
                                case 0:
                                    // red
                                    ret = 2;
                                    break;
                                case 1:
                                    // black
                                    ret = 1;
                                    break;
                                default:
                                    printf("unknown sdPlayer: %d\n", search.pos.sdPlayer);
                                    break;
                            }
                        }
                            break;
                        case REP_DRAW:
                        {
                            printf("position: repStatus: REP_DRAW\n");
                            ret = 3;
                        }
                            break;
                        case REP_LOSS:
                        {
                            printf("error: position: repStatus: REP_LOSS\n");
                            // TODO ret = 3;
                        }
                            break;
                        case REP_WIN:
                        {
                            printf("error: position: repStatus: REP_WIN\n");
                            // TODO ret = 3;
                        }
                            break;
                        default:
                            printf("error: position: unknown repStatus: %d\n", repStatus);
                            break;
                    }
                }
            }else{
                printf("error, position not ok\n");
            }
            // release data
            {
                search.pos.MyDelHash();
                delete search.pos.myPreGen;
            }
        }
        return ret;
    }
    
    void evaluatePosition(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t depth, int32_t lngLimitTime, bool useBook, int32_t chosenType, int32_t differentScore)
    {
        // prepare search
        SearchStruct search;
        {
            strcpy(search.szBookFile, xiangqi_bookPath);
            LoadEvalApi(&search, "EVALUATE");
            // init pregen
            {
                if(search.pos.myPreGen==nullptr){
                    search.pos.myPreGen = new MyPreGen;
                }else{
                    printf("error, myPregen !=null\n");
                }
                search.pos.myPreGen->PreGenInit();
            }
            search.pos.MyNewHash(24);
            // make position
            {
                PositionStruct::parseByteArray(&search.pos, positionBytes, length, 0, canCorrect);
            }
            // preEvaluate
            search.PreEvaluate(&search.pos, &search.pos.myPreGen->PreEval);
            // set other property
            {
                search.bIdle = search.bPonder = search.bQuit = search.bBatch = search.bDebug = search.bAlwaysCheck = false;
                search.bUseHash = search.bNullMove = search.bKnowledge = true;
                search.bUseBook = useBook;
                search.nCountMask = INTERRUPT_COUNT - 1;
                search.nRandomMask = 0;
                search.rc4Random.InitRand();
            }
            // time limit
            if (lngLimitTime == 0)
                search.nGoMode = GO_MODE_INFINITY;
            else {
                search.nGoMode = GO_MODE_TIMER;
                search.nMaxTimer = lngLimitTime;
                search.nProperTimer = lngLimitTime;
            };
            // banMoves
            makeBanMove(search.nBanMoves, search.wmvBanList, positionBytes, length, canCorrect);
        }
        // Search
        {
            // int32_t evaluateScore = search.Evaluate(&search.pos, -MATE_VALUE, MATE_VALUE);
            EvaluateResult result;
            int32_t evaluateScore = EvaluatePositionEVA(&search.pos, -MATE_VALUE, MATE_VALUE, &result);
            /*{
                printf("evaluate position: score: %d\n", evaluateScore);
                printf("evaluate position: material: %d\n", result.material);
                printf("evaluate position: advisorShap: %d\n", result.advisorShape);
                printf("evaluate position: stringHold: %d\n", result.stringHold);
                printf("evaluate position: rookMobility: %d\n", result.rookMobility);
                printf("evaluate position: knightTrap: %d\n", result.knightTrap);
            }*/
            // TODO search.MySearchMain(depth<=0 ? 1 : depth);
        }
        // free data
        {
            search.pos.MyDelHash();
            delete search.pos.myPreGen;
        }
    }
    
    uint32_t xiangqi_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t depth, int32_t lngLimitTime, bool useBook, int32_t pickBestMove)
    {
        uint32_t ret = 0;
        {
            // prepare search
            SearchStruct search;
            {
                strcpy(search.szBookFile, xiangqi_bookPath);
                LoadEvalApi(&search, "EVALUATE");
                // init pregen
                {
                    if(search.pos.myPreGen==nullptr){
                        search.pos.myPreGen = new MyPreGen;
                    }else{
                        printf("error, myPregen !=null\n");
                    }
                    search.pos.myPreGen->PreGenInit();
                }
                search.pos.MyNewHash(24);
                // make position
                {
                    PositionStruct::parseByteArray(&search.pos, positionBytes, length, 0, canCorrect);
                }
                // preEvaluate
                search.PreEvaluate(&search.pos, &search.pos.myPreGen->PreEval);
                // set other property
                {
                    search.bIdle = search.bPonder = search.bQuit = search.bBatch = search.bDebug = search.bAlwaysCheck = false;
                    search.bUseHash = search.bNullMove = search.bKnowledge = true;
                    search.bUseBook = useBook;
                    search.nCountMask = INTERRUPT_COUNT - 1;
                    search.nRandomMask = 0;
                    search.rc4Random.InitRand();
                    
                    search.pickBestMove = pickBestMove;
                }
                // time limit
                if (lngLimitTime == 0)
                    search.nGoMode = GO_MODE_INFINITY;
                else {
                    search.nGoMode = GO_MODE_TIMER;
                    search.nMaxTimer = lngLimitTime;
                    search.nProperTimer = lngLimitTime;
                };
            }
            if(search.pos.isOK()){
                // banMoves
                makeBanMove(search.nBanMoves, search.wmvBanList, positionBytes, length, canCorrect);
                // Search
                {
                    search.MySearchMain(depth<=0 ? 1 : depth);
                }
            }else{
                printf("error, why position not ok\n");
            }
            // Return result
            ret = search.mvResult;
            // TODO print time
            /*{
                int64_t time = GetTime();
                int32_t nCurrTimer = (int32_t) (time - search.search2.llTime);
                printf("time: %d, %lld, %lld", nCurrTimer, time, search.search2.llTime);
            }*/
            // free data
            {
                search.pos.MyDelHash();
                delete search.pos.myPreGen;
            }
        }
        // print result
        /*{
            printf("find ai move: %u\n", ret);
            printMove(ret);
        }*/
        // return
        return ret;
    }
    
    void xiangqi_printMove(uint32_t move)
    {
        // b2g2 845623906
        char strMove[5];
        snprintf(strMove, 5, "%.4s", (const char *) &move);
        printf("moveToString: %s\n", strMove);
    }
    
    bool xiangqi_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint32_t move)
    {
        // make position
        PositionStruct pos;
        {
            // init pregen
            {
                if(pos.myPreGen==nullptr){
                    pos.myPreGen = new MyPreGen;
                }else{
                    printf("error, myPregen !=null\n");
                }
                pos.myPreGen->PreGenInit();
            }
            PositionStruct::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // check
        int32_t mv = COORD_MOVE(move);
        bool ret = pos.LegalMove(mv);
        if(ret){
            // banMoves
            uint16_t banMoves[MAX_MOVE_NUM];
            int32_t banMoveCount = 0;
            {
                makeBanMove(banMoveCount, banMoves, positionBytes, length, canCorrect);
            }
            for(int32_t i=0; i<banMoveCount; i++){
                if(banMoves[i]==mv){
                    printf("error, ban moves, so not legal: %d, %d, ", banMoves[i], banMoveCount);
                    xiangqi_printMove(move);
                    printf("\n");
                    ret = false;
                    break;
                }
            }
        }else{
            printf("error, this is not legal move\n");
        }
        // release data
        {
            delete pos.myPreGen;
        }
        // return
        return ret;
    }

    int32_t xiangqi_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint32_t move, uint8_t* &outRet)
    {
        PositionStruct pos;
        {
            // init pregen
            {
                if(pos.myPreGen==nullptr){
                    pos.myPreGen = new MyPreGen;
                }else{
                    printf("error, myPregen null\n");
                }
                pos.myPreGen->PreGenInit();
            }
            PositionStruct::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // doMove
        if(pos.isOK()){
            int32_t mv = COORD_MOVE(move);
            if(pos.LegalMove(mv)){
                pos.MakeMove(mv);
            }else{
                printf("error, why not legal move: %d\n", mv);
            }
        }else{
            printf("doMove: position not ok\n");
        }
        // convert
        int32_t newLength = PositionStruct::convertToByteArray(&pos, outRet);
        // release data
        {
            delete pos.myPreGen;
        }
        // return
        return newLength;
    }

    int32_t xiangqi_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves)
    {
        PositionStruct pos;
        {
            // init pregen
            {
                if(pos.myPreGen==nullptr){
                    pos.myPreGen = new MyPreGen;
                }else{
                    printf("error, myPregen null\n");
                }
                pos.myPreGen->PreGenInit();
            }
            PositionStruct::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        int32_t outLegalMovesLength = 0;
        if(pos.isOK()){
            // gen all moves
            MoveStruct legalMoves[MAX_GEN_MOVES];
            int32_t legalRepStatus[MAX_GEN_MOVES];
            int32_t legalMoveCount = 0;
            {
                MoveStruct moves[MAX_GEN_MOVES];
                int32_t moveCount = pos.GenAllMoves(moves);
                for (int32_t i=0; i<moveCount; i++) {
                    if (pos.MakeMove(moves[i].wmv)) {
                        // Add
                        {
                            legalMoves[legalMoveCount] = moves[i];
                            legalRepStatus[legalMoveCount] = pos.RepStatus(2);
                            legalMoveCount++;
                        }
                        pos.UndoMakeMove();
                    } else {
                        // printf("not legal move\n");
                    }
                }
            }
            // make byte array
            if(legalMoveCount>0){
                // init outLegalMovves
                int32_t legalMoveSize = sizeof(uint32_t) + sizeof(int32_t);
                outLegalMovesLength = legalMoveCount*legalMoveSize;
                outLegalMoves = (uint8_t*)calloc(outLegalMovesLength, sizeof(uint8_t));
                // make outLegalMoves
                for(int32_t moveIndex=0; moveIndex<legalMoveCount; moveIndex++){
                    // copy move
                    {
                        uint32_t move = MOVE_COORD(legalMoves[moveIndex].wmv);
                        memcpy(outLegalMoves + legalMoveSize*moveIndex, &move , sizeof(uint32_t));
                        // printMove(move);
                    }
                    // repstatus
                    {
                        int32_t repStatus = legalRepStatus[moveIndex];
                        memcpy(outLegalMoves + legalMoveSize*moveIndex+sizeof(uint32_t), &repStatus , sizeof(int32_t));
                        // printf("RepStatus: %d\n", repStatus);
                    }
                }
            }else{
                printf("why don't have legal move\n");
            }
        }
        // release data
        {
            delete pos.myPreGen;
        }
        return outLegalMovesLength;
    }
    
}
