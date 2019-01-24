#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_RussianDraught_UseRuleInputUI_UI2381340674.h"

// LP`1<RussianDraught.RussianDraughtMove>
struct LP_1_t4275223451;
// VP`1<RussianDraught.UseRule.ShowUI/UIData/Sub>
struct VP_1_t2735911122;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.UseRule.ShowUI/UIData
struct  UIData_t138457507  : public State_t2381340674
{
public:
	// LP`1<RussianDraught.RussianDraughtMove> RussianDraught.UseRule.ShowUI/UIData::legalMoves
	LP_1_t4275223451 * ___legalMoves_5;
	// VP`1<RussianDraught.UseRule.ShowUI/UIData/Sub> RussianDraught.UseRule.ShowUI/UIData::sub
	VP_1_t2735911122 * ___sub_6;

public:
	inline static int32_t get_offset_of_legalMoves_5() { return static_cast<int32_t>(offsetof(UIData_t138457507, ___legalMoves_5)); }
	inline LP_1_t4275223451 * get_legalMoves_5() const { return ___legalMoves_5; }
	inline LP_1_t4275223451 ** get_address_of_legalMoves_5() { return &___legalMoves_5; }
	inline void set_legalMoves_5(LP_1_t4275223451 * value)
	{
		___legalMoves_5 = value;
		Il2CppCodeGenWriteBarrier(&___legalMoves_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t138457507, ___sub_6)); }
	inline VP_1_t2735911122 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t2735911122 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t2735911122 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
