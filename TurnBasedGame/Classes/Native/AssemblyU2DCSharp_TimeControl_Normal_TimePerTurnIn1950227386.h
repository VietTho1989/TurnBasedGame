#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_TimeControl_Normal_TimePerTurnIn4225884538.h"

// VP`1<EditData`1<TimeControl.Normal.TimePerTurnInfo/Limit>>
struct VP_1_t3059051420;
// VP`1<RequestChangeFloatUI/UIData>
struct VP_1_t4169104444;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TimePerTurnInfoLimitUI/UIData
struct  UIData_t1950227386  : public Sub_t4225884538
{
public:
	// VP`1<EditData`1<TimeControl.Normal.TimePerTurnInfo/Limit>> TimeControl.Normal.TimePerTurnInfoLimitUI/UIData::editLimit
	VP_1_t3059051420 * ___editLimit_5;
	// VP`1<RequestChangeFloatUI/UIData> TimeControl.Normal.TimePerTurnInfoLimitUI/UIData::perTurn
	VP_1_t4169104444 * ___perTurn_6;

public:
	inline static int32_t get_offset_of_editLimit_5() { return static_cast<int32_t>(offsetof(UIData_t1950227386, ___editLimit_5)); }
	inline VP_1_t3059051420 * get_editLimit_5() const { return ___editLimit_5; }
	inline VP_1_t3059051420 ** get_address_of_editLimit_5() { return &___editLimit_5; }
	inline void set_editLimit_5(VP_1_t3059051420 * value)
	{
		___editLimit_5 = value;
		Il2CppCodeGenWriteBarrier(&___editLimit_5, value);
	}

	inline static int32_t get_offset_of_perTurn_6() { return static_cast<int32_t>(offsetof(UIData_t1950227386, ___perTurn_6)); }
	inline VP_1_t4169104444 * get_perTurn_6() const { return ___perTurn_6; }
	inline VP_1_t4169104444 ** get_address_of_perTurn_6() { return &___perTurn_6; }
	inline void set_perTurn_6(VP_1_t4169104444 * value)
	{
		___perTurn_6 = value;
		Il2CppCodeGenWriteBarrier(&___perTurn_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
