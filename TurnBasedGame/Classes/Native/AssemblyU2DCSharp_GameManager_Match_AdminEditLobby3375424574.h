#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.LobbyPlayer>>
struct VP_1_t991913064;
// VP`1<GameManager.Match.AdminEditLobbyPlayerHumanUI/UIData/State>
struct VP_1_t4258154182;
// VP`1<GameManager.Match.AdminEditLobbyPlayerChooseHumanAdapter/UIData>
struct VP_1_t1988420386;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.AdminEditLobbyPlayerHumanUI/UIData
struct  UIData_t3375424574  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.LobbyPlayer>> GameManager.Match.AdminEditLobbyPlayerHumanUI/UIData::lobbyPlayer
	VP_1_t991913064 * ___lobbyPlayer_5;
	// VP`1<GameManager.Match.AdminEditLobbyPlayerHumanUI/UIData/State> GameManager.Match.AdminEditLobbyPlayerHumanUI/UIData::state
	VP_1_t4258154182 * ___state_6;
	// VP`1<GameManager.Match.AdminEditLobbyPlayerChooseHumanAdapter/UIData> GameManager.Match.AdminEditLobbyPlayerHumanUI/UIData::humanAdapter
	VP_1_t1988420386 * ___humanAdapter_7;

public:
	inline static int32_t get_offset_of_lobbyPlayer_5() { return static_cast<int32_t>(offsetof(UIData_t3375424574, ___lobbyPlayer_5)); }
	inline VP_1_t991913064 * get_lobbyPlayer_5() const { return ___lobbyPlayer_5; }
	inline VP_1_t991913064 ** get_address_of_lobbyPlayer_5() { return &___lobbyPlayer_5; }
	inline void set_lobbyPlayer_5(VP_1_t991913064 * value)
	{
		___lobbyPlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyPlayer_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t3375424574, ___state_6)); }
	inline VP_1_t4258154182 * get_state_6() const { return ___state_6; }
	inline VP_1_t4258154182 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t4258154182 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}

	inline static int32_t get_offset_of_humanAdapter_7() { return static_cast<int32_t>(offsetof(UIData_t3375424574, ___humanAdapter_7)); }
	inline VP_1_t1988420386 * get_humanAdapter_7() const { return ___humanAdapter_7; }
	inline VP_1_t1988420386 ** get_address_of_humanAdapter_7() { return &___humanAdapter_7; }
	inline void set_humanAdapter_7(VP_1_t1988420386 * value)
	{
		___humanAdapter_7 = value;
		Il2CppCodeGenWriteBarrier(&___humanAdapter_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
