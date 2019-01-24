#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<WaitHumanInput>
struct NetData_1_t3914812367;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitHumanInputIdentity
struct  WaitHumanInputIdentity_t711505776  : public DataIdentity_t543951486
{
public:
	// System.UInt32 WaitHumanInputIdentity::userId
	uint32_t ___userId_17;
	// NetData`1<WaitHumanInput> WaitHumanInputIdentity::netData
	NetData_1_t3914812367 * ___netData_18;

public:
	inline static int32_t get_offset_of_userId_17() { return static_cast<int32_t>(offsetof(WaitHumanInputIdentity_t711505776, ___userId_17)); }
	inline uint32_t get_userId_17() const { return ___userId_17; }
	inline uint32_t* get_address_of_userId_17() { return &___userId_17; }
	inline void set_userId_17(uint32_t value)
	{
		___userId_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(WaitHumanInputIdentity_t711505776, ___netData_18)); }
	inline NetData_1_t3914812367 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t3914812367 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t3914812367 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
