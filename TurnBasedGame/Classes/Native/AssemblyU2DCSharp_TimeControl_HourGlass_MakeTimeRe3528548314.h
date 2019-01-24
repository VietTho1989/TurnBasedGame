#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen72614219.h"

// GameData
struct GameData_t450274222;
// TimeControl.TimeControl
struct TimeControl_t2006596444;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.HourGlass.MakeTimeReportDeltaUpdate
struct  MakeTimeReportDeltaUpdate_t3528548314  : public UpdateBehavior_1_t72614219
{
public:
	// GameData TimeControl.HourGlass.MakeTimeReportDeltaUpdate::gameData
	GameData_t450274222 * ___gameData_4;
	// TimeControl.TimeControl TimeControl.HourGlass.MakeTimeReportDeltaUpdate::timeControl
	TimeControl_t2006596444 * ___timeControl_5;

public:
	inline static int32_t get_offset_of_gameData_4() { return static_cast<int32_t>(offsetof(MakeTimeReportDeltaUpdate_t3528548314, ___gameData_4)); }
	inline GameData_t450274222 * get_gameData_4() const { return ___gameData_4; }
	inline GameData_t450274222 ** get_address_of_gameData_4() { return &___gameData_4; }
	inline void set_gameData_4(GameData_t450274222 * value)
	{
		___gameData_4 = value;
		Il2CppCodeGenWriteBarrier(&___gameData_4, value);
	}

	inline static int32_t get_offset_of_timeControl_5() { return static_cast<int32_t>(offsetof(MakeTimeReportDeltaUpdate_t3528548314, ___timeControl_5)); }
	inline TimeControl_t2006596444 * get_timeControl_5() const { return ___timeControl_5; }
	inline TimeControl_t2006596444 ** get_address_of_timeControl_5() { return &___timeControl_5; }
	inline void set_timeControl_5(TimeControl_t2006596444 * value)
	{
		___timeControl_5 = value;
		Il2CppCodeGenWriteBarrier(&___timeControl_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
