#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2489844676.h"

// GameCheckPlayerChange`1<TimeControl.Normal.TimeControlNormal>
struct GameCheckPlayerChange_1_t1005394100;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.MakePlayerTotalTimesUpdate
struct  MakePlayerTotalTimesUpdate_t2962917234  : public UpdateBehavior_1_t2489844676
{
public:
	// GameCheckPlayerChange`1<TimeControl.Normal.TimeControlNormal> TimeControl.Normal.MakePlayerTotalTimesUpdate::gameCheckPlayerChange
	GameCheckPlayerChange_1_t1005394100 * ___gameCheckPlayerChange_4;

public:
	inline static int32_t get_offset_of_gameCheckPlayerChange_4() { return static_cast<int32_t>(offsetof(MakePlayerTotalTimesUpdate_t2962917234, ___gameCheckPlayerChange_4)); }
	inline GameCheckPlayerChange_1_t1005394100 * get_gameCheckPlayerChange_4() const { return ___gameCheckPlayerChange_4; }
	inline GameCheckPlayerChange_1_t1005394100 ** get_address_of_gameCheckPlayerChange_4() { return &___gameCheckPlayerChange_4; }
	inline void set_gameCheckPlayerChange_4(GameCheckPlayerChange_1_t1005394100 * value)
	{
		___gameCheckPlayerChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___gameCheckPlayerChange_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
