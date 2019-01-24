#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<System.Configuration.ConfigurationProperty>
struct List_1_t1417187943;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ConfigurationPropertyCollection
struct  ConfigurationPropertyCollection_t3473514151  : public Il2CppObject
{
public:
	// System.Collections.Generic.List`1<System.Configuration.ConfigurationProperty> System.Configuration.ConfigurationPropertyCollection::collection
	List_1_t1417187943 * ___collection_0;

public:
	inline static int32_t get_offset_of_collection_0() { return static_cast<int32_t>(offsetof(ConfigurationPropertyCollection_t3473514151, ___collection_0)); }
	inline List_1_t1417187943 * get_collection_0() const { return ___collection_0; }
	inline List_1_t1417187943 ** get_address_of_collection_0() { return &___collection_0; }
	inline void set_collection_0(List_1_t1417187943 * value)
	{
		___collection_0 = value;
		Il2CppCodeGenWriteBarrier(&___collection_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
