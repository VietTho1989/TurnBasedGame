#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2476863711.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Button
struct Button_t2872111280;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanAdapter
struct AdminRequestSwapPlayerChooseHumanAdapter_t3813502831;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;
// GameManager.Match.ContestManagerStatePlay
struct ContestManagerStatePlay_t4088911568;
// GameManager.Match.ContestManagerStatePlayTeamCheckChange`1<GameManager.Match.ContestManagerStatePlay>
struct ContestManagerStatePlayTeamCheckChange_1_t271771593;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI
struct  AdminRequestSwapPlayerHumanUI_t4084821379  : public UIBehavior_1_t2476863711
{
public:
	// UnityEngine.GameObject GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI::requestingContainer
	GameObject_t1756533147 * ___requestingContainer_6;
	// UnityEngine.UI.Button GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI::btnCancel
	Button_t2872111280 * ___btnCancel_7;
	// System.Boolean GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI::needReset
	bool ___needReset_8;
	// AdvancedCoroutines.Routine GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI::wait
	Routine_t2502590640 * ___wait_9;
	// GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanAdapter GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI::humanAdapterPrefab
	AdminRequestSwapPlayerChooseHumanAdapter_t3813502831 * ___humanAdapterPrefab_10;
	// UnityEngine.Transform GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI::humanAdapterContainer
	Transform_t3275118058 * ___humanAdapterContainer_11;
	// Server GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI::server
	Server_t2724320767 * ___server_12;
	// GameManager.Match.ContestManagerStatePlay GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI::contestManagerStatePlay
	ContestManagerStatePlay_t4088911568 * ___contestManagerStatePlay_13;
	// GameManager.Match.ContestManagerStatePlayTeamCheckChange`1<GameManager.Match.ContestManagerStatePlay> GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI::contestManagerStatePlayTeamCheckChange
	ContestManagerStatePlayTeamCheckChange_1_t271771593 * ___contestManagerStatePlayTeamCheckChange_14;

public:
	inline static int32_t get_offset_of_requestingContainer_6() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerHumanUI_t4084821379, ___requestingContainer_6)); }
	inline GameObject_t1756533147 * get_requestingContainer_6() const { return ___requestingContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_requestingContainer_6() { return &___requestingContainer_6; }
	inline void set_requestingContainer_6(GameObject_t1756533147 * value)
	{
		___requestingContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___requestingContainer_6, value);
	}

	inline static int32_t get_offset_of_btnCancel_7() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerHumanUI_t4084821379, ___btnCancel_7)); }
	inline Button_t2872111280 * get_btnCancel_7() const { return ___btnCancel_7; }
	inline Button_t2872111280 ** get_address_of_btnCancel_7() { return &___btnCancel_7; }
	inline void set_btnCancel_7(Button_t2872111280 * value)
	{
		___btnCancel_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnCancel_7, value);
	}

	inline static int32_t get_offset_of_needReset_8() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerHumanUI_t4084821379, ___needReset_8)); }
	inline bool get_needReset_8() const { return ___needReset_8; }
	inline bool* get_address_of_needReset_8() { return &___needReset_8; }
	inline void set_needReset_8(bool value)
	{
		___needReset_8 = value;
	}

	inline static int32_t get_offset_of_wait_9() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerHumanUI_t4084821379, ___wait_9)); }
	inline Routine_t2502590640 * get_wait_9() const { return ___wait_9; }
	inline Routine_t2502590640 ** get_address_of_wait_9() { return &___wait_9; }
	inline void set_wait_9(Routine_t2502590640 * value)
	{
		___wait_9 = value;
		Il2CppCodeGenWriteBarrier(&___wait_9, value);
	}

	inline static int32_t get_offset_of_humanAdapterPrefab_10() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerHumanUI_t4084821379, ___humanAdapterPrefab_10)); }
	inline AdminRequestSwapPlayerChooseHumanAdapter_t3813502831 * get_humanAdapterPrefab_10() const { return ___humanAdapterPrefab_10; }
	inline AdminRequestSwapPlayerChooseHumanAdapter_t3813502831 ** get_address_of_humanAdapterPrefab_10() { return &___humanAdapterPrefab_10; }
	inline void set_humanAdapterPrefab_10(AdminRequestSwapPlayerChooseHumanAdapter_t3813502831 * value)
	{
		___humanAdapterPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___humanAdapterPrefab_10, value);
	}

	inline static int32_t get_offset_of_humanAdapterContainer_11() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerHumanUI_t4084821379, ___humanAdapterContainer_11)); }
	inline Transform_t3275118058 * get_humanAdapterContainer_11() const { return ___humanAdapterContainer_11; }
	inline Transform_t3275118058 ** get_address_of_humanAdapterContainer_11() { return &___humanAdapterContainer_11; }
	inline void set_humanAdapterContainer_11(Transform_t3275118058 * value)
	{
		___humanAdapterContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___humanAdapterContainer_11, value);
	}

	inline static int32_t get_offset_of_server_12() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerHumanUI_t4084821379, ___server_12)); }
	inline Server_t2724320767 * get_server_12() const { return ___server_12; }
	inline Server_t2724320767 ** get_address_of_server_12() { return &___server_12; }
	inline void set_server_12(Server_t2724320767 * value)
	{
		___server_12 = value;
		Il2CppCodeGenWriteBarrier(&___server_12, value);
	}

	inline static int32_t get_offset_of_contestManagerStatePlay_13() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerHumanUI_t4084821379, ___contestManagerStatePlay_13)); }
	inline ContestManagerStatePlay_t4088911568 * get_contestManagerStatePlay_13() const { return ___contestManagerStatePlay_13; }
	inline ContestManagerStatePlay_t4088911568 ** get_address_of_contestManagerStatePlay_13() { return &___contestManagerStatePlay_13; }
	inline void set_contestManagerStatePlay_13(ContestManagerStatePlay_t4088911568 * value)
	{
		___contestManagerStatePlay_13 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlay_13, value);
	}

	inline static int32_t get_offset_of_contestManagerStatePlayTeamCheckChange_14() { return static_cast<int32_t>(offsetof(AdminRequestSwapPlayerHumanUI_t4084821379, ___contestManagerStatePlayTeamCheckChange_14)); }
	inline ContestManagerStatePlayTeamCheckChange_1_t271771593 * get_contestManagerStatePlayTeamCheckChange_14() const { return ___contestManagerStatePlayTeamCheckChange_14; }
	inline ContestManagerStatePlayTeamCheckChange_1_t271771593 ** get_address_of_contestManagerStatePlayTeamCheckChange_14() { return &___contestManagerStatePlayTeamCheckChange_14; }
	inline void set_contestManagerStatePlayTeamCheckChange_14(ContestManagerStatePlayTeamCheckChange_1_t271771593 * value)
	{
		___contestManagerStatePlayTeamCheckChange_14 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlayTeamCheckChange_14, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
