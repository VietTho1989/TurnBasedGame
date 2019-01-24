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
// LP`1<GameManager.Match.LobbyPlayer>
struct LP_1_t280596951;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.LobbyTeam
struct  LobbyTeam_t678824381  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GameManager.Match.LobbyTeam::teamIndex
	VP_1_t2450154454 * ___teamIndex_5;
	// LP`1<GameManager.Match.LobbyPlayer> GameManager.Match.LobbyTeam::players
	LP_1_t280596951 * ___players_6;

public:
	inline static int32_t get_offset_of_teamIndex_5() { return static_cast<int32_t>(offsetof(LobbyTeam_t678824381, ___teamIndex_5)); }
	inline VP_1_t2450154454 * get_teamIndex_5() const { return ___teamIndex_5; }
	inline VP_1_t2450154454 ** get_address_of_teamIndex_5() { return &___teamIndex_5; }
	inline void set_teamIndex_5(VP_1_t2450154454 * value)
	{
		___teamIndex_5 = value;
		Il2CppCodeGenWriteBarrier(&___teamIndex_5, value);
	}

	inline static int32_t get_offset_of_players_6() { return static_cast<int32_t>(offsetof(LobbyTeam_t678824381, ___players_6)); }
	inline LP_1_t280596951 * get_players_6() const { return ___players_6; }
	inline LP_1_t280596951 ** get_address_of_players_6() { return &___players_6; }
	inline void set_players_6(LP_1_t280596951 * value)
	{
		___players_6 = value;
		Il2CppCodeGenWriteBarrier(&___players_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
