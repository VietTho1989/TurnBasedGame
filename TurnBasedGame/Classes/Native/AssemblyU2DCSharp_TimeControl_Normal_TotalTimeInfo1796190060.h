#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<TimeControl.Normal.TotalTimeInfo/Limit>
struct NetData_1_t1006425103;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TotalTimeInfoLimitIdentity
struct  TotalTimeInfoLimitIdentity_t1796190060  : public DataIdentity_t543951486
{
public:
	// System.Single TimeControl.Normal.TotalTimeInfoLimitIdentity::totalTime
	float ___totalTime_17;
	// NetData`1<TimeControl.Normal.TotalTimeInfo/Limit> TimeControl.Normal.TotalTimeInfoLimitIdentity::netData
	NetData_1_t1006425103 * ___netData_18;

public:
	inline static int32_t get_offset_of_totalTime_17() { return static_cast<int32_t>(offsetof(TotalTimeInfoLimitIdentity_t1796190060, ___totalTime_17)); }
	inline float get_totalTime_17() const { return ___totalTime_17; }
	inline float* get_address_of_totalTime_17() { return &___totalTime_17; }
	inline void set_totalTime_17(float value)
	{
		___totalTime_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(TotalTimeInfoLimitIdentity_t1796190060, ___netData_18)); }
	inline NetData_1_t1006425103 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t1006425103 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t1006425103 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
