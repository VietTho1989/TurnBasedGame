#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_ContestManager3342620467.h"

// VP`1<GameManager.Match.ContestManagerStateLobby/State>
struct VP_1_t3737908020;
// LP`1<GameManager.Match.LobbyTeam>
struct LP_1_t3711535633;
// VP`1<GameType/Type>
struct VP_1_t2728349165;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<GameManager.Match.ContestManagerContentFactory>
struct VP_1_t1204035838;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManagerStateLobby
struct  ContestManagerStateLobby_t3432289894  : public State_t3342620467
{
public:
	// VP`1<GameManager.Match.ContestManagerStateLobby/State> GameManager.Match.ContestManagerStateLobby::state
	VP_1_t3737908020 * ___state_6;
	// LP`1<GameManager.Match.LobbyTeam> GameManager.Match.ContestManagerStateLobby::teams
	LP_1_t3711535633 * ___teams_7;
	// VP`1<GameType/Type> GameManager.Match.ContestManagerStateLobby::gameType
	VP_1_t2728349165 * ___gameType_8;
	// VP`1<System.Boolean> GameManager.Match.ContestManagerStateLobby::randomTeamIndex
	VP_1_t4203851724 * ___randomTeamIndex_9;
	// VP`1<GameManager.Match.ContestManagerContentFactory> GameManager.Match.ContestManagerStateLobby::contentFactory
	VP_1_t1204035838 * ___contentFactory_10;

public:
	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(ContestManagerStateLobby_t3432289894, ___state_6)); }
	inline VP_1_t3737908020 * get_state_6() const { return ___state_6; }
	inline VP_1_t3737908020 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t3737908020 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}

	inline static int32_t get_offset_of_teams_7() { return static_cast<int32_t>(offsetof(ContestManagerStateLobby_t3432289894, ___teams_7)); }
	inline LP_1_t3711535633 * get_teams_7() const { return ___teams_7; }
	inline LP_1_t3711535633 ** get_address_of_teams_7() { return &___teams_7; }
	inline void set_teams_7(LP_1_t3711535633 * value)
	{
		___teams_7 = value;
		Il2CppCodeGenWriteBarrier(&___teams_7, value);
	}

	inline static int32_t get_offset_of_gameType_8() { return static_cast<int32_t>(offsetof(ContestManagerStateLobby_t3432289894, ___gameType_8)); }
	inline VP_1_t2728349165 * get_gameType_8() const { return ___gameType_8; }
	inline VP_1_t2728349165 ** get_address_of_gameType_8() { return &___gameType_8; }
	inline void set_gameType_8(VP_1_t2728349165 * value)
	{
		___gameType_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameType_8, value);
	}

	inline static int32_t get_offset_of_randomTeamIndex_9() { return static_cast<int32_t>(offsetof(ContestManagerStateLobby_t3432289894, ___randomTeamIndex_9)); }
	inline VP_1_t4203851724 * get_randomTeamIndex_9() const { return ___randomTeamIndex_9; }
	inline VP_1_t4203851724 ** get_address_of_randomTeamIndex_9() { return &___randomTeamIndex_9; }
	inline void set_randomTeamIndex_9(VP_1_t4203851724 * value)
	{
		___randomTeamIndex_9 = value;
		Il2CppCodeGenWriteBarrier(&___randomTeamIndex_9, value);
	}

	inline static int32_t get_offset_of_contentFactory_10() { return static_cast<int32_t>(offsetof(ContestManagerStateLobby_t3432289894, ___contentFactory_10)); }
	inline VP_1_t1204035838 * get_contentFactory_10() const { return ___contentFactory_10; }
	inline VP_1_t1204035838 ** get_address_of_contentFactory_10() { return &___contentFactory_10; }
	inline void set_contentFactory_10(VP_1_t1204035838 * value)
	{
		___contentFactory_10 = value;
		Il2CppCodeGenWriteBarrier(&___contentFactory_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
