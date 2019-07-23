//
//  util.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_util_hpp
#define international_draught_util_hpp

// includes

#include <iostream>
#include <string>
#include <vector>
#include <chrono>
#include <stdio.h>
#include <assert.h>
#include "../Platform.h"

#include "international_draught_libmy.hpp"

namespace InternationalDraught
{
    // types
    
    class Bad_Input : public std::exception {
    };
    
    class Bad_Output : public std::exception {
    };
    
    class Scanner_Number {
        
        private :
        
        std::string p_string;
        int32_t p_pos;
        
        public :
        
        explicit Scanner_Number (const std::string & s);
        
        std::string get_token ();
        
        std::string string () const;
        bool eos () const;
        char get_char ();
        void unget_char ();
    };
    
    class Timer {
        
        private :
        
        typedef std::chrono::time_point<std::chrono::system_clock> time_t;
        typedef std::chrono::duration<double> second_t;
        
        double p_elapsed;
        bool p_running;
        time_t p_start;
        
        static time_t now() {
            return std::chrono::system_clock::now();
        }
        
        double time() const {
            {
                // assert(p_running);
                if(!p_running){
                    printf("error, assert(p_running)\n");
                }
            }
            return std::chrono::duration_cast<second_t>(now() - p_start).count();
        }
        
        public :
        
        Timer() {
            reset();
        }
        
        void reset() {
            p_elapsed = 0;
            p_running = false;
        }
        
        void start() {
            p_start = now();
            p_running = true;
        }
        
        void stop() {
            p_elapsed += time();
            p_running = false;
        }
        
        double elapsed() const {
            double time = p_elapsed;
            if (p_running) time += this->time();
            return time;
        }
    };
    
    // functions
#ifdef Android
    void load_file(std::vector<uint8> & table, assetistream& file);
#endif

    void load_file (std::vector<uint8> & table, std::istream & file);
    
    bool string_is_nat (const std::string & s);
}

#endif /* util_hpp */
