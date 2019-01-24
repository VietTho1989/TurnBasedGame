#include <cassert>
#include <chrono>
#include "hex_iengine.hpp"

namespace Hex
{
    using namespace std;
    using namespace chrono;
    using namespace board;
    
    namespace engine
    {
        
        IEngine::~IEngine()
        {
            wait();
        }
        
        void IEngine::configure(EngineCfg cfg) noexcept
        {
            // assert(cfg.pBoard && Color::Empty != cfg.colorAI);
            if(!(cfg.pBoard && Color::Empty != cfg.colorAI)){
                printf("error, assert(cfg.pBoard && Color::Empty != cfg.colorAI)\n");
            }
            
            lock();
            delete pBoard;
            pBoard = cfg.pBoard;// cfg.pBoard->copy();
            colorAI = cfg.colorAI;
            unlock();
        }
        
        void IEngine::compute(FUNC_CB_AIMOVE cb, void *opaque) noexcept
        {
            // assert(cb);
            if(!cb){
                printf("error, assert(cb)\n");
                return;
            }
            
            _future = async(launch::async, [this, cb, opaque] {
                lock();
                pos_t result = timer(&IEngine::calc_ai_move_sync, this);
                unlock();
                cb(result, opaque);
            });
        }
        
        void IEngine::compute_sync(position::pos_t & result) noexcept
        {
            lock();
            result = timer(&IEngine::calc_ai_move_sync, this);
            unlock();
        }
        
        void IEngine::terminate() noexcept
        {
            stop_calc_and_return();
        }
        
        void IEngine::wait()
        {
            // _future.wait();
        }
        
        void IEngine::lock()
        {
            bool is_thinking = !_lock.try_lock();
            if (is_thinking)
                throw;
        }
        
        void IEngine::unlock()
        {
            _lock.unlock();
        }
        
    }
}
