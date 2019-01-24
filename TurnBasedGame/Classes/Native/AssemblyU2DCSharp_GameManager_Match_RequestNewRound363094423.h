#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_SingleContestF4223989085.h"

// VP`1<EditData`1<GameManager.Match.RequestNewRoundHaveLimit>>
struct VP_1_t1293045032;
// VP`1<RequestChangeIntUI/UIData>
struct VP_1_t1437137211;
// VP`1<RequestChangeBoolUI/UIData>
struct VP_1_t3802102788;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRoundHaveLimitUI/UIData
struct  UIData_t363094423  : public NewRoundLimitUI_t4223989085
{
public:
	// VP`1<EditData`1<GameManager.Match.RequestNewRoundHaveLimit>> GameManager.Match.RequestNewRoundHaveLimitUI/UIData::editHaveLimit
	VP_1_t1293045032 * ___editHaveLimit_5;
	// VP`1<RequestChangeIntUI/UIData> GameManager.Match.RequestNewRoundHaveLimitUI/UIData::maxRound
	VP_1_t1437137211 * ___maxRound_6;
	// VP`1<RequestChangeBoolUI/UIData> GameManager.Match.RequestNewRoundHaveLimitUI/UIData::enoughScoreStop
	VP_1_t3802102788 * ___enoughScoreStop_7;

public:
	inline static int32_t get_offset_of_editHaveLimit_5() { return static_cast<int32_t>(offsetof(UIData_t363094423, ___editHaveLimit_5)); }
	inline VP_1_t1293045032 * get_editHaveLimit_5() const { return ___editHaveLimit_5; }
	inline VP_1_t1293045032 ** get_address_of_editHaveLimit_5() { return &___editHaveLimit_5; }
	inline void set_editHaveLimit_5(VP_1_t1293045032 * value)
	{
		___editHaveLimit_5 = value;
		Il2CppCodeGenWriteBarrier(&___editHaveLimit_5, value);
	}

	inline static int32_t get_offset_of_maxRound_6() { return static_cast<int32_t>(offsetof(UIData_t363094423, ___maxRound_6)); }
	inline VP_1_t1437137211 * get_maxRound_6() const { return ___maxRound_6; }
	inline VP_1_t1437137211 ** get_address_of_maxRound_6() { return &___maxRound_6; }
	inline void set_maxRound_6(VP_1_t1437137211 * value)
	{
		___maxRound_6 = value;
		Il2CppCodeGenWriteBarrier(&___maxRound_6, value);
	}

	inline static int32_t get_offset_of_enoughScoreStop_7() { return static_cast<int32_t>(offsetof(UIData_t363094423, ___enoughScoreStop_7)); }
	inline VP_1_t3802102788 * get_enoughScoreStop_7() const { return ___enoughScoreStop_7; }
	inline VP_1_t3802102788 ** get_address_of_enoughScoreStop_7() { return &___enoughScoreStop_7; }
	inline void set_enoughScoreStop_7(VP_1_t3802102788 * value)
	{
		___enoughScoreStop_7 = value;
		Il2CppCodeGenWriteBarrier(&___enoughScoreStop_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
