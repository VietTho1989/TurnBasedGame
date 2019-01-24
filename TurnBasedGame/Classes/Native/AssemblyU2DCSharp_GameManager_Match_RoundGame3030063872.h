#pragma once

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
// LP`1<System.Int32>
struct LP_1_t809621404;
// VP`1<Game>
struct VP_1_t1978418220;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundGame
struct  RoundGame_t3030063872  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GameManager.Match.RoundGame::index
	VP_1_t2450154454 * ___index_5;
	// LP`1<System.Int32> GameManager.Match.RoundGame::playerInTeam
	LP_1_t809621404 * ___playerInTeam_6;
	// LP`1<System.Int32> GameManager.Match.RoundGame::playerInGame
	LP_1_t809621404 * ___playerInGame_7;
	// VP`1<Game> GameManager.Match.RoundGame::game
	VP_1_t1978418220 * ___game_8;

public:
	inline static int32_t get_offset_of_index_5() { return static_cast<int32_t>(offsetof(RoundGame_t3030063872, ___index_5)); }
	inline VP_1_t2450154454 * get_index_5() const { return ___index_5; }
	inline VP_1_t2450154454 ** get_address_of_index_5() { return &___index_5; }
	inline void set_index_5(VP_1_t2450154454 * value)
	{
		___index_5 = value;
		Il2CppCodeGenWriteBarrier(&___index_5, value);
	}

	inline static int32_t get_offset_of_playerInTeam_6() { return static_cast<int32_t>(offsetof(RoundGame_t3030063872, ___playerInTeam_6)); }
	inline LP_1_t809621404 * get_playerInTeam_6() const { return ___playerInTeam_6; }
	inline LP_1_t809621404 ** get_address_of_playerInTeam_6() { return &___playerInTeam_6; }
	inline void set_playerInTeam_6(LP_1_t809621404 * value)
	{
		___playerInTeam_6 = value;
		Il2CppCodeGenWriteBarrier(&___playerInTeam_6, value);
	}

	inline static int32_t get_offset_of_playerInGame_7() { return static_cast<int32_t>(offsetof(RoundGame_t3030063872, ___playerInGame_7)); }
	inline LP_1_t809621404 * get_playerInGame_7() const { return ___playerInGame_7; }
	inline LP_1_t809621404 ** get_address_of_playerInGame_7() { return &___playerInGame_7; }
	inline void set_playerInGame_7(LP_1_t809621404 * value)
	{
		___playerInGame_7 = value;
		Il2CppCodeGenWriteBarrier(&___playerInGame_7, value);
	}

	inline static int32_t get_offset_of_game_8() { return static_cast<int32_t>(offsetof(RoundGame_t3030063872, ___game_8)); }
	inline VP_1_t1978418220 * get_game_8() const { return ___game_8; }
	inline VP_1_t1978418220 ** get_address_of_game_8() { return &___game_8; }
	inline void set_game_8(VP_1_t1978418220 * value)
	{
		___game_8 = value;
		Il2CppCodeGenWriteBarrier(&___game_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
