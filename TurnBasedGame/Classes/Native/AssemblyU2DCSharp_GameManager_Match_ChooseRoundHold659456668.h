#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1196055060.h"

// VP`1<ReferenceData`1<GameManager.Match.Round>>
struct VP_1_t3178215331;
// VP`1<GameManager.Match.RoundState/UIData>
struct VP_1_t2218616654;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseRoundHolder/UIData
struct  UIData_t659456668  : public BaseItemViewsHolder_t1196055060
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Round>> GameManager.Match.ChooseRoundHolder/UIData::round
	VP_1_t3178215331 * ___round_8;
	// VP`1<GameManager.Match.RoundState/UIData> GameManager.Match.ChooseRoundHolder/UIData::roundStateUIData
	VP_1_t2218616654 * ___roundStateUIData_9;

public:
	inline static int32_t get_offset_of_round_8() { return static_cast<int32_t>(offsetof(UIData_t659456668, ___round_8)); }
	inline VP_1_t3178215331 * get_round_8() const { return ___round_8; }
	inline VP_1_t3178215331 ** get_address_of_round_8() { return &___round_8; }
	inline void set_round_8(VP_1_t3178215331 * value)
	{
		___round_8 = value;
		Il2CppCodeGenWriteBarrier(&___round_8, value);
	}

	inline static int32_t get_offset_of_roundStateUIData_9() { return static_cast<int32_t>(offsetof(UIData_t659456668, ___roundStateUIData_9)); }
	inline VP_1_t2218616654 * get_roundStateUIData_9() const { return ___roundStateUIData_9; }
	inline VP_1_t2218616654 ** get_address_of_roundStateUIData_9() { return &___roundStateUIData_9; }
	inline void set_roundStateUIData_9(VP_1_t2218616654 * value)
	{
		___roundStateUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___roundStateUIData_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
