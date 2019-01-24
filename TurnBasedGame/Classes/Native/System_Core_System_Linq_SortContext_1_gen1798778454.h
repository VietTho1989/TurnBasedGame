#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_Core_System_Linq_SortDirection759359329.h"

// System.Linq.SortContext`1<System.Object>
struct SortContext_1_t1798778454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Linq.SortContext`1<System.Object>
struct  SortContext_1_t1798778454  : public Il2CppObject
{
public:
	// System.Linq.SortDirection System.Linq.SortContext`1::direction
	int32_t ___direction_0;
	// System.Linq.SortContext`1<TElement> System.Linq.SortContext`1::child_context
	SortContext_1_t1798778454 * ___child_context_1;

public:
	inline static int32_t get_offset_of_direction_0() { return static_cast<int32_t>(offsetof(SortContext_1_t1798778454, ___direction_0)); }
	inline int32_t get_direction_0() const { return ___direction_0; }
	inline int32_t* get_address_of_direction_0() { return &___direction_0; }
	inline void set_direction_0(int32_t value)
	{
		___direction_0 = value;
	}

	inline static int32_t get_offset_of_child_context_1() { return static_cast<int32_t>(offsetof(SortContext_1_t1798778454, ___child_context_1)); }
	inline SortContext_1_t1798778454 * get_child_context_1() const { return ___child_context_1; }
	inline SortContext_1_t1798778454 ** get_address_of_child_context_1() { return &___child_context_1; }
	inline void set_child_context_1(SortContext_1_t1798778454 * value)
	{
		___child_context_1 = value;
		Il2CppCodeGenWriteBarrier(&___child_context_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
