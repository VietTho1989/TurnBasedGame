#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// GameManager.Match.RequestNewRoundHaveLimit
struct RequestNewRoundHaveLimit_t3454006262;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// NetData`1<GameManager.Match.RequestNewRoundHaveLimit>
struct  NetData_1_t3700354787  : public Il2CppObject
{
public:
	// T NetData`1::clientData
	RequestNewRoundHaveLimit_t3454006262 * ___clientData_0;
	// T NetData`1::serverData
	RequestNewRoundHaveLimit_t3454006262 * ___serverData_1;

public:
	inline static int32_t get_offset_of_clientData_0() { return static_cast<int32_t>(offsetof(NetData_1_t3700354787, ___clientData_0)); }
	inline RequestNewRoundHaveLimit_t3454006262 * get_clientData_0() const { return ___clientData_0; }
	inline RequestNewRoundHaveLimit_t3454006262 ** get_address_of_clientData_0() { return &___clientData_0; }
	inline void set_clientData_0(RequestNewRoundHaveLimit_t3454006262 * value)
	{
		___clientData_0 = value;
		Il2CppCodeGenWriteBarrier(&___clientData_0, value);
	}

	inline static int32_t get_offset_of_serverData_1() { return static_cast<int32_t>(offsetof(NetData_1_t3700354787, ___serverData_1)); }
	inline RequestNewRoundHaveLimit_t3454006262 * get_serverData_1() const { return ___serverData_1; }
	inline RequestNewRoundHaveLimit_t3454006262 ** get_address_of_serverData_1() { return &___serverData_1; }
	inline void set_serverData_1(RequestNewRoundHaveLimit_t3454006262 * value)
	{
		___serverData_1 = value;
		Il2CppCodeGenWriteBarrier(&___serverData_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
