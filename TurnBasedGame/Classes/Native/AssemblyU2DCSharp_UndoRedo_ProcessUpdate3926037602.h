#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen698900134.h"

// Game
struct Game_t1600141214;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.ProcessUpdate
struct  ProcessUpdate_t3926037602  : public UpdateBehavior_1_t698900134
{
public:
	// Game UndoRedo.ProcessUpdate::game
	Game_t1600141214 * ___game_4;

public:
	inline static int32_t get_offset_of_game_4() { return static_cast<int32_t>(offsetof(ProcessUpdate_t3926037602, ___game_4)); }
	inline Game_t1600141214 * get_game_4() const { return ___game_4; }
	inline Game_t1600141214 ** get_address_of_game_4() { return &___game_4; }
	inline void set_game_4(Game_t1600141214 * value)
	{
		___game_4 = value;
		Il2CppCodeGenWriteBarrier(&___game_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
