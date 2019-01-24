//
//  stone.cpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "weiqi_stone.hpp"

#include <ctype.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

namespace weiqi
{
    void stone2str(char* ret, enum stone s)
    {
        switch (s) {
            case S_BLACK:
                strcpy(ret, "black");
                return;
            case S_WHITE:
                strcpy(ret, "white");
                return;
            default:
                strcpy(ret, "none");
                return;
        }
    }
    
    enum stone str2stone(char *str)
    {
        switch (tolower(*str)) {
            case 'b':
                return S_BLACK;
            case 'w':
                return S_WHITE;
            default:
                return S_NONE;
        }
    }
}
