#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2447010022.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.PlayUnPauseUpdate
struct  PlayUnPauseUpdate_t2715681990  : public UpdateBehavior_1_t2447010022
{
public:
	// AdvancedCoroutines.Routine GameState.PlayUnPauseUpdate::timeRoutine
	Routine_t2502590640 * ___timeRoutine_4;

public:
	inline static int32_t get_offset_of_timeRoutine_4() { return static_cast<int32_t>(offsetof(PlayUnPauseUpdate_t2715681990, ___timeRoutine_4)); }
	inline Routine_t2502590640 * get_timeRoutine_4() const { return ___timeRoutine_4; }
	inline Routine_t2502590640 ** get_address_of_timeRoutine_4() { return &___timeRoutine_4; }
	inline void set_timeRoutine_4(Routine_t2502590640 * value)
	{
		___timeRoutine_4 = value;
		Il2CppCodeGenWriteBarrier(&___timeRoutine_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
