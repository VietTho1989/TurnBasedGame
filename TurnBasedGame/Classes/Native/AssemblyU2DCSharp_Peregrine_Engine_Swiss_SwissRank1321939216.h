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
// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.MatchResult>
struct IEnumerable_1_t2507142393;
// Peregrine.Engine.Match
struct Match_t3321962803;
// System.Collections.Generic.IEnumerable`1<System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Match>>
struct IEnumerable_1_t3906216893;
// System.Collections.Generic.IEnumerator`1<System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Match>>
struct IEnumerator_1_t1089613675;
// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Match>
struct IEnumerable_1_t3614089848;
// Peregrine.Engine.Swiss.SwissRankingEngine
struct SwissRankingEngine_t88162131;
// Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0/<GeneratePairedMatches>c__AnonStorey4
struct U3CGeneratePairedMatchesU3Ec__AnonStorey4_t518893845;
// System.Func`2<Peregrine.Engine.MatchResult,Peregrine.Engine.GameResult>
struct Func_2_t988613096;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0
struct  U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216  : public Il2CppObject
{
public:
	// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Player> Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::unpairedPlayers
	Il2CppObject* ___unpairedPlayers_0;
	// System.Int32 Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::<remainingPairings>__0
	int32_t ___U3CremainingPairingsU3E__0_1;
	// System.Int32 Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::<skip>__1
	int32_t ___U3CskipU3E__1_2;
	// System.Int32 Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::<offset>__2
	int32_t ___U3CoffsetU3E__2_3;
	// System.Int32 Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::matchNumber
	int32_t ___matchNumber_4;
	// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.MatchResult> Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::roundMatchResults
	Il2CppObject* ___roundMatchResults_5;
	// Peregrine.Engine.Match Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::<match>__3
	Match_t3321962803 * ___U3CmatchU3E__3_6;
	// System.Collections.Generic.IEnumerable`1<System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Match>> Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::<subsequentMatches>__3
	Il2CppObject* ___U3CsubsequentMatchesU3E__3_7;
	// System.Collections.Generic.IEnumerator`1<System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Match>> Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::$locvar0
	Il2CppObject* ___U24locvar0_8;
	// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Match> Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::<subsequentMatch>__4
	Il2CppObject* ___U3CsubsequentMatchU3E__4_9;
	// Peregrine.Engine.Swiss.SwissRankingEngine Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::$this
	SwissRankingEngine_t88162131 * ___U24this_10;
	// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Match> Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::$current
	Il2CppObject* ___U24current_11;
	// System.Boolean Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::$disposing
	bool ___U24disposing_12;
	// System.Int32 Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::$PC
	int32_t ___U24PC_13;
	// Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0/<GeneratePairedMatches>c__AnonStorey4 Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::$locvar1
	U3CGeneratePairedMatchesU3Ec__AnonStorey4_t518893845 * ___U24locvar1_14;

public:
	inline static int32_t get_offset_of_unpairedPlayers_0() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___unpairedPlayers_0)); }
	inline Il2CppObject* get_unpairedPlayers_0() const { return ___unpairedPlayers_0; }
	inline Il2CppObject** get_address_of_unpairedPlayers_0() { return &___unpairedPlayers_0; }
	inline void set_unpairedPlayers_0(Il2CppObject* value)
	{
		___unpairedPlayers_0 = value;
		Il2CppCodeGenWriteBarrier(&___unpairedPlayers_0, value);
	}

	inline static int32_t get_offset_of_U3CremainingPairingsU3E__0_1() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___U3CremainingPairingsU3E__0_1)); }
	inline int32_t get_U3CremainingPairingsU3E__0_1() const { return ___U3CremainingPairingsU3E__0_1; }
	inline int32_t* get_address_of_U3CremainingPairingsU3E__0_1() { return &___U3CremainingPairingsU3E__0_1; }
	inline void set_U3CremainingPairingsU3E__0_1(int32_t value)
	{
		___U3CremainingPairingsU3E__0_1 = value;
	}

	inline static int32_t get_offset_of_U3CskipU3E__1_2() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___U3CskipU3E__1_2)); }
	inline int32_t get_U3CskipU3E__1_2() const { return ___U3CskipU3E__1_2; }
	inline int32_t* get_address_of_U3CskipU3E__1_2() { return &___U3CskipU3E__1_2; }
	inline void set_U3CskipU3E__1_2(int32_t value)
	{
		___U3CskipU3E__1_2 = value;
	}

	inline static int32_t get_offset_of_U3CoffsetU3E__2_3() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___U3CoffsetU3E__2_3)); }
	inline int32_t get_U3CoffsetU3E__2_3() const { return ___U3CoffsetU3E__2_3; }
	inline int32_t* get_address_of_U3CoffsetU3E__2_3() { return &___U3CoffsetU3E__2_3; }
	inline void set_U3CoffsetU3E__2_3(int32_t value)
	{
		___U3CoffsetU3E__2_3 = value;
	}

	inline static int32_t get_offset_of_matchNumber_4() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___matchNumber_4)); }
	inline int32_t get_matchNumber_4() const { return ___matchNumber_4; }
	inline int32_t* get_address_of_matchNumber_4() { return &___matchNumber_4; }
	inline void set_matchNumber_4(int32_t value)
	{
		___matchNumber_4 = value;
	}

	inline static int32_t get_offset_of_roundMatchResults_5() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___roundMatchResults_5)); }
	inline Il2CppObject* get_roundMatchResults_5() const { return ___roundMatchResults_5; }
	inline Il2CppObject** get_address_of_roundMatchResults_5() { return &___roundMatchResults_5; }
	inline void set_roundMatchResults_5(Il2CppObject* value)
	{
		___roundMatchResults_5 = value;
		Il2CppCodeGenWriteBarrier(&___roundMatchResults_5, value);
	}

	inline static int32_t get_offset_of_U3CmatchU3E__3_6() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___U3CmatchU3E__3_6)); }
	inline Match_t3321962803 * get_U3CmatchU3E__3_6() const { return ___U3CmatchU3E__3_6; }
	inline Match_t3321962803 ** get_address_of_U3CmatchU3E__3_6() { return &___U3CmatchU3E__3_6; }
	inline void set_U3CmatchU3E__3_6(Match_t3321962803 * value)
	{
		___U3CmatchU3E__3_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CmatchU3E__3_6, value);
	}

	inline static int32_t get_offset_of_U3CsubsequentMatchesU3E__3_7() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___U3CsubsequentMatchesU3E__3_7)); }
	inline Il2CppObject* get_U3CsubsequentMatchesU3E__3_7() const { return ___U3CsubsequentMatchesU3E__3_7; }
	inline Il2CppObject** get_address_of_U3CsubsequentMatchesU3E__3_7() { return &___U3CsubsequentMatchesU3E__3_7; }
	inline void set_U3CsubsequentMatchesU3E__3_7(Il2CppObject* value)
	{
		___U3CsubsequentMatchesU3E__3_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CsubsequentMatchesU3E__3_7, value);
	}

	inline static int32_t get_offset_of_U24locvar0_8() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___U24locvar0_8)); }
	inline Il2CppObject* get_U24locvar0_8() const { return ___U24locvar0_8; }
	inline Il2CppObject** get_address_of_U24locvar0_8() { return &___U24locvar0_8; }
	inline void set_U24locvar0_8(Il2CppObject* value)
	{
		___U24locvar0_8 = value;
		Il2CppCodeGenWriteBarrier(&___U24locvar0_8, value);
	}

	inline static int32_t get_offset_of_U3CsubsequentMatchU3E__4_9() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___U3CsubsequentMatchU3E__4_9)); }
	inline Il2CppObject* get_U3CsubsequentMatchU3E__4_9() const { return ___U3CsubsequentMatchU3E__4_9; }
	inline Il2CppObject** get_address_of_U3CsubsequentMatchU3E__4_9() { return &___U3CsubsequentMatchU3E__4_9; }
	inline void set_U3CsubsequentMatchU3E__4_9(Il2CppObject* value)
	{
		___U3CsubsequentMatchU3E__4_9 = value;
		Il2CppCodeGenWriteBarrier(&___U3CsubsequentMatchU3E__4_9, value);
	}

	inline static int32_t get_offset_of_U24this_10() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___U24this_10)); }
	inline SwissRankingEngine_t88162131 * get_U24this_10() const { return ___U24this_10; }
	inline SwissRankingEngine_t88162131 ** get_address_of_U24this_10() { return &___U24this_10; }
	inline void set_U24this_10(SwissRankingEngine_t88162131 * value)
	{
		___U24this_10 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_10, value);
	}

	inline static int32_t get_offset_of_U24current_11() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___U24current_11)); }
	inline Il2CppObject* get_U24current_11() const { return ___U24current_11; }
	inline Il2CppObject** get_address_of_U24current_11() { return &___U24current_11; }
	inline void set_U24current_11(Il2CppObject* value)
	{
		___U24current_11 = value;
		Il2CppCodeGenWriteBarrier(&___U24current_11, value);
	}

	inline static int32_t get_offset_of_U24disposing_12() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___U24disposing_12)); }
	inline bool get_U24disposing_12() const { return ___U24disposing_12; }
	inline bool* get_address_of_U24disposing_12() { return &___U24disposing_12; }
	inline void set_U24disposing_12(bool value)
	{
		___U24disposing_12 = value;
	}

	inline static int32_t get_offset_of_U24PC_13() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___U24PC_13)); }
	inline int32_t get_U24PC_13() const { return ___U24PC_13; }
	inline int32_t* get_address_of_U24PC_13() { return &___U24PC_13; }
	inline void set_U24PC_13(int32_t value)
	{
		___U24PC_13 = value;
	}

	inline static int32_t get_offset_of_U24locvar1_14() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216, ___U24locvar1_14)); }
	inline U3CGeneratePairedMatchesU3Ec__AnonStorey4_t518893845 * get_U24locvar1_14() const { return ___U24locvar1_14; }
	inline U3CGeneratePairedMatchesU3Ec__AnonStorey4_t518893845 ** get_address_of_U24locvar1_14() { return &___U24locvar1_14; }
	inline void set_U24locvar1_14(U3CGeneratePairedMatchesU3Ec__AnonStorey4_t518893845 * value)
	{
		___U24locvar1_14 = value;
		Il2CppCodeGenWriteBarrier(&___U24locvar1_14, value);
	}
};

struct U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216_StaticFields
{
public:
	// System.Func`2<Peregrine.Engine.MatchResult,Peregrine.Engine.GameResult> Peregrine.Engine.Swiss.SwissRankingEngine/<GeneratePairedMatches>c__Iterator0::<>f__am$cache0
	Func_2_t988613096 * ___U3CU3Ef__amU24cache0_15;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_15() { return static_cast<int32_t>(offsetof(U3CGeneratePairedMatchesU3Ec__Iterator0_t1321939216_StaticFields, ___U3CU3Ef__amU24cache0_15)); }
	inline Func_2_t988613096 * get_U3CU3Ef__amU24cache0_15() const { return ___U3CU3Ef__amU24cache0_15; }
	inline Func_2_t988613096 ** get_address_of_U3CU3Ef__amU24cache0_15() { return &___U3CU3Ef__amU24cache0_15; }
	inline void set_U3CU3Ef__amU24cache0_15(Func_2_t988613096 * value)
	{
		___U3CU3Ef__amU24cache0_15 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_15, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
