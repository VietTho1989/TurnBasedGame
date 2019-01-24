#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Unstated_StateMachineException395356217.h"

// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Unstated.InvalidTriggerException`2<System.Object,System.Object>
struct  InvalidTriggerException_2_t3143365285  : public StateMachineException_t395356217
{
public:
	// TState Unstated.InvalidTriggerException`2::State
	Il2CppObject * ___State_11;
	// TTrigger Unstated.InvalidTriggerException`2::Trigger
	Il2CppObject * ___Trigger_12;

public:
	inline static int32_t get_offset_of_State_11() { return static_cast<int32_t>(offsetof(InvalidTriggerException_2_t3143365285, ___State_11)); }
	inline Il2CppObject * get_State_11() const { return ___State_11; }
	inline Il2CppObject ** get_address_of_State_11() { return &___State_11; }
	inline void set_State_11(Il2CppObject * value)
	{
		___State_11 = value;
		Il2CppCodeGenWriteBarrier(&___State_11, value);
	}

	inline static int32_t get_offset_of_Trigger_12() { return static_cast<int32_t>(offsetof(InvalidTriggerException_2_t3143365285, ___Trigger_12)); }
	inline Il2CppObject * get_Trigger_12() const { return ___Trigger_12; }
	inline Il2CppObject ** get_address_of_Trigger_12() { return &___Trigger_12; }
	inline void set_Trigger_12(Il2CppObject * value)
	{
		___Trigger_12 = value;
		Il2CppCodeGenWriteBarrier(&___Trigger_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
