#include "hex_board.hpp"
#include "hex_disjointset.hpp"

namespace Hex
{
    namespace disjointset
    {
        
        template<coord_t size> inline DisjointSetT<size>::DisjointSetT(board::IBoard * pBoard) : pBoard(pBoard)
        {
            
        }
        
        template<coord_t size> inline DisjointSetT<size>::~DisjointSetT()
        {
        }
        
        template<coord_t size> inline IDisjointSet * DisjointSetT<size>::create(board::IBoard *pBoard)
        {
            DisjointSetT* ret = new DisjointSetT(pBoard);
            {
                ret->_pos = ((board::BoardT<size>*)pBoard)->_pos;
            }
            return ret;
        }
        
        template<coord_t size> inline color::Color DisjointSetT<size>::get(int32_t index)
        {
            return status[index];
        }
        
        template<coord_t size> inline void DisjointSetT<size>::set(int32_t index)
        {
            status[index] = color_to_move();
            ++rounds;
        }
        
        template<coord_t size> inline color::Color & DisjointSetT<size>::operator[](int32_t index)
        {
            return status[index];
        }
        
        template<coord_t size> inline void DisjointSetT<size>::revert()
        {
            rounds = pBoard->rounds();
            for (int32_t i = 0; i < size * size; ++i) {
                status[i] = (*pBoard)(i);
            }
            for (int32_t i = 0; i < size * size + 2; ++i) {
                fa[*Color::Red][i] = i;
                fa[*Color::Blue][i] = i;
            }
        }
        
        template<coord_t size> inline void DisjointSetT<size>::ufinit()
        {
            for (int32_t center_index = 0; center_index < size * size; ++center_index) {
                if (Color::Empty != status[center_index])
                    merge(center_index, status[center_index]);
            }
        }
        
        template<coord_t size> inline bool DisjointSetT<size>::check_after_set(int32_t center_index, const Color color)
        {
            merge(center_index, color);
            return find(pBoard->nBegin(), color) == find(pBoard->nEnd(), color);
        }
        
        template<coord_t size> inline int32_t DisjointSetT<size>::find(int32_t i, const Color color)
        {
            while (i != fa[*color][i])
                i = fa[*color][i];
            return i;
        }
        
        template<coord_t size> inline void DisjointSetT<size>::merge(int32_t center_index, Color color)
        {
            const pos_t &center_pos = *(*_pos)(center_index);
            for (auto adj_pos : center_pos.adj()) {
                const auto adj_index = adj_pos->index;
                if (color == status[adj_index]) {
                    int32_t comp_c = find(center_index, color);
                    int32_t comp_a = find(adj_index, color);
                    if (comp_a != comp_c) {
                        fa[*color][comp_a] = comp_c;
                    }
                }
            }
            if (center_pos.bAdjBegin[*color]) {
                fa[*color][find((*_pos).nBegin(), color)] = find(center_index, color);
            }
            if (center_pos.bAdjEnd[*color]) {
                fa[*color][find((*_pos).nEnd(), color)] = find(center_index, color);
            }
        }
        
    }
}
