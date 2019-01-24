#pragma once
#include <cassert>
#include <iostream>

namespace Hex
{
    namespace color
    {
        using color_t = char;
        
        enum class Color : color_t
        {
            Empty = 2,
            Red = 0,
            Blue = 1,
        };
        
        // Get opposite color.
#if defined(DEBUG) || defined(_DEBUG)
        Color operator!(const Color color);
#else
        constexpr Color operator!(const Color color)
        {
            return static_cast<Color>(!static_cast<color_t>(color));
        }
#endif
        
        // Convert to color_t.
        constexpr color_t operator*(const Color color)
        {
            return static_cast<color_t>(color);
        }
        
        std::ostream& operator<< (std::ostream& stream, Color color);
        
    }
}
