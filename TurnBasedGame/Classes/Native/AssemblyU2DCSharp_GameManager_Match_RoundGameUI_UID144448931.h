#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.RoundGame>>
struct VP_1_t2479123941;
// VP`1<GameUI/UIData>
struct VP_1_t4256190837;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundGameUI/UIData
struct  UIData_t144448931  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.RoundGame>> GameManager.Match.RoundGameUI/UIData::roundGame
	VP_1_t2479123941 * ___roundGame_5;
	// VP`1<GameUI/UIData> GameManager.Match.RoundGameUI/UIData::gameUIData
	VP_1_t4256190837 * ___gameUIData_6;

public:
	inline static int32_t get_offset_of_roundGame_5() { return static_cast<int32_t>(offsetof(UIData_t144448931, ___roundGame_5)); }
	inline VP_1_t2479123941 * get_roundGame_5() const { return ___roundGame_5; }
	inline VP_1_t2479123941 ** get_address_of_roundGame_5() { return &___roundGame_5; }
	inline void set_roundGame_5(VP_1_t2479123941 * value)
	{
		___roundGame_5 = value;
		Il2CppCodeGenWriteBarrier(&___roundGame_5, value);
	}

	inline static int32_t get_offset_of_gameUIData_6() { return static_cast<int32_t>(offsetof(UIData_t144448931, ___gameUIData_6)); }
	inline VP_1_t4256190837 * get_gameUIData_6() const { return ___gameUIData_6; }
	inline VP_1_t4256190837 ** get_address_of_gameUIData_6() { return &___gameUIData_6; }
	inline void set_gameUIData_6(VP_1_t4256190837 * value)
	{
		___gameUIData_6 = value;
		Il2CppCodeGenWriteBarrier(&___gameUIData_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
