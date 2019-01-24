#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_EditLobbyPlayer384552493.h"

// VP`1<ReferenceData`1<GameManager.Match.LobbyPlayer>>
struct VP_1_t991913064;
// VP`1<GamePlayer/Inform/Type>
struct VP_1_t2215072796;
// VP`1<GameManager.Match.AdminEditLobbyPlayerHumanUI/UIData>
struct VP_1_t3753701580;
// VP`1<GameManager.Match.AdminEditLobbyPlayerComputerUI/UIData>
struct VP_1_t1323568;
// VP`1<GameManager.Match.AdminEditLobbyPlayerEmptyUI/UIData>
struct VP_1_t3856456044;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.AdminEditLobbyPlayerUI/UIData
struct  UIData_t3021493825  : public Sub_t384552493
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.LobbyPlayer>> GameManager.Match.AdminEditLobbyPlayerUI/UIData::lobbyPlayer
	VP_1_t991913064 * ___lobbyPlayer_5;
	// VP`1<GamePlayer/Inform/Type> GameManager.Match.AdminEditLobbyPlayerUI/UIData::show
	VP_1_t2215072796 * ___show_6;
	// VP`1<GameManager.Match.AdminEditLobbyPlayerHumanUI/UIData> GameManager.Match.AdminEditLobbyPlayerUI/UIData::human
	VP_1_t3753701580 * ___human_7;
	// VP`1<GameManager.Match.AdminEditLobbyPlayerComputerUI/UIData> GameManager.Match.AdminEditLobbyPlayerUI/UIData::computer
	VP_1_t1323568 * ___computer_8;
	// VP`1<GameManager.Match.AdminEditLobbyPlayerEmptyUI/UIData> GameManager.Match.AdminEditLobbyPlayerUI/UIData::empty
	VP_1_t3856456044 * ___empty_9;

public:
	inline static int32_t get_offset_of_lobbyPlayer_5() { return static_cast<int32_t>(offsetof(UIData_t3021493825, ___lobbyPlayer_5)); }
	inline VP_1_t991913064 * get_lobbyPlayer_5() const { return ___lobbyPlayer_5; }
	inline VP_1_t991913064 ** get_address_of_lobbyPlayer_5() { return &___lobbyPlayer_5; }
	inline void set_lobbyPlayer_5(VP_1_t991913064 * value)
	{
		___lobbyPlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyPlayer_5, value);
	}

	inline static int32_t get_offset_of_show_6() { return static_cast<int32_t>(offsetof(UIData_t3021493825, ___show_6)); }
	inline VP_1_t2215072796 * get_show_6() const { return ___show_6; }
	inline VP_1_t2215072796 ** get_address_of_show_6() { return &___show_6; }
	inline void set_show_6(VP_1_t2215072796 * value)
	{
		___show_6 = value;
		Il2CppCodeGenWriteBarrier(&___show_6, value);
	}

	inline static int32_t get_offset_of_human_7() { return static_cast<int32_t>(offsetof(UIData_t3021493825, ___human_7)); }
	inline VP_1_t3753701580 * get_human_7() const { return ___human_7; }
	inline VP_1_t3753701580 ** get_address_of_human_7() { return &___human_7; }
	inline void set_human_7(VP_1_t3753701580 * value)
	{
		___human_7 = value;
		Il2CppCodeGenWriteBarrier(&___human_7, value);
	}

	inline static int32_t get_offset_of_computer_8() { return static_cast<int32_t>(offsetof(UIData_t3021493825, ___computer_8)); }
	inline VP_1_t1323568 * get_computer_8() const { return ___computer_8; }
	inline VP_1_t1323568 ** get_address_of_computer_8() { return &___computer_8; }
	inline void set_computer_8(VP_1_t1323568 * value)
	{
		___computer_8 = value;
		Il2CppCodeGenWriteBarrier(&___computer_8, value);
	}

	inline static int32_t get_offset_of_empty_9() { return static_cast<int32_t>(offsetof(UIData_t3021493825, ___empty_9)); }
	inline VP_1_t3856456044 * get_empty_9() const { return ___empty_9; }
	inline VP_1_t3856456044 ** get_address_of_empty_9() { return &___empty_9; }
	inline void set_empty_9(VP_1_t3856456044 * value)
	{
		___empty_9 = value;
		Il2CppCodeGenWriteBarrier(&___empty_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
