#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4110582241.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// RequestChangeIntUI
struct RequestChangeIntUI_t2563984076;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
// GameManager.Match.NormalRoundFactoryUI
struct NormalRoundFactoryUI_t1763609363;
// GameManager.Match.RequestNewRoundNoLimitUI
struct RequestNewRoundNoLimitUI_t1304812289;
// GameManager.Match.RequestNewRoundHaveLimitUI
struct RequestNewRoundHaveLimitUI_t632612280;
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

// GameManager.Match.SingleContestFactoryUI
struct  SingleContestFactoryUI_t3087354338  : public UIBehavior_1_t4110582241
{
public:
	// System.Boolean GameManager.Match.SingleContestFactoryUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject GameManager.Match.SingleContestFactoryUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeIntUI GameManager.Match.SingleContestFactoryUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_8;
	// RequestChangeEnumUI GameManager.Match.SingleContestFactoryUI::requestEnumPrefab
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefab_9;
	// GameManager.Match.NormalRoundFactoryUI GameManager.Match.SingleContestFactoryUI::normalRoundFactoryPrefab
	NormalRoundFactoryUI_t1763609363 * ___normalRoundFactoryPrefab_10;
	// GameManager.Match.RequestNewRoundNoLimitUI GameManager.Match.SingleContestFactoryUI::requestNewRoundNoLimitPrefab
	RequestNewRoundNoLimitUI_t1304812289 * ___requestNewRoundNoLimitPrefab_11;
	// GameManager.Match.RequestNewRoundHaveLimitUI GameManager.Match.SingleContestFactoryUI::requestNewRoundHaveLimitPrefab
	RequestNewRoundHaveLimitUI_t632612280 * ___requestNewRoundHaveLimitPrefab_12;
	// GameManager.Match.CalculateScoreSumUI GameManager.Match.SingleContestFactoryUI::calculateScoreSumPrefab
	CalculateScoreSumUI_t3262781401 * ___calculateScoreSumPrefab_13;
	// GameManager.Match.CalculateScoreWinLoseDrawUI GameManager.Match.SingleContestFactoryUI::calculateScoreWinLoseDrawPrefab
	CalculateScoreWinLoseDrawUI_t4022670967 * ___calculateScoreWinLoseDrawPrefab_14;
	// UnityEngine.Transform GameManager.Match.SingleContestFactoryUI::playerPerTeamContainer
	Transform_t3275118058 * ___playerPerTeamContainer_15;
	// UnityEngine.Transform GameManager.Match.SingleContestFactoryUI::roundFactoryTypeContainer
	Transform_t3275118058 * ___roundFactoryTypeContainer_16;
	// UnityEngine.Transform GameManager.Match.SingleContestFactoryUI::roundFactoryUIContainer
	Transform_t3275118058 * ___roundFactoryUIContainer_17;
	// UnityEngine.Transform GameManager.Match.SingleContestFactoryUI::newRoundLimitTypeContainer
	Transform_t3275118058 * ___newRoundLimitTypeContainer_18;
	// UnityEngine.Transform GameManager.Match.SingleContestFactoryUI::newRoundLimitUIContainer
	Transform_t3275118058 * ___newRoundLimitUIContainer_19;
	// UnityEngine.Transform GameManager.Match.SingleContestFactoryUI::calculateScoreTypeContainer
	Transform_t3275118058 * ___calculateScoreTypeContainer_20;
	// UnityEngine.Transform GameManager.Match.SingleContestFactoryUI::calculateScoreUIContainer
	Transform_t3275118058 * ___calculateScoreUIContainer_21;
	// Server GameManager.Match.SingleContestFactoryUI::server
	Server_t2724320767 * ___server_22;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_8() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___requestIntPrefab_8)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_8() const { return ___requestIntPrefab_8; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_8() { return &___requestIntPrefab_8; }
	inline void set_requestIntPrefab_8(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_8, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefab_9() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___requestEnumPrefab_9)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefab_9() const { return ___requestEnumPrefab_9; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefab_9() { return &___requestEnumPrefab_9; }
	inline void set_requestEnumPrefab_9(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefab_9, value);
	}

	inline static int32_t get_offset_of_normalRoundFactoryPrefab_10() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___normalRoundFactoryPrefab_10)); }
	inline NormalRoundFactoryUI_t1763609363 * get_normalRoundFactoryPrefab_10() const { return ___normalRoundFactoryPrefab_10; }
	inline NormalRoundFactoryUI_t1763609363 ** get_address_of_normalRoundFactoryPrefab_10() { return &___normalRoundFactoryPrefab_10; }
	inline void set_normalRoundFactoryPrefab_10(NormalRoundFactoryUI_t1763609363 * value)
	{
		___normalRoundFactoryPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___normalRoundFactoryPrefab_10, value);
	}

	inline static int32_t get_offset_of_requestNewRoundNoLimitPrefab_11() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___requestNewRoundNoLimitPrefab_11)); }
	inline RequestNewRoundNoLimitUI_t1304812289 * get_requestNewRoundNoLimitPrefab_11() const { return ___requestNewRoundNoLimitPrefab_11; }
	inline RequestNewRoundNoLimitUI_t1304812289 ** get_address_of_requestNewRoundNoLimitPrefab_11() { return &___requestNewRoundNoLimitPrefab_11; }
	inline void set_requestNewRoundNoLimitPrefab_11(RequestNewRoundNoLimitUI_t1304812289 * value)
	{
		___requestNewRoundNoLimitPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRoundNoLimitPrefab_11, value);
	}

	inline static int32_t get_offset_of_requestNewRoundHaveLimitPrefab_12() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___requestNewRoundHaveLimitPrefab_12)); }
	inline RequestNewRoundHaveLimitUI_t632612280 * get_requestNewRoundHaveLimitPrefab_12() const { return ___requestNewRoundHaveLimitPrefab_12; }
	inline RequestNewRoundHaveLimitUI_t632612280 ** get_address_of_requestNewRoundHaveLimitPrefab_12() { return &___requestNewRoundHaveLimitPrefab_12; }
	inline void set_requestNewRoundHaveLimitPrefab_12(RequestNewRoundHaveLimitUI_t632612280 * value)
	{
		___requestNewRoundHaveLimitPrefab_12 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRoundHaveLimitPrefab_12, value);
	}

	inline static int32_t get_offset_of_calculateScoreSumPrefab_13() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___calculateScoreSumPrefab_13)); }
	inline CalculateScoreSumUI_t3262781401 * get_calculateScoreSumPrefab_13() const { return ___calculateScoreSumPrefab_13; }
	inline CalculateScoreSumUI_t3262781401 ** get_address_of_calculateScoreSumPrefab_13() { return &___calculateScoreSumPrefab_13; }
	inline void set_calculateScoreSumPrefab_13(CalculateScoreSumUI_t3262781401 * value)
	{
		___calculateScoreSumPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___calculateScoreSumPrefab_13, value);
	}

	inline static int32_t get_offset_of_calculateScoreWinLoseDrawPrefab_14() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___calculateScoreWinLoseDrawPrefab_14)); }
	inline CalculateScoreWinLoseDrawUI_t4022670967 * get_calculateScoreWinLoseDrawPrefab_14() const { return ___calculateScoreWinLoseDrawPrefab_14; }
	inline CalculateScoreWinLoseDrawUI_t4022670967 ** get_address_of_calculateScoreWinLoseDrawPrefab_14() { return &___calculateScoreWinLoseDrawPrefab_14; }
	inline void set_calculateScoreWinLoseDrawPrefab_14(CalculateScoreWinLoseDrawUI_t4022670967 * value)
	{
		___calculateScoreWinLoseDrawPrefab_14 = value;
		Il2CppCodeGenWriteBarrier(&___calculateScoreWinLoseDrawPrefab_14, value);
	}

	inline static int32_t get_offset_of_playerPerTeamContainer_15() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___playerPerTeamContainer_15)); }
	inline Transform_t3275118058 * get_playerPerTeamContainer_15() const { return ___playerPerTeamContainer_15; }
	inline Transform_t3275118058 ** get_address_of_playerPerTeamContainer_15() { return &___playerPerTeamContainer_15; }
	inline void set_playerPerTeamContainer_15(Transform_t3275118058 * value)
	{
		___playerPerTeamContainer_15 = value;
		Il2CppCodeGenWriteBarrier(&___playerPerTeamContainer_15, value);
	}

	inline static int32_t get_offset_of_roundFactoryTypeContainer_16() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___roundFactoryTypeContainer_16)); }
	inline Transform_t3275118058 * get_roundFactoryTypeContainer_16() const { return ___roundFactoryTypeContainer_16; }
	inline Transform_t3275118058 ** get_address_of_roundFactoryTypeContainer_16() { return &___roundFactoryTypeContainer_16; }
	inline void set_roundFactoryTypeContainer_16(Transform_t3275118058 * value)
	{
		___roundFactoryTypeContainer_16 = value;
		Il2CppCodeGenWriteBarrier(&___roundFactoryTypeContainer_16, value);
	}

	inline static int32_t get_offset_of_roundFactoryUIContainer_17() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___roundFactoryUIContainer_17)); }
	inline Transform_t3275118058 * get_roundFactoryUIContainer_17() const { return ___roundFactoryUIContainer_17; }
	inline Transform_t3275118058 ** get_address_of_roundFactoryUIContainer_17() { return &___roundFactoryUIContainer_17; }
	inline void set_roundFactoryUIContainer_17(Transform_t3275118058 * value)
	{
		___roundFactoryUIContainer_17 = value;
		Il2CppCodeGenWriteBarrier(&___roundFactoryUIContainer_17, value);
	}

	inline static int32_t get_offset_of_newRoundLimitTypeContainer_18() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___newRoundLimitTypeContainer_18)); }
	inline Transform_t3275118058 * get_newRoundLimitTypeContainer_18() const { return ___newRoundLimitTypeContainer_18; }
	inline Transform_t3275118058 ** get_address_of_newRoundLimitTypeContainer_18() { return &___newRoundLimitTypeContainer_18; }
	inline void set_newRoundLimitTypeContainer_18(Transform_t3275118058 * value)
	{
		___newRoundLimitTypeContainer_18 = value;
		Il2CppCodeGenWriteBarrier(&___newRoundLimitTypeContainer_18, value);
	}

	inline static int32_t get_offset_of_newRoundLimitUIContainer_19() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___newRoundLimitUIContainer_19)); }
	inline Transform_t3275118058 * get_newRoundLimitUIContainer_19() const { return ___newRoundLimitUIContainer_19; }
	inline Transform_t3275118058 ** get_address_of_newRoundLimitUIContainer_19() { return &___newRoundLimitUIContainer_19; }
	inline void set_newRoundLimitUIContainer_19(Transform_t3275118058 * value)
	{
		___newRoundLimitUIContainer_19 = value;
		Il2CppCodeGenWriteBarrier(&___newRoundLimitUIContainer_19, value);
	}

	inline static int32_t get_offset_of_calculateScoreTypeContainer_20() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___calculateScoreTypeContainer_20)); }
	inline Transform_t3275118058 * get_calculateScoreTypeContainer_20() const { return ___calculateScoreTypeContainer_20; }
	inline Transform_t3275118058 ** get_address_of_calculateScoreTypeContainer_20() { return &___calculateScoreTypeContainer_20; }
	inline void set_calculateScoreTypeContainer_20(Transform_t3275118058 * value)
	{
		___calculateScoreTypeContainer_20 = value;
		Il2CppCodeGenWriteBarrier(&___calculateScoreTypeContainer_20, value);
	}

	inline static int32_t get_offset_of_calculateScoreUIContainer_21() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___calculateScoreUIContainer_21)); }
	inline Transform_t3275118058 * get_calculateScoreUIContainer_21() const { return ___calculateScoreUIContainer_21; }
	inline Transform_t3275118058 ** get_address_of_calculateScoreUIContainer_21() { return &___calculateScoreUIContainer_21; }
	inline void set_calculateScoreUIContainer_21(Transform_t3275118058 * value)
	{
		___calculateScoreUIContainer_21 = value;
		Il2CppCodeGenWriteBarrier(&___calculateScoreUIContainer_21, value);
	}

	inline static int32_t get_offset_of_server_22() { return static_cast<int32_t>(offsetof(SingleContestFactoryUI_t3087354338, ___server_22)); }
	inline Server_t2724320767 * get_server_22() const { return ___server_22; }
	inline Server_t2724320767 ** get_address_of_server_22() { return &___server_22; }
	inline void set_server_22(Server_t2724320767 * value)
	{
		___server_22 = value;
		Il2CppCodeGenWriteBarrier(&___server_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
