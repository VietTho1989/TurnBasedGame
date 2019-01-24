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
// System.Type
struct Type_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Injector/<GetExports>c__AnonStorey0
struct  U3CGetExportsU3Ec__AnonStorey0_t3904196306  : public Il2CppObject
{
public:
	// System.String Foundation.Injector/<GetExports>c__AnonStorey0::key
	String_t* ___key_0;
	// System.Type Foundation.Injector/<GetExports>c__AnonStorey0::memberType
	Type_t * ___memberType_1;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(U3CGetExportsU3Ec__AnonStorey0_t3904196306, ___key_0)); }
	inline String_t* get_key_0() const { return ___key_0; }
	inline String_t** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(String_t* value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier(&___key_0, value);
	}

	inline static int32_t get_offset_of_memberType_1() { return static_cast<int32_t>(offsetof(U3CGetExportsU3Ec__AnonStorey0_t3904196306, ___memberType_1)); }
	inline Type_t * get_memberType_1() const { return ___memberType_1; }
	inline Type_t ** get_address_of_memberType_1() { return &___memberType_1; }
	inline void set_memberType_1(Type_t * value)
	{
		___memberType_1 = value;
		Il2CppCodeGenWriteBarrier(&___memberType_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
