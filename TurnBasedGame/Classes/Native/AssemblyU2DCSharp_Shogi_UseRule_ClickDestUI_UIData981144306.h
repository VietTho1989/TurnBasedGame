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
// VP`1<Shogi.UseRule.ClickDestUI/UIData/Sub>
struct VP_1_t358264415;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.UseRule.ClickDestUI/UIData
struct  UIData_t981144306  : public Sub_t3782755102
{
public:
	// VP`1<Shogi.Common/Square> Shogi.UseRule.ClickDestUI/UIData::square
	VP_1_t567270415 * ___square_5;
	// VP`1<Shogi.UseRule.ClickDestUI/UIData/Sub> Shogi.UseRule.ClickDestUI/UIData::sub
	VP_1_t358264415 * ___sub_6;

public:
	inline static int32_t get_offset_of_square_5() { return static_cast<int32_t>(offsetof(UIData_t981144306, ___square_5)); }
	inline VP_1_t567270415 * get_square_5() const { return ___square_5; }
	inline VP_1_t567270415 ** get_address_of_square_5() { return &___square_5; }
	inline void set_square_5(VP_1_t567270415 * value)
	{
		___square_5 = value;
		Il2CppCodeGenWriteBarrier(&___square_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t981144306, ___sub_6)); }
	inline VP_1_t358264415 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t358264415 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t358264415 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
