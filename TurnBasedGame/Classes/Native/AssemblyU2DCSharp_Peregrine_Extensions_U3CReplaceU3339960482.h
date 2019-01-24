#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Func`2<Peregrine.Engine.Player,System.Boolean>
struct Func_2_t3129713706;
// System.Func`2<Peregrine.Engine.Player,Peregrine.Engine.Player>
struct Func_2_t66783149;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Extensions/<Replace>c__AnonStorey0`1<Peregrine.Engine.Player>
struct  U3CReplaceU3Ec__AnonStorey0_1_t3339960482  : public Il2CppObject
{
public:
	// System.Func`2<T,System.Boolean> Peregrine.Extensions/<Replace>c__AnonStorey0`1::predicate
	Func_2_t3129713706 * ___predicate_0;
	// System.Func`2<T,T> Peregrine.Extensions/<Replace>c__AnonStorey0`1::replacement
	Func_2_t66783149 * ___replacement_1;

public:
	inline static int32_t get_offset_of_predicate_0() { return static_cast<int32_t>(offsetof(U3CReplaceU3Ec__AnonStorey0_1_t3339960482, ___predicate_0)); }
	inline Func_2_t3129713706 * get_predicate_0() const { return ___predicate_0; }
	inline Func_2_t3129713706 ** get_address_of_predicate_0() { return &___predicate_0; }
	inline void set_predicate_0(Func_2_t3129713706 * value)
	{
		___predicate_0 = value;
		Il2CppCodeGenWriteBarrier(&___predicate_0, value);
	}

	inline static int32_t get_offset_of_replacement_1() { return static_cast<int32_t>(offsetof(U3CReplaceU3Ec__AnonStorey0_1_t3339960482, ___replacement_1)); }
	inline Func_2_t66783149 * get_replacement_1() const { return ___replacement_1; }
	inline Func_2_t66783149 ** get_address_of_replacement_1() { return &___replacement_1; }
	inline void set_replacement_1(Func_2_t66783149 * value)
	{
		___replacement_1 = value;
		Il2CppCodeGenWriteBarrier(&___replacement_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
