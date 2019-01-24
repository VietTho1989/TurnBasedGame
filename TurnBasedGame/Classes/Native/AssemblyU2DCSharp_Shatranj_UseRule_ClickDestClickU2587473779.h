#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Shatranj_UseRule_ClickDestUI_UID1063351786.h"

// LP`1<Shatranj.UseRule.LegalMoveUI/UIData>
struct LP_1_t2252810631;
// VP`1<Shatranj.UseRule.ClickDestClickMoveOrChooseUI/UIData>
struct VP_1_t1093363658;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.UseRule.ClickDestClickUI/UIData
struct  UIData_t2587473779  : public Sub_t1063351786
{
public:
	// LP`1<Shatranj.UseRule.LegalMoveUI/UIData> Shatranj.UseRule.ClickDestClickUI/UIData::legalMoves
	LP_1_t2252810631 * ___legalMoves_5;
	// VP`1<Shatranj.UseRule.ClickDestClickMoveOrChooseUI/UIData> Shatranj.UseRule.ClickDestClickUI/UIData::moveOrChoose
	VP_1_t1093363658 * ___moveOrChoose_6;

public:
	inline static int32_t get_offset_of_legalMoves_5() { return static_cast<int32_t>(offsetof(UIData_t2587473779, ___legalMoves_5)); }
	inline LP_1_t2252810631 * get_legalMoves_5() const { return ___legalMoves_5; }
	inline LP_1_t2252810631 ** get_address_of_legalMoves_5() { return &___legalMoves_5; }
	inline void set_legalMoves_5(LP_1_t2252810631 * value)
	{
		___legalMoves_5 = value;
		Il2CppCodeGenWriteBarrier(&___legalMoves_5, value);
	}

	inline static int32_t get_offset_of_moveOrChoose_6() { return static_cast<int32_t>(offsetof(UIData_t2587473779, ___moveOrChoose_6)); }
	inline VP_1_t1093363658 * get_moveOrChoose_6() const { return ___moveOrChoose_6; }
	inline VP_1_t1093363658 ** get_address_of_moveOrChoose_6() { return &___moveOrChoose_6; }
	inline void set_moveOrChoose_6(VP_1_t1093363658 * value)
	{
		___moveOrChoose_6 = value;
		Il2CppCodeGenWriteBarrier(&___moveOrChoose_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
