#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.IDictionary
struct IDictionary_t596158605;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.Collections.HashSet
struct  HashSet_t3608575830  : public Il2CppObject
{
public:
	// System.Collections.IDictionary Org.BouncyCastle.Utilities.Collections.HashSet::impl
	Il2CppObject * ___impl_0;

public:
	inline static int32_t get_offset_of_impl_0() { return static_cast<int32_t>(offsetof(HashSet_t3608575830, ___impl_0)); }
	inline Il2CppObject * get_impl_0() const { return ___impl_0; }
	inline Il2CppObject ** get_address_of_impl_0() { return &___impl_0; }
	inline void set_impl_0(Il2CppObject * value)
	{
		___impl_0 = value;
		Il2CppCodeGenWriteBarrier(&___impl_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
