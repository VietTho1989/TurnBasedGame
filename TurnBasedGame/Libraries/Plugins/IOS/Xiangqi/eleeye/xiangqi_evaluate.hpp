//
//  xiangqi_evaluate.h
//  TestXiangqi
//
//  Created by Viet Tho on 3/14/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef xiangqi_evaluate_h
#define xiangqi_evaluate_h

#include "../xiangqi_jni.hpp"

namespace Xiangqi {

    int32_t EvaluatePositionEVA(PositionStruct *lppos, int32_t vlAlpha, int32_t vlBeta, EvaluateResult* result);
    
}

#endif /* xiangqi_evaluate_h */
