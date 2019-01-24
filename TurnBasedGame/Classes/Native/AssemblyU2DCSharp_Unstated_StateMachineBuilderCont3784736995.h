#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Unstated.StateDefinition`2<Peregrine.Engine.TournamentState,Peregrine.Engine.TournamentCommand>
struct StateDefinition_2_t1295954971;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Unstated.StateMachineBuilderContext`2<Peregrine.Engine.TournamentState,Peregrine.Engine.TournamentCommand>
struct  StateMachineBuilderContext_2_t3784736995  : public Il2CppObject
{
public:
	// Unstated.StateDefinition`2<TState,TTrigger> Unstated.StateMachineBuilderContext`2::StateDefinition
	StateDefinition_2_t1295954971 * ___StateDefinition_0;

public:
	inline static int32_t get_offset_of_StateDefinition_0() { return static_cast<int32_t>(offsetof(StateMachineBuilderContext_2_t3784736995, ___StateDefinition_0)); }
	inline StateDefinition_2_t1295954971 * get_StateDefinition_0() const { return ___StateDefinition_0; }
	inline StateDefinition_2_t1295954971 ** get_address_of_StateDefinition_0() { return &___StateDefinition_0; }
	inline void set_StateDefinition_0(StateDefinition_2_t1295954971 * value)
	{
		___StateDefinition_0 = value;
		Il2CppCodeGenWriteBarrier(&___StateDefinition_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
