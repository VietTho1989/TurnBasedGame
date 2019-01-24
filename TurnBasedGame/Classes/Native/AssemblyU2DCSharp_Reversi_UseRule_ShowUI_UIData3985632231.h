#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Reversi_UseRuleInputUI_UIData_St2137546006.h"

// LP`1<Reversi.ReversiMove>
struct LP_1_t3531314091;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.UseRule.ShowUI/UIData
struct  UIData_t3985632231  : public State_t2137546006
{
public:
	// LP`1<Reversi.ReversiMove> Reversi.UseRule.ShowUI/UIData::legalMoves
	LP_1_t3531314091 * ___legalMoves_5;

public:
	inline static int32_t get_offset_of_legalMoves_5() { return static_cast<int32_t>(offsetof(UIData_t3985632231, ___legalMoves_5)); }
	inline LP_1_t3531314091 * get_legalMoves_5() const { return ___legalMoves_5; }
	inline LP_1_t3531314091 ** get_address_of_legalMoves_5() { return &___legalMoves_5; }
	inline void set_legalMoves_5(LP_1_t3531314091 * value)
	{
		___legalMoves_5 = value;
		Il2CppCodeGenWriteBarrier(&___legalMoves_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
