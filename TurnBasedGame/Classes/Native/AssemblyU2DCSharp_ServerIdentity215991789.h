#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Server>
struct NetData_1_t2970669292;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ServerIdentity
struct  ServerIdentity_t215991789  : public DataIdentity_t543951486
{
public:
	// System.Single ServerIdentity::disconnectTime
	float ___disconnectTime_17;
	// NetData`1<Server> ServerIdentity::netData
	NetData_1_t2970669292 * ___netData_18;

public:
	inline static int32_t get_offset_of_disconnectTime_17() { return static_cast<int32_t>(offsetof(ServerIdentity_t215991789, ___disconnectTime_17)); }
	inline float get_disconnectTime_17() const { return ___disconnectTime_17; }
	inline float* get_address_of_disconnectTime_17() { return &___disconnectTime_17; }
	inline void set_disconnectTime_17(float value)
	{
		___disconnectTime_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(ServerIdentity_t215991789, ___netData_18)); }
	inline NetData_1_t2970669292 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t2970669292 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t2970669292 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
