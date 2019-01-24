#pragma once
#include "hex_position.hpp"
#include "hex_color.hpp"

namespace Hex
{
    using namespace position;
    using namespace color;
    namespace board
    {
        class IBoard;
    }
    
    namespace disjointset
    {
        
        class IDisjointSet
        {
        public:
            virtual ~IDisjointSet() = default;
            static IDisjointSet * create(board::IBoard *pBoard);
            
        public:
            virtual Color get(int32_t index) = 0;
            virtual void set(int32_t index) = 0;
            virtual Color & operator[](int32_t index) = 0;
            virtual void revert() = 0;
            virtual void ufinit() = 0;
            virtual bool check_after_set(int32_t center_index, const Color color) = 0;
        public:
            Color color_to_move() { return static_cast<Color>(rounds & 1); }
        protected:
            size_t rounds;
        };
        
        template<coord_t size> class DisjointSetT : public IDisjointSet
        {
            using Position = PositionT<size>;
        public:
            DisjointSetT() = default;
            DisjointSetT(board::IBoard *pBoard);
            virtual ~DisjointSetT();
        public:
            static IDisjointSet * create(board::IBoard *pBoard);
        public:
            virtual Color get(int32_t index);
            virtual void set(int32_t index);
            virtual Color & operator[](int32_t index);
            virtual void revert();
            virtual void ufinit();
            virtual bool check_after_set(int32_t center_index, const Color color);
            
        private:
            int32_t find(int32_t i, const Color color);
            void merge(int32_t center_index, Color color);
            
        public:
            Color status[size * size];
            
        public:
            PositionT<size>* _pos;
            
            int32_t fa[2][size * size + 2];
            board::IBoard *pBoard;
        };
        
    }
}

#include "hex_disjointset.inl"
