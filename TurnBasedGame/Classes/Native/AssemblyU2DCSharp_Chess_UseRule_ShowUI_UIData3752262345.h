#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Chess_UseRuleInputUI_UIData_Stat2509541112.h"

// LP`1<Chess.ChessMove>
struct LP_1_t409034325;
// VP`1<Chess.UseRule.ShowUI/UIData/Sub>
struct VP_1_t1580607400;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.UseRule.ShowUI/UIData
struct  UIData_t3752262345  : public State_t2509541112
{
public:
	// LP`1<Chess.ChessMove> Chess.UseRule.ShowUI/UIData::legalMoves
	LP_1_t409034325 * ___legalMoves_5;
	// VP`1<Chess.UseRule.ShowUI/UIData/Sub> Chess.UseRule.ShowUI/UIData::sub
	VP_1_t1580607400 * ___sub_6;

public:
	inline static int32_t get_offset_of_legalMoves_5() { return static_cast<int32_t>(offsetof(UIData_t3752262345, ___legalMoves_5)); }
	inline LP_1_t409034325 * get_legalMoves_5() const { return ___legalMoves_5; }
	inline LP_1_t409034325 ** get_address_of_legalMoves_5() { return &___legalMoves_5; }
	inline void set_legalMoves_5(LP_1_t409034325 * value)
	{
		___legalMoves_5 = value;
		Il2CppCodeGenWriteBarrier(&___legalMoves_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t3752262345, ___sub_6)); }
	inline VP_1_t1580607400 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t1580607400 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t1580607400 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
