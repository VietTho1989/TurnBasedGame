#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_System_Net_HttpStatusCode1898409641.h"

// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<System.String,System.String[]>
struct Dictionary_2_t3557165234;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Tasks.HttpMetadata
struct  HttpMetadata_t2935150347  : public Il2CppObject
{
public:
	// System.String Foundation.Tasks.HttpMetadata::<Message>k__BackingField
	String_t* ___U3CMessageU3Ek__BackingField_0;
	// System.Net.HttpStatusCode Foundation.Tasks.HttpMetadata::<StatusCode>k__BackingField
	int32_t ___U3CStatusCodeU3Ek__BackingField_1;
	// System.Collections.Generic.Dictionary`2<System.String,System.String[]> Foundation.Tasks.HttpMetadata::<ModelState>k__BackingField
	Dictionary_2_t3557165234 * ___U3CModelStateU3Ek__BackingField_2;

public:
	inline static int32_t get_offset_of_U3CMessageU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(HttpMetadata_t2935150347, ___U3CMessageU3Ek__BackingField_0)); }
	inline String_t* get_U3CMessageU3Ek__BackingField_0() const { return ___U3CMessageU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CMessageU3Ek__BackingField_0() { return &___U3CMessageU3Ek__BackingField_0; }
	inline void set_U3CMessageU3Ek__BackingField_0(String_t* value)
	{
		___U3CMessageU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CMessageU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CStatusCodeU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(HttpMetadata_t2935150347, ___U3CStatusCodeU3Ek__BackingField_1)); }
	inline int32_t get_U3CStatusCodeU3Ek__BackingField_1() const { return ___U3CStatusCodeU3Ek__BackingField_1; }
	inline int32_t* get_address_of_U3CStatusCodeU3Ek__BackingField_1() { return &___U3CStatusCodeU3Ek__BackingField_1; }
	inline void set_U3CStatusCodeU3Ek__BackingField_1(int32_t value)
	{
		___U3CStatusCodeU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CModelStateU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(HttpMetadata_t2935150347, ___U3CModelStateU3Ek__BackingField_2)); }
	inline Dictionary_2_t3557165234 * get_U3CModelStateU3Ek__BackingField_2() const { return ___U3CModelStateU3Ek__BackingField_2; }
	inline Dictionary_2_t3557165234 ** get_address_of_U3CModelStateU3Ek__BackingField_2() { return &___U3CModelStateU3Ek__BackingField_2; }
	inline void set_U3CModelStateU3Ek__BackingField_2(Dictionary_2_t3557165234 * value)
	{
		___U3CModelStateU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CModelStateU3Ek__BackingField_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
