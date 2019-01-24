#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Unstated.StateMachineContext`1<System.Object>
struct  StateMachineContext_1_t3600898428  : public Il2CppObject
{
public:
	// TState Unstated.StateMachineContext`1::State
	Il2CppObject * ___State_0;

public:
	inline static int32_t get_offset_of_State_0() { return static_cast<int32_t>(offsetof(StateMachineContext_1_t3600898428, ___State_0)); }
	inline Il2CppObject * get_State_0() const { return ___State_0; }
	inline Il2CppObject ** get_address_of_State_0() { return &___State_0; }
	inline void set_State_0(Il2CppObject * value)
	{
		___State_0 = value;
		Il2CppCodeGenWriteBarrier(&___State_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
