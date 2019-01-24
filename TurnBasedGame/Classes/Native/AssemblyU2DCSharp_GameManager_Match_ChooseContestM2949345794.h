#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_ChooseContestM4010863725.h"

// VP`1<ReferenceData`1<GameManager.Match.ContestManagerStatePlay>>
struct VP_1_t3537971637;
// LP`1<GameManager.Match.ChooseContestManagerTeamUI/UIData>
struct LP_1_t3704776188;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseContestManagerStatePlayUI/UIData
struct  UIData_t2949345794  : public StateUI_t4010863725
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.ContestManagerStatePlay>> GameManager.Match.ChooseContestManagerStatePlayUI/UIData::contestManagerStatePlay
	VP_1_t3537971637 * ___contestManagerStatePlay_5;
	// LP`1<GameManager.Match.ChooseContestManagerTeamUI/UIData> GameManager.Match.ChooseContestManagerStatePlayUI/UIData::teams
	LP_1_t3704776188 * ___teams_6;

public:
	inline static int32_t get_offset_of_contestManagerStatePlay_5() { return static_cast<int32_t>(offsetof(UIData_t2949345794, ___contestManagerStatePlay_5)); }
	inline VP_1_t3537971637 * get_contestManagerStatePlay_5() const { return ___contestManagerStatePlay_5; }
	inline VP_1_t3537971637 ** get_address_of_contestManagerStatePlay_5() { return &___contestManagerStatePlay_5; }
	inline void set_contestManagerStatePlay_5(VP_1_t3537971637 * value)
	{
		___contestManagerStatePlay_5 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlay_5, value);
	}

	inline static int32_t get_offset_of_teams_6() { return static_cast<int32_t>(offsetof(UIData_t2949345794, ___teams_6)); }
	inline LP_1_t3704776188 * get_teams_6() const { return ___teams_6; }
	inline LP_1_t3704776188 ** get_address_of_teams_6() { return &___teams_6; }
	inline void set_teams_6(LP_1_t3704776188 * value)
	{
		___teams_6 = value;
		Il2CppCodeGenWriteBarrier(&___teams_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
