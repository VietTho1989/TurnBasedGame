#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1328307493.h"

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

// RoomUserBtnKickUI
struct  RoomUserBtnKickUI_t4167404676  : public UIBehavior_1_t1328307493
{
public:
	// UnityEngine.UI.Button RoomUserBtnKickUI::btnKick
	Button_t2872111280 * ___btnKick_6;
	// UnityEngine.UI.Text RoomUserBtnKickUI::tvKick
	Text_t356221433 * ___tvKick_7;
	// AdvancedCoroutines.Routine RoomUserBtnKickUI::wait
	Routine_t2502590640 * ___wait_8;
	// RoomCheckChangeAdminChange`1<RoomUser> RoomUserBtnKickUI::roomCheckAdminChange
	RoomCheckChangeAdminChange_1_t2103484370 * ___roomCheckAdminChange_9;
	// Server RoomUserBtnKickUI::server
	Server_t2724320767 * ___server_10;

public:
	inline static int32_t get_offset_of_btnKick_6() { return static_cast<int32_t>(offsetof(RoomUserBtnKickUI_t4167404676, ___btnKick_6)); }
	inline Button_t2872111280 * get_btnKick_6() const { return ___btnKick_6; }
	inline Button_t2872111280 ** get_address_of_btnKick_6() { return &___btnKick_6; }
	inline void set_btnKick_6(Button_t2872111280 * value)
	{
		___btnKick_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnKick_6, value);
	}

	inline static int32_t get_offset_of_tvKick_7() { return static_cast<int32_t>(offsetof(RoomUserBtnKickUI_t4167404676, ___tvKick_7)); }
	inline Text_t356221433 * get_tvKick_7() const { return ___tvKick_7; }
	inline Text_t356221433 ** get_address_of_tvKick_7() { return &___tvKick_7; }
	inline void set_tvKick_7(Text_t356221433 * value)
	{
		___tvKick_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvKick_7, value);
	}

	inline static int32_t get_offset_of_wait_8() { return static_cast<int32_t>(offsetof(RoomUserBtnKickUI_t4167404676, ___wait_8)); }
	inline Routine_t2502590640 * get_wait_8() const { return ___wait_8; }
	inline Routine_t2502590640 ** get_address_of_wait_8() { return &___wait_8; }
	inline void set_wait_8(Routine_t2502590640 * value)
	{
		___wait_8 = value;
		Il2CppCodeGenWriteBarrier(&___wait_8, value);
	}

	inline static int32_t get_offset_of_roomCheckAdminChange_9() { return static_cast<int32_t>(offsetof(RoomUserBtnKickUI_t4167404676, ___roomCheckAdminChange_9)); }
	inline RoomCheckChangeAdminChange_1_t2103484370 * get_roomCheckAdminChange_9() const { return ___roomCheckAdminChange_9; }
	inline RoomCheckChangeAdminChange_1_t2103484370 ** get_address_of_roomCheckAdminChange_9() { return &___roomCheckAdminChange_9; }
	inline void set_roomCheckAdminChange_9(RoomCheckChangeAdminChange_1_t2103484370 * value)
	{
		___roomCheckAdminChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___roomCheckAdminChange_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(RoomUserBtnKickUI_t4167404676, ___server_10)); }
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
