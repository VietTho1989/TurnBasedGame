#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Random
struct Random_t1044426839;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shuffle
struct  Shuffle_t1667398797  : public Il2CppObject
{
public:

public:
};

struct Shuffle_t1667398797_StaticFields
{
public:
	// System.Random Shuffle::rnd
	Random_t1044426839 * ___rnd_0;

public:
	inline static int32_t get_offset_of_rnd_0() { return static_cast<int32_t>(offsetof(Shuffle_t1667398797_StaticFields, ___rnd_0)); }
	inline Random_t1044426839 * get_rnd_0() const { return ___rnd_0; }
	inline Random_t1044426839 ** get_address_of_rnd_0() { return &___rnd_0; }
	inline void set_rnd_0(Random_t1044426839 * value)
	{
		___rnd_0 = value;
		Il2CppCodeGenWriteBarrier(&___rnd_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
