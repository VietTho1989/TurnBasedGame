//
//  thread_win32.h
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shatranj_thread_win32_h
#define shatranj_thread_win32_h

#include <condition_variable>
#include <mutex>

namespace Shatranj
{
#if defined(_WIN32) && !defined(_MSC_VER)
    
#ifndef NOMINMAX
#  define NOMINMAX // Disable macros min() and max()
#endif
    
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#undef WIN32_LEAN_AND_MEAN
#undef NOMINMAX
    
    /// Mutex and ConditionVariable struct are wrappers of the low level locking
    /// machinery and are modeled after the corresponding C++11 classes.
    
    struct Mutex {
        Mutex() { InitializeCriticalSection(&cs); }
        ~Mutex() { DeleteCriticalSection(&cs); }
        void lock() { EnterCriticalSection(&cs); }
        void unlock() { LeaveCriticalSection(&cs); }
        
    private:
        CRITICAL_SECTION cs;
    };
    
    typedef std::condition_variable_any ConditionVariable;
    
#else // Default case: use STL classes
    
    typedef std::mutex Mutex;
    typedef std::condition_variable ConditionVariable;
    
#endif
}

#endif /* thread_win32_h */
