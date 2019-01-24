#pragma once
#include <list>
#include "hex_color.hpp"
#include "hex_position.hpp"

namespace Hex
{
    namespace record
    {
        
        class RecordData
        {
        public:
            RecordData(position::pos_t pos, color::Color color);
            RecordData(position::coord_t index,
                       position::coord_t board_size,
                       color::Color color);
            RecordData(position::coord_t row, position::coord_t col,
                       position::coord_t board_size,
                       color::Color color);
            auto pos()->position::pos_t const;
            auto row()->position::coord_t const;
            auto col()->position::coord_t const;
            auto boardsize()->position::coord_t const;
            auto color()->color::Color const;
            
        private:
            position::pos_t _pos;
            color::Color _color;
        };
        
        class Record : public std::list<RecordData>
        {
            using Data = RecordData;
        public:
            void swap(bool swap) = delete;
            bool swap() const;
            void boardsize(position::coord_t boardsize);
            position::coord_t boardsize() const;
        public:
            void to_gam(unsigned char **gam_buffer, size_t *gam_size) const;
            void to_fh(unsigned char **fh_buffer, size_t *fh_size) const = delete;
            bool from_gam(unsigned char *gam_buffer, size_t gam_size);
            bool from_fh(unsigned char *gam_buffer, size_t gam_size) = delete;
        private:
            
        private:
            bool _swap { false };
            position::coord_t _boardsize;
        };
        
    }
}
