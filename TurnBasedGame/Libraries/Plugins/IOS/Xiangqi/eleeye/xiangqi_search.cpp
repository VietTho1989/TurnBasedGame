/*
search.h/search.cpp - Source Code for ElephantEye, Part VIII

ElephantEye - a Chinese Chess Program (UCCI Engine)
Designed by Morning Yellow, Version: 3.32, Last Modified: May 2012
Copyright (C) 2004-2012 www.xqbase.com

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
*/

#ifndef CCHESS_A3800
#include <stdio.h>
#endif
#include "../base/xiangqi_base2.hpp"
#include "xiangqi_pregen.hpp"
#include "xiangqi_position.hpp"
#include "xiangqi_hash.hpp"
#ifndef CCHESS_A3800
#include "xiangqi_ucci.hpp"
#include "xiangqi_book.hpp"
#endif
#include "xiangqi_search.hpp"

#include "../../Platform.h"
#include "../xiangqi_jni.hpp"

namespace Xiangqi
{
    const int32_t IID_DEPTH = 2;         // ƒ⁄≤øµ¸¥˙º”…Óµƒ…Ó∂»
    // const int32_t SMP_DEPTH = 6;         // ≤¢––À—À˜µƒ…Ó∂»
    const int32_t UNCHANGED_DEPTH = 4;   // Œ¥∏ƒ±‰◊Óº—◊≈∑®µƒ…Ó∂»
    
    const int32_t DROPDOWN_VALUE = 20;   // ¬‰∫Ûµƒ∑÷÷µ
    const int32_t RESIGN_VALUE = 300;    // »œ ‰µƒ∑÷÷µ
    const int32_t DRAW_OFFER_VALUE = 40; // Ã·∫Õµƒ∑÷÷µ
    
    // SearchStruct Search;
    
#ifndef CCHESS_A3800
    
    void BuildPos(PositionStruct &pos, const UcciCommStruct &UcciComm) {
        int32_t i, mv;
        pos.FromFen(UcciComm.szFenStr);
        for (i = 0; i < UcciComm.nMoveNum; i ++) {
            mv = COORD_MOVE(UcciComm.lpdwMovesCoord[i]);
            if (mv == 0) {
                break;
            }
            if (pos.LegalMove(mv) && pos.MakeMove(mv) && pos.LastMove().CptDrw > 0) {
                //  º÷’»√pos.nMoveNum∑¥”≥√ª≥‘◊”µƒ≤Ω ˝
                pos.SetIrrev();
            }
        }
    }
    
#endif
    
    
    bool SearchStruct::quit(void)
    {
        search2.bStop = true;
        return true;
    }
    
    // ÷–∂œ¿˝≥Ã
    bool SearchStruct::Interrupt(void) {
        if (bIdle) {
            Idle();
        }
        if (nGoMode == GO_MODE_NODES) {
            if (!bPonder && search2.nAllNodes > nNodes * 4) {
                search2.bStop = true;
                return true;
            }
        } else if (nGoMode == GO_MODE_TIMER) {
            if (!bPonder && (int) (now() - search2.llTime) > nMaxTimer) {
                search2.bStop = true;
                return true;
            }
        }
        if (bBatch) {
            return false;
        }
        return false;
    }
    
#ifndef CCHESS_A3800
    
    //  ‰≥ˆ÷˜“™±‰¿˝
    void SearchStruct::PopPvLine(int32_t nDepth, int32_t vl) {
        uint16_t *lpwmv;
        uint32_t dwMoveStr;
        // »Áπ˚…–Œ¥¥ÔµΩ–Ë“™ ‰≥ˆµƒ…Ó∂»£¨ƒ«√¥º«¬º∏√…Ó∂»∫Õ∑÷÷µ£¨“‘∫Û‘Ÿ ‰≥ˆ
        if (nDepth > 0 && !search2.bPopPv && !bDebug) {
            search2.nPopDepth = nDepth;
            search2.vlPopValue = vl;
            return;
        }
        //  ‰≥ˆ ±º‰∫ÕÀ—À˜Ω·µ„ ˝
        // printf("info time %d nodes %d\n", (int) (GetTime() - search2.llTime), search2.nAllNodes);
        fflush(stdout);
        if (nDepth == 0) {
            // »Áπ˚ «À—À˜Ω· ¯∫Ûµƒ ‰≥ˆ£¨≤¢«““—æ≠ ‰≥ˆπ˝£¨ƒ«√¥≤ª±ÿ‘Ÿ ‰≥ˆ
            if (search2.nPopDepth == 0) {
                return;
            }
            // ªÒ»°“‘«∞√ª”– ‰≥ˆµƒ…Ó∂»∫Õ∑÷÷µ
            nDepth = search2.nPopDepth;
            vl = search2.vlPopValue;
        } else {
            // ¥ÔµΩ–Ë“™ ‰≥ˆµƒ…Ó∂»£¨ƒ«√¥“‘∫Û≤ª±ÿ‘Ÿ ‰≥ˆ
            search2.nPopDepth = search2.vlPopValue = 0;
        }
        // printf("info depth %d score %d pv", nDepth, vl);
        lpwmv = search2.wmvPvLine;
        // printf("popPvLine: all move: ");
        while (*lpwmv != 0) {
            dwMoveStr = MOVE_COORD(*lpwmv);
            // printf(" %.4s", (const char *) &dwMoveStr);
            lpwmv ++;
        }
        // printf("\n");
        fflush(stdout);
    }
    
#endif
    
    // Œﬁ∫¶≤√ºÙ
    static int32_t HarmlessPruning(PositionStruct &pos, int32_t vlBeta) {
        int32_t vl, vlRep;
        
        // 1. …±∆Â≤Ω ˝≤√ºÙ£ª
        vl = pos.nDistance - MATE_VALUE;
        if (vl >= vlBeta) {
            return vl;
        }
        
        // 2. ∫Õ∆Â≤√ºÙ£ª
        if (pos.IsDraw()) {
            return 0; // ∞≤»´∆º˚£¨’‚¿Ô≤ª”√"pos.DrawValue()";
        }
        
        // 3. ÷ÿ∏¥≤√ºÙ£ª
        vlRep = pos.RepStatus();
        if (vlRep > 0) {
            return pos.RepValue(vlRep);
        }
        
        return -MATE_VALUE;
    }
    
