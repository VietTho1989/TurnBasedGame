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
// VP`1<GameManager.Match.AdminEditLobbyPlayerEmptyUI/UIData/State>
struct VP_1_t3173505206;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.AdminEditLobbyPlayerEmptyUI/UIData
struct  UIData_t3478179038  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.LobbyPlayer>> GameManager.Match.AdminEditLobbyPlayerEmptyUI/UIData::lobbyPlayer
	VP_1_t991913064 * ___lobbyPlayer_5;
	// VP`1<GameManager.Match.AdminEditLobbyPlayerEmptyUI/UIData/State> GameManager.Match.AdminEditLobbyPlayerEmptyUI/UIData::state
	VP_1_t3173505206 * ___state_6;

public:
	inline static int32_t get_offset_of_lobbyPlayer_5() { return static_cast<int32_t>(offsetof(UIData_t3478179038, ___lobbyPlayer_5)); }
	inline VP_1_t991913064 * get_lobbyPlayer_5() const { return ___lobbyPlayer_5; }
	inline VP_1_t991913064 ** get_address_of_lobbyPlayer_5() { return &___lobbyPlayer_5; }
	inline void set_lobbyPlayer_5(VP_1_t991913064 * value)
	{
		___lobbyPlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyPlayer_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t3478179038, ___state_6)); }
	inline VP_1_t3173505206 * get_state_6() const { return ___state_6; }
	inline VP_1_t3173505206 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t3173505206 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
