#ifndef __KHET_SEARCH_PARAMS_H__
#define __KHET_SEARCH_PARAMS_H__

namespace Khet
{
    // This class contains parameters relevant to the search.
    class SearchParams
    {
    public:
        SearchParams() : _infinite(false), _moveTime(0), _depth(0)
        {
        }
        
        // Getters and setters for each type of search constraint.
        inline void Infinite(bool infinite) { _infinite = infinite; }
        inline bool Infinite() const { return _infinite; }
        
        inline void MoveTime(int32_t moveTime) { _moveTime = moveTime; }
        inline int32_t MoveTime() const { return _moveTime; }
        
        inline void Depth(int32_t depth) { _depth = depth; }
        inline int32_t Depth() const { return _depth; }
        
    public:
        bool _infinite;
        int32_t _moveTime;
        int32_t _depth;
        int32_t pickBestMove = 90;
    };
}

#endif // __SEARCH_PARAMS_H__
