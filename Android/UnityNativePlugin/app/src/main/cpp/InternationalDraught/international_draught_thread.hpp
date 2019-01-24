//
//  thread.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_thread_hpp
#define international_draught_thread_hpp

#include <stdio.h>
#include <string>
#include <atomic>
#include <condition_variable>
#include <mutex>
#include <thread>

namespace InternationalDraught
{
    // types
    
    class Lockable {
        
        protected : // HACK for Waitable::wait()
        
        mutable std::mutex p_mutex;
        
        public :
        
        void lock   () const { p_mutex.lock(); }
        void unlock () const { p_mutex.unlock(); }
    };
    
    class Waitable : public Lockable {
        
        private :
        
        std::condition_variable_any p_cond;
        
        public :
        
        void wait   () { p_cond.wait(p_mutex); } // HACK: direct access
        void signal () { p_cond.notify_one(); }
    };
    
    // functions
    
    void listen_input ();
    
    bool has_input ();
    bool peek_line (std::string & line);
    bool get_line  (std::string & line);
}

#endif /* thread_hpp */
