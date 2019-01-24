#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen59498721.h"

// RoomCheckChangeAdminChange`1<History>
struct RoomCheckChangeAdminChange_1_t3028796038;
// Room
struct Room_t1042398373;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HumanConnectionCheckInsideRoomUpdate
struct  HumanConnectionCheckInsideRoomUpdate_t2372453655  : public UpdateBehavior_1_t59498721
{
public:
	// RoomCheckChangeAdminChange`1<History> HumanConnectionCheckInsideRoomUpdate::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t3028796038 * ___roomCheckAdminChange_4;
	// Room HumanConnectionCheckInsideRoomUpdate::room
	Room_t1042398373 * ___room_5;

public:
	inline static int32_t get_offset_of_roomCheckAdminChange_4() { return static_cast<int32_t>(offsetof(HumanConnectionCheckInsideRoomUpdate_t2372453655, ___roomCheckAdminChange_4)); }
	inline RoomCheckChangeAdminChange_1_t3028796038 * get_roomCheckAdminChange_4() const { return ___roomCheckAdminChange_4; }
	inline RoomCheckChangeAdminChange_1_t3028796038 ** get_address_of_roomCheckAdminChange_4() { return &___roomCheckAdminChange_4; }
	inline void set_roomCheckAdminChange_4(RoomCheckChangeAdminChange_1_t3028796038 * value)
	{
		___roomCheckAdminChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_4, value);
	}

	inline static int32_t get_offset_of_room_5() { return static_cast<int32_t>(offsetof(HumanConnectionCheckInsideRoomUpdate_t2372453655, ___room_5)); }
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
