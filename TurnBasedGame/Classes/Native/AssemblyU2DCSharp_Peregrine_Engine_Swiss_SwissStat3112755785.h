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
// Peregrine.Engine.Swiss.SwissStatisticsProvider
struct SwissStatisticsProvider_t2323807063;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.Swiss.SwissStatisticsProvider/<GetGamePoints>c__AnonStorey3
struct  U3CGetGamePointsU3Ec__AnonStorey3_t3112755785  : public Il2CppObject
{
public:
	// Peregrine.Engine.Player Peregrine.Engine.Swiss.SwissStatisticsProvider/<GetGamePoints>c__AnonStorey3::player
	Player_t762644161 * ___player_0;
	// Peregrine.Engine.Swiss.SwissStatisticsProvider Peregrine.Engine.Swiss.SwissStatisticsProvider/<GetGamePoints>c__AnonStorey3::$this
	SwissStatisticsProvider_t2323807063 * ___U24this_1;

public:
	inline static int32_t get_offset_of_player_0() { return static_cast<int32_t>(offsetof(U3CGetGamePointsU3Ec__AnonStorey3_t3112755785, ___player_0)); }
	inline Player_t762644161 * get_player_0() const { return ___player_0; }
	inline Player_t762644161 ** get_address_of_player_0() { return &___player_0; }
	inline void set_player_0(Player_t762644161 * value)
	{
		___player_0 = value;
		Il2CppCodeGenWriteBarrier(&___player_0, value);
	}

	inline static int32_t get_offset_of_U24this_1() { return static_cast<int32_t>(offsetof(U3CGetGamePointsU3Ec__AnonStorey3_t3112755785, ___U24this_1)); }
	inline SwissStatisticsProvider_t2323807063 * get_U24this_1() const { return ___U24this_1; }
	inline SwissStatisticsProvider_t2323807063 ** get_address_of_U24this_1() { return &___U24this_1; }
	inline void set_U24this_1(SwissStatisticsProvider_t2323807063 * value)
	{
		___U24this_1 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
