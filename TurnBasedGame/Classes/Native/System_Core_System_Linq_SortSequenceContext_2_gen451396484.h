#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Core_System_Linq_SortContext_1_gen413132385.h"

// System.Func`2<System.Type,System.String>
struct Func_2_t215605592;
// System.Collections.Generic.IComparer`1<System.String>
struct IComparer_1_t4278650651;
// System.String[]
struct StringU5BU5D_t1642385972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Linq.SortSequenceContext`2<System.Type,System.String>
struct  SortSequenceContext_2_t451396484  : public SortContext_1_t413132385
{
public:
	// System.Func`2<TElement,TKey> System.Linq.SortSequenceContext`2::selector
	Func_2_t215605592 * ___selector_2;
	// System.Collections.Generic.IComparer`1<TKey> System.Linq.SortSequenceContext`2::comparer
	Il2CppObject* ___comparer_3;
	// TKey[] System.Linq.SortSequenceContext`2::keys
	StringU5BU5D_t1642385972* ___keys_4;

public:
	inline static int32_t get_offset_of_selector_2() { return static_cast<int32_t>(offsetof(SortSequenceContext_2_t451396484, ___selector_2)); }
	inline Func_2_t215605592 * get_selector_2() const { return ___selector_2; }
	inline Func_2_t215605592 ** get_address_of_selector_2() { return &___selector_2; }
	inline void set_selector_2(Func_2_t215605592 * value)
	{
		___selector_2 = value;
		Il2CppCodeGenWriteBarrier(&___selector_2, value);
	}

	inline static int32_t get_offset_of_comparer_3() { return static_cast<int32_t>(offsetof(SortSequenceContext_2_t451396484, ___comparer_3)); }
	inline Il2CppObject* get_comparer_3() const { return ___comparer_3; }
	inline Il2CppObject** get_address_of_comparer_3() { return &___comparer_3; }
	inline void set_comparer_3(Il2CppObject* value)
	{
		___comparer_3 = value;
		Il2CppCodeGenWriteBarrier(&___comparer_3, value);
	}

	inline static int32_t get_offset_of_keys_4() { return static_cast<int32_t>(offsetof(SortSequenceContext_2_t451396484, ___keys_4)); }
	inline StringU5BU5D_t1642385972* get_keys_4() const { return ___keys_4; }
	inline StringU5BU5D_t1642385972** get_address_of_keys_4() { return &___keys_4; }
	inline void set_keys_4(StringU5BU5D_t1642385972* value)
	{
		___keys_4 = value;
		Il2CppCodeGenWriteBarrier(&___keys_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
