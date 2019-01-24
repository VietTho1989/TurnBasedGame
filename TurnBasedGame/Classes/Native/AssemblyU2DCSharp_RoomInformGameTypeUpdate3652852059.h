#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen327728163.h"

// Room
struct Room_t1042398373;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomInformGameTypeUpdate
struct  RoomInformGameTypeUpdate_t3652852059  : public UpdateBehavior_1_t327728163
{
public:
	// Room RoomInformGameTypeUpdate::room
	Room_t1042398373 * ___room_4;

public:
	inline static int32_t get_offset_of_room_4() { return static_cast<int32_t>(offsetof(RoomInformGameTypeUpdate_t3652852059, ___room_4)); }
	inline Room_t1042398373 * get_room_4() const { return ___room_4; }
	inline Room_t1042398373 ** get_address_of_room_4() { return &___room_4; }
	inline void set_room_4(Room_t1042398373 * value)
	{
		___room_4 = value;
		Il2CppCodeGenWriteBarrier(&___room_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
