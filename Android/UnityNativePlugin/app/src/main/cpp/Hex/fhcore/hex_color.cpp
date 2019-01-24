#include <map>
#include <iomanip>
#include "hex_color.hpp"

using namespace std;

namespace Hex
{
    namespace color
    {
        
#if defined(DEBUG) || defined(_DEBUG)
        Color operator!(const Color color)
        {
            // assert(color != Color::Empty);
            if(color == Color::Empty){
                printf("error, assert(color != Color::Empty)\n");
            }
            
            return static_cast<Color>(!static_cast<color_t>(color));
        }
#endif
        
        ostream & operator<<(ostream & stream, Color color)
        {
            // stream << std::setfill(' ') << std::setw(5);
            stream << setfill(' ') << setw(1);
            static const map<Color, const char *> str_map =
            {
                { Color::Red, "r" },
                { Color::Blue, "b" },
                { Color::Empty, "_" },
            };
            stream << str_map.find(color)->second;
            
            return stream;
        }
        
    }
}
