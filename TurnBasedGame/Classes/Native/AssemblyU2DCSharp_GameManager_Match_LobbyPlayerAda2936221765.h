#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.LobbyTeam>>
struct VP_1_t127884450;
// LP`1<GameManager.Match.LobbyPlayerHolder/UIData>
struct LP_1_t2944858074;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.LobbyPlayerAdapter/UIData
struct  UIData_t2936221765  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.LobbyTeam>> GameManager.Match.LobbyPlayerAdapter/UIData::lobbyTeam
	VP_1_t127884450 * ___lobbyTeam_5;
	// LP`1<GameManager.Match.LobbyPlayerHolder/UIData> GameManager.Match.LobbyPlayerAdapter/UIData::holders
	LP_1_t2944858074 * ___holders_6;

public:
	inline static int32_t get_offset_of_lobbyTeam_5() { return static_cast<int32_t>(offsetof(UIData_t2936221765, ___lobbyTeam_5)); }
	inline VP_1_t127884450 * get_lobbyTeam_5() const { return ___lobbyTeam_5; }
	inline VP_1_t127884450 ** get_address_of_lobbyTeam_5() { return &___lobbyTeam_5; }
	inline void set_lobbyTeam_5(VP_1_t127884450 * value)
	{
		___lobbyTeam_5 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyTeam_5, value);
	}

	inline static int32_t get_offset_of_holders_6() { return static_cast<int32_t>(offsetof(UIData_t2936221765, ___holders_6)); }
	inline LP_1_t2944858074 * get_holders_6() const { return ___holders_6; }
	inline LP_1_t2944858074 ** get_address_of_holders_6() { return &___holders_6; }
	inline void set_holders_6(LP_1_t2944858074 * value)
	{
		___holders_6 = value;
		Il2CppCodeGenWriteBarrier(&___holders_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
