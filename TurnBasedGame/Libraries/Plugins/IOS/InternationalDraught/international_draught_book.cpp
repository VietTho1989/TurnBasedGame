//
//  book.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <cstdlib>
#include <fstream>
#include <iostream>
#include <vector>

#include "international_draught_book.hpp"
#include "international_draught_hash.hpp"
#include "international_draught_move.hpp"
#include "international_draught_move_gen.hpp"
#include "international_draught_pos.hpp"
#include "international_draught_score.hpp"
#include "international_draught_pos.hpp"

namespace InternationalDraught
{
    namespace book {
        
        // functions
        
        /*void init(struct var::Var* myVar, const char* bookPath) {
         std::cout << "init book" << std::endl;
         G_Book.load(myVar->Variant, bookPath);
         }*/
        
        bool Book::Load(Variant_Type variantType, const std::string& file_name) {
            bool ret;
            {
                clear();
                ret = this->load(variantType, file_name);
                if(ret){
#ifdef Android
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Book Load success: %s\n", file_name.c_str());
#endif
                    backup(variantType);
                }
            }
            return ret;
        }
        
        void Book::clear() {
            
            p_table.resize((unsigned long) Hash_Size);
            
            Entry entry { Key_None, 0, false, false };
            
            for (int32_t i = 0; i < int(p_table.size()); i++) {
                p_table[i] = entry;
            }
        }
        
        void Book::clear_done() {
            for (int32_t i = 0; i < int(p_table.size()); i++) {
                p_table[i].done = false;
            }
        }
        
        void Book::backup(Variant_Type variantType) {
            this->clear_done();
            switch (variantType) {
                case Normal:
                    (void) ::InternationalDraught::backup(this, Normal, pos::StartNormal);
                    break;
                case Killer:
                    (void) ::InternationalDraught::backup(this, Killer, pos::StartKiller);
                    break;
                case BT:
                    (void) ::InternationalDraught::backup(this, BT, pos::StartBT);
                    break;
                default:
                    printf("error, unknown variantType: %d\n", variantType);
                    (void) ::InternationalDraught::backup(this, Normal, pos::StartNormal);
                    break;
            }
            
        }
        
        bool Book::load(Variant_Type variantType, const std::string & file_name)
        {
            bool isAndroidAsset = false;
#ifdef Android
            // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Book Load: %s\n", file_name.c_str());
            {
                assetistream file(assetManager, file_name.c_str());
                if(file.isOpen()){
                    isAndroidAsset = true;
                    this->clear_done();
                    bool ret;
                    {
                        switch (variantType) {
                            case Normal:
                                ret = ::InternationalDraught::load(this, Normal, file, pos::StartNormal);
                                break;
                            case Killer:
                                ret = ::InternationalDraught::load(this, Killer, file, pos::StartKiller);
                                break;
                            case BT:
                                ret = ::InternationalDraught::load(this, BT, file, pos::StartBT);
                                break;
                            default:
                                printf("error, don't know variantType\n");
                                ret = ::InternationalDraught::load(this, Normal, file, pos::StartNormal);
                                break;
                        }
                    }
                    return ret;
                } else {
                    // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "cannot open file: %s\n", file_name.c_str());
                }
            }
#endif
            if(!isAndroidAsset){
                printf("Book Load\n");
                std::ifstream file(file_name.c_str());
                if (!file) {
                    std::cerr << "unable to open file \"" << file_name << "\"" << std::endl;
                    // std::exit(EXIT_FAILURE);
                    return false;
                }
                this->clear_done();
                bool ret;
                {
                    switch (variantType) {
                        case Normal:
                            ret = ::InternationalDraught::load(this, Normal, file, pos::StartNormal);
                            break;
                        case Killer:
                            ret = ::InternationalDraught::load(this, Killer, file, pos::StartKiller);
                            break;
                        case BT:
                            ret = ::InternationalDraught::load(this, BT, file, pos::StartBT);
                            break;
                        default:
                            printf("error, don't know variantType\n");
                            ret = ::InternationalDraught::load(this, Normal, file, pos::StartNormal);
                            break;
                    }
                }
                return ret;
            } else {
                return false;
            }
        }
        
    }
}
