#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen822551476.h"

// GameIsPlayingChange`1<GameData>
struct GameIsPlayingChange_1_t1762368284;
// GameCheckPlayerChange`1<GameData>
struct GameCheckPlayerChange_1_t3776416635;
// CheckHaveAnimation`1<GameDataBoardUI/UIData>
struct CheckHaveAnimation_1_t3826162895;
// Game
struct Game_t1600141214;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameDataUIAllowInputUpdate
struct  GameDataUIAllowInputUpdate_t2162110290  : public UpdateBehavior_1_t822551476
{
public:
	// GameIsPlayingChange`1<GameData> GameDataUIAllowInputUpdate::gameIsPlayingChange
	GameIsPlayingChange_1_t1762368284 * ___gameIsPlayingChange_4;
	// GameCheckPlayerChange`1<GameData> GameDataUIAllowInputUpdate::gameCheckPlayerChange
	GameCheckPlayerChange_1_t3776416635 * ___gameCheckPlayerChange_5;
	// CheckHaveAnimation`1<GameDataBoardUI/UIData> GameDataUIAllowInputUpdate::checkHaveAnimation
	CheckHaveAnimation_1_t3826162895 * ___checkHaveAnimation_6;
	// Game GameDataUIAllowInputUpdate::game
	Game_t1600141214 * ___game_7;

public:
	inline static int32_t get_offset_of_gameIsPlayingChange_4() { return static_cast<int32_t>(offsetof(GameDataUIAllowInputUpdate_t2162110290, ___gameIsPlayingChange_4)); }
	inline GameIsPlayingChange_1_t1762368284 * get_gameIsPlayingChange_4() const { return ___gameIsPlayingChange_4; }
	inline GameIsPlayingChange_1_t1762368284 ** get_address_of_gameIsPlayingChange_4() { return &___gameIsPlayingChange_4; }
	inline void set_gameIsPlayingChange_4(GameIsPlayingChange_1_t1762368284 * value)
	{
		___gameIsPlayingChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___gameIsPlayingChange_4, value);
	}

	inline static int32_t get_offset_of_gameCheckPlayerChange_5() { return static_cast<int32_t>(offsetof(GameDataUIAllowInputUpdate_t2162110290, ___gameCheckPlayerChange_5)); }
	inline GameCheckPlayerChange_1_t3776416635 * get_gameCheckPlayerChange_5() const { return ___gameCheckPlayerChange_5; }
	inline GameCheckPlayerChange_1_t3776416635 ** get_address_of_gameCheckPlayerChange_5() { return &___gameCheckPlayerChange_5; }
	inline void set_gameCheckPlayerChange_5(GameCheckPlayerChange_1_t3776416635 * value)
	{
		___gameCheckPlayerChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameCheckPlayerChange_5, value);
	}

	inline static int32_t get_offset_of_checkHaveAnimation_6() { return static_cast<int32_t>(offsetof(GameDataUIAllowInputUpdate_t2162110290, ___checkHaveAnimation_6)); }
	inline CheckHaveAnimation_1_t3826162895 * get_checkHaveAnimation_6() const { return ___checkHaveAnimation_6; }
	inline CheckHaveAnimation_1_t3826162895 ** get_address_of_checkHaveAnimation_6() { return &___checkHaveAnimation_6; }
	inline void set_checkHaveAnimation_6(CheckHaveAnimation_1_t3826162895 * value)
	{
		___checkHaveAnimation_6 = value;
		Il2CppCodeGenWriteBarrier(&___checkHaveAnimation_6, value);
	}

	inline static int32_t get_offset_of_game_7() { return static_cast<int32_t>(offsetof(GameDataUIAllowInputUpdate_t2162110290, ___game_7)); }
	inline Game_t1600141214 * get_game_7() const { return ___game_7; }
	inline Game_t1600141214 ** get_address_of_game_7() { return &___game_7; }
	inline void set_game_7(Game_t1600141214 * value)
	{
		___game_7 = value;
		Il2CppCodeGenWriteBarrier(&___game_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
