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
// VP`1<GameManager.Match.ChooseRoundGameAdapter/UIData>
struct VP_1_t1754838683;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseRoundGameUI/UIData
struct  UIData_t944664690  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Round>> GameManager.Match.ChooseRoundGameUI/UIData::round
	VP_1_t3178215331 * ___round_5;
	// VP`1<GameManager.Match.ChooseRoundGameAdapter/UIData> GameManager.Match.ChooseRoundGameUI/UIData::chooseRoundGameAdapter
	VP_1_t1754838683 * ___chooseRoundGameAdapter_6;

public:
	inline static int32_t get_offset_of_round_5() { return static_cast<int32_t>(offsetof(UIData_t944664690, ___round_5)); }
	inline VP_1_t3178215331 * get_round_5() const { return ___round_5; }
	inline VP_1_t3178215331 ** get_address_of_round_5() { return &___round_5; }
	inline void set_round_5(VP_1_t3178215331 * value)
	{
		___round_5 = value;
		Il2CppCodeGenWriteBarrier(&___round_5, value);
	}

	inline static int32_t get_offset_of_chooseRoundGameAdapter_6() { return static_cast<int32_t>(offsetof(UIData_t944664690, ___chooseRoundGameAdapter_6)); }
	inline VP_1_t1754838683 * get_chooseRoundGameAdapter_6() const { return ___chooseRoundGameAdapter_6; }
	inline VP_1_t1754838683 ** get_address_of_chooseRoundGameAdapter_6() { return &___chooseRoundGameAdapter_6; }
	inline void set_chooseRoundGameAdapter_6(VP_1_t1754838683 * value)
	{
		___chooseRoundGameAdapter_6 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundGameAdapter_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
