#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2489844676.h"

// Game
struct Game_t1600141214;
// GameData
struct GameData_t450274222;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.IncreasePlayerTotalTimeUpdate
struct  IncreasePlayerTotalTimeUpdate_t2292930375  : public UpdateBehavior_1_t2489844676
{
public:
	// Game TimeControl.Normal.IncreasePlayerTotalTimeUpdate::game
	Game_t1600141214 * ___game_4;
	// GameData TimeControl.Normal.IncreasePlayerTotalTimeUpdate::gameData
	GameData_t450274222 * ___gameData_5;

public:
	inline static int32_t get_offset_of_game_4() { return static_cast<int32_t>(offsetof(IncreasePlayerTotalTimeUpdate_t2292930375, ___game_4)); }
	inline Game_t1600141214 * get_game_4() const { return ___game_4; }
	inline Game_t1600141214 ** get_address_of_game_4() { return &___game_4; }
	inline void set_game_4(Game_t1600141214 * value)
	{
		___game_4 = value;
		Il2CppCodeGenWriteBarrier(&___game_4, value);
	}

	inline static int32_t get_offset_of_gameData_5() { return static_cast<int32_t>(offsetof(IncreasePlayerTotalTimeUpdate_t2292930375, ___gameData_5)); }
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
