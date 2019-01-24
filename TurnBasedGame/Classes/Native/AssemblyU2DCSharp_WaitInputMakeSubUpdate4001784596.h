#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2398604750.h"

// GameCheckPlayerChange`1<WaitInputAction>
struct GameCheckPlayerChange_1_t914154174;
// RoomCheckChangeAdminChange`1<WaitInputAction>
struct RoomCheckChangeAdminChange_1_t1072934771;
// Game
struct Game_t1600141214;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitInputMakeSubUpdate
struct  WaitInputMakeSubUpdate_t4001784596  : public UpdateBehavior_1_t2398604750
{
public:
	// GameCheckPlayerChange`1<WaitInputAction> WaitInputMakeSubUpdate::gameCheckPlayerChange
	GameCheckPlayerChange_1_t914154174 * ___gameCheckPlayerChange_4;
	// RoomCheckChangeAdminChange`1<WaitInputAction> WaitInputMakeSubUpdate::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t1072934771 * ___roomCheckAdminChange_5;
	// Game WaitInputMakeSubUpdate::game
	Game_t1600141214 * ___game_6;

public:
	inline static int32_t get_offset_of_gameCheckPlayerChange_4() { return static_cast<int32_t>(offsetof(WaitInputMakeSubUpdate_t4001784596, ___gameCheckPlayerChange_4)); }
	inline GameCheckPlayerChange_1_t914154174 * get_gameCheckPlayerChange_4() const { return ___gameCheckPlayerChange_4; }
	inline GameCheckPlayerChange_1_t914154174 ** get_address_of_gameCheckPlayerChange_4() { return &___gameCheckPlayerChange_4; }
	inline void set_gameCheckPlayerChange_4(GameCheckPlayerChange_1_t914154174 * value)
	{
		___gameCheckPlayerChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___gameCheckPlayerChange_4, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_5() { return static_cast<int32_t>(offsetof(WaitInputMakeSubUpdate_t4001784596, ___roomCheckAdminChange_5)); }
	inline RoomCheckChangeAdminChange_1_t1072934771 * get_roomCheckAdminChange_5() const { return ___roomCheckAdminChange_5; }
	inline RoomCheckChangeAdminChange_1_t1072934771 ** get_address_of_roomCheckAdminChange_5() { return &___roomCheckAdminChange_5; }
	inline void set_roomCheckAdminChange_5(RoomCheckChangeAdminChange_1_t1072934771 * value)
	{
		___roomCheckAdminChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_5, value);
	}

	inline static int32_t get_offset_of_game_6() { return static_cast<int32_t>(offsetof(WaitInputMakeSubUpdate_t4001784596, ___game_6)); }
	inline Game_t1600141214 * get_game_6() const { return ___game_6; }
	inline Game_t1600141214 ** get_address_of_game_6() { return &___game_6; }
	inline void set_game_6(Game_t1600141214 * value)
	{
		___game_6 = value;
		Il2CppCodeGenWriteBarrier(&___game_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
