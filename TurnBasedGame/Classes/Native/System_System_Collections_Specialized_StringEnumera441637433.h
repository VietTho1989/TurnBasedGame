#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.IEnumerator
struct IEnumerator_t1466026749;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Specialized.StringEnumerator
struct  StringEnumerator_t441637433  : public Il2CppObject
{
public:
	// System.Collections.IEnumerator System.Collections.Specialized.StringEnumerator::enumerable
	Il2CppObject * ___enumerable_0;

public:
	inline static int32_t get_offset_of_enumerable_0() { return static_cast<int32_t>(offsetof(StringEnumerator_t441637433, ___enumerable_0)); }
	inline Il2CppObject * get_enumerable_0() const { return ___enumerable_0; }
	inline Il2CppObject ** get_address_of_enumerable_0() { return &___enumerable_0; }
	inline void set_enumerable_0(Il2CppObject * value)
	{
		___enumerable_0 = value;
		Il2CppCodeGenWriteBarrier(&___enumerable_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
