#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen115046184.h"

// Game
struct Game_t1600141214;
// Room
struct Room_t1042398373;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestDrawUpdate
struct  RequestDrawUpdate_t4095991054  : public UpdateBehavior_1_t115046184
{
public:
	// Game RequestDrawUpdate::game
	Game_t1600141214 * ___game_4;
	// Room RequestDrawUpdate::room
	Room_t1042398373 * ___room_5;

public:
	inline static int32_t get_offset_of_game_4() { return static_cast<int32_t>(offsetof(RequestDrawUpdate_t4095991054, ___game_4)); }
	inline Game_t1600141214 * get_game_4() const { return ___game_4; }
	inline Game_t1600141214 ** get_address_of_game_4() { return &___game_4; }
	inline void set_game_4(Game_t1600141214 * value)
	{
		___game_4 = value;
		Il2CppCodeGenWriteBarrier(&___game_4, value);
	}

	inline static int32_t get_offset_of_room_5() { return static_cast<int32_t>(offsetof(RequestDrawUpdate_t4095991054, ___room_5)); }
	inline Room_t1042398373 * get_room_5() const { return ___room_5; }
	inline Room_t1042398373 ** get_address_of_room_5() { return &___room_5; }
	inline void set_room_5(Room_t1042398373 * value)
	{
		___room_5 = value;
		Il2CppCodeGenWriteBarrier(&___room_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
