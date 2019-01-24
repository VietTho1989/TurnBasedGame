#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3742789892.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Room
struct Room_t1042398373;
// Game
struct Game_t1600141214;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Hint.HintUpdate
struct  HintUpdate_t4290055972  : public UpdateBehavior_1_t3742789892
{
public:
	// AdvancedCoroutines.Routine Hint.HintUpdate::findHintRoutine
	Routine_t2502590640 * ___findHintRoutine_4;
	// System.Boolean Hint.HintUpdate::haveChangeBoard
	bool ___haveChangeBoard_5;
	// Room Hint.HintUpdate::room
	Room_t1042398373 * ___room_6;
	// Game Hint.HintUpdate::game
	Game_t1600141214 * ___game_7;

public:
	inline static int32_t get_offset_of_findHintRoutine_4() { return static_cast<int32_t>(offsetof(HintUpdate_t4290055972, ___findHintRoutine_4)); }
	inline Routine_t2502590640 * get_findHintRoutine_4() const { return ___findHintRoutine_4; }
	inline Routine_t2502590640 ** get_address_of_findHintRoutine_4() { return &___findHintRoutine_4; }
	inline void set_findHintRoutine_4(Routine_t2502590640 * value)
	{
		___findHintRoutine_4 = value;
		Il2CppCodeGenWriteBarrier(&___findHintRoutine_4, value);
	}

	inline static int32_t get_offset_of_haveChangeBoard_5() { return static_cast<int32_t>(offsetof(HintUpdate_t4290055972, ___haveChangeBoard_5)); }
	inline bool get_haveChangeBoard_5() const { return ___haveChangeBoard_5; }
	inline bool* get_address_of_haveChangeBoard_5() { return &___haveChangeBoard_5; }
	inline void set_haveChangeBoard_5(bool value)
	{
		___haveChangeBoard_5 = value;
	}

	inline static int32_t get_offset_of_room_6() { return static_cast<int32_t>(offsetof(HintUpdate_t4290055972, ___room_6)); }
	inline Room_t1042398373 * get_room_6() const { return ___room_6; }
	inline Room_t1042398373 ** get_address_of_room_6() { return &___room_6; }
	inline void set_room_6(Room_t1042398373 * value)
	{
		___room_6 = value;
		Il2CppCodeGenWriteBarrier(&___room_6, value);
	}

	inline static int32_t get_offset_of_game_7() { return static_cast<int32_t>(offsetof(HintUpdate_t4290055972, ___game_7)); }
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
