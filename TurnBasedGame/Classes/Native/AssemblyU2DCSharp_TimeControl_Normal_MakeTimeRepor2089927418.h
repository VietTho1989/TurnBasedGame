#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2489844676.h"

// TimeControl.TimeControl
struct TimeControl_t2006596444;
// GameData
struct GameData_t450274222;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.MakeTimeReportDeltaUpdate
struct  MakeTimeReportDeltaUpdate_t2089927418  : public UpdateBehavior_1_t2489844676
{
public:
	// TimeControl.TimeControl TimeControl.Normal.MakeTimeReportDeltaUpdate::timeControls
	TimeControl_t2006596444 * ___timeControls_4;
	// GameData TimeControl.Normal.MakeTimeReportDeltaUpdate::gameData
	GameData_t450274222 * ___gameData_5;

public:
	inline static int32_t get_offset_of_timeControls_4() { return static_cast<int32_t>(offsetof(MakeTimeReportDeltaUpdate_t2089927418, ___timeControls_4)); }
	inline TimeControl_t2006596444 * get_timeControls_4() const { return ___timeControls_4; }
	inline TimeControl_t2006596444 ** get_address_of_timeControls_4() { return &___timeControls_4; }
	inline void set_timeControls_4(TimeControl_t2006596444 * value)
	{
		___timeControls_4 = value;
		Il2CppCodeGenWriteBarrier(&___timeControls_4, value);
	}

	inline static int32_t get_offset_of_gameData_5() { return static_cast<int32_t>(offsetof(MakeTimeReportDeltaUpdate_t2089927418, ___gameData_5)); }
	inline GameData_t450274222 * get_gameData_5() const { return ___gameData_5; }
	inline GameData_t450274222 ** get_address_of_gameData_5() { return &___gameData_5; }
	inline void set_gameData_5(GameData_t450274222 * value)
	{
		___gameData_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameData_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
