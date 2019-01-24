#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Computer_AI3403267224.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.RussianDraughtAI
struct  RussianDraughtAI_t94446166  : public AI_t3403267224
{
public:
	// VP`1<System.Int32> RussianDraught.RussianDraughtAI::timeLimit
	VP_1_t2450154454 * ___timeLimit_5;
	// VP`1<System.Int32> RussianDraught.RussianDraughtAI::pickBestMove
	VP_1_t2450154454 * ___pickBestMove_6;

public:
	inline static int32_t get_offset_of_timeLimit_5() { return static_cast<int32_t>(offsetof(RussianDraughtAI_t94446166, ___timeLimit_5)); }
	inline VP_1_t2450154454 * get_timeLimit_5() const { return ___timeLimit_5; }
	inline VP_1_t2450154454 ** get_address_of_timeLimit_5() { return &___timeLimit_5; }
	inline void set_timeLimit_5(VP_1_t2450154454 * value)
	{
		___timeLimit_5 = value;
		Il2CppCodeGenWriteBarrier(&___timeLimit_5, value);
	}

	inline static int32_t get_offset_of_pickBestMove_6() { return static_cast<int32_t>(offsetof(RussianDraughtAI_t94446166, ___pickBestMove_6)); }
	inline VP_1_t2450154454 * get_pickBestMove_6() const { return ___pickBestMove_6; }
	inline VP_1_t2450154454 ** get_address_of_pickBestMove_6() { return &___pickBestMove_6; }
	inline void set_pickBestMove_6(VP_1_t2450154454 * value)
	{
		___pickBestMove_6 = value;
		Il2CppCodeGenWriteBarrier(&___pickBestMove_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