    // µ˜’˚–Õæ÷√Ê∆¿º€∫Ø ˝
    inline int32_t MyEvaluate(SearchStruct* search, PositionStruct &pos, int32_t vlAlpha, int32_t vlBeta)
    {
        int32_t vl;
        vl = search->bKnowledge ? pos.Evaluate(vlAlpha, vlBeta) : pos.Material();
        return vl == pos.DrawValue() ? vl - 1 : vl;
    }
    
    // æ≤Ã¨À—À˜¿˝≥Ã
    int32_t SearchStruct::SearchQuiesc(PositionStruct &pos, int32_t vlAlpha, int32_t vlBeta)
    {
        int32_t vlBest, vl, mv;
        bool bInCheck;
        MoveSortStruct MoveSort;
        // æ≤Ã¨À—À˜¿˝≥Ã∞¸¿®“‘œ¬º∏∏ˆ≤Ω÷Ë£∫
        search2.nAllNodes ++;
        
        // 1. Œﬁ∫¶≤√ºÙ£ª
        vl = HarmlessPruning(pos, vlBeta);
        if (vl > -MATE_VALUE) {
            return vl;
        }
        
#ifdef HASH_QUIESC
        // 3. ÷√ªª≤√ºÙ£ª
        vl = ProbeHashQ(pos, vlAlpha, vlBeta);
        if (Search.bUseHash && vl > -MATE_VALUE) {
            return vl;
        }
#endif
        
        // 4. ¥ÔµΩº´œﬁ…Ó∂»£¨÷±Ω”∑µªÿ∆¿º€÷µ£ª
        if (pos.nDistance == Xiangqi::LIMIT_DEPTH) {
            // return MyEvaluate(this, pos, vlAlpha, vlBeta);
            return this->Evaluate(&pos, vlAlpha, vlBeta, pickBestMove);
        }
        // __ASSERT(pos.nDistance < Xiangqi::LIMIT_DEPTH);
        if(!(pos.nDistance < Xiangqi::LIMIT_DEPTH)){
            printf("error, ASSERT(pos.nDistance < Xiangqi::LIMIT_DEPTH): SearchQuiesc: %d\n", pos.nDistance);
            pos.nDistance = 0;
        }
        
        // 5. ≥ı ºªØ£ª
        vlBest = -MATE_VALUE;
        bInCheck = (pos.LastMove().ChkChs > 0);
        
        // 6. ∂‘”⁄±ªΩ´æ¸µƒæ÷√Ê£¨…˙≥…»´≤ø◊≈∑®£ª
        if (bInCheck) {
            MoveSort.InitAll(pos);
        } else {
            
            // 7. ∂‘”⁄Œ¥±ªΩ´æ¸µƒæ÷√Ê£¨‘⁄…˙≥…◊≈∑®«∞ ◊œ»≥¢ ‘ø’◊≈(ø’◊≈∆Ù∑¢)£¨º¥∂‘æ÷√Ê◊˜∆¿º€£ª
            // TODO vl = MyEvaluate(this, pos, vlAlpha, vlBeta);
            vl = this->Evaluate(&pos, vlAlpha, vlBeta, pickBestMove);
            // __ASSERT_BOUND(1 - WIN_VALUE, vl, WIN_VALUE - 1);
            if(!__IF_BOUND(1 - WIN_VALUE, vl, WIN_VALUE - 1)){
                printf("error, ASSERT_BOUND(1 - WIN_VALUE, vl, WIN_VALUE - 1)\n");
            }
            // __ASSERT(vl > vlBest);
            if(!(vl > vlBest)){
                printf("error, ASSERT(vl > vlBest)\n");
            }
            if (vl >= vlBeta) {
#ifdef HASH_QUIESC
                RecordHashQ(pos, vl, MATE_VALUE);
#endif
                return vl;
            }
            vlBest = vl;
            vlAlpha = MAX(vl, vlAlpha);
            
            // 8. ∂‘”⁄Œ¥±ªΩ´æ¸µƒæ÷√Ê£¨…˙≥…≤¢≈≈–ÚÀ˘”–≥‘◊”◊≈∑®(MVV(LVA)∆Ù∑¢)£ª
            MoveSort.InitQuiesc(pos);
        }
        
        // 9. ”√Alpha-BetaÀ„∑®À—À˜’‚–©◊≈∑®£ª
        while ((mv = MoveSort.NextQuiesc(bInCheck)) != 0) {
            // __ASSERT(bInCheck || pos.ucpcSquares[DST(mv)] > 0);
            if(!(bInCheck || pos.ucpcSquares[DST(mv)] > 0)){
                printf("error, ASSERT(bInCheck || pos.ucpcSquares[DST(mv)] > 0)\n");
            }
            if (pos.MakeMove(mv)) {
                vl = -SearchQuiesc(pos, -vlBeta, -vlAlpha);
                pos.UndoMakeMove();
                if (vl > vlBest) {
                    if (vl >= vlBeta) {
#ifdef HASH_QUIESC
                        if (vl > -WIN_VALUE && vl < WIN_VALUE) {
                            RecordHashQ(pos, vl, MATE_VALUE);
                        }
#endif
                        return vl;
                    }
                    vlBest = vl;
                    vlAlpha = MAX(vl, vlAlpha);
                }
            }
        }
        
        // 10. ∑µªÿ∑÷÷µ°£
        if (vlBest == -MATE_VALUE) {
            // __ASSERT(pos.IsMate());
            if(!(pos.IsMate())){
                printf("error, ASSERT(pos.IsMate())\n");
            }
            return pos.nDistance - MATE_VALUE;
        } else {
#ifdef HASH_QUIESC
            if (vlBest > -WIN_VALUE && vlBest < WIN_VALUE) {
                RecordHashQ(pos, vlBest > vlAlpha ? vlBest : -MATE_VALUE, vlBest);
            }
#endif
            return vlBest;
        }
    }
    
#ifndef CCHESS_A3800
    
