#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1571197701.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// GameManager.Match.ContestManagerStateLobbyInformUI
struct ContestManagerStateLobbyInformUI_t1172545157;
// GameManager.Match.ContestManagerStatePlayInformUI
struct ContestManagerStatePlayInformUI_t3936151243;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManagerInformUI
struct  ContestManagerInformUI_t1492993402  : public UIBehavior_1_t1571197701
{
public:
	// UnityEngine.UI.Text GameManager.Match.ContestManagerInformUI::tvIndex
	Text_t356221433 * ___tvIndex_6;
	// GameManager.Match.ContestManagerStateLobbyInformUI GameManager.Match.ContestManagerInformUI::lobbyPrefab
	ContestManagerStateLobbyInformUI_t1172545157 * ___lobbyPrefab_7;
	// GameManager.Match.ContestManagerStatePlayInformUI GameManager.Match.ContestManagerInformUI::playPrefab
	ContestManagerStatePlayInformUI_t3936151243 * ___playPrefab_8;
	// UnityEngine.Transform GameManager.Match.ContestManagerInformUI::stateUIContainer
	Transform_t3275118058 * ___stateUIContainer_9;

public:
	inline static int32_t get_offset_of_tvIndex_6() { return static_cast<int32_t>(offsetof(ContestManagerInformUI_t1492993402, ___tvIndex_6)); }
	inline Text_t356221433 * get_tvIndex_6() const { return ___tvIndex_6; }
	inline Text_t356221433 ** get_address_of_tvIndex_6() { return &___tvIndex_6; }
	inline void set_tvIndex_6(Text_t356221433 * value)
	{
		___tvIndex_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvIndex_6, value);
	}

	inline static int32_t get_offset_of_lobbyPrefab_7() { return static_cast<int32_t>(offsetof(ContestManagerInformUI_t1492993402, ___lobbyPrefab_7)); }
	inline ContestManagerStateLobbyInformUI_t1172545157 * get_lobbyPrefab_7() const { return ___lobbyPrefab_7; }
	inline ContestManagerStateLobbyInformUI_t1172545157 ** get_address_of_lobbyPrefab_7() { return &___lobbyPrefab_7; }
	inline void set_lobbyPrefab_7(ContestManagerStateLobbyInformUI_t1172545157 * value)
	{
		___lobbyPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyPrefab_7, value);
	}

	inline static int32_t get_offset_of_playPrefab_8() { return static_cast<int32_t>(offsetof(ContestManagerInformUI_t1492993402, ___playPrefab_8)); }
	inline ContestManagerStatePlayInformUI_t3936151243 * get_playPrefab_8() const { return ___playPrefab_8; }
	inline ContestManagerStatePlayInformUI_t3936151243 ** get_address_of_playPrefab_8() { return &___playPrefab_8; }
	inline void set_playPrefab_8(ContestManagerStatePlayInformUI_t3936151243 * value)
	{
		___playPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___playPrefab_8, value);
	}

	inline static int32_t get_offset_of_stateUIContainer_9() { return static_cast<int32_t>(offsetof(ContestManagerInformUI_t1492993402, ___stateUIContainer_9)); }
	inline Transform_t3275118058 * get_stateUIContainer_9() const { return ___stateUIContainer_9; }
	inline Transform_t3275118058 ** get_address_of_stateUIContainer_9() { return &___stateUIContainer_9; }
	inline void set_stateUIContainer_9(Transform_t3275118058 * value)
	{
		___stateUIContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___stateUIContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
