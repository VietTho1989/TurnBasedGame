#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen175804733.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Server
struct Server_t2724320767;
// Room
struct Room_t1042398373;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BtnLoadHistoryUI
struct  BtnLoadHistoryUI_t3133618714  : public UIBehavior_1_t175804733
{
public:
	// UnityEngine.GameObject BtnLoadHistoryUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// UnityEngine.UI.Button BtnLoadHistoryUI::btnLoad
	Button_t2872111280 * ___btnLoad_7;
	// UnityEngine.UI.Text BtnLoadHistoryUI::tvLoad
	Text_t356221433 * ___tvLoad_8;
	// System.Boolean BtnLoadHistoryUI::needReset
	bool ___needReset_9;
	// AdvancedCoroutines.Routine BtnLoadHistoryUI::wait
	Routine_t2502590640 * ___wait_10;
	// Server BtnLoadHistoryUI::server
	Server_t2724320767 * ___server_11;
	// Room BtnLoadHistoryUI::room
	Room_t1042398373 * ___room_12;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(BtnLoadHistoryUI_t3133618714, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_btnLoad_7() { return static_cast<int32_t>(offsetof(BtnLoadHistoryUI_t3133618714, ___btnLoad_7)); }
	inline Button_t2872111280 * get_btnLoad_7() const { return ___btnLoad_7; }
	inline Button_t2872111280 ** get_address_of_btnLoad_7() { return &___btnLoad_7; }
	inline void set_btnLoad_7(Button_t2872111280 * value)
	{
		___btnLoad_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnLoad_7, value);
	}

	inline static int32_t get_offset_of_tvLoad_8() { return static_cast<int32_t>(offsetof(BtnLoadHistoryUI_t3133618714, ___tvLoad_8)); }
	inline Text_t356221433 * get_tvLoad_8() const { return ___tvLoad_8; }
	inline Text_t356221433 ** get_address_of_tvLoad_8() { return &___tvLoad_8; }
	inline void set_tvLoad_8(Text_t356221433 * value)
	{
		___tvLoad_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvLoad_8, value);
	}

	inline static int32_t get_offset_of_needReset_9() { return static_cast<int32_t>(offsetof(BtnLoadHistoryUI_t3133618714, ___needReset_9)); }
	inline bool get_needReset_9() const { return ___needReset_9; }
	inline bool* get_address_of_needReset_9() { return &___needReset_9; }
	inline void set_needReset_9(bool value)
	{
		___needReset_9 = value;
	}

	inline static int32_t get_offset_of_wait_10() { return static_cast<int32_t>(offsetof(BtnLoadHistoryUI_t3133618714, ___wait_10)); }
	inline Routine_t2502590640 * get_wait_10() const { return ___wait_10; }
	inline Routine_t2502590640 ** get_address_of_wait_10() { return &___wait_10; }
	inline void set_wait_10(Routine_t2502590640 * value)
	{
		___wait_10 = value;
		Il2CppCodeGenWriteBarrier(&___wait_10, value);
	}

	inline static int32_t get_offset_of_server_11() { return static_cast<int32_t>(offsetof(BtnLoadHistoryUI_t3133618714, ___server_11)); }
	inline Server_t2724320767 * get_server_11() const { return ___server_11; }
	inline Server_t2724320767 ** get_address_of_server_11() { return &___server_11; }
	inline void set_server_11(Server_t2724320767 * value)
	{
		___server_11 = value;
		Il2CppCodeGenWriteBarrier(&___server_11, value);
	}

	inline static int32_t get_offset_of_room_12() { return static_cast<int32_t>(offsetof(BtnLoadHistoryUI_t3133618714, ___room_12)); }
	inline Room_t1042398373 * get_room_12() const { return ___room_12; }
	inline Room_t1042398373 ** get_address_of_room_12() { return &___room_12; }
	inline void set_room_12(Room_t1042398373 * value)
	{
		___room_12 = value;
		Il2CppCodeGenWriteBarrier(&___room_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
