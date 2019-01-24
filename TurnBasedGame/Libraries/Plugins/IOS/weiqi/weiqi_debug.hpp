//
//  debug.h
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_debug_h
#define weiqi_debug_h

#include <stdbool.h>

namespace weiqi
{
    static int32_t debug_level = 3;
    
#ifdef DEBUG
#define DEBUGL_(l, n) (unlikely((l) > (n)))
#define DEBUG_MODE (true)
#else
#define DEBUGL_(l, n) (false)
#define DEBUG_MODE (false)
#endif
    
    extern int32_t debug_level;
    extern bool debug_boardprint;
    
#define DEBUGL(n) DEBUGL_(debug_level, n)
    
    /* The distributed engine can be _very_ verbose so use DEBUGV
     * to keep only the first N verbose logs. */
#ifndef MAX_VERBOSE_LOGS
#  define MAX_VERBOSE_LOGS 100000
#endif
    extern int64_t verbose_logs;
#define DEBUGV(verbose, n) (DEBUGL(n) && (!(verbose) || ++verbose_logs < MAX_VERBOSE_LOGS))
#define DEBUGVV(n) DEBUGV(true, (n))
}

#endif /* debug_h */
