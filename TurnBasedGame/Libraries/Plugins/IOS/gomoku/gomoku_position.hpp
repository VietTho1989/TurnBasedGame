//
//  position.hpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef gomoku_position_hpp
#define gomoku_position_hpp

#include <stdio.h>
#include <stdint.h>
#include <stdlib.h>

namespace gomoku
{
#define LastMoveCount 8
    
    struct Position
    {
        int32_t boardSize = 19;
        char* gs = NULL;
        int32_t player = 1;
        int32_t winningPlayer = 0;
        int32_t lastMove[LastMoveCount];
        
        // win information
        int32_t winSize = 0;
        int32_t winCoord[100];
        
    public:
        void setLastMove(int32_t coord);
        
        void print(char* ret);

        int32_t getByteSize();
        
        static int32_t convertToByteArray(struct Position* position, uint8_t* &byteArray);
        
        static int32_t parseByteArray(struct Position* position, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect);
        
        ~Position()
        {
            if(gs){
                free(gs);
            }else{
                printf("gs null\n");
            }
        }
    };
}

#endif /* position_hpp */
