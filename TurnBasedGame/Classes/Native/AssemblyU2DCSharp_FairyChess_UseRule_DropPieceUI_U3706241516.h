#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_FairyChess_UseRule_ShowUI_UIData_326086951.h"

// VP`1<FairyChess.Common/Square>
struct VP_1_t2266909230;
// LP`1<FairyChess.UseRule.BtnChosenMoveUI/UIData>
struct LP_1_t353511962;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.UseRule.DropPieceUI/UIData
struct  UIData_t3706241516  : public Sub_t326086951
{
public:
	// VP`1<FairyChess.Common/Square> FairyChess.UseRule.DropPieceUI/UIData::square
	VP_1_t2266909230 * ___square_5;
	// LP`1<FairyChess.UseRule.BtnChosenMoveUI/UIData> FairyChess.UseRule.DropPieceUI/UIData::btnChosenMoves
	LP_1_t353511962 * ___btnChosenMoves_6;

public:
	inline static int32_t get_offset_of_square_5() { return static_cast<int32_t>(offsetof(UIData_t3706241516, ___square_5)); }
	inline VP_1_t2266909230 * get_square_5() const { return ___square_5; }
	inline VP_1_t2266909230 ** get_address_of_square_5() { return &___square_5; }
	inline void set_square_5(VP_1_t2266909230 * value)
	{
		___square_5 = value;
		Il2CppCodeGenWriteBarrier(&___square_5, value);
	}

	inline static int32_t get_offset_of_btnChosenMoves_6() { return static_cast<int32_t>(offsetof(UIData_t3706241516, ___btnChosenMoves_6)); }
	inline LP_1_t353511962 * get_btnChosenMoves_6() const { return ___btnChosenMoves_6; }
	inline LP_1_t353511962 ** get_address_of_btnChosenMoves_6() { return &___btnChosenMoves_6; }
	inline void set_btnChosenMoves_6(LP_1_t353511962 * value)
	{
		___btnChosenMoves_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnChosenMoves_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
