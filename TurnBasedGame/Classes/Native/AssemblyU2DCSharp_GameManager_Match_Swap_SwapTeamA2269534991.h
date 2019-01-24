#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.ContestManagerStatePlay>>
struct VP_1_t3537971637;
// LP`1<GameManager.Match.Swap.SwapTeamHolder/UIData>
struct LP_1_t3857123786;
// System.Collections.Generic.List`1<GameManager.Match.MatchTeam>
struct List_1_t2748692802;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapTeamAdapter/UIData
struct  UIData_t2269534991  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.ContestManagerStatePlay>> GameManager.Match.Swap.SwapTeamAdapter/UIData::contestManagerStatePlay
	VP_1_t3537971637 * ___contestManagerStatePlay_20;
	// LP`1<GameManager.Match.Swap.SwapTeamHolder/UIData> GameManager.Match.Swap.SwapTeamAdapter/UIData::holders
	LP_1_t3857123786 * ___holders_21;
	// System.Collections.Generic.List`1<GameManager.Match.MatchTeam> GameManager.Match.Swap.SwapTeamAdapter/UIData::matchTeams
	List_1_t2748692802 * ___matchTeams_22;

public:
	inline static int32_t get_offset_of_contestManagerStatePlay_20() { return static_cast<int32_t>(offsetof(UIData_t2269534991, ___contestManagerStatePlay_20)); }
	inline VP_1_t3537971637 * get_contestManagerStatePlay_20() const { return ___contestManagerStatePlay_20; }
	inline VP_1_t3537971637 ** get_address_of_contestManagerStatePlay_20() { return &___contestManagerStatePlay_20; }
	inline void set_contestManagerStatePlay_20(VP_1_t3537971637 * value)
	{
		___contestManagerStatePlay_20 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlay_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t2269534991, ___holders_21)); }
	inline LP_1_t3857123786 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t3857123786 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t3857123786 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_matchTeams_22() { return static_cast<int32_t>(offsetof(UIData_t2269534991, ___matchTeams_22)); }
	inline List_1_t2748692802 * get_matchTeams_22() const { return ___matchTeams_22; }
	inline List_1_t2748692802 ** get_address_of_matchTeams_22() { return &___matchTeams_22; }
	inline void set_matchTeams_22(List_1_t2748692802 * value)
	{
		___matchTeams_22 = value;
		Il2CppCodeGenWriteBarrier(&___matchTeams_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
