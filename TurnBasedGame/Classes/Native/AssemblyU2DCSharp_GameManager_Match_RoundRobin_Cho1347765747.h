#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.RoundRobin.RoundRobinContent>>
struct VP_1_t1814477276;
// LP`1<GameManager.Match.RoundRobin.ChooseRoundRobinHolder/UIData>
struct LP_1_t2745337524;
// System.Collections.Generic.List`1<GameManager.Match.RoundRobin.RoundRobin>
struct List_1_t3260142850;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.ChooseRoundRobinAdapter/UIData
struct  UIData_t1347765747  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.RoundRobin.RoundRobinContent>> GameManager.Match.RoundRobin.ChooseRoundRobinAdapter/UIData::roundRobinContent
	VP_1_t1814477276 * ___roundRobinContent_20;
	// LP`1<GameManager.Match.RoundRobin.ChooseRoundRobinHolder/UIData> GameManager.Match.RoundRobin.ChooseRoundRobinAdapter/UIData::holders
	LP_1_t2745337524 * ___holders_21;
	// System.Collections.Generic.List`1<GameManager.Match.RoundRobin.RoundRobin> GameManager.Match.RoundRobin.ChooseRoundRobinAdapter/UIData::roundRobins
	List_1_t3260142850 * ___roundRobins_22;

public:
	inline static int32_t get_offset_of_roundRobinContent_20() { return static_cast<int32_t>(offsetof(UIData_t1347765747, ___roundRobinContent_20)); }
	inline VP_1_t1814477276 * get_roundRobinContent_20() const { return ___roundRobinContent_20; }
	inline VP_1_t1814477276 ** get_address_of_roundRobinContent_20() { return &___roundRobinContent_20; }
	inline void set_roundRobinContent_20(VP_1_t1814477276 * value)
	{
		___roundRobinContent_20 = value;
		Il2CppCodeGenWriteBarrier(&___roundRobinContent_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t1347765747, ___holders_21)); }
	inline LP_1_t2745337524 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t2745337524 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t2745337524 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_roundRobins_22() { return static_cast<int32_t>(offsetof(UIData_t1347765747, ___roundRobins_22)); }
	inline List_1_t3260142850 * get_roundRobins_22() const { return ___roundRobins_22; }
	inline List_1_t3260142850 ** get_address_of_roundRobins_22() { return &___roundRobins_22; }
	inline void set_roundRobins_22(List_1_t3260142850 * value)
	{
		___roundRobins_22 = value;
		Il2CppCodeGenWriteBarrier(&___roundRobins_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
