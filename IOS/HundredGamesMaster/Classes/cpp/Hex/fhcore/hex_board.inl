#include <algorithm>
#include <cassert>
#include <cmath>
#include <iomanip>
#include <sstream>
#include <typeinfo>
#include "hex_board.hpp"

namespace Hex
{
    using namespace std;
    using namespace color;
    
    namespace board
    {
        
        template<coord_t size> inline BoardT<size>::BoardT() noexcept
        {
            static_assert((4 <= size) && (size <= MAX_BOARD_SIZE), "board size supposed to an odd number greater than five.");
            _pos = new PositionT<size>();
            
            auto func = [this](auto& link_rb, const PositionT<size> & pos, Color color) {
                auto & link_array = link_rb[*color];
                int32_t index = 0;
                for (set<coord_t> & link : link_array) {
                    if (size * size == index)
                        break;
                    auto pt_center = pos(index);
                    for (auto pt_adjacent : pt_center->adj())
                    {
                        link.insert(pt_adjacent->index);
                    }
                    if (pt_center->bAdjBegin[*color])
                    {
                        link.insert(_pos->nBegin());
                        link_array[_pos->nBegin()].insert(index);
                    }
                    if (pt_center->bAdjEnd[*color])
                    {
                        link.insert(_pos->nEnd());
                        link_array[_pos->nEnd()].insert(index);
                    }
                    ++index;
                }
            };
            func(_link, *_pos, Color::Red);
            func(_link, *_pos, Color::Blue);
        }
        
        template<coord_t size> inline BoardT<size>::~BoardT() noexcept
        {
            if(this->_pos!=NULL){
                delete this->_pos;
                this->_pos = NULL;
            }
        }
        
        template<coord_t size> inline IBoard * BoardT<size>::create()
        {
            return new BoardT();
        }
        
        template<coord_t size> inline IBoard & BoardT<size>::operator()(coord_t row, coord_t col)
        {
            // assert(size > row && size > col);
            if(!(size > row && size > col)){
                printf("error, assert(size > row && size > col)\n");
            }
            
            _rowBuf = row;
            _colBuf = col;
            return *this;
        }
        
        template<coord_t size> inline IBoard & BoardT<size>::operator()(coord_t index)
        {
            // assert(size * size > index);
            if(!(size * size > index)){
                printf("error, assert(size * size > index)\n");
            }
            
            _rowBuf = (*_pos)(index)->row;
            _colBuf = (*_pos)(index)->col;
            return *this;
        }
        
        template<coord_t size> inline std::tuple<const std::set<coord_t>*, size_t> BoardT<size>::operator[](const Color color) const
        {
            using namespace std;
            return make_tuple(_link[*color].data(), _link[*color].size());
        }
        
        template<coord_t size> inline void BoardT<size>::operator=(const Color color)
        {
            if (Color::Empty == color)
            {
                reset_piece();
            }
            else // Not empty
            {
                set_piece(color);
            }
        }
        
        template<coord_t size> inline BoardT<size>::operator Color() const
        {
            if (_bit[*Color::Red][buf_index()])
                return Color::Red;
            else if (_bit[*Color::Blue][buf_index()])
                return Color::Blue;
            else
                return Color::Empty;
        }
        
        template<coord_t size> inline const std::set<pos_t*>& BoardT<size>::adj() const
        {
            return (*_pos)(_rowBuf, _colBuf)->adj();
        }
        
        template<coord_t size> inline const pos_t * BoardT<size>::adj(int32_t dir) const
        {
            return (*_pos)(_rowBuf, _colBuf)->adj(dir);
        }
        
        template<coord_t size> inline const pos_t * BoardT<size>::pos() const
        {
            return (*_pos)(_rowBuf, _colBuf);
        }
        
        template<coord_t size> inline size_t BoardT<size>::boardsize() const
        {
            return size;
        }
        
        template<coord_t size> inline size_t BoardT<size>::rounds() const
        {
            return _bit[*Color::Red].count() + _bit[*Color::Blue].count();
        }
        
        template<coord_t size> inline Color BoardT<size>::color() const
        {
            return rounds() % 2 ? Color::Blue : Color::Red;
        }
        
