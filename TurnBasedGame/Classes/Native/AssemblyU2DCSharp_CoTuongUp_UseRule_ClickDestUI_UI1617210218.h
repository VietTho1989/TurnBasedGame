﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_CoTuongUp_UseRule_ShowUI_UIData_3996100670.h"

// VP`1<System.Byte>
struct VP_1_t4061381442;
// LP`1<CoTuongUp.UseRule.LegalMoveUI/UIData>
struct LP_1_t824200706;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.UseRule.ClickDestUI/UIData
struct  UIData_t1617210218  : public Sub_t3996100670
{
public:
	// VP`1<System.Byte> CoTuongUp.UseRule.ClickDestUI/UIData::coord
	VP_1_t4061381442 * ___coord_5;
	// LP`1<CoTuongUp.UseRule.LegalMoveUI/UIData> CoTuongUp.UseRule.ClickDestUI/UIData::legalMoves
	LP_1_t824200706 * ___legalMoves_6;

public:
	inline static int32_t get_offset_of_coord_5() { return static_cast<int32_t>(offsetof(UIData_t1617210218, ___coord_5)); }
	inline VP_1_t4061381442 * get_coord_5() const { return ___coord_5; }
	inline VP_1_t4061381442 ** get_address_of_coord_5() { return &___coord_5; }
	inline void set_coord_5(VP_1_t4061381442 * value)
	{
		___coord_5 = value;
		Il2CppCodeGenWriteBarrier(&___coord_5, value);
	}

	inline static int32_t get_offset_of_legalMoves_6() { return static_cast<int32_t>(offsetof(UIData_t1617210218, ___legalMoves_6)); }
	inline LP_1_t824200706 * get_legalMoves_6() const { return ___legalMoves_6; }
	inline LP_1_t824200706 ** get_address_of_legalMoves_6() { return &___legalMoves_6; }
	inline void set_legalMoves_6(LP_1_t824200706 * value)
	{
		___legalMoves_6 = value;
		Il2CppCodeGenWriteBarrier(&___legalMoves_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif