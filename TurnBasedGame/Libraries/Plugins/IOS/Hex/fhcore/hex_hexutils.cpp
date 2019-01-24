#include <cmath>
#include <iomanip>
#include <sstream>
#include "hex_hexutils.hpp"

namespace Hex
{
    using namespace std;
    namespace hexutils
    {
        
        string xy2symbol(int32_t row, int32_t col, int32_t size)
        {
            if (row >= size || col >= size){
                // throw;
                printf("error, row, col\n");
                return "";
            }
            
            int32_t digits = (int32_t)log10(size) + 1;
            ostringstream oss;
            oss << (char)('A' + col) << "-"
            << setw(digits) << setfill('0') << (row + 1);
            return oss.str();
        }
        
        // gam_locate = (3 + size) + col + row * (size + 2)
        uint8_t xy2gamlocate(int32_t row, int32_t col, int32_t size)
        {
            if (row >= size || col >= size || size > 11) {
                // throw;
                printf("row, col, size error\n");
                return 0;
            }
            return 3 + size + col + (size + 2) * row;
        }
        
        tuple<int32_t, int32_t> gamlocate2xy(int32_t gamlocate, int32_t size)
        {
            if (size > 11) {
                // throw;
                printf("error, gamlocate2xy\n");
            }
            for (int32_t row = 0; row < size; ++row) {
                for (int32_t col = 0; col < size; ++col) {
                    if (gamlocate == xy2gamlocate(row, col, size))
                        return make_tuple(row, col);
                }
            }
            // throw;
            return make_tuple(0, 0);
        }
    }
}
