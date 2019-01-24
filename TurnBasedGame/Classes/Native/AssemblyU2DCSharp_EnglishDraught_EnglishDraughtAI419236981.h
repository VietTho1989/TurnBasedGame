#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Computer_AI3403267224.h"

// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<System.Single>
struct VP_1_t2454786938;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.EnglishDraughtAI
struct  EnglishDraughtAI_t419236981  : public AI_t3403267224
{
public:
	// VP`1<System.Boolean> EnglishDraught.EnglishDraughtAI::threeMoveRandom
	VP_1_t4203851724 * ___threeMoveRandom_5;
	// VP`1<System.Single> EnglishDraught.EnglishDraughtAI::fMaxSeconds
	VP_1_t2454786938 * ___fMaxSeconds_6;
	// VP`1<System.Int32> EnglishDraught.EnglishDraughtAI::g_MaxDepth
	VP_1_t2450154454 * ___g_MaxDepth_7;
	// VP`1<System.Int32> EnglishDraught.EnglishDraughtAI::pickBestMove
	VP_1_t2450154454 * ___pickBestMove_8;

public:
	inline static int32_t get_offset_of_threeMoveRandom_5() { return static_cast<int32_t>(offsetof(EnglishDraughtAI_t419236981, ___threeMoveRandom_5)); }
	inline VP_1_t4203851724 * get_threeMoveRandom_5() const { return ___threeMoveRandom_5; }
	inline VP_1_t4203851724 ** get_address_of_threeMoveRandom_5() { return &___threeMoveRandom_5; }
	inline void set_threeMoveRandom_5(VP_1_t4203851724 * value)
	{
		___threeMoveRandom_5 = value;
		Il2CppCodeGenWriteBarrier(&___threeMoveRandom_5, value);
	}

	inline static int32_t get_offset_of_fMaxSeconds_6() { return static_cast<int32_t>(offsetof(EnglishDraughtAI_t419236981, ___fMaxSeconds_6)); }
	inline VP_1_t2454786938 * get_fMaxSeconds_6() const { return ___fMaxSeconds_6; }
	inline VP_1_t2454786938 ** get_address_of_fMaxSeconds_6() { return &___fMaxSeconds_6; }
	inline void set_fMaxSeconds_6(VP_1_t2454786938 * value)
	{
		___fMaxSeconds_6 = value;
		Il2CppCodeGenWriteBarrier(&___fMaxSeconds_6, value);
	}

	inline static int32_t get_offset_of_g_MaxDepth_7() { return static_cast<int32_t>(offsetof(EnglishDraughtAI_t419236981, ___g_MaxDepth_7)); }
	inline VP_1_t2450154454 * get_g_MaxDepth_7() const { return ___g_MaxDepth_7; }
	inline VP_1_t2450154454 ** get_address_of_g_MaxDepth_7() { return &___g_MaxDepth_7; }
	inline void set_g_MaxDepth_7(VP_1_t2450154454 * value)
	{
		___g_MaxDepth_7 = value;
		Il2CppCodeGenWriteBarrier(&___g_MaxDepth_7, value);
	}

	inline static int32_t get_offset_of_pickBestMove_8() { return static_cast<int32_t>(offsetof(EnglishDraughtAI_t419236981, ___pickBestMove_8)); }
	inline VP_1_t2450154454 * get_pickBestMove_8() const { return ___pickBestMove_8; }
	inline VP_1_t2450154454 ** get_address_of_pickBestMove_8() { return &___pickBestMove_8; }
	inline void set_pickBestMove_8(VP_1_t2450154454 * value)
	{
		___pickBestMove_8 = value;
		Il2CppCodeGenWriteBarrier(&___pickBestMove_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
