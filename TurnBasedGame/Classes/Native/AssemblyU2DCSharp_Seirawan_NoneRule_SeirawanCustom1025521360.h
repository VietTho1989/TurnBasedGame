#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<Seirawan.Common/Piece>
struct VP_1_t3141135440;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.NoneRule.SeirawanCustomHand
struct  SeirawanCustomHand_t1025521360  : public GameMove_t1861898997
{
public:
	// VP`1<Seirawan.Common/Piece> Seirawan.NoneRule.SeirawanCustomHand::piece
	VP_1_t3141135440 * ___piece_5;

public:
	inline static int32_t get_offset_of_piece_5() { return static_cast<int32_t>(offsetof(SeirawanCustomHand_t1025521360, ___piece_5)); }
	inline VP_1_t3141135440 * get_piece_5() const { return ___piece_5; }
	inline VP_1_t3141135440 ** get_address_of_piece_5() { return &___piece_5; }
	inline void set_piece_5(VP_1_t3141135440 * value)
	{
		___piece_5 = value;
		Il2CppCodeGenWriteBarrier(&___piece_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
