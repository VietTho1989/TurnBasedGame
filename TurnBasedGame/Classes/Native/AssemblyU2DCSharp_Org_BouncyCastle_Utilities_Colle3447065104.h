#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.IEnumerable
struct IEnumerable_t2911409499;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.Collections.EnumerableProxy
struct  EnumerableProxy_t3447065104  : public Il2CppObject
{
public:
	// System.Collections.IEnumerable Org.BouncyCastle.Utilities.Collections.EnumerableProxy::inner
	Il2CppObject * ___inner_0;

public:
	inline static int32_t get_offset_of_inner_0() { return static_cast<int32_t>(offsetof(EnumerableProxy_t3447065104, ___inner_0)); }
	inline Il2CppObject * get_inner_0() const { return ___inner_0; }
	inline Il2CppObject ** get_address_of_inner_0() { return &___inner_0; }
	inline void set_inner_0(Il2CppObject * value)
	{
		___inner_0 = value;
		Il2CppCodeGenWriteBarrier(&___inner_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
