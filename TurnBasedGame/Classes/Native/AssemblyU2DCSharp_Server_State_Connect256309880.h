#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Server_State3514787095.h"

// VP`1<Server/State/Connect/State>
struct VP_1_t3286069084;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Server/State/Connect
struct  Connect_t256309880  : public State_t3514787095
{
public:
	// VP`1<Server/State/Connect/State> Server/State/Connect::state
	VP_1_t3286069084 * ___state_5;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(Connect_t256309880, ___state_5)); }
	inline VP_1_t3286069084 * get_state_5() const { return ___state_5; }
	inline VP_1_t3286069084 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t3286069084 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
