#include "hex_position.hpp"

namespace Hex
{
    namespace position
    {
        
        // static_assert(coord_t(-1) > coord_t(0), "type: coord_t, supposed to be unsigned.");
        
        template<coord_t size> inline const pos_t* PositionT<size>::operator()(coord_t index) const
        {
            return _container[index];
        }
        
        template<coord_t size> inline const pos_t * PositionT<size>::operator()(coord_t row, coord_t col) const
        {
            return _container[row * size + col];
        }
        
        template<coord_t size> inline PositionT<size>::PositionT()
        {
            for (auto row = 0; row < size; ++row)
            {
                for (auto col = 0; col < size; ++col)
                {
                    _container[row * size + col] = new pos_t(row, col, size);
                }
            }
            coord_t s = size;
            auto &container = _container;
            auto get_index = [&container, s](coord_t row, coord_t col)->pos_t * {
                if (row < s && col < s)
                    return container[row * s + col];
                return nullptr;
            };
            for (auto pos : _container) {
                auto a1 = get_index(pos->row, pos->col - 1);
                auto a2 = get_index(pos->row, pos->col + 1);
                auto a3 = get_index(pos->row - 1, pos->col);
                auto a4 = get_index(pos->row + 1, pos->col);
                auto a5 = get_index(pos->row - 1, pos->col + 1);
                auto a6 = get_index(pos->row + 1, pos->col - 1);
                pos->setAdj(0, a1);
                pos->setAdj(1, a2);
                pos->setAdj(2, a3);
                pos->setAdj(3, a4);
                pos->setAdj(4, a5);
                pos->setAdj(5, a6);
            }
        }
        
        template<coord_t size> inline PositionT<size>::~PositionT()
        {
            for (auto pos : _container)
            {
                delete pos;
                pos = nullptr;
            }
        }
        
    }
}