    // UCCI÷ß≥÷ -  ‰≥ˆ“∂◊”Ω·µ„µƒæ÷√Ê–≈œ¢
    void SearchStruct::PopLeaf(PositionStruct &pos) {
        int32_t vl;
        search2.nAllNodes = 0;
        vl = SearchQuiesc(pos, -MATE_VALUE, MATE_VALUE);
        printf("pophash lowerbound %d depth 0 upperbound %d depth 0\n", vl, vl);
        fflush(stdout);
    }
    
#endif
    
    const bool NO_NULL = true; // "SearchCut()"µƒ≤Œ ˝£¨ «∑ÒΩ˚÷πø’◊≈≤√ºÙ
    
    // ¡„¥∞ø⁄ÕÍ»´À—À˜¿˝≥Ã
    int32_t SearchStruct::SearchCut(int32_t vlBeta, int32_t nDepth, bool bNoNull)
    {
        int32_t nNewDepth, vlBest, vl;
        int32_t mvHash, mv, mvEvade;
        Xiangqi::MoveSortStruct MoveSort;
        // ÕÍ»´À—À˜¿˝≥Ã∞¸¿®“‘œ¬º∏∏ˆ≤Ω÷Ë£∫
        
        // 1. ‘⁄“∂◊”Ω·µ„¥¶µ˜”√æ≤Ã¨À—À˜£ª
        if (nDepth <= 0) {
            // __ASSERT(nDepth >= -NULL_DEPTH);
            if(!(nDepth >= -NULL_DEPTH)){
                printf("error, ASSERT(nDepth >= -NULL_DEPTH)\n");
            }
            return SearchQuiesc(pos, vlBeta - 1, vlBeta);
        }
        search2.nAllNodes ++;
        
        // 2. Œﬁ∫¶≤√ºÙ£ª
        vl = HarmlessPruning(pos, vlBeta);
        if (vl > -MATE_VALUE) {
            return vl;
        }
        
        // 3. ÷√ªª≤√ºÙ£ª
        vl = ProbeHash(pos, vlBeta - 1, vlBeta, nDepth, bNoNull, mvHash);
        if (bUseHash && vl > -MATE_VALUE) {
            return vl;
        }
        
        // 4. ¥ÔµΩº´œﬁ…Ó∂»£¨÷±Ω”∑µªÿ∆¿º€÷µ£ª
        if (pos.nDistance == Xiangqi::LIMIT_DEPTH) {
            // TODO return MyEvaluate(this, pos, vlBeta - 1, vlBeta);
            return this->Evaluate(&pos, vlBeta - 1, vlBeta, pickBestMove);
        }
        // __ASSERT(pos.nDistance < Xiangqi::LIMIT_DEPTH);
        if(!(pos.nDistance < Xiangqi::LIMIT_DEPTH)){
            printf("error, ASSERT(pos.nDistance < Xiangqi::LIMIT_DEPTH): SearchCut: %d\n", pos.nDistance);
            pos.nDistance = 0;
        }
        
        // 5. ÷–∂œµ˜”√£ª
        search2.nMainNodes ++;
        vlBest = -MATE_VALUE;
        if ((search2.nMainNodes & nCountMask) == 0 && Interrupt()) {
            return vlBest;
        }
        
        // 6. ≥¢ ‘ø’◊≈≤√ºÙ£ª
        if (bNullMove && !bNoNull && pos.LastMove().ChkChs <= 0 && pos.NullOkay()) {
            pos.NullMove();
            vl = -SearchCut(1 - vlBeta, nDepth - NULL_DEPTH - 1, NO_NULL);
            pos.UndoNullMove();
            if (search2.bStop) {
                return vlBest;
            }
            
            if (vl >= vlBeta) {
                if (pos.NullSafe()) {
                    // a. »Áπ˚ø’◊≈≤√ºÙ≤ª¥¯ºÏ—È£¨ƒ«√¥º«¬º…Ó∂»÷¡…ŸŒ™(NULL_DEPTH + 1)£ª
                    RecordHash(pos, HASH_BETA, vl, MAX(nDepth, NULL_DEPTH + 1), 0);
                    return vl;
                } else if (SearchCut(vlBeta, nDepth - NULL_DEPTH, NO_NULL) >= vlBeta) {
                    // b. »Áπ˚ø’◊≈≤√ºÙ¥¯ºÏ—È£¨ƒ«√¥º«¬º…Ó∂»÷¡…ŸŒ™(NULL_DEPTH)£ª
                    RecordHash(pos, HASH_BETA, vl, MAX(nDepth, NULL_DEPTH), 0);
                    return vl;
                }
            }
        }
        
        // 7. ≥ı ºªØ£ª
        if (pos.LastMove().ChkChs > 0) {
            // »Áπ˚ «Ω´æ¸æ÷√Ê£¨ƒ«√¥…˙≥…À˘”–”¶Ω´◊≈∑®£ª
            mvEvade = MoveSort.InitEvade(pos, mvHash, search2.wmvKiller[pos.nDistance]);
        } else {
            // »Áπ˚≤ª «Ω´æ¸æ÷√Ê£¨ƒ«√¥ π”√’˝≥£µƒ◊≈∑®¡–±Ì°£
            MoveSort.InitFull(pos, mvHash, search2.wmvKiller[pos.nDistance]);
            mvEvade = 0;
        }
        
        // 8. ∞¥’’"MoveSortStruct::NextFull()"¿˝≥Ãµƒ◊≈∑®À≥–Ú÷“ªÀ—À˜£ª
        while ((mv = MoveSort.NextFull(pos)) != 0) {
            if (pos.MakeMove(mv)) {
                
                // 9. ≥¢ ‘—°‘Ò–‘—”…Ï£ª
                nNewDepth = (pos.LastMove().ChkChs > 0 || mvEvade != 0 ? nDepth : nDepth - 1);
                
                // 10. ¡„¥∞ø⁄À—À˜£ª
                vl = -SearchCut(1 - vlBeta, nNewDepth);
                pos.UndoMakeMove();
                if (search2.bStop) {
                    return vlBest;
                }
                
                // 11. Ωÿ∂œ≈–∂®£ª
                if (vl > vlBest) {
                    vlBest = vl;
                    if (vl >= vlBeta) {
                        RecordHash(pos, HASH_BETA, vlBest, nDepth, mv);
                        if (!MoveSort.GoodCap(pos, mv)) {
                            Xiangqi::SetBestMove(mv, nDepth, search2.wmvKiller[pos.nDistance]);
                        }
                        return vlBest;
                    }
                }
            }
        }
        
        // 12. ≤ªΩÿ∂œ¥Î ©°£
        if (vlBest == -MATE_VALUE) {
            // __ASSERT(pos.IsMate());
            if(!(pos.IsMate())){
                printf("error, ASSERT(pos.IsMate())\n");
            }
            return pos.nDistance - MATE_VALUE;
        } else {
            RecordHash(pos, HASH_ALPHA, vlBest, nDepth, mvEvade);
            return vlBest;
        }
    }
    
