#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2659499426.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Button
struct Button_t2872111280;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// GameManager.Match.AdminEditLobbyPlayerChooseHumanAdapter
struct AdminEditLobbyPlayerChooseHumanAdapter_t493075129;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.AdminEditLobbyPlayerHumanUI
struct  AdminEditLobbyPlayerHumanUI_t721031231  : public UIBehavior_1_t2659499426
{
public:
	// UnityEngine.GameObject GameManager.Match.AdminEditLobbyPlayerHumanUI::requestingContainer
	GameObject_t1756533147 * ___requestingContainer_6;
	// UnityEngine.UI.Button GameManager.Match.AdminEditLobbyPlayerHumanUI::btnCancel
	Button_t2872111280 * ___btnCancel_7;
	// System.Boolean GameManager.Match.AdminEditLobbyPlayerHumanUI::needReset
	bool ___needReset_8;
	// AdvancedCoroutines.Routine GameManager.Match.AdminEditLobbyPlayerHumanUI::wait
	Routine_t2502590640 * ___wait_9;
	// GameManager.Match.AdminEditLobbyPlayerChooseHumanAdapter GameManager.Match.AdminEditLobbyPlayerHumanUI::humanAdapterPrefab
	AdminEditLobbyPlayerChooseHumanAdapter_t493075129 * ___humanAdapterPrefab_10;
	// UnityEngine.Transform GameManager.Match.AdminEditLobbyPlayerHumanUI::humanAdapterContainer
	Transform_t3275118058 * ___humanAdapterContainer_11;
	// Server GameManager.Match.AdminEditLobbyPlayerHumanUI::server
	Server_t2724320767 * ___server_12;

public:
	inline static int32_t get_offset_of_requestingContainer_6() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerHumanUI_t721031231, ___requestingContainer_6)); }
	inline GameObject_t1756533147 * get_requestingContainer_6() const { return ___requestingContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_requestingContainer_6() { return &___requestingContainer_6; }
	inline void set_requestingContainer_6(GameObject_t1756533147 * value)
	{
		___requestingContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___requestingContainer_6, value);
	}

	inline static int32_t get_offset_of_btnCancel_7() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerHumanUI_t721031231, ___btnCancel_7)); }
	inline Button_t2872111280 * get_btnCancel_7() const { return ___btnCancel_7; }
	inline Button_t2872111280 ** get_address_of_btnCancel_7() { return &___btnCancel_7; }
	inline void set_btnCancel_7(Button_t2872111280 * value)
	{
		___btnCancel_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnCancel_7, value);
	}

	inline static int32_t get_offset_of_needReset_8() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerHumanUI_t721031231, ___needReset_8)); }
	inline bool get_needReset_8() const { return ___needReset_8; }
	inline bool* get_address_of_needReset_8() { return &___needReset_8; }
	inline void set_needReset_8(bool value)
	{
		___needReset_8 = value;
	}

	inline static int32_t get_offset_of_wait_9() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerHumanUI_t721031231, ___wait_9)); }
	inline Routine_t2502590640 * get_wait_9() const { return ___wait_9; }
	inline Routine_t2502590640 ** get_address_of_wait_9() { return &___wait_9; }
	inline void set_wait_9(Routine_t2502590640 * value)
	{
		___wait_9 = value;
		Il2CppCodeGenWriteBarrier(&___wait_9, value);
	}

	inline static int32_t get_offset_of_humanAdapterPrefab_10() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerHumanUI_t721031231, ___humanAdapterPrefab_10)); }
	inline AdminEditLobbyPlayerChooseHumanAdapter_t493075129 * get_humanAdapterPrefab_10() const { return ___humanAdapterPrefab_10; }
	inline AdminEditLobbyPlayerChooseHumanAdapter_t493075129 ** get_address_of_humanAdapterPrefab_10() { return &___humanAdapterPrefab_10; }
	inline void set_humanAdapterPrefab_10(AdminEditLobbyPlayerChooseHumanAdapter_t493075129 * value)
	{
		___humanAdapterPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___humanAdapterPrefab_10, value);
	}

	inline static int32_t get_offset_of_humanAdapterContainer_11() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerHumanUI_t721031231, ___humanAdapterContainer_11)); }
	inline Transform_t3275118058 * get_humanAdapterContainer_11() const { return ___humanAdapterContainer_11; }
	inline Transform_t3275118058 ** get_address_of_humanAdapterContainer_11() { return &___humanAdapterContainer_11; }
	inline void set_humanAdapterContainer_11(Transform_t3275118058 * value)
	{
		___humanAdapterContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___humanAdapterContainer_11, value);
	}

	inline static int32_t get_offset_of_server_12() { return static_cast<int32_t>(offsetof(AdminEditLobbyPlayerHumanUI_t721031231, ___server_12)); }
	inline Server_t2724320767 * get_server_12() const { return ___server_12; }
	inline Server_t2724320767 ** get_address_of_server_12() { return &___server_12; }
	inline void set_server_12(Server_t2724320767 * value)
	{
		___server_12 = value;
		Il2CppCodeGenWriteBarrier(&___server_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
