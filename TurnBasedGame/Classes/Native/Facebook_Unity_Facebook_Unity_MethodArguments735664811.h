#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.IDictionary`2<System.String,System.Object>
struct IDictionary_2_t2603311978;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.MethodArguments
struct  MethodArguments_t735664811  : public Il2CppObject
{
public:
	// System.Collections.Generic.IDictionary`2<System.String,System.Object> Facebook.Unity.MethodArguments::arguments
	Il2CppObject* ___arguments_0;

public:
	inline static int32_t get_offset_of_arguments_0() { return static_cast<int32_t>(offsetof(MethodArguments_t735664811, ___arguments_0)); }
	inline Il2CppObject* get_arguments_0() const { return ___arguments_0; }
	inline Il2CppObject** get_address_of_arguments_0() { return &___arguments_0; }
	inline void set_arguments_0(Il2CppObject* value)
	{
		___arguments_0 = value;
		Il2CppCodeGenWriteBarrier(&___arguments_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
