#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "Facebook_Unity_Facebook_Unity_ResultBase864677574.h"

// System.String
struct String_t;
// System.Collections.Generic.IEnumerable`1<System.String>
struct IEnumerable_1_t2321347278;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.AppRequestResult
struct  AppRequestResult_t2863124367  : public ResultBase_t864677574
{
public:
	// System.String Facebook.Unity.AppRequestResult::<RequestID>k__BackingField
	String_t* ___U3CRequestIDU3Ek__BackingField_6;
	// System.Collections.Generic.IEnumerable`1<System.String> Facebook.Unity.AppRequestResult::<To>k__BackingField
	Il2CppObject* ___U3CToU3Ek__BackingField_7;

public:
	inline static int32_t get_offset_of_U3CRequestIDU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(AppRequestResult_t2863124367, ___U3CRequestIDU3Ek__BackingField_6)); }
	inline String_t* get_U3CRequestIDU3Ek__BackingField_6() const { return ___U3CRequestIDU3Ek__BackingField_6; }
	inline String_t** get_address_of_U3CRequestIDU3Ek__BackingField_6() { return &___U3CRequestIDU3Ek__BackingField_6; }
	inline void set_U3CRequestIDU3Ek__BackingField_6(String_t* value)
	{
		___U3CRequestIDU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CRequestIDU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_U3CToU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(AppRequestResult_t2863124367, ___U3CToU3Ek__BackingField_7)); }
	inline Il2CppObject* get_U3CToU3Ek__BackingField_7() const { return ___U3CToU3Ek__BackingField_7; }
	inline Il2CppObject** get_address_of_U3CToU3Ek__BackingField_7() { return &___U3CToU3Ek__BackingField_7; }
	inline void set_U3CToU3Ek__BackingField_7(Il2CppObject* value)
	{
		___U3CToU3Ek__BackingField_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CToU3Ek__BackingField_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
