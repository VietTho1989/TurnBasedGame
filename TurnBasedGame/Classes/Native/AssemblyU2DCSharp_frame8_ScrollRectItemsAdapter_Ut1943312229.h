#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// frame8.ScrollRectItemsAdapter.Util.LazyList`1<System.Object>
struct LazyList_1_t1677393291;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.LazyList`1/EnumerableLazyList<System.Object>
struct  EnumerableLazyList_t1943312229  : public Il2CppObject
{
public:
	// frame8.ScrollRectItemsAdapter.Util.LazyList`1<T> frame8.ScrollRectItemsAdapter.Util.LazyList`1/EnumerableLazyList::_LazyList
	LazyList_1_t1677393291 * ____LazyList_0;

public:
	inline static int32_t get_offset_of__LazyList_0() { return static_cast<int32_t>(offsetof(EnumerableLazyList_t1943312229, ____LazyList_0)); }
	inline LazyList_1_t1677393291 * get__LazyList_0() const { return ____LazyList_0; }
	inline LazyList_1_t1677393291 ** get_address_of__LazyList_0() { return &____LazyList_0; }
	inline void set__LazyList_0(LazyList_1_t1677393291 * value)
	{
		____LazyList_0 = value;
		Il2CppCodeGenWriteBarrier(&____LazyList_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
