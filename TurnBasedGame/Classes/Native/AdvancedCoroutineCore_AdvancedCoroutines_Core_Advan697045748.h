#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<AdvancedCoroutines.Routine>
struct List_1_t1871711772;
// AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll/ExtentionMethod
struct ExtentionMethod_t2391051970;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll
struct  AdvancedCoroutinesCoreDll_t697045748  : public Il2CppObject
{
public:
	// System.Collections.Generic.List`1<AdvancedCoroutines.Routine> AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::_routines
	List_1_t1871711772 * ____routines_0;

public:
	inline static int32_t get_offset_of__routines_0() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesCoreDll_t697045748, ____routines_0)); }
	inline List_1_t1871711772 * get__routines_0() const { return ____routines_0; }
	inline List_1_t1871711772 ** get_address_of__routines_0() { return &____routines_0; }
	inline void set__routines_0(List_1_t1871711772 * value)
	{
		____routines_0 = value;
		Il2CppCodeGenWriteBarrier(&____routines_0, value);
	}
};

struct AdvancedCoroutinesCoreDll_t697045748_StaticFields
{
public:
	// AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll/ExtentionMethod AdvancedCoroutines.Core.AdvancedCoroutinesCoreDll::ExtMethod
	ExtentionMethod_t2391051970 * ___ExtMethod_1;

public:
	inline static int32_t get_offset_of_ExtMethod_1() { return static_cast<int32_t>(offsetof(AdvancedCoroutinesCoreDll_t697045748_StaticFields, ___ExtMethod_1)); }
	inline ExtentionMethod_t2391051970 * get_ExtMethod_1() const { return ___ExtMethod_1; }
	inline ExtentionMethod_t2391051970 ** get_address_of_ExtMethod_1() { return &___ExtMethod_1; }
	inline void set_ExtMethod_1(ExtentionMethod_t2391051970 * value)
	{
		___ExtMethod_1 = value;
		Il2CppCodeGenWriteBarrier(&___ExtMethod_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
