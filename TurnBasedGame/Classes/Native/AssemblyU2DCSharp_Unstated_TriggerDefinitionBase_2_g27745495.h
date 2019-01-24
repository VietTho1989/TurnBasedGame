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

// Unstated.TriggerDefinitionBase`2<System.Object,System.Object>
struct  TriggerDefinitionBase_2_t27745495  : public Il2CppObject
{
public:
	// TTrigger Unstated.TriggerDefinitionBase`2::Trigger
	Il2CppObject * ___Trigger_0;
	// TState Unstated.TriggerDefinitionBase`2::TargetState
	Il2CppObject * ___TargetState_1;

public:
	inline static int32_t get_offset_of_Trigger_0() { return static_cast<int32_t>(offsetof(TriggerDefinitionBase_2_t27745495, ___Trigger_0)); }
	inline Il2CppObject * get_Trigger_0() const { return ___Trigger_0; }
	inline Il2CppObject ** get_address_of_Trigger_0() { return &___Trigger_0; }
	inline void set_Trigger_0(Il2CppObject * value)
	{
		___Trigger_0 = value;
		Il2CppCodeGenWriteBarrier(&___Trigger_0, value);
	}

	inline static int32_t get_offset_of_TargetState_1() { return static_cast<int32_t>(offsetof(TriggerDefinitionBase_2_t27745495, ___TargetState_1)); }
	inline Il2CppObject * get_TargetState_1() const { return ___TargetState_1; }
	inline Il2CppObject ** get_address_of_TargetState_1() { return &___TargetState_1; }
	inline void set_TargetState_1(Il2CppObject * value)
	{
		___TargetState_1 = value;
		Il2CppCodeGenWriteBarrier(&___TargetState_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
