#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2489844676.h"

// GameData
struct GameData_t450274222;
// TimeControl.TimeControl
struct TimeControl_t2006596444;
// Game
struct Game_t1600141214;
// GameCheckPlayerChange`1<TimeControl.Normal.TimeControlNormal>
struct GameCheckPlayerChange_1_t1005394100;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.CheckTimeOutUpdate
struct  CheckTimeOutUpdate_t2242633358  : public UpdateBehavior_1_t2489844676
{
public:
	// GameData TimeControl.Normal.CheckTimeOutUpdate::gameData
	GameData_t450274222 * ___gameData_4;
	// TimeControl.TimeControl TimeControl.Normal.CheckTimeOutUpdate::timeControls
	TimeControl_t2006596444 * ___timeControls_5;
	// Game TimeControl.Normal.CheckTimeOutUpdate::game
	Game_t1600141214 * ___game_6;
	// GameCheckPlayerChange`1<TimeControl.Normal.TimeControlNormal> TimeControl.Normal.CheckTimeOutUpdate::gameCheckPlayerChange
	GameCheckPlayerChange_1_t1005394100 * ___gameCheckPlayerChange_7;

public:
	inline static int32_t get_offset_of_gameData_4() { return static_cast<int32_t>(offsetof(CheckTimeOutUpdate_t2242633358, ___gameData_4)); }
	inline GameData_t450274222 * get_gameData_4() const { return ___gameData_4; }
	inline GameData_t450274222 ** get_address_of_gameData_4() { return &___gameData_4; }
	inline void set_gameData_4(GameData_t450274222 * value)
	{
		___gameData_4 = value;
		Il2CppCodeGenWriteBarrier(&___gameData_4, value);
	}

	inline static int32_t get_offset_of_timeControls_5() { return static_cast<int32_t>(offsetof(CheckTimeOutUpdate_t2242633358, ___timeControls_5)); }
	inline TimeControl_t2006596444 * get_timeControls_5() const { return ___timeControls_5; }
	inline TimeControl_t2006596444 ** get_address_of_timeControls_5() { return &___timeControls_5; }
	inline void set_timeControls_5(TimeControl_t2006596444 * value)
	{
		___timeControls_5 = value;
		Il2CppCodeGenWriteBarrier(&___timeControls_5, value);
	}

	inline static int32_t get_offset_of_game_6() { return static_cast<int32_t>(offsetof(CheckTimeOutUpdate_t2242633358, ___game_6)); }
	inline Game_t1600141214 * get_game_6() const { return ___game_6; }
	inline Game_t1600141214 ** get_address_of_game_6() { return &___game_6; }
	inline void set_game_6(Game_t1600141214 * value)
	{
		___game_6 = value;
		Il2CppCodeGenWriteBarrier(&___game_6, value);
	}

	inline static int32_t get_offset_of_gameCheckPlayerChange_7() { return static_cast<int32_t>(offsetof(CheckTimeOutUpdate_t2242633358, ___gameCheckPlayerChange_7)); }
	inline GameCheckPlayerChange_1_t1005394100 * get_gameCheckPlayerChange_7() const { return ___gameCheckPlayerChange_7; }
	inline GameCheckPlayerChange_1_t1005394100 ** get_address_of_gameCheckPlayerChange_7() { return &___gameCheckPlayerChange_7; }
	inline void set_gameCheckPlayerChange_7(GameCheckPlayerChange_1_t1005394100 * value)
	{
		___gameCheckPlayerChange_7 = value;
		Il2CppCodeGenWriteBarrier(&___gameCheckPlayerChange_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
