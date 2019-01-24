#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Unstated_TriggerDefinitionBase_23600340963.h"

// System.Func`2<System.Object,System.Boolean>
struct Func_2_t3961629604;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Unstated.TriggerDefinition`3<Peregrine.Engine.TournamentState,Peregrine.Engine.TournamentCommand,System.Object>
struct  TriggerDefinition_3_t1169699998  : public TriggerDefinitionBase_2_t3600340963
{
public:
	// System.Func`2<TPredicateArg0,System.Boolean> Unstated.TriggerDefinition`3::Predicate
	Func_2_t3961629604 * ___Predicate_2;

public:
	inline static int32_t get_offset_of_Predicate_2() { return static_cast<int32_t>(offsetof(TriggerDefinition_3_t1169699998, ___Predicate_2)); }
	inline Func_2_t3961629604 * get_Predicate_2() const { return ___Predicate_2; }
	inline Func_2_t3961629604 ** get_address_of_Predicate_2() { return &___Predicate_2; }
	inline void set_Predicate_2(Func_2_t3961629604 * value)
	{
		___Predicate_2 = value;
		Il2CppCodeGenWriteBarrier(&___Predicate_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
