#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Chess_UseRule_ClickDestUI_UIData1297602221.h"

// LP`1<Chess.UseRule.LegalMoveUI/UIData>
struct LP_1_t3391460522;
// VP`1<Chess.UseRule.ClickDestClickMoveOrChooseUI/UIData>
struct VP_1_t1377062715;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.UseRule.ClickDestClickUI/UIData
struct  UIData_t2477391716  : public Sub_t1297602221
{
public:
	// LP`1<Chess.UseRule.LegalMoveUI/UIData> Chess.UseRule.ClickDestClickUI/UIData::legalMoves
	LP_1_t3391460522 * ___legalMoves_5;
	// VP`1<Chess.UseRule.ClickDestClickMoveOrChooseUI/UIData> Chess.UseRule.ClickDestClickUI/UIData::moveOrChoose
	VP_1_t1377062715 * ___moveOrChoose_6;

public:
	inline static int32_t get_offset_of_legalMoves_5() { return static_cast<int32_t>(offsetof(UIData_t2477391716, ___legalMoves_5)); }
	inline LP_1_t3391460522 * get_legalMoves_5() const { return ___legalMoves_5; }
	inline LP_1_t3391460522 ** get_address_of_legalMoves_5() { return &___legalMoves_5; }
	inline void set_legalMoves_5(LP_1_t3391460522 * value)
	{
		___legalMoves_5 = value;
		Il2CppCodeGenWriteBarrier(&___legalMoves_5, value);
	}

	inline static int32_t get_offset_of_moveOrChoose_6() { return static_cast<int32_t>(offsetof(UIData_t2477391716, ___moveOrChoose_6)); }
	inline VP_1_t1377062715 * get_moveOrChoose_6() const { return ___moveOrChoose_6; }
	inline VP_1_t1377062715 ** get_address_of_moveOrChoose_6() { return &___moveOrChoose_6; }
	inline void set_moveOrChoose_6(VP_1_t1377062715 * value)
	{
		___moveOrChoose_6 = value;
		Il2CppCodeGenWriteBarrier(&___moveOrChoose_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
