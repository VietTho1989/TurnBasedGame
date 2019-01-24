#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3524692564.h"

// Room
struct Room_t1042398373;
// GameManager.Match.ContestManagerStatePlay
struct ContestManagerStatePlay_t4088911568;
// GameManager.Match.ContestManagerStatePlayTeamCheckChange`1<GameManager.Match.ContestManagerStatePlay>
struct ContestManagerStatePlayTeamCheckChange_1_t271771593;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapUpdate
struct  SwapUpdate_t804882650  : public UpdateBehavior_1_t3524692564
{
public:
	// Room GameManager.Match.Swap.SwapUpdate::room
	Room_t1042398373 * ___room_4;
	// GameManager.Match.ContestManagerStatePlay GameManager.Match.Swap.SwapUpdate::contestManagerStatePlay
	ContestManagerStatePlay_t4088911568 * ___contestManagerStatePlay_5;
	// GameManager.Match.ContestManagerStatePlayTeamCheckChange`1<GameManager.Match.ContestManagerStatePlay> GameManager.Match.Swap.SwapUpdate::contestManagerStatePlayTeamCheckChange
	ContestManagerStatePlayTeamCheckChange_1_t271771593 * ___contestManagerStatePlayTeamCheckChange_6;

public:
	inline static int32_t get_offset_of_room_4() { return static_cast<int32_t>(offsetof(SwapUpdate_t804882650, ___room_4)); }
	inline Room_t1042398373 * get_room_4() const { return ___room_4; }
	inline Room_t1042398373 ** get_address_of_room_4() { return &___room_4; }
	inline void set_room_4(Room_t1042398373 * value)
	{
		___room_4 = value;
		Il2CppCodeGenWriteBarrier(&___room_4, value);
	}

	inline static int32_t get_offset_of_contestManagerStatePlay_5() { return static_cast<int32_t>(offsetof(SwapUpdate_t804882650, ___contestManagerStatePlay_5)); }
	inline ContestManagerStatePlay_t4088911568 * get_contestManagerStatePlay_5() const { return ___contestManagerStatePlay_5; }
	inline ContestManagerStatePlay_t4088911568 ** get_address_of_contestManagerStatePlay_5() { return &___contestManagerStatePlay_5; }
	inline void set_contestManagerStatePlay_5(ContestManagerStatePlay_t4088911568 * value)
	{
		___contestManagerStatePlay_5 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlay_5, value);
	}

	inline static int32_t get_offset_of_contestManagerStatePlayTeamCheckChange_6() { return static_cast<int32_t>(offsetof(SwapUpdate_t804882650, ___contestManagerStatePlayTeamCheckChange_6)); }
	inline ContestManagerStatePlayTeamCheckChange_1_t271771593 * get_contestManagerStatePlayTeamCheckChange_6() const { return ___contestManagerStatePlayTeamCheckChange_6; }
	inline ContestManagerStatePlayTeamCheckChange_1_t271771593 ** get_address_of_contestManagerStatePlayTeamCheckChange_6() { return &___contestManagerStatePlayTeamCheckChange_6; }
	inline void set_contestManagerStatePlayTeamCheckChange_6(ContestManagerStatePlayTeamCheckChange_1_t271771593 * value)
	{
		___contestManagerStatePlayTeamCheckChange_6 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlayTeamCheckChange_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
