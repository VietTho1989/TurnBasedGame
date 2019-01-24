#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<GameManager.Match.RoundState>
struct VP_1_t3696504665;
// VP`1<CalculateScore>
struct VP_1_t3414263936;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<GameManager.Match.RoundGame>
struct LP_1_t1767807828;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Round
struct  Round_t3729155262  : public Data_t3569509720
{
public:
	// VP`1<GameManager.Match.RoundState> GameManager.Match.Round::state
	VP_1_t3696504665 * ___state_5;
	// VP`1<CalculateScore> GameManager.Match.Round::calculateScore
	VP_1_t3414263936 * ___calculateScore_6;
	// VP`1<System.Int32> GameManager.Match.Round::index
	VP_1_t2450154454 * ___index_7;
	// LP`1<GameManager.Match.RoundGame> GameManager.Match.Round::roundGames
	LP_1_t1767807828 * ___roundGames_8;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(Round_t3729155262, ___state_5)); }
	inline VP_1_t3696504665 * get_state_5() const { return ___state_5; }
	inline VP_1_t3696504665 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t3696504665 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_calculateScore_6() { return static_cast<int32_t>(offsetof(Round_t3729155262, ___calculateScore_6)); }
	inline VP_1_t3414263936 * get_calculateScore_6() const { return ___calculateScore_6; }
	inline VP_1_t3414263936 ** get_address_of_calculateScore_6() { return &___calculateScore_6; }
	inline void set_calculateScore_6(VP_1_t3414263936 * value)
	{
		___calculateScore_6 = value;
		Il2CppCodeGenWriteBarrier(&___calculateScore_6, value);
	}

	inline static int32_t get_offset_of_index_7() { return static_cast<int32_t>(offsetof(Round_t3729155262, ___index_7)); }
	inline VP_1_t2450154454 * get_index_7() const { return ___index_7; }
	inline VP_1_t2450154454 ** get_address_of_index_7() { return &___index_7; }
	inline void set_index_7(VP_1_t2450154454 * value)
	{
		___index_7 = value;
		Il2CppCodeGenWriteBarrier(&___index_7, value);
	}

	inline static int32_t get_offset_of_roundGames_8() { return static_cast<int32_t>(offsetof(Round_t3729155262, ___roundGames_8)); }
	inline LP_1_t1767807828 * get_roundGames_8() const { return ___roundGames_8; }
	inline LP_1_t1767807828 ** get_address_of_roundGames_8() { return &___roundGames_8; }
	inline void set_roundGames_8(LP_1_t1767807828 * value)
	{
		___roundGames_8 = value;
		Il2CppCodeGenWriteBarrier(&___roundGames_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
