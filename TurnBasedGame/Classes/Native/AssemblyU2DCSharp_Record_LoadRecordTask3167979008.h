#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1672421786.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.LoadRecordTask
struct  LoadRecordTask_t3167979008  : public UpdateBehavior_1_t1672421786
{
public:
	// AdvancedCoroutines.Routine Record.LoadRecordTask::loadRoutine
	Routine_t2502590640 * ___loadRoutine_4;

public:
	inline static int32_t get_offset_of_loadRoutine_4() { return static_cast<int32_t>(offsetof(LoadRecordTask_t3167979008, ___loadRoutine_4)); }
	inline Routine_t2502590640 * get_loadRoutine_4() const { return ___loadRoutine_4; }
	inline Routine_t2502590640 ** get_address_of_loadRoutine_4() { return &___loadRoutine_4; }
	inline void set_loadRoutine_4(Routine_t2502590640 * value)
	{
		___loadRoutine_4 = value;
		Il2CppCodeGenWriteBarrier(&___loadRoutine_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
