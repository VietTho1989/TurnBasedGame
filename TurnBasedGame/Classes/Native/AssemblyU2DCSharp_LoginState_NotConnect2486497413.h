#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_LoginState_Log_ConnectState1502297588.h"

// VP`1<LoginState.NotConnect/State>
struct VP_1_t2405354993;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.NotConnect
struct  NotConnect_t2486497413  : public ConnectState_t1502297588
{
public:
	// VP`1<LoginState.NotConnect/State> LoginState.NotConnect::state
	VP_1_t2405354993 * ___state_5;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(NotConnect_t2486497413, ___state_5)); }
	inline VP_1_t2405354993 * get_state_5() const { return ___state_5; }
	inline VP_1_t2405354993 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t2405354993 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
