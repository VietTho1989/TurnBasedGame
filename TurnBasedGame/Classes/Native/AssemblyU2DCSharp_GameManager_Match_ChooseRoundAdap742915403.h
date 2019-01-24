#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.Contest>>
struct VP_1_t1875269615;
// LP`1<GameManager.Match.ChooseRoundHolder/UIData>
struct LP_1_t3692167920;
// System.Collections.Generic.List`1<GameManager.Match.Round>
struct List_1_t3098276394;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseRoundAdapter/UIData
struct  UIData_t742915403  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Contest>> GameManager.Match.ChooseRoundAdapter/UIData::contest
	VP_1_t1875269615 * ___contest_20;
	// LP`1<GameManager.Match.ChooseRoundHolder/UIData> GameManager.Match.ChooseRoundAdapter/UIData::holders
	LP_1_t3692167920 * ___holders_21;
	// System.Collections.Generic.List`1<GameManager.Match.Round> GameManager.Match.ChooseRoundAdapter/UIData::rounds
	List_1_t3098276394 * ___rounds_22;

public:
	inline static int32_t get_offset_of_contest_20() { return static_cast<int32_t>(offsetof(UIData_t742915403, ___contest_20)); }
	inline VP_1_t1875269615 * get_contest_20() const { return ___contest_20; }
	inline VP_1_t1875269615 ** get_address_of_contest_20() { return &___contest_20; }
	inline void set_contest_20(VP_1_t1875269615 * value)
	{
		___contest_20 = value;
		Il2CppCodeGenWriteBarrier(&___contest_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t742915403, ___holders_21)); }
	inline LP_1_t3692167920 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t3692167920 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t3692167920 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_rounds_22() { return static_cast<int32_t>(offsetof(UIData_t742915403, ___rounds_22)); }
	inline List_1_t3098276394 * get_rounds_22() const { return ___rounds_22; }
	inline List_1_t3098276394 ** get_address_of_rounds_22() { return &___rounds_22; }
	inline void set_rounds_22(List_1_t3098276394 * value)
	{
		___rounds_22 = value;
		Il2CppCodeGenWriteBarrier(&___rounds_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
