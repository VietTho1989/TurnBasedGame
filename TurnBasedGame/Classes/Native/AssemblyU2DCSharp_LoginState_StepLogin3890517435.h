#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_LoginState_Log_Step3304528929.h"

// VP`1<LoginState.StepLogin/State>
struct VP_1_t2797133003;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.StepLogin
struct  StepLogin_t3890517435  : public Step_t3304528929
{
public:
	// VP`1<LoginState.StepLogin/State> LoginState.StepLogin::state
	VP_1_t2797133003 * ___state_5;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(StepLogin_t3890517435, ___state_5)); }
	inline VP_1_t2797133003 * get_state_5() const { return ___state_5; }
	inline VP_1_t2797133003 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t2797133003 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
