#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_TimeControl_TimeControl_Sub1302046003.h"

// VP`1<System.Single>
struct VP_1_t2454786938;
// LP`1<TimeControl.HourGlass.PlayerTime>
struct LP_1_t3422408694;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.HourGlass.TimeControlHourGlass
struct  TimeControlHourGlass_t3851955822  : public Sub_t1302046003
{
public:
	// VP`1<System.Single> TimeControl.HourGlass.TimeControlHourGlass::initTime
	VP_1_t2454786938 * ___initTime_5;
	// VP`1<System.Single> TimeControl.HourGlass.TimeControlHourGlass::lagCompensation
	VP_1_t2454786938 * ___lagCompensation_6;
	// LP`1<TimeControl.HourGlass.PlayerTime> TimeControl.HourGlass.TimeControlHourGlass::playerTimes
	LP_1_t3422408694 * ___playerTimes_7;

public:
	inline static int32_t get_offset_of_initTime_5() { return static_cast<int32_t>(offsetof(TimeControlHourGlass_t3851955822, ___initTime_5)); }
	inline VP_1_t2454786938 * get_initTime_5() const { return ___initTime_5; }
	inline VP_1_t2454786938 ** get_address_of_initTime_5() { return &___initTime_5; }
	inline void set_initTime_5(VP_1_t2454786938 * value)
	{
		___initTime_5 = value;
		Il2CppCodeGenWriteBarrier(&___initTime_5, value);
	}

	inline static int32_t get_offset_of_lagCompensation_6() { return static_cast<int32_t>(offsetof(TimeControlHourGlass_t3851955822, ___lagCompensation_6)); }
	inline VP_1_t2454786938 * get_lagCompensation_6() const { return ___lagCompensation_6; }
	inline VP_1_t2454786938 ** get_address_of_lagCompensation_6() { return &___lagCompensation_6; }
	inline void set_lagCompensation_6(VP_1_t2454786938 * value)
	{
		___lagCompensation_6 = value;
		Il2CppCodeGenWriteBarrier(&___lagCompensation_6, value);
	}

	inline static int32_t get_offset_of_playerTimes_7() { return static_cast<int32_t>(offsetof(TimeControlHourGlass_t3851955822, ___playerTimes_7)); }
	inline LP_1_t3422408694 * get_playerTimes_7() const { return ___playerTimes_7; }
	inline LP_1_t3422408694 ** get_address_of_playerTimes_7() { return &___playerTimes_7; }
	inline void set_playerTimes_7(LP_1_t3422408694 * value)
	{
		___playerTimes_7 = value;
		Il2CppCodeGenWriteBarrier(&___playerTimes_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
