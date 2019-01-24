#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen611246445.h"

// Room
struct Room_t1042398373;
// RoomCheckChangeAdminChange`1<GameManager.Match.Swap.SwapRequestStateAsk>
struct RoomCheckChangeAdminChange_1_t3580543762;
// GameManager.Match.ContestManagerStatePlay
struct ContestManagerStatePlay_t4088911568;
// GameManager.Match.ContestManagerStatePlayTeamCheckChange`1<GameManager.Match.ContestManagerStatePlay>
struct ContestManagerStatePlayTeamCheckChange_1_t271771593;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapRequestStateAskUpdate
struct  SwapRequestStateAskUpdate_t321361105  : public UpdateBehavior_1_t611246445
{
public:
	// Room GameManager.Match.Swap.SwapRequestStateAskUpdate::room
	Room_t1042398373 * ___room_4;
	// RoomCheckChangeAdminChange`1<GameManager.Match.Swap.SwapRequestStateAsk> GameManager.Match.Swap.SwapRequestStateAskUpdate::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t3580543762 * ___roomCheckAdminChange_5;
	// GameManager.Match.ContestManagerStatePlay GameManager.Match.Swap.SwapRequestStateAskUpdate::contestManagerStatePlay
	ContestManagerStatePlay_t4088911568 * ___contestManagerStatePlay_6;
	// GameManager.Match.ContestManagerStatePlayTeamCheckChange`1<GameManager.Match.ContestManagerStatePlay> GameManager.Match.Swap.SwapRequestStateAskUpdate::contestManagerStatePlayTeamCheckChange
	ContestManagerStatePlayTeamCheckChange_1_t271771593 * ___contestManagerStatePlayTeamCheckChange_7;

public:
	inline static int32_t get_offset_of_room_4() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUpdate_t321361105, ___room_4)); }
	inline Room_t1042398373 * get_room_4() const { return ___room_4; }
	inline Room_t1042398373 ** get_address_of_room_4() { return &___room_4; }
	inline void set_room_4(Room_t1042398373 * value)
	{
		___room_4 = value;
		Il2CppCodeGenWriteBarrier(&___room_4, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_5() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUpdate_t321361105, ___roomCheckAdminChange_5)); }
	inline RoomCheckChangeAdminChange_1_t3580543762 * get_roomCheckAdminChange_5() const { return ___roomCheckAdminChange_5; }
	inline RoomCheckChangeAdminChange_1_t3580543762 ** get_address_of_roomCheckAdminChange_5() { return &___roomCheckAdminChange_5; }
	inline void set_roomCheckAdminChange_5(RoomCheckChangeAdminChange_1_t3580543762 * value)
	{
		___roomCheckAdminChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_5, value);
	}

	inline static int32_t get_offset_of_contestManagerStatePlay_6() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUpdate_t321361105, ___contestManagerStatePlay_6)); }
	inline ContestManagerStatePlay_t4088911568 * get_contestManagerStatePlay_6() const { return ___contestManagerStatePlay_6; }
	inline ContestManagerStatePlay_t4088911568 ** get_address_of_contestManagerStatePlay_6() { return &___contestManagerStatePlay_6; }
	inline void set_contestManagerStatePlay_6(ContestManagerStatePlay_t4088911568 * value)
	{
		___contestManagerStatePlay_6 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlay_6, value);
	}

	inline static int32_t get_offset_of_contestManagerStatePlayTeamCheckChange_7() { return static_cast<int32_t>(offsetof(SwapRequestStateAskUpdate_t321361105, ___contestManagerStatePlayTeamCheckChange_7)); }
	inline ContestManagerStatePlayTeamCheckChange_1_t271771593 * get_contestManagerStatePlayTeamCheckChange_7() const { return ___contestManagerStatePlayTeamCheckChange_7; }
	inline ContestManagerStatePlayTeamCheckChange_1_t271771593 ** get_address_of_contestManagerStatePlayTeamCheckChange_7() { return &___contestManagerStatePlayTeamCheckChange_7; }
	inline void set_contestManagerStatePlayTeamCheckChange_7(ContestManagerStatePlayTeamCheckChange_1_t271771593 * value)
	{
		___contestManagerStatePlayTeamCheckChange_7 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlayTeamCheckChange_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
