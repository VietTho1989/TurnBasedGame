#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1540909701.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.CheckTimeOutUpdate
struct  CheckTimeOutUpdate_t966455032  : public UpdateBehavior_1_t1540909701
{
public:
	// AdvancedCoroutines.Routine LoginState.CheckTimeOutUpdate::updateTimeRoutine
	Routine_t2502590640 * ___updateTimeRoutine_4;

public:
	inline static int32_t get_offset_of_updateTimeRoutine_4() { return static_cast<int32_t>(offsetof(CheckTimeOutUpdate_t966455032, ___updateTimeRoutine_4)); }
	inline Routine_t2502590640 * get_updateTimeRoutine_4() const { return ___updateTimeRoutine_4; }
	inline Routine_t2502590640 ** get_address_of_updateTimeRoutine_4() { return &___updateTimeRoutine_4; }
	inline void set_updateTimeRoutine_4(Routine_t2502590640 * value)
	{
		___updateTimeRoutine_4 = value;
		Il2CppCodeGenWriteBarrier(&___updateTimeRoutine_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
