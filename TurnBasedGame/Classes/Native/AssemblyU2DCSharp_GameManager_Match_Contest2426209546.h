#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<GameManager.Match.ContestState>
struct VP_1_t2201853071;
// VP`1<CalculateScore>
struct VP_1_t3414263936;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<GameManager.Match.MatchTeam>
struct LP_1_t2117315626;
// VP`1<GameManager.Match.RoundFactory>
struct VP_1_t2213350254;
// LP`1<GameManager.Match.Round>
struct LP_1_t2466899218;
// VP`1<GameManager.Match.RequestNewRound>
struct VP_1_t1911247275;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Contest
struct  Contest_t2426209546  : public Data_t3569509720
{
public:
	// VP`1<GameManager.Match.ContestState> GameManager.Match.Contest::state
	VP_1_t2201853071 * ___state_5;
	// VP`1<CalculateScore> GameManager.Match.Contest::calculateScore
	VP_1_t3414263936 * ___calculateScore_6;
	// VP`1<System.Int32> GameManager.Match.Contest::playerPerTeam
	VP_1_t2450154454 * ___playerPerTeam_7;
	// LP`1<GameManager.Match.MatchTeam> GameManager.Match.Contest::teams
	LP_1_t2117315626 * ___teams_8;
	// VP`1<GameManager.Match.RoundFactory> GameManager.Match.Contest::roundFactory
	VP_1_t2213350254 * ___roundFactory_9;
	// LP`1<GameManager.Match.Round> GameManager.Match.Contest::rounds
	LP_1_t2466899218 * ___rounds_10;
	// VP`1<GameManager.Match.RequestNewRound> GameManager.Match.Contest::requestNewRound
	VP_1_t1911247275 * ___requestNewRound_11;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(Contest_t2426209546, ___state_5)); }
	inline VP_1_t2201853071 * get_state_5() const { return ___state_5; }
	inline VP_1_t2201853071 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t2201853071 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_calculateScore_6() { return static_cast<int32_t>(offsetof(Contest_t2426209546, ___calculateScore_6)); }
	inline VP_1_t3414263936 * get_calculateScore_6() const { return ___calculateScore_6; }
	inline VP_1_t3414263936 ** get_address_of_calculateScore_6() { return &___calculateScore_6; }
	inline void set_calculateScore_6(VP_1_t3414263936 * value)
	{
		___calculateScore_6 = value;
		Il2CppCodeGenWriteBarrier(&___calculateScore_6, value);
	}

	inline static int32_t get_offset_of_playerPerTeam_7() { return static_cast<int32_t>(offsetof(Contest_t2426209546, ___playerPerTeam_7)); }
	inline VP_1_t2450154454 * get_playerPerTeam_7() const { return ___playerPerTeam_7; }
	inline VP_1_t2450154454 ** get_address_of_playerPerTeam_7() { return &___playerPerTeam_7; }
	inline void set_playerPerTeam_7(VP_1_t2450154454 * value)
	{
		___playerPerTeam_7 = value;
		Il2CppCodeGenWriteBarrier(&___playerPerTeam_7, value);
	}

	inline static int32_t get_offset_of_teams_8() { return static_cast<int32_t>(offsetof(Contest_t2426209546, ___teams_8)); }
	inline LP_1_t2117315626 * get_teams_8() const { return ___teams_8; }
	inline LP_1_t2117315626 ** get_address_of_teams_8() { return &___teams_8; }
	inline void set_teams_8(LP_1_t2117315626 * value)
	{
		___teams_8 = value;
		Il2CppCodeGenWriteBarrier(&___teams_8, value);
	}

	inline static int32_t get_offset_of_roundFactory_9() { return static_cast<int32_t>(offsetof(Contest_t2426209546, ___roundFactory_9)); }
	inline VP_1_t2213350254 * get_roundFactory_9() const { return ___roundFactory_9; }
	inline VP_1_t2213350254 ** get_address_of_roundFactory_9() { return &___roundFactory_9; }
	inline void set_roundFactory_9(VP_1_t2213350254 * value)
	{
		___roundFactory_9 = value;
		Il2CppCodeGenWriteBarrier(&___roundFactory_9, value);
	}

	inline static int32_t get_offset_of_rounds_10() { return static_cast<int32_t>(offsetof(Contest_t2426209546, ___rounds_10)); }
	inline LP_1_t2466899218 * get_rounds_10() const { return ___rounds_10; }
	inline LP_1_t2466899218 ** get_address_of_rounds_10() { return &___rounds_10; }
	inline void set_rounds_10(LP_1_t2466899218 * value)
	{
		___rounds_10 = value;
		Il2CppCodeGenWriteBarrier(&___rounds_10, value);
	}

	inline static int32_t get_offset_of_requestNewRound_11() { return static_cast<int32_t>(offsetof(Contest_t2426209546, ___requestNewRound_11)); }
	inline VP_1_t1911247275 * get_requestNewRound_11() const { return ___requestNewRound_11; }
	inline VP_1_t1911247275 ** get_address_of_requestNewRound_11() { return &___requestNewRound_11; }
	inline void set_requestNewRound_11(VP_1_t1911247275 * value)
	{
		___requestNewRound_11 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRound_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
