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

// Peregrine.Engine.Swiss.SwissStatisticsProvider/<GetMatchPointsPerRound>c__AnonStorey2
struct  U3CGetMatchPointsPerRoundU3Ec__AnonStorey2_t1712460074  : public Il2CppObject
{
public:
	// Peregrine.Engine.Player Peregrine.Engine.Swiss.SwissStatisticsProvider/<GetMatchPointsPerRound>c__AnonStorey2::player
	Player_t762644161 * ___player_0;

public:
	inline static int32_t get_offset_of_player_0() { return static_cast<int32_t>(offsetof(U3CGetMatchPointsPerRoundU3Ec__AnonStorey2_t1712460074, ___player_0)); }
	inline Player_t762644161 * get_player_0() const { return ___player_0; }
	inline Player_t762644161 ** get_address_of_player_0() { return &___player_0; }
	inline void set_player_0(Player_t762644161 * value)
	{
		___player_0 = value;
		Il2CppCodeGenWriteBarrier(&___player_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
