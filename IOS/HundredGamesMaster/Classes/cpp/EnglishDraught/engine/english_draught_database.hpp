//
//  database.h
//  EnglishDraught
//
//  Created by Viet Tho on 7/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef english_draught_database_hpp
#define english_draught_database_hpp

#include "english_draught_board.hpp"

namespace EnglishDraught
{
    int32_t QueryDatabase(CBoard &Board);
    
    void LoadAllDatabases(char *endgame2pcpath, char *endgame3pcpath, char *endgame4pcpath);
}

#endif /* database_h */
