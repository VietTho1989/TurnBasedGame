#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Rights.HaveLimit>
struct NetData_1_t1588470004;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rights.HaveLimitIdentity
struct  HaveLimitIdentity_t3354156909  : public DataIdentity_t543951486
{
public:
	// System.Int32 Rights.HaveLimitIdentity::limit
	int32_t ___limit_17;
	// NetData`1<Rights.HaveLimit> Rights.HaveLimitIdentity::netData
	NetData_1_t1588470004 * ___netData_18;

public:
	inline static int32_t get_offset_of_limit_17() { return static_cast<int32_t>(offsetof(HaveLimitIdentity_t3354156909, ___limit_17)); }
	inline int32_t get_limit_17() const { return ___limit_17; }
	inline int32_t* get_address_of_limit_17() { return &___limit_17; }
	inline void set_limit_17(int32_t value)
	{
		___limit_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(HaveLimitIdentity_t3354156909, ___netData_18)); }
	inline NetData_1_t1588470004 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t1588470004 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t1588470004 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
