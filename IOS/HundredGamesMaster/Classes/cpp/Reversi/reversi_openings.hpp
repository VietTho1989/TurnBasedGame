#ifndef __reversi_OPENINGS_H__
#define __reversi_OPENINGS_H__

#include "reversi_common.hpp"

namespace Reversi
{
    struct Node {
        bitbrd taken, black;
        int32_t move;
    };
    
    class Openings {
        
    private:
        Node **openings;
        int32_t bookSize;
        int32_t binarySearch(bitbrd taken, bitbrd black);
        
        bool readFile();
        
    public:
        Openings();
        ~Openings();

        int32_t get(bitbrd taken, bitbrd black);
    };
}

#endif
