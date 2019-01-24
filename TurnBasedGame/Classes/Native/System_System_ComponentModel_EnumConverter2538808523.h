#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_System_ComponentModel_TypeConverter745995970.h"

// System.Type
struct Type_t;
// System.ComponentModel.TypeConverter/StandardValuesCollection
struct StandardValuesCollection_t191679357;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.EnumConverter
struct  EnumConverter_t2538808523  : public TypeConverter_t745995970
{
public:
	// System.Type System.ComponentModel.EnumConverter::type
	Type_t * ___type_0;
	// System.ComponentModel.TypeConverter/StandardValuesCollection System.ComponentModel.EnumConverter::stdValues
	StandardValuesCollection_t191679357 * ___stdValues_1;

public:
	inline static int32_t get_offset_of_type_0() { return static_cast<int32_t>(offsetof(EnumConverter_t2538808523, ___type_0)); }
	inline Type_t * get_type_0() const { return ___type_0; }
	inline Type_t ** get_address_of_type_0() { return &___type_0; }
	inline void set_type_0(Type_t * value)
	{
		___type_0 = value;
		Il2CppCodeGenWriteBarrier(&___type_0, value);
	}

	inline static int32_t get_offset_of_stdValues_1() { return static_cast<int32_t>(offsetof(EnumConverter_t2538808523, ___stdValues_1)); }
	inline StandardValuesCollection_t191679357 * get_stdValues_1() const { return ___stdValues_1; }
	inline StandardValuesCollection_t191679357 ** get_address_of_stdValues_1() { return &___stdValues_1; }
	inline void set_stdValues_1(StandardValuesCollection_t191679357 * value)
	{
		___stdValues_1 = value;
		Il2CppCodeGenWriteBarrier(&___stdValues_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
