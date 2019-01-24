#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Core_System_Linq_SortContext_1_gen1798778454.h"

// System.Func`2<System.Object,System.Object>
struct Func_2_t2825504181;
// System.Collections.Generic.IComparer`1<System.Object>
struct IComparer_1_t643912417;
// System.Object[]
struct ObjectU5BU5D_t3614634134;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Linq.SortSequenceContext`2<System.Object,System.Object>
struct  SortSequenceContext_2_t3061295073  : public SortContext_1_t1798778454
{
public:
	// System.Func`2<TElement,TKey> System.Linq.SortSequenceContext`2::selector
	Func_2_t2825504181 * ___selector_2;
	// System.Collections.Generic.IComparer`1<TKey> System.Linq.SortSequenceContext`2::comparer
	Il2CppObject* ___comparer_3;
	// TKey[] System.Linq.SortSequenceContext`2::keys
	ObjectU5BU5D_t3614634134* ___keys_4;

public:
	inline static int32_t get_offset_of_selector_2() { return static_cast<int32_t>(offsetof(SortSequenceContext_2_t3061295073, ___selector_2)); }
	inline Func_2_t2825504181 * get_selector_2() const { return ___selector_2; }
	inline Func_2_t2825504181 ** get_address_of_selector_2() { return &___selector_2; }
	inline void set_selector_2(Func_2_t2825504181 * value)
	{
		___selector_2 = value;
		Il2CppCodeGenWriteBarrier(&___selector_2, value);
	}

	inline static int32_t get_offset_of_comparer_3() { return static_cast<int32_t>(offsetof(SortSequenceContext_2_t3061295073, ___comparer_3)); }
	inline Il2CppObject* get_comparer_3() const { return ___comparer_3; }
	inline Il2CppObject** get_address_of_comparer_3() { return &___comparer_3; }
	inline void set_comparer_3(Il2CppObject* value)
	{
		___comparer_3 = value;
		Il2CppCodeGenWriteBarrier(&___comparer_3, value);
	}

	inline static int32_t get_offset_of_keys_4() { return static_cast<int32_t>(offsetof(SortSequenceContext_2_t3061295073, ___keys_4)); }
	inline ObjectU5BU5D_t3614634134* get_keys_4() const { return ___keys_4; }
	inline ObjectU5BU5D_t3614634134** get_address_of_keys_4() { return &___keys_4; }
	inline void set_keys_4(ObjectU5BU5D_t3614634134* value)
	{
		___keys_4 = value;
		Il2CppCodeGenWriteBarrier(&___keys_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
