#include "khet_Utils.hpp"
#include <sstream>

namespace Khet
{
    Utils* Utils::_instance = NULL;
    
    Utils::Utils()
    {
    }
    
    // Split by character.
    std::vector<std::string> Utils::Split(const std::string& s, char delim) const
    {
        auto elems = std::vector<std::string>();
        std::stringstream ss(s);
        std::string item;
        while (std::getline(ss, item, delim))
        {
            elems.push_back(item);
        }
        return elems;
    }
    
    // Split by characters.
    std::vector<std::string> Utils::Split(const std::string& s, const std::string& delims) const
    {
        auto elems = std::vector<std::string>();
        
        size_t prev = 0, pos;
        while ((pos = s.find_first_of(delims, prev)) != std::string::npos)
        {
            if (pos > prev)
                elems.push_back(s.substr(prev, pos-prev));
            prev = pos + 1;
        }
        
        if (prev < s.length())
            elems.push_back(s.substr(prev, std::string::npos));
        
        return elems;
    }
}
