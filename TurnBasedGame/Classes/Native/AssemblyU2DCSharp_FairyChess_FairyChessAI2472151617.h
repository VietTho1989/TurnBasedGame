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
// VP`1<System.Int64>
struct VP_1_t1287355043;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.FairyChessAI
struct  FairyChessAI_t2472151617  : public AI_t3403267224
{
public:
	// VP`1<System.Int32> FairyChess.FairyChessAI::depth
	VP_1_t2450154454 * ___depth_5;
	// VP`1<System.Int32> FairyChess.FairyChessAI::skillLevel
	VP_1_t2450154454 * ___skillLevel_6;
	// VP`1<System.Int64> FairyChess.FairyChessAI::duration
	VP_1_t1287355043 * ___duration_7;

public:
	inline static int32_t get_offset_of_depth_5() { return static_cast<int32_t>(offsetof(FairyChessAI_t2472151617, ___depth_5)); }
	inline VP_1_t2450154454 * get_depth_5() const { return ___depth_5; }
	inline VP_1_t2450154454 ** get_address_of_depth_5() { return &___depth_5; }
	inline void set_depth_5(VP_1_t2450154454 * value)
	{
		___depth_5 = value;
		Il2CppCodeGenWriteBarrier(&___depth_5, value);
	}

	inline static int32_t get_offset_of_skillLevel_6() { return static_cast<int32_t>(offsetof(FairyChessAI_t2472151617, ___skillLevel_6)); }
	inline VP_1_t2450154454 * get_skillLevel_6() const { return ___skillLevel_6; }
	inline VP_1_t2450154454 ** get_address_of_skillLevel_6() { return &___skillLevel_6; }
	inline void set_skillLevel_6(VP_1_t2450154454 * value)
	{
		___skillLevel_6 = value;
		Il2CppCodeGenWriteBarrier(&___skillLevel_6, value);
	}

	inline static int32_t get_offset_of_duration_7() { return static_cast<int32_t>(offsetof(FairyChessAI_t2472151617, ___duration_7)); }
	inline VP_1_t1287355043 * get_duration_7() const { return ___duration_7; }
	inline VP_1_t1287355043 ** get_address_of_duration_7() { return &___duration_7; }
	inline void set_duration_7(VP_1_t1287355043 * value)
	{
		___duration_7 = value;
		Il2CppCodeGenWriteBarrier(&___duration_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
