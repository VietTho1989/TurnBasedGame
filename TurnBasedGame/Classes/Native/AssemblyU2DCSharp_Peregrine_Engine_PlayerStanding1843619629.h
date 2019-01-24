#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_Decimal724701077.h"

// Peregrine.Engine.Player
struct Player_t762644161;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.PlayerStanding
struct  PlayerStanding_t1843619629  : public Il2CppObject
{
public:
	// Peregrine.Engine.Player Peregrine.Engine.PlayerStanding::Player
	Player_t762644161 * ___Player_0;
	// System.Int32 Peregrine.Engine.PlayerStanding::Rank
	int32_t ___Rank_1;
	// System.Decimal Peregrine.Engine.PlayerStanding::MatchPoints
	Decimal_t724701077  ___MatchPoints_2;
	// System.Decimal Peregrine.Engine.PlayerStanding::OpponentsMatchWinPercentage
	Decimal_t724701077  ___OpponentsMatchWinPercentage_3;
	// System.Decimal Peregrine.Engine.PlayerStanding::GameWinPercentage
	Decimal_t724701077  ___GameWinPercentage_4;
	// System.Decimal Peregrine.Engine.PlayerStanding::OpponentsGameWinPercentage
	Decimal_t724701077  ___OpponentsGameWinPercentage_5;

public:
	inline static int32_t get_offset_of_Player_0() { return static_cast<int32_t>(offsetof(PlayerStanding_t1843619629, ___Player_0)); }
	inline Player_t762644161 * get_Player_0() const { return ___Player_0; }
	inline Player_t762644161 ** get_address_of_Player_0() { return &___Player_0; }
	inline void set_Player_0(Player_t762644161 * value)
	{
		___Player_0 = value;
		Il2CppCodeGenWriteBarrier(&___Player_0, value);
	}

	inline static int32_t get_offset_of_Rank_1() { return static_cast<int32_t>(offsetof(PlayerStanding_t1843619629, ___Rank_1)); }
	inline int32_t get_Rank_1() const { return ___Rank_1; }
	inline int32_t* get_address_of_Rank_1() { return &___Rank_1; }
	inline void set_Rank_1(int32_t value)
	{
		___Rank_1 = value;
	}

	inline static int32_t get_offset_of_MatchPoints_2() { return static_cast<int32_t>(offsetof(PlayerStanding_t1843619629, ___MatchPoints_2)); }
	inline Decimal_t724701077  get_MatchPoints_2() const { return ___MatchPoints_2; }
	inline Decimal_t724701077 * get_address_of_MatchPoints_2() { return &___MatchPoints_2; }
	inline void set_MatchPoints_2(Decimal_t724701077  value)
	{
		___MatchPoints_2 = value;
	}

	inline static int32_t get_offset_of_OpponentsMatchWinPercentage_3() { return static_cast<int32_t>(offsetof(PlayerStanding_t1843619629, ___OpponentsMatchWinPercentage_3)); }
	inline Decimal_t724701077  get_OpponentsMatchWinPercentage_3() const { return ___OpponentsMatchWinPercentage_3; }
	inline Decimal_t724701077 * get_address_of_OpponentsMatchWinPercentage_3() { return &___OpponentsMatchWinPercentage_3; }
	inline void set_OpponentsMatchWinPercentage_3(Decimal_t724701077  value)
	{
		___OpponentsMatchWinPercentage_3 = value;
	}

	inline static int32_t get_offset_of_GameWinPercentage_4() { return static_cast<int32_t>(offsetof(PlayerStanding_t1843619629, ___GameWinPercentage_4)); }
	inline Decimal_t724701077  get_GameWinPercentage_4() const { return ___GameWinPercentage_4; }
	inline Decimal_t724701077 * get_address_of_GameWinPercentage_4() { return &___GameWinPercentage_4; }
	inline void set_GameWinPercentage_4(Decimal_t724701077  value)
	{
		___GameWinPercentage_4 = value;
	}

	inline static int32_t get_offset_of_OpponentsGameWinPercentage_5() { return static_cast<int32_t>(offsetof(PlayerStanding_t1843619629, ___OpponentsGameWinPercentage_5)); }
	inline Decimal_t724701077  get_OpponentsGameWinPercentage_5() const { return ___OpponentsGameWinPercentage_5; }
	inline Decimal_t724701077 * get_address_of_OpponentsGameWinPercentage_5() { return &___OpponentsGameWinPercentage_5; }
	inline void set_OpponentsGameWinPercentage_5(Decimal_t724701077  value)
	{
		___OpponentsGameWinPercentage_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
