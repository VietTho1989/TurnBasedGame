#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.ContestManagerStateLobby>>
struct VP_1_t2881349963;
// LP`1<GameManager.Match.LobbyTeamHolder/UIData>
struct LP_1_t1316461766;
// System.Collections.Generic.List`1<GameManager.Match.LobbyTeam>
struct List_1_t47945513;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.LobbyTeamAdapter/UIData
struct  UIData_t296122619  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.ContestManagerStateLobby>> GameManager.Match.LobbyTeamAdapter/UIData::contestManagerStateLobby
	VP_1_t2881349963 * ___contestManagerStateLobby_20;
	// LP`1<GameManager.Match.LobbyTeamHolder/UIData> GameManager.Match.LobbyTeamAdapter/UIData::holders
	LP_1_t1316461766 * ___holders_21;
	// System.Collections.Generic.List`1<GameManager.Match.LobbyTeam> GameManager.Match.LobbyTeamAdapter/UIData::lobbyTeams
	List_1_t47945513 * ___lobbyTeams_22;

public:
	inline static int32_t get_offset_of_contestManagerStateLobby_20() { return static_cast<int32_t>(offsetof(UIData_t296122619, ___contestManagerStateLobby_20)); }
	inline VP_1_t2881349963 * get_contestManagerStateLobby_20() const { return ___contestManagerStateLobby_20; }
	inline VP_1_t2881349963 ** get_address_of_contestManagerStateLobby_20() { return &___contestManagerStateLobby_20; }
	inline void set_contestManagerStateLobby_20(VP_1_t2881349963 * value)
	{
		___contestManagerStateLobby_20 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStateLobby_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t296122619, ___holders_21)); }
	inline LP_1_t1316461766 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t1316461766 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t1316461766 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_lobbyTeams_22() { return static_cast<int32_t>(offsetof(UIData_t296122619, ___lobbyTeams_22)); }
	inline List_1_t47945513 * get_lobbyTeams_22() const { return ___lobbyTeams_22; }
	inline List_1_t47945513 ** get_address_of_lobbyTeams_22() { return &___lobbyTeams_22; }
	inline void set_lobbyTeams_22(List_1_t47945513 * value)
	{
		___lobbyTeams_22 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyTeams_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
