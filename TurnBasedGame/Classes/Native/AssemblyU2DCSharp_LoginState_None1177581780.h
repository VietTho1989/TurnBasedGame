#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Login_State2662870813.h"

// VP`1<LoginState.None/State>
struct VP_1_t3040114706;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.None
struct  None_t1177581780  : public State_t2662870813
{
public:
	// VP`1<LoginState.None/State> LoginState.None::state
	VP_1_t3040114706 * ___state_5;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(None_t1177581780, ___state_5)); }
	inline VP_1_t3040114706 * get_state_5() const { return ___state_5; }
	inline VP_1_t3040114706 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t3040114706 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
