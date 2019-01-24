#pragma once
#include <string>
#include <tuple>
#include "hex_position.hpp"
#include "hex_record.hpp"

namespace Hex
{
    namespace hexutils
    {
        
        std::string xy2symbol(int32_t row, int32_t col, int32_t size);
        
        uint8_t xy2gamlocate(int32_t row, int32_t col, int32_t size);
        
        std::tuple<int32_t, int32_t> gamlocate2xy(int32_t gamlocate, int32_t size);
        
    }
}
