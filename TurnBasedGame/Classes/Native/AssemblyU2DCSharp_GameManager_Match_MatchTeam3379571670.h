#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<GameManager.Match.TeamState>
struct VP_1_t2860138382;
// LP`1<GameManager.Match.TeamPlayer>
struct LP_1_t2947583386;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.MatchTeam
struct  MatchTeam_t3379571670  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GameManager.Match.MatchTeam::teamIndex
	VP_1_t2450154454 * ___teamIndex_5;
	// VP`1<GameManager.Match.TeamState> GameManager.Match.MatchTeam::state
	VP_1_t2860138382 * ___state_6;
	// LP`1<GameManager.Match.TeamPlayer> GameManager.Match.MatchTeam::players
	LP_1_t2947583386 * ___players_7;

public:
	inline static int32_t get_offset_of_teamIndex_5() { return static_cast<int32_t>(offsetof(MatchTeam_t3379571670, ___teamIndex_5)); }
	inline VP_1_t2450154454 * get_teamIndex_5() const { return ___teamIndex_5; }
	inline VP_1_t2450154454 ** get_address_of_teamIndex_5() { return &___teamIndex_5; }
	inline void set_teamIndex_5(VP_1_t2450154454 * value)
	{
		___teamIndex_5 = value;
		Il2CppCodeGenWriteBarrier(&___teamIndex_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(MatchTeam_t3379571670, ___state_6)); }
	inline VP_1_t2860138382 * get_state_6() const { return ___state_6; }
	inline VP_1_t2860138382 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t2860138382 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}

	inline static int32_t get_offset_of_players_7() { return static_cast<int32_t>(offsetof(MatchTeam_t3379571670, ___players_7)); }
	inline LP_1_t2947583386 * get_players_7() const { return ___players_7; }
	inline LP_1_t2947583386 ** get_address_of_players_7() { return &___players_7; }
	inline void set_players_7(LP_1_t2947583386 * value)
	{
		___players_7 = value;
		Il2CppCodeGenWriteBarrier(&___players_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