    // ¡¨Ω”÷˜“™±‰¿˝
    static void AppendPvLine(uint16_t *lpwmvDst, uint16_t mv, const uint16_t *lpwmvSrc) {
        *lpwmvDst = mv;
        lpwmvDst ++;
        while (*lpwmvSrc != 0) {
            *lpwmvDst = *lpwmvSrc;
            lpwmvSrc ++;
            lpwmvDst ++;
        }
        *lpwmvDst = 0;
    }
    
    /* ÷˜“™±‰¿˝ÕÍ»´À—À˜¿˝≥Ã£¨∫Õ¡„¥∞ø⁄ÕÍ»´À—À˜µƒ«¯±”–“‘œ¬º∏µ„£∫
     *
     * 1. ∆Ù”√ƒ⁄≤øµ¸¥˙º”…Ó∆Ù∑¢£ª
     * 2. ≤ª π”√”–∏∫√Ê”∞œÏµƒ≤√ºÙ£ª
     * 3. Alpha-Beta±ﬂΩÁ≈–∂®∏¥‘”£ª
     * 4. PVΩ·µ„“™ªÒ»°÷˜“™±‰¿˝£ª
     * 5. øº¬«PVΩ·µ„¥¶¿Ì◊Óº—◊≈∑®µƒ«Èøˆ°£
     */
    int32_t SearchStruct::SearchPV(int32_t vlAlpha, int32_t vlBeta, int32_t nDepth, uint16_t *lpwmvPvLine)
    {
        int32_t nNewDepth, nHashFlag, vlBest, vl;
        int32_t mvBest, mvHash, mv, mvEvade;
        Xiangqi::MoveSortStruct MoveSort;
        uint16_t wmvPvLine[Xiangqi::LIMIT_DEPTH];
        // ÕÍ»´À—À˜¿˝≥Ã∞¸¿®“‘œ¬º∏∏ˆ≤Ω÷Ë£∫
        
        // 1. ‘⁄“∂◊”Ω·µ„¥¶µ˜”√æ≤Ã¨À—À˜£ª
        *lpwmvPvLine = 0;
        if (nDepth <= 0) {
            // __ASSERT(nDepth >= -NULL_DEPTH);
            if(!(nDepth >= -NULL_DEPTH)){
                printf("error, ASSERT(nDepth >= -NULL_DEPTH)\n");
            }
            return SearchQuiesc(pos, vlAlpha, vlBeta);
        }
        search2.nAllNodes ++;
        
        // 2. Œﬁ∫¶≤√ºÙ£ª
        vl = HarmlessPruning(pos, vlBeta);
        if (vl > -MATE_VALUE) {
            return vl;
        }
        
        // 3. ÷√ªª≤√ºÙ£ª
        vl = ProbeHash(pos, vlAlpha, vlBeta, nDepth, NO_NULL, mvHash);
        if (bUseHash && vl > -MATE_VALUE) {
            // ”…”⁄PVΩ·µ„≤ª  ”√÷√ªª≤√ºÙ£¨À˘“‘≤ªª·∑¢…˙PV¬∑œﬂ÷–∂œµƒ«Èøˆ
            return vl;
        }
        
        // 4. ¥ÔµΩº´œﬁ…Ó∂»£¨÷±Ω”∑µªÿ∆¿º€÷µ£ª
        // __ASSERT(pos.nDistance > 0);
        if(!(pos.nDistance > 0)){
            printf("error, ASSERT(pos.nDistance > 0): SearchPV: %d\n", pos.nDistance);
        }
        if (pos.nDistance == Xiangqi::LIMIT_DEPTH) {
            // TODO return MyEvaluate(this, pos, vlAlpha, vlBeta);
            return this->Evaluate(&pos, vlAlpha, vlBeta, pickBestMove);
        }
        // __ASSERT(pos.nDistance < Xiangqi::LIMIT_DEPTH);
        if(!(pos.nDistance < Xiangqi::LIMIT_DEPTH)){
            printf("error, ASSERT(pos.nDistance < Xiangqi::LIMIT_DEPTH): SearchPV: %d\n", pos.nDistance);
            pos.nDistance = 0;
        }
        
        // 5. ÷–∂œµ˜”√£ª
        search2.nMainNodes ++;
        vlBest = -MATE_VALUE;
        if ((search2.nMainNodes & nCountMask) == 0 && Interrupt()) {
            return vlBest;
        }
        
        // 6. ƒ⁄≤øµ¸¥˙º”…Ó∆Ù∑¢£ª
        if (nDepth > IID_DEPTH && mvHash == 0) {
            // __ASSERT(nDepth / 2 <= nDepth - IID_DEPTH);
            if(!(nDepth / 2 <= nDepth - IID_DEPTH)){
                printf("error, ASSERT(nDepth / 2 <= nDepth - IID_DEPTH)\n");
            }
            vl = SearchPV(vlAlpha, vlBeta, nDepth / 2, wmvPvLine);
            if (vl <= vlAlpha) {
                vl = SearchPV(-MATE_VALUE, vlBeta, nDepth / 2, wmvPvLine);
            }
            if (search2.bStop) {
                return vlBest;
            }
            mvHash = wmvPvLine[0];
        }
        
        // 7. ≥ı ºªØ£ª
        mvBest = 0;
        nHashFlag = HASH_ALPHA;
        if (pos.LastMove().ChkChs > 0) {
            // »Áπ˚ «Ω´æ¸æ÷√Ê£¨ƒ«√¥…˙≥…À˘”–”¶Ω´◊≈∑®£ª
            mvEvade = MoveSort.InitEvade(pos, mvHash, search2.wmvKiller[pos.nDistance]);
        } else {
            // »Áπ˚≤ª «Ω´æ¸æ÷√Ê£¨ƒ«√¥ π”√’˝≥£µƒ◊≈∑®¡–±Ì°£
            MoveSort.InitFull(pos, mvHash, search2.wmvKiller[pos.nDistance]);
            mvEvade = 0;
        }
        
        // 8. ∞¥’’"MoveSortStruct::NextFull()"¿˝≥Ãµƒ◊≈∑®À≥–Ú÷“ªÀ—À˜£ª
        while ((mv = MoveSort.NextFull(pos)) != 0) {
            if (pos.MakeMove(mv)) {
                
                // 9. ≥¢ ‘—°‘Ò–‘—”…Ï£ª
                nNewDepth = (pos.LastMove().ChkChs > 0 || mvEvade != 0 ? nDepth : nDepth - 1);
                
                // 10. ÷˜“™±‰¿˝À—À˜£ª
                if (vlBest == -MATE_VALUE) {
                    vl = -SearchPV(-vlBeta, -vlAlpha, nNewDepth, wmvPvLine);
                } else {
                    vl = -SearchCut(-vlAlpha, nNewDepth);
                    if (vl > vlAlpha && vl < vlBeta) {
                        vl = -SearchPV(-vlBeta, -vlAlpha, nNewDepth, wmvPvLine);
                    }
                }
                pos.UndoMakeMove();
                if (search2.bStop) {
                    return vlBest;
                }
                
                // 11. Alpha-Beta±ﬂΩÁ≈–∂®£ª
                if (vl > vlBest) {
                    vlBest = vl;
                    if (vl >= vlBeta) {
                        mvBest = mv;
                        nHashFlag = HASH_BETA;
                        break;
                    }
                    if (vl > vlAlpha) {
                        vlAlpha = vl;
                        mvBest = mv;
                        nHashFlag = HASH_PV;
                        AppendPvLine(lpwmvPvLine, mv, wmvPvLine);
                    }
                }
            }
        }
        
        // 12. ∏¸–¬÷√ªª±Ì°¢¿˙ ∑±Ì∫Õ…± ÷◊≈∑®±Ì°£
        if (vlBest == -MATE_VALUE) {
            // __ASSERT(pos.IsMate());
            if(!(pos.IsMate())){
                printf("error, ASSERT(pos.IsMate())\n");
            }
            return pos.nDistance - MATE_VALUE;
        } else {
            RecordHash(pos, nHashFlag, vlBest, nDepth, mvEvade == 0 ? mvBest : mvEvade);
            if (mvBest != 0 && !MoveSort.GoodCap(pos, mvBest)) {
                Xiangqi::SetBestMove(mvBest, nDepth, search2.wmvKiller[pos.nDistance]);
            }
            return vlBest;
        }
    }
    
