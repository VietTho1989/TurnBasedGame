#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3785115575.h"

// GameManager.Match.RoundUI
struct RoundUI_t2850044108;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.Match.RequestNewRoundUI
struct RequestNewRoundUI_t1925056109;
// GameManager.Match.ChooseRoundUI
struct ChooseRoundUI_t430321213;
// RoomUI/UIData
struct UIData_t2598208972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestUI
struct  ContestUI_t3044427636  : public UIBehavior_1_t3785115575
{
public:
	// System.Boolean GameManager.Match.ContestUI::haveNewRound
	bool ___haveNewRound_6;
	// GameManager.Match.RoundUI GameManager.Match.ContestUI::roundPrefab
	RoundUI_t2850044108 * ___roundPrefab_7;
	// UnityEngine.Transform GameManager.Match.ContestUI::roundContainer
	Transform_t3275118058 * ___roundContainer_8;
	// GameManager.Match.RequestNewRoundUI GameManager.Match.ContestUI::requestNewRoundPrefab
	RequestNewRoundUI_t1925056109 * ___requestNewRoundPrefab_9;
	// UnityEngine.Transform GameManager.Match.ContestUI::requestNewRoundContainer
	Transform_t3275118058 * ___requestNewRoundContainer_10;
	// GameManager.Match.ChooseRoundUI GameManager.Match.ContestUI::chooseRoundPrefab
	ChooseRoundUI_t430321213 * ___chooseRoundPrefab_11;
	// UnityEngine.Transform GameManager.Match.ContestUI::chooseRoundContainer
	Transform_t3275118058 * ___chooseRoundContainer_12;
	// RoomUI/UIData GameManager.Match.ContestUI::roomUIData
	UIData_t2598208972 * ___roomUIData_13;

public:
	inline static int32_t get_offset_of_haveNewRound_6() { return static_cast<int32_t>(offsetof(ContestUI_t3044427636, ___haveNewRound_6)); }
	inline bool get_haveNewRound_6() const { return ___haveNewRound_6; }
	inline bool* get_address_of_haveNewRound_6() { return &___haveNewRound_6; }
	inline void set_haveNewRound_6(bool value)
	{
		___haveNewRound_6 = value;
	}

	inline static int32_t get_offset_of_roundPrefab_7() { return static_cast<int32_t>(offsetof(ContestUI_t3044427636, ___roundPrefab_7)); }
	inline RoundUI_t2850044108 * get_roundPrefab_7() const { return ___roundPrefab_7; }
	inline RoundUI_t2850044108 ** get_address_of_roundPrefab_7() { return &___roundPrefab_7; }
	inline void set_roundPrefab_7(RoundUI_t2850044108 * value)
	{
		___roundPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___roundPrefab_7, value);
	}

	inline static int32_t get_offset_of_roundContainer_8() { return static_cast<int32_t>(offsetof(ContestUI_t3044427636, ___roundContainer_8)); }
	inline Transform_t3275118058 * get_roundContainer_8() const { return ___roundContainer_8; }
	inline Transform_t3275118058 ** get_address_of_roundContainer_8() { return &___roundContainer_8; }
	inline void set_roundContainer_8(Transform_t3275118058 * value)
	{
		___roundContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___roundContainer_8, value);
	}

	inline static int32_t get_offset_of_requestNewRoundPrefab_9() { return static_cast<int32_t>(offsetof(ContestUI_t3044427636, ___requestNewRoundPrefab_9)); }
	inline RequestNewRoundUI_t1925056109 * get_requestNewRoundPrefab_9() const { return ___requestNewRoundPrefab_9; }
	inline RequestNewRoundUI_t1925056109 ** get_address_of_requestNewRoundPrefab_9() { return &___requestNewRoundPrefab_9; }
	inline void set_requestNewRoundPrefab_9(RequestNewRoundUI_t1925056109 * value)
	{
		___requestNewRoundPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRoundPrefab_9, value);
	}

	inline static int32_t get_offset_of_requestNewRoundContainer_10() { return static_cast<int32_t>(offsetof(ContestUI_t3044427636, ___requestNewRoundContainer_10)); }
	inline Transform_t3275118058 * get_requestNewRoundContainer_10() const { return ___requestNewRoundContainer_10; }
	inline Transform_t3275118058 ** get_address_of_requestNewRoundContainer_10() { return &___requestNewRoundContainer_10; }
	inline void set_requestNewRoundContainer_10(Transform_t3275118058 * value)
	{
		___requestNewRoundContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRoundContainer_10, value);
	}

	inline static int32_t get_offset_of_chooseRoundPrefab_11() { return static_cast<int32_t>(offsetof(ContestUI_t3044427636, ___chooseRoundPrefab_11)); }
	inline ChooseRoundUI_t430321213 * get_chooseRoundPrefab_11() const { return ___chooseRoundPrefab_11; }
	inline ChooseRoundUI_t430321213 ** get_address_of_chooseRoundPrefab_11() { return &___chooseRoundPrefab_11; }
	inline void set_chooseRoundPrefab_11(ChooseRoundUI_t430321213 * value)
	{
		___chooseRoundPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundPrefab_11, value);
	}

	inline static int32_t get_offset_of_chooseRoundContainer_12() { return static_cast<int32_t>(offsetof(ContestUI_t3044427636, ___chooseRoundContainer_12)); }
	inline Transform_t3275118058 * get_chooseRoundContainer_12() const { return ___chooseRoundContainer_12; }
	inline Transform_t3275118058 ** get_address_of_chooseRoundContainer_12() { return &___chooseRoundContainer_12; }
	inline void set_chooseRoundContainer_12(Transform_t3275118058 * value)
	{
		___chooseRoundContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundContainer_12, value);
	}

	inline static int32_t get_offset_of_roomUIData_13() { return static_cast<int32_t>(offsetof(ContestUI_t3044427636, ___roomUIData_13)); }
	inline UIData_t2598208972 * get_roomUIData_13() const { return ___roomUIData_13; }
	inline UIData_t2598208972 ** get_address_of_roomUIData_13() { return &___roomUIData_13; }
	inline void set_roomUIData_13(UIData_t2598208972 * value)
	{
		___roomUIData_13 = value;
		Il2CppCodeGenWriteBarrier(&___roomUIData_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
