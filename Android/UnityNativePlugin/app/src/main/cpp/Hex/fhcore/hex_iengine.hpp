#pragma once
#include <chrono>
#include <future>
#include <mutex>
#include "hex_board.hpp"

namespace Hex
{
    namespace engine
    {
        
        typedef void *(*FUNC_CB_AIMOVE)(position::pos_t result, void *opaque);
        
        typedef struct EngineCfg
        {
            board::IBoard *pBoard;
            color::Color colorAI;
        } EngineCfg;
        
        class IEngine
        {
        public:
            virtual ~IEngine();
            void configure(EngineCfg cfg) noexcept;
            void compute(FUNC_CB_AIMOVE cb, void *opaque = nullptr) noexcept;
            void compute_sync(position::pos_t & result) noexcept;
            void terminate() noexcept;
            
        protected:
            virtual position::pos_t calc_ai_move_sync() = 0;
            virtual position::pos_t stop_calc_and_return() = 0;
            void wait();
            
        private:
            template<typename T, typename E, typename... Args>
            auto timer(T calc, E engine, Args... args) ->
            decltype((engine->*calc)(args ...));
            void lock();
            void unlock();
            
        public:
            board::IBoard *pBoard { nullptr };
            color::Color colorAI { color::Color::Empty };
            
        private:
            std::mutex _lock;
            std::future<void> _future;
        };
        
        template<typename T, typename E, typename ...Args> inline auto IEngine::timer(T calc, E engine, Args ...args) -> decltype((engine->*calc)(args ...))
        {
            using namespace std::chrono;
            
            auto begin = system_clock::now();
            auto result = (engine->*calc)(args...);
            auto end = system_clock::now();
            auto duration = duration_cast<seconds>(end - begin);
            printf("cost: %lld sec\n", duration.count());
            return result;
        }
        
    }
}
