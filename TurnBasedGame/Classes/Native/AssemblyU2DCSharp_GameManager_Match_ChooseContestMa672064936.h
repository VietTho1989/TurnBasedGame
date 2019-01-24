#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.MatchTeam>>
struct VP_1_t2828631739;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseContestManagerTeamUI/UIData
struct  UIData_t672064936  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.MatchTeam>> GameManager.Match.ChooseContestManagerTeamUI/UIData::matchTeam
	VP_1_t2828631739 * ___matchTeam_5;

public:
	inline static int32_t get_offset_of_matchTeam_5() { return static_cast<int32_t>(offsetof(UIData_t672064936, ___matchTeam_5)); }
	inline VP_1_t2828631739 * get_matchTeam_5() const { return ___matchTeam_5; }
	inline VP_1_t2828631739 ** get_address_of_matchTeam_5() { return &___matchTeam_5; }
	inline void set_matchTeam_5(VP_1_t2828631739 * value)
	{
		___matchTeam_5 = value;
		Il2CppCodeGenWriteBarrier(&___matchTeam_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
