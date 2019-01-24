//
//  uci.hpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shatranj_uci_hpp
#define shatranj_uci_hpp

#include <stdio.h>
#include <map>
#include <string>
#include <vector>
#include "shatranj_types.hpp"

namespace Shatranj
{
    class Position;
    
    // FEN string of the initial position, normal chess
    extern const char* StartFEN;
    
    namespace UCI {
        
        class Option;
        
        /// Custom comparator because UCI options should be case insensitive
        struct CaseInsensitiveLess {
            bool operator() (const std::string&, const std::string&) const;
        };
        
        /// Our options container is actually a std::map
        typedef std::map<std::string, Option, CaseInsensitiveLess> OptionsMap;
        
        /// Option class implements an option as defined by UCI protocol
        class Option {
            
            typedef void (*OnChange)(const Option&);
            
        public:
            Option(OnChange = nullptr);
            Option(bool v, OnChange = nullptr);
            Option(const char* v, OnChange = nullptr);
            Option(const char* v, const std::vector<std::string>& variants, OnChange = nullptr);
            Option(int32_t v, int32_t min, int32_t max, OnChange = nullptr);
            
            Option& operator=(const std::string&);
            void operator<<(const Option&);
            operator int() const;
            operator std::string() const;
            int32_t compare(const char*) const;
            
        private:
            friend std::ostream& operator<<(std::ostream&, const OptionsMap&);
            
            std::string defaultValue, currentValue, type;
            int32_t min, max;
            std::vector<std::string> comboValues;
            size_t idx;
            OnChange on_change;
        };
        
        void init(OptionsMap&);
        std::string value(Value v);
        
        void square(char* ret, Square s);
        std::string square(Square s);
        
        void move(char* ret, Move m);
        std::string move(Move m);
        
        // std::string pv(const Position& pos, Depth depth, Value alpha, Value beta);
        Move to_move(const Position& pos, std::string& str);
        
    } // namespace UCI
    
    extern UCI::OptionsMap Options;
}

#endif /* uci_hpp */
