#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<Shogi.Common/Square>
struct VP_1_t567270415;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.ShogiCustomMove
struct  ShogiCustomMove_t1986382680  : public GameMove_t1861898997
{
public:
	// VP`1<Shogi.Common/Square> Shogi.NoneRule.ShogiCustomMove::from
	VP_1_t567270415 * ___from_5;
	// VP`1<Shogi.Common/Square> Shogi.NoneRule.ShogiCustomMove::dest
	VP_1_t567270415 * ___dest_6;

public:
	inline static int32_t get_offset_of_from_5() { return static_cast<int32_t>(offsetof(ShogiCustomMove_t1986382680, ___from_5)); }
	inline VP_1_t567270415 * get_from_5() const { return ___from_5; }
	inline VP_1_t567270415 ** get_address_of_from_5() { return &___from_5; }
	inline void set_from_5(VP_1_t567270415 * value)
	{
		___from_5 = value;
		Il2CppCodeGenWriteBarrier(&___from_5, value);
	}

	inline static int32_t get_offset_of_dest_6() { return static_cast<int32_t>(offsetof(ShogiCustomMove_t1986382680, ___dest_6)); }
	inline VP_1_t567270415 * get_dest_6() const { return ___dest_6; }
	inline VP_1_t567270415 ** get_address_of_dest_6() { return &___dest_6; }
	inline void set_dest_6(VP_1_t567270415 * value)
	{
		___dest_6 = value;
		Il2CppCodeGenWriteBarrier(&___dest_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
