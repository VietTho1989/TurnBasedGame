//
//  libmy.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <cmath>
#include <cctype>
#include <cstdio>
#include <cstdlib>
#include <ctime>
#include <fstream>
#include <iomanip>
#include <iostream>
#include <random>
#include <sstream>

#include "international_draught_libmy.hpp"

namespace InternationalDraught
{
    namespace ml {
        
        // functions
        
        // math
        
        void rand_init() {
            std::srand((uint32_t)std::time(nullptr));
        }
        
        double rand_float() {
            return double(std::rand()) / (double(RAND_MAX) + 1.0);
        }
        
        uint64 rand_int_64() {
            static std::mt19937_64 gen;
            return gen();
        }
        
        bool rand_bool(double p) {
            {
                // assert(p >= 0.0 && p <= 1.0);
                if(!(p >= 0.0 && p <= 1.0)){
                    printf("error, assert(p >= 0.0 && p <= 1.0)\n");
                    p = 1.0;
                }
            }
            return rand_float() < p;
        }

        int32_t round(double x) {
            return int(floor(x + 0.5));
        }

        int32_t div(int32_t a, int32_t b) {
            {
                // assert(b > 0);
                if(b<=0){
                    printf("error, assert(b > 0)\n");
                    b = 1;
                }
            }
            
            if (b <= 0) {
                std::cerr << "ml::div(): divide error" << std::endl;
                // std::exit(EXIT_FAILURE);
                b = 1;
            }

            int32_t div = a / b;
            if (a < 0 && a != b * div) div--; // fix buggy C semantics
            
            return div;
        }

        int32_t div_round(int32_t a, int32_t b) {
            {
                // assert(b > 0);
                if(b<=0){
                    printf("error, assert(b > 0)\n");
                    b = 1;
                }
            }
            return div(a + b / 2, b);
        }
        
        bool is_power_2(int64 n) {
            {
                // assert(n >= 0);
                if(n<0){
                    printf("error, n<0\n");
                    n = 0;
                }
            }
            return (n & (n - 1)) == 0 && n != 0;
        }
        
        // stream
#ifdef Android
        int64 stream_size(assetistream& stream) {
            int64_t ret = 1;
            {
                asset_streambuf* assetBuf = (asset_streambuf*)stream.rdbuf();
                if(assetBuf->asset!=NULL){
                    ret = AAsset_getLength(assetBuf->asset);
                } else {
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "assetBuf->asset null\n");
                }
            }
            return ret;
        }
#endif

        int64 stream_size(std::istream & stream) {
            {
                // assert(stream.tellg() == 0);
                /*if(stream.tellg() != 0){
                    printf("error, assert(stream.tellg() == 0)\n");
                }*/
            }
            
            stream.seekg(0, std::ios::end);
            int64 size = stream.tellg();
            stream.seekg(0);
            
            return size;
        }

        int32_t get_byte(std::istream & stream) {
            
            char c;
            
            if (!stream.get(c)) {
                std::cerr << "error while reading file" << std::endl;
                std::exit(EXIT_FAILURE);
            }
            
            return c & 0xFF; // HACK
        }
        
        uint64 get_bytes(std::istream & stream, int32_t size) {
            {
                // assert(size >= 0 && size <= 8);
                if(!(size >= 0 && size <= 8)){
                    printf("error, assert(size >= 0 && size <= 8)\n");
                    size = 0;
                }
            }
            
            uint64 bytes = 0;
            
            for (int32_t i = 0; i < size; i++) {
                bytes = (bytes << 8) | get_byte(stream);
            }
            
            return bytes;
        }
        
        // string
        
        std::string ftos(double x, int32_t decimals) {
            std::stringstream ss;
            ss << std::fixed << std::setprecision(decimals) << x;
            return ss.str();
        }
        
        std::string trim(const std::string & s) {

            int32_t begin = 0;
            
            while (begin < int(s.size()) && std::isspace(s[begin])) {
                begin++;
            }

            int32_t end = int(s.size());
            
            while (end > begin && std::isspace(s[end - 1])) {
                end--;
            }
            {
                // assert(begin <= end);
                if(begin>end){
                    printf("error, assert(begin <= end)\n");
                    begin = end;
                }
            }
            
            return s.substr(begin, end - begin);
        }
        
    }
}
