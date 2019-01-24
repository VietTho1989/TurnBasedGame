#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<System.SByte>
struct VP_1_t832694555;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.ReversiMove
struct  ReversiMove_t498602839  : public GameMove_t1861898997
{
public:
	// VP`1<System.SByte> Reversi.ReversiMove::move
	VP_1_t832694555 * ___move_5;

public:
	inline static int32_t get_offset_of_move_5() { return static_cast<int32_t>(offsetof(ReversiMove_t498602839, ___move_5)); }
	inline VP_1_t832694555 * get_move_5() const { return ___move_5; }
	inline VP_1_t832694555 ** get_address_of_move_5() { return &___move_5; }
	inline void set_move_5(VP_1_t832694555 * value)
	{
		___move_5 = value;
		Il2CppCodeGenWriteBarrier(&___move_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
