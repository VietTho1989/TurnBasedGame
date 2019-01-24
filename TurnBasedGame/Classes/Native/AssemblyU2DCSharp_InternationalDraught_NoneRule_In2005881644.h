#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<InternationalDraught.Common/Piece_Side>
struct VP_1_t4006974121;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.NoneRule.InternationalDraughtCustomSet
struct  InternationalDraughtCustomSet_t2005881644  : public GameMove_t1861898997
{
public:
	// VP`1<System.Int32> InternationalDraught.NoneRule.InternationalDraughtCustomSet::square
	VP_1_t2450154454 * ___square_5;
	// VP`1<InternationalDraught.Common/Piece_Side> InternationalDraught.NoneRule.InternationalDraughtCustomSet::pieceSide
	VP_1_t4006974121 * ___pieceSide_6;

public:
	inline static int32_t get_offset_of_square_5() { return static_cast<int32_t>(offsetof(InternationalDraughtCustomSet_t2005881644, ___square_5)); }
	inline VP_1_t2450154454 * get_square_5() const { return ___square_5; }
	inline VP_1_t2450154454 ** get_address_of_square_5() { return &___square_5; }
	inline void set_square_5(VP_1_t2450154454 * value)
	{
		___square_5 = value;
		Il2CppCodeGenWriteBarrier(&___square_5, value);
	}

	inline static int32_t get_offset_of_pieceSide_6() { return static_cast<int32_t>(offsetof(InternationalDraughtCustomSet_t2005881644, ___pieceSide_6)); }
	inline VP_1_t4006974121 * get_pieceSide_6() const { return ___pieceSide_6; }
	inline VP_1_t4006974121 ** get_address_of_pieceSide_6() { return &___pieceSide_6; }
	inline void set_pieceSide_6(VP_1_t4006974121 * value)
	{
		___pieceSide_6 = value;
		Il2CppCodeGenWriteBarrier(&___pieceSide_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
