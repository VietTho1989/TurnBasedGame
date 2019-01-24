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

// Xiangqi.XiangqiAI
struct  XiangqiAI_t2935256521  : public AI_t3403267224
{
public:
	// VP`1<System.Int32> Xiangqi.XiangqiAI::depth
	VP_1_t2450154454 * ___depth_5;
	// VP`1<System.Int32> Xiangqi.XiangqiAI::thinkTime
	VP_1_t2450154454 * ___thinkTime_6;
	// VP`1<System.Boolean> Xiangqi.XiangqiAI::useBook
	VP_1_t4203851724 * ___useBook_7;
	// VP`1<System.Int32> Xiangqi.XiangqiAI::pickBestMove
	VP_1_t2450154454 * ___pickBestMove_8;

public:
	inline static int32_t get_offset_of_depth_5() { return static_cast<int32_t>(offsetof(XiangqiAI_t2935256521, ___depth_5)); }
	inline VP_1_t2450154454 * get_depth_5() const { return ___depth_5; }
	inline VP_1_t2450154454 ** get_address_of_depth_5() { return &___depth_5; }
	inline void set_depth_5(VP_1_t2450154454 * value)
	{
		___depth_5 = value;
		Il2CppCodeGenWriteBarrier(&___depth_5, value);
	}

	inline static int32_t get_offset_of_thinkTime_6() { return static_cast<int32_t>(offsetof(XiangqiAI_t2935256521, ___thinkTime_6)); }
	inline VP_1_t2450154454 * get_thinkTime_6() const { return ___thinkTime_6; }
	inline VP_1_t2450154454 ** get_address_of_thinkTime_6() { return &___thinkTime_6; }
	inline void set_thinkTime_6(VP_1_t2450154454 * value)
	{
		___thinkTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___thinkTime_6, value);
	}

	inline static int32_t get_offset_of_useBook_7() { return static_cast<int32_t>(offsetof(XiangqiAI_t2935256521, ___useBook_7)); }
	inline VP_1_t4203851724 * get_useBook_7() const { return ___useBook_7; }
	inline VP_1_t4203851724 ** get_address_of_useBook_7() { return &___useBook_7; }
	inline void set_useBook_7(VP_1_t4203851724 * value)
	{
		___useBook_7 = value;
		Il2CppCodeGenWriteBarrier(&___useBook_7, value);
	}

	inline static int32_t get_offset_of_pickBestMove_8() { return static_cast<int32_t>(offsetof(XiangqiAI_t2935256521, ___pickBestMove_8)); }
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
