#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1981581464.h"

// Game
struct Game_t1600141214;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedoRequestUpdate
struct  UndoRedoRequestUpdate_t1441688086  : public UpdateBehavior_1_t1981581464
{
public:
	// System.Boolean UndoRedoRequestUpdate::needReset
	bool ___needReset_4;
	// Game UndoRedoRequestUpdate::game
	Game_t1600141214 * ___game_5;

public:
	inline static int32_t get_offset_of_needReset_4() { return static_cast<int32_t>(offsetof(UndoRedoRequestUpdate_t1441688086, ___needReset_4)); }
	inline bool get_needReset_4() const { return ___needReset_4; }
	inline bool* get_address_of_needReset_4() { return &___needReset_4; }
	inline void set_needReset_4(bool value)
	{
		___needReset_4 = value;
	}

	inline static int32_t get_offset_of_game_5() { return static_cast<int32_t>(offsetof(UndoRedoRequestUpdate_t1441688086, ___game_5)); }
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
