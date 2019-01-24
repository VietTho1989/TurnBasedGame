//
//  thread.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

// includes

#include <iostream>
#include <string>

#include "international_draught_libmy.hpp"
#include "international_draught_thread.hpp"

namespace InternationalDraught
{
    // types
    
    class Input : public Waitable {
        
        private :
        
        std::atomic<bool> p_has_input;
        bool p_eof;
        std::string p_line;
        
        public :
        
        Input ();
        
        bool peek_line (std::string & line);
        bool get_line  (std::string & line);
        
        void set_eof  ();
        void set_line (std::string & line);
        
        bool has_input () const { return p_has_input; }
    };
    
    // variables
    
    static Input G_Input;
    static std::thread G_Thread;
    
    // prototypes
    
    static void input_program (Input * input);
    
    // functions
    
    void listen_input() {
        G_Thread = std::thread(input_program, &G_Input);
        G_Thread.detach();
    }
    
    static void input_program(Input * input) {
        
        std::string line;
        
        while (std::getline(std::cin, line)) {
            input->set_line(line);
        }
        
        input->set_eof();
    }
    
    bool has_input() {
        return G_Input.has_input();
    }
    
    bool peek_line(std::string & line) {
        return G_Input.peek_line(line);
    }
    
    bool get_line(std::string & line) {
        return G_Input.get_line(line);
    }
    
    Input::Input() {
        p_has_input = false;
        p_eof = false;
    }
    
    bool Input::peek_line(std::string & line) {
        
        lock();
        
        {
            // assert(p_has_input);
            if(!p_has_input){
                printf("error, assert(p_has_input)\n");
            }
        }
        
        bool line_ok = !p_eof;
        if (line_ok) line = p_line;
        
        unlock();
        
        return line_ok;
    }
    
    bool Input::get_line(std::string & line) {
        
        lock();
        
        while (!p_has_input) {
            wait();
        }
        
        bool line_ok = !p_eof;
        if (line_ok) line = p_line;
        
        p_has_input = false;
        signal();
        
        unlock();
        
        return line_ok;
    }
    
    void Input::set_eof() {
        
        lock();
        
        while (p_has_input) {
            wait();
        }
        
        p_eof = true;
        
        p_has_input = true;
        signal();
        
        unlock();
    }
    
    void Input::set_line(std::string & line) {
        
        lock();
        
        while (p_has_input) {
            wait();
        }
        
        p_line = line;
        
        p_has_input = true;
        signal();
        
        unlock();
    }
    
}
