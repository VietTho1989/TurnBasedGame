#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// UnityEngine.Networking.NetworkMessageDelegate
struct NetworkMessageDelegate_t1861659952;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.KeyValuePair`2<System.Int16,UnityEngine.Networking.NetworkMessageDelegate>
struct  KeyValuePair_2_t2995681727 
{
public:
	// TKey System.Collections.Generic.KeyValuePair`2::key
	int16_t ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	NetworkMessageDelegate_t1861659952 * ___value_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t2995681727, ___key_0)); }
	inline int16_t get_key_0() const { return ___key_0; }
	inline int16_t* get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(int16_t value)
	{
		___key_0 = value;
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t2995681727, ___value_1)); }
	inline NetworkMessageDelegate_t1861659952 * get_value_1() const { return ___value_1; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_value_1() { return &___value_1; }
	inline void set_value_1(NetworkMessageDelegate_t1861659952 * value)
	{
		___value_1 = value;
		Il2CppCodeGenWriteBarrier(&___value_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
