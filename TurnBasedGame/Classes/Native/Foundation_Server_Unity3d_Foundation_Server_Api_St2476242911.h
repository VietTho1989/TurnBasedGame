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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.Api.StorageDelta
struct  StorageDelta_t2476242911  : public Il2CppObject
{
public:
	// System.String Foundation.Server.Api.StorageDelta::<ObjectId>k__BackingField
	String_t* ___U3CObjectIdU3Ek__BackingField_0;
	// System.String Foundation.Server.Api.StorageDelta::<PropertyName>k__BackingField
	String_t* ___U3CPropertyNameU3Ek__BackingField_1;
	// System.Boolean Foundation.Server.Api.StorageDelta::<IsFloat>k__BackingField
	bool ___U3CIsFloatU3Ek__BackingField_2;
	// System.Single Foundation.Server.Api.StorageDelta::<Delta>k__BackingField
	float ___U3CDeltaU3Ek__BackingField_3;

public:
	inline static int32_t get_offset_of_U3CObjectIdU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(StorageDelta_t2476242911, ___U3CObjectIdU3Ek__BackingField_0)); }
	inline String_t* get_U3CObjectIdU3Ek__BackingField_0() const { return ___U3CObjectIdU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CObjectIdU3Ek__BackingField_0() { return &___U3CObjectIdU3Ek__BackingField_0; }
	inline void set_U3CObjectIdU3Ek__BackingField_0(String_t* value)
	{
		___U3CObjectIdU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CObjectIdU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CPropertyNameU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(StorageDelta_t2476242911, ___U3CPropertyNameU3Ek__BackingField_1)); }
	inline String_t* get_U3CPropertyNameU3Ek__BackingField_1() const { return ___U3CPropertyNameU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CPropertyNameU3Ek__BackingField_1() { return &___U3CPropertyNameU3Ek__BackingField_1; }
	inline void set_U3CPropertyNameU3Ek__BackingField_1(String_t* value)
	{
		___U3CPropertyNameU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CPropertyNameU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CIsFloatU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(StorageDelta_t2476242911, ___U3CIsFloatU3Ek__BackingField_2)); }
	inline bool get_U3CIsFloatU3Ek__BackingField_2() const { return ___U3CIsFloatU3Ek__BackingField_2; }
	inline bool* get_address_of_U3CIsFloatU3Ek__BackingField_2() { return &___U3CIsFloatU3Ek__BackingField_2; }
	inline void set_U3CIsFloatU3Ek__BackingField_2(bool value)
	{
		___U3CIsFloatU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CDeltaU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(StorageDelta_t2476242911, ___U3CDeltaU3Ek__BackingField_3)); }
	inline float get_U3CDeltaU3Ek__BackingField_3() const { return ___U3CDeltaU3Ek__BackingField_3; }
	inline float* get_address_of_U3CDeltaU3Ek__BackingField_3() { return &___U3CDeltaU3Ek__BackingField_3; }
	inline void set_U3CDeltaU3Ek__BackingField_3(float value)
	{
		___U3CDeltaU3Ek__BackingField_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
