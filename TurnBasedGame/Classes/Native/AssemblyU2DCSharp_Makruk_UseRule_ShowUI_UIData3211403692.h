#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Makruk_UseRuleInputUI_UIData_Stat831334991.h"

// LP`1<Makruk.MakrukMove>
struct LP_1_t4051608964;
// VP`1<Makruk.UseRule.ShowUI/UIData/Sub>
struct VP_1_t786856633;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Makruk.UseRule.ShowUI/UIData
struct  UIData_t3211403692  : public State_t831334991
{
public:
	// LP`1<Makruk.MakrukMove> Makruk.UseRule.ShowUI/UIData::legalMoves
	LP_1_t4051608964 * ___legalMoves_5;
	// VP`1<Makruk.UseRule.ShowUI/UIData/Sub> Makruk.UseRule.ShowUI/UIData::sub
	VP_1_t786856633 * ___sub_6;

public:
	inline static int32_t get_offset_of_legalMoves_5() { return static_cast<int32_t>(offsetof(UIData_t3211403692, ___legalMoves_5)); }
	inline LP_1_t4051608964 * get_legalMoves_5() const { return ___legalMoves_5; }
	inline LP_1_t4051608964 ** get_address_of_legalMoves_5() { return &___legalMoves_5; }
	inline void set_legalMoves_5(LP_1_t4051608964 * value)
	{
		___legalMoves_5 = value;
		Il2CppCodeGenWriteBarrier(&___legalMoves_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t3211403692, ___sub_6)); }
	inline VP_1_t786856633 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t786856633 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t786856633 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
