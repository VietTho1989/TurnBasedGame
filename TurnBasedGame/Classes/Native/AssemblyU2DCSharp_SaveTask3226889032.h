#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3558376021.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SaveTask
struct  SaveTask_t3226889032  : public UpdateBehavior_1_t3558376021
{
public:
	// AdvancedCoroutines.Routine SaveTask::saveRoutine
	Routine_t2502590640 * ___saveRoutine_4;

public:
	inline static int32_t get_offset_of_saveRoutine_4() { return static_cast<int32_t>(offsetof(SaveTask_t3226889032, ___saveRoutine_4)); }
	inline Routine_t2502590640 * get_saveRoutine_4() const { return ___saveRoutine_4; }
	inline Routine_t2502590640 ** get_address_of_saveRoutine_4() { return &___saveRoutine_4; }
	inline void set_saveRoutine_4(Routine_t2502590640 * value)
	{
		___saveRoutine_4 = value;
		Il2CppCodeGenWriteBarrier(&___saveRoutine_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
