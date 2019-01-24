#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1196055060.h"

// VP`1<ReferenceData`1<GameManager.Match.MatchTeam>>
struct VP_1_t2828631739;
// LP`1<GameManager.Match.Swap.SwapPlayerUI/UIData>
struct LP_1_t3649707066;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapTeamHolder/UIData
struct  UIData_t824412534  : public BaseItemViewsHolder_t1196055060
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.MatchTeam>> GameManager.Match.Swap.SwapTeamHolder/UIData::matchTeam
	VP_1_t2828631739 * ___matchTeam_8;
	// LP`1<GameManager.Match.Swap.SwapPlayerUI/UIData> GameManager.Match.Swap.SwapTeamHolder/UIData::players
	LP_1_t3649707066 * ___players_9;

public:
	inline static int32_t get_offset_of_matchTeam_8() { return static_cast<int32_t>(offsetof(UIData_t824412534, ___matchTeam_8)); }
	inline VP_1_t2828631739 * get_matchTeam_8() const { return ___matchTeam_8; }
	inline VP_1_t2828631739 ** get_address_of_matchTeam_8() { return &___matchTeam_8; }
	inline void set_matchTeam_8(VP_1_t2828631739 * value)
	{
		___matchTeam_8 = value;
		Il2CppCodeGenWriteBarrier(&___matchTeam_8, value);
	}

	inline static int32_t get_offset_of_players_9() { return static_cast<int32_t>(offsetof(UIData_t824412534, ___players_9)); }
	inline LP_1_t3649707066 * get_players_9() const { return ___players_9; }
	inline LP_1_t3649707066 ** get_address_of_players_9() { return &___players_9; }
	inline void set_players_9(LP_1_t3649707066 * value)
	{
		___players_9 = value;
		Il2CppCodeGenWriteBarrier(&___players_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
