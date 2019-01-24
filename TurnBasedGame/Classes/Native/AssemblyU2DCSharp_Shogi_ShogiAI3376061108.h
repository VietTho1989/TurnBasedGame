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
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ShogiAI
struct  ShogiAI_t3376061108  : public AI_t3403267224
{
public:
	// VP`1<System.Int32> Shogi.ShogiAI::depth
	VP_1_t2450154454 * ___depth_5;
	// VP`1<System.Int32> Shogi.ShogiAI::skillLevel
	VP_1_t2450154454 * ___skillLevel_6;
	// VP`1<System.Int32> Shogi.ShogiAI::mr
	VP_1_t2450154454 * ___mr_7;
	// VP`1<System.Int32> Shogi.ShogiAI::duration
	VP_1_t2450154454 * ___duration_8;
	// VP`1<System.Boolean> Shogi.ShogiAI::useBook
	VP_1_t4203851724 * ___useBook_9;

public:
	inline static int32_t get_offset_of_depth_5() { return static_cast<int32_t>(offsetof(ShogiAI_t3376061108, ___depth_5)); }
	inline VP_1_t2450154454 * get_depth_5() const { return ___depth_5; }
	inline VP_1_t2450154454 ** get_address_of_depth_5() { return &___depth_5; }
	inline void set_depth_5(VP_1_t2450154454 * value)
	{
		___depth_5 = value;
		Il2CppCodeGenWriteBarrier(&___depth_5, value);
	}

	inline static int32_t get_offset_of_skillLevel_6() { return static_cast<int32_t>(offsetof(ShogiAI_t3376061108, ___skillLevel_6)); }
	inline VP_1_t2450154454 * get_skillLevel_6() const { return ___skillLevel_6; }
	inline VP_1_t2450154454 ** get_address_of_skillLevel_6() { return &___skillLevel_6; }
	inline void set_skillLevel_6(VP_1_t2450154454 * value)
	{
		___skillLevel_6 = value;
		Il2CppCodeGenWriteBarrier(&___skillLevel_6, value);
	}

	inline static int32_t get_offset_of_mr_7() { return static_cast<int32_t>(offsetof(ShogiAI_t3376061108, ___mr_7)); }
	inline VP_1_t2450154454 * get_mr_7() const { return ___mr_7; }
	inline VP_1_t2450154454 ** get_address_of_mr_7() { return &___mr_7; }
	inline void set_mr_7(VP_1_t2450154454 * value)
	{
		___mr_7 = value;
		Il2CppCodeGenWriteBarrier(&___mr_7, value);
	}

	inline static int32_t get_offset_of_duration_8() { return static_cast<int32_t>(offsetof(ShogiAI_t3376061108, ___duration_8)); }
	inline VP_1_t2450154454 * get_duration_8() const { return ___duration_8; }
	inline VP_1_t2450154454 ** get_address_of_duration_8() { return &___duration_8; }
	inline void set_duration_8(VP_1_t2450154454 * value)
	{
		___duration_8 = value;
		Il2CppCodeGenWriteBarrier(&___duration_8, value);
	}

	inline static int32_t get_offset_of_useBook_9() { return static_cast<int32_t>(offsetof(ShogiAI_t3376061108, ___useBook_9)); }
	inline VP_1_t4203851724 * get_useBook_9() const { return ___useBook_9; }
	inline VP_1_t4203851724 ** get_address_of_useBook_9() { return &___useBook_9; }
	inline void set_useBook_9(VP_1_t4203851724 * value)
	{
		___useBook_9 = value;
		Il2CppCodeGenWriteBarrier(&___useBook_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