    /* ∏˘Ω·µ„À—À˜¿˝≥Ã£¨∫ÕÕÍ»´À—À˜µƒ«¯±”–“‘œ¬º∏µ„£∫
     *
     * 1.  °¬‘Œﬁ∫¶≤√ºÙ(“≤≤ªªÒ»°÷√ªª±Ì◊≈∑®)£ª
     * 2. ≤ª π”√ø’◊≈≤√ºÙ£ª
     * 3. —°‘Ò–‘—”…Ï÷ª π”√Ω´æ¸—”…Ï£ª
     * 4. π˝¬ÀµÙΩ˚÷π◊≈∑®£ª
     * 5. À—À˜µΩ◊Óº—◊≈∑® ±“™◊ˆ∫‹∂‡¥¶¿Ì(∞¸¿®º«¬º÷˜“™±‰¿˝°¢Ω·µ„≈≈–Úµ»)£ª
     * 6. ≤ª∏¸–¬¿˙ ∑±Ì∫Õ…± ÷◊≈∑®±Ì°£
     */
    int32_t SearchStruct::SearchRoot(int32_t nDepth)
    {
        int32_t nNewDepth, vlBest, vl, mv, nCurrMove;
#ifndef CCHESS_A3800
        uint32_t dwMoveStr;
#endif
        uint16_t wmvPvLine[Xiangqi::LIMIT_DEPTH];
        // ∏˘Ω·µ„À—À˜¿˝≥Ã∞¸¿®“‘œ¬º∏∏ˆ≤Ω÷Ë£∫
        
        // 1. ≥ı ºªØ
        vlBest = -MATE_VALUE;
        search2.MoveSort.ResetRoot();
        
        // 2. ÷“ªÀ—À˜√ø∏ˆ◊≈∑®(“™π˝¬ÀΩ˚÷π◊≈∑®)
        nCurrMove = 0;
        while ((mv = search2.MoveSort.NextRoot()) != 0) {
            if (pos.MakeMove(mv)) {
#ifndef CCHESS_A3800
                if (search2.bPopCurrMove || bDebug) {
                    dwMoveStr = MOVE_COORD(mv);
                    nCurrMove ++;
                    // printf("info currmove %.4s currmovenumber %d\n", (const char *) &dwMoveStr, nCurrMove);
                    // fflush(stdout);
                }
#endif
                
                // 3. ≥¢ ‘—°‘Ò–‘—”…Ï(÷ªøº¬«Ω´æ¸—”…Ï)
                nNewDepth = (pos.LastMove().ChkChs > 0 ? nDepth : nDepth - 1);
                
                // 4. ÷˜“™±‰¿˝À—À˜
                if (vlBest == -MATE_VALUE) {
                    vl = -SearchPV(-MATE_VALUE, MATE_VALUE, nNewDepth, wmvPvLine);
                    // printf("search root: %d: SearchPV: %d, %d\n", nDepth, vl, vlBest);
                    // __ASSERT(vl > vlBest);
                    if(!(vl > vlBest)){
                        printf("error, ASSERT(vl > vlBest)\n");
                    }
                } else {
                    vl = -SearchCut(-vlBest, nNewDepth);
                    // printf("search root: SearchCut: %d, %d, %d\n", nDepth, vl, vlBest);
                    if (vl > vlBest) { // ’‚¿Ô≤ª–Ë“™" && vl < MATE_VALUE"¡À
                        vl = -SearchPV(-MATE_VALUE, -vlBest, nNewDepth, wmvPvLine);
                        // printf("search root: SearchPV2: %d, %d, %d\n", nDepth, vl, vlBest);
                    }
                }
                pos.UndoMakeMove();
                if (search2.bStop) {
                    // printf("search root: stop: %d\n", vlBest);
                    return vlBest;
                }
                // print all move
                /*{
                    uint32_t dwmv = MOVE_COORD(mv);
                    const char* strMove = moveToString(dwmv);
                    printf("search root: move: depth: %d, %d, %d: %d(%s)\n", nDepth, vl, vlBest, dwmv, strMove);
                    delete [] strMove;
                }*/
                // 5. Alpha-Beta±ﬂΩÁ≈–∂®("vlBest"¥˙ÃÊ¡À"SearchPV()"÷–µƒ"vlAlpha")
                if (vl > vlBest) {
                    
                    // 7. write move scores
                    {
                        uint32_t dwmv = MOVE_COORD(mv);
                        // find old
                        int32_t oldIndex = -1;
                        {
                            for(int32_t i=0; i<nMoveScore; i++){
                                if(moveScores[i].move==dwmv){
                                    oldIndex = i;
                                    break;
                                }
                            }
                        }
                        // update
                        if(oldIndex>=0 && oldIndex<nMoveScore){
                            // update old
                            moveScores[oldIndex].score = vl;
                            moveScores[oldIndex].depth = nDepth;
                        }else{
                            // make new
                            moveScores[nMoveScore].move = dwmv;
                            moveScores[nMoveScore].score = vl;
                            moveScores[oldIndex].depth = nDepth;
                            nMoveScore++;
                        }
                        // TODO print value
                        /*{
                            const char* strMove = moveToString(MOVE_COORD(mv));
                            printf("search normal: move score: %d(%s); value: %d, %d; %s; %d\n", mv, strMove, vl, vlBest, mv==search2.wmvPvLine[0] ? "is 0 index" : "not 0 index", nDepth);
                            delete [] strMove;
                        }*/
                    }
                    
                    // 6. »Áπ˚À—À˜µΩµ⁄“ª◊≈∑®£¨ƒ«√¥"Œ¥∏ƒ±‰◊Óº—◊≈∑®"µƒº∆ ˝∆˜º”1£¨∑Ò‘Ú«Â¡„
                    search2.nUnchanged = (vlBest == -MATE_VALUE ? search2.nUnchanged + 1 : 0);
                    vlBest = vl;
                    
                    // 7.
                    AppendPvLine(search2.wmvPvLine, mv, wmvPvLine);
#ifndef CCHESS_A3800
                    PopPvLine(nDepth, vl);
#endif
                    
                    // 8. »Áπ˚“™øº¬«ÀÊª˙–‘£¨‘ÚAlpha÷µ“™◊˜ÀÊª˙∏°∂Ø£¨µ´“—À—À˜µΩ…±∆Â ±≤ª◊˜ÀÊª˙∏°∂Ø
                    if (vlBest > -WIN_VALUE && vlBest < WIN_VALUE) {
                        vlBest += (rc4Random.NextLong() & nRandomMask) -
                        (rc4Random.NextLong() & nRandomMask);
                        vlBest = (vlBest == pos.DrawValue() ? vlBest - 1 : vlBest);
                    }
                    
                    // 9. ∏¸–¬∏˘Ω·µ„◊≈∑®¡–±Ì
                    search2.MoveSort.UpdateRoot(mv);
                }
            }
        }
        // write move score best
        if(search2.wmvPvLine[0]!=0){
            uint32_t dwmv = MOVE_COORD(search2.wmvPvLine[0]);
            // find old
            int32_t oldIndex = -1;
            {
                for(int32_t i=0; i<nMoveScore; i++){
                    if(moveScores[i].move==dwmv){
                        oldIndex = i;
                        break;
                    }
                }
            }
            // update
            if(oldIndex>=0 && oldIndex<nMoveScore){
                // update old
                moveScores[oldIndex].score = vlBest;
                moveScores[oldIndex].depth = nDepth;
            }else{
                printf("error, why have to make new best moveScore\n");
                // make new
                moveScores[nMoveScore].move = dwmv;
                moveScores[nMoveScore].score = vlBest;
                moveScores[oldIndex].depth = nDepth;
                nMoveScore++;
            }
            // print best move
            /*{
                uint32_t dwmv = MOVE_COORD(search2.wmvPvLine[0]);
                const char* strMove = moveToString(dwmv);
                printf("search root: best move: %d, %d(%s), %d\n", nDepth, dwmv, strMove, vlBest);
                delete [] strMove;
            }*/
        }else{
            printf("error, why search2.wmvPvLine[0]=0\n");
        }
        return vlBest;
    }
    
