//
//  Position.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_position_hpp
#define international_draught_position_hpp

#include <stdio.h>
#include <vector>
#include <mutex>
#include "international_draught_pos.hpp"
#include "international_draught_var.hpp"

namespace InternationalDraught
{
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// Book /////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    extern char BookPath[1024];
    
    extern std::mutex bookMutext;
    
    extern book::Book* bookNormal;
    extern book::Book* bookKiller;
    extern book::Book* bookBT;
    
    book::Book* getBook(Variant_Type variantType);
    
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// EvalVariable /////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    extern char EvalPath[1024];
    
    extern std::mutex evalMutext;
    
    extern EvalVariable* evalVariableNormal;
    extern EvalVariable* evalVariableKiller;
    extern EvalVariable* evalVariableBT;
    
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// Position /////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    struct Position
    {
        Node* node = NULL;
        struct var::Var var;
        uint64 lastMove = 0;
        int32_t ply = 50;
        
        // dung de free data
        Node* firstNode = NULL;
        
        // CaptureSquares
        int32_t captureSize = 0;
        Square captureSquares[20];
        
    public:
        int32_t getByteSize();
        
        static int32_t convertToByteArray(struct Position* position, uint8_t* &byteArray);
        
        static int32_t parseByteArray(struct Position* position, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect);
        
        ~Position()
        {
            if(firstNode!=NULL){
                free(firstNode);
            }else{
                printf("error, destructor: node null\n");
            }
        }
        
        void print(char* ret);
    };
}

#endif /* Position_hpp */
