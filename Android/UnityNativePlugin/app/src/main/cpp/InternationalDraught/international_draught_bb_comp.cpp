//
//  bb_comp.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <cmath>
#include <fstream>
#include <iostream>
#include <vector>
#include "international_draught_bb_comp.hpp"
#include "international_draught_util.hpp"
#include "../Platform.h"

namespace InternationalDraught
{
    namespace bb {
        
        // constants
        
        const int32_t RLE_Size { 255 / 3 };
        
        const int32_t Block_Size { 1 << 8 };
        
        // variables
        
        static int32_t RLE[RLE_Size + 1];
        
        static int32_t Code_Value[256];
        static int32_t Code_Length[256];
        
        // functions
        
        void comp_init() {
            
            for (int32_t i = 0; i < RLE_Size; i++) {
                RLE[i] = ml::round(std::pow(1.2, double(i)));
            }
            
            for (int32_t byte = 0; byte < 256; byte++) {
                Code_Value[byte]  = byte % 3;
                Code_Length[byte] = RLE[byte / 3];
            }
        }
        
        bool Index_::load(const std::string & file_name, Index size) {
            bool isAndroidAsset = false;
#ifdef Android
            {
                assetistream file(assetManager, file_name.c_str());
                if(file.isOpen()){
                    isAndroidAsset = true;
                    p_size = size;
                    load_file(p_table, file);
                    // create index table for on-line decompression
                    Index table_size = Index(p_table.size());
                    Index index_size = (table_size + Block_Size - 1) / Block_Size;

                    p_index.clear();
                    p_index.reserve(index_size + 1); // sentinel for debug

                    Index pos = 0;

                    for (Index i = 0; i < table_size; i++) {
                        if (i % Block_Size == 0) p_index.push_back(pos);
                        pos += Code_Length[p_table[i]];
                    }

                    if (pos != p_size) {
                        std::cerr << "unmatched uncompressed size: " << file_name << ": " << p_size << " -> " << pos << std::endl;
                        // std::exit(EXIT_FAILURE);
                        return false;
                    }

                    // assert(Index(p_index.size()) == index_size);
                    {
                        if(!(Index(p_index.size()) == index_size)){
                            printf("error, assert(Index(p_index.size()) == index_size)\n");
                            return false;
                        }
                    }
                    p_index.push_back(p_size); // sentinel for debug
                    return true;
                } else {
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Index_load: cannot open file: %s\n", file_name.c_str());
                }
            }
#endif
            if(!isAndroidAsset){
                std::ifstream file(file_name.c_str(), std::ios::binary);
                if (!file) {
                    std::cerr << "unable to open file \"" << file_name << "\"" << std::endl;
                    // std::exit(EXIT_FAILURE);
                    return false;
                }
                p_size = size;
                load_file(p_table, file);
                // create index table for on-line decompression
                Index table_size = Index(p_table.size());
                Index index_size = (table_size + Block_Size - 1) / Block_Size;

                p_index.clear();
                p_index.reserve(index_size + 1); // sentinel for debug

                Index pos = 0;

                for (Index i = 0; i < table_size; i++) {
                    if (i % Block_Size == 0) p_index.push_back(pos);
                    pos += Code_Length[p_table[i]];
                }

                if (pos != p_size) {
                    std::cerr << "unmatched uncompressed size: " << file_name << ": " << p_size << " -> " << pos << std::endl;
                    // std::exit(EXIT_FAILURE);
                    return false;
                }

                // assert(Index(p_index.size()) == index_size);
                {
                    if(!(Index(p_index.size()) == index_size)){
                        printf("error, assert(Index(p_index.size()) == index_size)\n");
                        return false;
                    }
                }
                p_index.push_back(p_size); // sentinel for debug
                return true;
            } else {
                return false;
            }
        }

        int32_t Index_::get(Index pos) const {
            // printf("Index_ get: %d, %d\n", pos, p_size);
            // assert(pos < p_size);
            if(pos>=p_size){
                printf("error, assert(pos < p_size): %d, %d\n", pos, p_size);
                return 0;
            }
            
            // find the compressed block using the index table

            int32_t low = 0;
            int32_t high = (int32_t)p_index.size() - 1;
            {
                // assert(low <= high);
                if(low>high){
                    printf("error, assert(low <= high)\n");
                    low = high;
                }
            }
            
            while (low < high) {

                int32_t mid = (low + high + 1) / 2;
                {
                    // assert(mid > low && mid <= high);
                    if(!(mid > low && mid <= high)){
                        printf("error, assert(mid > low && mid <= high)\n");
                        mid = high;
                    }
                }
                
                if (p_index[mid] <= pos) {
                    low = mid;
                    {
                        // assert(low <= high);
                        if(low>high){
                            printf("error, assert(low <= high)\n");
                            low = high;
                        }
                    }
                } else {
                    high = mid - 1;
                    {
                        // assert(low <= high);
                        if(low>high){
                            printf("error, assert(low <= high)\n");
                            low = high;
                        }
                    }
                }
            }
            
            {
                // assert(low == high);
                if(low!=high){
                    printf("error, assert(low == high)\n");
                    low = high;
                }
            }
            {
                // assert(p_index[low] <= pos);
                if(pos<p_index[low]){
                    printf("error, assert(p_index[low] <= pos)\n");
                    pos = p_index[low];
                }
            }
            {
                // assert(p_index[low + 1] > pos);
                if(p_index[low + 1] <= pos){
                    printf("error, assert(p_index[low + 1] > pos)\n");
                    pos = p_index[low + 1] - 1;
                }
            }
            
            // find the value using on-line RLE
            
            {
                // assert(pos >= p_index[low]);
                if(pos<p_index[low]){
                    printf("error, assert(pos >= p_index[low])\n");
                    pos = p_index[low];
                }
            }
            pos -= p_index[low];
            
            for (Index i = low * Block_Size; true; i++) {

                int32_t byte = p_table[i];

                int32_t len = Code_Length[byte];
                if (pos < Index(len)) return Code_Value[byte];
                pos -= len;
            }
        }
        
    }
}
