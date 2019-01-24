#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Player>
struct IEnumerable_1_t1054771206;
// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.GameResult>
struct IEnumerable_1_t1730711648;
// System.Func`2<System.Object,System.String>
struct Func_2_t2165275119;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.Match
struct  Match_t3321962803  : public Il2CppObject
{
public:
	// System.Int32 Peregrine.Engine.Match::Number
	int32_t ___Number_0;
	// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Player> Peregrine.Engine.Match::Players
	Il2CppObject* ___Players_1;
	// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.GameResult> Peregrine.Engine.Match::GameResults
	Il2CppObject* ___GameResults_2;

public:
	inline static int32_t get_offset_of_Number_0() { return static_cast<int32_t>(offsetof(Match_t3321962803, ___Number_0)); }
	inline int32_t get_Number_0() const { return ___Number_0; }
	inline int32_t* get_address_of_Number_0() { return &___Number_0; }
	inline void set_Number_0(int32_t value)
	{
		___Number_0 = value;
	}

	inline static int32_t get_offset_of_Players_1() { return static_cast<int32_t>(offsetof(Match_t3321962803, ___Players_1)); }
	inline Il2CppObject* get_Players_1() const { return ___Players_1; }
	inline Il2CppObject** get_address_of_Players_1() { return &___Players_1; }
	inline void set_Players_1(Il2CppObject* value)
	{
		___Players_1 = value;
		Il2CppCodeGenWriteBarrier(&___Players_1, value);
	}

	inline static int32_t get_offset_of_GameResults_2() { return static_cast<int32_t>(offsetof(Match_t3321962803, ___GameResults_2)); }
	inline Il2CppObject* get_GameResults_2() const { return ___GameResults_2; }
	inline Il2CppObject** get_address_of_GameResults_2() { return &___GameResults_2; }
	inline void set_GameResults_2(Il2CppObject* value)
	{
		___GameResults_2 = value;
		Il2CppCodeGenWriteBarrier(&___GameResults_2, value);
	}
};

struct Match_t3321962803_StaticFields
{
public:
	// System.Func`2<System.Object,System.String> Peregrine.Engine.Match::<>f__am$cache0
	Func_2_t2165275119 * ___U3CU3Ef__amU24cache0_3;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_3() { return static_cast<int32_t>(offsetof(Match_t3321962803_StaticFields, ___U3CU3Ef__amU24cache0_3)); }
	inline Func_2_t2165275119 * get_U3CU3Ef__amU24cache0_3() const { return ___U3CU3Ef__amU24cache0_3; }
	inline Func_2_t2165275119 ** get_address_of_U3CU3Ef__amU24cache0_3() { return &___U3CU3Ef__amU24cache0_3; }
	inline void set_U3CU3Ef__amU24cache0_3(Func_2_t2165275119 * value)
	{
		___U3CU3Ef__amU24cache0_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
