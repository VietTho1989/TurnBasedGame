#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<TimeControl.Normal.TimeInfo>
struct VP_1_t1654521127;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.PlayerTimeInfo
struct  PlayerTimeInfo_t1512101186  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> TimeControl.Normal.PlayerTimeInfo::playerIndex
	VP_1_t2450154454 * ___playerIndex_5;
	// VP`1<TimeControl.Normal.TimeInfo> TimeControl.Normal.PlayerTimeInfo::timeInfo
	VP_1_t1654521127 * ___timeInfo_6;

public:
	inline static int32_t get_offset_of_playerIndex_5() { return static_cast<int32_t>(offsetof(PlayerTimeInfo_t1512101186, ___playerIndex_5)); }
	inline VP_1_t2450154454 * get_playerIndex_5() const { return ___playerIndex_5; }
	inline VP_1_t2450154454 ** get_address_of_playerIndex_5() { return &___playerIndex_5; }
	inline void set_playerIndex_5(VP_1_t2450154454 * value)
	{
		___playerIndex_5 = value;
		Il2CppCodeGenWriteBarrier(&___playerIndex_5, value);
	}

	inline static int32_t get_offset_of_timeInfo_6() { return static_cast<int32_t>(offsetof(PlayerTimeInfo_t1512101186, ___timeInfo_6)); }
	inline VP_1_t1654521127 * get_timeInfo_6() const { return ___timeInfo_6; }
	inline VP_1_t1654521127 ** get_address_of_timeInfo_6() { return &___timeInfo_6; }
	inline void set_timeInfo_6(VP_1_t1654521127 * value)
	{
		___timeInfo_6 = value;
		Il2CppCodeGenWriteBarrier(&___timeInfo_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
