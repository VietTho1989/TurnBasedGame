#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<TimeControl.Normal.TimePerTurnInfo>
struct VP_1_t1801781735;
// VP`1<TimeControl.Normal.TotalTimeInfo>
struct VP_1_t833104335;
// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TimeInfo
struct  TimeInfo_t1276244121  : public Data_t3569509720
{
public:
	// VP`1<TimeControl.Normal.TimePerTurnInfo> TimeControl.Normal.TimeInfo::timePerTurn
	VP_1_t1801781735 * ___timePerTurn_5;
	// VP`1<TimeControl.Normal.TotalTimeInfo> TimeControl.Normal.TimeInfo::totalTime
	VP_1_t833104335 * ___totalTime_6;
	// VP`1<TimeControl.Normal.TimePerTurnInfo> TimeControl.Normal.TimeInfo::overTimePerTurn
	VP_1_t1801781735 * ___overTimePerTurn_7;
	// VP`1<System.Single> TimeControl.Normal.TimeInfo::lagCompensation
	VP_1_t2454786938 * ___lagCompensation_8;

public:
	inline static int32_t get_offset_of_timePerTurn_5() { return static_cast<int32_t>(offsetof(TimeInfo_t1276244121, ___timePerTurn_5)); }
	inline VP_1_t1801781735 * get_timePerTurn_5() const { return ___timePerTurn_5; }
	inline VP_1_t1801781735 ** get_address_of_timePerTurn_5() { return &___timePerTurn_5; }
	inline void set_timePerTurn_5(VP_1_t1801781735 * value)
	{
		___timePerTurn_5 = value;
		Il2CppCodeGenWriteBarrier(&___timePerTurn_5, value);
	}

	inline static int32_t get_offset_of_totalTime_6() { return static_cast<int32_t>(offsetof(TimeInfo_t1276244121, ___totalTime_6)); }
	inline VP_1_t833104335 * get_totalTime_6() const { return ___totalTime_6; }
	inline VP_1_t833104335 ** get_address_of_totalTime_6() { return &___totalTime_6; }
	inline void set_totalTime_6(VP_1_t833104335 * value)
	{
		___totalTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___totalTime_6, value);
	}

	inline static int32_t get_offset_of_overTimePerTurn_7() { return static_cast<int32_t>(offsetof(TimeInfo_t1276244121, ___overTimePerTurn_7)); }
	inline VP_1_t1801781735 * get_overTimePerTurn_7() const { return ___overTimePerTurn_7; }
	inline VP_1_t1801781735 ** get_address_of_overTimePerTurn_7() { return &___overTimePerTurn_7; }
	inline void set_overTimePerTurn_7(VP_1_t1801781735 * value)
	{
		___overTimePerTurn_7 = value;
		Il2CppCodeGenWriteBarrier(&___overTimePerTurn_7, value);
	}

	inline static int32_t get_offset_of_lagCompensation_8() { return static_cast<int32_t>(offsetof(TimeInfo_t1276244121, ___lagCompensation_8)); }
	inline VP_1_t2454786938 * get_lagCompensation_8() const { return ___lagCompensation_8; }
	inline VP_1_t2454786938 ** get_address_of_lagCompensation_8() { return &___lagCompensation_8; }
	inline void set_lagCompensation_8(VP_1_t2454786938 * value)
	{
		___lagCompensation_8 = value;
		Il2CppCodeGenWriteBarrier(&___lagCompensation_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
