#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Xiangqi_UseRuleInputUI_UIData_St3951383885.h"

// LP`1<Xiangqi.UseRule.LegalMove>
struct LP_1_t3321703854;
// VP`1<Xiangqi.UseRule.ShowUI/UIData/Sub>
struct VP_1_t2565424919;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.UseRule.ShowUI/UIData
struct  UIData_t2301285320  : public State_t3951383885
{
public:
	// LP`1<Xiangqi.UseRule.LegalMove> Xiangqi.UseRule.ShowUI/UIData::legalMoves
	LP_1_t3321703854 * ___legalMoves_5;
	// VP`1<Xiangqi.UseRule.ShowUI/UIData/Sub> Xiangqi.UseRule.ShowUI/UIData::sub
	VP_1_t2565424919 * ___sub_6;

public:
	inline static int32_t get_offset_of_legalMoves_5() { return static_cast<int32_t>(offsetof(UIData_t2301285320, ___legalMoves_5)); }
	inline LP_1_t3321703854 * get_legalMoves_5() const { return ___legalMoves_5; }
	inline LP_1_t3321703854 ** get_address_of_legalMoves_5() { return &___legalMoves_5; }
	inline void set_legalMoves_5(LP_1_t3321703854 * value)
	{
		___legalMoves_5 = value;
		Il2CppCodeGenWriteBarrier(&___legalMoves_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t2301285320, ___sub_6)); }
	inline VP_1_t2565424919 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t2565424919 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t2565424919 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
