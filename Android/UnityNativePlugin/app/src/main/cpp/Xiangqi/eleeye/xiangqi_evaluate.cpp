/*
evaluate.cpp - Source Code for ElephantEye, Part XI

ElephantEye - a Chinese Chess Program (UCCI Engine)
Designed by Morning Yellow, Version: 3.3, Last Modified: Mar. 2012
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

#include "../base/xiangqi_base.hpp"
#include "xiangqi_pregen.hpp"
#include "xiangqi_position.hpp"
#include "xiangqi_preeval.hpp"
#include "xiangqi_evaluate.hpp"

namespace Xiangqi
{
#if _WIN32
    
#include <windows.h>
    
    extern "C" __declspec(dllexport) int32_t WINAPI Evaluate(const PositionStruct *lppos, int32_t vlAlpha, int32_t vlBeta);
    extern "C" __declspec(dllexport) const char *WINAPI GetEngineName(void);
    
#else
    
#define WINAPI
    
    extern "C" int32_t Evaluate(const PositionStruct *lppos, int32_t vlAlpha, int32_t vlBeta);
    extern "C" const char *GetEngineName(void);
    
#endif
    
    
    /* ElephantEye???????????????????????
     *
     * sq: ???????(????????0??255??????"pregen.cpp")
     * pc: ???????(????????0??47??????"position.cpp")
     * pt: ???????????(????????0??6??????"position.cpp")
     * mv: ???(????????0??65535??????"position.cpp")
     * sd: ?????(??????0???????1??????)
     * vl: ??????(????????"-MATE_VALUE"??"MATE_VALUE"??????"position.cpp")
     * (????????????????uc??dw???????????????????)
     * pos: ????(PositionStruct?????????"position.h")
     * sms: ???????????????????(????"pregen.h")
     * smv: ??????????????????(????"pregen.h")
     */
    
    // ??????????
    const int32_t EVAL_MARGIN1 = 160;
    const int32_t EVAL_MARGIN2 = 80;
    const int32_t EVAL_MARGIN3 = 40;
    const int32_t EVAL_MARGIN4 = 20;
    
    // ??????????"PositionStruct"???"sdPlayer"??"ucpcSquares"??"ucsqPieces"??"wBitPiece"?????????????????"this->"
    
    /* ElephantEye??????????????4??4????
     * 1. ????(?)????????????????????"AdvisorShape()"??
     * 2. ??????????(??)???????????????"StringHold()"??
     * 3. ?????????????????"RookMobility()"??
     * 4. ????????????????"KnightTrap()"??
     */
    
    // ??????????????????????????
    
    /* ??(?)??????????????????????????????????????????????????????ElephantEye?????????????
     * 1. ?(??)?????????(?)???????????1?????????????????????????????
     * 2. ?(??)?????????(?)????????(??)?????2????????????????????????????????(??)???
     * 3. ?(??)?????????(?)????????(??)?????3????????????????????????????????(??)???
     * 4. ??????????????(??)???????????(?)???????0??
     * ?????????????????????????????????????
     */
    const int32_t WHITE_KING_BITFILE = 1 << (RANK_BOTTOM - RANK_TOP);
    const int32_t BLACK_KING_BITFILE = 1 << (RANK_TOP - RANK_TOP);
    const int32_t KING_BITRANK = 1 << (FILE_CENTER - FILE_LEFT);
    
    const int32_t SHAPE_NONE = 0;
    const int32_t SHAPE_CENTER = 1;
    const int32_t SHAPE_LEFT = 2;
    const int32_t SHAPE_RIGHT = 3;

    int32_t PositionStruct::AdvisorShape(void) {
        // printf("position: advisorShap\n");
        int32_t pcCannon, pcRook, sq, sqAdv1, sqAdv2, x, y, nShape;
        int32_t vlWhitePenalty, vlBlackPenalty;
        SlideMaskStruct *lpsms;
        vlWhitePenalty = vlBlackPenalty = 0;
        if ((this->wBitPiece[0] & ADVISOR_BITPIECE) == ADVISOR_BITPIECE) {
            if (this->ucsqPieces[SIDE_TAG(0) + KING_FROM] == 0xc7) {
                sqAdv1 = this->ucsqPieces[SIDE_TAG(0) + ADVISOR_FROM];
                sqAdv2 = this->ucsqPieces[SIDE_TAG(0) + ADVISOR_TO];
                if (false) {
                } else if (sqAdv1 == 0xc6) { // ???????????????
                    nShape = (sqAdv2 == 0xc8 ? SHAPE_CENTER : sqAdv2 == 0xb7 ? SHAPE_LEFT : SHAPE_NONE);
                } else if (sqAdv1 == 0xc8) { // ???????????????
                    nShape = (sqAdv2 == 0xc6 ? SHAPE_CENTER : sqAdv2 == 0xb7 ? SHAPE_RIGHT : SHAPE_NONE);
                } else if (sqAdv1 == 0xb7) { // ????????????
                    nShape = (sqAdv2 == 0xc6 ? SHAPE_LEFT : sqAdv2 == 0xc8 ? SHAPE_RIGHT : SHAPE_NONE);
                } else {
                    nShape = SHAPE_NONE;
                }
                switch (nShape) {
                    case SHAPE_NONE:
                        break;
                    case SHAPE_CENTER:
                        for (pcCannon = SIDE_TAG(1) + CANNON_FROM; pcCannon <= SIDE_TAG(1) + CANNON_TO; pcCannon ++) {
                            sq = this->ucsqPieces[pcCannon];
                            if (sq != 0) {
                                x = FILE_X(sq);
                                if (x == FILE_CENTER) {
                                    y = RANK_Y(sq);
                                    lpsms = this->FileMaskPtr(x, y);
                                    if ((lpsms->wRookCap & WHITE_KING_BITFILE) != 0) {
                                        // ????????????
                                        vlWhitePenalty += PreEvalEx.vlHollowThreat[RANK_FLIP(y)];
                                    } else if ((lpsms->wSuperCap & WHITE_KING_BITFILE) != 0 &&
                                               (this->ucpcSquares[0xb7] == 21 || this->ucpcSquares[0xb7] == 22)) {
                                        // ??????????????????
                                        vlWhitePenalty += PreEvalEx.vlCentralThreat[RANK_FLIP(y)];
                                    }
                                }
                            }
                        }
                        break;
                    case SHAPE_LEFT:
                    case SHAPE_RIGHT:
                        for (pcCannon = SIDE_TAG(1) + CANNON_FROM; pcCannon <= SIDE_TAG(1) + CANNON_TO; pcCannon ++) {
                            sq = this->ucsqPieces[pcCannon];
                            if (sq != 0) {
                                x = FILE_X(sq);
                                y = RANK_Y(sq);
                                if (x == FILE_CENTER) {
                                    if ((this->FileMaskPtr(x, y)->wSuperCap & WHITE_KING_BITFILE) != 0) {
                                        // ??????????????????(??)???????????????????
                                        vlWhitePenalty += (PreEvalEx.vlCentralThreat[RANK_FLIP(y)] >> 2) +
                                        (this->Protected(1, nShape == SHAPE_LEFT ? 0xc8 : 0xc6) ? 20 : 0);
                                        // ??????????????(??)???????????????
                                        for (pcRook = SIDE_TAG(0) + ROOK_FROM; pcRook <= SIDE_TAG(0) + ROOK_TO; pcRook ++) {
                                            sq = this->ucsqPieces[pcRook];
                                            if (sq != 0) {
                                                y = RANK_Y(sq);
                                                if (y == RANK_BOTTOM) {
                                                    x = FILE_X(sq);
                                                    if ((this->RankMaskPtr(x, y)->wRookCap & KING_BITRANK) != 0) {
                                                        vlWhitePenalty += 80;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                } else if (y == RANK_BOTTOM) {
                                    if ((this->RankMaskPtr(x, y)->wRookCap & KING_BITRANK) != 0) {
                                        // ?????????????
                                        vlWhitePenalty += PreEvalEx.vlWhiteBottomThreat[x];
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            } else if (this->ucsqPieces[SIDE_TAG(0) + KING_FROM] == 0xb7) {
                // ?????(?)????????(??)????????
                vlWhitePenalty += 20;
            }
        } else {
            if ((this->wBitPiece[1] & ROOK_BITPIECE) == ROOK_BITPIECE) {
                // ???(?)????????????
                vlWhitePenalty += PreEvalEx.vlWhiteAdvisorLeakage;
            }
        }
        if ((this->wBitPiece[1] & ADVISOR_BITPIECE) == ADVISOR_BITPIECE) {
            if (this->ucsqPieces[SIDE_TAG(1) + KING_FROM] == 0x37) {
                sqAdv1 = this->ucsqPieces[SIDE_TAG(1) + ADVISOR_FROM];
                sqAdv2 = this->ucsqPieces[SIDE_TAG(1) + ADVISOR_TO];
                if (false) {
                } else if (sqAdv1 == 0x36) { // ???????????????
                    nShape = (sqAdv2 == 0x38 ? SHAPE_CENTER : sqAdv2 == 0x47 ? SHAPE_LEFT : SHAPE_NONE);
                } else if (sqAdv1 == 0x38) { // ???????????????
                    nShape = (sqAdv2 == 0x36 ? SHAPE_CENTER : sqAdv2 == 0x47 ? SHAPE_RIGHT : SHAPE_NONE);
                } else if (sqAdv1 == 0x47) { // ????????????
                    nShape = (sqAdv2 == 0x36 ? SHAPE_LEFT : sqAdv2 == 0x38 ? SHAPE_RIGHT : SHAPE_NONE);
                } else {
                    nShape = SHAPE_NONE;
                }
                switch (nShape) {
                    case SHAPE_NONE:
                        break;
                    case SHAPE_CENTER:
                        for (pcCannon = SIDE_TAG(0) + CANNON_FROM; pcCannon <= SIDE_TAG(0) + CANNON_TO; pcCannon ++) {
                            sq = this->ucsqPieces[pcCannon];
                            if (sq != 0) {
                                x = FILE_X(sq);
                                if (x == FILE_CENTER) {
                                    y = RANK_Y(sq);
                                    lpsms = this->FileMaskPtr(x, y);
                                    if ((lpsms->wRookCap & BLACK_KING_BITFILE) != 0) {
                                        // ????????????
                                        vlBlackPenalty += PreEvalEx.vlHollowThreat[y];
                                    } else if ((lpsms->wSuperCap & BLACK_KING_BITFILE) != 0 &&
                                               (this->ucpcSquares[0x47] == 37 || this->ucpcSquares[0x47] == 38)) {
                                        // ??????????????????
                                        vlBlackPenalty += PreEvalEx.vlCentralThreat[y];
                                    }
                                }
                            }
                        }
                        break;
                    case SHAPE_LEFT:
                    case SHAPE_RIGHT:
                        for (pcCannon = SIDE_TAG(0) + CANNON_FROM; pcCannon <= SIDE_TAG(0) + CANNON_TO; pcCannon ++) {
                            sq = this->ucsqPieces[pcCannon];
                            if (sq != 0) {
                                x = FILE_X(sq);
                                y = RANK_Y(sq);
                                if (x == FILE_CENTER) {
                                    if ((this->FileMaskPtr(x, y)->wSuperCap & BLACK_KING_BITFILE) != 0) {
                                        // ??????????????????(??)???????????????????
                                        vlBlackPenalty += (PreEvalEx.vlCentralThreat[y] >> 2) +
                                        (this->Protected(0, nShape == SHAPE_LEFT ? 0x38 : 0x36) ? 20 : 0);
                                        // ??????????????(??)???????????????
                                        for (pcRook = SIDE_TAG(1) + ROOK_FROM; pcRook <= SIDE_TAG(1) + ROOK_TO; pcRook ++) {
                                            sq = this->ucsqPieces[pcRook];
                                            if (sq != 0) {
                                                y = RANK_Y(sq);
                                                if (y == RANK_TOP) {
                                                    x = FILE_X(sq);
                                                    if ((this->RankMaskPtr(x, y)->wRookCap & KING_BITRANK) != 0) {
                                                        vlBlackPenalty += 80;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                } else if (y == RANK_TOP) {
                                    if ((this->RankMaskPtr(x, y)->wRookCap & KING_BITRANK) != 0) {
                                        // ?????????????
                                        vlBlackPenalty += PreEvalEx.vlBlackBottomThreat[x];
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            } else if (this->ucsqPieces[SIDE_TAG(1) + KING_FROM] == 0x47) {
                // ?????(?)????????(??)????????
                vlBlackPenalty += 20;
            }
        } else {
            if ((this->wBitPiece[0] & ROOK_BITPIECE) == ROOK_BITPIECE) {
                // ???(?)????????????
                vlBlackPenalty += PreEvalEx.vlBlackAdvisorLeakage;
            }
        }
        return SIDE_VALUE(this->sdPlayer, vlBlackPenalty - vlWhitePenalty);
    }
    
    // ??????????????????????????
    
    // ?????????????????????
    
    // ??????"cnValuableStringPieces"???????????????
    // ????0????????????????????????(?????)????????????1???????????????????????????
    static const int32_t cnValuableStringPieces[48] = {
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 2, 2, 0, 0, 1, 1, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 2, 2, 0, 0, 1, 1, 0, 0, 0, 0, 0
    };
    
    // "ccvlStringValueTab"??????"KNIGHT_PIN_TAB"???????(????"pregen.h")???????????
    // ????????????????????????????????
    static const char ccvlStringValueTab[512] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 12,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 16,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 20,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 24,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 28,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 32,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 36,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 40,  0,  0,  0,  0,  0,  0,  0,  0,
        12, 16, 20, 24, 28, 32, 36,  0, 36, 32, 28, 24, 20, 16, 12,  0,
        0,  0,  0,  0,  0,  0,  0, 40,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 36,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 32,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 28,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 24,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 20,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 16,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 12,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0
    };
    
    // ??????????(??)????????????
    int32_t PositionStruct::StringHold(void) {
        // printf("position: stringHold\n");
        int32_t sd, i, j, nDir, sqSrc, sqDst, sqStr;
        int32_t x, y, nSideTag, nOppSideTag;
        int32_t vlString[2];
        SlideMoveStruct *lpsmv;
        
        for (sd = 0; sd < 2; sd ++) {
            vlString[sd] = 0;
            nSideTag = SIDE_TAG(sd);
            nOppSideTag = OPP_SIDE_TAG(sd);
            // ????????????????
            for (i = ROOK_FROM; i <= ROOK_TO; i ++) {
                sqSrc = this->ucsqPieces[nSideTag + i];
                if (sqSrc != 0) {
                    // __ASSERT_SQUARE(sqSrc);
                    if(!IF_SQUARE(sqSrc)){
                        printf("error, ASSERT_SQUARE(sqSrc)\n");
                        sqSrc = 128;
                    }
                    // ?????????????(??)?????
                    sqDst = this->ucsqPieces[nOppSideTag + KING_FROM];
                    if (sqDst != 0) {
                        // __ASSERT_SQUARE(sqDst);
                        if(!IF_SQUARE(sqDst)){
                            printf("error, ASSERT_SQUARE(sqDst)\n");
                            sqDst = 128;
                        }
                        x = FILE_X(sqSrc);
                        y = RANK_Y(sqSrc);
                        if (x == FILE_X(sqDst)) {
                            lpsmv = this->FileMovePtr(x, y);
                            nDir = (sqSrc < sqDst ? 0 : 1);
                            // ????????????(?????????????)?????????"sqDst"???????????????
                            if (sqDst == lpsmv->ucCannonCap[nDir] + FILE_DISP(x)) {
                                // ???????"sqStr"???(??)??????????????????
                                sqStr = lpsmv->ucRookCap[nDir] + FILE_DISP(x);
                                // __ASSERT_SQUARE(sqStr);
                                if(!IF_SQUARE(sqStr)){
                                    printf("error, ASSERT_SQUARE(sqStr)\n");
                                    sqStr = 128;
                                }
                                // ??????????????????????
                                if ((this->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                    // ???????????????????????????????????(??????????????)????????????????????
                                    if (cnValuableStringPieces[this->ucpcSquares[sqStr]] > 0 &&
                                        !this->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                        vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                    }
                                }
                            }
                        } else if (y == RANK_Y(sqDst)) {
                            lpsmv = this->RankMovePtr(x, y);
                            nDir = (sqSrc < sqDst ? 0 : 1);
                            if (sqDst == lpsmv->ucCannonCap[nDir] + RANK_DISP(y)) {
                                sqStr = lpsmv->ucRookCap[nDir] + RANK_DISP(y);
                                // __ASSERT_SQUARE(sqStr);
                                if(!IF_SQUARE(sqStr)){
                                    printf("error, ASSERT_SQUARE(sqStr)\n");
                                    sqStr = 128;
                                }
                                if ((this->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                    if (cnValuableStringPieces[this->ucpcSquares[sqStr]] > 0 &&
                                        !this->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                        vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                    }
                                }
                            }
                        }
                    }
                    // ??????????????????
                    for (j = ROOK_FROM; j <= ROOK_TO; j ++) {
                        sqDst = this->ucsqPieces[nOppSideTag + j];
                        if (sqDst != 0) {
                            // __ASSERT_SQUARE(sqDst);
                            if(!IF_SQUARE(sqDst)){
                                printf("error, ASSERT_SQUARE(sqDst)\n");
                                sqDst = 128;
                            }
                            x = FILE_X(sqSrc);
                            y = RANK_Y(sqSrc);
                            if (x == FILE_X(sqDst)) {
                                lpsmv = this->FileMovePtr(x, y);
                                nDir = (sqSrc < sqDst ? 0 : 1);
                                if (sqDst == lpsmv->ucCannonCap[nDir] + FILE_DISP(x)) {
                                    sqStr = lpsmv->ucRookCap[nDir] + FILE_DISP(x);
                                    // __ASSERT_SQUARE(sqStr);
                                    if(!IF_SQUARE(sqStr)){
                                        printf("error, ASSERT_SQUARE(sqStr)\n");
                                        sqStr = 128;
                                    }
                                    if ((this->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                        // ????????????????(??)???????????????????????????
                                        if (cnValuableStringPieces[this->ucpcSquares[sqStr]] > 0 &&
                                            !this->Protected(OPP_SIDE(sd), sqDst) && !this->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                            vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                        }
                                    }
                                }
                            } else if (y == RANK_Y(sqDst)) {
                                lpsmv = this->RankMovePtr(x, y);
                                nDir = (sqSrc < sqDst ? 0 : 1);
                                if (sqDst == lpsmv->ucCannonCap[nDir] + RANK_DISP(y)) {
                                    sqStr = lpsmv->ucRookCap[nDir] + RANK_DISP(y);
                                    // __ASSERT_SQUARE(sqStr);
                                    if(!IF_SQUARE(sqStr)){
                                        printf("error, ASSERT_SQUARE(sqStr)\n");
                                        sqStr = 128;
                                    }
                                    if ((this->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                        if (cnValuableStringPieces[this->ucpcSquares[sqStr]] > 0 &&
                                            !this->Protected(OPP_SIDE(sd), sqDst) && !this->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                            vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            // ?????????????????
            for (i = CANNON_FROM; i <= CANNON_TO; i ++) {
                sqSrc = this->ucsqPieces[nSideTag + i];
                if (sqSrc != 0) {
                    // __ASSERT_SQUARE(sqSrc);
                    if(!IF_SQUARE(sqSrc)){
                        printf("error, ASSERT_SQUARE(sqSrc)\n");
                        sqSrc = 128;
                    }
                    // ?????????????(??)?????
                    sqDst = this->ucsqPieces[nOppSideTag + KING_FROM];
                    if (sqDst != 0) {
                        // __ASSERT_SQUARE(sqDst);
                        if(!IF_SQUARE(sqDst)){
                            printf("error, ASSERT_SQUARE(sqDst)\n");
                            sqDst = 128;
                        }
                        x = FILE_X(sqSrc);
                        y = RANK_Y(sqSrc);
                        if (x == FILE_X(sqDst)) {
                            lpsmv = this->FileMovePtr(x, y);
                            nDir = (sqSrc < sqDst ? 0 : 1);
                            if (sqDst == lpsmv->ucSuperCap[nDir] + FILE_DISP(x)) {
                                sqStr = lpsmv->ucCannonCap[nDir] + FILE_DISP(x);
                                // __ASSERT_SQUARE(sqStr);
                                if(!IF_SQUARE(sqStr)){
                                    printf("error, ASSERT_SQUARE(sqStr)\n");
                                    sqStr = 128;
                                }
                                if ((this->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                    if (cnValuableStringPieces[this->ucpcSquares[sqStr]] > 1 &&
                                        !this->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                        vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                    }
                                }
                            }
                        } else if (y == RANK_Y(sqDst)) {
                            lpsmv = this->RankMovePtr(x, y);
                            nDir = (sqSrc < sqDst ? 0 : 1);
                            if (sqDst == lpsmv->ucSuperCap[nDir] + RANK_DISP(y)) {
                                sqStr = lpsmv->ucCannonCap[nDir] + RANK_DISP(y);
                                // __ASSERT_SQUARE(sqStr);
                                if(!IF_SQUARE(sqStr)){
                                    printf("error, ASSERT_SQUARE(sqStr)\n");
                                    sqStr = 128;
                                }
                                if ((this->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                    if (cnValuableStringPieces[this->ucpcSquares[sqStr]] > 1 &&
                                        !this->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                        vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                    }
                                }
                            }
                        }
                    }
                    // ??????????????????
                    for (j = ROOK_FROM; j <= ROOK_TO; j ++) {
                        sqDst = this->ucsqPieces[nOppSideTag + j];
                        if (sqDst != 0) {
                            // __ASSERT_SQUARE(sqDst);
                            if(!IF_SQUARE(sqDst)){
                                printf("error, ASSERT_SQUARE(sqDst)\n");
                                sqDst = 128;
                            }
                            x = FILE_X(sqSrc);
                            y = RANK_Y(sqSrc);
                            if (x == FILE_X(sqDst)) {
                                lpsmv = this->FileMovePtr(x, y);
                                nDir = (sqSrc < sqDst ? 0 : 1);
                                if (sqDst == lpsmv->ucSuperCap[nDir] + FILE_DISP(x)) {
                                    sqStr = lpsmv->ucCannonCap[nDir] + FILE_DISP(x);
                                    // __ASSERT_SQUARE(sqStr);
                                    if(!IF_SQUARE(sqStr)){
                                        printf("error, ASSERT_SQUARE(sqStr)\n");
                                        sqStr = 128;
                                    }
                                    if ((this->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                        if (cnValuableStringPieces[this->ucpcSquares[sqStr]] > 1 &&
                                            !this->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                            vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                        }
                                    }
                                }
                            } else if (y == RANK_Y(sqDst)) {
                                lpsmv = this->RankMovePtr(x, y);
                                nDir = (sqSrc < sqDst ? 0 : 1);
                                if (sqDst == lpsmv->ucSuperCap[nDir] + RANK_DISP(y)) {
                                    sqStr = lpsmv->ucCannonCap[nDir] + RANK_DISP(y);
                                    // __ASSERT_SQUARE(sqStr);
                                    if(!IF_SQUARE(sqStr)){
                                        printf("error, ASSERT_SQUARE(sqStr)\n");
                                        sqStr = 128;
                                    }
                                    if ((this->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                        if (cnValuableStringPieces[this->ucpcSquares[sqStr]] > 1 &&
                                            !this->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                            vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return SIDE_VALUE(this->sdPlayer, vlString[0] - vlString[1]);
    }
    
    // ?????????????????????
    
    // ????????????????????????????

    int32_t PositionStruct::RookMobility(void) {
        // printf("position: rookMobility\n");
        int32_t sd, i, sqSrc, nSideTag, x, y;
        int32_t vlRookMobility[2];
        for (sd = 0; sd < 2; sd ++) {
            vlRookMobility[sd] = 0;
            nSideTag = SIDE_TAG(sd);
            for (i = ROOK_FROM; i <= ROOK_TO; i ++) {
                sqSrc = this->ucsqPieces[nSideTag + i];
                if (sqSrc != 0) {
                    // __ASSERT_SQUARE(sqSrc);
                    if(!IF_SQUARE(sqSrc)){
                        printf("error, ASSERT_SQUARE(sqSrc)\n");
                        sqSrc = 128;
                    }
                    x = FILE_X(sqSrc);
                    y = RANK_Y(sqSrc);
                    vlRookMobility[sd] += PreEvalEx.cPopCnt16[this->RankMaskPtr(x, y)->wNonCap] +
                    PreEvalEx.cPopCnt16[this->FileMaskPtr(x, y)->wNonCap];
                }
            }
            // TODO tam bo __ASSERT(vlRookMobility[sd] <= 34);
            if(vlRookMobility[sd] > 34){
                // printf("error: position: rookMobility: __ASSERT(vlRookMobility[sd] <= 34): %d, %d\n", vlRookMobility[sd], sd);
                vlRookMobility[sd] = 34;
            }
        }
        return SIDE_VALUE(this->sdPlayer, vlRookMobility[0] - vlRookMobility[1]) >> 1;
    }
    
    // ????????????????????????????
    
    // ??????????????????????????
    
    // ??????"cbcEdgeSquares"?????????????????????????????????????????????????
    static const bool cbcEdgeSquares[256] = {
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0,
        0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
    };

    int32_t PositionStruct::KnightTrap(void) {
        // printf("position: knightTrap\n");
        int32_t sd, i, sqSrc, sqDst, nSideTag, nMovable;
        uint8_t *lpucsqDst, *lpucsqPin;
        int32_t vlKnightTraps[2];
        
        for (sd = 0; sd < 2; sd ++) {
            vlKnightTraps[sd] = 0;
            nSideTag = SIDE_TAG(sd);
            // ????????????????????????????????????????????????????
            for (i = KNIGHT_FROM; i <= KNIGHT_TO; i ++) {
                sqSrc = this->ucsqPieces[nSideTag + i];
                if (sqSrc != 0) {
                    // __ASSERT_SQUARE(sqSrc);
                    if(!IF_SQUARE(sqSrc)){
                        printf("error, ASSERT_SQUARE(sqSrc)\n");
                        sqSrc = 128;
                    }
                    nMovable = 0;
                    lpucsqDst = myPreGen->PreGen.ucsqKnightMoves[sqSrc];
                    lpucsqPin = myPreGen->PreGen.ucsqKnightPins[sqSrc];
                    sqDst = *lpucsqDst;
                    while (sqDst != 0) {
                        // __ASSERT_SQUARE(sqDst);
                        if(IF_SQUARE(sqDst)){
                            printf("error, ASSERT_SQUARE(sqDst)\n");
                            sqDst = 128;
                        }
                        // ??????????????"genmoves.cpp"?????????????????????????????????????????????
                        if (!cbcEdgeSquares[sqDst] && this->ucpcSquares[sqDst] == 0 &&
                            this->ucpcSquares[*lpucsqPin] == 0 && !this->Protected(OPP_SIDE(sd), sqDst)) {
                            nMovable ++;
                            if (nMovable > 1) {
                                break;
                            }
                        }
                        lpucsqDst ++;
                        sqDst = *lpucsqDst;
                        lpucsqPin ++;
                    }
                    // ???????????????10?????????????????????????5?????
                    if (nMovable == 0) {
                        vlKnightTraps[sd] += 10;
                    } else if (nMovable == 1) {
                        vlKnightTraps[sd] += 5;
                    }
                }
                // __ASSERT(vlKnightTraps[sd] <= 20);
                if(!(vlKnightTraps[sd] <= 20)){
                    printf("error, ASSERT(vlKnightTraps[sd] <= 20)\n");
                    vlKnightTraps[sd] = 20;
                }
            }
        }
        return SIDE_VALUE(this->sdPlayer, vlKnightTraps[1] - vlKnightTraps[0]);
    }
    
    // ??????????????????????????
    
    // ???????????
    int32_t PositionStruct::Evaluate(int32_t vlAlpha, int32_t vlBeta) {
        int32_t vl;
        // ????????????????????????????
        
        // 1. ??????????(???????????)??????????????
        vl = this->Material();
        if (vl + EVAL_MARGIN1 <= vlAlpha) {
            return vl + EVAL_MARGIN1;
        } else if (vl - EVAL_MARGIN1 >= vlBeta) {
            return vl - EVAL_MARGIN1;
        }
        
        // 2. ?????????????????????????
        vl += this->AdvisorShape();
        if (vl + EVAL_MARGIN2 <= vlAlpha) {
            return vl + EVAL_MARGIN2;
        } else if (vl - EVAL_MARGIN2 >= vlBeta) {
            return vl - EVAL_MARGIN2;
        }
        
        // 3. ????????????????????
        vl += this->StringHold();
        if (vl + EVAL_MARGIN3 <= vlAlpha) {
            return vl + EVAL_MARGIN3;
        } else if (vl - EVAL_MARGIN3 >= vlBeta) {
            return vl - EVAL_MARGIN3;
        }
        
        // 4. ?????????????????????????
        vl += this->RookMobility();
        if (vl + EVAL_MARGIN4 <= vlAlpha) {
            return vl + EVAL_MARGIN4;
        } else if (vl - EVAL_MARGIN4 >= vlBeta) {
            return vl - EVAL_MARGIN4;
        }
        
        // 5. ?????????(???????)?????????????
        int32_t ret = vl + this->KnightTrap();
        printf("position evaluate: %d; %d, %d\n", vlAlpha, vlBeta, ret);
        return ret;
    }

    int32_t AdvisorShape(PositionStruct *lppos) {
        int32_t pcCannon, pcRook, sq, sqAdv1, sqAdv2, x, y, nShape;
        int32_t vlWhitePenalty, vlBlackPenalty;
        SlideMaskStruct *lpsms;
        vlWhitePenalty = vlBlackPenalty = 0;
        if ((lppos->wBitPiece[0] & ADVISOR_BITPIECE) == ADVISOR_BITPIECE) {
            if (lppos->ucsqPieces[SIDE_TAG(0) + KING_FROM] == 0xc7) {
                sqAdv1 = lppos->ucsqPieces[SIDE_TAG(0) + ADVISOR_FROM];
                sqAdv2 = lppos->ucsqPieces[SIDE_TAG(0) + ADVISOR_TO];
                if (false) {
                } else if (sqAdv1 == 0xc6) { // ???????????????
                    nShape = (sqAdv2 == 0xc8 ? SHAPE_CENTER : sqAdv2 == 0xb7 ? SHAPE_LEFT : SHAPE_NONE);
                } else if (sqAdv1 == 0xc8) { // ???????????????
                    nShape = (sqAdv2 == 0xc6 ? SHAPE_CENTER : sqAdv2 == 0xb7 ? SHAPE_RIGHT : SHAPE_NONE);
                } else if (sqAdv1 == 0xb7) { // ????????????
                    nShape = (sqAdv2 == 0xc6 ? SHAPE_LEFT : sqAdv2 == 0xc8 ? SHAPE_RIGHT : SHAPE_NONE);
                } else {
                    nShape = SHAPE_NONE;
                }
                switch (nShape) {
                    case SHAPE_NONE:
                        break;
                    case SHAPE_CENTER:
                        for (pcCannon = SIDE_TAG(1) + CANNON_FROM; pcCannon <= SIDE_TAG(1) + CANNON_TO; pcCannon ++) {
                            sq = lppos->ucsqPieces[pcCannon];
                            if (sq != 0) {
                                x = FILE_X(sq);
                                if (x == FILE_CENTER) {
                                    y = RANK_Y(sq);
                                    lpsms = lppos->FileMaskPtr(x, y);
                                    if ((lpsms->wRookCap & WHITE_KING_BITFILE) != 0) {
                                        // ????????????
                                        vlWhitePenalty += lppos->PreEvalEx.vlHollowThreat[RANK_FLIP(y)];
                                    } else if ((lpsms->wSuperCap & WHITE_KING_BITFILE) != 0 &&
                                               (lppos->ucpcSquares[0xb7] == 21 || lppos->ucpcSquares[0xb7] == 22)) {
                                        // ??????????????????
                                        vlWhitePenalty += lppos->PreEvalEx.vlCentralThreat[RANK_FLIP(y)];
                                    }
                                }
                            }
                        }
                        break;
                    case SHAPE_LEFT:
                    case SHAPE_RIGHT:
                        for (pcCannon = SIDE_TAG(1) + CANNON_FROM; pcCannon <= SIDE_TAG(1) + CANNON_TO; pcCannon ++) {
                            sq = lppos->ucsqPieces[pcCannon];
                            if (sq != 0) {
                                x = FILE_X(sq);
                                y = RANK_Y(sq);
                                if (x == FILE_CENTER) {
                                    if ((lppos->FileMaskPtr(x, y)->wSuperCap & WHITE_KING_BITFILE) != 0) {
                                        // ??????????????????(??)???????????????????
                                        vlWhitePenalty += (lppos->PreEvalEx.vlCentralThreat[RANK_FLIP(y)] >> 2) +
                                        (lppos->Protected(1, nShape == SHAPE_LEFT ? 0xc8 : 0xc6) ? 20 : 0);
                                        // ??????????????(??)???????????????
                                        for (pcRook = SIDE_TAG(0) + ROOK_FROM; pcRook <= SIDE_TAG(0) + ROOK_TO; pcRook ++) {
                                            sq = lppos->ucsqPieces[pcRook];
                                            if (sq != 0) {
                                                y = RANK_Y(sq);
                                                if (y == RANK_BOTTOM) {
                                                    x = FILE_X(sq);
                                                    if ((lppos->RankMaskPtr(x, y)->wRookCap & KING_BITRANK) != 0) {
                                                        vlWhitePenalty += 80;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                } else if (y == RANK_BOTTOM) {
                                    if ((lppos->RankMaskPtr(x, y)->wRookCap & KING_BITRANK) != 0) {
                                        // ?????????????
                                        vlWhitePenalty += lppos->PreEvalEx.vlWhiteBottomThreat[x];
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            } else if (lppos->ucsqPieces[SIDE_TAG(0) + KING_FROM] == 0xb7) {
                // ?????(?)????????(??)????????
                vlWhitePenalty += 20;
            }
        } else {
            if ((lppos->wBitPiece[1] & ROOK_BITPIECE) == ROOK_BITPIECE) {
                // ???(?)????????????
                vlWhitePenalty += lppos->PreEvalEx.vlWhiteAdvisorLeakage;
            }
        }
        if ((lppos->wBitPiece[1] & ADVISOR_BITPIECE) == ADVISOR_BITPIECE) {
            if (lppos->ucsqPieces[SIDE_TAG(1) + KING_FROM] == 0x37) {
                sqAdv1 = lppos->ucsqPieces[SIDE_TAG(1) + ADVISOR_FROM];
                sqAdv2 = lppos->ucsqPieces[SIDE_TAG(1) + ADVISOR_TO];
                if (false) {
                } else if (sqAdv1 == 0x36) { // ???????????????
                    nShape = (sqAdv2 == 0x38 ? SHAPE_CENTER : sqAdv2 == 0x47 ? SHAPE_LEFT : SHAPE_NONE);
                } else if (sqAdv1 == 0x38) { // ???????????????
                    nShape = (sqAdv2 == 0x36 ? SHAPE_CENTER : sqAdv2 == 0x47 ? SHAPE_RIGHT : SHAPE_NONE);
                } else if (sqAdv1 == 0x47) { // ????????????
                    nShape = (sqAdv2 == 0x36 ? SHAPE_LEFT : sqAdv2 == 0x38 ? SHAPE_RIGHT : SHAPE_NONE);
                } else {
                    nShape = SHAPE_NONE;
                }
                switch (nShape) {
                    case SHAPE_NONE:
                        break;
                    case SHAPE_CENTER:
                        for (pcCannon = SIDE_TAG(0) + CANNON_FROM; pcCannon <= SIDE_TAG(0) + CANNON_TO; pcCannon ++) {
                            sq = lppos->ucsqPieces[pcCannon];
                            if (sq != 0) {
                                x = FILE_X(sq);
                                if (x == FILE_CENTER) {
                                    y = RANK_Y(sq);
                                    lpsms = lppos->FileMaskPtr(x, y);
                                    if ((lpsms->wRookCap & BLACK_KING_BITFILE) != 0) {
                                        // ????????????
                                        vlBlackPenalty += lppos->PreEvalEx.vlHollowThreat[y];
                                    } else if ((lpsms->wSuperCap & BLACK_KING_BITFILE) != 0 &&
                                               (lppos->ucpcSquares[0x47] == 37 || lppos->ucpcSquares[0x47] == 38)) {
                                        // ??????????????????
                                        vlBlackPenalty += lppos->PreEvalEx.vlCentralThreat[y];
                                    }
                                }
                            }
                        }
                        break;
                    case SHAPE_LEFT:
                    case SHAPE_RIGHT:
                        for (pcCannon = SIDE_TAG(0) + CANNON_FROM; pcCannon <= SIDE_TAG(0) + CANNON_TO; pcCannon ++) {
                            sq = lppos->ucsqPieces[pcCannon];
                            if (sq != 0) {
                                x = FILE_X(sq);
                                y = RANK_Y(sq);
                                if (x == FILE_CENTER) {
                                    if ((lppos->FileMaskPtr(x, y)->wSuperCap & BLACK_KING_BITFILE) != 0) {
                                        // ??????????????????(??)???????????????????
                                        vlBlackPenalty += (lppos->PreEvalEx.vlCentralThreat[y] >> 2) +
                                        (lppos->Protected(0, nShape == SHAPE_LEFT ? 0x38 : 0x36) ? 20 : 0);
                                        // ??????????????(??)???????????????
                                        for (pcRook = SIDE_TAG(1) + ROOK_FROM; pcRook <= SIDE_TAG(1) + ROOK_TO; pcRook ++) {
                                            sq = lppos->ucsqPieces[pcRook];
                                            if (sq != 0) {
                                                y = RANK_Y(sq);
                                                if (y == RANK_TOP) {
                                                    x = FILE_X(sq);
                                                    if ((lppos->RankMaskPtr(x, y)->wRookCap & KING_BITRANK) != 0) {
                                                        vlBlackPenalty += 80;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                } else if (y == RANK_TOP) {
                                    if ((lppos->RankMaskPtr(x, y)->wRookCap & KING_BITRANK) != 0) {
                                        // ?????????????
                                        vlBlackPenalty += lppos->PreEvalEx.vlBlackBottomThreat[x];
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            } else if (lppos->ucsqPieces[SIDE_TAG(1) + KING_FROM] == 0x47) {
                // ?????(?)????????(??)????????
                vlBlackPenalty += 20;
            }
        } else {
            if ((lppos->wBitPiece[0] & ROOK_BITPIECE) == ROOK_BITPIECE) {
                // ???(?)????????????
                vlBlackPenalty += lppos->PreEvalEx.vlBlackAdvisorLeakage;
            }
        }
        return SIDE_VALUE(lppos->sdPlayer, vlBlackPenalty - vlWhitePenalty);
    }

    int32_t StringHold(PositionStruct *lppos) {
        int32_t sd, i, j, nDir, sqSrc, sqDst, sqStr;
        int32_t x, y, nSideTag, nOppSideTag;
        int32_t vlString[2];
        SlideMoveStruct *lpsmv;
        
        for (sd = 0; sd < 2; sd ++) {
            vlString[sd] = 0;
            nSideTag = SIDE_TAG(sd);
            nOppSideTag = OPP_SIDE_TAG(sd);
            // ????????????????
            for (i = ROOK_FROM; i <= ROOK_TO; i ++) {
                sqSrc = lppos->ucsqPieces[nSideTag + i];
                if (sqSrc != 0) {
                    // __ASSERT_SQUARE(sqSrc);
                    if(!IF_SQUARE(sqSrc)){
                        printf("error, ASSERT_SQUARE(sqSrc)\n");
                        sqSrc = 128;
                    }
                    // ?????????????(??)?????
                    sqDst = lppos->ucsqPieces[nOppSideTag + KING_FROM];
                    if (sqDst != 0) {
                        // __ASSERT_SQUARE(sqDst);
                        if(!IF_SQUARE(sqDst)){
                            printf("error, ASSERT_SQUARE(sqDst)\n");
                            sqDst = 128;
                        }
                        x = FILE_X(sqSrc);
                        y = RANK_Y(sqSrc);
                        if (x == FILE_X(sqDst)) {
                            lpsmv = lppos->FileMovePtr(x, y);
                            nDir = (sqSrc < sqDst ? 0 : 1);
                            // ????????????(?????????????)?????????"sqDst"???????????????
                            if (sqDst == lpsmv->ucCannonCap[nDir] + FILE_DISP(x)) {
                                // ???????"sqStr"???(??)??????????????????
                                sqStr = lpsmv->ucRookCap[nDir] + FILE_DISP(x);
                                // __ASSERT_SQUARE(sqStr);
                                if(!IF_SQUARE(sqStr)){
                                    printf("error, ASSERT_SQUARE(sqStr)\n");
                                    sqStr = 128;
                                }
                                // ??????????????????????
                                if ((lppos->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                    // ???????????????????????????????????(??????????????)????????????????????
                                    if (cnValuableStringPieces[lppos->ucpcSquares[sqStr]] > 0 &&
                                        !lppos->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                        vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                    }
                                }
                            }
                        } else if (y == RANK_Y(sqDst)) {
                            lpsmv = lppos->RankMovePtr(x, y);
                            nDir = (sqSrc < sqDst ? 0 : 1);
                            if (sqDst == lpsmv->ucCannonCap[nDir] + RANK_DISP(y)) {
                                sqStr = lpsmv->ucRookCap[nDir] + RANK_DISP(y);
                                // __ASSERT_SQUARE(sqStr);
                                if(!IF_SQUARE(sqStr)){
                                    printf("error, ASSERT_SQUARE(sqStr)\n");
                                    sqStr = 128;
                                }
                                if ((lppos->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                    if (cnValuableStringPieces[lppos->ucpcSquares[sqStr]] > 0 &&
                                        !lppos->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                        vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                    }
                                }
                            }
                        }
                    }
                    // ??????????????????
                    for (j = ROOK_FROM; j <= ROOK_TO; j ++) {
                        sqDst = lppos->ucsqPieces[nOppSideTag + j];
                        if (sqDst != 0) {
                            // __ASSERT_SQUARE(sqDst);
                            if(!IF_SQUARE(sqDst)){
                                printf("error, ASSERT_SQUARE(sqDst)\n");
                                sqDst = 128;
                            }
                            x = FILE_X(sqSrc);
                            y = RANK_Y(sqSrc);
                            if (x == FILE_X(sqDst)) {
                                lpsmv = lppos->FileMovePtr(x, y);
                                nDir = (sqSrc < sqDst ? 0 : 1);
                                if (sqDst == lpsmv->ucCannonCap[nDir] + FILE_DISP(x)) {
                                    sqStr = lpsmv->ucRookCap[nDir] + FILE_DISP(x);
                                    // __ASSERT_SQUARE(sqStr);
                                    if(!IF_SQUARE(sqStr)){
                                        printf("error, ASSERT_SQUARE(sqStr)\n");
                                        sqStr = 128;
                                    }
                                    if ((lppos->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                        // ????????????????(??)???????????????????????????
                                        if (cnValuableStringPieces[lppos->ucpcSquares[sqStr]] > 0 &&
                                            !lppos->Protected(OPP_SIDE(sd), sqDst) && !lppos->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                            vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                        }
                                    }
                                }
                            } else if (y == RANK_Y(sqDst)) {
                                lpsmv = lppos->RankMovePtr(x, y);
                                nDir = (sqSrc < sqDst ? 0 : 1);
                                if (sqDst == lpsmv->ucCannonCap[nDir] + RANK_DISP(y)) {
                                    sqStr = lpsmv->ucRookCap[nDir] + RANK_DISP(y);
                                    // __ASSERT_SQUARE(sqStr);
                                    if(!IF_SQUARE(sqStr)){
                                        printf("error, ASSERT_SQUARE(sqStr)\n");
                                        sqStr = 128;
                                    }
                                    if ((lppos->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                        if (cnValuableStringPieces[lppos->ucpcSquares[sqStr]] > 0 &&
                                            !lppos->Protected(OPP_SIDE(sd), sqDst) && !lppos->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                            vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            // ?????????????????
            for (i = CANNON_FROM; i <= CANNON_TO; i ++) {
                sqSrc = lppos->ucsqPieces[nSideTag + i];
                if (sqSrc != 0) {
                    // __ASSERT_SQUARE(sqSrc);
                    if(!IF_SQUARE(sqSrc)){
                        printf("error, ASSERT_SQUARE(sqSrc)\n");
                        sqSrc = 128;
                    }
                    // ?????????????(??)?????
                    sqDst = lppos->ucsqPieces[nOppSideTag + KING_FROM];
                    if (sqDst != 0) {
                        // __ASSERT_SQUARE(sqDst);
                        if(!IF_SQUARE(sqDst)){
                            printf("error, ASSERT_SQUARE(sqDst)\n");
                            sqDst = 128;
                        }
                        x = FILE_X(sqSrc);
                        y = RANK_Y(sqSrc);
                        if (x == FILE_X(sqDst)) {
                            lpsmv = lppos->FileMovePtr(x, y);
                            nDir = (sqSrc < sqDst ? 0 : 1);
                            if (sqDst == lpsmv->ucSuperCap[nDir] + FILE_DISP(x)) {
                                sqStr = lpsmv->ucCannonCap[nDir] + FILE_DISP(x);
                                // __ASSERT_SQUARE(sqStr);
                                if(!IF_SQUARE(sqStr)){
                                    printf("error, ASSERT_SQUARE(sqStr)\n");
                                    sqStr = 128;
                                }
                                if ((lppos->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                    if (cnValuableStringPieces[lppos->ucpcSquares[sqStr]] > 1 &&
                                        !lppos->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                        vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                    }
                                }
                            }
                        } else if (y == RANK_Y(sqDst)) {
                            lpsmv = lppos->RankMovePtr(x, y);
                            nDir = (sqSrc < sqDst ? 0 : 1);
                            if (sqDst == lpsmv->ucSuperCap[nDir] + RANK_DISP(y)) {
                                sqStr = lpsmv->ucCannonCap[nDir] + RANK_DISP(y);
                                // __ASSERT_SQUARE(sqStr);
                                if(!IF_SQUARE(sqStr)){
                                    printf("error, ASSERT_SQUARE(sqStr)\n");
                                    sqStr = 128;
                                }
                                if ((lppos->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                    if (cnValuableStringPieces[lppos->ucpcSquares[sqStr]] > 1 &&
                                        !lppos->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                        vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                    }
                                }
                            }
                        }
                    }
                    // ??????????????????
                    for (j = ROOK_FROM; j <= ROOK_TO; j ++) {
                        sqDst = lppos->ucsqPieces[nOppSideTag + j];
                        if (sqDst != 0) {
                            // __ASSERT_SQUARE(sqDst);
                            if(!IF_SQUARE(sqDst)){
                                printf("error, ASSERT_SQUARE(sqDst)\n");
                                sqDst = 128;
                            }
                            x = FILE_X(sqSrc);
                            y = RANK_Y(sqSrc);
                            if (x == FILE_X(sqDst)) {
                                lpsmv = lppos->FileMovePtr(x, y);
                                nDir = (sqSrc < sqDst ? 0 : 1);
                                if (sqDst == lpsmv->ucSuperCap[nDir] + FILE_DISP(x)) {
                                    sqStr = lpsmv->ucCannonCap[nDir] + FILE_DISP(x);
                                    // __ASSERT_SQUARE(sqStr);
                                    if(!IF_SQUARE(sqStr)){
                                        printf("error, ASSERT_SQUARE(sqStr)\n");
                                        sqStr = 128;
                                    }
                                    if ((lppos->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                        if (cnValuableStringPieces[lppos->ucpcSquares[sqStr]] > 1 &&
                                            !lppos->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                            vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                        }
                                    }
                                }
                            } else if (y == RANK_Y(sqDst)) {
                                lpsmv = lppos->RankMovePtr(x, y);
                                nDir = (sqSrc < sqDst ? 0 : 1);
                                if (sqDst == lpsmv->ucSuperCap[nDir] + RANK_DISP(y)) {
                                    sqStr = lpsmv->ucCannonCap[nDir] + RANK_DISP(y);
                                    // __ASSERT_SQUARE(sqStr);
                                    if(!IF_SQUARE(sqStr)){
                                        printf("error, ASSERT_SQUARE(sqStr)\n");
                                        sqStr = 128;
                                    }
                                    if ((lppos->ucpcSquares[sqStr] & nOppSideTag) != 0) {
                                        if (cnValuableStringPieces[lppos->ucpcSquares[sqStr]] > 1 &&
                                            !lppos->Protected(OPP_SIDE(sd), sqStr, sqDst)) {
                                            vlString[sd] += ccvlStringValueTab[sqDst - sqStr + 256];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return SIDE_VALUE(lppos->sdPlayer, vlString[0] - vlString[1]);
    }
    
    // ?????????????????????
    
    // ????????????????????????????

    int32_t RookMobility(PositionStruct *lppos) {
        int32_t sd, i, sqSrc, nSideTag, x, y;
        int32_t vlRookMobility[2];
        for (sd = 0; sd < 2; sd ++) {
            vlRookMobility[sd] = 0;
            nSideTag = SIDE_TAG(sd);
            for (i = ROOK_FROM; i <= ROOK_TO; i ++) {
                sqSrc = lppos->ucsqPieces[nSideTag + i];
                if (sqSrc != 0) {
                    // __ASSERT_SQUARE(sqSrc);
                    if(!IF_SQUARE(sqSrc)){
                        printf("error, ASSERT_SQUARE(sqSrc)\n");
                        sqSrc = 128;
                    }
                    x = FILE_X(sqSrc);
                    y = RANK_Y(sqSrc);
                    vlRookMobility[sd] += lppos->PreEvalEx.cPopCnt16[lppos->RankMaskPtr(x, y)->wNonCap] +
                    lppos->PreEvalEx.cPopCnt16[lppos->FileMaskPtr(x, y)->wNonCap];
                }
            }
            // TODO __ASSERT(vlRookMobility[sd] <= 34);
            if(vlRookMobility[sd] > 34){
                // printf("error, __ASSERT(vlRookMobility[sd] <= 34)\n");
                vlRookMobility[sd] = 34;
            }
        }
        return SIDE_VALUE(lppos->sdPlayer, vlRookMobility[0] - vlRookMobility[1]) >> 1;
    }



    int32_t KnightTrap(PositionStruct *lppos) {
        int32_t sd, i, sqSrc, sqDst, nSideTag, nMovable;
        uint8_t *lpucsqDst, *lpucsqPin;
        int32_t vlKnightTraps[2];
        
        for (sd = 0; sd < 2; sd ++) {
            vlKnightTraps[sd] = 0;
            nSideTag = SIDE_TAG(sd);
            // ????????????????????????????????????????????????????
            for (i = KNIGHT_FROM; i <= KNIGHT_TO; i ++) {
                sqSrc = lppos->ucsqPieces[nSideTag + i];
                if (sqSrc != 0) {
                    // __ASSERT_SQUARE(sqSrc);
                    if(!IF_SQUARE(sqSrc)){
                        printf("error, ASSERT_SQUARE(sqSrc)\n");
                        sqSrc = 128;
                    }
                    nMovable = 0;
                    lpucsqDst = lppos->myPreGen->PreGen.ucsqKnightMoves[sqSrc];
                    lpucsqPin = lppos->myPreGen->PreGen.ucsqKnightPins[sqSrc];
                    sqDst = *lpucsqDst;
                    while (sqDst != 0) {
                        // __ASSERT_SQUARE(sqDst);
                        if(!IF_SQUARE(sqDst)){
                            printf("error, ASSERT_SQUARE(sqDst)\n");
                            sqDst = 128;
                        }
                        // ??????????????"genmoves.cpp"?????????????????????????????????????????????
                        if (!cbcEdgeSquares[sqDst] && lppos->ucpcSquares[sqDst] == 0 &&
                            lppos->ucpcSquares[*lpucsqPin] == 0 && !lppos->Protected(OPP_SIDE(sd), sqDst)) {
                            nMovable ++;
                            if (nMovable > 1) {
                                break;
                            }
                        }
                        lpucsqDst ++;
                        sqDst = *lpucsqDst;
                        lpucsqPin ++;
                    }
                    // ???????????????10?????????????????????????5?????
                    if (nMovable == 0) {
                        vlKnightTraps[sd] += 10;
                    } else if (nMovable == 1) {
                        vlKnightTraps[sd] += 5;
                    }
                }
                // __ASSERT(vlKnightTraps[sd] <= 20);
                if(!(vlKnightTraps[sd] <= 20)){
                    printf("error, ASSERT(vlKnightTraps[sd] <= 20)\n");
                    vlKnightTraps[sd] = 20;
                }
            }
        }
        return SIDE_VALUE(lppos->sdPlayer, vlKnightTraps[1] - vlKnightTraps[0]);
    }
    
    // ???????????
    int32_t WINAPI EvaluateEVA(PositionStruct *lppos, int32_t vlAlpha, int32_t vlBeta, int32_t pickBestMove) {
        // printf("EvaluateEVA: %d, %d\n", vlAlpha, vlBeta);
        int32_t vl;
        // ????????????????????????????
        
        // 1. ??????????(???????????)??????????????
        vl = lppos->Material();
        if (vl + EVAL_MARGIN1 <= vlAlpha) {
            return vl + EVAL_MARGIN1;
        } else if (vl - EVAL_MARGIN1 >= vlBeta) {
            return vl - EVAL_MARGIN1;
        }
        
        // 2. ?????????????????????????
        vl += AdvisorShape(lppos);
        if (vl + EVAL_MARGIN2 <= vlAlpha) {
            return vl + EVAL_MARGIN2;
        } else if (vl - EVAL_MARGIN2 >= vlBeta) {
            return vl - EVAL_MARGIN2;
        }
        
        // 3. ????????????????????
        vl += StringHold(lppos);
        if (vl + EVAL_MARGIN3 <= vlAlpha) {
            return vl + EVAL_MARGIN3;
        } else if (vl - EVAL_MARGIN3 >= vlBeta) {
            return vl - EVAL_MARGIN3;
        }
        
        // 4. ?????????????????????????
        vl += RookMobility(lppos);
        if (vl + EVAL_MARGIN4 <= vlAlpha) {
            return vl + EVAL_MARGIN4;
        } else if (vl - EVAL_MARGIN4 >= vlBeta) {
            return vl - EVAL_MARGIN4;
        }
        
        // 5. ?????????(???????)?????????????
        vl+= +KnightTrap(lppos);
        // return
        if(pickBestMove>=0 && pickBestMove<100){
            // random value
            int32_t randomPercent = fastRandom(100-pickBestMove);
            int32_t newVl = vl - randomPercent*vl/100;
            // printf("EvaluateEVA: %d, %d, %d, %d, %d\n", vlAlpha, vlBeta, vl, randomPercent, newVl);
            return newVl;
        }else{
            // printf("EvaluateEVA: %d, %d, %d\n", vlAlpha, vlBeta, vl);
            return vl;
        }
    }
    
    const char *WINAPI GetEngineNameEVA(void) {
        return NULL;
    }
    
    ////////////////////////////////////////////////////////////////////////////
    //////////////// My Evaluate Position //////////////////
    ////////////////////////////////////////////////////////////////////////////

    int32_t EvaluatePositionEVA(PositionStruct *lppos, int32_t vlAlpha, int32_t vlBeta, EvaluateResult* result)
    {
        // printf("EvaluateEVA: %d, %d\n", vlAlpha, vlBeta);
        int32_t vl;
        // ????????????????????????????
        
        // 1. ??????????(???????????)??????????????
        {
            int32_t material = lppos->Material();
            result->material = material;
            vl = material;
        }
        /*if (vl + EVAL_MARGIN1 <= vlAlpha) {
            return vl + EVAL_MARGIN1;
        } else if (vl - EVAL_MARGIN1 >= vlBeta) {
            return vl - EVAL_MARGIN1;
        }*/
        
        // 2. ?????????????????????????
        {
            int32_t advisorShape = AdvisorShape(lppos);
            result->advisorShape = advisorShape;
            vl += advisorShape;
        }
        /*if (vl + EVAL_MARGIN2 <= vlAlpha) {
            return vl + EVAL_MARGIN2;
        } else if (vl - EVAL_MARGIN2 >= vlBeta) {
            return vl - EVAL_MARGIN2;
        }*/
        
        // 3. ????????????????????
        {
            int32_t stringHold = StringHold(lppos);
            result->stringHold = stringHold;
            vl += stringHold;
        }
        /*if (vl + EVAL_MARGIN3 <= vlAlpha) {
            return vl + EVAL_MARGIN3;
        } else if (vl - EVAL_MARGIN3 >= vlBeta) {
            return vl - EVAL_MARGIN3;
        }*/
        
        // 4. ?????????????????????????
        {
            int32_t rookMobility = RookMobility(lppos);
            result->rookMobility = rookMobility;
            vl += rookMobility;
        }
        /*if (vl + EVAL_MARGIN4 <= vlAlpha) {
            return vl + EVAL_MARGIN4;
        } else if (vl - EVAL_MARGIN4 >= vlBeta) {
            return vl - EVAL_MARGIN4;
        }*/
        
        // 5. ?????????(???????)?????????????
        {
            int32_t knightTrap = KnightTrap(lppos);
            result->knightTrap = knightTrap;
            vl+= +knightTrap;
        }
        // printf("EvaluateEVA: %d, %d, %d\n", vlAlpha, vlBeta, vl);
        return vl;
    }
}
