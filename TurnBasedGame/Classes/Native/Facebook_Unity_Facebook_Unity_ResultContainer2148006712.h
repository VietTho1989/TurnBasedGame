#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.Collections.Generic.IDictionary`2<System.String,System.Object>
struct IDictionary_2_t2603311978;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.ResultContainer
struct  ResultContainer_t2148006712  : public Il2CppObject
{
public:
	// System.String Facebook.Unity.ResultContainer::<RawResult>k__BackingField
	String_t* ___U3CRawResultU3Ek__BackingField_1;
	// System.Collections.Generic.IDictionary`2<System.String,System.Object> Facebook.Unity.ResultContainer::<ResultDictionary>k__BackingField
	Il2CppObject* ___U3CResultDictionaryU3Ek__BackingField_2;

public:
	inline static int32_t get_offset_of_U3CRawResultU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(ResultContainer_t2148006712, ___U3CRawResultU3Ek__BackingField_1)); }
	inline String_t* get_U3CRawResultU3Ek__BackingField_1() const { return ___U3CRawResultU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CRawResultU3Ek__BackingField_1() { return &___U3CRawResultU3Ek__BackingField_1; }
	inline void set_U3CRawResultU3Ek__BackingField_1(String_t* value)
	{
		___U3CRawResultU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CRawResultU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CResultDictionaryU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(ResultContainer_t2148006712, ___U3CResultDictionaryU3Ek__BackingField_2)); }
	inline Il2CppObject* get_U3CResultDictionaryU3Ek__BackingField_2() const { return ___U3CResultDictionaryU3Ek__BackingField_2; }
	inline Il2CppObject** get_address_of_U3CResultDictionaryU3Ek__BackingField_2() { return &___U3CResultDictionaryU3Ek__BackingField_2; }
	inline void set_U3CResultDictionaryU3Ek__BackingField_2(Il2CppObject* value)
	{
		___U3CResultDictionaryU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CResultDictionaryU3Ek__BackingField_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
