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

// HEX.HexAI
struct  HexAI_t109246293  : public AI_t3403267224
{
public:
	// VP`1<System.Int32> HEX.HexAI::limitTime
	VP_1_t2450154454 * ___limitTime_5;
	// VP`1<System.Boolean> HEX.HexAI::firstMoveCenter
	VP_1_t4203851724 * ___firstMoveCenter_6;

public:
	inline static int32_t get_offset_of_limitTime_5() { return static_cast<int32_t>(offsetof(HexAI_t109246293, ___limitTime_5)); }
	inline VP_1_t2450154454 * get_limitTime_5() const { return ___limitTime_5; }
	inline VP_1_t2450154454 ** get_address_of_limitTime_5() { return &___limitTime_5; }
	inline void set_limitTime_5(VP_1_t2450154454 * value)
	{
		___limitTime_5 = value;
		Il2CppCodeGenWriteBarrier(&___limitTime_5, value);
	}

	inline static int32_t get_offset_of_firstMoveCenter_6() { return static_cast<int32_t>(offsetof(HexAI_t109246293, ___firstMoveCenter_6)); }
	inline VP_1_t4203851724 * get_firstMoveCenter_6() const { return ___firstMoveCenter_6; }
	inline VP_1_t4203851724 ** get_address_of_firstMoveCenter_6() { return &___firstMoveCenter_6; }
	inline void set_firstMoveCenter_6(VP_1_t4203851724 * value)
	{
		___firstMoveCenter_6 = value;
		Il2CppCodeGenWriteBarrier(&___firstMoveCenter_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
