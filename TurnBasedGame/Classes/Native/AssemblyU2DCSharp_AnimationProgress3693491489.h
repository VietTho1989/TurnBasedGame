#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Single>
struct VP_1_t2454786938;
// VP`1<ReferenceData`1<MoveAnimation>>
struct VP_1_t2510583730;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AnimationProgress
struct  AnimationProgress_t3693491489  : public Data_t3569509720
{
public:
	// VP`1<System.Single> AnimationProgress::time
	VP_1_t2454786938 * ___time_5;
	// VP`1<System.Single> AnimationProgress::duration
	VP_1_t2454786938 * ___duration_6;
	// VP`1<ReferenceData`1<MoveAnimation>> AnimationProgress::moveAnimation
	VP_1_t2510583730 * ___moveAnimation_7;
	// System.Boolean AnimationProgress::isReverse
	bool ___isReverse_8;

public:
	inline static int32_t get_offset_of_time_5() { return static_cast<int32_t>(offsetof(AnimationProgress_t3693491489, ___time_5)); }
	inline VP_1_t2454786938 * get_time_5() const { return ___time_5; }
	inline VP_1_t2454786938 ** get_address_of_time_5() { return &___time_5; }
	inline void set_time_5(VP_1_t2454786938 * value)
	{
		___time_5 = value;
		Il2CppCodeGenWriteBarrier(&___time_5, value);
	}

	inline static int32_t get_offset_of_duration_6() { return static_cast<int32_t>(offsetof(AnimationProgress_t3693491489, ___duration_6)); }
	inline VP_1_t2454786938 * get_duration_6() const { return ___duration_6; }
	inline VP_1_t2454786938 ** get_address_of_duration_6() { return &___duration_6; }
	inline void set_duration_6(VP_1_t2454786938 * value)
	{
		___duration_6 = value;
		Il2CppCodeGenWriteBarrier(&___duration_6, value);
	}

	inline static int32_t get_offset_of_moveAnimation_7() { return static_cast<int32_t>(offsetof(AnimationProgress_t3693491489, ___moveAnimation_7)); }
	inline VP_1_t2510583730 * get_moveAnimation_7() const { return ___moveAnimation_7; }
	inline VP_1_t2510583730 ** get_address_of_moveAnimation_7() { return &___moveAnimation_7; }
	inline void set_moveAnimation_7(VP_1_t2510583730 * value)
	{
		___moveAnimation_7 = value;
		Il2CppCodeGenWriteBarrier(&___moveAnimation_7, value);
	}

	inline static int32_t get_offset_of_isReverse_8() { return static_cast<int32_t>(offsetof(AnimationProgress_t3693491489, ___isReverse_8)); }
	inline bool get_isReverse_8() const { return ___isReverse_8; }
	inline bool* get_address_of_isReverse_8() { return &___isReverse_8; }
	inline void set_isReverse_8(bool value)
	{
		___isReverse_8 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
