#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "AssemblyU2DCSharp_FullSerializer_Internal_fsPortabl604298480.h"

// System.Attribute
struct Attribute_t542643598;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.KeyValuePair`2<FullSerializer.Internal.fsPortableReflection/AttributeQuery,System.Attribute>
struct  KeyValuePair_2_t2436966639 
{
public:
	// TKey System.Collections.Generic.KeyValuePair`2::key
	AttributeQuery_t604298480  ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	Attribute_t542643598 * ___value_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t2436966639, ___key_0)); }
	inline AttributeQuery_t604298480  get_key_0() const { return ___key_0; }
	inline AttributeQuery_t604298480 * get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(AttributeQuery_t604298480  value)
	{
		___key_0 = value;
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t2436966639, ___value_1)); }
	inline Attribute_t542643598 * get_value_1() const { return ___value_1; }
	inline Attribute_t542643598 ** get_address_of_value_1() { return &___value_1; }
	inline void set_value_1(Attribute_t542643598 * value)
	{
		___value_1 = value;
		Il2CppCodeGenWriteBarrier(&___value_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
