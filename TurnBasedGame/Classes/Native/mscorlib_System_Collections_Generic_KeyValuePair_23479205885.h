#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Netwo835211239.h"

// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.KeyValuePair`2<UnityEngine.Networking.NetworkHash128,System.Object>
struct  KeyValuePair_2_t3479205885 
{
public:
	// TKey System.Collections.Generic.KeyValuePair`2::key
	NetworkHash128_t835211239  ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	Il2CppObject * ___value_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t3479205885, ___key_0)); }
	inline NetworkHash128_t835211239  get_key_0() const { return ___key_0; }
	inline NetworkHash128_t835211239 * get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(NetworkHash128_t835211239  value)
	{
		___key_0 = value;
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t3479205885, ___value_1)); }
	inline Il2CppObject * get_value_1() const { return ___value_1; }
	inline Il2CppObject ** get_address_of_value_1() { return &___value_1; }
	inline void set_value_1(Il2CppObject * value)
	{
		___value_1 = value;
		Il2CppCodeGenWriteBarrier(&___value_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
