#include <iomanip>
#include <typeinfo>
#include "hex_position.hpp"
#include "hex_color.hpp"
using namespace std;

namespace Hex
{
    namespace position
    {
        
        pos_t::pos_t(coord_t row, coord_t col, coord_t size) : row(row), col(col), size(size), index(row * size + col)
        {
            using namespace color;
            bAdjBegin[*Color::Red] = (0 == row);
            bAdjBegin[*Color::Blue] = (0 == col);
            bAdjEnd[*Color::Red] = (size - 1 == row);
            bAdjEnd[*Color::Blue] = (size - 1 == col);
        }
        
        const std::set<pos_t *> & pos_t::adj() const
        {
            return _adjacent_exist;
        }
        
        const pos_t *position::pos_t::adj(int32_t dir) const
        {
            return _adjacent[dir];
        }
        
        void position::pos_t::setAdj(int32_t dir, pos_t *adj)
        {
            _adjacent[dir] = adj;
            if (adj)
                _adjacent_exist.insert(adj);
        }
        
        ostream & operator<<(ostream & stream, const pos_t pt)
        {
            stream << endl;
            auto func = [&stream](pos_t pt, const char *indent = "") {
                stream << indent << pt.index
                << " (row: " << pt.row << ", col:" << pt.col << ")" << endl;
            };
            // stream << typeid(pt).name() << ", ";
            func(pt);
            
            if (!pt.adj().empty())
                stream << "adjacent pos: " << endl;
            for (int32_t i = 0; i < 6; ++i) {
                auto adj = pt.adj(i);
                if (adj) {
                    func(*adj, "\t");
                }
            }
            return stream;
        }
        
    }
}
