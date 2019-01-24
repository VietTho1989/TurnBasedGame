#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<TimeControl.Normal.TimeInfo>
struct NetData_1_t1522592646;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TimeInfoIdentity
struct  TimeInfoIdentity_t3866604895  : public DataIdentity_t543951486
{
public:
	// System.Single TimeControl.Normal.TimeInfoIdentity::lagCompensation
	float ___lagCompensation_17;
	// NetData`1<TimeControl.Normal.TimeInfo> TimeControl.Normal.TimeInfoIdentity::netData
	NetData_1_t1522592646 * ___netData_18;

public:
	inline static int32_t get_offset_of_lagCompensation_17() { return static_cast<int32_t>(offsetof(TimeInfoIdentity_t3866604895, ___lagCompensation_17)); }
	inline float get_lagCompensation_17() const { return ___lagCompensation_17; }
	inline float* get_address_of_lagCompensation_17() { return &___lagCompensation_17; }
	inline void set_lagCompensation_17(float value)
	{
		___lagCompensation_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(TimeInfoIdentity_t3866604895, ___netData_18)); }
	inline NetData_1_t1522592646 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t1522592646 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t1522592646 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
