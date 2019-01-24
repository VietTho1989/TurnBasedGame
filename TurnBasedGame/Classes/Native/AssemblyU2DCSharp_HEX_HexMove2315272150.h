#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<System.UInt16>
struct VP_1_t1365159617;
// VP`1<HEX.Common/Color>
struct VP_1_t3405266990;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.HexMove
struct  HexMove_t2315272150  : public GameMove_t1861898997
{
public:
	// VP`1<System.UInt16> HEX.HexMove::move
	VP_1_t1365159617 * ___move_5;
	// VP`1<System.UInt16> HEX.HexMove::boardSize
	VP_1_t1365159617 * ___boardSize_6;
	// VP`1<HEX.Common/Color> HEX.HexMove::color
	VP_1_t3405266990 * ___color_7;

public:
	inline static int32_t get_offset_of_move_5() { return static_cast<int32_t>(offsetof(HexMove_t2315272150, ___move_5)); }
	inline VP_1_t1365159617 * get_move_5() const { return ___move_5; }
	inline VP_1_t1365159617 ** get_address_of_move_5() { return &___move_5; }
	inline void set_move_5(VP_1_t1365159617 * value)
	{
		___move_5 = value;
		Il2CppCodeGenWriteBarrier(&___move_5, value);
	}

	inline static int32_t get_offset_of_boardSize_6() { return static_cast<int32_t>(offsetof(HexMove_t2315272150, ___boardSize_6)); }
	inline VP_1_t1365159617 * get_boardSize_6() const { return ___boardSize_6; }
	inline VP_1_t1365159617 ** get_address_of_boardSize_6() { return &___boardSize_6; }
	inline void set_boardSize_6(VP_1_t1365159617 * value)
	{
		___boardSize_6 = value;
		Il2CppCodeGenWriteBarrier(&___boardSize_6, value);
	}

	inline static int32_t get_offset_of_color_7() { return static_cast<int32_t>(offsetof(HexMove_t2315272150, ___color_7)); }
	inline VP_1_t3405266990 * get_color_7() const { return ___color_7; }
	inline VP_1_t3405266990 ** get_address_of_color_7() { return &___color_7; }
	inline void set_color_7(VP_1_t3405266990 * value)
	{
		___color_7 = value;
		Il2CppCodeGenWriteBarrier(&___color_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
