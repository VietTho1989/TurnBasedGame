#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1655157461.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.StepGetDataFacebookUpdate
struct  StepGetDataFacebookUpdate_t1888796599  : public UpdateBehavior_1_t1655157461
{
public:
	// AdvancedCoroutines.Routine LoginState.StepGetDataFacebookUpdate::getData
	Routine_t2502590640 * ___getData_4;
	// AdvancedCoroutines.Routine LoginState.StepGetDataFacebookUpdate::wait
	Routine_t2502590640 * ___wait_5;

public:
	inline static int32_t get_offset_of_getData_4() { return static_cast<int32_t>(offsetof(StepGetDataFacebookUpdate_t1888796599, ___getData_4)); }
	inline Routine_t2502590640 * get_getData_4() const { return ___getData_4; }
	inline Routine_t2502590640 ** get_address_of_getData_4() { return &___getData_4; }
	inline void set_getData_4(Routine_t2502590640 * value)
	{
		___getData_4 = value;
		Il2CppCodeGenWriteBarrier(&___getData_4, value);
	}

	inline static int32_t get_offset_of_wait_5() { return static_cast<int32_t>(offsetof(StepGetDataFacebookUpdate_t1888796599, ___wait_5)); }
	inline Routine_t2502590640 * get_wait_5() const { return ___wait_5; }
	inline Routine_t2502590640 ** get_address_of_wait_5() { return &___wait_5; }
	inline void set_wait_5(Routine_t2502590640 * value)
	{
		___wait_5 = value;
		Il2CppCodeGenWriteBarrier(&___wait_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
