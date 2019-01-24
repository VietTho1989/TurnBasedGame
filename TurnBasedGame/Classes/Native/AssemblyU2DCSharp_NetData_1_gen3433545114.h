#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// RoomStateNormal
struct RoomStateNormal_t3187196589;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// NetData`1<RoomStateNormal>
struct  NetData_1_t3433545114  : public Il2CppObject
{
public:
	// T NetData`1::clientData
	RoomStateNormal_t3187196589 * ___clientData_0;
	// T NetData`1::serverData
	RoomStateNormal_t3187196589 * ___serverData_1;

public:
	inline static int32_t get_offset_of_clientData_0() { return static_cast<int32_t>(offsetof(NetData_1_t3433545114, ___clientData_0)); }
	inline RoomStateNormal_t3187196589 * get_clientData_0() const { return ___clientData_0; }
	inline RoomStateNormal_t3187196589 ** get_address_of_clientData_0() { return &___clientData_0; }
	inline void set_clientData_0(RoomStateNormal_t3187196589 * value)
	{
		___clientData_0 = value;
		Il2CppCodeGenWriteBarrier(&___clientData_0, value);
	}

	inline static int32_t get_offset_of_serverData_1() { return static_cast<int32_t>(offsetof(NetData_1_t3433545114, ___serverData_1)); }
	inline RoomStateNormal_t3187196589 * get_serverData_1() const { return ___serverData_1; }
	inline RoomStateNormal_t3187196589 ** get_address_of_serverData_1() { return &___serverData_1; }
	inline void set_serverData_1(RoomStateNormal_t3187196589 * value)
	{
		___serverData_1 = value;
		Il2CppCodeGenWriteBarrier(&___serverData_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
