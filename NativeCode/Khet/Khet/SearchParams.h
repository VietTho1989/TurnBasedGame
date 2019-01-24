#ifndef __SEARCH_PARAMS_H__
#define __SEARCH_PARAMS_H__

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

    inline void MoveTime(int moveTime) { _moveTime = moveTime; }
    inline int MoveTime() const { return _moveTime; }

    inline void Depth(int depth) { _depth = depth; }
    inline int Depth() const { return _depth; }

public:
    bool _infinite;
    int _moveTime;
    int _depth;
};

#endif // __SEARCH_PARAMS_H__
