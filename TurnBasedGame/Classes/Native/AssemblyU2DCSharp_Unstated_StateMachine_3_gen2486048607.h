#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Unstated.IStateMachineDefinition`2<Peregrine.Engine.TournamentState,Peregrine.Engine.TournamentCommand>
struct IStateMachineDefinition_2_t595484415;
// Unstated.IStateMachineExecutor`3<Peregrine.Engine.TournamentState,Peregrine.Engine.TournamentCommand,Peregrine.Engine.Swiss.SwissTournamentContext>
struct IStateMachineExecutor_3_t3137736673;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Unstated.StateMachine`3<Peregrine.Engine.TournamentState,Peregrine.Engine.TournamentCommand,Peregrine.Engine.Swiss.SwissTournamentContext>
struct  StateMachine_3_t2486048607  : public Il2CppObject
{
public:
	// Unstated.IStateMachineDefinition`2<TState,TTrigger> Unstated.StateMachine`3::Definition
	Il2CppObject* ___Definition_0;
	// Unstated.IStateMachineExecutor`3<TState,TTrigger,TContext> Unstated.StateMachine`3::Executor
	Il2CppObject* ___Executor_1;

public:
	inline static int32_t get_offset_of_Definition_0() { return static_cast<int32_t>(offsetof(StateMachine_3_t2486048607, ___Definition_0)); }
	inline Il2CppObject* get_Definition_0() const { return ___Definition_0; }
	inline Il2CppObject** get_address_of_Definition_0() { return &___Definition_0; }
	inline void set_Definition_0(Il2CppObject* value)
	{
		___Definition_0 = value;
		Il2CppCodeGenWriteBarrier(&___Definition_0, value);
	}

	inline static int32_t get_offset_of_Executor_1() { return static_cast<int32_t>(offsetof(StateMachine_3_t2486048607, ___Executor_1)); }
	inline Il2CppObject* get_Executor_1() const { return ___Executor_1; }
	inline Il2CppObject** get_address_of_Executor_1() { return &___Executor_1; }
	inline void set_Executor_1(Il2CppObject* value)
	{
		___Executor_1 = value;
		Il2CppCodeGenWriteBarrier(&___Executor_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
