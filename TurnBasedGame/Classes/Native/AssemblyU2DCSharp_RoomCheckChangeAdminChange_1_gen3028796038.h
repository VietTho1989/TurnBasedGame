﻿#pragma once

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
// History
struct History_t3838840324;
// Room
struct Room_t1042398373;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomCheckChangeAdminChange`1<History>
struct  RoomCheckChangeAdminChange_1_t3028796038  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> RoomCheckChangeAdminChange`1::change
	VP_1_t2450154454 * ___change_5;
	// K RoomCheckChangeAdminChange`1::data
	History_t3838840324 * ___data_6;
	// Room RoomCheckChangeAdminChange`1::room
	Room_t1042398373 * ___room_7;

public:
	inline static int32_t get_offset_of_change_5() { return static_cast<int32_t>(offsetof(RoomCheckChangeAdminChange_1_t3028796038, ___change_5)); }
	inline VP_1_t2450154454 * get_change_5() const { return ___change_5; }
	inline VP_1_t2450154454 ** get_address_of_change_5() { return &___change_5; }
	inline void set_change_5(VP_1_t2450154454 * value)
	{
		___change_5 = value;
		Il2CppCodeGenWriteBarrier(&___change_5, value);
	}

	inline static int32_t get_offset_of_data_6() { return static_cast<int32_t>(offsetof(RoomCheckChangeAdminChange_1_t3028796038, ___data_6)); }
	inline History_t3838840324 * get_data_6() const { return ___data_6; }
	inline History_t3838840324 ** get_address_of_data_6() { return &___data_6; }
	inline void set_data_6(History_t3838840324 * value)
	{
		___data_6 = value;
		Il2CppCodeGenWriteBarrier(&___data_6, value);
	}

	inline static int32_t get_offset_of_room_7() { return static_cast<int32_t>(offsetof(RoomCheckChangeAdminChange_1_t3028796038, ___room_7)); }
	inline Room_t1042398373 * get_room_7() const { return ___room_7; }
	inline Room_t1042398373 ** get_address_of_room_7() { return &___room_7; }
	inline void set_room_7(Room_t1042398373 * value)
	{
		___room_7 = value;
		Il2CppCodeGenWriteBarrier(&___room_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
