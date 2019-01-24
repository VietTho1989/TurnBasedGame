#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// LP`1<MoveAnimation>
struct LP_1_t1799267617;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AnimationData
struct  AnimationData_t1696983510  : public Data_t3569509720
{
public:
	// LP`1<MoveAnimation> AnimationData::moveAnimations
	LP_1_t1799267617 * ___moveAnimations_5;

public:
	inline static int32_t get_offset_of_moveAnimations_5() { return static_cast<int32_t>(offsetof(AnimationData_t1696983510, ___moveAnimations_5)); }
	inline LP_1_t1799267617 * get_moveAnimations_5() const { return ___moveAnimations_5; }
	inline LP_1_t1799267617 ** get_address_of_moveAnimations_5() { return &___moveAnimations_5; }
	inline void set_moveAnimations_5(LP_1_t1799267617 * value)
	{
		___moveAnimations_5 = value;
		Il2CppCodeGenWriteBarrier(&___moveAnimations_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
