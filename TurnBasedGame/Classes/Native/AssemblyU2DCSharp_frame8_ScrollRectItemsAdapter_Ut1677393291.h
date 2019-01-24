#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<System.Object>
struct List_1_t2058570427;
// System.Func`2<System.Int32,System.Object>
struct Func_2_t2241269688;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.LazyList`1<System.Object>
struct  LazyList_1_t1677393291  : public Il2CppObject
{
public:
	// System.Collections.Generic.List`1<T> frame8.ScrollRectItemsAdapter.Util.LazyList`1::_BackingList
	List_1_t2058570427 * ____BackingList_0;
	// System.Func`2<System.Int32,T> frame8.ScrollRectItemsAdapter.Util.LazyList`1::_NewValueCreator
	Func_2_t2241269688 * ____NewValueCreator_1;

public:
	inline static int32_t get_offset_of__BackingList_0() { return static_cast<int32_t>(offsetof(LazyList_1_t1677393291, ____BackingList_0)); }
	inline List_1_t2058570427 * get__BackingList_0() const { return ____BackingList_0; }
	inline List_1_t2058570427 ** get_address_of__BackingList_0() { return &____BackingList_0; }
	inline void set__BackingList_0(List_1_t2058570427 * value)
	{
		____BackingList_0 = value;
		Il2CppCodeGenWriteBarrier(&____BackingList_0, value);
	}

	inline static int32_t get_offset_of__NewValueCreator_1() { return static_cast<int32_t>(offsetof(LazyList_1_t1677393291, ____NewValueCreator_1)); }
	inline Func_2_t2241269688 * get__NewValueCreator_1() const { return ____NewValueCreator_1; }
	inline Func_2_t2241269688 ** get_address_of__NewValueCreator_1() { return &____NewValueCreator_1; }
	inline void set__NewValueCreator_1(Func_2_t2241269688 * value)
	{
		____NewValueCreator_1 = value;
		Il2CppCodeGenWriteBarrier(&____NewValueCreator_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
