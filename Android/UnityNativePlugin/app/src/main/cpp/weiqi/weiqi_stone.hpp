//
//  stone.hpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_stone_hpp
#define weiqi_stone_hpp

#include <stdio.h>

namespace weiqi
{
    enum stone {
        S_NONE,
        S_BLACK,
        S_WHITE,
        S_OFFBOARD,
        S_MAX,
    };
    
    // loai bo static
    void stone2str(char* ret, enum stone s);
    
    // loai bo static
    enum stone char2stone(char s);
    enum stone str2stone(char *str);
    
    /* Curiously, gcc is reluctant to inline this; I have cofirmed
     * there is performance benefit. */
    // loai bo static
#ifdef _MSC_VER
    inline enum stone stone_other(enum stone s)
#else
    inline enum stone __attribute__((always_inline)) stone_other(enum stone s)
#endif
    {
        static const enum stone o[S_MAX] = { S_NONE, S_WHITE, S_BLACK, S_OFFBOARD };
        return o[s];
    }
    
    // loai bo static
    inline char stone2char(enum stone s)
    {
        return ".XO#"[s];
    }
    
    // loai bo static
    inline enum stone char2stone(char s)
    {
        switch (s) {
            case '.': return S_NONE;
            case 'X': return S_BLACK;
            case 'O': return S_WHITE;
            case '#': return S_OFFBOARD;
        }
        return S_NONE; // XXX
    }
    
}

#endif /* stone_hpp */
