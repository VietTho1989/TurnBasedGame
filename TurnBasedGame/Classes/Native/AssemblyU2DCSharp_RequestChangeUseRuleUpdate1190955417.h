#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2001562575.h"

// RoomCheckChangeAdminChange`1<RequestChangeUseRule>
struct RoomCheckChangeAdminChange_1_t675892596;
// GameCheckPlayerChange`1<RequestChangeUseRule>
struct GameCheckPlayerChange_1_t517111999;
// Room
struct Room_t1042398373;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestChangeUseRuleUpdate
struct  RequestChangeUseRuleUpdate_t1190955417  : public UpdateBehavior_1_t2001562575
{
public:
	// RoomCheckChangeAdminChange`1<RequestChangeUseRule> RequestChangeUseRuleUpdate::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t675892596 * ___roomCheckAdminChange_4;
	// GameCheckPlayerChange`1<RequestChangeUseRule> RequestChangeUseRuleUpdate::gameCheckPlayerChange
	GameCheckPlayerChange_1_t517111999 * ___gameCheckPlayerChange_5;
	// Room RequestChangeUseRuleUpdate::room
	Room_t1042398373 * ___room_6;

public:
	inline static int32_t get_offset_of_roomCheckAdminChange_4() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleUpdate_t1190955417, ___roomCheckAdminChange_4)); }
	inline RoomCheckChangeAdminChange_1_t675892596 * get_roomCheckAdminChange_4() const { return ___roomCheckAdminChange_4; }
	inline RoomCheckChangeAdminChange_1_t675892596 ** get_address_of_roomCheckAdminChange_4() { return &___roomCheckAdminChange_4; }
	inline void set_roomCheckAdminChange_4(RoomCheckChangeAdminChange_1_t675892596 * value)
	{
		___roomCheckAdminChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_4, value);
	}

	inline static int32_t get_offset_of_gameCheckPlayerChange_5() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleUpdate_t1190955417, ___gameCheckPlayerChange_5)); }
	inline GameCheckPlayerChange_1_t517111999 * get_gameCheckPlayerChange_5() const { return ___gameCheckPlayerChange_5; }
	inline GameCheckPlayerChange_1_t517111999 ** get_address_of_gameCheckPlayerChange_5() { return &___gameCheckPlayerChange_5; }
	inline void set_gameCheckPlayerChange_5(GameCheckPlayerChange_1_t517111999 * value)
	{
		___gameCheckPlayerChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameCheckPlayerChange_5, value);
	}

	inline static int32_t get_offset_of_room_6() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleUpdate_t1190955417, ___room_6)); }
	inline Room_t1042398373 * get_room_6() const { return ___room_6; }
	inline Room_t1042398373 ** get_address_of_room_6() { return &___room_6; }
	inline void set_room_6(Room_t1042398373 * value)
	{
		___room_6 = value;
		Il2CppCodeGenWriteBarrier(&___room_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
