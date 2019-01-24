#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1797953162.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.ActionEditProcessUpdate
struct  ActionEditProcessUpdate_t3321456462  : public UpdateBehavior_1_t1797953162
{
public:
	// System.Boolean FileSystem.ActionEditProcessUpdate::stop
	bool ___stop_4;
	// AdvancedCoroutines.Routine FileSystem.ActionEditProcessUpdate::processRoutine
	Routine_t2502590640 * ___processRoutine_5;

public:
	inline static int32_t get_offset_of_stop_4() { return static_cast<int32_t>(offsetof(ActionEditProcessUpdate_t3321456462, ___stop_4)); }
	inline bool get_stop_4() const { return ___stop_4; }
	inline bool* get_address_of_stop_4() { return &___stop_4; }
	inline void set_stop_4(bool value)
	{
		___stop_4 = value;
	}

	inline static int32_t get_offset_of_processRoutine_5() { return static_cast<int32_t>(offsetof(ActionEditProcessUpdate_t3321456462, ___processRoutine_5)); }
	inline Routine_t2502590640 * get_processRoutine_5() const { return ___processRoutine_5; }
	inline Routine_t2502590640 ** get_address_of_processRoutine_5() { return &___processRoutine_5; }
	inline void set_processRoutine_5(Routine_t2502590640 * value)
	{
		___processRoutine_5 = value;
		Il2CppCodeGenWriteBarrier(&___processRoutine_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
