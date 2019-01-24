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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.Swiss.SwissStatisticsProvider/<GetPlayerOpponents>c__AnonStorey8
struct  U3CGetPlayerOpponentsU3Ec__AnonStorey8_t1319160298  : public Il2CppObject
{
public:
	// Peregrine.Engine.Match Peregrine.Engine.Swiss.SwissStatisticsProvider/<GetPlayerOpponents>c__AnonStorey8::match
	Match_t3321962803 * ___match_0;
	// Peregrine.Engine.Player Peregrine.Engine.Swiss.SwissStatisticsProvider/<GetPlayerOpponents>c__AnonStorey8::player
	Player_t762644161 * ___player_1;

public:
	inline static int32_t get_offset_of_match_0() { return static_cast<int32_t>(offsetof(U3CGetPlayerOpponentsU3Ec__AnonStorey8_t1319160298, ___match_0)); }
	inline Match_t3321962803 * get_match_0() const { return ___match_0; }
	inline Match_t3321962803 ** get_address_of_match_0() { return &___match_0; }
	inline void set_match_0(Match_t3321962803 * value)
	{
		___match_0 = value;
		Il2CppCodeGenWriteBarrier(&___match_0, value);
	}

	inline static int32_t get_offset_of_player_1() { return static_cast<int32_t>(offsetof(U3CGetPlayerOpponentsU3Ec__AnonStorey8_t1319160298, ___player_1)); }
	inline Player_t762644161 * get_player_1() const { return ___player_1; }
	inline Player_t762644161 ** get_address_of_player_1() { return &___player_1; }
	inline void set_player_1(Player_t762644161 * value)
	{
		___player_1 = value;
		Il2CppCodeGenWriteBarrier(&___player_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
