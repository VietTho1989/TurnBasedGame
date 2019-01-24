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

// Gomoku.GomokuAI
struct  GomokuAI_t659432066  : public AI_t3403267224
{
public:
	// VP`1<System.Int32> Gomoku.GomokuAI::searchDepth
	VP_1_t2450154454 * ___searchDepth_5;
	// VP`1<System.Int32> Gomoku.GomokuAI::timeLimit
	VP_1_t2450154454 * ___timeLimit_6;
	// VP`1<System.Int32> Gomoku.GomokuAI::level
	VP_1_t2450154454 * ___level_7;

public:
	inline static int32_t get_offset_of_searchDepth_5() { return static_cast<int32_t>(offsetof(GomokuAI_t659432066, ___searchDepth_5)); }
	inline VP_1_t2450154454 * get_searchDepth_5() const { return ___searchDepth_5; }
	inline VP_1_t2450154454 ** get_address_of_searchDepth_5() { return &___searchDepth_5; }
	inline void set_searchDepth_5(VP_1_t2450154454 * value)
	{
		___searchDepth_5 = value;
		Il2CppCodeGenWriteBarrier(&___searchDepth_5, value);
	}

	inline static int32_t get_offset_of_timeLimit_6() { return static_cast<int32_t>(offsetof(GomokuAI_t659432066, ___timeLimit_6)); }
	inline VP_1_t2450154454 * get_timeLimit_6() const { return ___timeLimit_6; }
	inline VP_1_t2450154454 ** get_address_of_timeLimit_6() { return &___timeLimit_6; }
	inline void set_timeLimit_6(VP_1_t2450154454 * value)
	{
		___timeLimit_6 = value;
		Il2CppCodeGenWriteBarrier(&___timeLimit_6, value);
	}

	inline static int32_t get_offset_of_level_7() { return static_cast<int32_t>(offsetof(GomokuAI_t659432066, ___level_7)); }
	inline VP_1_t2450154454 * get_level_7() const { return ___level_7; }
	inline VP_1_t2450154454 ** get_address_of_level_7() { return &___level_7; }
	inline void set_level_7(VP_1_t2450154454 * value)
	{
		___level_7 = value;
		Il2CppCodeGenWriteBarrier(&___level_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
