#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2398604750.h"

// GameIsPlayingChange`1<WaitInputAction>
struct GameIsPlayingChange_1_t3195073119;
// Game
struct Game_t1600141214;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitInputActionProcessInputUpdate
struct  WaitInputActionProcessInputUpdate_t1312608657  : public UpdateBehavior_1_t2398604750
{
public:
	// GameIsPlayingChange`1<WaitInputAction> WaitInputActionProcessInputUpdate::gameIsPlayingChange
	GameIsPlayingChange_1_t3195073119 * ___gameIsPlayingChange_4;
	// Game WaitInputActionProcessInputUpdate::game
	Game_t1600141214 * ___game_5;

public:
	inline static int32_t get_offset_of_gameIsPlayingChange_4() { return static_cast<int32_t>(offsetof(WaitInputActionProcessInputUpdate_t1312608657, ___gameIsPlayingChange_4)); }
	inline GameIsPlayingChange_1_t3195073119 * get_gameIsPlayingChange_4() const { return ___gameIsPlayingChange_4; }
	inline GameIsPlayingChange_1_t3195073119 ** get_address_of_gameIsPlayingChange_4() { return &___gameIsPlayingChange_4; }
	inline void set_gameIsPlayingChange_4(GameIsPlayingChange_1_t3195073119 * value)
	{
		___gameIsPlayingChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___gameIsPlayingChange_4, value);
	}

	inline static int32_t get_offset_of_game_5() { return static_cast<int32_t>(offsetof(WaitInputActionProcessInputUpdate_t1312608657, ___game_5)); }
	inline Game_t1600141214 * get_game_5() const { return ___game_5; }
	inline Game_t1600141214 ** get_address_of_game_5() { return &___game_5; }
	inline void set_game_5(Game_t1600141214 * value)
	{
		___game_5 = value;
		Il2CppCodeGenWriteBarrier(&___game_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
