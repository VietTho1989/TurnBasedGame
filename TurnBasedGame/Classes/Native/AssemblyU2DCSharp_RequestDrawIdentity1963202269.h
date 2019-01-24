#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<RequestDraw>
struct NetData_1_t4140736312;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestDrawIdentity
struct  RequestDrawIdentity_t1963202269  : public DataIdentity_t543951486
{
public:
	// System.Int64 RequestDrawIdentity::time
	int64_t ___time_17;
	// NetData`1<RequestDraw> RequestDrawIdentity::netData
	NetData_1_t4140736312 * ___netData_18;

public:
	inline static int32_t get_offset_of_time_17() { return static_cast<int32_t>(offsetof(RequestDrawIdentity_t1963202269, ___time_17)); }
	inline int64_t get_time_17() const { return ___time_17; }
	inline int64_t* get_address_of_time_17() { return &___time_17; }
	inline void set_time_17(int64_t value)
	{
		___time_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(RequestDrawIdentity_t1963202269, ___netData_18)); }
	inline NetData_1_t4140736312 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t4140736312 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t4140736312 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
