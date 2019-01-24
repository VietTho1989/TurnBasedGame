#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_System_ComponentModel_TypeConverter745995970.h"

// System.ComponentModel.TypeConverter/StandardValuesCollection
struct StandardValuesCollection_t191679357;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.CultureInfoConverter
struct  CultureInfoConverter_t2239982248  : public TypeConverter_t745995970
{
public:
	// System.ComponentModel.TypeConverter/StandardValuesCollection System.ComponentModel.CultureInfoConverter::_standardValues
	StandardValuesCollection_t191679357 * ____standardValues_0;

public:
	inline static int32_t get_offset_of__standardValues_0() { return static_cast<int32_t>(offsetof(CultureInfoConverter_t2239982248, ____standardValues_0)); }
	inline StandardValuesCollection_t191679357 * get__standardValues_0() const { return ____standardValues_0; }
	inline StandardValuesCollection_t191679357 ** get_address_of__standardValues_0() { return &____standardValues_0; }
	inline void set__standardValues_0(StandardValuesCollection_t191679357 * value)
	{
		____standardValues_0 = value;
		Il2CppCodeGenWriteBarrier(&____standardValues_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
