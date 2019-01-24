#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1251398824.h"

// Game
struct Game_t1600141214;
// UndoRedoRequest
struct UndoRedoRequest_t1465955771;
// Room
struct Room_t1042398373;
// GameCheckPlayerChange`1<UndoRedo.Ask>
struct GameCheckPlayerChange_1_t4061915544;
// RoomCheckChangeAdminChange`1<UndoRedo.Ask>
struct RoomCheckChangeAdminChange_1_t4220696141;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.AskUpdate
struct  AskUpdate_t464701090  : public UpdateBehavior_1_t1251398824
{
public:
	// Game UndoRedo.AskUpdate::game
	Game_t1600141214 * ___game_4;
	// UndoRedoRequest UndoRedo.AskUpdate::undoRedoRequest
	UndoRedoRequest_t1465955771 * ___undoRedoRequest_5;
	// Room UndoRedo.AskUpdate::room
	Room_t1042398373 * ___room_6;
	// GameCheckPlayerChange`1<UndoRedo.Ask> UndoRedo.AskUpdate::gameCheckPlayerChange
	GameCheckPlayerChange_1_t4061915544 * ___gameCheckPlayerChange_7;
	// RoomCheckChangeAdminChange`1<UndoRedo.Ask> UndoRedo.AskUpdate::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t4220696141 * ___roomCheckAdminChange_8;

public:
	inline static int32_t get_offset_of_game_4() { return static_cast<int32_t>(offsetof(AskUpdate_t464701090, ___game_4)); }
	inline Game_t1600141214 * get_game_4() const { return ___game_4; }
	inline Game_t1600141214 ** get_address_of_game_4() { return &___game_4; }
	inline void set_game_4(Game_t1600141214 * value)
	{
		___game_4 = value;
		Il2CppCodeGenWriteBarrier(&___game_4, value);
	}

	inline static int32_t get_offset_of_undoRedoRequest_5() { return static_cast<int32_t>(offsetof(AskUpdate_t464701090, ___undoRedoRequest_5)); }
	inline UndoRedoRequest_t1465955771 * get_undoRedoRequest_5() const { return ___undoRedoRequest_5; }
	inline UndoRedoRequest_t1465955771 ** get_address_of_undoRedoRequest_5() { return &___undoRedoRequest_5; }
	inline void set_undoRedoRequest_5(UndoRedoRequest_t1465955771 * value)
	{
		___undoRedoRequest_5 = value;
		Il2CppCodeGenWriteBarrier(&___undoRedoRequest_5, value);
	}

	inline static int32_t get_offset_of_room_6() { return static_cast<int32_t>(offsetof(AskUpdate_t464701090, ___room_6)); }
	inline Room_t1042398373 * get_room_6() const { return ___room_6; }
	inline Room_t1042398373 ** get_address_of_room_6() { return &___room_6; }
	inline void set_room_6(Room_t1042398373 * value)
	{
		___room_6 = value;
		Il2CppCodeGenWriteBarrier(&___room_6, value);
	}

	inline static int32_t get_offset_of_gameCheckPlayerChange_7() { return static_cast<int32_t>(offsetof(AskUpdate_t464701090, ___gameCheckPlayerChange_7)); }
	inline GameCheckPlayerChange_1_t4061915544 * get_gameCheckPlayerChange_7() const { return ___gameCheckPlayerChange_7; }
	inline GameCheckPlayerChange_1_t4061915544 ** get_address_of_gameCheckPlayerChange_7() { return &___gameCheckPlayerChange_7; }
	inline void set_gameCheckPlayerChange_7(GameCheckPlayerChange_1_t4061915544 * value)
	{
		___gameCheckPlayerChange_7 = value;
		Il2CppCodeGenWriteBarrier(&___gameCheckPlayerChange_7, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_8() { return static_cast<int32_t>(offsetof(AskUpdate_t464701090, ___roomCheckAdminChange_8)); }
	inline RoomCheckChangeAdminChange_1_t4220696141 * get_roomCheckAdminChange_8() const { return ___roomCheckAdminChange_8; }
	inline RoomCheckChangeAdminChange_1_t4220696141 ** get_address_of_roomCheckAdminChange_8() { return &___roomCheckAdminChange_8; }
	inline void set_roomCheckAdminChange_8(RoomCheckChangeAdminChange_1_t4220696141 * value)
	{
		___roomCheckAdminChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
