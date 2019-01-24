#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Reflection.PropertyInfo
struct PropertyInfo_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsMetaType/<CanSerializeProperty>c__AnonStorey1
struct  U3CCanSerializePropertyU3Ec__AnonStorey1_t3778365949  : public Il2CppObject
{
public:
	// System.Reflection.PropertyInfo FullSerializer.fsMetaType/<CanSerializeProperty>c__AnonStorey1::property
	PropertyInfo_t * ___property_0;

public:
	inline static int32_t get_offset_of_property_0() { return static_cast<int32_t>(offsetof(U3CCanSerializePropertyU3Ec__AnonStorey1_t3778365949, ___property_0)); }
	inline PropertyInfo_t * get_property_0() const { return ___property_0; }
	inline PropertyInfo_t ** get_address_of_property_0() { return &___property_0; }
	inline void set_property_0(PropertyInfo_t * value)
	{
		___property_0 = value;
		Il2CppCodeGenWriteBarrier(&___property_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
