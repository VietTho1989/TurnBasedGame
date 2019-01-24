#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// FullSerializer.fsConfig
struct fsConfig_t3026457307;
// System.Collections.Generic.Dictionary`2<System.Type,FullSerializer.fsMetaType>
struct Dictionary_2_t909189527;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.KeyValuePair`2<FullSerializer.fsConfig,System.Collections.Generic.Dictionary`2<System.Type,FullSerializer.fsMetaType>>
struct  KeyValuePair_2_t3291089665 
{
public:
	// TKey System.Collections.Generic.KeyValuePair`2::key
	fsConfig_t3026457307 * ___key_0;
	// TValue System.Collections.Generic.KeyValuePair`2::value
	Dictionary_2_t909189527 * ___value_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t3291089665, ___key_0)); }
	inline fsConfig_t3026457307 * get_key_0() const { return ___key_0; }
	inline fsConfig_t3026457307 ** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(fsConfig_t3026457307 * value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier(&___key_0, value);
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(KeyValuePair_2_t3291089665, ___value_1)); }
	inline Dictionary_2_t909189527 * get_value_1() const { return ___value_1; }
	inline Dictionary_2_t909189527 ** get_address_of_value_1() { return &___value_1; }
	inline void set_value_1(Dictionary_2_t909189527 * value)
	{
		___value_1 = value;
		Il2CppCodeGenWriteBarrier(&___value_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
