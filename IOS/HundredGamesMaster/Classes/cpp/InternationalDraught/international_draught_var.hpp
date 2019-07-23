//
//  var.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_var_hpp
#define international_draught_var_hpp

#include <stdio.h>
#include <vector>
#include "international_draught_libmy.hpp"
#include "international_draught_MyBase.hpp"
#include "international_draught_book.hpp"

namespace InternationalDraught
{
    // constants
    
    const int32_t P { 2125820 };
    
    const int32_t Unit { 10 }; // units per cp
    
    const int32_t Pat_Squares { 12 };
    
    // compile-time functions
    
    constexpr int32_t pow(int32_t a, int32_t b) {
        return (b == 0) ? 1 : pow(a, b - 1) * a;
    }
    
    // variable
    
    struct EvalVariable
    {
        std::vector<int> G_Weight;
        int32_t Index_3    [pow(2, Pat_Squares)];
        int32_t Index_3_Rev[pow(2, Pat_Squares)];
        
    public:
        bool eval_init (const std::string & file_name);
    };
    
    namespace var {
        
        // types
        
        struct Var
        {
            Variant_Type Variant = Normal;
            bool Book = true;
            int32_t  Book_Ply = 4;
            int32_t  Book_Margin = 4;
            bool Ponder = false;
            bool SMP = true;
            int32_t  SMP_Threads = 1;
            int32_t  TT_Size = 1 << 22;
            bool BB = false;
            int32_t  BB_Size = 5;
            int32_t pickBestMove = 90;
            
            EvalVariable* evalVariable = NULL;
            bb::MyBase* myBase = NULL;
            book::Book* myBook = NULL;
            
        public:
            static int32_t getByteSize();
            
            static int32_t convertToByteArray(struct Var* var, uint8_t* &byteArray);
            
            static int32_t parseByteArray(struct Var* var, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect);
            
        };
        
        // functions
        
        void        set (const std::string & name, const std::string & value);
        
        std::string variant (Variant_Type variantType, const std::string & normal, const std::string & killer, const std::string & bt);
        
    }
}

#endif /* var_hpp */
