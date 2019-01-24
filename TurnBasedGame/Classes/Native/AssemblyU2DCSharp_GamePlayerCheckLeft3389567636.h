#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3269890400.h"

// RoomCheckChangeAdminChange`1<GamePlayer>
struct RoomCheckChangeAdminChange_1_t1944220421;
// GameIsPlayingChange`1<GamePlayer>
struct GameIsPlayingChange_1_t4066358769;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GamePlayerCheckLeft
struct  GamePlayerCheckLeft_t3389567636  : public UpdateBehavior_1_t3269890400
{
public:
	// RoomCheckChangeAdminChange`1<GamePlayer> GamePlayerCheckLeft::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t1944220421 * ___roomCheckAdminChange_4;
	// GameIsPlayingChange`1<GamePlayer> GamePlayerCheckLeft::gameIsPlayingChange
	GameIsPlayingChange_1_t4066358769 * ___gameIsPlayingChange_5;

public:
	inline static int32_t get_offset_of_roomCheckAdminChange_4() { return static_cast<int32_t>(offsetof(GamePlayerCheckLeft_t3389567636, ___roomCheckAdminChange_4)); }
	inline RoomCheckChangeAdminChange_1_t1944220421 * get_roomCheckAdminChange_4() const { return ___roomCheckAdminChange_4; }
	inline RoomCheckChangeAdminChange_1_t1944220421 ** get_address_of_roomCheckAdminChange_4() { return &___roomCheckAdminChange_4; }
	inline void set_roomCheckAdminChange_4(RoomCheckChangeAdminChange_1_t1944220421 * value)
	{
		___roomCheckAdminChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_4, value);
	}

	inline static int32_t get_offset_of_gameIsPlayingChange_5() { return static_cast<int32_t>(offsetof(GamePlayerCheckLeft_t3389567636, ___gameIsPlayingChange_5)); }
	inline GameIsPlayingChange_1_t4066358769 * get_gameIsPlayingChange_5() const { return ___gameIsPlayingChange_5; }
	inline GameIsPlayingChange_1_t4066358769 ** get_address_of_gameIsPlayingChange_5() { return &___gameIsPlayingChange_5; }
	inline void set_gameIsPlayingChange_5(GameIsPlayingChange_1_t4066358769 * value)
	{
		___gameIsPlayingChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameIsPlayingChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
