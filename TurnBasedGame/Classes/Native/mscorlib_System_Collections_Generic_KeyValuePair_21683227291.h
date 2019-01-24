#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "mscorlib_System_Collections_Generic_KeyValuePair_2_g38854645.h"

// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.KeyValuePair`2<System.Object,System.Collections.Generic.KeyValuePair`2<System.Object,System.Object>>
struct  KeyValuePair_2_t1683227291 
{
public:
	// TKey System.Collections.Generic.KeyValuePair`2::key
	Il2CppObject * ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	KeyValuePair_2_t38854645  ___value_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t1683227291, ___key_0)); }
	inline Il2CppObject * get_key_0() const { return ___key_0; }
	inline Il2CppObject ** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(Il2CppObject * value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier(&___key_0, value);
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t1683227291, ___value_1)); }
	inline KeyValuePair_2_t38854645  get_value_1() const { return ___value_1; }
	inline KeyValuePair_2_t38854645 * get_address_of_value_1() { return &___value_1; }
	inline void set_value_1(KeyValuePair_2_t38854645  value)
	{
		___value_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
