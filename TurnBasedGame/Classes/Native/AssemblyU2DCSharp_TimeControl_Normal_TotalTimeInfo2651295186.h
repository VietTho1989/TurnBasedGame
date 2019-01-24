#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_TimeControl_Normal_TotalTimeInfo1849103010.h"

// VP`1<EditData`1<TimeControl.Normal.TotalTimeInfo/Limit>>
struct VP_1_t2894082644;
// VP`1<RequestChangeFloatUI/UIData>
struct VP_1_t4169104444;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TotalTimeInfoLimitUI/UIData
struct  UIData_t2651295186  : public Sub_t1849103010
{
public:
	// VP`1<EditData`1<TimeControl.Normal.TotalTimeInfo/Limit>> TimeControl.Normal.TotalTimeInfoLimitUI/UIData::editLimit
	VP_1_t2894082644 * ___editLimit_5;
	// VP`1<RequestChangeFloatUI/UIData> TimeControl.Normal.TotalTimeInfoLimitUI/UIData::totalTime
	VP_1_t4169104444 * ___totalTime_6;

public:
	inline static int32_t get_offset_of_editLimit_5() { return static_cast<int32_t>(offsetof(UIData_t2651295186, ___editLimit_5)); }
	inline VP_1_t2894082644 * get_editLimit_5() const { return ___editLimit_5; }
	inline VP_1_t2894082644 ** get_address_of_editLimit_5() { return &___editLimit_5; }
	inline void set_editLimit_5(VP_1_t2894082644 * value)
	{
		___editLimit_5 = value;
		Il2CppCodeGenWriteBarrier(&___editLimit_5, value);
	}

	inline static int32_t get_offset_of_totalTime_6() { return static_cast<int32_t>(offsetof(UIData_t2651295186, ___totalTime_6)); }
	inline VP_1_t4169104444 * get_totalTime_6() const { return ___totalTime_6; }
	inline VP_1_t4169104444 ** get_address_of_totalTime_6() { return &___totalTime_6; }
	inline void set_totalTime_6(VP_1_t4169104444 * value)
	{
		___totalTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___totalTime_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
