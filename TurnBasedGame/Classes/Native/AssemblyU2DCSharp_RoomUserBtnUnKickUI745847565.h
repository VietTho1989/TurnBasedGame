#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2711782814.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// RoomCheckChangeAdminChange`1<RoomUser>
struct RoomCheckChangeAdminChange_1_t2103484370;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomUserBtnUnKickUI
struct  RoomUserBtnUnKickUI_t745847565  : public UIBehavior_1_t2711782814
{
public:
	// UnityEngine.UI.Button RoomUserBtnUnKickUI::btnUnKick
	Button_t2872111280 * ___btnUnKick_6;
	// UnityEngine.UI.Text RoomUserBtnUnKickUI::tvUnKick
	Text_t356221433 * ___tvUnKick_7;
	// AdvancedCoroutines.Routine RoomUserBtnUnKickUI::wait
	Routine_t2502590640 * ___wait_8;
	// RoomCheckChangeAdminChange`1<RoomUser> RoomUserBtnUnKickUI::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t2103484370 * ___roomCheckAdminChange_9;
	// Server RoomUserBtnUnKickUI::server
	Server_t2724320767 * ___server_10;

public:
	inline static int32_t get_offset_of_btnUnKick_6() { return static_cast<int32_t>(offsetof(RoomUserBtnUnKickUI_t745847565, ___btnUnKick_6)); }
	inline Button_t2872111280 * get_btnUnKick_6() const { return ___btnUnKick_6; }
	inline Button_t2872111280 ** get_address_of_btnUnKick_6() { return &___btnUnKick_6; }
	inline void set_btnUnKick_6(Button_t2872111280 * value)
	{
		___btnUnKick_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnUnKick_6, value);
	}

	inline static int32_t get_offset_of_tvUnKick_7() { return static_cast<int32_t>(offsetof(RoomUserBtnUnKickUI_t745847565, ___tvUnKick_7)); }
	inline Text_t356221433 * get_tvUnKick_7() const { return ___tvUnKick_7; }
	inline Text_t356221433 ** get_address_of_tvUnKick_7() { return &___tvUnKick_7; }
	inline void set_tvUnKick_7(Text_t356221433 * value)
	{
		___tvUnKick_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvUnKick_7, value);
	}

	inline static int32_t get_offset_of_wait_8() { return static_cast<int32_t>(offsetof(RoomUserBtnUnKickUI_t745847565, ___wait_8)); }
	inline Routine_t2502590640 * get_wait_8() const { return ___wait_8; }
	inline Routine_t2502590640 ** get_address_of_wait_8() { return &___wait_8; }
	inline void set_wait_8(Routine_t2502590640 * value)
	{
		___wait_8 = value;
		Il2CppCodeGenWriteBarrier(&___wait_8, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_9() { return static_cast<int32_t>(offsetof(RoomUserBtnUnKickUI_t745847565, ___roomCheckAdminChange_9)); }
	inline RoomCheckChangeAdminChange_1_t2103484370 * get_roomCheckAdminChange_9() const { return ___roomCheckAdminChange_9; }
	inline RoomCheckChangeAdminChange_1_t2103484370 ** get_address_of_roomCheckAdminChange_9() { return &___roomCheckAdminChange_9; }
	inline void set_roomCheckAdminChange_9(RoomCheckChangeAdminChange_1_t2103484370 * value)
	{
		___roomCheckAdminChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(RoomUserBtnUnKickUI_t745847565, ___server_10)); }
	inline Server_t2724320767 * get_server_10() const { return ___server_10; }
	inline Server_t2724320767 ** get_address_of_server_10() { return &___server_10; }
	inline void set_server_10(Server_t2724320767 * value)
	{
		___server_10 = value;
		Il2CppCodeGenWriteBarrier(&___server_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
