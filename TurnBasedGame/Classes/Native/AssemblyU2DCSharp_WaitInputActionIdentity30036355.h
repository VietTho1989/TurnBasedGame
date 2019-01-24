#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<WaitInputAction>
struct NetData_1_t2129327582;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitInputActionIdentity
struct  WaitInputActionIdentity_t30036355  : public DataIdentity_t543951486
{
public:
	// System.Single WaitInputActionIdentity::serverTime
	float ___serverTime_17;
	// NetData`1<WaitInputAction> WaitInputActionIdentity::netData
	NetData_1_t2129327582 * ___netData_18;

public:
	inline static int32_t get_offset_of_serverTime_17() { return static_cast<int32_t>(offsetof(WaitInputActionIdentity_t30036355, ___serverTime_17)); }
	inline float get_serverTime_17() const { return ___serverTime_17; }
	inline float* get_address_of_serverTime_17() { return &___serverTime_17; }
	inline void set_serverTime_17(float value)
	{
		___serverTime_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(WaitInputActionIdentity_t30036355, ___netData_18)); }
	inline NetData_1_t2129327582 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t2129327582 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t2129327582 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
