﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<System.Int32,System.Reflection.Emit.Label>
struct Dictionary_2_t3251028295;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2/ValueCollection<System.Int32,System.Reflection.Emit.Label>
struct  ValueCollection_t1954088138  : public Il2CppObject
{
public:
	// System.Collections.Generic.Dictionary`2<TKey,TValue> System.Collections.Generic.Dictionary`2/ValueCollection::dictionary
	Dictionary_2_t3251028295 * ___dictionary_0;

public:
	inline static int32_t get_offset_of_dictionary_0() { return static_cast<int32_t>(offsetof(ValueCollection_t1954088138, ___dictionary_0)); }
	inline Dictionary_2_t3251028295 * get_dictionary_0() const { return ___dictionary_0; }
	inline Dictionary_2_t3251028295 ** get_address_of_dictionary_0() { return &___dictionary_0; }
	inline void set_dictionary_0(Dictionary_2_t3251028295 * value)
	{
		___dictionary_0 = value;
		Il2CppCodeGenWriteBarrier(&___dictionary_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