        template<coord_t size> inline Color BoardT<size>::winner() const
        {
            bool r_win = (_link[*Color::Red][_pos->nBegin()].end() !=
                          _link[*Color::Red][_pos->nBegin()].find(_pos->nEnd()));
            bool b_win = (_link[*Color::Blue][_pos->nBegin()].end() !=
                          _link[*Color::Blue][_pos->nBegin()].find(_pos->nEnd()));
            
            // assert(!(r_win && b_win));
            if(r_win && b_win){
                printf("error, assert(!(r_win && b_win))\n");
            }
            
            if (r_win)
                return Color::Red;
            else if (b_win)
                return Color::Blue;
            else
                return Color::Empty;
        }
        
        template<coord_t size> inline bool BoardT<size>::empty() const
        {
            return _bit[*Color::Red].none() && _bit[*Color::Blue].none();
        }
        
        template<coord_t size> inline bool BoardT<size>::empty(coord_t index) const
        {
            return _bit[*Color::Red][index] == 0 && _bit[*Color::Blue][index] == 0;
        }
        
        template<coord_t size> inline bool BoardT<size>::empty(coord_t row, coord_t col) const
        {
            coord_t index = (*_pos)(row, col)->index;
            return empty(index);
        }
        
        template<coord_t size> coord_t BoardT<size>::nBegin() const
        {
            return _pos->nBegin();
        }
        
        template<coord_t size> inline coord_t BoardT<size>::nEnd() const
        {
            return _pos->nEnd();
        }
        
        template<coord_t size> inline bool BoardT<size>::equal_to(const IBoard & rhs) const
        {
            // const BoardT & ref = *dynamic_cast<const BoardT *>(&rhs);
            const BoardT & ref = *(const BoardT*)(&rhs);
            
            if (_bit[*Color::Red] != ref._bit[*Color::Red] ||
                _bit[*Color::Blue] != ref._bit[*Color::Blue])
                return false;
            
#if defined(DEBUG) || defined(_DEBUG)
            bool flag_r = _link[*Color::Red] != ref._link[*Color::Red];
            bool flag_b = _link[*Color::Blue] != ref._link[*Color::Blue];
            if (flag_r || flag_b)
            {
                // do something
                // Hex::debug(Level::Info) << debug_link_str();
                // Hex::debug(Level::Info) << ref.debug_link_str();
                
                return false;
            }
#endif // DEBUG
            
            return true;
        }
        
        template<coord_t size> inline std::set<coord_t>::iterator BoardT<size>::begin(const Color color, coord_t index) const
        {
            return _link[*color][index].begin();
        }
        
        template<coord_t size> inline std::set<coord_t>::iterator BoardT<size>::end(const Color color, coord_t index) const
        {
            return _link[*color][index].end();
        }
        
        template<coord_t size> inline IBoard * BoardT<size>::copy() const
        {
            printf("copy board\n");
            return new BoardT(*this);
        }
        
        template<coord_t size> inline bool BoardT<size>::operator==(const BoardT & rhs) const
        {
            return equal_to(rhs);
        }
        
        template<coord_t size> inline bool BoardT<size>::operator!=(const BoardT & rhs) const
        {
            return !equal_to(rhs);
        }
        
        template<coord_t size> inline coord_t BoardT<size>::buf_index() const
        {
            return (*_pos)(_rowBuf, _colBuf)->index;
        }
        
        template<coord_t size> inline void BoardT<size>::get_direct_capture_union(std::set<coord_t> & out, coord_t center, Color color, bool first_time/* = true*/) const
        {
            out.insert(center);
            for (auto pos_adj : (*_pos)(center)->adj())
            {
                const coord_t adj_index = pos_adj->index;
                // if own color captured
                if (_bit[*color][adj_index] &&
                    out.end() == out.find(adj_index))
                {
                    get_direct_capture_union(out, adj_index, color, false);
                }
            }
            //if (first_time)
            //    out.erase(center);
        }
        
