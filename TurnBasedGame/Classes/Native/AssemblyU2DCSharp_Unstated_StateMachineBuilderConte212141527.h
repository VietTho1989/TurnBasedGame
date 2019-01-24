#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Unstated.StateDefinition`2<System.Object,System.Object>
struct StateDefinition_2_t2018326799;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Unstated.StateMachineBuilderContext`2<System.Object,System.Object>
struct  StateMachineBuilderContext_2_t212141527  : public Il2CppObject
{
public:
	// Unstated.StateDefinition`2<TState,TTrigger> Unstated.StateMachineBuilderContext`2::StateDefinition
	StateDefinition_2_t2018326799 * ___StateDefinition_0;

public:
	inline static int32_t get_offset_of_StateDefinition_0() { return static_cast<int32_t>(offsetof(StateMachineBuilderContext_2_t212141527, ___StateDefinition_0)); }
	inline StateDefinition_2_t2018326799 * get_StateDefinition_0() const { return ___StateDefinition_0; }
	inline StateDefinition_2_t2018326799 ** get_address_of_StateDefinition_0() { return &___StateDefinition_0; }
	inline void set_StateDefinition_0(StateDefinition_2_t2018326799 * value)
	{
		___StateDefinition_0 = value;
		Il2CppCodeGenWriteBarrier(&___StateDefinition_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
