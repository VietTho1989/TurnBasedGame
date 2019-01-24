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
// VP`1<InformAvatarUI/UIData>
struct VP_1_t2969382667;
// VP`1<GameManager.Match.LobbyPlayerBtnSetReady/UIData>
struct VP_1_t4133248737;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.LobbyPlayerHolder/UIData
struct  UIData_t4207114118  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.LobbyPlayer>> GameManager.Match.LobbyPlayerHolder/UIData::lobbyPlayer
	VP_1_t991913064 * ___lobbyPlayer_5;
	// VP`1<InformAvatarUI/UIData> GameManager.Match.LobbyPlayerHolder/UIData::avatar
	VP_1_t2969382667 * ___avatar_6;
	// VP`1<GameManager.Match.LobbyPlayerBtnSetReady/UIData> GameManager.Match.LobbyPlayerHolder/UIData::btnReady
	VP_1_t4133248737 * ___btnReady_7;

public:
	inline static int32_t get_offset_of_lobbyPlayer_5() { return static_cast<int32_t>(offsetof(UIData_t4207114118, ___lobbyPlayer_5)); }
	inline VP_1_t991913064 * get_lobbyPlayer_5() const { return ___lobbyPlayer_5; }
	inline VP_1_t991913064 ** get_address_of_lobbyPlayer_5() { return &___lobbyPlayer_5; }
	inline void set_lobbyPlayer_5(VP_1_t991913064 * value)
	{
		___lobbyPlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyPlayer_5, value);
	}

	inline static int32_t get_offset_of_avatar_6() { return static_cast<int32_t>(offsetof(UIData_t4207114118, ___avatar_6)); }
	inline VP_1_t2969382667 * get_avatar_6() const { return ___avatar_6; }
	inline VP_1_t2969382667 ** get_address_of_avatar_6() { return &___avatar_6; }
	inline void set_avatar_6(VP_1_t2969382667 * value)
	{
		___avatar_6 = value;
		Il2CppCodeGenWriteBarrier(&___avatar_6, value);
	}

	inline static int32_t get_offset_of_btnReady_7() { return static_cast<int32_t>(offsetof(UIData_t4207114118, ___btnReady_7)); }
	inline VP_1_t4133248737 * get_btnReady_7() const { return ___btnReady_7; }
	inline VP_1_t4133248737 ** get_address_of_btnReady_7() { return &___btnReady_7; }
	inline void set_btnReady_7(VP_1_t4133248737 * value)
	{
		___btnReady_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnReady_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
