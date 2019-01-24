#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// UnityEngine.WWW
struct WWW_t2919945039;
// System.Action`1<Foundation.Tasks.Response`1<System.String>>
struct Action_1_t232766016;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.KeyValuePair`2<UnityEngine.WWW,System.Action`1<Foundation.Tasks.Response`1<System.String>>>
struct  KeyValuePair_2_t1418768102 
{
public:
	// TKey System.Collections.Generic.KeyValuePair`2::key
	WWW_t2919945039 * ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	Action_1_t232766016 * ___value_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t1418768102, ___key_0)); }
	inline WWW_t2919945039 * get_key_0() const { return ___key_0; }
	inline WWW_t2919945039 ** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(WWW_t2919945039 * value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier(&___key_0, value);
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t1418768102, ___value_1)); }
	inline Action_1_t232766016 * get_value_1() const { return ___value_1; }
	inline Action_1_t232766016 ** get_address_of_value_1() { return &___value_1; }
	inline void set_value_1(Action_1_t232766016 * value)
	{
		___value_1 = value;
		Il2CppCodeGenWriteBarrier(&___value_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
