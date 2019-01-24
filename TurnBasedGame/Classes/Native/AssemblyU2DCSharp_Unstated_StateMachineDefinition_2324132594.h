#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.IEnumerable`1<Unstated.StateDefinition`2<Peregrine.Engine.TournamentState,Peregrine.Engine.TournamentCommand>>
struct IEnumerable_1_t1588082016;
// System.Collections.Generic.IEqualityComparer`1<Peregrine.Engine.TournamentState>
struct IEqualityComparer_1_t424942854;
// System.Collections.Generic.IEqualityComparer`1<Peregrine.Engine.TournamentCommand>
struct IEqualityComparer_1_t3426214502;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Unstated.StateMachineDefinition`2<Peregrine.Engine.TournamentState,Peregrine.Engine.TournamentCommand>
struct  StateMachineDefinition_2_t2324132594  : public Il2CppObject
{
public:
	// System.Collections.Generic.IEnumerable`1<Unstated.StateDefinition`2<TState,TTrigger>> Unstated.StateMachineDefinition`2::States
	Il2CppObject* ___States_0;
	// System.Collections.Generic.IEqualityComparer`1<TState> Unstated.StateMachineDefinition`2::StateComparer
	Il2CppObject* ___StateComparer_1;
	// System.Collections.Generic.IEqualityComparer`1<TTrigger> Unstated.StateMachineDefinition`2::TriggerComparer
	Il2CppObject* ___TriggerComparer_2;

public:
	inline static int32_t get_offset_of_States_0() { return static_cast<int32_t>(offsetof(StateMachineDefinition_2_t2324132594, ___States_0)); }
	inline Il2CppObject* get_States_0() const { return ___States_0; }
	inline Il2CppObject** get_address_of_States_0() { return &___States_0; }
	inline void set_States_0(Il2CppObject* value)
	{
		___States_0 = value;
		Il2CppCodeGenWriteBarrier(&___States_0, value);
	}

	inline static int32_t get_offset_of_StateComparer_1() { return static_cast<int32_t>(offsetof(StateMachineDefinition_2_t2324132594, ___StateComparer_1)); }
	inline Il2CppObject* get_StateComparer_1() const { return ___StateComparer_1; }
	inline Il2CppObject** get_address_of_StateComparer_1() { return &___StateComparer_1; }
	inline void set_StateComparer_1(Il2CppObject* value)
	{
		___StateComparer_1 = value;
		Il2CppCodeGenWriteBarrier(&___StateComparer_1, value);
	}

	inline static int32_t get_offset_of_TriggerComparer_2() { return static_cast<int32_t>(offsetof(StateMachineDefinition_2_t2324132594, ___TriggerComparer_2)); }
	inline Il2CppObject* get_TriggerComparer_2() const { return ___TriggerComparer_2; }
	inline Il2CppObject** get_address_of_TriggerComparer_2() { return &___TriggerComparer_2; }
	inline void set_TriggerComparer_2(Il2CppObject* value)
	{
		___TriggerComparer_2 = value;
		Il2CppCodeGenWriteBarrier(&___TriggerComparer_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
