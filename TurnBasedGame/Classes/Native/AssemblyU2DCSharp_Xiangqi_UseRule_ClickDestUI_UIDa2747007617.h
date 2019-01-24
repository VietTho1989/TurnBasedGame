#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Xiangqi_UseRule_ShowUI_UIData_Su2187147913.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<Xiangqi.UseRule.LegalMoveUI/UIData>
struct LP_1_t1513822091;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.UseRule.ClickDestUI/UIData
struct  UIData_t2747007617  : public Sub_t2187147913
{
public:
	// VP`1<System.Int32> Xiangqi.UseRule.ClickDestUI/UIData::x
	VP_1_t2450154454 * ___x_5;
	// VP`1<System.Int32> Xiangqi.UseRule.ClickDestUI/UIData::y
	VP_1_t2450154454 * ___y_6;
	// LP`1<Xiangqi.UseRule.LegalMoveUI/UIData> Xiangqi.UseRule.ClickDestUI/UIData::legalMoves
	LP_1_t1513822091 * ___legalMoves_7;

public:
	inline static int32_t get_offset_of_x_5() { return static_cast<int32_t>(offsetof(UIData_t2747007617, ___x_5)); }
	inline VP_1_t2450154454 * get_x_5() const { return ___x_5; }
	inline VP_1_t2450154454 ** get_address_of_x_5() { return &___x_5; }
	inline void set_x_5(VP_1_t2450154454 * value)
	{
		___x_5 = value;
		Il2CppCodeGenWriteBarrier(&___x_5, value);
	}

	inline static int32_t get_offset_of_y_6() { return static_cast<int32_t>(offsetof(UIData_t2747007617, ___y_6)); }
	inline VP_1_t2450154454 * get_y_6() const { return ___y_6; }
	inline VP_1_t2450154454 ** get_address_of_y_6() { return &___y_6; }
	inline void set_y_6(VP_1_t2450154454 * value)
	{
		___y_6 = value;
		Il2CppCodeGenWriteBarrier(&___y_6, value);
	}

	inline static int32_t get_offset_of_legalMoves_7() { return static_cast<int32_t>(offsetof(UIData_t2747007617, ___legalMoves_7)); }
	inline LP_1_t1513822091 * get_legalMoves_7() const { return ___legalMoves_7; }
	inline LP_1_t1513822091 ** get_address_of_legalMoves_7() { return &___legalMoves_7; }
	inline void set_legalMoves_7(LP_1_t1513822091 * value)
	{
		___legalMoves_7 = value;
		Il2CppCodeGenWriteBarrier(&___legalMoves_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
