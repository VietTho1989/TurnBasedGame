#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3577149354.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MoveAnimationUpdate
struct  MoveAnimationUpdate_t1248046248  : public UpdateBehavior_1_t3577149354
{
public:
	// AdvancedCoroutines.Routine MoveAnimationUpdate::clientTimeRoutine
	Routine_t2502590640 * ___clientTimeRoutine_4;

public:
	inline static int32_t get_offset_of_clientTimeRoutine_4() { return static_cast<int32_t>(offsetof(MoveAnimationUpdate_t1248046248, ___clientTimeRoutine_4)); }
	inline Routine_t2502590640 * get_clientTimeRoutine_4() const { return ___clientTimeRoutine_4; }
	inline Routine_t2502590640 ** get_address_of_clientTimeRoutine_4() { return &___clientTimeRoutine_4; }
	inline void set_clientTimeRoutine_4(Routine_t2502590640 * value)
	{
		___clientTimeRoutine_4 = value;
		Il2CppCodeGenWriteBarrier(&___clientTimeRoutine_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
