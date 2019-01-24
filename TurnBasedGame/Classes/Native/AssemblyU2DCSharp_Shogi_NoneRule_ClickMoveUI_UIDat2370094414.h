#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Shogi_NoneRuleInputUI_UIData_Sub1918934690.h"

// VP`1<Shogi.Common/Square>
struct VP_1_t567270415;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.ClickMoveUI/UIData
struct  UIData_t2370094414  : public Sub_t1918934690
{
public:
	// VP`1<Shogi.Common/Square> Shogi.NoneRule.ClickMoveUI/UIData::square
	VP_1_t567270415 * ___square_5;

public:
	inline static int32_t get_offset_of_square_5() { return static_cast<int32_t>(offsetof(UIData_t2370094414, ___square_5)); }
	inline VP_1_t567270415 * get_square_5() const { return ___square_5; }
	inline VP_1_t567270415 ** get_address_of_square_5() { return &___square_5; }
	inline void set_square_5(VP_1_t567270415 * value)
	{
		___square_5 = value;
		Il2CppCodeGenWriteBarrier(&___square_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
