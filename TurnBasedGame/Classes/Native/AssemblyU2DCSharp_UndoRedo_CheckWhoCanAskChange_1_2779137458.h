#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// System.Object
struct Il2CppObject;
// UndoRedoRequest
struct UndoRedoRequest_t1465955771;
// RoomCheckChangeAdminChange`1<UndoRedoRequest>
struct RoomCheckChangeAdminChange_1_t655911485;
// GameCheckPlayerChange`1<UndoRedoRequest>
struct GameCheckPlayerChange_1_t497130888;
// Room
struct Room_t1042398373;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.CheckWhoCanAskChange`1<System.Object>
struct  CheckWhoCanAskChange_1_t2779137458  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> UndoRedo.CheckWhoCanAskChange`1::change
	VP_1_t2450154454 * ___change_5;
	// K UndoRedo.CheckWhoCanAskChange`1::data
	Il2CppObject * ___data_6;
	// UndoRedoRequest UndoRedo.CheckWhoCanAskChange`1::undoRedoRequest
	UndoRedoRequest_t1465955771 * ___undoRedoRequest_7;
	// RoomCheckChangeAdminChange`1<UndoRedoRequest> UndoRedo.CheckWhoCanAskChange`1::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t655911485 * ___roomCheckAdminChange_8;
	// GameCheckPlayerChange`1<UndoRedoRequest> UndoRedo.CheckWhoCanAskChange`1::gameCheckPlayerChange
	GameCheckPlayerChange_1_t497130888 * ___gameCheckPlayerChange_9;
	// Room UndoRedo.CheckWhoCanAskChange`1::room
	Room_t1042398373 * ___room_10;

public:
	inline static int32_t get_offset_of_change_5() { return static_cast<int32_t>(offsetof(CheckWhoCanAskChange_1_t2779137458, ___change_5)); }
	inline VP_1_t2450154454 * get_change_5() const { return ___change_5; }
	inline VP_1_t2450154454 ** get_address_of_change_5() { return &___change_5; }
	inline void set_change_5(VP_1_t2450154454 * value)
	{
		___change_5 = value;
		Il2CppCodeGenWriteBarrier(&___change_5, value);
	}

	inline static int32_t get_offset_of_data_6() { return static_cast<int32_t>(offsetof(CheckWhoCanAskChange_1_t2779137458, ___data_6)); }
	inline Il2CppObject * get_data_6() const { return ___data_6; }
	inline Il2CppObject ** get_address_of_data_6() { return &___data_6; }
	inline void set_data_6(Il2CppObject * value)
	{
		___data_6 = value;
		Il2CppCodeGenWriteBarrier(&___data_6, value);
	}

	inline static int32_t get_offset_of_undoRedoRequest_7() { return static_cast<int32_t>(offsetof(CheckWhoCanAskChange_1_t2779137458, ___undoRedoRequest_7)); }
	inline UndoRedoRequest_t1465955771 * get_undoRedoRequest_7() const { return ___undoRedoRequest_7; }
	inline UndoRedoRequest_t1465955771 ** get_address_of_undoRedoRequest_7() { return &___undoRedoRequest_7; }
	inline void set_undoRedoRequest_7(UndoRedoRequest_t1465955771 * value)
	{
		___undoRedoRequest_7 = value;
		Il2CppCodeGenWriteBarrier(&___undoRedoRequest_7, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_8() { return static_cast<int32_t>(offsetof(CheckWhoCanAskChange_1_t2779137458, ___roomCheckAdminChange_8)); }
	inline RoomCheckChangeAdminChange_1_t655911485 * get_roomCheckAdminChange_8() const { return ___roomCheckAdminChange_8; }
	inline RoomCheckChangeAdminChange_1_t655911485 ** get_address_of_roomCheckAdminChange_8() { return &___roomCheckAdminChange_8; }
	inline void set_roomCheckAdminChange_8(RoomCheckChangeAdminChange_1_t655911485 * value)
	{
		___roomCheckAdminChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_8, value);
	}

	inline static int32_t get_offset_of_gameCheckPlayerChange_9() { return static_cast<int32_t>(offsetof(CheckWhoCanAskChange_1_t2779137458, ___gameCheckPlayerChange_9)); }
	inline GameCheckPlayerChange_1_t497130888 * get_gameCheckPlayerChange_9() const { return ___gameCheckPlayerChange_9; }
	inline GameCheckPlayerChange_1_t497130888 ** get_address_of_gameCheckPlayerChange_9() { return &___gameCheckPlayerChange_9; }
	inline void set_gameCheckPlayerChange_9(GameCheckPlayerChange_1_t497130888 * value)
	{
		___gameCheckPlayerChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameCheckPlayerChange_9, value);
	}

	inline static int32_t get_offset_of_room_10() { return static_cast<int32_t>(offsetof(CheckWhoCanAskChange_1_t2779137458, ___room_10)); }
	inline Room_t1042398373 * get_room_10() const { return ___room_10; }
	inline Room_t1042398373 ** get_address_of_room_10() { return &___room_10; }
	inline void set_room_10(Room_t1042398373 * value)
	{
		___room_10 = value;
		Il2CppCodeGenWriteBarrier(&___room_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
