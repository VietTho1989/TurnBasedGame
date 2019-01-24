#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1196055060.h"

// VP`1<ReferenceData`1<GameManager.Match.LobbyTeam>>
struct VP_1_t127884450;
// VP`1<GameManager.Match.LobbyPlayerAdapter/UIData>
struct VP_1_t3314498771;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.LobbyTeamHolder/UIData
struct  UIData_t2578717810  : public BaseItemViewsHolder_t1196055060
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.LobbyTeam>> GameManager.Match.LobbyTeamHolder/UIData::lobbyTeam
	VP_1_t127884450 * ___lobbyTeam_8;
	// VP`1<GameManager.Match.LobbyPlayerAdapter/UIData> GameManager.Match.LobbyTeamHolder/UIData::playerAdapter
	VP_1_t3314498771 * ___playerAdapter_9;

public:
	inline static int32_t get_offset_of_lobbyTeam_8() { return static_cast<int32_t>(offsetof(UIData_t2578717810, ___lobbyTeam_8)); }
	inline VP_1_t127884450 * get_lobbyTeam_8() const { return ___lobbyTeam_8; }
	inline VP_1_t127884450 ** get_address_of_lobbyTeam_8() { return &___lobbyTeam_8; }
	inline void set_lobbyTeam_8(VP_1_t127884450 * value)
	{
		___lobbyTeam_8 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyTeam_8, value);
	}

	inline static int32_t get_offset_of_playerAdapter_9() { return static_cast<int32_t>(offsetof(UIData_t2578717810, ___playerAdapter_9)); }
	inline VP_1_t3314498771 * get_playerAdapter_9() const { return ___playerAdapter_9; }
	inline VP_1_t3314498771 ** get_address_of_playerAdapter_9() { return &___playerAdapter_9; }
	inline void set_playerAdapter_9(VP_1_t3314498771 * value)
	{
		___playerAdapter_9 = value;
		Il2CppCodeGenWriteBarrier(&___playerAdapter_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
