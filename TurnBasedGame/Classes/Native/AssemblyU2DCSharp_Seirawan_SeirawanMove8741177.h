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
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.SeirawanMove
struct  SeirawanMove_t8741177  : public GameMove_t1861898997
{
public:
	// VP`1<System.Int32> Seirawan.SeirawanMove::move
	VP_1_t2450154454 * ___move_5;
	// VP`1<System.Boolean> Seirawan.SeirawanMove::chess960
	VP_1_t4203851724 * ___chess960_6;

public:
	inline static int32_t get_offset_of_move_5() { return static_cast<int32_t>(offsetof(SeirawanMove_t8741177, ___move_5)); }
	inline VP_1_t2450154454 * get_move_5() const { return ___move_5; }
	inline VP_1_t2450154454 ** get_address_of_move_5() { return &___move_5; }
	inline void set_move_5(VP_1_t2450154454 * value)
	{
		___move_5 = value;
		Il2CppCodeGenWriteBarrier(&___move_5, value);
	}

	inline static int32_t get_offset_of_chess960_6() { return static_cast<int32_t>(offsetof(SeirawanMove_t8741177, ___chess960_6)); }
	inline VP_1_t4203851724 * get_chess960_6() const { return ___chess960_6; }
	inline VP_1_t4203851724 ** get_address_of_chess960_6() { return &___chess960_6; }
	inline void set_chess960_6(VP_1_t4203851724 * value)
	{
		___chess960_6 = value;
		Il2CppCodeGenWriteBarrier(&___chess960_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
