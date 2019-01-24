#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3002123106.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.NotConnectUpdate
struct  NotConnectUpdate_t2696756258  : public UpdateBehavior_1_t3002123106
{
public:
	// AdvancedCoroutines.Routine LoginState.NotConnectUpdate::wait
	Routine_t2502590640 * ___wait_4;

public:
	inline static int32_t get_offset_of_wait_4() { return static_cast<int32_t>(offsetof(NotConnectUpdate_t2696756258, ___wait_4)); }
	inline Routine_t2502590640 * get_wait_4() const { return ___wait_4; }
	inline Routine_t2502590640 ** get_address_of_wait_4() { return &___wait_4; }
	inline void set_wait_4(Routine_t2502590640 * value)
	{
		___wait_4 = value;
		Il2CppCodeGenWriteBarrier(&___wait_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
