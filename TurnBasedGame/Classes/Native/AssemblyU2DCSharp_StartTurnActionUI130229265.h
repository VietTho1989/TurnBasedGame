#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1889714202.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// Game
struct Game_t1600141214;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// StartTurnActionUI
struct  StartTurnActionUI_t130229265  : public UIBehavior_1_t1889714202
{
public:
	// UnityEngine.UI.Text StartTurnActionUI::tvTurn
	Text_t356221433 * ___tvTurn_6;
	// Game StartTurnActionUI::game
	Game_t1600141214 * ___game_7;

public:
	inline static int32_t get_offset_of_tvTurn_6() { return static_cast<int32_t>(offsetof(StartTurnActionUI_t130229265, ___tvTurn_6)); }
	inline Text_t356221433 * get_tvTurn_6() const { return ___tvTurn_6; }
	inline Text_t356221433 ** get_address_of_tvTurn_6() { return &___tvTurn_6; }
	inline void set_tvTurn_6(Text_t356221433 * value)
	{
		___tvTurn_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvTurn_6, value);
	}

	inline static int32_t get_offset_of_game_7() { return static_cast<int32_t>(offsetof(StartTurnActionUI_t130229265, ___game_7)); }
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
