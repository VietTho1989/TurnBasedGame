#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_TimeControl_Normal_TotalTimeInfo454827329.h"

// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TotalTimeInfo/Limit
struct  Limit_t760076578  : public TotalTimeInfo_t454827329
{
public:
	// VP`1<System.Single> TimeControl.Normal.TotalTimeInfo/Limit::totalTime
	VP_1_t2454786938 * ___totalTime_6;

public:
	inline static int32_t get_offset_of_totalTime_6() { return static_cast<int32_t>(offsetof(Limit_t760076578, ___totalTime_6)); }
	inline VP_1_t2454786938 * get_totalTime_6() const { return ___totalTime_6; }
	inline VP_1_t2454786938 ** get_address_of_totalTime_6() { return &___totalTime_6; }
	inline void set_totalTime_6(VP_1_t2454786938 * value)
	{
		___totalTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___totalTime_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
