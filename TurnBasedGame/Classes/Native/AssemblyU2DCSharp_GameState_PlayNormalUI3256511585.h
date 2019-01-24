#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4017950765.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// GameCheckPlayerChange`1<GameState.PlayNormal>
struct GameCheckPlayerChange_1_t584256436;
// RoomCheckChangeAdminChange`1<GameState.PlayNormal>
struct RoomCheckChangeAdminChange_1_t743037033;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.PlayNormalUI
struct  PlayNormalUI_t3256511585  : public UIBehavior_1_t4017950765
{
public:
	// UnityEngine.UI.Button GameState.PlayNormalUI::btnPause
	Button_t2872111280 * ___btnPause_6;
	// UnityEngine.UI.Text GameState.PlayNormalUI::tvPause
	Text_t356221433 * ___tvPause_7;
	// AdvancedCoroutines.Routine GameState.PlayNormalUI::wait
	Routine_t2502590640 * ___wait_8;
	// GameCheckPlayerChange`1<GameState.PlayNormal> GameState.PlayNormalUI::gamePlayerCheckChange
	GameCheckPlayerChange_1_t584256436 * ___gamePlayerCheckChange_9;
	// RoomCheckChangeAdminChange`1<GameState.PlayNormal> GameState.PlayNormalUI::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t743037033 * ___roomCheckAdminChange_10;
	// Server GameState.PlayNormalUI::server
	Server_t2724320767 * ___server_11;

public:
	inline static int32_t get_offset_of_btnPause_6() { return static_cast<int32_t>(offsetof(PlayNormalUI_t3256511585, ___btnPause_6)); }
	inline Button_t2872111280 * get_btnPause_6() const { return ___btnPause_6; }
	inline Button_t2872111280 ** get_address_of_btnPause_6() { return &___btnPause_6; }
	inline void set_btnPause_6(Button_t2872111280 * value)
	{
		___btnPause_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnPause_6, value);
	}

	inline static int32_t get_offset_of_tvPause_7() { return static_cast<int32_t>(offsetof(PlayNormalUI_t3256511585, ___tvPause_7)); }
	inline Text_t356221433 * get_tvPause_7() const { return ___tvPause_7; }
	inline Text_t356221433 ** get_address_of_tvPause_7() { return &___tvPause_7; }
	inline void set_tvPause_7(Text_t356221433 * value)
	{
		___tvPause_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvPause_7, value);
	}

	inline static int32_t get_offset_of_wait_8() { return static_cast<int32_t>(offsetof(PlayNormalUI_t3256511585, ___wait_8)); }
	inline Routine_t2502590640 * get_wait_8() const { return ___wait_8; }
	inline Routine_t2502590640 ** get_address_of_wait_8() { return &___wait_8; }
	inline void set_wait_8(Routine_t2502590640 * value)
	{
		___wait_8 = value;
		Il2CppCodeGenWriteBarrier(&___wait_8, value);
	}

	inline static int32_t get_offset_of_gamePlayerCheckChange_9() { return static_cast<int32_t>(offsetof(PlayNormalUI_t3256511585, ___gamePlayerCheckChange_9)); }
	inline GameCheckPlayerChange_1_t584256436 * get_gamePlayerCheckChange_9() const { return ___gamePlayerCheckChange_9; }
	inline GameCheckPlayerChange_1_t584256436 ** get_address_of_gamePlayerCheckChange_9() { return &___gamePlayerCheckChange_9; }
	inline void set_gamePlayerCheckChange_9(GameCheckPlayerChange_1_t584256436 * value)
	{
		___gamePlayerCheckChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___gamePlayerCheckChange_9, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_10() { return static_cast<int32_t>(offsetof(PlayNormalUI_t3256511585, ___roomCheckAdminChange_10)); }
	inline RoomCheckChangeAdminChange_1_t743037033 * get_roomCheckAdminChange_10() const { return ___roomCheckAdminChange_10; }
	inline RoomCheckChangeAdminChange_1_t743037033 ** get_address_of_roomCheckAdminChange_10() { return &___roomCheckAdminChange_10; }
	inline void set_roomCheckAdminChange_10(RoomCheckChangeAdminChange_1_t743037033 * value)
	{
		___roomCheckAdminChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_10, value);
	}

	inline static int32_t get_offset_of_server_11() { return static_cast<int32_t>(offsetof(PlayNormalUI_t3256511585, ___server_11)); }
	inline Server_t2724320767 * get_server_11() const { return ___server_11; }
	inline Server_t2724320767 ** get_address_of_server_11() { return &___server_11; }
	inline void set_server_11(Server_t2724320767 * value)
	{
		___server_11 = value;
		Il2CppCodeGenWriteBarrier(&___server_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
