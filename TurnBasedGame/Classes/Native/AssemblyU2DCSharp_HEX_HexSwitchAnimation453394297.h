#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_MoveAnimation3061523661.h"

// VP`1<System.UInt16>
struct VP_1_t1365159617;
// LP`1<System.SByte>
struct LP_1_t3487128801;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.HexSwitchAnimation
struct  HexSwitchAnimation_t453394297  : public MoveAnimation_t3061523661
{
public:
	// VP`1<System.UInt16> HEX.HexSwitchAnimation::boardSize
	VP_1_t1365159617 * ___boardSize_5;
	// LP`1<System.SByte> HEX.HexSwitchAnimation::board
	LP_1_t3487128801 * ___board_6;

public:
	inline static int32_t get_offset_of_boardSize_5() { return static_cast<int32_t>(offsetof(HexSwitchAnimation_t453394297, ___boardSize_5)); }
	inline VP_1_t1365159617 * get_boardSize_5() const { return ___boardSize_5; }
	inline VP_1_t1365159617 ** get_address_of_boardSize_5() { return &___boardSize_5; }
	inline void set_boardSize_5(VP_1_t1365159617 * value)
	{
		___boardSize_5 = value;
		Il2CppCodeGenWriteBarrier(&___boardSize_5, value);
	}

	inline static int32_t get_offset_of_board_6() { return static_cast<int32_t>(offsetof(HexSwitchAnimation_t453394297, ___board_6)); }
	inline LP_1_t3487128801 * get_board_6() const { return ___board_6; }
	inline LP_1_t3487128801 ** get_address_of_board_6() { return &___board_6; }
	inline void set_board_6(LP_1_t3487128801 * value)
	{
		___board_6 = value;
		Il2CppCodeGenWriteBarrier(&___board_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
