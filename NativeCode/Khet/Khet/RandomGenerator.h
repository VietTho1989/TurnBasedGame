#ifndef __RANDOM_GENERATOR_H__
#define __RANDOM_GENERATOR_H__

#include <cassert>

// Pseudo-random number generator which uses the xorshift* algorithm.
// Only requires 8 bytes of storage and is extremely fast.
class RandomGenerator
{
public:
    // Seed the generator.
    RandomGenerator(uint64_t seed) : _s(seed) 
    {
        assert(_s != 0);
    }

    // Generate the next pseudo-random number.
    uint64_t Next()
    {
        _s ^= _s >> 12; _s ^= _s << 25; _s ^= _s >> 27;
        return _s * 0x2545F4914F6CDD1DLL;
    }
    
private:
    uint64_t _s;
};

#endif // __RANDOM_GENERATOR_H__

