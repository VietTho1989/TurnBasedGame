﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<Seirawan.Common/Piece>
struct VP_1_t3141135440;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.PieceUI/UIData
struct  UIData_t2436617765  : public Data_t3569509720
{
public:
	// VP`1<Seirawan.Common/Piece> Seirawan.PieceUI/UIData::piece
	VP_1_t3141135440 * ___piece_5;
	// VP`1<System.Int32> Seirawan.PieceUI/UIData::position
	VP_1_t2450154454 * ___position_6;

public:
	inline static int32_t get_offset_of_piece_5() { return static_cast<int32_t>(offsetof(UIData_t2436617765, ___piece_5)); }
	inline VP_1_t3141135440 * get_piece_5() const { return ___piece_5; }
	inline VP_1_t3141135440 ** get_address_of_piece_5() { return &___piece_5; }
	inline void set_piece_5(VP_1_t3141135440 * value)
	{
		___piece_5 = value;
		Il2CppCodeGenWriteBarrier(&___piece_5, value);
	}

	inline static int32_t get_offset_of_position_6() { return static_cast<int32_t>(offsetof(UIData_t2436617765, ___position_6)); }
	inline VP_1_t2450154454 * get_position_6() const { return ___position_6; }
	inline VP_1_t2450154454 ** get_address_of_position_6() { return &___position_6; }
	inline void set_position_6(VP_1_t2450154454 * value)
	{
		___position_6 = value;
		Il2CppCodeGenWriteBarrier(&___position_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
