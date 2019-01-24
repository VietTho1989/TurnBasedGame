#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Shogi.ShogiMove>>
struct VP_1_t4150035994;
// VP`1<Shogi.UseRule.BtnChosenMoveUI/OnClick>
struct VP_1_t2324336062;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.UseRule.BtnChosenMoveUI/UIData
struct  UIData_t3722679539  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Shogi.ShogiMove>> Shogi.UseRule.BtnChosenMoveUI/UIData::shogiMove
	VP_1_t4150035994 * ___shogiMove_5;
	// VP`1<Shogi.UseRule.BtnChosenMoveUI/OnClick> Shogi.UseRule.BtnChosenMoveUI/UIData::onClick
	VP_1_t2324336062 * ___onClick_6;

public:
	inline static int32_t get_offset_of_shogiMove_5() { return static_cast<int32_t>(offsetof(UIData_t3722679539, ___shogiMove_5)); }
	inline VP_1_t4150035994 * get_shogiMove_5() const { return ___shogiMove_5; }
	inline VP_1_t4150035994 ** get_address_of_shogiMove_5() { return &___shogiMove_5; }
	inline void set_shogiMove_5(VP_1_t4150035994 * value)
	{
		___shogiMove_5 = value;
		Il2CppCodeGenWriteBarrier(&___shogiMove_5, value);
	}

	inline static int32_t get_offset_of_onClick_6() { return static_cast<int32_t>(offsetof(UIData_t3722679539, ___onClick_6)); }
	inline VP_1_t2324336062 * get_onClick_6() const { return ___onClick_6; }
	inline VP_1_t2324336062 ** get_address_of_onClick_6() { return &___onClick_6; }
	inline void set_onClick_6(VP_1_t2324336062 * value)
	{
		___onClick_6 = value;
		Il2CppCodeGenWriteBarrier(&___onClick_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
