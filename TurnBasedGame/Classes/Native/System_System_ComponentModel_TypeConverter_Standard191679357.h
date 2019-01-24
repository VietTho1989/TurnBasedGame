#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.ICollection
struct ICollection_t91669223;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.TypeConverter/StandardValuesCollection
struct  StandardValuesCollection_t191679357  : public Il2CppObject
{
public:
	// System.Collections.ICollection System.ComponentModel.TypeConverter/StandardValuesCollection::values
	Il2CppObject * ___values_0;

public:
	inline static int32_t get_offset_of_values_0() { return static_cast<int32_t>(offsetof(StandardValuesCollection_t191679357, ___values_0)); }
	inline Il2CppObject * get_values_0() const { return ___values_0; }
	inline Il2CppObject ** get_address_of_values_0() { return &___values_0; }
	inline void set_values_0(Il2CppObject * value)
	{
		___values_0 = value;
		Il2CppCodeGenWriteBarrier(&___values_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
