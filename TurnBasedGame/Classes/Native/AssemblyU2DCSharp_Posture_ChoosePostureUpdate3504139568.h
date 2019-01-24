#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1090321183.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Posture.ChoosePostureUpdate
struct  ChoosePostureUpdate_t3504139568  : public UpdateBehavior_1_t1090321183
{
public:
	// AdvancedCoroutines.Routine Posture.ChoosePostureUpdate::loadData
	Routine_t2502590640 * ___loadData_4;

public:
	inline static int32_t get_offset_of_loadData_4() { return static_cast<int32_t>(offsetof(ChoosePostureUpdate_t3504139568, ___loadData_4)); }
	inline Routine_t2502590640 * get_loadData_4() const { return ___loadData_4; }
	inline Routine_t2502590640 ** get_address_of_loadData_4() { return &___loadData_4; }
	inline void set_loadData_4(Routine_t2502590640 * value)
	{
		___loadData_4 = value;
		Il2CppCodeGenWriteBarrier(&___loadData_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
