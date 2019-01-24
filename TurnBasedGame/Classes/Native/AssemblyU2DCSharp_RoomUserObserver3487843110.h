#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameObserver_CheckChange811089867.h"

// RoomUser
struct RoomUser_t2913528656;
// Room
struct Room_t1042398373;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomUserObserver
struct  RoomUserObserver_t3487843110  : public CheckChange_t811089867
{
public:
	// RoomUser RoomUserObserver::data
	RoomUser_t2913528656 * ___data_1;
	// Room RoomUserObserver::room
	Room_t1042398373 * ___room_2;

public:
	inline static int32_t get_offset_of_data_1() { return static_cast<int32_t>(offsetof(RoomUserObserver_t3487843110, ___data_1)); }
	inline RoomUser_t2913528656 * get_data_1() const { return ___data_1; }
	inline RoomUser_t2913528656 ** get_address_of_data_1() { return &___data_1; }
	inline void set_data_1(RoomUser_t2913528656 * value)
	{
		___data_1 = value;
		Il2CppCodeGenWriteBarrier(&___data_1, value);
	}

	inline static int32_t get_offset_of_room_2() { return static_cast<int32_t>(offsetof(RoomUserObserver_t3487843110, ___room_2)); }
	inline Room_t1042398373 * get_room_2() const { return ___room_2; }
	inline Room_t1042398373 ** get_address_of_room_2() { return &___room_2; }
	inline void set_room_2(Room_t1042398373 * value)
	{
		___room_2 = value;
		Il2CppCodeGenWriteBarrier(&___room_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
