#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Reversi_NoneRuleInputUI_UIData_Su470629328.h"

// VP`1<System.SByte>
struct VP_1_t832694555;
// VP`1<Reversi.NoneRule.ChoosePieceAdapter/UIData>
struct VP_1_t3541211803;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.NoneRule.SetPieceUI/UIData
struct  UIData_t4254884457  : public Sub_t470629328
{
public:
	// VP`1<System.SByte> Reversi.NoneRule.SetPieceUI/UIData::square
	VP_1_t832694555 * ___square_5;
	// VP`1<Reversi.NoneRule.ChoosePieceAdapter/UIData> Reversi.NoneRule.SetPieceUI/UIData::choosePieceAdapter
	VP_1_t3541211803 * ___choosePieceAdapter_6;

public:
	inline static int32_t get_offset_of_square_5() { return static_cast<int32_t>(offsetof(UIData_t4254884457, ___square_5)); }
	inline VP_1_t832694555 * get_square_5() const { return ___square_5; }
	inline VP_1_t832694555 ** get_address_of_square_5() { return &___square_5; }
	inline void set_square_5(VP_1_t832694555 * value)
	{
		___square_5 = value;
		Il2CppCodeGenWriteBarrier(&___square_5, value);
	}

	inline static int32_t get_offset_of_choosePieceAdapter_6() { return static_cast<int32_t>(offsetof(UIData_t4254884457, ___choosePieceAdapter_6)); }
	inline VP_1_t3541211803 * get_choosePieceAdapter_6() const { return ___choosePieceAdapter_6; }
	inline VP_1_t3541211803 ** get_address_of_choosePieceAdapter_6() { return &___choosePieceAdapter_6; }
	inline void set_choosePieceAdapter_6(VP_1_t3541211803 * value)
	{
		___choosePieceAdapter_6 = value;
		Il2CppCodeGenWriteBarrier(&___choosePieceAdapter_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
