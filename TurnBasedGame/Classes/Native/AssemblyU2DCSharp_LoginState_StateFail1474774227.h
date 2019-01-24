#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_LoginState_None_State2661837700.h"

// VP`1<LoginState.StateFail/Reason>
struct VP_1_t2567943368;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.StateFail
struct  StateFail_t1474774227  : public State_t2661837700
{
public:
	// VP`1<LoginState.StateFail/Reason> LoginState.StateFail::reason
	VP_1_t2567943368 * ___reason_5;

public:
	inline static int32_t get_offset_of_reason_5() { return static_cast<int32_t>(offsetof(StateFail_t1474774227, ___reason_5)); }
	inline VP_1_t2567943368 * get_reason_5() const { return ___reason_5; }
	inline VP_1_t2567943368 ** get_address_of_reason_5() { return &___reason_5; }
	inline void set_reason_5(VP_1_t2567943368 * value)
	{
		___reason_5 = value;
		Il2CppCodeGenWriteBarrier(&___reason_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
