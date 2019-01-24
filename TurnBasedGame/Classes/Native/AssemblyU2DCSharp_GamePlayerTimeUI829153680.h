#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1546945085.h"

// TimeControl.Normal.GamePlayerTimeNormalUI
struct GamePlayerTimeNormalUI_t4091102239;
// TimeControl.HourGlass.GamePlayerTimeHourGlassUI
struct GamePlayerTimeHourGlassUI_t1489757784;
// Game
struct Game_t1600141214;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GamePlayerTimeUI
struct  GamePlayerTimeUI_t829153680  : public UIBehavior_1_t1546945085
{
public:
	// TimeControl.Normal.GamePlayerTimeNormalUI GamePlayerTimeUI::normalPrefab
	GamePlayerTimeNormalUI_t4091102239 * ___normalPrefab_6;
	// TimeControl.HourGlass.GamePlayerTimeHourGlassUI GamePlayerTimeUI::hourGlassPrefab
	GamePlayerTimeHourGlassUI_t1489757784 * ___hourGlassPrefab_7;
	// Game GamePlayerTimeUI::game
	Game_t1600141214 * ___game_8;

public:
	inline static int32_t get_offset_of_normalPrefab_6() { return static_cast<int32_t>(offsetof(GamePlayerTimeUI_t829153680, ___normalPrefab_6)); }
	inline GamePlayerTimeNormalUI_t4091102239 * get_normalPrefab_6() const { return ___normalPrefab_6; }
	inline GamePlayerTimeNormalUI_t4091102239 ** get_address_of_normalPrefab_6() { return &___normalPrefab_6; }
	inline void set_normalPrefab_6(GamePlayerTimeNormalUI_t4091102239 * value)
	{
		___normalPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___normalPrefab_6, value);
	}

	inline static int32_t get_offset_of_hourGlassPrefab_7() { return static_cast<int32_t>(offsetof(GamePlayerTimeUI_t829153680, ___hourGlassPrefab_7)); }
	inline GamePlayerTimeHourGlassUI_t1489757784 * get_hourGlassPrefab_7() const { return ___hourGlassPrefab_7; }
	inline GamePlayerTimeHourGlassUI_t1489757784 ** get_address_of_hourGlassPrefab_7() { return &___hourGlassPrefab_7; }
	inline void set_hourGlassPrefab_7(GamePlayerTimeHourGlassUI_t1489757784 * value)
	{
		___hourGlassPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___hourGlassPrefab_7, value);
	}

	inline static int32_t get_offset_of_game_8() { return static_cast<int32_t>(offsetof(GamePlayerTimeUI_t829153680, ___game_8)); }
	inline Game_t1600141214 * get_game_8() const { return ___game_8; }
	inline Game_t1600141214 ** get_address_of_game_8() { return &___game_8; }
	inline void set_game_8(Game_t1600141214 * value)
	{
		___game_8 = value;
		Il2CppCodeGenWriteBarrier(&___game_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
