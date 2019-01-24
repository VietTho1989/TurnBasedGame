//
//  util.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <cctype>
#include "international_draught_util.hpp"

namespace InternationalDraught
{
    // functions

#ifdef Android
    void load_file(std::vector<uint8> & table, assetistream& file) {

        int64 size = ml::stream_size(file);
        // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "size: %lld\n", size);
        if(size>0){
            table.resize(size);
            file.read((char *) &table[0], size);
        } else {
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, size small");
        }
    }
#endif
    
    void load_file(std::vector<uint8> & table, std::istream & file) {
        
        int64 size = ml::stream_size(file);
        table.resize(size);
        
        file.read((char *) &table[0], size);
    }
    
    Scanner_Number::Scanner_Number(const std::string & s) {
        p_string = s;
        p_pos = 0;
    }
    
    std::string Scanner_Number::get_token() {
        
        if (eos()) return "";
        
        std::string token;
        
        char c = get_char();
        token += c;
        
        if (std::isdigit(c)) {
            
            while (!eos()) {
                
                char c = get_char();
                
                if (!std::isdigit(c)) {
                    unget_char();
                    break;
                }
                
                token += c;
            }
        }
        
        return token;
    }
    
    std::string Scanner_Number::string() const {
        return p_string;
    }
    
    bool Scanner_Number::eos() const {
        return p_pos >= int(p_string.size());
    }
    
    char Scanner_Number::get_char() {
        {
            // assert(!eos());
            if(eos()){
                printf("error, assert(!eos())\n");
                return p_string[0];
            }
        }
        return p_string[p_pos++];
    }
    
    void Scanner_Number::unget_char() {
        {
            // assert(p_pos > 0);
            if(p_pos <= 0){
                printf("error, assert(p_pos > 0)\n");
                p_pos = 1;
            }
        }
        p_pos--;
    }
    
    bool string_is_nat(const std::string & s) {
        
        if (s.size() == 0) return false;
        
        for (int32_t i = 0; i < int(s.size()); i++) {
            if (!std::isdigit(s[i])) return false;
        }
        
        return true;
    }
}
