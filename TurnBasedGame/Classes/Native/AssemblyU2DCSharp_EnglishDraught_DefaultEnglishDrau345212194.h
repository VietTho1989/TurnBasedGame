#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DefaultGameType1641020183.h"

// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.DefaultEnglishDraught
struct  DefaultEnglishDraught_t345212194  : public DefaultGameType_t1641020183
{
public:
	// VP`1<System.Boolean> EnglishDraught.DefaultEnglishDraught::threeMoveRandom
	VP_1_t4203851724 * ___threeMoveRandom_5;
	// VP`1<System.Int32> EnglishDraught.DefaultEnglishDraught::maxPly
	VP_1_t2450154454 * ___maxPly_6;

public:
	inline static int32_t get_offset_of_threeMoveRandom_5() { return static_cast<int32_t>(offsetof(DefaultEnglishDraught_t345212194, ___threeMoveRandom_5)); }
	inline VP_1_t4203851724 * get_threeMoveRandom_5() const { return ___threeMoveRandom_5; }
	inline VP_1_t4203851724 ** get_address_of_threeMoveRandom_5() { return &___threeMoveRandom_5; }
	inline void set_threeMoveRandom_5(VP_1_t4203851724 * value)
	{
		___threeMoveRandom_5 = value;
		Il2CppCodeGenWriteBarrier(&___threeMoveRandom_5, value);
	}

	inline static int32_t get_offset_of_maxPly_6() { return static_cast<int32_t>(offsetof(DefaultEnglishDraught_t345212194, ___maxPly_6)); }
	inline VP_1_t2450154454 * get_maxPly_6() const { return ___maxPly_6; }
	inline VP_1_t2450154454 ** get_address_of_maxPly_6() { return &___maxPly_6; }
	inline void set_maxPly_6(VP_1_t2450154454 * value)
	{
		___maxPly_6 = value;
		Il2CppCodeGenWriteBarrier(&___maxPly_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
