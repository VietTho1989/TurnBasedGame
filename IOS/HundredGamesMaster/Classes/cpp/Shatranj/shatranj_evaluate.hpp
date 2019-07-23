//
//  evaluate.hpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shatranj_evaluate_hpp
#define shatranj_evaluate_hpp

#include <stdio.h>
#include <string>

#include "shatranj_types.hpp"

namespace Shatranj
{
    class Position;
    
    namespace Eval {
        
        const Value Tempo = Value(20); // Must be visible to search
        
        std::string trace(const Position& pos);
        
        Value evaluate(const Position& pos);
    }
}

#endif /* evaluate_hpp */
