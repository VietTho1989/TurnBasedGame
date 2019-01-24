//
//  var.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <cstdlib>
#include <fstream>
#include <iostream>
#include <map>
#include <string>

#include "international_draught_var.hpp"

namespace InternationalDraught
{
    namespace var {
        
        std::string variant(Variant_Type variantType, const std::string & normal, const std::string & killer, const std::string & bt) {
            
            switch (variantType) {
                case Normal :
                    return normal;
                case Killer :
                    return killer;
                case BT     :
                    return bt;
                default     :
                    return normal;
            }
        }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////// Convert Var ////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////

        int32_t Var::getByteSize()
        {
            int32_t ret = 0;
            {
                // Variant_Type Variant;
                ret+=sizeof(Variant_Type);
                // bool Book;
                ret+=sizeof(bool);
                // int32_t  Book_Ply;
                ret+=sizeof(int32_t);
                // int32_t  Book_Margin;
                ret+=sizeof(int32_t);
                // bool Ponder;
                ret+=sizeof(bool);
                // bool SMP;
                ret+=sizeof(bool);
                // int32_t  SMP_Threads;
                ret+=sizeof(int32_t);
                // int32_t  TT_Size;
                ret+=sizeof(int32_t);
                // bool BB;
                ret+=sizeof(bool);
                // int32_t  BB_Size;
                ret+=sizeof(int32_t);
                // int32_t pickBestMove;
                ret+=sizeof(int32_t);
            }
            return ret;
        }

        int32_t Var::convertToByteArray(struct Var* var, uint8_t* &byteArray)
        {
            // find length of return
            int32_t length = var->getByteSize();
            byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
            {
                int32_t pointerIndex = 0;
                // convert property
                {
                    // Variant_Type Variant;
                    {
                        int32_t size = sizeof(Variant_Type);
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, &var->Variant, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: Variant: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // bool Book;
                    {
                        int32_t size = sizeof(bool);
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, &var->Book, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: Book: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // int32_t  Book_Ply;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, &var->Book_Ply, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: Book_Ply: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // int32_t  Book_Margin;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, &var->Book_Margin, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: Book_Margin: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // bool Ponder;
                    {
                        int32_t size = sizeof(bool);
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, &var->Ponder, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: Ponder: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // bool SMP;
                    {
                        int32_t size = sizeof(bool);
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, &var->SMP, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: SMP: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // int32_t  SMP_Threads;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, &var->SMP_Threads, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: SMP_Threads: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // int32_t  TT_Size;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, &var->TT_Size, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: TT_Size: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // bool BB;
                    {
                        int32_t size = sizeof(bool);
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, &var->BB, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: BB: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // int32_t  BB_Size;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, &var->BB_Size, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: BB_Size: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // int32_t pickBestMove;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, &var->pickBestMove, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: pickBestMove: %d, %d\n", pointerIndex, length);
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

        int32_t Var::parseByteArray(struct Var* var, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect)
        {
            int32_t pointerIndex = start;
            int32_t index = 0;
            bool isParseCorrect = true;
            while (pointerIndex < length) {
                bool alreadyPassAll = false;
                switch (index) {
                    case 0:
                        // Variant_Type Variant;
                    {
                        int32_t size = sizeof(Variant_Type);
                        if(pointerIndex+size<=length){
                            memcpy(&var->Variant, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: Variant: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 1:
                        // bool Book;
                    {
                        int32_t size = sizeof(bool);
                        if(pointerIndex+size<=length){
                            memcpy(&var->Book, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: Book: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 2:
                        // int32_t  Book_Ply;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&var->Book_Ply, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: Book_Ply: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 3:
                        // int32_t  Book_Margin;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&var->Book_Margin, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: Book_Margin: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 4:
                        // bool Ponder;
                    {
                        int32_t size = sizeof(bool);
                        if(pointerIndex+size<=length){
                            memcpy(&var->Ponder, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: Ponder: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 5:
                        // bool SMP;
                    {
                        int32_t size = sizeof(bool);
                        if(pointerIndex+size<=length){
                            memcpy(&var->SMP, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: SMP: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 6:
                        // int32_t  SMP_Threads;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&var->SMP_Threads, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: SMP_Threads: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 7:
                        // int32_t  TT_Size;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&var->TT_Size, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: TT_Size: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 8:
                        // bool BB;
                    {
                        int32_t size = sizeof(bool);
                        if(pointerIndex+size<=length){
                            memcpy(&var->BB, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: BB: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 9:
                        // int32_t  BB_Size;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&var->BB_Size, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: BB_Size: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 10:
                        // int32_t pickBestMove;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&var->pickBestMove, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: pickBestMove: %d, %d\n", pointerIndex, length);
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
                    {
                        // BB_Size
                        if(var->BB_Size<1){
                            printf("error, var->BB_Size too small: %d\n", var->BB_Size);
                            var->BB_Size = 1;
                        }else if(var->BB_Size>5){
                            printf("error, var->BB_Size too large: %d\n", var->BB_Size);
                            var->BB_Size = 5;
                        }
                        // TT_Size
                        {
                            if(!ml::is_power_2(var->TT_Size)){
                                printf("error, TT_Size wrong\n");
                                var->TT_Size = 1 << 20;
                            }else{
                                if(var->TT_Size < (1<<5)){
                                    printf("error, TT_Size too small\n");
                                    var->TT_Size = 1<<5;
                                }else if(var->TT_Size > (1<<30)){
                                    printf("error, TT_Size too large\n");
                                    var->TT_Size = 1<<30;
                                }
                            }
                        }
                        // SMP
                        {
                            var->SMP = true;
                            var->SMP_Threads = 1;
                        }
                        // Ponder
                        var->Ponder = false;
                    }
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
}
