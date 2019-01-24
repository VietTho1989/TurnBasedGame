#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<FairyChess.FairyChessMove>>
struct VP_1_t2869139429;
// VP`1<FairyChess.UseRule.BtnChosenMoveUI/OnClick>
struct VP_1_t402321891;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.UseRule.BtnChosenMoveUI/UIData
struct  UIData_t1615768006  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<FairyChess.FairyChessMove>> FairyChess.UseRule.BtnChosenMoveUI/UIData::fairyChessMove
	VP_1_t2869139429 * ___fairyChessMove_5;
	// VP`1<FairyChess.UseRule.BtnChosenMoveUI/OnClick> FairyChess.UseRule.BtnChosenMoveUI/UIData::onClick
	VP_1_t402321891 * ___onClick_6;

public:
	inline static int32_t get_offset_of_fairyChessMove_5() { return static_cast<int32_t>(offsetof(UIData_t1615768006, ___fairyChessMove_5)); }
	inline VP_1_t2869139429 * get_fairyChessMove_5() const { return ___fairyChessMove_5; }
	inline VP_1_t2869139429 ** get_address_of_fairyChessMove_5() { return &___fairyChessMove_5; }
	inline void set_fairyChessMove_5(VP_1_t2869139429 * value)
	{
		___fairyChessMove_5 = value;
		Il2CppCodeGenWriteBarrier(&___fairyChessMove_5, value);
	}

	inline static int32_t get_offset_of_onClick_6() { return static_cast<int32_t>(offsetof(UIData_t1615768006, ___onClick_6)); }
	inline VP_1_t402321891 * get_onClick_6() const { return ___onClick_6; }
	inline VP_1_t402321891 ** get_address_of_onClick_6() { return &___onClick_6; }
	inline void set_onClick_6(VP_1_t402321891 * value)
	{
		___onClick_6 = value;
		Il2CppCodeGenWriteBarrier(&___onClick_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