    // Œ®“ª◊≈∑®ºÏ—È «ElephantEye‘⁄À—À˜…œµƒ“ª¥ÛÃÿ…´£¨”√¿¥≈–∂œ”√“‘ƒ≥÷÷…Ó∂»Ω¯––µƒÀ—À˜ «∑Ò’“µΩ¡ÀŒ®“ª◊≈∑®°£
    // ∆‰‘≠¿Ì «∞—’“µΩµƒ◊Óº—◊≈∑®…Ë≥…Ω˚÷π◊≈∑®£¨»ª∫Û“‘(-WIN_VALUE, 1 - WIN_VALUE)µƒ¥∞ø⁄÷ÿ–¬À—À˜£¨
    // »Áπ˚µÕ≥ˆ±ﬂΩÁ‘ÚÀµ√˜∆‰À˚◊≈∑®∂ºΩ´±ª…±°£
    bool SearchStruct::SearchUnique(int32_t vlBeta, int32_t nDepth)
    {
        int32_t vl, mv;
        search2.MoveSort.ResetRoot(Xiangqi::ROOT_UNIQUE);
        // Ã¯π˝µ⁄“ª∏ˆ◊≈∑®
        while ((mv = search2.MoveSort.NextRoot()) != 0) {
            if (pos.MakeMove(mv)) {
                vl = -SearchCut(1 - vlBeta, pos.LastMove().ChkChs > 0 ? nDepth : nDepth - 1);
                pos.UndoMakeMove();
                if (search2.bStop || vl >= vlBeta) {
                    return false;
                }
            }
        }
        return true;
    }
    
