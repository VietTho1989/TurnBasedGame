#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2762253890.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.AdminEditLobbyPlayerEmptyUI
struct  AdminEditLobbyPlayerEmptyUI_t3910218333  : public UIBehavior_1_t2762253890
{
public:
	// UnityEngine.UI.Button GameManager.Match.AdminEditLobbyPlayerEmptyUI::btnRequest
	Button_t2872111280 * ___btnRequest_6;
	// UnityEngine.UI.Text GameManager.Match.AdminEditLobbyPlayerEmptyUI::tvRequest
	Text_t356221433 * ___tvRequest_7;
	// System.Boolean GameManager.Match.AdminEditLobbyPlayerEmptyUI::needReset
	bool ___needReset_8;
	// AdvancedCoroutines.Routine GameManager.Match.AdminEditLobbyPlayerEmptyUI::wait
	Routine_t2502590640 * ___wait_9;
	// Server GameManager.Match.AdminEditLobbyPlayerEmptyUI::server
	Server_t2724320767 * ___server_10;

public:
	inline static int32_t get_offset_of_btnRequest_6() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerEmptyUI_t3910218333, ___btnRequest_6)); }
	inline Button_t2872111280 * get_btnRequest_6() const { return ___btnRequest_6; }
	inline Button_t2872111280 ** get_address_of_btnRequest_6() { return &___btnRequest_6; }
	inline void set_btnRequest_6(Button_t2872111280 * value)
	{
		___btnRequest_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnRequest_6, value);
	}

	inline static int32_t get_offset_of_tvRequest_7() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerEmptyUI_t3910218333, ___tvRequest_7)); }
	inline Text_t356221433 * get_tvRequest_7() const { return ___tvRequest_7; }
	inline Text_t356221433 ** get_address_of_tvRequest_7() { return &___tvRequest_7; }
	inline void set_tvRequest_7(Text_t356221433 * value)
	{
		___tvRequest_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvRequest_7, value);
	}

	inline static int32_t get_offset_of_needReset_8() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerEmptyUI_t3910218333, ___needReset_8)); }
	inline bool get_needReset_8() const { return ___needReset_8; }
	inline bool* get_address_of_needReset_8() { return &___needReset_8; }
	inline void set_needReset_8(bool value)
	{
		___needReset_8 = value;
	}

	inline static int32_t get_offset_of_wait_9() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerEmptyUI_t3910218333, ___wait_9)); }
	inline Routine_t2502590640 * get_wait_9() const { return ___wait_9; }
	inline Routine_t2502590640 ** get_address_of_wait_9() { return &___wait_9; }
	inline void set_wait_9(Routine_t2502590640 * value)
	{
		___wait_9 = value;
		Il2CppCodeGenWriteBarrier(&___wait_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerEmptyUI_t3910218333, ___server_10)); }
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
