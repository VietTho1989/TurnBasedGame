#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.Round>>
struct VP_1_t3178215331;
// VP`1<GameManager.Match.RoundGameUI/UIData>
struct VP_1_t522725937;
// VP`1<GameManager.Match.ChooseRoundGameUI/UIData>
struct VP_1_t1322941696;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundUI/UIData
struct  UIData_t2626213333  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Round>> GameManager.Match.RoundUI/UIData::round
	VP_1_t3178215331 * ___round_5;
	// VP`1<GameManager.Match.RoundGameUI/UIData> GameManager.Match.RoundUI/UIData::roundGameUIData
	VP_1_t522725937 * ___roundGameUIData_6;
	// VP`1<GameManager.Match.ChooseRoundGameUI/UIData> GameManager.Match.RoundUI/UIData::chooseRoundGameUIData
	VP_1_t1322941696 * ___chooseRoundGameUIData_7;

public:
	inline static int32_t get_offset_of_round_5() { return static_cast<int32_t>(offsetof(UIData_t2626213333, ___round_5)); }
	inline VP_1_t3178215331 * get_round_5() const { return ___round_5; }
	inline VP_1_t3178215331 ** get_address_of_round_5() { return &___round_5; }
	inline void set_round_5(VP_1_t3178215331 * value)
	{
		___round_5 = value;
		Il2CppCodeGenWriteBarrier(&___round_5, value);
	}

	inline static int32_t get_offset_of_roundGameUIData_6() { return static_cast<int32_t>(offsetof(UIData_t2626213333, ___roundGameUIData_6)); }
	inline VP_1_t522725937 * get_roundGameUIData_6() const { return ___roundGameUIData_6; }
	inline VP_1_t522725937 ** get_address_of_roundGameUIData_6() { return &___roundGameUIData_6; }
	inline void set_roundGameUIData_6(VP_1_t522725937 * value)
	{
		___roundGameUIData_6 = value;
		Il2CppCodeGenWriteBarrier(&___roundGameUIData_6, value);
	}

	inline static int32_t get_offset_of_chooseRoundGameUIData_7() { return static_cast<int32_t>(offsetof(UIData_t2626213333, ___chooseRoundGameUIData_7)); }
	inline VP_1_t1322941696 * get_chooseRoundGameUIData_7() const { return ___chooseRoundGameUIData_7; }
	inline VP_1_t1322941696 ** get_address_of_chooseRoundGameUIData_7() { return &___chooseRoundGameUIData_7; }
	inline void set_chooseRoundGameUIData_7(VP_1_t1322941696 * value)
	{
		___chooseRoundGameUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundGameUIData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
