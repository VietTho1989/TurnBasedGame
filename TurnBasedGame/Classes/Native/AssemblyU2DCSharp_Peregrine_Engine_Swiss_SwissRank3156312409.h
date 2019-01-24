#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Peregrine.Engine.Round[]
struct RoundU5BU5D_t2890419345;
// Peregrine.Engine.Swiss.SwissRankingEngine
struct SwissRankingEngine_t88162131;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.Swiss.SwissRankingEngine/<GetStandings>c__AnonStorey5
struct  U3CGetStandingsU3Ec__AnonStorey5_t3156312409  : public Il2CppObject
{
public:
	// Peregrine.Engine.Round[] Peregrine.Engine.Swiss.SwissRankingEngine/<GetStandings>c__AnonStorey5::applicableRounds
	RoundU5BU5D_t2890419345* ___applicableRounds_0;
	// Peregrine.Engine.Swiss.SwissRankingEngine Peregrine.Engine.Swiss.SwissRankingEngine/<GetStandings>c__AnonStorey5::$this
	SwissRankingEngine_t88162131 * ___U24this_1;

public:
	inline static int32_t get_offset_of_applicableRounds_0() { return static_cast<int32_t>(offsetof(U3CGetStandingsU3Ec__AnonStorey5_t3156312409, ___applicableRounds_0)); }
	inline RoundU5BU5D_t2890419345* get_applicableRounds_0() const { return ___applicableRounds_0; }
	inline RoundU5BU5D_t2890419345** get_address_of_applicableRounds_0() { return &___applicableRounds_0; }
	inline void set_applicableRounds_0(RoundU5BU5D_t2890419345* value)
	{
		___applicableRounds_0 = value;
		Il2CppCodeGenWriteBarrier(&___applicableRounds_0, value);
	}

	inline static int32_t get_offset_of_U24this_1() { return static_cast<int32_t>(offsetof(U3CGetStandingsU3Ec__AnonStorey5_t3156312409, ___U24this_1)); }
	inline SwissRankingEngine_t88162131 * get_U24this_1() const { return ___U24this_1; }
	inline SwissRankingEngine_t88162131 ** get_address_of_U24this_1() { return &___U24this_1; }
	inline void set_U24this_1(SwissRankingEngine_t88162131 * value)
	{
		___U24this_1 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
