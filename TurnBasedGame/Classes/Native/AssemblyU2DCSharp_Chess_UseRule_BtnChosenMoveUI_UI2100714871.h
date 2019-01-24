#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Chess.ChessMove>>
struct VP_1_t1120350438;
// VP`1<Chess.UseRule.BtnChosenMoveUI/OnClick>
struct VP_1_t3195246530;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.UseRule.BtnChosenMoveUI/UIData
struct  UIData_t2100714871  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Chess.ChessMove>> Chess.UseRule.BtnChosenMoveUI/UIData::chessMove
	VP_1_t1120350438 * ___chessMove_5;
	// VP`1<Chess.UseRule.BtnChosenMoveUI/OnClick> Chess.UseRule.BtnChosenMoveUI/UIData::onClick
	VP_1_t3195246530 * ___onClick_6;

public:
	inline static int32_t get_offset_of_chessMove_5() { return static_cast<int32_t>(offsetof(UIData_t2100714871, ___chessMove_5)); }
	inline VP_1_t1120350438 * get_chessMove_5() const { return ___chessMove_5; }
	inline VP_1_t1120350438 ** get_address_of_chessMove_5() { return &___chessMove_5; }
	inline void set_chessMove_5(VP_1_t1120350438 * value)
	{
		___chessMove_5 = value;
		Il2CppCodeGenWriteBarrier(&___chessMove_5, value);
	}

	inline static int32_t get_offset_of_onClick_6() { return static_cast<int32_t>(offsetof(UIData_t2100714871, ___onClick_6)); }
	inline VP_1_t3195246530 * get_onClick_6() const { return ___onClick_6; }
	inline VP_1_t3195246530 ** get_address_of_onClick_6() { return &___onClick_6; }
	inline void set_onClick_6(VP_1_t3195246530 * value)
	{
		___onClick_6 = value;
		Il2CppCodeGenWriteBarrier(&___onClick_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
