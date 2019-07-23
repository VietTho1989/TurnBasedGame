//
//  libmy.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_libmy_hpp
#define international_draught_libmy_hpp

#include <stdio.h>
#include <cstdint>
#include <iostream>
#include <string>

#ifdef _WIN32
#include <intrin.h>
#endif

#include "../Platform.h"

namespace InternationalDraught
{
    // constants
    
#undef FALSE
#define FALSE 0
    
#undef TRUE
#define TRUE 1
    
#ifdef DEBUG
#  undef DEBUG
#  define DEBUG TRUE
#else
#  define DEBUG FALSE
#endif
    
    // macros
    
#if DEBUG
#  undef NDEBUG
#else
#  define NDEBUG
#endif
    
#include <cassert> // needs NDEBUG
    
#ifdef _MSC_VER
#  define I64(n) (n##i64)
#  define U64(u) (u##ui64)
#else
#  define I64(n) (n##LL)
#  define U64(u) (u##ULL)
#endif
    
    // types
    
    typedef std::int8_t  int8;
    typedef std::int16_t int16;
    typedef std::int32_t int32;
    typedef long long int int64;
    
    typedef std::uint8_t  uint8;
    typedef std::uint16_t uint16;
    typedef std::uint32_t uint32;
    typedef unsigned long long int uint64;
    
    namespace ml {
        
        // array
        
        template <class T, int32_t Size> class Array {
            
        private:
            
            int32_t p_size;
            T p_item[Size];
            
            void copy(const Array<T, Size> & array) {

                int32_t size = array.p_size;
                
                p_size = size;
                
                for (int32_t pos = 0; pos < size; pos++) {
                    p_item[pos] = array.p_item[pos];
                }
            }
            
        public:
            
            Array ()                             { clear(); }
            Array (const Array<T, Size> & array) { copy(array); }
            
            void operator= (const Array<T, Size> & array) { copy(array); }
            
            void clear(){
                p_size = 0;
            }
            
            void add(T item){
                {
                    // assert(!full());
                    if(full()){
                        printf("error, assert(!full())\n");
                        return;
                    }
                }
                p_item[p_size++] = item;
            }
            
            void add_ref(const T & item){
                {
                    // assert(!full());
                    if(full()){
                        printf("error, assert(!full())\n");
                        return;
                    }
                }
                p_item[p_size++] = item;
            }
            
            T remove(){
                {
                    // assert(!empty());
                    if(empty()){
                        printf("error, assert(!empty())\n");
                        return p_item[0];
                    }
                }
                return p_item[--p_size];
            }
            
            void set_size (int32_t size) {
                {
                    // assert(size <= Size);
                    if(size>Size){
                        printf("error, assert(size <= Size)\n");
                        size = Size;
                    }
                }
                p_size = size;
            }
            
            bool empty () const { return p_size == 0; }
            bool full  () const { return p_size == Size; }
            int32_t  size  () const { return p_size; }
            
            const T & operator[] (int32_t pos) const
            {
                {
                    // assert(pos < p_size);
                    if(pos>=p_size){
                        printf("error, assert(pos < p_size)\n");
                        pos = p_size - 1;
                    }
                }
                return p_item[pos];
            }
            
            T & operator[] (int32_t pos){
                {
                    // assert(pos < p_size);
                    if(pos>=p_size){
                        printf("error, assert(pos < p_size)\n");
                        pos = p_size - 1;
                    }
                }
                return p_item[pos];
            } // direct access!
        };
    }
    
    // functions
    
    namespace ml {
        
        // math
        
        void   rand_init   ();
        double rand_float  ();
        uint64 rand_int_64 ();
        bool   rand_bool   (double p);

        int32_t  round (double x);

        int32_t  div       (int32_t a, int32_t b);
        int32_t  div_round (int32_t a, int32_t b);
        
        bool is_power_2 (int64 n);
        
        inline uint64 bit       (int32_t n) { return uint64(1) << n; }
        inline uint64 bit_mask  (int32_t n) { return bit(n) - 1; }
        
#ifdef _MSC_VER
        inline int32_t bit_first (uint64 b) {
            {
                // assert(b != 0);
                if(b==0){
                    printf("error, assert(b != 0)\n");
                    b = 1;
                }
            }
            unsigned long i;
            _BitScanForward64(&i, b);
            return i;
        }
        
        inline int32_t bit_count (uint64 b) { return int(__popcnt64(b)); }
#else
        inline int32_t bit_first (uint64 b) {
            {
                // assert(b != 0);
                if(b==0){
                    printf("error, assert(b != 0)\n");
                    b= 1;
                }
            }
            return __builtin_ctzll(b);
        }
        
        inline int32_t bit_count (uint64 b) { return __builtin_popcountll(b); }
#endif

#ifdef Android
        int64 stream_size (assetistream& stream);
#endif
        int64 stream_size (std::istream& stream);

        int32_t    get_byte  (std::istream & stream);
        uint64 get_bytes (std::istream & stream, int32_t size);
        
        // string
        
        std::string ftos (double x, int32_t decimals);
        std::string trim (const std::string & s);
    }
}

#endif /* libmy_hpp */
