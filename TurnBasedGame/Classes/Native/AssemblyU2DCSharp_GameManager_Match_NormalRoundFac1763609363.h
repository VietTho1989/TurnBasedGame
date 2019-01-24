#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen663949374.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// GameFactoryUI
struct GameFactoryUI_t1239554238;
// RequestChangeBoolUI
struct RequestChangeBoolUI_t2618169711;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
// GameManager.Match.CalculateScoreSumUI
struct CalculateScoreSumUI_t3262781401;
// GameManager.Match.CalculateScoreWinLoseDrawUI
struct CalculateScoreWinLoseDrawUI_t4022670967;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.NormalRoundFactoryUI
struct  NormalRoundFactoryUI_t1763609363  : public UIBehavior_1_t663949374
{
public:
	// System.Boolean GameManager.Match.NormalRoundFactoryUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject GameManager.Match.NormalRoundFactoryUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// GameFactoryUI GameManager.Match.NormalRoundFactoryUI::gameFactoryPrefab
	GameFactoryUI_t1239554238 * ___gameFactoryPrefab_8;
	// RequestChangeBoolUI GameManager.Match.NormalRoundFactoryUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_9;
	// RequestChangeEnumUI GameManager.Match.NormalRoundFactoryUI::requestEnumPrefab
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefab_10;
	// GameManager.Match.CalculateScoreSumUI GameManager.Match.NormalRoundFactoryUI::calculateScoreSumPrefab
	CalculateScoreSumUI_t3262781401 * ___calculateScoreSumPrefab_11;
	// GameManager.Match.CalculateScoreWinLoseDrawUI GameManager.Match.NormalRoundFactoryUI::calculateScoreWinLoseDrawPrefab
	CalculateScoreWinLoseDrawUI_t4022670967 * ___calculateScoreWinLoseDrawPrefab_12;
	// UnityEngine.Transform GameManager.Match.NormalRoundFactoryUI::gameFactoryContainer
	Transform_t3275118058 * ___gameFactoryContainer_13;
	// UnityEngine.Transform GameManager.Match.NormalRoundFactoryUI::isChangeSideBetweenRoundContainer
	Transform_t3275118058 * ___isChangeSideBetweenRoundContainer_14;
	// UnityEngine.Transform GameManager.Match.NormalRoundFactoryUI::isSwitchPlayerContainer
	Transform_t3275118058 * ___isSwitchPlayerContainer_15;
	// UnityEngine.Transform GameManager.Match.NormalRoundFactoryUI::isDifferentInTeamContainer
	Transform_t3275118058 * ___isDifferentInTeamContainer_16;
	// UnityEngine.Transform GameManager.Match.NormalRoundFactoryUI::calculateScoreTypeContainer
	Transform_t3275118058 * ___calculateScoreTypeContainer_17;
	// UnityEngine.Transform GameManager.Match.NormalRoundFactoryUI::calculateScoreUIContainer
	Transform_t3275118058 * ___calculateScoreUIContainer_18;
	// Server GameManager.Match.NormalRoundFactoryUI::server
	Server_t2724320767 * ___server_19;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_gameFactoryPrefab_8() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___gameFactoryPrefab_8)); }
	inline GameFactoryUI_t1239554238 * get_gameFactoryPrefab_8() const { return ___gameFactoryPrefab_8; }
	inline GameFactoryUI_t1239554238 ** get_address_of_gameFactoryPrefab_8() { return &___gameFactoryPrefab_8; }
	inline void set_gameFactoryPrefab_8(GameFactoryUI_t1239554238 * value)
	{
		___gameFactoryPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameFactoryPrefab_8, value);
	}

	inline static int32_t get_offset_of_requestBoolPrefab_9() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___requestBoolPrefab_9)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_9() const { return ___requestBoolPrefab_9; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_9() { return &___requestBoolPrefab_9; }
	inline void set_requestBoolPrefab_9(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_9, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefab_10() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___requestEnumPrefab_10)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefab_10() const { return ___requestEnumPrefab_10; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefab_10() { return &___requestEnumPrefab_10; }
	inline void set_requestEnumPrefab_10(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefab_10, value);
	}

	inline static int32_t get_offset_of_calculateScoreSumPrefab_11() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___calculateScoreSumPrefab_11)); }
	inline CalculateScoreSumUI_t3262781401 * get_calculateScoreSumPrefab_11() const { return ___calculateScoreSumPrefab_11; }
	inline CalculateScoreSumUI_t3262781401 ** get_address_of_calculateScoreSumPrefab_11() { return &___calculateScoreSumPrefab_11; }
	inline void set_calculateScoreSumPrefab_11(CalculateScoreSumUI_t3262781401 * value)
	{
		___calculateScoreSumPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___calculateScoreSumPrefab_11, value);
	}

	inline static int32_t get_offset_of_calculateScoreWinLoseDrawPrefab_12() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___calculateScoreWinLoseDrawPrefab_12)); }
	inline CalculateScoreWinLoseDrawUI_t4022670967 * get_calculateScoreWinLoseDrawPrefab_12() const { return ___calculateScoreWinLoseDrawPrefab_12; }
	inline CalculateScoreWinLoseDrawUI_t4022670967 ** get_address_of_calculateScoreWinLoseDrawPrefab_12() { return &___calculateScoreWinLoseDrawPrefab_12; }
	inline void set_calculateScoreWinLoseDrawPrefab_12(CalculateScoreWinLoseDrawUI_t4022670967 * value)
	{
		___calculateScoreWinLoseDrawPrefab_12 = value;
		Il2CppCodeGenWriteBarrier(&___calculateScoreWinLoseDrawPrefab_12, value);
	}

	inline static int32_t get_offset_of_gameFactoryContainer_13() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___gameFactoryContainer_13)); }
	inline Transform_t3275118058 * get_gameFactoryContainer_13() const { return ___gameFactoryContainer_13; }
	inline Transform_t3275118058 ** get_address_of_gameFactoryContainer_13() { return &___gameFactoryContainer_13; }
	inline void set_gameFactoryContainer_13(Transform_t3275118058 * value)
	{
		___gameFactoryContainer_13 = value;
		Il2CppCodeGenWriteBarrier(&___gameFactoryContainer_13, value);
	}

	inline static int32_t get_offset_of_isChangeSideBetweenRoundContainer_14() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___isChangeSideBetweenRoundContainer_14)); }
	inline Transform_t3275118058 * get_isChangeSideBetweenRoundContainer_14() const { return ___isChangeSideBetweenRoundContainer_14; }
	inline Transform_t3275118058 ** get_address_of_isChangeSideBetweenRoundContainer_14() { return &___isChangeSideBetweenRoundContainer_14; }
	inline void set_isChangeSideBetweenRoundContainer_14(Transform_t3275118058 * value)
	{
		___isChangeSideBetweenRoundContainer_14 = value;
		Il2CppCodeGenWriteBarrier(&___isChangeSideBetweenRoundContainer_14, value);
	}

	inline static int32_t get_offset_of_isSwitchPlayerContainer_15() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___isSwitchPlayerContainer_15)); }
	inline Transform_t3275118058 * get_isSwitchPlayerContainer_15() const { return ___isSwitchPlayerContainer_15; }
	inline Transform_t3275118058 ** get_address_of_isSwitchPlayerContainer_15() { return &___isSwitchPlayerContainer_15; }
	inline void set_isSwitchPlayerContainer_15(Transform_t3275118058 * value)
	{
		___isSwitchPlayerContainer_15 = value;
		Il2CppCodeGenWriteBarrier(&___isSwitchPlayerContainer_15, value);
	}

	inline static int32_t get_offset_of_isDifferentInTeamContainer_16() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___isDifferentInTeamContainer_16)); }
	inline Transform_t3275118058 * get_isDifferentInTeamContainer_16() const { return ___isDifferentInTeamContainer_16; }
	inline Transform_t3275118058 ** get_address_of_isDifferentInTeamContainer_16() { return &___isDifferentInTeamContainer_16; }
	inline void set_isDifferentInTeamContainer_16(Transform_t3275118058 * value)
	{
		___isDifferentInTeamContainer_16 = value;
		Il2CppCodeGenWriteBarrier(&___isDifferentInTeamContainer_16, value);
	}

	inline static int32_t get_offset_of_calculateScoreTypeContainer_17() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___calculateScoreTypeContainer_17)); }
	inline Transform_t3275118058 * get_calculateScoreTypeContainer_17() const { return ___calculateScoreTypeContainer_17; }
	inline Transform_t3275118058 ** get_address_of_calculateScoreTypeContainer_17() { return &___calculateScoreTypeContainer_17; }
	inline void set_calculateScoreTypeContainer_17(Transform_t3275118058 * value)
	{
		___calculateScoreTypeContainer_17 = value;
		Il2CppCodeGenWriteBarrier(&___calculateScoreTypeContainer_17, value);
	}

	inline static int32_t get_offset_of_calculateScoreUIContainer_18() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___calculateScoreUIContainer_18)); }
	inline Transform_t3275118058 * get_calculateScoreUIContainer_18() const { return ___calculateScoreUIContainer_18; }
	inline Transform_t3275118058 ** get_address_of_calculateScoreUIContainer_18() { return &___calculateScoreUIContainer_18; }
	inline void set_calculateScoreUIContainer_18(Transform_t3275118058 * value)
	{
		___calculateScoreUIContainer_18 = value;
		Il2CppCodeGenWriteBarrier(&___calculateScoreUIContainer_18, value);
	}

	inline static int32_t get_offset_of_server_19() { return static_cast<int32_t>(offsetof(NormalRoundFactoryUI_t1763609363, ___server_19)); }
	inline Server_t2724320767 * get_server_19() const { return ___server_19; }
	inline Server_t2724320767 ** get_address_of_server_19() { return &___server_19; }
	inline void set_server_19(Server_t2724320767 * value)
	{
		___server_19 = value;
		Il2CppCodeGenWriteBarrier(&___server_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
