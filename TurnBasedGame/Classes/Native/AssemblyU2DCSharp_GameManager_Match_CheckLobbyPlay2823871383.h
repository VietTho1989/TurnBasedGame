#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3947915587.h"

// RoomCheckChangeAdminChange`1<GameManager.Match.ContestManagerStateLobby>
struct RoomCheckChangeAdminChange_1_t2622245608;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.CheckLobbyPlayerInsideRoomUpdate
struct  CheckLobbyPlayerInsideRoomUpdate_t2823871383  : public UpdateBehavior_1_t3947915587
{
public:
	// RoomCheckChangeAdminChange`1<GameManager.Match.ContestManagerStateLobby> GameManager.Match.CheckLobbyPlayerInsideRoomUpdate::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t2622245608 * ___roomCheckAdminChange_4;

public:
	inline static int32_t get_offset_of_roomCheckAdminChange_4() { return static_cast<int32_t>(offsetof(CheckLobbyPlayerInsideRoomUpdate_t2823871383, ___roomCheckAdminChange_4)); }
	inline RoomCheckChangeAdminChange_1_t2622245608 * get_roomCheckAdminChange_4() const { return ___roomCheckAdminChange_4; }
	inline RoomCheckChangeAdminChange_1_t2622245608 ** get_address_of_roomCheckAdminChange_4() { return &___roomCheckAdminChange_4; }
	inline void set_roomCheckAdminChange_4(RoomCheckChangeAdminChange_1_t2622245608 * value)
	{
		___roomCheckAdminChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
