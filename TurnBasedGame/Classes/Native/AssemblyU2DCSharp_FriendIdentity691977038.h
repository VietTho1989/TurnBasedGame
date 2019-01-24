#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Friend>
struct NetData_1_t3801362633;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendIdentity
struct  FriendIdentity_t691977038  : public DataIdentity_t543951486
{
public:
	// System.Int64 FriendIdentity::time
	int64_t ___time_17;
	// NetData`1<Friend> FriendIdentity::netData
	NetData_1_t3801362633 * ___netData_18;

public:
	inline static int32_t get_offset_of_time_17() { return static_cast<int32_t>(offsetof(FriendIdentity_t691977038, ___time_17)); }
	inline int64_t get_time_17() const { return ___time_17; }
	inline int64_t* get_address_of_time_17() { return &___time_17; }
	inline void set_time_17(int64_t value)
	{
		___time_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(FriendIdentity_t691977038, ___netData_18)); }
	inline NetData_1_t3801362633 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t3801362633 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t3801362633 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
