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
#include "AssemblyU2DCSharp_Peregrine_Engine_TournamentComma4213581724.h"

// Unstated.IStateMachineDefinition`2<Peregrine.Engine.TournamentState,Peregrine.Engine.TournamentCommand>
struct IStateMachineDefinition_2_t595484415;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Unstated.StateMachineExecutor`3/<GetTargetStates>c__AnonStorey1<Peregrine.Engine.TournamentState,Peregrine.Engine.TournamentCommand,System.Object>
struct  U3CGetTargetStatesU3Ec__AnonStorey1_t2103184380  : public Il2CppObject
{
public:
	// Unstated.IStateMachineDefinition`2<TState,TTrigger> Unstated.StateMachineExecutor`3/<GetTargetStates>c__AnonStorey1::definition
	Il2CppObject* ___definition_0;
	// TState Unstated.StateMachineExecutor`3/<GetTargetStates>c__AnonStorey1::currentState
	int32_t ___currentState_1;
	// TTrigger Unstated.StateMachineExecutor`3/<GetTargetStates>c__AnonStorey1::trigger
	int32_t ___trigger_2;

public:
	inline static int32_t get_offset_of_definition_0() { return static_cast<int32_t>(offsetof(U3CGetTargetStatesU3Ec__AnonStorey1_t2103184380, ___definition_0)); }
	inline Il2CppObject* get_definition_0() const { return ___definition_0; }
	inline Il2CppObject** get_address_of_definition_0() { return &___definition_0; }
	inline void set_definition_0(Il2CppObject* value)
	{
		___definition_0 = value;
		Il2CppCodeGenWriteBarrier(&___definition_0, value);
	}

	inline static int32_t get_offset_of_currentState_1() { return static_cast<int32_t>(offsetof(U3CGetTargetStatesU3Ec__AnonStorey1_t2103184380, ___currentState_1)); }
	inline int32_t get_currentState_1() const { return ___currentState_1; }
	inline int32_t* get_address_of_currentState_1() { return &___currentState_1; }
	inline void set_currentState_1(int32_t value)
	{
		___currentState_1 = value;
	}

	inline static int32_t get_offset_of_trigger_2() { return static_cast<int32_t>(offsetof(U3CGetTargetStatesU3Ec__AnonStorey1_t2103184380, ___trigger_2)); }
	inline int32_t get_trigger_2() const { return ___trigger_2; }
	inline int32_t* get_address_of_trigger_2() { return &___trigger_2; }
	inline void set_trigger_2(int32_t value)
	{
		___trigger_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
