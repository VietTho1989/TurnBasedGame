#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<TimeControl.Normal.TimePerTurnInfo/Limit>
struct NetData_1_t1171393879;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TimePerTurnInfoLimitIdentity
struct  TimePerTurnInfoLimitIdentity_t1429488308  : public DataIdentity_t543951486
{
public:
	// System.Single TimeControl.Normal.TimePerTurnInfoLimitIdentity::perTurn
	float ___perTurn_17;
	// NetData`1<TimeControl.Normal.TimePerTurnInfo/Limit> TimeControl.Normal.TimePerTurnInfoLimitIdentity::netData
	NetData_1_t1171393879 * ___netData_18;

public:
	inline static int32_t get_offset_of_perTurn_17() { return static_cast<int32_t>(offsetof(TimePerTurnInfoLimitIdentity_t1429488308, ___perTurn_17)); }
	inline float get_perTurn_17() const { return ___perTurn_17; }
	inline float* get_address_of_perTurn_17() { return &___perTurn_17; }
	inline void set_perTurn_17(float value)
	{
		___perTurn_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(TimePerTurnInfoLimitIdentity_t1429488308, ___netData_18)); }
	inline NetData_1_t1171393879 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t1171393879 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t1171393879 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
