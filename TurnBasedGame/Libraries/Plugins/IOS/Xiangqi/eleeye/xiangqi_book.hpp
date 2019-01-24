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

#ifndef XIANGQI_BOOK_H
#define XIANGQI_BOOK_H

#include <stdio.h>
#include "../base/xiangqi_base.hpp"
#include "xiangqi_position.hpp"

#include "../../Platform.h"
#ifdef Android
#include <android/log.h>
#endif

namespace Xiangqi
{
    
    struct BookStruct {
        union {
            uint32_t dwZobristLock;
            int32_t nPtr;
        };
        uint16_t wmv, wvl;
    }; // bk
    
    inline int32_t BOOK_POS_CMP(const BookStruct &bk, const PositionStruct &pos) {
        return bk.dwZobristLock < pos.zobr.dwLock1 ? -1 : bk.dwZobristLock > pos.zobr.dwLock1 ? 1 : 0;
    }
    
    struct BookFileStruct {
        FILE *fp;
        int32_t nLen;
        
        bool Open(const char *szFileName, bool bEdit = false) {
            fp = fopen(szFileName, bEdit ? "r+b" : "rb");
            if (fp == NULL) {
                return false;
            } else {
                fseek(fp, 0, SEEK_END);
                nLen = (int)(ftell(fp) / sizeof(BookStruct));
                return true;
            }
        }
        
        void Close(void) const {
            fclose(fp);
        }
        
        void Read(BookStruct &bk, int32_t nPtr) const {
            fseek(fp, nPtr * sizeof(BookStruct), SEEK_SET);
            fread(&bk, sizeof(BookStruct), 1, fp);
        }
        
    };

#ifdef Android

    struct AndroidBookFileStruct {
        AAsset* fp;
        int32_t nLen;

        bool Open(const char *szFileName) {
            fp = AAssetManager_open(assetManager, szFileName, AASSET_MODE_BUFFER);
            if(fp==NULL){
                // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "asset manager open null: %s\n", szFileName);
                return false;
            } else {
                size_t assetLength = AAsset_getLength(fp);
                nLen = (int)(assetLength / sizeof(BookStruct));
                // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "asset manager open correct: nlen: %d\n", nLen);
                return true;
            }
        }

        void Close(void) const {
            // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, Android MyGetBookMoves: close\n");
            AAsset_close(fp);
        }

        void Read(BookStruct &bk, int32_t nPtr) const {
            // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Android MyGetBookMoves: read: %d\n", nPtr);
            AAsset_seek(fp, nPtr * sizeof(BookStruct), SEEK_SET);
            AAsset_read(fp, &bk, sizeof(BookStruct));
        }

    };

#endif

    int32_t MyGetBookMoves(PositionStruct* myPos, const char *szBookFile, BookStruct *lpbks);
}

#endif
