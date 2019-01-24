//
//  ucioption.cpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <algorithm>
#include <cassert>
#include <ostream>

#include "shatranj_misc.hpp"
#include "shatranj_search.hpp"
#include "shatranj_thread.hpp"
#include "shatranj_tt.hpp"
#include "shatranj_uci.hpp"
#include "shatranj_tbprobe.hpp"

using std::string;

namespace Shatranj
{
    UCI::OptionsMap Options; // Global object
    
    namespace UCI {
        
        /// 'On change' actions, triggered by an option's value change
        void on_clear_hash(const Option&)
        {
            // Search::clear();
        }
        
        void on_hash_size(const Option& o)
        {
            // TT.resize(o);
        }
        
        void on_logger(const Option& o) {
            start_logger(o);
        }
        
        void on_threads(const Option& o)
        {
            // Threads.set(o);
        }
        
        void on_tb_path(const Option& o) { Tablebases::init(o); }
        
        
        /// Our case insensitive less() function as required by UCI protocol
        bool CaseInsensitiveLess::operator() (const string& s1, const string& s2) const {
            
            return std::lexicographical_compare(s1.begin(), s1.end(), s2.begin(), s2.end(),
                                                [](char c1, char c2) { return tolower(c1) < tolower(c2); });
        }
        
        
        /// init() initializes the UCI options to their hard-coded default values
        
        void init(OptionsMap& o) {
            
            const int32_t MaxHashMB = Is64Bit ? 1024 * 1024 : 2048;
            
            o["Debug Log File"]        << Option("", on_logger);
            o["Contempt"]              << Option(0, -100, 100);
            o["Threads"]               << Option(1, 1, 512, on_threads);
            o["Hash"]                  << Option(16, 1, MaxHashMB, on_hash_size);
            o["Clear Hash"]            << Option(on_clear_hash);
            o["Ponder"]                << Option(false);
            o["MultiPV"]               << Option(1, 1, 500);
            o["Skill Level"]           << Option(20, 0, 20);
            o["Move Overhead"]         << Option(100, 0, 5000);
            o["nodestime"]             << Option(0, 0, 10000);
            o["UCI_Chess960"]          << Option(false);
            o["UCI_Variant"]           << Option("shatranj", {"shatranj"});
            o["SyzygyPath"]            << Option("<empty>", on_tb_path);
            o["SyzygyProbeDepth"]      << Option(1, 1, 100);
            o["Syzygy50MoveRule"]      << Option(true);
            o["SyzygyProbeLimit"]      << Option(6, 0, 6);
        }
        
        
        /// operator<<() is used to print all the options default values in chronological
        /// insertion order (the idx field) and in the format defined by the UCI protocol.
        
        std::ostream& operator<<(std::ostream& os, const OptionsMap& om) {
            
            for (size_t idx = 0; idx < om.size(); ++idx)
                for (const auto& it : om)
                    if (it.second.idx == idx)
                    {
                        const Option& o = it.second;
                        os << "\noption name " << it.first << " type " << o.type;
                        
                        if (o.type != "button")
                            os << " default " << o.defaultValue;
                        
                        if (o.type == "combo")
                            for (string value : o.comboValues)
                                os << " var " << value;
                        
                        if (o.type == "spin")
                            os << " min " << o.min << " max " << o.max;
                        
                        break;
                    }
            
            return os;
        }
        
        
        /// Option class constructors and conversion operators
        
        Option::Option(const char* v, OnChange f) : type("string"), min(0), max(0), on_change(f)
        { defaultValue = currentValue = v; }
        
        Option::Option(const char* v, const std::vector<std::string>& variants, OnChange f) : type("combo"), min(0), max(0), comboValues(variants), on_change(f)
        { defaultValue = currentValue = v; }
        
        Option::Option(bool v, OnChange f) : type("check"), min(0), max(0), on_change(f)
        { defaultValue = currentValue = (v ? "true" : "false"); }
        
        Option::Option(OnChange f) : type("button"), min(0), max(0), on_change(f)
        {}
        
        Option::Option(int32_t v, int32_t minv, int32_t maxv, OnChange f) : type("spin"), min(minv), max(maxv), on_change(f)
        { defaultValue = currentValue = std::to_string(v); }
        
        Option::operator int() const {
            // assert(type == "check" || type == "spin");
            if(!(type == "check" || type == "spin")){
                printf("error, assert(type == \"check\" || type == \"spin\")\n");
            }
            return (type == "spin" ? stoi(currentValue) : currentValue == "true");
        }
        
        Option::operator std::string() const {
            // assert(type == "string" || type == "combo");
            if(!(type == "string" || type == "combo")){
                printf("error, assert(type == \"string\" || type == \"combo\")\n");
            }
            return currentValue;
        }

        int32_t Option::compare(const char* str) const {
            // assert(type == "string" || type == "combo");
            if(!(type == "string" || type == "combo")){
                printf("error, assert(type == \"string\" || type == \"combo\")\n");
            }
            return currentValue.compare(str);
        }

        /// operator<<() inits options and assigns idx in the correct printing order
        
        void Option::operator<<(const Option& o) {
            
            static size_t insert_order = 0;
            
            *this = o;
            idx = insert_order++;
        }
        
        
        /// operator=() updates currentValue and triggers on_change() action. It's up to
        /// the GUI to check for option's limits, but we could receive the new value from
        /// the user by console window, so let's check the bounds anyway.
        
        Option& Option::operator=(const string& v) {
            
            // assert(!type.empty());
            if(type.empty()){
                printf("error, assert(!type.empty())\n");
            }
            
            if (   (type != "button" && v.empty())
                || (type == "check" && v != "true" && v != "false")
                || (type == "combo" && (std::find(comboValues.begin(), comboValues.end(), v) == comboValues.end()))
                || (type == "spin" && (stoi(v) < min || stoi(v) > max)))
                return *this;
            
            if (type != "button")
                currentValue = v;
            
            if (on_change)
                on_change(*this);
            
            return *this;
        }
        
    } // namespace UCI
}
