//
//  position.hpp
//  weiqi
//
//  Created by Viet Tho on 3/29/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_position_hpp
#define weiqi_position_hpp

#include <stdio.h>
#include "weiqi_board.hpp"
#include "weiqi_ownermap.hpp"
#include "weiqi_mq.hpp"

namespace weiqi
{
    struct Position
    {
        struct board b;
        
        struct move_queue deadgroup;
        
        // owner map for score
        int32_t scoreOwnerMap[(BOARD_MAX_SIZE+2)*(BOARD_MAX_SIZE+2)];
        int32_t scoreOwnerMapSize = 0;
        // score
        int32_t scoreBlack = 0;
        int32_t scoreWhite = 0;
        int32_t dame = 0;
        float score = 0;
    public:
        void updateScoreAndOwnerMap();

        int32_t getByteSize();
        
        static int32_t convertToByteArray(struct Position* position, uint8_t* &byteArray);
        
        static int32_t parseByteArray(struct Position* position, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect);
        
        ~Position()
        {
            // printf("position destructor\n");
            board_done_noalloc(&b);
        }
    };
}

#endif /* position_hpp */
