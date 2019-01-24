#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_TimeControl_TimeControl_Sub1302046003.h"

// VP`1<TimeControl.Normal.TimeInfo>
struct VP_1_t1654521127;
// LP`1<TimeControl.Normal.PlayerTimeInfo>
struct LP_1_t249845142;
// LP`1<TimeControl.Normal.PlayerTotalTime>
struct LP_1_t1763055262;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TimeControlNormal
struct  TimeControlNormal_t1974218983  : public Sub_t1302046003
{
public:
	// VP`1<TimeControl.Normal.TimeInfo> TimeControl.Normal.TimeControlNormal::generalInfo
	VP_1_t1654521127 * ___generalInfo_5;
	// LP`1<TimeControl.Normal.PlayerTimeInfo> TimeControl.Normal.TimeControlNormal::playerTimeInfos
	LP_1_t249845142 * ___playerTimeInfos_6;
	// LP`1<TimeControl.Normal.PlayerTotalTime> TimeControl.Normal.TimeControlNormal::playerTotalTimes
	LP_1_t1763055262 * ___playerTotalTimes_7;

public:
	inline static int32_t get_offset_of_generalInfo_5() { return static_cast<int32_t>(offsetof(TimeControlNormal_t1974218983, ___generalInfo_5)); }
	inline VP_1_t1654521127 * get_generalInfo_5() const { return ___generalInfo_5; }
	inline VP_1_t1654521127 ** get_address_of_generalInfo_5() { return &___generalInfo_5; }
	inline void set_generalInfo_5(VP_1_t1654521127 * value)
	{
		___generalInfo_5 = value;
		Il2CppCodeGenWriteBarrier(&___generalInfo_5, value);
	}

	inline static int32_t get_offset_of_playerTimeInfos_6() { return static_cast<int32_t>(offsetof(TimeControlNormal_t1974218983, ___playerTimeInfos_6)); }
	inline LP_1_t249845142 * get_playerTimeInfos_6() const { return ___playerTimeInfos_6; }
	inline LP_1_t249845142 ** get_address_of_playerTimeInfos_6() { return &___playerTimeInfos_6; }
	inline void set_playerTimeInfos_6(LP_1_t249845142 * value)
	{
		___playerTimeInfos_6 = value;
		Il2CppCodeGenWriteBarrier(&___playerTimeInfos_6, value);
	}

	inline static int32_t get_offset_of_playerTotalTimes_7() { return static_cast<int32_t>(offsetof(TimeControlNormal_t1974218983, ___playerTotalTimes_7)); }
	inline LP_1_t1763055262 * get_playerTotalTimes_7() const { return ___playerTotalTimes_7; }
	inline LP_1_t1763055262 ** get_address_of_playerTotalTimes_7() { return &___playerTotalTimes_7; }
	inline void set_playerTotalTimes_7(LP_1_t1763055262 * value)
	{
		___playerTotalTimes_7 = value;
		Il2CppCodeGenWriteBarrier(&___playerTotalTimes_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
