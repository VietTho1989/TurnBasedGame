#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_Peregrine_Engine_TournamentState1212310076.h"

// System.Collections.Generic.IEnumerable`1<Unstated.TriggerDefinitionBase`2<Peregrine.Engine.TournamentState,Peregrine.Engine.TournamentCommand>>
struct IEnumerable_1_t3892468008;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Unstated.StateDefinition`2<Peregrine.Engine.TournamentState,Peregrine.Engine.TournamentCommand>
struct  StateDefinition_2_t1295954971  : public Il2CppObject
{
public:
	// TState Unstated.StateDefinition`2::State
	int32_t ___State_0;
	// System.Collections.Generic.IEnumerable`1<Unstated.TriggerDefinitionBase`2<TState,TTrigger>> Unstated.StateDefinition`2::Triggers
	Il2CppObject* ___Triggers_1;

public:
	inline static int32_t get_offset_of_State_0() { return static_cast<int32_t>(offsetof(StateDefinition_2_t1295954971, ___State_0)); }
	inline int32_t get_State_0() const { return ___State_0; }
	inline int32_t* get_address_of_State_0() { return &___State_0; }
	inline void set_State_0(int32_t value)
	{
		___State_0 = value;
	}

	inline static int32_t get_offset_of_Triggers_1() { return static_cast<int32_t>(offsetof(StateDefinition_2_t1295954971, ___Triggers_1)); }
	inline Il2CppObject* get_Triggers_1() const { return ___Triggers_1; }
	inline Il2CppObject** get_address_of_Triggers_1() { return &___Triggers_1; }
	inline void set_Triggers_1(Il2CppObject* value)
	{
		___Triggers_1 = value;
		Il2CppCodeGenWriteBarrier(&___Triggers_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