    void SearchStruct::MySearchMain(int32_t nDepth)
    {
        // position not correct
        {
            // draw
            if(pos.IsDraw()){
                printf("error, no best move: draw\n");
            }
            // repStatus
            {
                int32_t repStatus = pos.RepStatus(3);
                if(repStatus>0){
                    printf("error, no best move: repStatus: %d\n", repStatus);
                }
            }
        }
        // book
        if (bUseBook) {
            int32_t resultNumber = 0;
            SearchResult results[MAX_GEN_MOVES];
            int32_t resultChosen = 0;
            
            BookStruct bks[MAX_GEN_MOVES];
            int32_t nBookMoves = MyGetBookMoves(&pos, szBookFile, bks);
            if (nBookMoves > 0) {
                for (int32_t i = 0; i < nBookMoves; i ++) {
                    // print result
                    /*{
                        uint32_t dwMoveStr = MOVE_COORD(bks[i].wmv);
                        printf("info depth 0 score %d pv %.4s %u\n", bks[i].wvl, (const char *) &dwMoveStr, dwMoveStr);
                    }*/
                    // add to result
                    {
                        pos.MakeMove(bks[i].wmv);
                        if (pos.RepStatus(3) == 0) {
                            // write result
                            {
                                results[resultNumber].move = MOVE_COORD(bks[i].wmv);
                                results[resultNumber].score = bks[i].wvl;
                            }
                            resultNumber++;
                        } else{
                            printf("error, why repeat three time\n");
                        }
                        pos.UndoMakeMove();
                    }
                }
                // choose result
                {
                    if(resultNumber>0){
                        // default
                        resultChosen = 0;
                        // random
                        int32_t vl = 0;
                        for (int32_t i = 0; i < resultNumber; i ++) {
                            vl += results[i].score;
                        }
                        // b. ∏˘æ›»®÷ÿÀÊª˙—°‘Ò“ª∏ˆ◊ﬂ∑®
                        vl = rc4Random.NextLong() % (uint32_t) vl;
                        // printf("search: value random: book: %d\n", vl);
                        for (int32_t i = 0; i < resultNumber; i ++) {
                            vl -= results[i].score;
                            if (vl < 0) {
                                resultChosen = i;
                                break;
                            }
                        }
                        // return
                        {
                            mvResult = results[resultChosen].move;
                            return;
                        }
                    }else{
                        // printf("search: don't have any book move\n");
                    }
                }
            }
        }
        
        // random
        if (nDepth <= 0)
        {
            // printf("random move\n");
            // random move
            uint32_t mvs[MAX_GEN_MOVES];
            int32_t nTotal = pos.myGenMoves(mvs);
            if(nTotal>0){
                int32_t randomIndex = rc4Random.NextLong() % (uint32_t) nTotal;
                {
                    if(randomIndex<0 || randomIndex>=nTotal){
                        printf("eror, why chose random index wrong: %d, %d\n", randomIndex, nTotal);
                        randomIndex = 0;
                    }
                }
                // write result
                mvResult = mvs[randomIndex];
            }else{
                printf("error, why don't have any legal move\n");
            }
            return;
        }
        
        // normal search
        {
            int32_t vl, vlLast, nDraw;
            int32_t nCurrTimer, nLimitTimer, nLimitNodes;
            bool bUnique;
            
            // 4. Each move that generates the root node
            search2.MoveSort.InitRoot(pos, nBanMoves, wmvBanList);
            
            // 5. ≥ı ºªØ ±º‰∫Õº∆ ˝∆˜
            search2.bStop = search2.bPonderStop = search2.bPopPv = search2.bPopCurrMove = false;
            search2.nPopDepth = search2.vlPopValue = 0;
            search2.nAllNodes = search2.nMainNodes = search2.nUnchanged = 0;
            search2.wmvPvLine[0] = 0;
            Xiangqi::ClearKiller(search2.wmvKiller);
            Xiangqi::ClearHistory();
            ClearHash(pos);
            // ”…”⁄ ClearHash() –Ë“™œ˚∫ƒ“ª∂® ±º‰£¨À˘“‘º∆ ±¥”’‚“‘∫Ûø™ º±»Ωœ∫œ¿Ì
            search2.llTime = now();
            vlLast = 0;
            // »Áπ˚◊ﬂ¡À10ªÿ∫œŒﬁ”√◊≈∑®£¨ƒ«√¥‘ –Ì÷˜∂ØÃ·∫Õ£¨“‘∫Û√ø∏Ù8ªÿ∫œÃ·∫Õ“ª¥Œ
            nDraw = -pos.LastMove().CptDrw;
            if (nDraw > 5 && ((nDraw - 4) / 2) % 8 == 0) {
                bDraw = true;
            }
            bUnique = false;
            nCurrTimer = 0;
            
            // 6. ◊ˆµ¸¥˙º”…ÓÀ—À˜
            for (int32_t i = 1; i <= nDepth; i ++) {
                // –Ë“™ ‰≥ˆ÷˜“™±‰¿˝ ±£¨µ⁄“ª∏ˆ"info depth n" «≤ª ‰≥ˆµƒ
                if (search2.bPopPv || bDebug) {
                    // printf("info depth %d\n", i);
                }
                
                // 7. ∏˘æ›À—À˜µƒ ±º‰æˆ∂®£¨ «∑Ò–Ë“™ ‰≥ˆ÷˜“™±‰¿˝∫Õµ±«∞Àºøºµƒ◊≈∑®
                search2.bPopPv = (nCurrTimer > 300);
                search2.bPopCurrMove = (nCurrTimer > 3000);
                
                // 8. À—À˜∏˘Ω·µ„
                vl = SearchRoot(i);
                if (search2.bStop) {
                    if (vl > -MATE_VALUE) {
                        vlLast = vl; // Ã¯≥ˆ∫Û£¨vlLastª·”√¿¥≈–∂œ»œ ‰ªÚÕ∂Ωµ£¨À˘“‘–Ë“™∏¯∂®◊ÓΩ¸“ª∏ˆ÷µ
                    }
                    break; // √ª”–Ã¯≥ˆ£¨‘Ú"vl" «ø…øø÷µ
                }
                
                nCurrTimer = (int) (now() - search2.llTime);
                // 9. »Áπ˚À—À˜ ±º‰≥¨π˝  µ± ±œﬁ£¨‘Ú÷’÷πÀ—À˜
                if (nGoMode == GO_MODE_TIMER) {
                    // a. »Áπ˚√ª”– π”√ø’◊≈≤√ºÙ£¨ƒ«√¥  µ± ±œﬁºı∞Î(“ÚŒ™∑÷÷¶“Ú◊”º”±∂¡À)
                    nLimitTimer = (bNullMove ? nProperTimer : nProperTimer / 2);
                    // b. »Áπ˚µ±«∞À—À˜÷µ√ª”–¬‰∫Û«∞“ª≤„∫‹∂‡£¨ƒ«√¥  µ± ±œﬁºı∞Î
                    nLimitTimer = (vl + DROPDOWN_VALUE >= vlLast ? nLimitTimer / 2 : nLimitTimer);
                    // c. »Áπ˚◊Óº—◊≈∑®¡¨–¯∂‡≤„√ª”–±‰ªØ£¨ƒ«√¥  µ± ±œﬁºı∞Î
                    nLimitTimer = (search2.nUnchanged >= UNCHANGED_DEPTH ? nLimitTimer / 2 : nLimitTimer);
                    if (nCurrTimer > nLimitTimer) {
                        if (bPonder) {
                            search2.bPonderStop = true; // »Áπ˚¥¶”⁄∫ÛÃ®Àºøºƒ£ Ω£¨ƒ«√¥÷ª «‘⁄∫ÛÃ®Àºøº√¸÷–∫Û¡¢º¥÷–÷πÀ—À˜°£
                        } else {
                            vlLast = vl;
                            break; // ≤ªπ‹ «∑ÒÃ¯≥ˆ£¨"vlLast"∂º“—∏¸–¬
                        }
                    }
                } else if (nGoMode == GO_MODE_NODES) {
                    // nLimitNodesµƒº∆À„∑Ω∑®”ÎnLimitTimer «“ª—˘µƒ
                    nLimitNodes = (bNullMove ? nNodes : nNodes / 2);
                    nLimitNodes = (vl + DROPDOWN_VALUE >= vlLast ? nLimitNodes / 2 : nLimitNodes);
                    nLimitNodes = (search2.nUnchanged >= UNCHANGED_DEPTH ? nLimitNodes / 2 : nLimitNodes);
                    // GO_MODE_NODESœ¬ «≤ª—”≥§∫ÛÃ®Àºøº ±º‰µƒ
                    if (search2.nAllNodes > nLimitNodes) {
                        vlLast = vl;
                        break;
                    }
                }
                vlLast = vl;
                
                // 10. À—À˜µΩ…±∆Â‘Ú÷’÷πÀ—À˜
                if (vlLast > WIN_VALUE || vlLast < -WIN_VALUE) {
                    break;
                }
                
                // 11.  «Œ®“ª◊≈∑®£¨‘Ú÷’÷πÀ—À˜
                if (SearchUnique(1 - WIN_VALUE, i)) {
                    bUnique = true;
                    break;
                }
            }

            // 12.  ‰≥ˆ◊Óº—◊≈∑®º∞∆‰◊Óº—”¶∂‘(◊˜Œ™∫ÛÃ®Àºøºµƒ≤¬≤‚◊≈∑®)
            if (search2.wmvPvLine[0] != 0) {
                PopPvLine();
                // print result
                {
                    uint32_t dwMoveStr = MOVE_COORD(search2.wmvPvLine[0]);
                    printf("\nsearch: normal: find bestmove %.4s %u\n", (const char *) &dwMoveStr, dwMoveStr);
                    if (search2.wmvPvLine[1] != 0) {
                        dwMoveStr = MOVE_COORD(search2.wmvPvLine[1]);
                        printf("search: normal: find ponder %.4s %u\n\n", (const char *) &dwMoveStr, dwMoveStr);
                    }
                }
                // set result
                mvResult = MOVE_COORD(search2.wmvPvLine[0]);

                // 13. ≈–∂œ «∑Ò»œ ‰ªÚÃ·∫Õ£¨µ´ «æ≠π˝Œ®“ª◊≈∑®ºÏ—Èµƒ≤ª  ∫œ»œ ‰ªÚÃ·∫Õ(“ÚŒ™À—À˜…Ó∂»≤ªπª)
                if (!bUnique) {
                    if (vlLast > -WIN_VALUE && vlLast < -RESIGN_VALUE) {
                        printf("search: normal: should resign\n");
                    } else if (bDraw && !pos.NullSafe() && vlLast < DRAW_OFFER_VALUE * 2) {
                        printf("search: normal: should draw\n");
                    }
                }
            } else {
                printf("nobestmove");
            }
        }
    }
}
