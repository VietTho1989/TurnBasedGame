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
// Peregrine.Engine.Player
struct Player_t762644161;
// System.Func`2<Peregrine.Engine.Match,System.Int32>
struct Func_2_t3320781754;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.Swiss.SwissRankingEngine/<GenerateByeMatch>c__AnonStorey3
struct  U3CGenerateByeMatchU3Ec__AnonStorey3_t1185673886  : public Il2CppObject
{
public:
	// System.Collections.Generic.IEnumerable`1<Peregrine.Engine.Player> Peregrine.Engine.Swiss.SwissRankingEngine/<GenerateByeMatch>c__AnonStorey3::previousByes
	Il2CppObject* ___previousByes_0;
	// System.Int32 Peregrine.Engine.Swiss.SwissRankingEngine/<GenerateByeMatch>c__AnonStorey3::matchNumber
	int32_t ___matchNumber_1;
	// Peregrine.Engine.Player Peregrine.Engine.Swiss.SwissRankingEngine/<GenerateByeMatch>c__AnonStorey3::bye
	Player_t762644161 * ___bye_2;

public:
	inline static int32_t get_offset_of_previousByes_0() { return static_cast<int32_t>(offsetof(U3CGenerateByeMatchU3Ec__AnonStorey3_t1185673886, ___previousByes_0)); }
	inline Il2CppObject* get_previousByes_0() const { return ___previousByes_0; }
	inline Il2CppObject** get_address_of_previousByes_0() { return &___previousByes_0; }
	inline void set_previousByes_0(Il2CppObject* value)
	{
		___previousByes_0 = value;
		Il2CppCodeGenWriteBarrier(&___previousByes_0, value);
	}

	inline static int32_t get_offset_of_matchNumber_1() { return static_cast<int32_t>(offsetof(U3CGenerateByeMatchU3Ec__AnonStorey3_t1185673886, ___matchNumber_1)); }
	inline int32_t get_matchNumber_1() const { return ___matchNumber_1; }
	inline int32_t* get_address_of_matchNumber_1() { return &___matchNumber_1; }
	inline void set_matchNumber_1(int32_t value)
	{
		___matchNumber_1 = value;
	}

	inline static int32_t get_offset_of_bye_2() { return static_cast<int32_t>(offsetof(U3CGenerateByeMatchU3Ec__AnonStorey3_t1185673886, ___bye_2)); }
	inline Player_t762644161 * get_bye_2() const { return ___bye_2; }
	inline Player_t762644161 ** get_address_of_bye_2() { return &___bye_2; }
	inline void set_bye_2(Player_t762644161 * value)
	{
		___bye_2 = value;
		Il2CppCodeGenWriteBarrier(&___bye_2, value);
	}
};

struct U3CGenerateByeMatchU3Ec__AnonStorey3_t1185673886_StaticFields
{
public:
	// System.Func`2<Peregrine.Engine.Match,System.Int32> Peregrine.Engine.Swiss.SwissRankingEngine/<GenerateByeMatch>c__AnonStorey3::<>f__am$cache0
	Func_2_t3320781754 * ___U3CU3Ef__amU24cache0_3;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_3() { return static_cast<int32_t>(offsetof(U3CGenerateByeMatchU3Ec__AnonStorey3_t1185673886_StaticFields, ___U3CU3Ef__amU24cache0_3)); }
	inline Func_2_t3320781754 * get_U3CU3Ef__amU24cache0_3() const { return ___U3CU3Ef__amU24cache0_3; }
	inline Func_2_t3320781754 ** get_address_of_U3CU3Ef__amU24cache0_3() { return &___U3CU3Ef__amU24cache0_3; }
	inline void set_U3CU3Ef__amU24cache0_3(Func_2_t3320781754 * value)
	{
		___U3CU3Ef__amU24cache0_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
