#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1502987610.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.UI.Button
struct Button_t2872111280;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// GameCheckPlayerChange`1<GameState.PlayPause>
struct GameCheckPlayerChange_1_t1340794285;
// RoomCheckChangeAdminChange`1<GameState.PlayPause>
struct RoomCheckChangeAdminChange_1_t1499574882;
// Server
struct Server_t2724320767;
// AccountAvatarUI
struct AccountAvatarUI_t3584502088;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.PlayPauseUI
struct  PlayPauseUI_t4065594944  : public UIBehavior_1_t1502987610
{
public:
	// UnityEngine.UI.Text GameState.PlayPauseUI::tvName
	Text_t356221433 * ___tvName_6;
	// UnityEngine.UI.Button GameState.PlayPauseUI::btnUnPause
	Button_t2872111280 * ___btnUnPause_7;
	// UnityEngine.UI.Text GameState.PlayPauseUI::tvUnPause
	Text_t356221433 * ___tvUnPause_8;
	// AdvancedCoroutines.Routine GameState.PlayPauseUI::wait
	Routine_t2502590640 * ___wait_9;
	// GameCheckPlayerChange`1<GameState.PlayPause> GameState.PlayPauseUI::gamePlayerCheckChange
	GameCheckPlayerChange_1_t1340794285 * ___gamePlayerCheckChange_10;
	// RoomCheckChangeAdminChange`1<GameState.PlayPause> GameState.PlayPauseUI::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t1499574882 * ___roomCheckAdminChange_11;
	// Server GameState.PlayPauseUI::server
	Server_t2724320767 * ___server_12;
	// AccountAvatarUI GameState.PlayPauseUI::accountAvatarPrefab
	AccountAvatarUI_t3584502088 * ___accountAvatarPrefab_13;
	// UnityEngine.Transform GameState.PlayPauseUI::accountAvatarContainer
	Transform_t3275118058 * ___accountAvatarContainer_14;

public:
	inline static int32_t get_offset_of_tvName_6() { return static_cast<int32_t>(offsetof(PlayPauseUI_t4065594944, ___tvName_6)); }
	inline Text_t356221433 * get_tvName_6() const { return ___tvName_6; }
	inline Text_t356221433 ** get_address_of_tvName_6() { return &___tvName_6; }
	inline void set_tvName_6(Text_t356221433 * value)
	{
		___tvName_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvName_6, value);
	}

	inline static int32_t get_offset_of_btnUnPause_7() { return static_cast<int32_t>(offsetof(PlayPauseUI_t4065594944, ___btnUnPause_7)); }
	inline Button_t2872111280 * get_btnUnPause_7() const { return ___btnUnPause_7; }
	inline Button_t2872111280 ** get_address_of_btnUnPause_7() { return &___btnUnPause_7; }
	inline void set_btnUnPause_7(Button_t2872111280 * value)
	{
		___btnUnPause_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnUnPause_7, value);
	}

	inline static int32_t get_offset_of_tvUnPause_8() { return static_cast<int32_t>(offsetof(PlayPauseUI_t4065594944, ___tvUnPause_8)); }
	inline Text_t356221433 * get_tvUnPause_8() const { return ___tvUnPause_8; }
	inline Text_t356221433 ** get_address_of_tvUnPause_8() { return &___tvUnPause_8; }
	inline void set_tvUnPause_8(Text_t356221433 * value)
	{
		___tvUnPause_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvUnPause_8, value);
	}

	inline static int32_t get_offset_of_wait_9() { return static_cast<int32_t>(offsetof(PlayPauseUI_t4065594944, ___wait_9)); }
	inline Routine_t2502590640 * get_wait_9() const { return ___wait_9; }
	inline Routine_t2502590640 ** get_address_of_wait_9() { return &___wait_9; }
	inline void set_wait_9(Routine_t2502590640 * value)
	{
		___wait_9 = value;
		Il2CppCodeGenWriteBarrier(&___wait_9, value);
	}

	inline static int32_t get_offset_of_gamePlayerCheckChange_10() { return static_cast<int32_t>(offsetof(PlayPauseUI_t4065594944, ___gamePlayerCheckChange_10)); }
	inline GameCheckPlayerChange_1_t1340794285 * get_gamePlayerCheckChange_10() const { return ___gamePlayerCheckChange_10; }
	inline GameCheckPlayerChange_1_t1340794285 ** get_address_of_gamePlayerCheckChange_10() { return &___gamePlayerCheckChange_10; }
	inline void set_gamePlayerCheckChange_10(GameCheckPlayerChange_1_t1340794285 * value)
	{
		___gamePlayerCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___gamePlayerCheckChange_10, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_11() { return static_cast<int32_t>(offsetof(PlayPauseUI_t4065594944, ___roomCheckAdminChange_11)); }
	inline RoomCheckChangeAdminChange_1_t1499574882 * get_roomCheckAdminChange_11() const { return ___roomCheckAdminChange_11; }
	inline RoomCheckChangeAdminChange_1_t1499574882 ** get_address_of_roomCheckAdminChange_11() { return &___roomCheckAdminChange_11; }
	inline void set_roomCheckAdminChange_11(RoomCheckChangeAdminChange_1_t1499574882 * value)
	{
		___roomCheckAdminChange_11 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_11, value);
	}

	inline static int32_t get_offset_of_server_12() { return static_cast<int32_t>(offsetof(PlayPauseUI_t4065594944, ___server_12)); }
	inline Server_t2724320767 * get_server_12() const { return ___server_12; }
	inline Server_t2724320767 ** get_address_of_server_12() { return &___server_12; }
	inline void set_server_12(Server_t2724320767 * value)
	{
		___server_12 = value;
		Il2CppCodeGenWriteBarrier(&___server_12, value);
	}

	inline static int32_t get_offset_of_accountAvatarPrefab_13() { return static_cast<int32_t>(offsetof(PlayPauseUI_t4065594944, ___accountAvatarPrefab_13)); }
	inline AccountAvatarUI_t3584502088 * get_accountAvatarPrefab_13() const { return ___accountAvatarPrefab_13; }
	inline AccountAvatarUI_t3584502088 ** get_address_of_accountAvatarPrefab_13() { return &___accountAvatarPrefab_13; }
	inline void set_accountAvatarPrefab_13(AccountAvatarUI_t3584502088 * value)
	{
		___accountAvatarPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___accountAvatarPrefab_13, value);
	}

	inline static int32_t get_offset_of_accountAvatarContainer_14() { return static_cast<int32_t>(offsetof(PlayPauseUI_t4065594944, ___accountAvatarContainer_14)); }
	inline Transform_t3275118058 * get_accountAvatarContainer_14() const { return ___accountAvatarContainer_14; }
	inline Transform_t3275118058 ** get_address_of_accountAvatarContainer_14() { return &___accountAvatarContainer_14; }
	inline void set_accountAvatarContainer_14(Transform_t3275118058 * value)
	{
		___accountAvatarContainer_14 = value;
		Il2CppCodeGenWriteBarrier(&___accountAvatarContainer_14, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
