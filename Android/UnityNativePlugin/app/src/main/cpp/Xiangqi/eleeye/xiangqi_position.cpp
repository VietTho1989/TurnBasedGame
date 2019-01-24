/*
position.h/position.cpp - Source Code for ElephantEye, Part III

ElephantEye - a Chinese Chess Program (UCCI Engine)
Designed by Morning Yellow, Version: 3.0, Last Modified: Nov. 2007
Copyright (C) 2004-2007 www.elephantbase.net

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
#include <stdio.h>

#include "../../Platform.h"
#include "../xiangqi_jni.hpp"

namespace Xiangqi
{
    /* ElephantEye‘¥≥Ã–Ú π”√µƒ–Ÿ—¿¿˚º«∫≈‘º∂®£∫
     *
     * sq: ∏Ò◊”–Ú∫≈(’˚ ˝£¨¥”0µΩ255£¨≤Œ‘ƒ"pregen.cpp")
     * pc: ∆Â◊”–Ú∫≈(’˚ ˝£¨¥”0µΩ47£¨≤Œ‘ƒ"position.cpp")
     * pt: ∆Â◊”¿‡–Õ–Ú∫≈(’˚ ˝£¨¥”0µΩ6£¨≤Œ‘ƒ"position.cpp")
     * mv: ◊≈∑®(’˚ ˝£¨¥”0µΩ65535£¨≤Œ‘ƒ"position.cpp")
     * sd: ◊ﬂ◊”∑Ω(’˚ ˝£¨0¥˙±Ì∫Ï∑Ω£¨1¥˙±Ì∫⁄∑Ω)
     * vl: æ÷√Êº€÷µ(’˚ ˝£¨¥”"-MATE_VALUE"µΩ"MATE_VALUE"£¨≤Œ‘ƒ"position.cpp")
     * (◊¢£∫“‘…œŒÂ∏ˆº«∫≈ø…”Îuc°¢dwµ»¥˙±Ì’˚ ˝µƒº«∫≈≈‰∫œ π”√)
     * pos: æ÷√Ê(PositionStruct¿‡–Õ£¨≤Œ‘ƒ"position.h")
     * sms: Œª––∫ÕŒª¡–µƒ◊≈∑®…˙≥…‘§÷√Ω·ππ(≤Œ‘ƒ"pregen.h")
     * smv: Œª––∫ÕŒª¡–µƒ◊≈∑®≈–∂œ‘§÷√Ω·ππ(≤Œ‘ƒ"pregen.h")
     */
    
    // ±æƒ£øÈ…Êº∞∂‡∏ˆ"PositionStruct"µƒ≥…‘±£¨”√"this->"±Íº«≥ˆ¿¥“‘∑Ω±„±Ê»œ
    
    // ∆ ºæ÷√ÊµƒFEN¥Æ
    const char *const cszStartFen = "rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR w";
    
    // ∆Â◊”¿‡–Õ∂‘”¶µƒ∆Â◊”∑˚∫≈
    const char *const cszPieceBytes = "KABNRCP";
    
    /* ∆Â◊”–Ú∫≈∂‘”¶µƒ∆Â◊”¿‡–Õ
     *
     * ElephantEyeµƒ∆Â◊”–Ú∫≈¥”0µΩ47£¨∆‰÷–0µΩ15≤ª”√£¨16µΩ31±Ì æ∫Ï◊”£¨32µΩ47±Ì æ∫⁄◊”°£
     * √ø∑Ωµƒ∆Â◊”À≥–Ú“¿¥Œ «£∫Àß À Àœ‡œ‡¬Ì¬Ì≥µ≥µ≈⁄≈⁄±¯±¯±¯±¯±¯(Ω´ ø øœÛœÛ¬Ì¬Ì≥µ≥µ≈⁄≈⁄◊‰◊‰◊‰◊‰◊‰)
     * Ã· æ£∫≈–∂œ∆Â◊” «∫Ï◊””√"pc < 32"£¨∫⁄◊””√"pc >= 32"
     */
    const int32_t cnPieceTypes[48] = {
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 6, 6, 6,
        0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 6, 6, 6
    };
    
    // ∆Â◊”µƒºÚµ•∑÷÷µ£¨÷ª‘⁄ºÚµ•±»Ωœ ±◊˜≤Œøº
    const int32_t cnSimpleValues[48] = {
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        5, 1, 1, 1, 1, 3, 3, 4, 4, 3, 3, 2, 2, 2, 2, 2,
        5, 1, 1, 1, 1, 3, 3, 4, 4, 3, 3, 2, 2, 2, 2, 2,
    };
    
    // ∏√ ˝◊È∫‹∑Ω±„µÿ µœ÷¡À◊¯±ÍµƒæµœÒ(◊Û”“∂‘≥∆)
    const uint8_t cucsqMirrorTab[256] = {
        0, 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0,
        0, 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0,
        0, 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0,
        0, 0, 0, 0x3b, 0x3a, 0x39, 0x38, 0x37, 0x36, 0x35, 0x34, 0x33, 0, 0, 0, 0,
        0, 0, 0, 0x4b, 0x4a, 0x49, 0x48, 0x47, 0x46, 0x45, 0x44, 0x43, 0, 0, 0, 0,
        0, 0, 0, 0x5b, 0x5a, 0x59, 0x58, 0x57, 0x56, 0x55, 0x54, 0x53, 0, 0, 0, 0,
        0, 0, 0, 0x6b, 0x6a, 0x69, 0x68, 0x67, 0x66, 0x65, 0x64, 0x63, 0, 0, 0, 0,
        0, 0, 0, 0x7b, 0x7a, 0x79, 0x78, 0x77, 0x76, 0x75, 0x74, 0x73, 0, 0, 0, 0,
        0, 0, 0, 0x8b, 0x8a, 0x89, 0x88, 0x87, 0x86, 0x85, 0x84, 0x83, 0, 0, 0, 0,
        0, 0, 0, 0x9b, 0x9a, 0x99, 0x98, 0x97, 0x96, 0x95, 0x94, 0x93, 0, 0, 0, 0,
        0, 0, 0, 0xab, 0xaa, 0xa9, 0xa8, 0xa7, 0xa6, 0xa5, 0xa4, 0xa3, 0, 0, 0, 0,
        0, 0, 0, 0xbb, 0xba, 0xb9, 0xb8, 0xb7, 0xb6, 0xb5, 0xb4, 0xb3, 0, 0, 0, 0,
        0, 0, 0, 0xcb, 0xca, 0xc9, 0xc8, 0xc7, 0xc6, 0xc5, 0xc4, 0xc3, 0, 0, 0, 0,
        0, 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0,
        0, 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0,
        0, 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0,
    };
    
    // FEN¥Æ÷–∆Â◊”±Í ∂£¨◊¢“‚’‚∏ˆ∫Ø ˝÷ªƒ‹ ∂±¥Û–¥◊÷ƒ∏£¨“Ú¥À”√–°–¥◊÷ƒ∏ ±£¨ ◊œ»±ÿ–Î◊™ªªŒ™¥Û–¥
    int32_t FenPiece(int32_t nArg) {
        switch (nArg) {
            case 'K':
                return 0;
            case 'A':
                return 1;
            case 'B':
            case 'E':
                return 2;
            case 'N':
            case 'H':
                return 3;
            case 'R':
                return 4;
            case 'C':
                return 5;
            case 'P':
                return 6;
            default:
                return 7;
        }
    }
    
    // “‘œ¬ «“ª–©∆Â≈Ã¥¶¿Ìπ˝≥Ã
    
    // ∆Â≈Ã…œ‘ˆº”∆Â◊”
    void PositionStruct::AddPiece(int32_t sq, int32_t pc, bool bDel) {
        int32_t pt;
        
        // __ASSERT_SQUARE(sq);
        if(!IF_SQUARE(sq)){
            printf("error, ASSERT_SQUARE(sq)\n");
        }
        // __ASSERT_PIECE(pc);
        if(!IF_PIECE(pc)){
            printf("error, ASSERT_PIECE(pc)\n");
        }
        if (bDel) {
            this->ucpcSquares[sq] = 0;
            this->ucsqPieces[pc] = 0;
        } else {
            this->ucpcSquares[sq] = pc;
            this->ucsqPieces[pc] = sq;
        }
        this->wBitRanks[RANK_Y(sq)] ^= myPreGen->PreGen.wBitRankMask[sq];
        this->wBitFiles[FILE_X(sq)] ^= myPreGen->PreGen.wBitFileMask[sq];
        // __ASSERT_BITRANK(this->wBitRanks[RANK_Y(sq)]);
        if(!IF_BITRANK(this->wBitRanks[RANK_Y(sq)])){
            printf("error, ASSERT_BITRANK(this->wBitRanks[RANK_Y(sq)])\n");
        }
        // __ASSERT_BITFILE(this->wBitRanks[FILE_X(sq)]);
        if(!IF_BITFILE(this->wBitRanks[FILE_X(sq)])){
            printf("error, ASSERT_BITFILE(this->wBitRanks[FILE_X(sq)])\n");
        }
        this->dwBitPiece ^= BIT_PIECE(pc);
        pt = PIECE_TYPE(pc);
        if (pc < 32) {
            if (bDel) {
                this->vlWhite -= myPreGen->PreEval.ucvlWhitePieces[pt][sq];
            } else {
                this->vlWhite += myPreGen->PreEval.ucvlWhitePieces[pt][sq];
            }
        } else {
            if (bDel) {
                this->vlBlack -= myPreGen->PreEval.ucvlBlackPieces[pt][sq];
            } else {
                this->vlBlack += myPreGen->PreEval.ucvlBlackPieces[pt][sq];
            }
            pt += 7;
        }
        // __ASSERT_BOUND(0, pt, 13);
        if(!__IF_BOUND(0, pt, 13)){
            printf("error, ASSERT_BOUND(0, pt, 13)\n");
            pt = 0;
        }
        this->zobr.Xor(myPreGen->PreGen.zobrTable[pt][sq]);
    }
    
    // “∆∂Ø∆Â◊”
    int32_t PositionStruct::MovePiece(int32_t mv) {
        int32_t sqSrc, sqDst, pcMoved, pcCaptured, pt;
        uint8_t *lpucvl;
        // “∆∂Ø∆Â◊”∞¸¿®“‘œ¬º∏∏ˆ≤Ω÷Ë£∫
        
        // 1. µ√µΩ“∆∂Øµƒ∆Â◊”–Ú∫≈∫Õ±ª≥‘µƒ∆Â◊”–Ú∫≈£ª
        sqSrc = SRC(mv);
        sqDst = DST(mv);
        pcMoved = this->ucpcSquares[sqSrc];
        // __ASSERT_SQUARE(sqSrc);
        if(!IF_SQUARE(sqSrc)){
            printf("error, ASSERT_SQUARE(sqSrc)\n");
            sqSrc = 128;
        }
        // __ASSERT_SQUARE(sqDst);
        if(!IF_SQUARE(sqDst)){
            printf("error, ASSERT_SQUARE(sqDst)\n");
            sqDst = 128;
        }
        // __ASSERT_PIECE(pcMoved);
        if(!IF_PIECE(pcMoved)){
            printf("error, ASSERT_PIECE(pcMoved)\n");
        }
        pcCaptured = this->ucpcSquares[sqDst];
        if (pcCaptured == 0) {
            
            // 2. »Áπ˚√ª”–±ª≥‘µƒ∆Â◊”£¨ƒ«√¥∏¸–¬ƒø±Í∏ÒµƒŒª––∫ÕŒª¡–°£
            //    ªªæ‰ª∞Àµ£¨”–±ª≥‘µƒ∆Â◊”£¨ƒø±Í∏ÒµƒŒª––∫ÕŒª¡–æÕ≤ª±ÿ∏¸–¬¡À°£
            this->wBitRanks[RANK_Y(sqDst)] ^= myPreGen->PreGen.wBitRankMask[sqDst];
            this->wBitFiles[FILE_X(sqDst)] ^= myPreGen->PreGen.wBitFileMask[sqDst];
            // __ASSERT_BITRANK(this->wBitRanks[RANK_Y(sqDst)]);
            if(!IF_BITRANK(this->wBitRanks[RANK_Y(sqDst)])){
                printf("error, ASSERT_BITRANK(this->wBitRanks[RANK_Y(sqDst)])\n");
            }
            // __ASSERT_BITFILE(this->wBitRanks[FILE_X(sqDst)]);
            if(!IF_BITFILE(this->wBitRanks[FILE_X(sqDst)])){
                printf("error, ASSERT_BITFILE(this->wBitRanks[FILE_X(sqDst)])\n");
            }
        } else {
            
            // __ASSERT_PIECE(pcCaptured);
            if(!IF_PIECE(pcCaptured)){
                printf("error, ASSERT_PIECE(pcCaptured)\n");
            }
            // 3. »Áπ˚”–±ª≥‘µƒ∆Â◊”£¨ƒ«√¥∏¸–¬∆Â◊”Œª£¨¥”"ucsqPieces" ˝◊È÷–«Â≥˝±ª≥‘∆Â◊”
            //    Õ¨ ±∏¸–¬◊”¡¶º€÷µ°¢Œª––Œª¡–°¢Zobristº¸÷µ∫Õ–£—ÈÀ¯
            this->ucsqPieces[pcCaptured] = 0;
            this->dwBitPiece ^= BIT_PIECE(pcCaptured);
            pt = PIECE_TYPE(pcCaptured);
            if (pcCaptured < 32) {
                this->vlWhite -= myPreGen->PreEval.ucvlWhitePieces[pt][sqDst];
            } else {
                this->vlBlack -= myPreGen->PreEval.ucvlBlackPieces[pt][sqDst];
                pt += 7;
            }
            // __ASSERT_BOUND(0, pt, 13);
            if(!__IF_BOUND(0, pt, 13)){
                printf("error, ASSERT_BOUND(0, pt, 13)\n");
                pt = 0;
            }
            this->zobr.Xor(myPreGen->PreGen.zobrTable[pt][sqDst]);
        }
        
        // 4. ¥”"ucpcSquares"∫Õ"ucsqPieces" ˝◊È÷–“∆∂Ø∆Â◊”£¨◊¢“‚°∞∏Ò◊”-∆Â◊”¡™œµ ˝◊È°±“∆∂Ø∆Â◊”µƒ∑Ω∑®
        //    Õ¨ ±∏¸–¬Œª––°¢Œª¡–°¢◊”¡¶º€÷µ°¢Œª––Œª¡–°¢Zobristº¸÷µ∫Õ–£—ÈÀ¯
        this->ucpcSquares[sqSrc] = 0;
        this->ucpcSquares[sqDst] = pcMoved;
        this->ucsqPieces[pcMoved] = sqDst;
        this->wBitRanks[RANK_Y(sqSrc)] ^= myPreGen->PreGen.wBitRankMask[sqSrc];
        this->wBitFiles[FILE_X(sqSrc)] ^= myPreGen->PreGen.wBitFileMask[sqSrc];
        // __ASSERT_BITRANK(this->wBitRanks[RANK_Y(sqSrc)]);
        if(!IF_BITRANK(this->wBitRanks[RANK_Y(sqSrc)])){
            printf("error, ASSERT_BITRANK(this->wBitRanks[RANK_Y(sqSrc)])\n");
        }
        // __ASSERT_BITFILE(this->wBitRanks[FILE_X(sqSrc)]);
        if(!IF_BITFILE(this->wBitRanks[FILE_X(sqSrc)])){
            printf("error, ASSERT_BITFILE(this->wBitRanks[FILE_X(sqSrc)])\n");
        }
        pt = PIECE_TYPE(pcMoved);
        if (pcMoved < 32) {
            lpucvl = myPreGen->PreEval.ucvlWhitePieces[pt];
            this->vlWhite += lpucvl[sqDst] - lpucvl[sqSrc];
        } else {
            lpucvl = myPreGen->PreEval.ucvlBlackPieces[pt];
            this->vlBlack += lpucvl[sqDst] - lpucvl[sqSrc];
            pt += 7;
        }
        // __ASSERT_BOUND(0, pt, 13);
        if(!__IF_BOUND(0, pt, 13)){
            printf("error, ASSERT_BOUND(0, pt, 13)\n");
            pt = 0;
        }
        this->zobr.Xor(myPreGen->PreGen.zobrTable[pt][sqDst], myPreGen->PreGen.zobrTable[pt][sqSrc]);
        return pcCaptured;
    }
    
    // ≥∑œ˚“∆∂Ø∆Â◊”
    void PositionStruct::UndoMovePiece(int32_t mv, int32_t pcCaptured) {
        int32_t sqSrc, sqDst, pcMoved;
        sqSrc = SRC(mv);
        sqDst = DST(mv);
        pcMoved = this->ucpcSquares[sqDst];
        // __ASSERT_SQUARE(sqSrc);
        if(!IF_SQUARE(sqSrc)){
            printf("error, ASSERT_SQUARE(sqSrc)\n");
        }
        // __ASSERT_SQUARE(sqDst);
        if(!IF_SQUARE(sqDst)){
            printf("error, ASSERT_SQUARE(sqDst)\n");
        }
        // __ASSERT_PIECE(pcMoved);
        if(!IF_PIECE(pcMoved)){
            printf("error, ASSERT_PIECE(pcMoved)\n");
        }
        this->ucpcSquares[sqSrc] = pcMoved;
        this->ucsqPieces[pcMoved] = sqSrc;
        this->wBitRanks[RANK_Y(sqSrc)] ^= myPreGen->PreGen.wBitRankMask[sqSrc];
        this->wBitFiles[FILE_X(sqSrc)] ^= myPreGen->PreGen.wBitFileMask[sqSrc];
        // __ASSERT_BITRANK(this->wBitRanks[RANK_Y(sqSrc)]);
        if(!IF_BITRANK(this->wBitRanks[RANK_Y(sqSrc)])){
            printf("error, ASSERT_BITRANK(this->wBitRanks[RANK_Y(sqSrc)])\n");
        }
        // __ASSERT_BITFILE(this->wBitRanks[FILE_X(sqSrc)]);
        if(!IF_BITFILE(this->wBitRanks[FILE_X(sqSrc)])){
            printf("error, ASSERT_BITFILE(this->wBitRanks[FILE_X(sqSrc)])\n");
        }
        if (pcCaptured > 0) {
            // __ASSERT_PIECE(pcCaptured);
            if(!IF_PIECE(pcCaptured)){
                printf("error, ASSERT_PIECE(pcCaptured)\n");
            }
            this->ucpcSquares[sqDst] = pcCaptured;
            this->ucsqPieces[pcCaptured] = sqDst;
            this->dwBitPiece ^= BIT_PIECE(pcCaptured);
        } else {
            this->ucpcSquares[sqDst] = 0;
            this->wBitRanks[RANK_Y(sqDst)] ^= myPreGen->PreGen.wBitRankMask[sqDst];
            this->wBitFiles[FILE_X(sqDst)] ^= myPreGen->PreGen.wBitFileMask[sqDst];
            // __ASSERT_BITRANK(this->wBitRanks[RANK_Y(sqDst)]);
            if(!IF_BITRANK(this->wBitRanks[RANK_Y(sqDst)])){
                printf("error, ASSERT_BITRANK(this->wBitRanks[RANK_Y(sqDst)])\n");
            }
            // __ASSERT_BITFILE(this->wBitRanks[FILE_X(sqDst)]);
            if(!IF_BITFILE(this->wBitRanks[FILE_X(sqDst)])){
                printf("error, ASSERT_BITFILE(this->wBitRanks[FILE_X(sqDst)])\n");
            }
        }
    }
    
    // …˝±‰
    int32_t PositionStruct::Promote(int32_t sq) {
        int32_t pcCaptured, pcPromoted, pt;
        // …˝±‰∞¸¿®“‘œ¬º∏∏ˆ≤Ω÷Ë£∫
        
        // 1. µ√µΩ…˝±‰«∞∆Â◊”µƒ–Ú∫≈£ª
        // __ASSERT_SQUARE(sq);
        if(!IF_SQUARE(sq)){
            printf("error, ASSERT_SQUARE(sq)\n");
        }
        // __ASSERT(CanPromote());
        if(!(CanPromote())){
            printf("error, ASSERT(CanPromote())\n");
        }
        // __ASSERT(CAN_PROMOTE(sq));
        if(!(CAN_PROMOTE(sq))){
            printf("error, ASSERT(CAN_PROMOTE(sq))\n");
        }
        pcCaptured = this->ucpcSquares[sq];
        // __ASSERT_PIECE(pcCaptured);
        if(!IF_PIECE(pcCaptured)){
            printf("error, ASSERT_PIECE(pcCaptured)\n");
        }
        pcPromoted = SIDE_TAG(this->sdPlayer) + Bsf(~this->wBitPiece[this->sdPlayer] & PAWN_BITPIECE);
        // __ASSERT_PIECE(pcPromoted);
        if(!pcPromoted){
            printf("error, ASSERT_PIECE(pcPromoted)\n");
        }
        // __ASSERT(this->ucsqPieces[pcPromoted] == 0);
        if(!(this->ucsqPieces[pcPromoted] == 0)){
            printf("error, ASSERT(this->ucsqPieces[pcPromoted] == 0)\n");
        }
        
        // 2. »•µÙ…˝±‰«∞∆Â◊”£¨Õ¨ ±∏¸–¬◊”¡¶º€÷µ°¢Zobristº¸÷µ∫Õ–£—ÈÀ¯
        this->dwBitPiece ^= BIT_PIECE(pcPromoted) ^ BIT_PIECE(pcCaptured);
        this->ucsqPieces[pcCaptured] = 0;
        pt = PIECE_TYPE(pcCaptured);
        if (pcCaptured < 32) {
            this->vlWhite -= myPreGen->PreEval.ucvlWhitePieces[pt][sq];
        } else {
            this->vlBlack -= myPreGen->PreEval.ucvlBlackPieces[pt][sq];
            pt += 7;
        }
        // __ASSERT_BOUND(0, pt, 13);
        if(!__IF_BOUND(0, pt, 13)){
            printf("error, ASSERT_BOUND(0, pt, 13)\n");
            pt = 0;
        }
        this->zobr.Xor(myPreGen->PreGen.zobrTable[pt][sq]);
        
        // 3. º”…œ…˝±‰∫Û∆Â◊”£¨Õ¨ ±∏¸–¬◊”¡¶º€÷µ°¢Zobristº¸÷µ∫Õ–£—ÈÀ¯
        this->ucpcSquares[sq] = pcPromoted;
        this->ucsqPieces[pcPromoted] = sq;
        pt = PIECE_TYPE(pcPromoted);
        if (pcPromoted < 32) {
            this->vlWhite += myPreGen->PreEval.ucvlWhitePieces[pt][sq];
        } else {
            this->vlBlack += myPreGen->PreEval.ucvlBlackPieces[pt][sq];
            pt += 7;
        }
        // __ASSERT_BOUND(0, pt, 13);
        if(!__IF_BOUND(0, pt, 13)){
            printf("error, ASSERT_BOUND(0, pt, 13)\n");
            pt = 0;
        }
        this->zobr.Xor(myPreGen->PreGen.zobrTable[pt][sq]);
        return pcCaptured;
    }
    
    // ≥∑œ˚…˝±‰
    void PositionStruct::UndoPromote(int32_t sq, int32_t pcCaptured) {
        int32_t pcPromoted;
        // __ASSERT_SQUARE(sq);
        if(!IF_SQUARE(sq)){
            printf("error, ASSERT_SQUARE(sq)\n");
            sq = 128;
        }
        // __ASSERT_PIECE(pcCaptured);
        if(!IF_PIECE(pcCaptured)){
            printf("error, ASSERT_PIECE(pcCaptured)\n");
        }
        pcPromoted = this->ucpcSquares[sq];
        // __ASSERT(PIECE_TYPE(pcPromoted) == 6);
        if(!(PIECE_TYPE(pcPromoted) == 6)){
            printf("error, ASSERT(PIECE_TYPE(pcPromoted) == 6)\n");
        }
        this->ucsqPieces[pcPromoted] = 0;
        this->ucpcSquares[sq] = pcCaptured;
        this->ucsqPieces[pcCaptured] = sq;
        this->dwBitPiece ^= BIT_PIECE(pcPromoted) ^ BIT_PIECE(pcCaptured);
    }
    
    // “‘…œ «“ª–©∆Â≈Ã¥¶¿Ìπ˝≥Ã
    
    // “‘œ¬ «“ª–©◊≈∑®¥¶¿Ìπ˝≥Ã
    
    // ÷¥––“ª∏ˆ◊≈∑®
    bool PositionStruct::MakeMove(int32_t mv) {
        // printf("position: make move: %d\n", mv);
        int32_t sq, pcCaptured;
        uint32_t dwOldZobristKey;
        RollbackStruct *lprbs;
        
        // »Áπ˚¥ÔµΩ◊Ó¥Û◊≈∑® ˝£¨ƒ«√¥≈–∂®Œ™∑«∑®◊≈∑®
        if (this->nMoveNum == MAX_MOVE_NUM) {
            return false;
        }
        // __ASSERT(this->nMoveNum < MAX_MOVE_NUM);
        if(!(this->nMoveNum < MAX_MOVE_NUM)){
            printf("error, ASSERT(this->nMoveNum < MAX_MOVE_NUM)\n");
        }
        // ÷¥––“ª∏ˆ◊≈∑®“™∞¸¿®“‘œ¬º∏∏ˆ≤Ω÷Ë£∫
        
        // 1. ±£¥Ê‘≠¿¥µƒZobristº¸÷µ
        dwOldZobristKey = this->zobr.dwKey;
        SaveStatus();
        
        // 2. “∆∂Ø∆Â◊”£¨º«◊°≥‘µÙµƒ◊”(»Áπ˚”–µƒª∞)
        sq = SRC(mv);
        if (sq == DST(mv)) {
            pcCaptured = Promote(sq);
        } else {
            pcCaptured = MovePiece(mv);
            
            // 3. »Áπ˚“∆∂Ø∫Û±ªΩ´æ¸¡À£¨ƒ«√¥◊≈∑® «∑«∑®µƒ£¨≥∑œ˚∏√◊≈∑®
            if (CheckedBy(CHECK_LAZY) > 0) {
                UndoMovePiece(mv, pcCaptured);
                Rollback();
                return false;
            }
        }
        
        // 4. Ωªªª◊ﬂ◊”∑Ω
        ChangeSide();
        
        // 5. ∞—‘≠¿¥µƒZobristº¸÷µº«¬ºµΩºÏ≤‚÷ÿ∏¥µƒ√‘ƒ„÷√ªª±Ì÷–
        if (this->ucRepHash[dwOldZobristKey & REP_HASH_MASK] == 0) {
            this->ucRepHash[dwOldZobristKey & REP_HASH_MASK] = this->nMoveNum;
        }
        
        // 6. ∞—◊≈∑®±£¥ÊµΩ¿˙ ∑◊≈∑®¡–±Ì÷–£¨≤¢º«◊°≥‘µÙµƒ◊”∫ÕΩ´æ¸◊¥Ã¨
        lprbs = this->rbsList + this->nMoveNum;
        lprbs->mvs.wmv = mv;
        lprbs->mvs.ChkChs = CheckedBy();
        
        // 7. Set the number of moves and moves (generals and dues will not be counted)
        if (pcCaptured == 0) {
            if (lprbs->mvs.ChkChs == 0) {
                lprbs->mvs.ChkChs = -ChasedBy(mv);
            }
            if (LastMove().CptDrw == -100) {
                lprbs->mvs.CptDrw = -100;
            } else {
                lprbs->mvs.CptDrw = MIN((int) LastMove().CptDrw, 0) - (lprbs->mvs.ChkChs > 0 || LastMove().ChkChs > 0 ? 0 : 1);
            }
            // TODO __ASSERT_BOUND(-100, lprbs->mvs.CptDrw, 0);
            if(!__IF_BOUND(-100, lprbs->mvs.CptDrw, 0)){
                // printf("error: __ASSERT_BOUND(-100, lprbs->mvs.CptDrw, 0): %d %d\n", lprbs->mvs.CptDrw, LastMove().CptDrw);
                if(lprbs->mvs.CptDrw<-100){
                    lprbs->mvs.CptDrw = -100;
                }
                if(lprbs->mvs.CptDrw>0){
                    lprbs->mvs.CptDrw = 0;
                }
            }
        } else {
            lprbs->mvs.CptDrw = pcCaptured;
            // __ASSERT_PIECE(pcCaptured);
            if(!IF_PIECE(pcCaptured)){
                printf("error, ASSERT_PIECE(pcCaptured)\n");
            }
        }
        this->nMoveNum ++;
        this->nDistance ++;
        
        return true;
    }
    
    // ≥∑œ˚“ª∏ˆ◊≈∑®
    void PositionStruct::UndoMakeMove(void) {
        int32_t sq;
        RollbackStruct *lprbs;
        this->nMoveNum --;
        this->nDistance --;
        lprbs = this->rbsList + this->nMoveNum;
        sq = SRC(lprbs->mvs.wmv);
        if (sq == DST(lprbs->mvs.wmv)) {
            // __ASSERT_BOUND(ADVISOR_TYPE, PIECE_TYPE(lprbs->mvs.CptDrw), BISHOP_TYPE);
            if(!__IF_BOUND(ADVISOR_TYPE, PIECE_TYPE(lprbs->mvs.CptDrw), BISHOP_TYPE)){
                printf("error, ASSERT_BOUND(ADVISOR_TYPE, PIECE_TYPE(lprbs->mvs.CptDrw), BISHOP_TYPE)\n");
            }
            UndoPromote(sq, lprbs->mvs.CptDrw);
        } else {
            UndoMovePiece(lprbs->mvs.wmv, lprbs->mvs.CptDrw);
        }
        this->sdPlayer = OPP_SIDE(this->sdPlayer);
        Rollback();
        if (this->ucRepHash[this->zobr.dwKey & REP_HASH_MASK] == this->nMoveNum) {
            this->ucRepHash[this->zobr.dwKey & REP_HASH_MASK] = 0;
        }
        // __ASSERT(this->nMoveNum > 0);
        if(!(this->nMoveNum > 0)){
            printf("error, ASSERT(this->nMoveNum > 0)\n");
        }
    }
    
    // ÷¥––“ª∏ˆø’◊≈
    void PositionStruct::NullMove(void) {
        // __ASSERT(this->nMoveNum < MAX_MOVE_NUM);
        if(!(this->nMoveNum < MAX_MOVE_NUM)){
            printf("error, ASSERT(this->nMoveNum < MAX_MOVE_NUM)\n");
        }
        if (this->ucRepHash[this->zobr.dwKey & REP_HASH_MASK] == 0) {
            this->ucRepHash[this->zobr.dwKey & REP_HASH_MASK] = this->nMoveNum;
        }
        SaveStatus();
        ChangeSide();
        this->rbsList[nMoveNum].mvs.dwmv = 0; // wmv, Chk, CptDrw, ChkChs = 0
        this->nMoveNum ++;
        this->nDistance ++;
    }
    
    // ≥∑œ˚“ª∏ˆø’◊≈
    void PositionStruct::UndoNullMove(void) {
        this->nMoveNum --;
        this->nDistance --;
        this->sdPlayer = OPP_SIDE(this->sdPlayer);
        Rollback();
        if (this->ucRepHash[this->zobr.dwKey & REP_HASH_MASK] == this->nMoveNum) {
            this->ucRepHash[this->zobr.dwKey & REP_HASH_MASK] = 0;
        }
        // __ASSERT(this->nMoveNum > 0);
        if(!(this->nMoveNum > 0)){
            printf("error, ASSERT(this->nMoveNum > 0)\n");
        }
    }
    
    // “‘…œ «“ª–©◊≈∑®¥¶¿Ìπ˝≥Ã
    
    // “‘œ¬ «“ª–©æ÷√Ê¥¶¿Ìπ˝≥Ã
    
    // FEN¥Æ ∂±
    void PositionStruct::FromFen(const char *szFen) {
        int32_t i, j, k;
        int32_t pcWhite[7];
        int32_t pcBlack[7];
        const char *lpFen;
        // FEN¥Æµƒ ∂±∞¸¿®“‘œ¬º∏∏ˆ≤Ω÷Ë£∫
        // 1. ≥ı ºªØ£¨«Âø’∆Â≈Ã
        pcWhite[0] = SIDE_TAG(0) + KING_FROM;
        pcWhite[1] = SIDE_TAG(0) + ADVISOR_FROM;
        pcWhite[2] = SIDE_TAG(0) + BISHOP_FROM;
        pcWhite[3] = SIDE_TAG(0) + KNIGHT_FROM;
        pcWhite[4] = SIDE_TAG(0) + ROOK_FROM;
        pcWhite[5] = SIDE_TAG(0) + CANNON_FROM;
        pcWhite[6] = SIDE_TAG(0) + PAWN_FROM;
        for (i = 0; i < 7; i ++) {
            pcBlack[i] = pcWhite[i] + 16;
        }
        /*  ˝◊È"pcWhite[7]"∫Õ"pcBlack[7]"∑÷±¥˙±Ì∫Ï∑Ω∫Õ∫⁄∑Ω√ø∏ˆ±¯÷÷º¥Ω´’º”–µƒ–Ú∫≈£¨
         * “‘"pcWhite[7]"Œ™¿˝£¨”…”⁄∆Â◊”16µΩ31“¿¥Œ¥˙±Ì°∞Àß À Àœ‡œ‡¬Ì¬Ì≥µ≥µ≈⁄≈⁄±¯±¯±¯±¯±¯°±£¨
         * À˘“‘◊Ó≥ı”¶∏√ «"pcWhite[7] = {16, 17, 19, 21, 23, 25, 27}"£¨√øÃÌº”“ª∏ˆ∆Â◊”£¨∏√œÓæÕ‘ˆº”1£¨
         * ’‚÷÷◊ˆ∑®‘ –ÌÃÌº”∂‡”‡µƒ∆Â◊”(¿˝»ÁÃÌº”µ⁄∂˛∏ˆÀß£¨æÕ±‰≥… À¡À)£¨µ´ÃÌº”«∞“™◊ˆ±ﬂΩÁºÏ≤‚
         */
        ClearBoard();
        lpFen = szFen;
        if (*lpFen == '\0') {
            SetIrrev();
            return;
        }
        // 2. ∂¡»°∆Â≈Ã…œµƒ∆Â◊”
        i = RANK_TOP;
        j = FILE_LEFT;
        while (*lpFen != ' ') {
            if (*lpFen == '/') {
                j = FILE_LEFT;
                i ++;
                if (i > RANK_BOTTOM) {
                    break;
                }
            } else if (*lpFen >= '1' && *lpFen <= '9') {
                for (k = 0; k < (*lpFen - '0'); k ++) {
                    if (j >= FILE_RIGHT) {
                        break;
                    }
                    j ++;
                }
            } else if (*lpFen >= 'A' && *lpFen <= 'Z') {
                if (j <= FILE_RIGHT) {
                    k = FenPiece(*lpFen);
                    if (k < 7) {
                        if (pcWhite[k] < 32) {
                            if (this->ucsqPieces[pcWhite[k]] == 0) {
                                AddPiece(COORD_XY(j, i), pcWhite[k]);
                                pcWhite[k] ++;
                            }
                        }
                    }
                    j ++;
                }
            } else if (*lpFen >= 'a' && *lpFen <= 'z') {
                if (j <= FILE_RIGHT) {
                    k = FenPiece(*lpFen + 'A' - 'a');
                    if (k < 7) {
                        if (pcBlack[k] < 48) {
                            if (this->ucsqPieces[pcBlack[k]] == 0) {
                                AddPiece(COORD_XY(j, i), pcBlack[k]);
                                pcBlack[k] ++;
                            }
                        }
                    }
                    j ++;
                }
            }
            lpFen ++;
            if (*lpFen == '\0') {
                SetIrrev();
                return;
            }
        }
        lpFen ++;
        // 3. »∑∂®¬÷µΩƒƒ∑Ω◊ﬂ
        if (*lpFen == 'b') {
            ChangeSide();
        }
        // 4. ∞—æ÷√Ê…Ë≥…°∞≤ªø…ƒÊ°±
        SetIrrev();
    }
    
    // …˙≥…FEN¥Æ
    void PositionStruct::ToFen(char *szFen) const {
        int32_t i, j, k, pc;
        char *lpFen;
        
        lpFen = szFen;
        for (i = RANK_TOP; i <= RANK_BOTTOM; i ++) {
            k = 0;
            for (j = FILE_LEFT; j <= FILE_RIGHT; j ++) {
                pc = this->ucpcSquares[COORD_XY(j, i)];
                if (pc != 0) {
                    if (k > 0) {
                        *lpFen = k + '0';
                        lpFen ++;
                        k = 0;
                    }
                    *lpFen = PIECE_BYTE(PIECE_TYPE(pc)) + (pc < 32 ? 0 : 'a' - 'A');
                    lpFen ++;
                } else {
                    k ++;
                }
            }
            if (k > 0) {
                *lpFen = k + '0';
                lpFen ++;
            }
            *lpFen = '/';
            lpFen ++;
        }
        *(lpFen - 1) = ' '; // ∞—◊Ó∫Û“ª∏ˆ'/'ÃÊªª≥…' '
        *lpFen = (this->sdPlayer == 0 ? 'w' : 'b');
        lpFen ++;
        *lpFen = '\0';
    }
    
    const char* PositionStruct::MyToFen()
    {
        char fen[1024];
        {
            int32_t i, j, k, pc;

            for (i = RANK_TOP; i <= RANK_BOTTOM; i ++) {
                k = 0;
                for (j = FILE_LEFT; j <= FILE_RIGHT; j ++) {
                    pc = this->ucpcSquares[COORD_XY(j, i)];
                    if (pc != 0) {
                        if (k > 0) {
                            sprintf(fen, "%s%c", fen, k + '0');
                            k = 0;
                        }
                        sprintf(fen, "%s%c", fen, PIECE_BYTE(PIECE_TYPE(pc)) + (pc < 32 ? 0 : 'a' - 'A'));
                    } else {
                        k ++;
                    }
                }
                if (k > 0) {
                    sprintf(fen, "%s%c", fen, k + '0');
                }
                if(i!=RANK_BOTTOM)
                    sprintf(fen, "%s/", fen);
            }
            sprintf(fen, "%s ", fen);
            sprintf(fen, "%s%c", fen, (this->sdPlayer == 0 ? 'w' : 'b'));
        }
        // return
        {
            char* ret = new char[strlen(fen)+1];
            strcpy(ret, fen);
            return ret;
        }
    }
    
    // æ÷√ÊæµœÒ
    void PositionStruct::Mirror(void) {
        int32_t i, sq, nMoveNumSave;
        uint16_t wmvList[MAX_MOVE_NUM];
        uint8_t ucsqList[32];
        // æ÷√ÊæµœÒ–Ë“™∞¥“‘œ¬≤Ω÷Ë“¿¥ŒΩ¯––£∫
        
        // 1. º«¬ºÀ˘”–¿˙ ∑◊≈∑®
        nMoveNumSave = this->nMoveNum;
        for (i = 1; i < nMoveNumSave; i ++) {
            wmvList[i] = this->rbsList[i].mvs.wmv;
        }
        
        // 2. ≥∑œ˚À˘”–◊≈∑®
        for (i = 1; i < nMoveNumSave; i ++) {
            UndoMakeMove();
        }
        
        // 3. ∞—À˘”–∆Â◊”¥”∆Â≈Ã…œƒ√◊ﬂ£¨Œª÷√º«¬ºµΩ"ucsqList" ˝◊È£ª
        for (i = 16; i < 48; i ++) {
            sq = this->ucsqPieces[i];
            ucsqList[i - 16] = sq;
            if (sq != 0) {
                AddPiece(sq, i, DEL_PIECE);
            }
        }
        
        // 4. ∞—ƒ√◊ﬂµƒ∆Â◊”∞¥’’æµœÒŒª÷√÷ÿ–¬∑≈µΩ∆Â≈Ã…œ£ª
        for (i = 16; i < 48; i ++) {
            sq = ucsqList[i - 16];
            if (sq != 0) {
                AddPiece(SQUARE_MIRROR(sq), i);
            }
        }
        
        // 6. ªπ‘≠æµœÒ◊≈∑®
        SetIrrev();
        for (i = 1; i < nMoveNumSave; i ++) {
            MakeMove(MOVE_MIRROR(wmvList[i]));
        }
    }
    
    // “‘…œ «“ª–©æ÷√Ê¥¶¿Ìπ˝≥Ã
    
    // “‘œ¬ «“ª–©◊≈∑®ºÏ≤‚π˝≥Ã
    
    // ◊≈∑®∫œ¿Ì–‘ºÏ≤‚£¨Ωˆ”√‘⁄°∞…± ÷◊≈∑®°±µƒºÏ≤‚÷–
    bool PositionStruct::LegalMove(int32_t mv)
    {
        int32_t sqSrc, sqDst, sqPin, pcMoved, pcCaptured, x, y, nSideTag;
        // ◊≈∑®∫œ¿Ì–‘ºÏ≤‚∞¸¿®“‘œ¬º∏∏ˆ≤Ω÷Ë£∫
        
        // 1. ºÏ≤È“™◊ﬂµƒ◊” «∑Ò¥Ê‘⁄
        nSideTag = SIDE_TAG(this->sdPlayer);
        sqSrc = SRC(mv);
        sqDst = DST(mv);
        pcMoved = this->ucpcSquares[sqSrc];
        if ((pcMoved & nSideTag) == 0) {
            return false;
        }
        // __ASSERT_SQUARE(sqSrc);
        if(!IF_SQUARE(sqSrc)){
            printf("error, ASSERT_SQUARE(sqSrc)\n");
        }
        // __ASSERT_SQUARE(sqDst);
        if(!IF_SQUARE(sqDst)){
            printf("error, ASSERT_SQUARE(sqDst)\n");
        }
        // __ASSERT_PIECE(pcMoved);
        if(!IF_PIECE(pcMoved)){
            printf("error, ASSERT_PIECE(pcMoved)\n");
        }
        
        // 2. ºÏ≤È≥‘µΩµƒ◊” «∑ÒŒ™∂‘∑Ω∆Â◊”(»Áπ˚”–≥‘◊”≤¢«“√ª”–…˝±‰µƒª∞)
        pcCaptured = this->ucpcSquares[sqDst];
        if (sqSrc != sqDst && (pcCaptured & nSideTag) != 0) {
            return false;
        }
        // __ASSERT_BOUND(0, PIECE_INDEX(pcMoved), 15);
        if(!__IF_BOUND(0, PIECE_INDEX(pcMoved), 15)){
            printf("error, ASSERT_BOUND(0, PIECE_INDEX(pcMoved), 15)\n");
        }
        switch (PIECE_INDEX(pcMoved)) {
                
                // 3. »Áπ˚ «Àß(Ω´)ªÚ À( ø)£¨‘Úœ»ø¥ «∑Ò‘⁄æ≈π¨ƒ⁄£¨‘Ÿø¥ «∑Ò «∫œ¿ÌŒª“∆
            case KING_FROM:
                return IN_FORT(sqDst) && KING_SPAN(sqSrc, sqDst);
            case ADVISOR_FROM:
            case ADVISOR_TO:
                if (sqSrc == sqDst) {
                    // øº¬«…˝±‰£¨‘⁄µ◊œﬂ≤¢«“±¯(◊‰)≤ª»´ ±£¨≤≈ø……˝±‰
                    return CAN_PROMOTE(sqSrc) && CanPromote();
                } else {
                    return IN_FORT(sqDst) && ADVISOR_SPAN(sqSrc, sqDst);
                }
                
                // 4. »Áπ˚ «œ‡(œÛ)£¨‘Úœ»ø¥ «∑Òπ˝∫”£¨‘Ÿø¥ «∑Ò «∫œ¿ÌŒª“∆£¨◊Ó∫Ûø¥”–√ª”–±ª»˚œÛ—€
            case BISHOP_FROM:
            case BISHOP_TO:
                if (sqSrc == sqDst) {
                    // øº¬«…˝±‰£¨‘⁄µ◊œﬂ≤¢«“±¯(◊‰)≤ª»´ ±£¨≤≈ø……˝±‰
                    return CAN_PROMOTE(sqSrc) && CanPromote();
                } else {
                    return SAME_HALF(sqSrc, sqDst) && BISHOP_SPAN(sqSrc, sqDst) && this->ucpcSquares[BISHOP_PIN(sqSrc, sqDst)] == 0;
                }
                
                // 5. »Áπ˚ «¬Ì£¨‘Úœ»ø¥ø¥ «∑Ò «∫œ¿ÌŒª“∆£¨‘Ÿø¥”–√ª”–±ªıø¬ÌÕ»
            case KNIGHT_FROM:
            case KNIGHT_TO:
                sqPin = KNIGHT_PIN(sqSrc, sqDst);
                return sqPin != sqSrc && this->ucpcSquares[sqPin] == 0;
                
                // 6. »Áπ˚ «≥µ£¨‘Úœ»ø¥ «∫·œÚ“∆∂Øªπ «◊›œÚ“∆∂Ø£¨‘Ÿ∂¡»°Œª––ªÚŒª¡–µƒ◊≈∑®‘§…˙≥… ˝◊È
            case ROOK_FROM:
            case ROOK_TO:
                x = FILE_X(sqSrc);
                y = RANK_Y(sqSrc);
                if (x == FILE_X(sqDst)) {
                    if (pcCaptured == 0) {
                        return (FileMaskPtr(x, y)->wNonCap & myPreGen->PreGen.wBitFileMask[sqDst]) != 0;
                    } else {
                        return (FileMaskPtr(x, y)->wRookCap & myPreGen->PreGen.wBitFileMask[sqDst]) != 0;
                    }
                } else if (y == RANK_Y(sqDst)) {
                    if (pcCaptured == 0) {
                        return (RankMaskPtr(x, y)->wNonCap & myPreGen->PreGen.wBitRankMask[sqDst]) != 0;
                    } else {
                        return (RankMaskPtr(x, y)->wRookCap & myPreGen->PreGen.wBitRankMask[sqDst]) != 0;
                    }
                } else {
                    return false;
                }
                
                // 7. »Áπ˚ «≈⁄£¨≈–∂œ∆¿¥∫Õ≥µ“ª—˘
            case CANNON_FROM:
            case CANNON_TO:
                x = FILE_X(sqSrc);
                y = RANK_Y(sqSrc);
                if (x == FILE_X(sqDst)) {
                    if (pcCaptured == 0) {
                        return (FileMaskPtr(x, y)->wNonCap & myPreGen->PreGen.wBitFileMask[sqDst]) != 0;
                    } else {
                        return (FileMaskPtr(x, y)->wCannonCap & myPreGen->PreGen.wBitFileMask[sqDst]) != 0;
                    }
                } else if (y == RANK_Y(sqDst)) {
                    if (pcCaptured == 0) {
                        return (RankMaskPtr(x, y)->wNonCap & myPreGen->PreGen.wBitRankMask[sqDst]) != 0;
                    } else {
                        return (RankMaskPtr(x, y)->wCannonCap & myPreGen->PreGen.wBitRankMask[sqDst]) != 0;
                    }
                } else {
                    return false;
                }
                
                // 8. »Áπ˚ «±¯(◊‰)£¨‘Ú∞¥∫Ï∑Ω∫Õ∫⁄∑Ω∑÷«ÈøˆÃ÷¬€
            default:
                if (AWAY_HALF(sqDst, this->sdPlayer) && (sqDst == sqSrc - 1 || sqDst == sqSrc + 1)) {
                    return true;
                } else {
                    return sqDst == SQUARE_FORWARD(sqSrc, this->sdPlayer);
                }
        }
    }
    
    // Ω´æ¸ºÏ≤‚
    int32_t PositionStruct::CheckedBy(bool bLazy)
    {
        int32_t pcCheckedBy, i, sqSrc, sqDst, sqPin, pc, x, y, nOppSideTag;
        SlideMaskStruct *lpsmsRank, *lpsmsFile;
        
        pcCheckedBy = 0;
        nOppSideTag = OPP_SIDE_TAG(this->sdPlayer);
        // Ω´æ¸≈–∂œ∞¸¿®“‘œ¬º∏≤ø∑÷ƒ⁄»›£∫
        
        // 1. ≈–∂œÀß(Ω´) «∑Ò‘⁄∆Â≈Ã…œ
        sqSrc = this->ucsqPieces[SIDE_TAG(this->sdPlayer)];
        if (sqSrc == 0) {
            return 0;
        }
        // __ASSERT_SQUARE(sqSrc);
        if(!IF_SQUARE(sqSrc)){
            printf("error, ASSERT_SQUARE(sqSrc)\n");
            sqSrc = 128;
        }
        
        // 2. ªÒµ√Àß(Ω´)À˘‘⁄∏Ò◊”µƒŒª––∫ÕŒª¡–
        x = FILE_X(sqSrc);
        y = RANK_Y(sqSrc);
        lpsmsRank = RankMaskPtr(x, y);
        lpsmsFile = FileMaskPtr(x, y);
        
        // 3. ≈–∂œ «∑ÒΩ´Àß∂‘¡≥
        sqDst = this->ucsqPieces[nOppSideTag + KING_FROM];
        if (sqDst != 0) {
            // __ASSERT_SQUARE(sqDst);
            if(!IF_SQUARE(sqDst)){
                printf("error, ASSERT_SQUARE(sqDst)\n");
                sqDst = 128;
            }
            if (x == FILE_X(sqDst) && (lpsmsFile->wRookCap & myPreGen->PreGen.wBitFileMask[sqDst]) != 0) {
                return CHECK_MULTI;
            }
        }
        
        // 4. ≈–∂œ «∑Ò±ª¬ÌΩ´æ¸
        for (i = KNIGHT_FROM; i <= KNIGHT_TO; i ++) {
            sqDst = this->ucsqPieces[nOppSideTag + i];
            if (sqDst != 0) {
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                sqPin = KNIGHT_PIN(sqDst, sqSrc); // ◊¢“‚£¨sqSrc∫ÕsqDst «∑¥µƒ£°
                if (sqPin != sqDst && this->ucpcSquares[sqPin] == 0) {
                    if (bLazy || pcCheckedBy > 0) {
                        return CHECK_MULTI;
                    }
                    pcCheckedBy = nOppSideTag + i;
                    // __ASSERT_PIECE(pcCheckedBy);
                    if(!IF_PIECE(pcCheckedBy)){
                        printf("error, ASSERT_PIECE(pcCheckedBy)\n");
                    }
                }
            }
        }
        
        // 5. ≈–∂œ «∑Ò±ª≥µΩ´æ¸ªÚΩ´Àß∂‘¡≥
        for (i = ROOK_FROM; i <= ROOK_TO; i ++) {
            sqDst = this->ucsqPieces[nOppSideTag + i];
            if (sqDst != 0) {
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                if (x == FILE_X(sqDst)) {
                    if ((lpsmsFile->wRookCap & myPreGen->PreGen.wBitFileMask[sqDst]) != 0) {
                        if (bLazy || pcCheckedBy > 0) {
                            return CHECK_MULTI;
                        }
                        pcCheckedBy = nOppSideTag + i;
                        // __ASSERT_PIECE(pcCheckedBy);
                        if(!IF_PIECE(pcCheckedBy)){
                            printf("error, ASSERT_PIECE(pcCheckedBy)\n");
                        }
                    }
                } else if (y == RANK_Y(sqDst)) {
                    if ((lpsmsRank->wRookCap & myPreGen->PreGen.wBitRankMask[sqDst]) != 0) {
                        if (bLazy || pcCheckedBy > 0) {
                            return CHECK_MULTI;
                        }
                        pcCheckedBy = nOppSideTag + i;
                        // __ASSERT_PIECE(pcCheckedBy);
                        if(!IF_PIECE(pcCheckedBy)){
                            printf("error, ASSERT_PIECE(pcCheckedBy)\n");
                        }
                    }
                }
            }
        }
        
        // 6. ≈–∂œ «∑Ò±ª≈⁄Ω´æ¸
        for (i = CANNON_FROM; i <= CANNON_TO; i ++) {
            sqDst = this->ucsqPieces[nOppSideTag + i];
            if (sqDst != 0) {
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                if (x == FILE_X(sqDst)) {
                    if ((lpsmsFile->wCannonCap & myPreGen->PreGen.wBitFileMask[sqDst]) != 0) {
                        if (bLazy || pcCheckedBy > 0) {
                            return CHECK_MULTI;
                        }
                        pcCheckedBy = nOppSideTag + i;
                        // __ASSERT_PIECE(pcCheckedBy);
                        if(!IF_PIECE(pcCheckedBy)){
                            printf("error, ASSERT_PIECE(pcCheckedBy)\n");
                        }
                    }
                } else if (y == RANK_Y(sqDst)) {
                    if ((lpsmsRank->wCannonCap & myPreGen->PreGen.wBitRankMask[sqDst]) != 0) {
                        if (bLazy || pcCheckedBy > 0) {
                            return CHECK_MULTI;
                        }
                        pcCheckedBy = nOppSideTag + i;
                        // __ASSERT_PIECE(pcCheckedBy);
                        if(!IF_PIECE(pcCheckedBy)){
                            printf("error, ASSERT_PIECE(pcCheckedBy)\n");
                        }
                    }
                }
            }
        }
        
        // 7. ≈–∂œ «∑Ò±ª±¯(◊‰)Ω´æ¸
        for (sqDst = sqSrc - 1; sqDst <= sqSrc + 1; sqDst += 2) {
            // »Áπ˚Àß(Ω´)‘⁄±ﬂœﬂ(ElephantEye‘ –Ì)£¨ƒ«√¥∂œ—‘≤ª≥…¡¢
            // __ASSERT_SQUARE(sqDst);
            pc = this->ucpcSquares[sqDst];
            if ((pc & nOppSideTag) != 0 && PIECE_INDEX(pc) >= PAWN_FROM) {
                if (bLazy || pcCheckedBy > 0) {
                    return CHECK_MULTI;
                }
                pcCheckedBy = nOppSideTag + i;
                // __ASSERT_PIECE(pcCheckedBy);
                if(!IF_PIECE(pcCheckedBy)){
                    printf("error, ASSERT_PIECE(pcCheckedBy)\n");
                }
            }
        }
        pc = this->ucpcSquares[SQUARE_FORWARD(sqSrc, this->sdPlayer)];
        if ((pc & nOppSideTag) != 0 && PIECE_INDEX(pc) >= PAWN_FROM) {
            if (bLazy || pcCheckedBy > 0) {
                return CHECK_MULTI;
            }
            pcCheckedBy = nOppSideTag + i;
            // __ASSERT_PIECE(pcCheckedBy);
            if(!IF_PIECE(pcCheckedBy)){
                printf("error, ASSERT_PIECE(pcCheckedBy)\n");
            }
        }
        return pcCheckedBy;
    }
    
    // ≈–∂œ «∑Ò±ªΩ´À¿
    bool PositionStruct::IsMate(void) {
        int32_t i, nGenNum;
        MoveStruct mvsGen[MAX_GEN_MOVES];
        nGenNum = GenCapMoves(mvsGen);
        // printf("isMate: GenCapMoves: nGenNum: %d\n", nGenNum);
        for (i = 0; i < nGenNum; i ++) {
            if (MakeMove(mvsGen[i].wmv)) {
                // printf("isMate: GenCapMoves: move: %u %s\n", mvsGen[i].dwmv, moveToString(mvsGen[i].dwmv));
                UndoMakeMove();
                return false;
            }
        }
        // ◊≈∑®…˙≥…∑÷¡Ω≤ø∑÷◊ˆ£¨’‚—˘ø…“‘Ω⁄‘º ±º‰
        nGenNum = GenNonCapMoves(mvsGen);
        // printf("isMate: GenNonCapMoves: nGenNum: %d\n", nGenNum);
        for (i = 0; i < nGenNum; i ++) {
            if (MakeMove(mvsGen[i].wmv)) {
                // printf("isMate: GenNonCapMoves: move: %u %s\n", mvsGen[i].dwmv, moveToString(mvsGen[i].dwmv));
                UndoMakeMove();
                return false;
            }
        }
        return true;
    }
    
    // …Ë÷√Ω´æ¸◊¥Ã¨Œª
    inline void SetPerpCheck(uint32_t &dwPerpCheck, int32_t nChkChs) {
        if (nChkChs == 0) {
            dwPerpCheck = 0;
        } else if (nChkChs > 0) {
            dwPerpCheck &= 0x10000;
        } else {
            dwPerpCheck &= (1 << -nChkChs);
        }
    }
    
    // ÷ÿ∏¥æ÷√ÊºÏ≤‚
    int32_t PositionStruct::RepStatus(int32_t nRecur)
    {
        // ≤Œ ˝"nRecur"÷∏÷ÿ∏¥¥Œ ˝£¨‘⁄À—À˜÷–»°1“‘Ã·∏ﬂÀ—À˜–ß¬ (ƒ¨»œ÷µ)£¨∏˘Ω·µ„¥¶»°3“‘  ”¶πÊ‘Ú
        int32_t sd;
        uint32_t dwPerpCheck, dwOppPerpCheck;
        const RollbackStruct *lprbs;
        /* ÷ÿ∏¥æ÷√ÊºÏ≤‚∞¸¿®“‘œ¬º∏∏ˆ≤Ω÷Ë£∫
         *
         * 1.  ◊œ»≈–∂œºÏ≤‚÷ÿ∏¥µƒ√‘ƒ„÷√ªª±Ì÷– «∑Òø…ƒ‹”–µ±«∞æ÷√Ê£¨»Áπ˚√ª”–ø…ƒ‹£¨æÕ”√≤ª◊≈≈–∂œ¡À
         *    ÷√ªª±Ì"ucRepHash" «ElephantEyeµƒ“ª∏ˆÃÿ…´£¨æ÷√Ê√ø÷¥––“ª∏ˆ◊≈∑® ±£¨æÕª·‘⁄÷√ªª±ÌœÓ÷–º«¬ºœ¬µ±«∞µƒ"nMoveNum"
         *    »Áπ˚÷√ªª±ÌœÓ“—æ≠ÃÓ”–∆‰À˚æ÷√Ê£¨æÕ≤ª±ÿ∏≤∏«¡À£¨≤Œ‘ƒ"MakeMove()"∫Ø ˝
         *    “Ú¥À≥∑œ˚◊≈∑® ±£¨÷ª“™≤È’“÷√ªª±ÌœÓµƒ÷µ «∑Òµ»”⁄µ±«∞µƒ"nMoveNum"£¨»Áπ˚œ‡µ»‘Ú«Âø’∏√œÓ
         *    »Áπ˚≤ªµ»”⁄µ±«∞µƒ"nMoveNum"£¨‘ÚÀµ√˜÷Æ«∞ªπ”–æ÷√Ê’º”–’‚∏ˆ÷√ªª±ÌœÓ£¨≤ª±ÿ«Âø’∏√œÓ£¨≤Œ‘ƒ"position.h"÷–µƒ"UndoMakeMove()"∫Ø ˝
         */
        if (this->ucRepHash[this->zobr.dwKey & REP_HASH_MASK] == 0) {
            return REP_NONE;
        }
        
        // 2. ≥ı ºªØ
        sd = OPP_SIDE(this->sdPlayer);
        dwPerpCheck = dwOppPerpCheck = 0x1ffff;
        lprbs = this->rbsList + this->nMoveNum - 1;
        
        // 3. ºÏ≤È…œ“ª∏ˆ◊≈∑®£¨»Áπ˚ «ø’◊≈ªÚ≥‘◊”◊≈∑®£¨æÕ≤ªø…ƒ‹”–÷ÿ∏¥¡À
        while (lprbs->mvs.wmv != 0 && lprbs->mvs.CptDrw <= 0) {
            // __ASSERT(lprbs >= this->rbsList);
            if(!(lprbs >= this->rbsList)){
                printf("error, ASSERT(lprbs >= this->rbsList)\n");
            }
            
            // 4. ≈–∂œÀ´∑Ωµƒ≥§¥Úº∂±£¨0±Ì æŒﬁ≥§¥Ú£¨0xffff±Ì æ≥§◊Ω£¨0x10000±Ì æ≥§Ω´
            if (sd == this->sdPlayer) {
                SetPerpCheck(dwPerpCheck, lprbs->mvs.ChkChs);
                
                // 5. —∞’“÷ÿ∏¥æ÷√Ê£¨»Áπ˚÷ÿ∏¥¥Œ ˝¥ÔµΩ‘§∂®¥Œ ˝£¨‘Ú∑µªÿ÷ÿ∏¥º«∫≈
                if (lprbs->zobr.dwLock0 == this->zobr.dwLock0 && lprbs->zobr.dwLock1 == this->zobr.dwLock1) {
                    nRecur --;
                    if (nRecur == 0) {
                        dwPerpCheck = ((dwPerpCheck & 0xffff) == 0 ? dwPerpCheck : 0xffff);
                        dwOppPerpCheck = ((dwOppPerpCheck & 0xffff) == 0 ? dwOppPerpCheck : 0xffff);
                        int32_t rep = dwPerpCheck > dwOppPerpCheck ? REP_LOSS : dwPerpCheck < dwOppPerpCheck ? REP_WIN : REP_DRAW;
                        switch (rep) {
                            case REP_NONE:
                                // printf("position: repStatus: REP_NONE\n");
                                break;
                            case REP_DRAW:
                                // printf("position: repStatus: REP_DRAW\n");
                                break;
                            case REP_LOSS:
                            {
                                // printf("position: repStatus: REP_LOSS\n");
                                // print();
                            }
                                break;
                            case REP_WIN:
                            {
                                // printf("position: repStatus: REP_WIN\n");
                                // print();
                            }
                                break;
                            default:
                                printf("error: position: unknown repStatus: %d\n", rep);
                                break;
                        }
                        return rep;
                    }
                }
                
            } else {
                SetPerpCheck(dwOppPerpCheck, lprbs->mvs.ChkChs);
            }
            
            sd = OPP_SIDE(sd);
            lprbs --;
        }
        return REP_NONE;
    }
    
    // “‘…œ «“ª–©◊≈∑®ºÏ≤‚π˝≥Ã
    
    //////////////////////////////////////////////////////////////////////////////
    /////////////// My method /////////////////
    /////////////////////////////////////////////////////////////////////////////
    
    bool PositionStruct::isOK()
    {
        // nMoveNum
        if(nMoveNum<0 || nMoveNum > MAX_MOVE_NUM){
            printf("error, nMoveNum error: %d\n", nMoveNum);
            return false;
        }
        // board correct?
        {
            
        }
        // TODO can hoan thien
        return true;
    }
    
    void PositionStruct::print()
    {
        char strPosition[5000];
        strPosition[0] = 0;
        {
            sprintf(strPosition, "%sturn: %d, distance: %d\n", strPosition, nMoveNum, nDistance);
            // lastMove
            int32_t lastMoveSrc = -1;
            int32_t lastMoveDst = -1;
            {
                if(nMoveNum>=1){
                    MoveStruct lastMove = LastMove();
                    sprintf(strPosition, "%slastMove: %d %d; %u\n", strPosition, lastMove.Src, lastMove.Dst, lastMove.dwmv);
                    lastMoveSrc = lastMove.Src;
                    lastMoveDst = lastMove.Dst;
                    // CptDrw
                    sprintf(strPosition, "%sCptDrw: %d\n", strPosition, lastMove.CptDrw);
                }else{
                    // printf("don't have last move\n");
                }
            }
            // write board
            {
                int32_t i, j, pc;
                // write rank:
                sprintf(strPosition, "%s `  a  b  c  d  e  f  g  h  i\n", strPosition);
                for (i = RANK_TOP; i <= RANK_BOTTOM; i ++) {
                    sprintf(strPosition, "%s %d ", strPosition, (RANK_BOTTOM - i));
                    for (j = FILE_LEFT; j <= FILE_RIGHT; j ++) {
                        // find coord and pc
                        int32_t coordXY = COORD_XY(j, i);
                        pc = this->ucpcSquares[coordXY];
                        // print
                        if (pc != 0) {
                            char piece = PIECE_BYTE(PIECE_TYPE(pc)) + (pc < 32 ? 0 : 'a' - 'A');
                            if(lastMoveDst!=coordXY){
                                sprintf(strPosition, "%s %c ", strPosition, piece);
                            }else{
                                sprintf(strPosition, "%s[%c]", strPosition, piece);
                            }
                        } else {
                            if(lastMoveSrc!=coordXY){
                                sprintf(strPosition, "%s * ", strPosition);
                            }else{
                                sprintf(strPosition, "%s - ", strPosition);
                            }
                        }
                    }
                    sprintf(strPosition, "%s\n", strPosition);
                }
            }
        }
        // print
        printf("%s\n", strPosition);
    }

    int32_t PositionStruct::getByteSize()
    {
        int32_t ret = 0;
        {
            // int32_t sdPlayer;
            ret+=sizeof(int32_t);
            // uint8_t ucpcSquares[256];
            ret+=256*sizeof(uint8_t);
            // uint8_t ucsqPieces[48];
            ret+=48*sizeof(uint8_t);
            // ZobristStruct zobr;
            ret+=ZobristStruct::getByteSize();
            
            // uint32_t dwBitPiece;
            ret+=sizeof(uint32_t);
            // uint16_t wBitRanks[16];
            ret+=16*sizeof(uint16_t);
            // uint16_t wBitFiles[16];
            ret+=16*sizeof(uint16_t);
            
            // int32_t vlWhite, vlBlack;
            ret+=2*sizeof(int32_t);
            
            // int32_t nMoveNum, nDistance;
            ret+=2*sizeof(int32_t);
            // RollbackStruct rbsList[MAX_MOVE_NUM];
            ret+=nMoveNum*RollbackStruct::getByteSize();
            //uint8_t ucRepHash[REP_HASH_MASK + 1];
             ret+=(REP_HASH_MASK + 1)*sizeof(uint8_t);
        }
        return ret;
    }
    
    bool convertLog = false;

    int32_t PositionStruct::convertToByteArray(PositionStruct* position, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = position->getByteSize();
        byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // int32_t sdPlayer;
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    int32_t value = position->sdPlayer;
                    memcpy(byteArray + pointerIndex, &value, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: sdPlayer: %d, %d\n", pointerIndex, length);
                }
            }
            // uint8_t ucpcSquares[256];
            {
                int32_t size = sizeof(uint8_t);
                for(int32_t i=0; i<256; i++){
                    if(pointerIndex+size<=length){
                        uint8_t value = position->ucpcSquares[i];
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: ucpcSquares: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // uint8_t ucsqPieces[48];
            {
                int32_t size = sizeof(uint8_t);
                for(int32_t i=0; i<48; i++){
                    if(pointerIndex+size<=length){
                        uint8_t value = position->ucsqPieces[i];
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: ucsqPieces: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // ZobristStruct zobr;
            {
                uint8_t* zobrByteArray;
                int32_t size = ZobristStruct::convertToByteArray(&position->zobr, zobrByteArray);
                // write
                if(pointerIndex+size<=length){
                    memcpy(byteArray + pointerIndex, zobrByteArray, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: zobr: %d, %d\n", pointerIndex, length);
                }
                free(zobrByteArray);
            }
            // uint32_t dwBitPiece;
            {
                int32_t size = sizeof(uint32_t);
                if(pointerIndex+size<=length){
                    uint32_t value = position->dwBitPiece;
                    memcpy(byteArray + pointerIndex, &value, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: dwBitPiece: %d, %d\n", pointerIndex, length);
                }
            }
            // uint16_t wBitRanks[16];
            {
                int32_t size = sizeof(uint16_t);
                for(int32_t i=0; i<16; i++){
                    if(pointerIndex+size<=length){
                        uint16_t value = position->wBitRanks[i];
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: wBitRanks: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // uint16_t wBitFiles[16];
            {
                int32_t size = sizeof(uint16_t);
                for(int32_t i=0; i<16; i++){
                    if(pointerIndex+size<=length){
                        uint16_t value = position->wBitFiles[i];
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: wBitFiles: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // int32_t vlWhite;
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    int32_t value = position->vlWhite;
                    memcpy(byteArray + pointerIndex, &value, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: vlWhite: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t vlBlack;
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    int32_t value = position->vlBlack;
                    memcpy(byteArray + pointerIndex, &value, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: vlBlack: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t nMoveNum;
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    int32_t value = position->nMoveNum;
                    memcpy(byteArray + pointerIndex, &value, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: nMoveNum: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t nDistance;
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    int32_t value = position->nDistance;
                    memcpy(byteArray + pointerIndex, &value, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: nDistance: %d, %d\n", pointerIndex, length);
                }
            }
            // RollbackStruct rbsList[MAX_MOVE_NUM];
            {
                for(int32_t i=0; i<position->nMoveNum; i++){
                    RollbackStruct rollBackStruct = position->rbsList[i];
                    // write
                    {
                        uint8_t* rbsByteArray;
                        int32_t size = RollbackStruct::convertToByteArray(&rollBackStruct, rbsByteArray);
                        // write
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, rbsByteArray, size);
                            pointerIndex+=size;
                        }else{
                            if(convertLog)
                                printf("length error: zobr: %d, %d\n", pointerIndex, length);
                        }
                        free(rbsByteArray);
                    }
                }
            }
            //uint8_t ucRepHash[REP_HASH_MASK + 1];
            {
                int32_t size = sizeof(uint8_t);
                for(int32_t i=0; i<REP_HASH_MASK + 1; i++){
                    if(pointerIndex+size<=length){
                        uint8_t value = position->ucRepHash[i];
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: ucRepHash: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            if(pointerIndex!=length){
                printf("error: convert not correct: %d; %d\n", pointerIndex, length);
            }else{
                // printf("convert byte array correct\n");
            }
        }
        return length;
    }

    int32_t PositionStruct::parseByteArray(PositionStruct* position, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect)
    {
        if(convertLog)
            printf("convertByteArrayToPosition: %d\n", length);
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // int32_t sdPlayer;
                {
                    if(convertLog)
                        printf("position: parseByteArray: sdPlayer: %d\n", pointerIndex);
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->sdPlayer, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        if(convertLog)
                            printf("length error: sdPlayer: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                    // uint8_t ucpcSquares[256];
                {
                    if(convertLog)
                        printf("position: parseByteArray: ucpcSquares: %d\n", pointerIndex);
                    int32_t size = sizeof(uint8_t);
                    for(int32_t i=0; i<256; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->ucpcSquares[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            if(convertLog)
                                printf("length error: ucpcSquares: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                }
                    break;
                case 2:
                    // uint8_t ucsqPieces[48];
                {
                    if(convertLog)
                        printf("position: parseByteArray: ucsqPieces: %d\n", pointerIndex);
                    int32_t size = sizeof(uint8_t);
                    for(int32_t i=0; i<48; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->ucsqPieces[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            if(convertLog)
                                printf("length error: ucsqPieces: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                }
                    break;
                case 3:
                    // ZobristStruct zobr;
                {
                    if(convertLog)
                        printf("position: parseByteArray: zobr: %d\n", pointerIndex);
                    int32_t zobrByteLength = ZobristStruct::parseByteArray(&position->zobr, positionBytes, length, pointerIndex);
                    if (zobrByteLength > 0) {
                        pointerIndex+= zobrByteLength;
                    } else {
                        if(convertLog)
                            printf("cannot parse\n");
                        isParseCorrect = false;
                    }
                }
                    break;
                case 4:
                    // uint32_t dwBitPiece;
                {
                    if(convertLog)
                        printf("position: parseByteArray: dwBitPiece: %d\n", pointerIndex);
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->dwBitPiece, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        if(convertLog)
                            printf("length error: sdPlayer: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 5:
                    // uint16_t wBitRanks[16];
                {
                    if(convertLog)
                        printf("position: parseByteArray: wBitRanks: %d\n", pointerIndex);
                    int32_t size = sizeof(uint16_t);
                    for(int32_t i=0; i<16; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->wBitRanks[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            if(convertLog)
                                printf("length error: wBitRanks: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                }
                    break;
                case 6:
                    // uint16_t wBitFiles[16];
                {
                    if(convertLog)
                        printf("position: parseByteArray: wBitFiles: %d\n", pointerIndex);
                    int32_t size = sizeof(uint16_t);
                    for(int32_t i=0; i<16; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->wBitFiles[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            if(convertLog)
                                printf("length error: wBitFiles: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                }
                    break;
                case 7:
                    // int32_t vlWhite;
                {
                    if(convertLog)
                        printf("position: parseByteArray: vlWhite: %d\n", pointerIndex);
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->vlWhite, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        if(convertLog)
                            printf("length error: vlWhite: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 8:
                    // int32_t vlBlack;
                {
                    if(convertLog)
                        printf("position: parseByteArray: vlBlack: %d\n", pointerIndex);
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->vlBlack, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        if(convertLog)
                            printf("length error: vlBlack: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 9:
                    // int32_t nMoveNum;
                {
                    if(convertLog)
                        printf("position: parseByteArray: nMoveNum: %d\n", pointerIndex);
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->nMoveNum, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        if(convertLog)
                            printf("length error: nMoveNum: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 10:
                    // int32_t nDistance;
                {
                    if(convertLog)
                        printf("position: parseByteArray: nDistance: %d\n", pointerIndex);
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->nDistance, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        if(convertLog)
                            printf("length error: nDistance: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 11:
                    // RollbackStruct rbsList[MAX_MOVE_NUM];
                {
                    if(convertLog)
                        printf("position: parseByteArray: rbsList: %d, %d\n", pointerIndex, index);
                    for(int32_t i=0; i<position->nMoveNum; i++){
                        int32_t rbsByteLength = RollbackStruct::parseByteArray(&position->rbsList[i], positionBytes, length, pointerIndex);
                        if (rbsByteLength > 0) {
                            pointerIndex+= rbsByteLength;
                        } else {
                            if(convertLog)
                                printf("cannot parse\n");
                            isParseCorrect = false;
                            break;
                        }
                    }
                }
                    break;
                case 12:
                    // uint8_t ucRepHash[REP_HASH_MASK + 1];
                {
                    int32_t size = sizeof(uint8_t);
                    for(int32_t i=0; i<REP_HASH_MASK + 1; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->ucRepHash[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: ucRepHash: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                }
                    break;
                    
                default:
                {
                    if(convertLog)
                        printf("error, convertByteArrayToPosition: unknown index: %d\n", index);
                    alreadyPassAll = true;
                }
                    break;
            }
            // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
            index++;
            if (!isParseCorrect) {
                if(convertLog)
                    printf("not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // TODO cai nay co can ko nhi?
        position->nDistance = 0;
        // check position ok: if not, correct it
        {
            if(canCorrect){
                if(!position->isOK()){
                    printf("error, position not ok\n");
                    // find fen
                    char strFen[1000];
                    position->ToFen(strFen);
                    printf("parse position: fen: %s\n", strFen);
                    // convert again
                    {
                        if(position->myPreGen==nullptr){
                            printf("myPregen null\n");
                            position->myPreGen = new MyPreGen;
                        }
                        position->myPreGen->PreGenInit();
                    }
                    position->FromFen(strFen);
                }else{
                    // printf("position ok\n");
                }
            }
        }
        // return
        if (!isParseCorrect) {
            printf("error parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            if(convertLog)
                printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }

    int32_t PositionStruct::myGenMoves(uint32_t* lpmv) {
        MoveStruct mvs[MAX_GEN_MOVES];
        int32_t nTotal = GenAllMoves(mvs);
        int32_t nLegal = 0;
        for (int32_t i = 0; i < nTotal; i++) {
            if (this->MakeMove(mvs[i].wmv)) {
                this->UndoMakeMove();
                lpmv[nLegal] = MOVE_COORD(mvs[i].wmv);
                nLegal++;
            }
        }
        return nLegal;
    }
    
    void PositionStruct::MyDelHash()
    {
        //  Õ∑≈÷√ªª±Ì
        delete[] hshItems;
#ifdef HASH_QUIESC
        delete[] hshItemsQ;
#endif
    }
    
    void PositionStruct::MyNewHash(int32_t nHashScale)
    {
        nHashMask = ((1 << nHashScale) / sizeof(HashStruct)) - 1;
        hshItems = new HashStruct[nHashMask + 1];
#ifdef HASH_QUIESC
        hshItemsQ = new HashStruct[nHashMask + 1];
#endif
        MyClearHash();
    }
    
    inline void PositionStruct::MyClearHash(){
        memset(hshItems, 0, (nHashMask + 1) * sizeof(HashStruct));
#ifdef HASH_QUIESC
        memset(hshItemsQ, 0, (nHashMask + 1) * sizeof(HashStruct));
#endif
    }
    
    void makePositionWrong(PositionStruct* pos)
    {
        pos->nMoveNum = -100;
    }
}

/*

 `  a  b  c  d  e  f  g  h  i
 9  r  n  *  a  k  a  b  n  r
 8  *  *  *  *  *  *  *  *  *
 7  *  *  *  *  b  *  *  c  *
 6  p  *  p  *  p  *  p  *  p
 5  *  c  *  *  *  *  *  *  *
 4  *  *  P  *  *  *  *  *  *
 3  P  *  *  *  P  *  P  *  P
 2  *  C  N  *  B  *  *  C  *
 1  *  *  *  *  *  *  *  *  *
 0 [R] -  B  A  K  A  *  N  R

*/
