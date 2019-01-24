#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.SortedList
struct SortedList_t3004938869;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.SortedList/ListValues
struct  ListValues_t4117764156  : public Il2CppObject
{
public:
	// System.Collections.SortedList System.Collections.SortedList/ListValues::host
	SortedList_t3004938869 * ___host_0;

public:
	inline static int32_t get_offset_of_host_0() { return static_cast<int32_t>(offsetof(ListValues_t4117764156, ___host_0)); }
	inline SortedList_t3004938869 * get_host_0() const { return ___host_0; }
	inline SortedList_t3004938869 ** get_address_of_host_0() { return &___host_0; }
	inline void set_host_0(SortedList_t3004938869 * value)
	{
		___host_0 = value;
		Il2CppCodeGenWriteBarrier(&___host_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
