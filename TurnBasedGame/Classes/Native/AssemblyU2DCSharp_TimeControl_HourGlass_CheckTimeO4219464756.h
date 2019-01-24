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
// Game
struct Game_t1600141214;
// TimeControl.TimeControl
struct TimeControl_t2006596444;
// GameCheckPlayerChange`1<TimeControl.HourGlass.TimeControlHourGlass>
struct GameCheckPlayerChange_1_t2883130939;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.HourGlass.CheckTimeOutUpdate
struct  CheckTimeOutUpdate_t4219464756  : public UpdateBehavior_1_t72614219
{
public:
	// GameData TimeControl.HourGlass.CheckTimeOutUpdate::gameData
	GameData_t450274222 * ___gameData_4;
	// Game TimeControl.HourGlass.CheckTimeOutUpdate::game
	Game_t1600141214 * ___game_5;
	// TimeControl.TimeControl TimeControl.HourGlass.CheckTimeOutUpdate::timeControl
	TimeControl_t2006596444 * ___timeControl_6;
	// GameCheckPlayerChange`1<TimeControl.HourGlass.TimeControlHourGlass> TimeControl.HourGlass.CheckTimeOutUpdate::gameCheckPlayerChange
	GameCheckPlayerChange_1_t2883130939 * ___gameCheckPlayerChange_7;

public:
	inline static int32_t get_offset_of_gameData_4() { return static_cast<int32_t>(offsetof(CheckTimeOutUpdate_t4219464756, ___gameData_4)); }
	inline GameData_t450274222 * get_gameData_4() const { return ___gameData_4; }
	inline GameData_t450274222 ** get_address_of_gameData_4() { return &___gameData_4; }
	inline void set_gameData_4(GameData_t450274222 * value)
	{
		___gameData_4 = value;
		Il2CppCodeGenWriteBarrier(&___gameData_4, value);
	}

	inline static int32_t get_offset_of_game_5() { return static_cast<int32_t>(offsetof(CheckTimeOutUpdate_t4219464756, ___game_5)); }
	inline Game_t1600141214 * get_game_5() const { return ___game_5; }
	inline Game_t1600141214 ** get_address_of_game_5() { return &___game_5; }
	inline void set_game_5(Game_t1600141214 * value)
	{
		___game_5 = value;
		Il2CppCodeGenWriteBarrier(&___game_5, value);
	}

	inline static int32_t get_offset_of_timeControl_6() { return static_cast<int32_t>(offsetof(CheckTimeOutUpdate_t4219464756, ___timeControl_6)); }
	inline TimeControl_t2006596444 * get_timeControl_6() const { return ___timeControl_6; }
	inline TimeControl_t2006596444 ** get_address_of_timeControl_6() { return &___timeControl_6; }
	inline void set_timeControl_6(TimeControl_t2006596444 * value)
	{
		___timeControl_6 = value;
		Il2CppCodeGenWriteBarrier(&___timeControl_6, value);
	}

	inline static int32_t get_offset_of_gameCheckPlayerChange_7() { return static_cast<int32_t>(offsetof(CheckTimeOutUpdate_t4219464756, ___gameCheckPlayerChange_7)); }
	inline GameCheckPlayerChange_1_t2883130939 * get_gameCheckPlayerChange_7() const { return ___gameCheckPlayerChange_7; }
	inline GameCheckPlayerChange_1_t2883130939 ** get_address_of_gameCheckPlayerChange_7() { return &___gameCheckPlayerChange_7; }
	inline void set_gameCheckPlayerChange_7(GameCheckPlayerChange_1_t2883130939 * value)
	{
		___gameCheckPlayerChange_7 = value;
		Il2CppCodeGenWriteBarrier(&___gameCheckPlayerChange_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
