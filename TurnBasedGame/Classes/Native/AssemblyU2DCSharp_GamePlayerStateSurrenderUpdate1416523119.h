#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2119740331.h"

// RoomCheckChangeAdminChange`1<GamePlayerStateSurrender>
struct RoomCheckChangeAdminChange_1_t794070352;
// GamePlayer
struct GamePlayer_t2754264707;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GamePlayerStateSurrenderUpdate
struct  GamePlayerStateSurrenderUpdate_t1416523119  : public UpdateBehavior_1_t2119740331
{
public:
	// RoomCheckChangeAdminChange`1<GamePlayerStateSurrender> GamePlayerStateSurrenderUpdate::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t794070352 * ___roomCheckAdminChange_4;
	// GamePlayer GamePlayerStateSurrenderUpdate::gamePlayer
	GamePlayer_t2754264707 * ___gamePlayer_5;

public:
	inline static int32_t get_offset_of_roomCheckAdminChange_4() { return static_cast<int32_t>(offsetof(GamePlayerStateSurrenderUpdate_t1416523119, ___roomCheckAdminChange_4)); }
	inline RoomCheckChangeAdminChange_1_t794070352 * get_roomCheckAdminChange_4() const { return ___roomCheckAdminChange_4; }
	inline RoomCheckChangeAdminChange_1_t794070352 ** get_address_of_roomCheckAdminChange_4() { return &___roomCheckAdminChange_4; }
	inline void set_roomCheckAdminChange_4(RoomCheckChangeAdminChange_1_t794070352 * value)
	{
		___roomCheckAdminChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_4, value);
	}

	inline static int32_t get_offset_of_gamePlayer_5() { return static_cast<int32_t>(offsetof(GamePlayerStateSurrenderUpdate_t1416523119, ___gamePlayer_5)); }
	inline GamePlayer_t2754264707 * get_gamePlayer_5() const { return ___gamePlayer_5; }
	inline GamePlayer_t2754264707 ** get_address_of_gamePlayer_5() { return &___gamePlayer_5; }
	inline void set_gamePlayer_5(GamePlayer_t2754264707 * value)
	{
		___gamePlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___gamePlayer_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
