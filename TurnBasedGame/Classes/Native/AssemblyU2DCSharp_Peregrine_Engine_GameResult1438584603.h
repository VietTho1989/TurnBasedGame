#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Peregrine.Engine.Player
struct Player_t762644161;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.GameResult
struct  GameResult_t1438584603  : public Il2CppObject
{
public:
	// Peregrine.Engine.Player Peregrine.Engine.GameResult::Winner
	Player_t762644161 * ___Winner_0;

public:
	inline static int32_t get_offset_of_Winner_0() { return static_cast<int32_t>(offsetof(GameResult_t1438584603, ___Winner_0)); }
	inline Player_t762644161 * get_Winner_0() const { return ___Winner_0; }
	inline Player_t762644161 ** get_address_of_Winner_0() { return &___Winner_0; }
	inline void set_Winner_0(Player_t762644161 * value)
	{
		___Winner_0 = value;
		Il2CppCodeGenWriteBarrier(&___Winner_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
