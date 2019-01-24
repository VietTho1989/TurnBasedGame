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
// VP`1<ComputerUI/UIData>
struct VP_1_t1050701168;
// VP`1<GameManager.Match.AdminEditLobbyPlayerComputerUI/UIData/State>
struct VP_1_t2661166034;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.AdminEditLobbyPlayerComputerUI/UIData
struct  UIData_t3918013858  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.LobbyPlayer>> GameManager.Match.AdminEditLobbyPlayerComputerUI/UIData::lobbyPlayer
	VP_1_t991913064 * ___lobbyPlayer_5;
	// VP`1<ComputerUI/UIData> GameManager.Match.AdminEditLobbyPlayerComputerUI/UIData::editComputer
	VP_1_t1050701168 * ___editComputer_6;
	// VP`1<GameManager.Match.AdminEditLobbyPlayerComputerUI/UIData/State> GameManager.Match.AdminEditLobbyPlayerComputerUI/UIData::state
	VP_1_t2661166034 * ___state_7;

public:
	inline static int32_t get_offset_of_lobbyPlayer_5() { return static_cast<int32_t>(offsetof(UIData_t3918013858, ___lobbyPlayer_5)); }
	inline VP_1_t991913064 * get_lobbyPlayer_5() const { return ___lobbyPlayer_5; }
	inline VP_1_t991913064 ** get_address_of_lobbyPlayer_5() { return &___lobbyPlayer_5; }
	inline void set_lobbyPlayer_5(VP_1_t991913064 * value)
	{
		___lobbyPlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyPlayer_5, value);
	}

	inline static int32_t get_offset_of_editComputer_6() { return static_cast<int32_t>(offsetof(UIData_t3918013858, ___editComputer_6)); }
	inline VP_1_t1050701168 * get_editComputer_6() const { return ___editComputer_6; }
	inline VP_1_t1050701168 ** get_address_of_editComputer_6() { return &___editComputer_6; }
	inline void set_editComputer_6(VP_1_t1050701168 * value)
	{
		___editComputer_6 = value;
		Il2CppCodeGenWriteBarrier(&___editComputer_6, value);
	}

	inline static int32_t get_offset_of_state_7() { return static_cast<int32_t>(offsetof(UIData_t3918013858, ___state_7)); }
	inline VP_1_t2661166034 * get_state_7() const { return ___state_7; }
	inline VP_1_t2661166034 ** get_address_of_state_7() { return &___state_7; }
	inline void set_state_7(VP_1_t2661166034 * value)
	{
		___state_7 = value;
		Il2CppCodeGenWriteBarrier(&___state_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
