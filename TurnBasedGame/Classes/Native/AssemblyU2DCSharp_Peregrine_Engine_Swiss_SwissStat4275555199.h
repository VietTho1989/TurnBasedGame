#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Peregrine.Engine.Match
struct Match_t3321962803;
// Peregrine.Engine.Player
struct Player_t762644161;
// Peregrine.Engine.Swiss.SwissStatisticsProvider
struct SwissStatisticsProvider_t2323807063;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.Swiss.SwissStatisticsProvider/<GetGamePoints>c__AnonStorey5
struct  U3CGetGamePointsU3Ec__AnonStorey5_t4275555199  : public Il2CppObject
{
public:
	// Peregrine.Engine.Match Peregrine.Engine.Swiss.SwissStatisticsProvider/<GetGamePoints>c__AnonStorey5::match
	Match_t3321962803 * ___match_0;
	// Peregrine.Engine.Player Peregrine.Engine.Swiss.SwissStatisticsProvider/<GetGamePoints>c__AnonStorey5::player
	Player_t762644161 * ___player_1;
	// Peregrine.Engine.Swiss.SwissStatisticsProvider Peregrine.Engine.Swiss.SwissStatisticsProvider/<GetGamePoints>c__AnonStorey5::$this
	SwissStatisticsProvider_t2323807063 * ___U24this_2;

public:
	inline static int32_t get_offset_of_match_0() { return static_cast<int32_t>(offsetof(U3CGetGamePointsU3Ec__AnonStorey5_t4275555199, ___match_0)); }
	inline Match_t3321962803 * get_match_0() const { return ___match_0; }
	inline Match_t3321962803 ** get_address_of_match_0() { return &___match_0; }
	inline void set_match_0(Match_t3321962803 * value)
	{
		___match_0 = value;
		Il2CppCodeGenWriteBarrier(&___match_0, value);
	}

	inline static int32_t get_offset_of_player_1() { return static_cast<int32_t>(offsetof(U3CGetGamePointsU3Ec__AnonStorey5_t4275555199, ___player_1)); }
	inline Player_t762644161 * get_player_1() const { return ___player_1; }
	inline Player_t762644161 ** get_address_of_player_1() { return &___player_1; }
	inline void set_player_1(Player_t762644161 * value)
	{
		___player_1 = value;
		Il2CppCodeGenWriteBarrier(&___player_1, value);
	}

	inline static int32_t get_offset_of_U24this_2() { return static_cast<int32_t>(offsetof(U3CGetGamePointsU3Ec__AnonStorey5_t4275555199, ___U24this_2)); }
	inline SwissStatisticsProvider_t2323807063 * get_U24this_2() const { return ___U24this_2; }
	inline SwissStatisticsProvider_t2323807063 ** get_address_of_U24this_2() { return &___U24this_2; }
	inline void set_U24this_2(SwissStatisticsProvider_t2323807063 * value)
	{
		___U24this_2 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
