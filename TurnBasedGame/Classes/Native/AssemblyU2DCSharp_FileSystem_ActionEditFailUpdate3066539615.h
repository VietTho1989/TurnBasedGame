#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3963762295.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.ActionEditFailUpdate
struct  ActionEditFailUpdate_t3066539615  : public UpdateBehavior_1_t3963762295
{
public:
	// AdvancedCoroutines.Routine FileSystem.ActionEditFailUpdate::timeCoroutine
	Routine_t2502590640 * ___timeCoroutine_4;

public:
	inline static int32_t get_offset_of_timeCoroutine_4() { return static_cast<int32_t>(offsetof(ActionEditFailUpdate_t3066539615, ___timeCoroutine_4)); }
	inline Routine_t2502590640 * get_timeCoroutine_4() const { return ___timeCoroutine_4; }
	inline Routine_t2502590640 ** get_address_of_timeCoroutine_4() { return &___timeCoroutine_4; }
	inline void set_timeCoroutine_4(Routine_t2502590640 * value)
	{
		___timeCoroutine_4 = value;
		Il2CppCodeGenWriteBarrier(&___timeCoroutine_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
