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

// Peregrine.Engine.MatchResult
struct  MatchResult_t2215015348  : public Il2CppObject
{
public:
	// System.Int32 Peregrine.Engine.MatchResult::RoundNumber
	int32_t ___RoundNumber_0;
	// System.Int32 Peregrine.Engine.MatchResult::MatchNumber
	int32_t ___MatchNumber_1;
	// Peregrine.Engine.Player Peregrine.Engine.MatchResult::Winner
	Player_t762644161 * ___Winner_2;

public:
	inline static int32_t get_offset_of_RoundNumber_0() { return static_cast<int32_t>(offsetof(MatchResult_t2215015348, ___RoundNumber_0)); }
	inline int32_t get_RoundNumber_0() const { return ___RoundNumber_0; }
	inline int32_t* get_address_of_RoundNumber_0() { return &___RoundNumber_0; }
	inline void set_RoundNumber_0(int32_t value)
	{
		___RoundNumber_0 = value;
	}

	inline static int32_t get_offset_of_MatchNumber_1() { return static_cast<int32_t>(offsetof(MatchResult_t2215015348, ___MatchNumber_1)); }
	inline int32_t get_MatchNumber_1() const { return ___MatchNumber_1; }
	inline int32_t* get_address_of_MatchNumber_1() { return &___MatchNumber_1; }
	inline void set_MatchNumber_1(int32_t value)
	{
		___MatchNumber_1 = value;
	}

	inline static int32_t get_offset_of_Winner_2() { return static_cast<int32_t>(offsetof(MatchResult_t2215015348, ___Winner_2)); }
	inline Player_t762644161 * get_Winner_2() const { return ___Winner_2; }
	inline Player_t762644161 ** get_address_of_Winner_2() { return &___Winner_2; }
	inline void set_Winner_2(Player_t762644161 * value)
	{
		___Winner_2 = value;
		Il2CppCodeGenWriteBarrier(&___Winner_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
