#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Shogi_UseRule_ShowUI_UIData_Sub3782755102.h"

// VP`1<Shogi.Common/Square>
struct VP_1_t567270415;
// LP`1<Shogi.UseRule.BtnChosenMoveUI/UIData>
struct LP_1_t2460423495;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.UseRule.DropPieceUI/UIData
struct  UIData_t1051749213  : public Sub_t3782755102
{
public:
	// VP`1<Shogi.Common/Square> Shogi.UseRule.DropPieceUI/UIData::square
	VP_1_t567270415 * ___square_5;
	// LP`1<Shogi.UseRule.BtnChosenMoveUI/UIData> Shogi.UseRule.DropPieceUI/UIData::btnChosenMoves
	LP_1_t2460423495 * ___btnChosenMoves_6;

public:
	inline static int32_t get_offset_of_square_5() { return static_cast<int32_t>(offsetof(UIData_t1051749213, ___square_5)); }
	inline VP_1_t567270415 * get_square_5() const { return ___square_5; }
	inline VP_1_t567270415 ** get_address_of_square_5() { return &___square_5; }
	inline void set_square_5(VP_1_t567270415 * value)
	{
		___square_5 = value;
		Il2CppCodeGenWriteBarrier(&___square_5, value);
	}

	inline static int32_t get_offset_of_btnChosenMoves_6() { return static_cast<int32_t>(offsetof(UIData_t1051749213, ___btnChosenMoves_6)); }
	inline LP_1_t2460423495 * get_btnChosenMoves_6() const { return ___btnChosenMoves_6; }
	inline LP_1_t2460423495 ** get_address_of_btnChosenMoves_6() { return &___btnChosenMoves_6; }
	inline void set_btnChosenMoves_6(LP_1_t2460423495 * value)
	{
		___btnChosenMoves_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnChosenMoves_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
