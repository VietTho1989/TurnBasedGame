#ifndef __TRANSPOSITION_TABLE_H__
#define __TRANSPOSITION_TABLE_H__

#include "Types.h"
#include <unordered_map>

typedef uint64_t Key;

enum class EntryType
{
    Exact,
    Alpha,
    Beta
};

// The format of a single TT entry.
struct Entry
{
    EntryType Type;
    Move HashMove;
    int Depth;
    int Value;
    int Age;
};

class TranspositionTable
{
public:
    // Insert the specified key-value pair in the table.
    // This method decides whether the perform replacement.
    void Insert(Key key, EntryType type, Move move, int depth, int value)
    {
        auto e = _map.find(key);
        if (e != _map.end())
        {
            // Should this entry be replaced with the new one?
            if (e->second.Depth < depth)
            {
                e->second = { type, move, depth, value };
            }
        }
        else
        {
            _map.insert({ key, { type, move, depth, value } });
        }
    }

    // Lookup the specified key.
    Entry* Find(Key key)
    {
        auto e = _map.find(key);
        return e != _map.end() ? &e->second : nullptr;
    }

    // Increase the age of all existing entries and remove them if they're too old.
    void Age()
    {
        const int MaxAge = 3;
        auto e = _map.begin();
        while (e != _map.end())
        {
            e->second.Age++;
            e = e->second.Age > MaxAge
                ? _map.erase(e)
                : std::next(e);
        }
    }

    // Clear the table and free all memory.
    void Clear()
    {
        auto e = _map.begin();
        while (e != _map.end())
        {
            e = _map.erase(e);
        }
    }

private:
    struct Hash
    {
    public:
        size_t operator()(const Key& k) const
        {
            return k >> 32;
        }
    };

    std::unordered_map<Key, Entry, Hash> _map;
};

typedef TranspositionTable TT;

#endif // __TRANSPOSITION_TABLE_H__
