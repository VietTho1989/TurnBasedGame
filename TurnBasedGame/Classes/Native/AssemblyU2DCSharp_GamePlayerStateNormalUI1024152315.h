#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3032958052.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// RoomCheckChangeAdminChange`1<GamePlayerStateNormal>
struct RoomCheckChangeAdminChange_1_t3210375157;
// GameIsPlayingChange`1<GamePlayerStateNormal>
struct GameIsPlayingChange_1_t1037546209;
// GamePlayer
struct GamePlayer_t2754264707;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GamePlayerStateNormalUI
struct  GamePlayerStateNormalUI_t1024152315  : public UIBehavior_1_t3032958052
{
public:
	// UnityEngine.UI.Button GamePlayerStateNormalUI::btnSurrender
	Button_t2872111280 * ___btnSurrender_6;
	// RoomCheckChangeAdminChange`1<GamePlayerStateNormal> GamePlayerStateNormalUI::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t3210375157 * ___roomCheckAdminChange_7;
	// GameIsPlayingChange`1<GamePlayerStateNormal> GamePlayerStateNormalUI::gameIsPlayingChange
	GameIsPlayingChange_1_t1037546209 * ___gameIsPlayingChange_8;
	// GamePlayer GamePlayerStateNormalUI::gamePlayer
	GamePlayer_t2754264707 * ___gamePlayer_9;

public:
	inline static int32_t get_offset_of_btnSurrender_6() { return static_cast<int32_t>(offsetof(GamePlayerStateNormalUI_t1024152315, ___btnSurrender_6)); }
	inline Button_t2872111280 * get_btnSurrender_6() const { return ___btnSurrender_6; }
	inline Button_t2872111280 ** get_address_of_btnSurrender_6() { return &___btnSurrender_6; }
	inline void set_btnSurrender_6(Button_t2872111280 * value)
	{
		___btnSurrender_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnSurrender_6, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_7() { return static_cast<int32_t>(offsetof(GamePlayerStateNormalUI_t1024152315, ___roomCheckAdminChange_7)); }
	inline RoomCheckChangeAdminChange_1_t3210375157 * get_roomCheckAdminChange_7() const { return ___roomCheckAdminChange_7; }
	inline RoomCheckChangeAdminChange_1_t3210375157 ** get_address_of_roomCheckAdminChange_7() { return &___roomCheckAdminChange_7; }
	inline void set_roomCheckAdminChange_7(RoomCheckChangeAdminChange_1_t3210375157 * value)
	{
		___roomCheckAdminChange_7 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_7, value);
	}

	inline static int32_t get_offset_of_gameIsPlayingChange_8() { return static_cast<int32_t>(offsetof(GamePlayerStateNormalUI_t1024152315, ___gameIsPlayingChange_8)); }
	inline GameIsPlayingChange_1_t1037546209 * get_gameIsPlayingChange_8() const { return ___gameIsPlayingChange_8; }
	inline GameIsPlayingChange_1_t1037546209 ** get_address_of_gameIsPlayingChange_8() { return &___gameIsPlayingChange_8; }
	inline void set_gameIsPlayingChange_8(GameIsPlayingChange_1_t1037546209 * value)
	{
		___gameIsPlayingChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameIsPlayingChange_8, value);
	}

	inline static int32_t get_offset_of_gamePlayer_9() { return static_cast<int32_t>(offsetof(GamePlayerStateNormalUI_t1024152315, ___gamePlayer_9)); }
	inline GamePlayer_t2754264707 * get_gamePlayer_9() const { return ___gamePlayer_9; }
	inline GamePlayer_t2754264707 ** get_address_of_gamePlayer_9() { return &___gamePlayer_9; }
	inline void set_gamePlayer_9(GamePlayer_t2754264707 * value)
	{
		___gamePlayer_9 = value;
		Il2CppCodeGenWriteBarrier(&___gamePlayer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
