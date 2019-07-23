#ifndef __KHET_UTILS_H__
#define __KHET_UTILS_H__

#include <vector>
#include <string>

namespace Khet
{
    // The Utils class implements the singleton pattern.
    class Utils
    {
    public:
        static Utils* GetInstance()
        {
            if (_instance == NULL)
            {
                printf("Utils size: %lu\n", sizeof(Utils));
                _instance = new Utils();
            }
            
            return _instance;
        }
        
        // Split by character.
        std::vector<std::string> Split(const std::string&, char) const;
        
        // Split by characters.
        std::vector<std::string> Split(const std::string&, const std::string& delims) const;
        
    private:
        static Utils* _instance;
        
        Utils();
    };
}

#endif // __UTILS_H__
