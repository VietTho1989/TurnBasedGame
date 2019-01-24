#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.AndroidJavaClass
struct AndroidJavaClass_t2973420583;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.AndroidJavaProxy
struct  AndroidJavaProxy_t4274989947  : public Il2CppObject
{
public:
	// UnityEngine.AndroidJavaClass UnityEngine.AndroidJavaProxy::javaInterface
	AndroidJavaClass_t2973420583 * ___javaInterface_0;

public:
	inline static int32_t get_offset_of_javaInterface_0() { return static_cast<int32_t>(offsetof(AndroidJavaProxy_t4274989947, ___javaInterface_0)); }
	inline AndroidJavaClass_t2973420583 * get_javaInterface_0() const { return ___javaInterface_0; }
	inline AndroidJavaClass_t2973420583 ** get_address_of_javaInterface_0() { return &___javaInterface_0; }
	inline void set_javaInterface_0(AndroidJavaClass_t2973420583 * value)
	{
		___javaInterface_0 = value;
		Il2CppCodeGenWriteBarrier(&___javaInterface_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
