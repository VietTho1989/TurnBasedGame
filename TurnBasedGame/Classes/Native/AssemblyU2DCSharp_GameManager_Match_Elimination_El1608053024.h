#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1166215604.h"

// GameManager.Match.Elimination.EliminationRoundUI
struct EliminationRoundUI_t1345130477;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.Match.Elimination.ChooseEliminationRoundUI
struct ChooseEliminationRoundUI_t3955130730;
// GameManager.Match.Elimination.RequestNewEliminationRoundUI
struct RequestNewEliminationRoundUI_t1044632778;
// RoomUI/UIData
struct UIData_t2598208972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.EliminationContentUI
struct  EliminationContentUI_t1608053024  : public UIBehavior_1_t1166215604
{
public:
	// System.Boolean GameManager.Match.Elimination.EliminationContentUI::haveNewRound
	bool ___haveNewRound_6;
	// GameManager.Match.Elimination.EliminationRoundUI GameManager.Match.Elimination.EliminationContentUI::eliminationRoundPrefab
	EliminationRoundUI_t1345130477 * ___eliminationRoundPrefab_7;
	// UnityEngine.Transform GameManager.Match.Elimination.EliminationContentUI::eliminationRoundContainer
	Transform_t3275118058 * ___eliminationRoundContainer_8;
	// GameManager.Match.Elimination.ChooseEliminationRoundUI GameManager.Match.Elimination.EliminationContentUI::chooseEliminationRoundPrefab
	ChooseEliminationRoundUI_t3955130730 * ___chooseEliminationRoundPrefab_9;
	// UnityEngine.Transform GameManager.Match.Elimination.EliminationContentUI::chooseEliminationRoundContainer
	Transform_t3275118058 * ___chooseEliminationRoundContainer_10;
	// GameManager.Match.Elimination.RequestNewEliminationRoundUI GameManager.Match.Elimination.EliminationContentUI::requestNewEliminationRoundPrefab
	RequestNewEliminationRoundUI_t1044632778 * ___requestNewEliminationRoundPrefab_11;
	// UnityEngine.Transform GameManager.Match.Elimination.EliminationContentUI::requestNewEliminationRoundContainer
	Transform_t3275118058 * ___requestNewEliminationRoundContainer_12;
	// RoomUI/UIData GameManager.Match.Elimination.EliminationContentUI::roomUIData
	UIData_t2598208972 * ___roomUIData_13;

public:
	inline static int32_t get_offset_of_haveNewRound_6() { return static_cast<int32_t>(offsetof(EliminationContentUI_t1608053024, ___haveNewRound_6)); }
	inline bool get_haveNewRound_6() const { return ___haveNewRound_6; }
	inline bool* get_address_of_haveNewRound_6() { return &___haveNewRound_6; }
	inline void set_haveNewRound_6(bool value)
	{
		___haveNewRound_6 = value;
	}

	inline static int32_t get_offset_of_eliminationRoundPrefab_7() { return static_cast<int32_t>(offsetof(EliminationContentUI_t1608053024, ___eliminationRoundPrefab_7)); }
	inline EliminationRoundUI_t1345130477 * get_eliminationRoundPrefab_7() const { return ___eliminationRoundPrefab_7; }
	inline EliminationRoundUI_t1345130477 ** get_address_of_eliminationRoundPrefab_7() { return &___eliminationRoundPrefab_7; }
	inline void set_eliminationRoundPrefab_7(EliminationRoundUI_t1345130477 * value)
	{
		___eliminationRoundPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___eliminationRoundPrefab_7, value);
	}

	inline static int32_t get_offset_of_eliminationRoundContainer_8() { return static_cast<int32_t>(offsetof(EliminationContentUI_t1608053024, ___eliminationRoundContainer_8)); }
	inline Transform_t3275118058 * get_eliminationRoundContainer_8() const { return ___eliminationRoundContainer_8; }
	inline Transform_t3275118058 ** get_address_of_eliminationRoundContainer_8() { return &___eliminationRoundContainer_8; }
	inline void set_eliminationRoundContainer_8(Transform_t3275118058 * value)
	{
		___eliminationRoundContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___eliminationRoundContainer_8, value);
	}

	inline static int32_t get_offset_of_chooseEliminationRoundPrefab_9() { return static_cast<int32_t>(offsetof(EliminationContentUI_t1608053024, ___chooseEliminationRoundPrefab_9)); }
	inline ChooseEliminationRoundUI_t3955130730 * get_chooseEliminationRoundPrefab_9() const { return ___chooseEliminationRoundPrefab_9; }
	inline ChooseEliminationRoundUI_t3955130730 ** get_address_of_chooseEliminationRoundPrefab_9() { return &___chooseEliminationRoundPrefab_9; }
	inline void set_chooseEliminationRoundPrefab_9(ChooseEliminationRoundUI_t3955130730 * value)
	{
		___chooseEliminationRoundPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___chooseEliminationRoundPrefab_9, value);
	}

	inline static int32_t get_offset_of_chooseEliminationRoundContainer_10() { return static_cast<int32_t>(offsetof(EliminationContentUI_t1608053024, ___chooseEliminationRoundContainer_10)); }
	inline Transform_t3275118058 * get_chooseEliminationRoundContainer_10() const { return ___chooseEliminationRoundContainer_10; }
	inline Transform_t3275118058 ** get_address_of_chooseEliminationRoundContainer_10() { return &___chooseEliminationRoundContainer_10; }
	inline void set_chooseEliminationRoundContainer_10(Transform_t3275118058 * value)
	{
		___chooseEliminationRoundContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___chooseEliminationRoundContainer_10, value);
	}

	inline static int32_t get_offset_of_requestNewEliminationRoundPrefab_11() { return static_cast<int32_t>(offsetof(EliminationContentUI_t1608053024, ___requestNewEliminationRoundPrefab_11)); }
	inline RequestNewEliminationRoundUI_t1044632778 * get_requestNewEliminationRoundPrefab_11() const { return ___requestNewEliminationRoundPrefab_11; }
	inline RequestNewEliminationRoundUI_t1044632778 ** get_address_of_requestNewEliminationRoundPrefab_11() { return &___requestNewEliminationRoundPrefab_11; }
	inline void set_requestNewEliminationRoundPrefab_11(RequestNewEliminationRoundUI_t1044632778 * value)
	{
		___requestNewEliminationRoundPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewEliminationRoundPrefab_11, value);
	}

	inline static int32_t get_offset_of_requestNewEliminationRoundContainer_12() { return static_cast<int32_t>(offsetof(EliminationContentUI_t1608053024, ___requestNewEliminationRoundContainer_12)); }
	inline Transform_t3275118058 * get_requestNewEliminationRoundContainer_12() const { return ___requestNewEliminationRoundContainer_12; }
	inline Transform_t3275118058 ** get_address_of_requestNewEliminationRoundContainer_12() { return &___requestNewEliminationRoundContainer_12; }
	inline void set_requestNewEliminationRoundContainer_12(Transform_t3275118058 * value)
	{
		___requestNewEliminationRoundContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewEliminationRoundContainer_12, value);
	}

	inline static int32_t get_offset_of_roomUIData_13() { return static_cast<int32_t>(offsetof(EliminationContentUI_t1608053024, ___roomUIData_13)); }
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
