#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Type
struct Type_t;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Messenger/<Publish>c__AnonStorey4
struct  U3CPublishU3Ec__AnonStorey4_t3090511239  : public Il2CppObject
{
public:
	// System.Type Foundation.Messenger/<Publish>c__AnonStorey4::mType
	Type_t * ___mType_0;
	// System.Object Foundation.Messenger/<Publish>c__AnonStorey4::ignore
	Il2CppObject * ___ignore_1;

public:
	inline static int32_t get_offset_of_mType_0() { return static_cast<int32_t>(offsetof(U3CPublishU3Ec__AnonStorey4_t3090511239, ___mType_0)); }
	inline Type_t * get_mType_0() const { return ___mType_0; }
	inline Type_t ** get_address_of_mType_0() { return &___mType_0; }
	inline void set_mType_0(Type_t * value)
	{
		___mType_0 = value;
		Il2CppCodeGenWriteBarrier(&___mType_0, value);
	}

	inline static int32_t get_offset_of_ignore_1() { return static_cast<int32_t>(offsetof(U3CPublishU3Ec__AnonStorey4_t3090511239, ___ignore_1)); }
	inline Il2CppObject * get_ignore_1() const { return ___ignore_1; }
	inline Il2CppObject ** get_address_of_ignore_1() { return &___ignore_1; }
	inline void set_ignore_1(Il2CppObject * value)
	{
		___ignore_1 = value;
		Il2CppCodeGenWriteBarrier(&___ignore_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
