#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.IEnumerable`1<System.Object>
struct IEnumerable_1_t2981576340;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Linq.OrderedEnumerable`1<System.Object>
struct  OrderedEnumerable_1_t4214082274  : public Il2CppObject
{
public:
	// System.Collections.Generic.IEnumerable`1<TElement> System.Linq.OrderedEnumerable`1::source
	Il2CppObject* ___source_0;

public:
	inline static int32_t get_offset_of_source_0() { return static_cast<int32_t>(offsetof(OrderedEnumerable_1_t4214082274, ___source_0)); }
	inline Il2CppObject* get_source_0() const { return ___source_0; }
	inline Il2CppObject** get_address_of_source_0() { return &___source_0; }
	inline void set_source_0(Il2CppObject* value)
	{
		___source_0 = value;
		Il2CppCodeGenWriteBarrier(&___source_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
