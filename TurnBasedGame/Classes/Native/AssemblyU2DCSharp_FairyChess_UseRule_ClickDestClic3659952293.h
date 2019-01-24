#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_FairyChess_UseRule_ClickDestUI_U3968731266.h"

// LP`1<FairyChess.UseRule.LegalMoveUI/UIData>
struct LP_1_t4278742481;
// VP`1<FairyChess.UseRule.ClickDestClickMoveOrChooseUI/UIData>
struct VP_1_t3173272374;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.UseRule.ClickDestClickUI/UIData
struct  UIData_t3659952293  : public Sub_t3968731266
{
public:
	// LP`1<FairyChess.UseRule.LegalMoveUI/UIData> FairyChess.UseRule.ClickDestClickUI/UIData::legalMoves
	LP_1_t4278742481 * ___legalMoves_5;
	// VP`1<FairyChess.UseRule.ClickDestClickMoveOrChooseUI/UIData> FairyChess.UseRule.ClickDestClickUI/UIData::moveOrChoose
	VP_1_t3173272374 * ___moveOrChoose_6;

public:
	inline static int32_t get_offset_of_legalMoves_5() { return static_cast<int32_t>(offsetof(UIData_t3659952293, ___legalMoves_5)); }
	inline LP_1_t4278742481 * get_legalMoves_5() const { return ___legalMoves_5; }
	inline LP_1_t4278742481 ** get_address_of_legalMoves_5() { return &___legalMoves_5; }
	inline void set_legalMoves_5(LP_1_t4278742481 * value)
	{
		___legalMoves_5 = value;
		Il2CppCodeGenWriteBarrier(&___legalMoves_5, value);
	}

	inline static int32_t get_offset_of_moveOrChoose_6() { return static_cast<int32_t>(offsetof(UIData_t3659952293, ___moveOrChoose_6)); }
	inline VP_1_t3173272374 * get_moveOrChoose_6() const { return ___moveOrChoose_6; }
	inline VP_1_t3173272374 ** get_address_of_moveOrChoose_6() { return &___moveOrChoose_6; }
	inline void set_moveOrChoose_6(VP_1_t3173272374 * value)
	{
		___moveOrChoose_6 = value;
		Il2CppCodeGenWriteBarrier(&___moveOrChoose_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
