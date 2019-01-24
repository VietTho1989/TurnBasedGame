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
// VP`1<GameManager.Match.NormalEditLobbyPlayerBtnSetUI/UIData>
struct VP_1_t2177737461;
// VP`1<GameManager.Match.NormalEditLobbyPlayerBtnEmptyUI/UIData>
struct VP_1_t3057686744;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.NormalEditLobbyPlayerUI/UIData
struct  UIData_t1119785865  : public Sub_t384552493
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.LobbyPlayer>> GameManager.Match.NormalEditLobbyPlayerUI/UIData::lobbyPlayer
	VP_1_t991913064 * ___lobbyPlayer_5;
	// VP`1<GameManager.Match.NormalEditLobbyPlayerBtnSetUI/UIData> GameManager.Match.NormalEditLobbyPlayerUI/UIData::btnSet
	VP_1_t2177737461 * ___btnSet_6;
	// VP`1<GameManager.Match.NormalEditLobbyPlayerBtnEmptyUI/UIData> GameManager.Match.NormalEditLobbyPlayerUI/UIData::btnEmpty
	VP_1_t3057686744 * ___btnEmpty_7;

public:
	inline static int32_t get_offset_of_lobbyPlayer_5() { return static_cast<int32_t>(offsetof(UIData_t1119785865, ___lobbyPlayer_5)); }
	inline VP_1_t991913064 * get_lobbyPlayer_5() const { return ___lobbyPlayer_5; }
	inline VP_1_t991913064 ** get_address_of_lobbyPlayer_5() { return &___lobbyPlayer_5; }
	inline void set_lobbyPlayer_5(VP_1_t991913064 * value)
	{
		___lobbyPlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyPlayer_5, value);
	}

	inline static int32_t get_offset_of_btnSet_6() { return static_cast<int32_t>(offsetof(UIData_t1119785865, ___btnSet_6)); }
	inline VP_1_t2177737461 * get_btnSet_6() const { return ___btnSet_6; }
	inline VP_1_t2177737461 ** get_address_of_btnSet_6() { return &___btnSet_6; }
	inline void set_btnSet_6(VP_1_t2177737461 * value)
	{
		___btnSet_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnSet_6, value);
	}

	inline static int32_t get_offset_of_btnEmpty_7() { return static_cast<int32_t>(offsetof(UIData_t1119785865, ___btnEmpty_7)); }
	inline VP_1_t3057686744 * get_btnEmpty_7() const { return ___btnEmpty_7; }
	inline VP_1_t3057686744 ** get_address_of_btnEmpty_7() { return &___btnEmpty_7; }
	inline void set_btnEmpty_7(VP_1_t3057686744 * value)
	{
		___btnEmpty_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnEmpty_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
