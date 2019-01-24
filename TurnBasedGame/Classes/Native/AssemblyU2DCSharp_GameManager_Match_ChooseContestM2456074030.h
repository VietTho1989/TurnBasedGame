#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen2981645970.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// GameManager.Match.ChooseContestManagerStateLobbyUI
struct ChooseContestManagerStateLobbyUI_t3695462533;
// GameManager.Match.ChooseContestManagerStatePlayUI
struct ChooseContestManagerStatePlayUI_t172708299;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseContestManagerHolder
struct  ChooseContestManagerHolder_t2456074030  : public SriaHolderBehavior_1_t2981645970
{
public:
	// UnityEngine.UI.Text GameManager.Match.ChooseContestManagerHolder::tvIndex
	Text_t356221433 * ___tvIndex_16;
	// GameManager.Match.ChooseContestManagerStateLobbyUI GameManager.Match.ChooseContestManagerHolder::lobbyPrefab
	ChooseContestManagerStateLobbyUI_t3695462533 * ___lobbyPrefab_17;
	// GameManager.Match.ChooseContestManagerStatePlayUI GameManager.Match.ChooseContestManagerHolder::playPrefab
	ChooseContestManagerStatePlayUI_t172708299 * ___playPrefab_18;
	// UnityEngine.Transform GameManager.Match.ChooseContestManagerHolder::stateUIContainer
	Transform_t3275118058 * ___stateUIContainer_19;

public:
	inline static int32_t get_offset_of_tvIndex_16() { return static_cast<int32_t>(offsetof(ChooseContestManagerHolder_t2456074030, ___tvIndex_16)); }
	inline Text_t356221433 * get_tvIndex_16() const { return ___tvIndex_16; }
	inline Text_t356221433 ** get_address_of_tvIndex_16() { return &___tvIndex_16; }
	inline void set_tvIndex_16(Text_t356221433 * value)
	{
		___tvIndex_16 = value;
		Il2CppCodeGenWriteBarrier(&___tvIndex_16, value);
	}

	inline static int32_t get_offset_of_lobbyPrefab_17() { return static_cast<int32_t>(offsetof(ChooseContestManagerHolder_t2456074030, ___lobbyPrefab_17)); }
	inline ChooseContestManagerStateLobbyUI_t3695462533 * get_lobbyPrefab_17() const { return ___lobbyPrefab_17; }
	inline ChooseContestManagerStateLobbyUI_t3695462533 ** get_address_of_lobbyPrefab_17() { return &___lobbyPrefab_17; }
	inline void set_lobbyPrefab_17(ChooseContestManagerStateLobbyUI_t3695462533 * value)
	{
		___lobbyPrefab_17 = value;
		Il2CppCodeGenWriteBarrier(&___lobbyPrefab_17, value);
	}

	inline static int32_t get_offset_of_playPrefab_18() { return static_cast<int32_t>(offsetof(ChooseContestManagerHolder_t2456074030, ___playPrefab_18)); }
	inline ChooseContestManagerStatePlayUI_t172708299 * get_playPrefab_18() const { return ___playPrefab_18; }
	inline ChooseContestManagerStatePlayUI_t172708299 ** get_address_of_playPrefab_18() { return &___playPrefab_18; }
	inline void set_playPrefab_18(ChooseContestManagerStatePlayUI_t172708299 * value)
	{
		___playPrefab_18 = value;
		Il2CppCodeGenWriteBarrier(&___playPrefab_18, value);
	}

	inline static int32_t get_offset_of_stateUIContainer_19() { return static_cast<int32_t>(offsetof(ChooseContestManagerHolder_t2456074030, ___stateUIContainer_19)); }
	inline Transform_t3275118058 * get_stateUIContainer_19() const { return ___stateUIContainer_19; }
	inline Transform_t3275118058 ** get_address_of_stateUIContainer_19() { return &___stateUIContainer_19; }
	inline void set_stateUIContainer_19(Transform_t3275118058 * value)
	{
		___stateUIContainer_19 = value;
		Il2CppCodeGenWriteBarrier(&___stateUIContainer_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
