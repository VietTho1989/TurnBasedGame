#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Peregrine_Engine_CommandResult_1_530403141.h"

// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.CommandResult`2<System.Object,System.Object>
struct  CommandResult_2_t4212602345  : public CommandResult_1_t530403141
{
public:
	// TReturnValue Peregrine.Engine.CommandResult`2::ReturnValue
	Il2CppObject * ___ReturnValue_3;

public:
	inline static int32_t get_offset_of_ReturnValue_3() { return static_cast<int32_t>(offsetof(CommandResult_2_t4212602345, ___ReturnValue_3)); }
	inline Il2CppObject * get_ReturnValue_3() const { return ___ReturnValue_3; }
	inline Il2CppObject ** get_address_of_ReturnValue_3() { return &___ReturnValue_3; }
	inline void set_ReturnValue_3(Il2CppObject * value)
	{
		___ReturnValue_3 = value;
		Il2CppCodeGenWriteBarrier(&___ReturnValue_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
