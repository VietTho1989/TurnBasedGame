#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.Type
struct Type_t;
// FullSerializer.fsDirectConverter
struct fsDirectConverter_t763460818;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.KeyValuePair`2<System.Type,FullSerializer.fsDirectConverter>
struct  KeyValuePair_2_t458163937 
{
public:
	// TKey System.Collections.Generic.KeyValuePair`2::key
	Type_t * ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	fsDirectConverter_t763460818 * ___value_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t458163937, ___key_0)); }
	inline Type_t * get_key_0() const { return ___key_0; }
	inline Type_t ** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(Type_t * value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier(&___key_0, value);
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t458163937, ___value_1)); }
	inline fsDirectConverter_t763460818 * get_value_1() const { return ___value_1; }
	inline fsDirectConverter_t763460818 ** get_address_of_value_1() { return &___value_1; }
	inline void set_value_1(fsDirectConverter_t763460818 * value)
	{
		___value_1 = value;
		Il2CppCodeGenWriteBarrier(&___value_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
