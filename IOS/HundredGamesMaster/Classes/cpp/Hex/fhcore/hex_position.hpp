#pragma once
#include <array>
#include <ostream>
#include <set>

namespace Hex
{
    namespace position
    {
        using coord_t = uint16_t;
        
        class pos_t;
        template<coord_t size> class PositionT;
        
        class pos_t
        {
        public:
            pos_t() = default;
            pos_t(coord_t row, coord_t col, coord_t size);
            pos_t(const pos_t &) = default;
            const std::set<pos_t *> & adj() const;
            const pos_t *adj(int32_t dir) const;
            void setAdj(int32_t dir, pos_t *adj);
            friend std::ostream& operator<< (std::ostream& stream, const pos_t pt);
        public:
            coord_t row;
            coord_t col;
            coord_t size;
            coord_t index;
            bool bAdjBegin[2];
            bool bAdjEnd[2];
        private:
            std::array<pos_t *, 6> _adjacent {
                nullptr, nullptr, nullptr, nullptr, nullptr, nullptr };
            std::set<pos_t *> _adjacent_exist;
        };
        
        template<coord_t size> class PositionT
        {
        public:
            const pos_t *operator()(coord_t index) const;
            const pos_t *operator()(coord_t row, coord_t col) const;
            
        public:
            const coord_t nBegin() {
                return size * size;
            };
            const coord_t nEnd() {
                return size * size + 1;
            };
            
        public:
            PositionT();
            ~PositionT();
            PositionT(const PositionT<size>&) = delete;
            PositionT(PositionT<size> &&) = delete;
            PositionT<size> & operator=(const PositionT<size> &) = delete;
            
        public:
            std::array<pos_t *, size * size> _container;
        };
        
    }
}

#include "hex_position.inl"
