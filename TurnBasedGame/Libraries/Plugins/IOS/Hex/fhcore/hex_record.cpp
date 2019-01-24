#include "hex_record.hpp"
#include "hex_hexutils.hpp"

namespace Hex
{
    using namespace std;
    using namespace color;
    using namespace position;
    using namespace hexutils;
    namespace record
    {
        
        RecordData::RecordData(pos_t pos, Color color)
        : _pos(pos)
        , _color(color)
        {
        }
        
        RecordData::RecordData(coord_t index, coord_t board_size, Color color)
        {
            coord_t row = index / board_size;
            coord_t col = index % board_size;
            new (this) RecordData(pos_t(row, col, board_size), color);
        }
        
        RecordData::RecordData(coord_t row, coord_t col, coord_t board_size, Color color)
        {
            new (this) RecordData(pos_t(row, col, board_size), color);
        }
        
        auto RecordData::pos() -> position::pos_t const
        {
            return _pos;
        }
        
        auto RecordData::row() -> position::coord_t const
        {
            return _pos.row;
        }
        
        auto RecordData::col() -> position::coord_t const
        {
            return _pos.col;
        }
        
        auto RecordData::boardsize() -> position::coord_t const
        {
            return _pos.size;
        }
        
        auto RecordData::color() -> color::Color const
        {
            return _color;
        }
        
        bool Record::swap() const
        {
            return _swap;
        }
        
        void Record::boardsize(position::coord_t boardsize)
        {
            _boardsize = boardsize;
        }
        
        position::coord_t Record::boardsize() const
        {
            return _boardsize;
        }
        
        void Record::to_gam(unsigned char **gam_buffer, size_t *gam_size) const
        {
            *gam_size = 128; // magic number :)
            *gam_buffer = new unsigned char[*gam_size]{ 0 };
            auto buffer = *gam_buffer;
            size_t i = 0;
            buffer[i++] = 0xff & _boardsize; // boardsize
            buffer[i++] = 0xff & (int)_swap; // swap rule
            for (auto data : *this)
            {
                if (i >= *gam_size)
                    throw;
                buffer[i++] = xy2gamlocate(data.row(), data.col(), _boardsize);
            }
        }
        
        bool Record::from_gam(unsigned char *gam_buffer, size_t gam_size)
        {
            size_t i = 0;
            auto boardsize = gam_buffer[i++];
            auto swap = 0 != gam_buffer[i++];
            if (gam_size != 128 || (swap != 0 && swap != 1))
                return false;
            
            clear();
            _swap = swap;
            _boardsize = boardsize;
            Color color = swap ? Color::Blue : Color::Red;
            for (;;)
            {
                auto gamlocate = gam_buffer[i++];
                if (!gamlocate)
                    break;
                auto xy = gamlocate2xy(gamlocate, boardsize);
                auto row = get<0>(xy);
                auto col = get<1>(xy);
                push_back(Data(row, col, boardsize, color));
            }
            return true;
        }
        
    }
}
