#ifndef __MOVE_HELPERS_H__
#define __MOVE_HELPERS_H__

#include "Globals.h"
#include <string>
#include <cassert>

inline std::string LocationToString(int loc)
{
    const std::string Files = "XabcdefghijX";
    return Files[loc % BoardWidth] + std::to_string(loc / BoardWidth);
}

inline int StringToLocation(char file, char rank)
{
    return (rank - 48)*BoardWidth + (file - 96);
}

// The format for a Move (in bits) is:
// B1: Reserved.
// B2-B8: Start.
// B9-B15: End.
// B16-B19: Rotation (can be: 01 or 11 and 10 indicates no rotation).

inline Move MakeMove(int start, int end, int rotation)
{
    return start << 1 | end << 8 | (rotation + 2) << 15;
}

inline Move MakeMove(const std::string& s)
{
    assert(s.size() >= 3);
    int start = StringToLocation(s[0], s[1]);
    int end = s.size() == 3 ? start : StringToLocation(s[2], s[3]);
    int rotation = 0;
    if (start == end)
        rotation = s[2] == '+' ? 1 : -1;

    return MakeMove(start, end, rotation);
}

inline int GetStart(Move m)
{
    return m >> 1 & 0x7F;
}

inline int GetEnd(Move m)
{
    return m >> 8 & 0x7F;
}

inline int GetRotation(Move m)
{
    return (m >> 15 & 0x3) - 2;
}

inline std::string ToString(Move m)
{
    int start = GetStart(m);
    int end = GetEnd(m);
    int rotation = GetRotation(m);
    std::string s = LocationToString(start);
    s += start != end ? LocationToString(end) : (rotation > 0 ? "+" : "-");
    return s;
}

#endif // __MOVE_HELPERS_H__
