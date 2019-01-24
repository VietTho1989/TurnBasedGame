#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.Collections.Generic.List`1<frame8.ScrollRectItemsAdapter.Util.GridView.CellGroupViewsHolder`1<System.Object>>
struct List_1_t1210390528;
// frame8.ScrollRectItemsAdapter.Util.GridView.CellGroupViewsHolder`1<System.Object>
struct CellGroupViewsHolder_1_t1841269396;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1/Enumerator<frame8.ScrollRectItemsAdapter.Util.GridView.CellGroupViewsHolder`1<System.Object>>
struct  Enumerator_t745120202 
{
public:
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::l
	List_1_t1210390528 * ___l_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::next
	int32_t ___next_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::ver
	int32_t ___ver_2;
	// T System.Collections.Generic.List`1/Enumerator::current
	CellGroupViewsHolder_1_t1841269396 * ___current_3;

public:
	inline static int32_t get_offset_of_l_0() { return static_cast<int32_t>(offsetof(Enumerator_t745120202, ___l_0)); }
	inline List_1_t1210390528 * get_l_0() const { return ___l_0; }
	inline List_1_t1210390528 ** get_address_of_l_0() { return &___l_0; }
	inline void set_l_0(List_1_t1210390528 * value)
	{
		___l_0 = value;
		Il2CppCodeGenWriteBarrier(&___l_0, value);
	}

	inline static int32_t get_offset_of_next_1() { return static_cast<int32_t>(offsetof(Enumerator_t745120202, ___next_1)); }
	inline int32_t get_next_1() const { return ___next_1; }
	inline int32_t* get_address_of_next_1() { return &___next_1; }
	inline void set_next_1(int32_t value)
	{
		___next_1 = value;
	}

	inline static int32_t get_offset_of_ver_2() { return static_cast<int32_t>(offsetof(Enumerator_t745120202, ___ver_2)); }
	inline int32_t get_ver_2() const { return ___ver_2; }
	inline int32_t* get_address_of_ver_2() { return &___ver_2; }
	inline void set_ver_2(int32_t value)
	{
		___ver_2 = value;
	}

	inline static int32_t get_offset_of_current_3() { return static_cast<int32_t>(offsetof(Enumerator_t745120202, ___current_3)); }
	inline CellGroupViewsHolder_1_t1841269396 * get_current_3() const { return ___current_3; }
	inline CellGroupViewsHolder_1_t1841269396 ** get_address_of_current_3() { return &___current_3; }
	inline void set_current_3(CellGroupViewsHolder_1_t1841269396 * value)
	{
		___current_3 = value;
		Il2CppCodeGenWriteBarrier(&___current_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
