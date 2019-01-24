#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Round>
struct IEnumerable_1_t2700305397;
// System.Random
struct Random_t1044426839;
// System.Linq.IOrderedEnumerable`1<Peregrine.Engine.Player>[]
struct IOrderedEnumerable_1U5BU5D_t126677064;
// Peregrine.Engine.Swiss.SwissRankingEngine
struct SwissRankingEngine_t88162131;
// System.Func`2<Peregrine.Engine.Match,System.Linq.IOrderedEnumerable`1<Peregrine.Engine.Player>>
struct Func_2_t1302768247;
// System.Func`2<Peregrine.Engine.Player,System.String>
struct Func_2_t1333359221;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.Swiss.SwissRankingEngine/<BuildRounds>c__AnonStorey1
struct  U3CBuildRoundsU3Ec__AnonStorey1_t98876055  : public Il2CppObject
{
public:
	// System.Int32 Peregrine.Engine.Swiss.SwissRankingEngine/<BuildRounds>c__AnonStorey1::roundNumber
	int32_t ___roundNumber_0;
	// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Round> Peregrine.Engine.Swiss.SwissRankingEngine/<BuildRounds>c__AnonStorey1::previousRounds
	Il2CppObject* ___previousRounds_1;
	// System.Random Peregrine.Engine.Swiss.SwissRankingEngine/<BuildRounds>c__AnonStorey1::roundRng
	Random_t1044426839 * ___roundRng_2;
	// System.Linq.IOrderedEnumerable`1<Peregrine.Engine.Player>[] Peregrine.Engine.Swiss.SwissRankingEngine/<BuildRounds>c__AnonStorey1::previousPairings
	IOrderedEnumerable_1U5BU5D_t126677064* ___previousPairings_3;
	// Peregrine.Engine.Swiss.SwissRankingEngine Peregrine.Engine.Swiss.SwissRankingEngine/<BuildRounds>c__AnonStorey1::$this
	SwissRankingEngine_t88162131 * ___U24this_4;

public:
	inline static int32_t get_offset_of_roundNumber_0() { return static_cast<int32_t>(offsetof(U3CBuildRoundsU3Ec__AnonStorey1_t98876055, ___roundNumber_0)); }
	inline int32_t get_roundNumber_0() const { return ___roundNumber_0; }
	inline int32_t* get_address_of_roundNumber_0() { return &___roundNumber_0; }
	inline void set_roundNumber_0(int32_t value)
	{
		___roundNumber_0 = value;
	}

	inline static int32_t get_offset_of_previousRounds_1() { return static_cast<int32_t>(offsetof(U3CBuildRoundsU3Ec__AnonStorey1_t98876055, ___previousRounds_1)); }
	inline Il2CppObject* get_previousRounds_1() const { return ___previousRounds_1; }
	inline Il2CppObject** get_address_of_previousRounds_1() { return &___previousRounds_1; }
	inline void set_previousRounds_1(Il2CppObject* value)
	{
		___previousRounds_1 = value;
		Il2CppCodeGenWriteBarrier(&___previousRounds_1, value);
	}

	inline static int32_t get_offset_of_roundRng_2() { return static_cast<int32_t>(offsetof(U3CBuildRoundsU3Ec__AnonStorey1_t98876055, ___roundRng_2)); }
	inline Random_t1044426839 * get_roundRng_2() const { return ___roundRng_2; }
	inline Random_t1044426839 ** get_address_of_roundRng_2() { return &___roundRng_2; }
	inline void set_roundRng_2(Random_t1044426839 * value)
	{
		___roundRng_2 = value;
		Il2CppCodeGenWriteBarrier(&___roundRng_2, value);
	}

	inline static int32_t get_offset_of_previousPairings_3() { return static_cast<int32_t>(offsetof(U3CBuildRoundsU3Ec__AnonStorey1_t98876055, ___previousPairings_3)); }
	inline IOrderedEnumerable_1U5BU5D_t126677064* get_previousPairings_3() const { return ___previousPairings_3; }
	inline IOrderedEnumerable_1U5BU5D_t126677064** get_address_of_previousPairings_3() { return &___previousPairings_3; }
	inline void set_previousPairings_3(IOrderedEnumerable_1U5BU5D_t126677064* value)
	{
		___previousPairings_3 = value;
		Il2CppCodeGenWriteBarrier(&___previousPairings_3, value);
	}

	inline static int32_t get_offset_of_U24this_4() { return static_cast<int32_t>(offsetof(U3CBuildRoundsU3Ec__AnonStorey1_t98876055, ___U24this_4)); }
	inline SwissRankingEngine_t88162131 * get_U24this_4() const { return ___U24this_4; }
	inline SwissRankingEngine_t88162131 ** get_address_of_U24this_4() { return &___U24this_4; }
	inline void set_U24this_4(SwissRankingEngine_t88162131 * value)
	{
		___U24this_4 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_4, value);
	}
};

struct U3CBuildRoundsU3Ec__AnonStorey1_t98876055_StaticFields
{
public:
	// System.Func`2<Peregrine.Engine.Match,System.Linq.IOrderedEnumerable`1<Peregrine.Engine.Player>> Peregrine.Engine.Swiss.SwissRankingEngine/<BuildRounds>c__AnonStorey1::<>f__am$cache0
	Func_2_t1302768247 * ___U3CU3Ef__amU24cache0_5;
	// System.Func`2<Peregrine.Engine.Player,System.String> Peregrine.Engine.Swiss.SwissRankingEngine/<BuildRounds>c__AnonStorey1::<>f__am$cache1
	Func_2_t1333359221 * ___U3CU3Ef__amU24cache1_6;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_5() { return static_cast<int32_t>(offsetof(U3CBuildRoundsU3Ec__AnonStorey1_t98876055_StaticFields, ___U3CU3Ef__amU24cache0_5)); }
	inline Func_2_t1302768247 * get_U3CU3Ef__amU24cache0_5() const { return ___U3CU3Ef__amU24cache0_5; }
	inline Func_2_t1302768247 ** get_address_of_U3CU3Ef__amU24cache0_5() { return &___U3CU3Ef__amU24cache0_5; }
	inline void set_U3CU3Ef__amU24cache0_5(Func_2_t1302768247 * value)
	{
		___U3CU3Ef__amU24cache0_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_5, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache1_6() { return static_cast<int32_t>(offsetof(U3CBuildRoundsU3Ec__AnonStorey1_t98876055_StaticFields, ___U3CU3Ef__amU24cache1_6)); }
	inline Func_2_t1333359221 * get_U3CU3Ef__amU24cache1_6() const { return ___U3CU3Ef__amU24cache1_6; }
	inline Func_2_t1333359221 ** get_address_of_U3CU3Ef__amU24cache1_6() { return &___U3CU3Ef__amU24cache1_6; }
	inline void set_U3CU3Ef__amU24cache1_6(Func_2_t1333359221 * value)
	{
		___U3CU3Ef__amU24cache1_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache1_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
