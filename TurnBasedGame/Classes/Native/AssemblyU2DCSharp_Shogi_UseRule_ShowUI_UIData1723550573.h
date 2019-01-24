#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Shogi_UseRuleInputUI_UIData_Stat1811985404.h"

// LP`1<Shogi.ShogiMove>
struct LP_1_t3438719881;
// VP`1<Shogi.UseRule.ShowUI/UIData/Sub>
struct VP_1_t4161032108;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.UseRule.ShowUI/UIData
struct  UIData_t1723550573  : public State_t1811985404
{
public:
	// LP`1<Shogi.ShogiMove> Shogi.UseRule.ShowUI/UIData::legalMoves
	LP_1_t3438719881 * ___legalMoves_5;
	// VP`1<Shogi.UseRule.ShowUI/UIData/Sub> Shogi.UseRule.ShowUI/UIData::sub
	VP_1_t4161032108 * ___sub_6;

public:
	inline static int32_t get_offset_of_legalMoves_5() { return static_cast<int32_t>(offsetof(UIData_t1723550573, ___legalMoves_5)); }
	inline LP_1_t3438719881 * get_legalMoves_5() const { return ___legalMoves_5; }
	inline LP_1_t3438719881 ** get_address_of_legalMoves_5() { return &___legalMoves_5; }
	inline void set_legalMoves_5(LP_1_t3438719881 * value)
	{
		___legalMoves_5 = value;
		Il2CppCodeGenWriteBarrier(&___legalMoves_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t1723550573, ___sub_6)); }
	inline VP_1_t4161032108 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t4161032108 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t4161032108 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
