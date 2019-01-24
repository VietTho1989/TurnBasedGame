/*
book.h/book.cpp - Source Code for ElephantEye, Part VI

ElephantEye - a Chinese Chess Program (UCCI Engine)
Designed by Morning Yellow, Version: 3.25, Last Modified: Apr. 2011
Copyright (C) 2004-2011 www.xqbase.com

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

#include "xiangqi_position.hpp"
#include "xiangqi_book.hpp"
// #include "xiangqi_jni.hpp"

namespace Xiangqi
{
    
    inline void freeData(PositionStruct* posScan)
    {
        if(posScan->myPreGen!=nullptr){
            delete posScan->myPreGen;
            posScan->myPreGen = nullptr;
        }else{
            // printf("error, myPregen null\n");
        }
        // delete posScan;
    }

    int32_t MyGetBookMoves(PositionStruct* myPos, const char *szBookFile, BookStruct *lpbks) {
        bool isAndroidAssetBookFile = false;
        // Android
#ifdef Android
        {
            AndroidBookFileStruct BookFile;
            BookStruct bk;
            int32_t nScan, nLow, nHigh, nPtr = 0;
            int32_t i, j, nMoves;
            // �ӿ��ֿ��������ŷ������̣������¼������裺

            // 1. �򿪿��ֿ⣬�����ʧ�ܣ��򷵻ؿ�ֵ��
            if (!BookFile.Open(szBookFile)) {
                __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, Android MyGetBookMoves: book file not exist\n");
            } else {
                isAndroidAssetBookFile = true;
                // 2. �ò����ҷ��������棻
                // set posScan
                PositionStruct posScan;
                {
                    // TODO posScan->myPreGen.PreGenInit();
                    {
                        if(posScan.myPreGen==nullptr){
                            posScan.myPreGen = new MyPreGen;
                        }else{
                            printf("error, posScan.myPreGen not null\n");
                        }
                        // memcpy(posScan.myPreGen, &firstPregen, sizeof(MyPreGen));
                        posScan.myPreGen->PreGenInit();
                    }
                    // set from fen
                    {
                        char fen[1024];
                        memset(fen, 0, 1024);
                        myPos->ToFen(fen);
                        posScan.FromFen(fen);
                    }
                    posScan.nDistance = 0;
                }
                for (nScan = 0; nScan < 2; nScan ++) {
                    nPtr = nLow = 0;
                    nHigh = BookFile.nLen - 1;
                    while (nLow <= nHigh) {
                        nPtr = (nLow + nHigh) / 2;
                        BookFile.Read(bk, nPtr);
                        if (BOOK_POS_CMP(bk, posScan) < 0) {
                            nLow = nPtr + 1;
                        } else if (BOOK_POS_CMP(bk, posScan) > 0) {
                            nHigh = nPtr - 1;
                        } else {
                            break;
                        }
                    }
                    if (nLow <= nHigh) {
                        break;
                    }
                    // ԭ����;�����������һ��
                    posScan.Mirror();
                }

                // 3. ����������棬�򷵻ؿ��ţ�
                if (nScan == 2) {
                    BookFile.Close();
                    freeData(&posScan);
                    // printf("book: getBookMoves: nScan==2\n");
                    return 0;
                }
                // __ASSERT_BOUND(0, nPtr, BookFile.nLen - 1);
                if(!__IF_BOUND(0, nPtr, BookFile.nLen - 1)){
                    printf("error, __ASSERT_BOUND(0, nPtr, BookFile.nLen - 1)\n");
                    nPtr = 0;
                }

                // 4. ����ҵ����棬����ǰ���ҵ�һ���ŷ���
                for (nPtr --; nPtr >= 0; nPtr --) {
                    BookFile.Read(bk, nPtr);
                    if (BOOK_POS_CMP(bk, posScan) < 0) {
                        break;
                    }
                }

                // 5. ������ζ������ڸþ����ÿ���ŷ���
                nMoves = 0;
                for (nPtr ++; nPtr < BookFile.nLen; nPtr ++) {
                    BookFile.Read(bk, nPtr);
                    if (BOOK_POS_CMP(bk, posScan) > 0) {
                        break;
                    }
                    if (posScan.LegalMove(bk.wmv)) {
                        // ��������ǵڶ����������ģ����ŷ�����������
                        lpbks[nMoves].nPtr = nPtr;
                        lpbks[nMoves].wmv = (nScan == 0 ? bk.wmv : MOVE_MIRROR(bk.wmv));
                        lpbks[nMoves].wvl = bk.wvl;
                        nMoves ++;
                        if (nMoves == MAX_GEN_MOVES) {
                            break;
                        }
                    }
                }
                BookFile.Close();

                // 6. ���ŷ�����ֵ����
                for (i = 0; i < nMoves - 1; i ++) {
                    for (j = nMoves - 1; j > i; j --) {
                        if (lpbks[j - 1].wvl < lpbks[j].wvl) {
                            SWAP(lpbks[j - 1], lpbks[j]);
                        }
                    }
                }

                // free data
                freeData(&posScan);

                // return
                return nMoves;
            }
        }
#else

#endif
        if(!isAndroidAssetBookFile){
            BookFileStruct BookFile;
            BookStruct bk;
            int32_t nScan, nLow, nHigh, nPtr = 0;
            int32_t i, j, nMoves;
            // �ӿ��ֿ��������ŷ������̣������¼������裺

            // 1. �򿪿��ֿ⣬�����ʧ�ܣ��򷵻ؿ�ֵ��
            if (!BookFile.Open(szBookFile)) {
                printf("error, MyGetBookMoves: book file not exist\n");
                return 0;
            }

            // 2. �ò����ҷ��������棻
            // set posScan
            PositionStruct posScan;
            {
                // TODO posScan->myPreGen.PreGenInit();
                {
                    if(posScan.myPreGen==nullptr){
                        posScan.myPreGen = new MyPreGen;
                    }else{
                        printf("error, posScan.myPreGen not null\n");
                    }
                    // memcpy(posScan.myPreGen, &firstPregen, sizeof(MyPreGen));
                    posScan.myPreGen->PreGenInit();
                }
                // set from fen
                {
                    char fen[1024];
                    memset(fen, 0, 1024);
                    myPos->ToFen(fen);
                    posScan.FromFen(fen);
                }
                posScan.nDistance = 0;
            }
            for (nScan = 0; nScan < 2; nScan ++) {
                nPtr = nLow = 0;
                nHigh = BookFile.nLen - 1;
                while (nLow <= nHigh) {
                    nPtr = (nLow + nHigh) / 2;
                    BookFile.Read(bk, nPtr);
                    if (BOOK_POS_CMP(bk, posScan) < 0) {
                        nLow = nPtr + 1;
                    } else if (BOOK_POS_CMP(bk, posScan) > 0) {
                        nHigh = nPtr - 1;
                    } else {
                        break;
                    }
                }
                if (nLow <= nHigh) {
                    break;
                }
                // ԭ����;�����������һ��
                posScan.Mirror();
            }

            // 3. ����������棬�򷵻ؿ��ţ�
            if (nScan == 2) {
                BookFile.Close();
                freeData(&posScan);
                // printf("book: getBookMoves: nScan==2\n");
                return 0;
            }
            // __ASSERT_BOUND(0, nPtr, BookFile.nLen - 1);
            if(!__IF_BOUND(0, nPtr, BookFile.nLen - 1)){
                printf("error, __ASSERT_BOUND(0, nPtr, BookFile.nLen - 1)\n");
                nPtr = 0;
            }

            // 4. ����ҵ����棬����ǰ���ҵ�һ���ŷ���
            for (nPtr --; nPtr >= 0; nPtr --) {
                BookFile.Read(bk, nPtr);
                if (BOOK_POS_CMP(bk, posScan) < 0) {
                    break;
                }
            }

            // 5. ������ζ������ڸþ����ÿ���ŷ���
            nMoves = 0;
            for (nPtr ++; nPtr < BookFile.nLen; nPtr ++) {
                BookFile.Read(bk, nPtr);
                if (BOOK_POS_CMP(bk, posScan) > 0) {
                    break;
                }
                if (posScan.LegalMove(bk.wmv)) {
                    // ��������ǵڶ����������ģ����ŷ�����������
                    lpbks[nMoves].nPtr = nPtr;
                    lpbks[nMoves].wmv = (nScan == 0 ? bk.wmv : MOVE_MIRROR(bk.wmv));
                    lpbks[nMoves].wvl = bk.wvl;
                    nMoves ++;
                    if (nMoves == MAX_GEN_MOVES) {
                        break;
                    }
                }
            }
            BookFile.Close();

            // 6. ���ŷ�����ֵ����
            for (i = 0; i < nMoves - 1; i ++) {
                for (j = nMoves - 1; j > i; j --) {
                    if (lpbks[j - 1].wvl < lpbks[j].wvl) {
                        SWAP(lpbks[j - 1], lpbks[j]);
                    }
                }
            }

            // free data
            freeData(&posScan);

            // return
            return nMoves;
        } else {
            return 0;
        }
    }
}