        template<coord_t size> inline void BoardT<size>::get_direct_link_union(std::set<coord_t> & out,std::set<coord_t> & except, coord_t center, Color color, bool first_time/* = true*/) const
        {
            using namespace std;
            
            const pos_t *pos_center = (*_pos)(center);
            // mark center index as excpet
            except.insert(center);
            
            // handle each adjance block around center
            for (auto pos_adj : pos_center->adj())
            {
                const coord_t adj_index = pos_adj->index;
                // if oppsite color captured
                if (_bit[*!color][adj_index])
                {
                    // do nothing
                }
                // if own color captured
                else if (_bit[*color][adj_index])
                {
                    // check if adj_index already searched
                    if (except.end() == except.find(adj_index))
                    {
                        // if not, marked in except
                        except.insert(adj_index);
                        // recursion
                        get_direct_link_union(out, except, adj_index, color, false);
                    }
                }
                // empty block
                else
                {
                    out.insert(adj_index); // link to empty block
                }
            }
            
            // link to begin/end point if own color captured
            if (pos_center->bAdjBegin[*color])
                out.insert(nBegin());
            if (pos_center->bAdjEnd[*color])
                out.insert(nEnd());
            
            // make sure do not link itself
            if (first_time)
                out.erase(center);
        }
        
        template<coord_t size> inline void BoardT<size>::set_piece(const Color color)
        {
            const auto center = buf_index();
            // make sure position empty
            {
                // assert(0 == _bit[*!color][center]);
                if(0 != _bit[*!color][center]){
                    printf("error, assert(0 == _bit[*!color][center])\n");
                }
            }
            // current-color, set bitmap
            _bit[*color].set(center);
            // opposite-color, clear link
            for (auto adj_index : _link[*!color][center])
            {
                _link[*!color][adj_index].erase(center);
            }
            _link[*!color][center].clear();
            // current-color, link
            for (auto iter = _link[*color][center].begin();
                 iter != _link[*color][center].end();
                 ++iter)
            {
                // disconnect with center-point
                _link[*color][*iter].erase(center);
                // connect with point around center
                auto it_adj = iter;
                for (++it_adj; it_adj != _link[*color][center].end(); ++it_adj)
                {
                    _link[*color][*iter].insert(*it_adj);
                    _link[*color][*it_adj].insert(*iter);
                }
            }
            _link[*color][center].clear();
        }
        
        template<coord_t size> inline void BoardT<size>::reset_piece()
        {
            using namespace std;
            // color of previous owner
            Color previous = *this;
            if (Color::Empty == previous)
                return;
            
            const coord_t center = buf_index();
            
            // reset bitmap for both color
            _bit[*Color::Red].reset(center);
            _bit[*Color::Blue].reset(center);
            
            // ******************** color of previous owner ********************
            set<coord_t> captured;
            get_direct_capture_union(captured, center, previous);
            // clear link state around captured block
            for (auto cap_index : captured)
            {
                for (auto pos_adj : (*_pos)(cap_index)->adj())
                {
                    const coord_t adj = pos_adj->index;
                    if (!empty(adj))
                        continue;
                    
                    for (auto adj_adj : _link[*previous][adj])
                    {
                        _link[*previous][adj_adj].erase(adj);
                    }
                    _link[*previous][adj].clear();
                }
            }
            // infer direct-link of each block around captured block, then relink it
            set<coord_t> out, except;
            for (auto cap_index : captured)
            {
                for (auto pos_adj : (*_pos)(cap_index)->adj())
                {
                    const coord_t adj = pos_adj->index;
                    if (!empty(adj))
                        continue;
                    
                    get_direct_link_union(out, except, adj, previous);
                    for (auto link_index : out)
                    {
                        _link[*previous][adj].insert(link_index);
                        _link[*previous][link_index].insert(adj);
                    }
                    out.clear();
                    except.clear();
                }
            }
            
            // handle center block
            get_direct_link_union(out, except, center, previous);
            for (auto link_index : out)
            {
                _link[*previous][center].insert(link_index);
                _link[*previous][link_index].insert(center);
            }
            out.clear();
            except.clear();
            
            // ******************** color of opposite owner ********************
            // handle center block
            get_direct_link_union(out, except, center, !previous);
            for (auto link_index : out)
            {
                _link[*!previous][center].insert(link_index);
                _link[*!previous][link_index].insert(center);
            }
            
        }
        
        template<coord_t size> std::ostream& operator<< (std::ostream& stream, BoardT<size> b)
        {
            using namespace std;
            // stream << typeid(b).name() << __func__ << endl;
            stream << b.debug_state_str();
            stream << b.debug_link_str();
            stream << b.debug_bit_str();
            return stream;
        }
        
        template<coord_t size> inline void BoardT<size>::reset()
        {
            reset_piece();
        }
        
    }
}
