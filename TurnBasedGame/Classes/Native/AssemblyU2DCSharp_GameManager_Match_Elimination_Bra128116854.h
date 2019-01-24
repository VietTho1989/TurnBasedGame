#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2287783120.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// GameManager.Match.Elimination.BracketContestUI
struct BracketContestUI_t1105050306;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.Match.Elimination.ChooseBracketContestUI
struct ChooseBracketContestUI_t2619032151;
// RoomUI/UIData
struct UIData_t2598208972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.BracketUI
struct  BracketUI_t128116854  : public UIBehavior_1_t2287783120
{
public:
	// UnityEngine.GameObject GameManager.Match.Elimination.BracketUI::noBracketContest
	GameObject_t1756533147 * ___noBracketContest_6;
	// GameManager.Match.Elimination.BracketContestUI GameManager.Match.Elimination.BracketUI::bracketContestPrefab
	BracketContestUI_t1105050306 * ___bracketContestPrefab_7;
	// UnityEngine.Transform GameManager.Match.Elimination.BracketUI::bracketContestContainer
	Transform_t3275118058 * ___bracketContestContainer_8;
	// GameManager.Match.Elimination.ChooseBracketContestUI GameManager.Match.Elimination.BracketUI::chooseBracketContestPrefab
	ChooseBracketContestUI_t2619032151 * ___chooseBracketContestPrefab_9;
	// UnityEngine.Transform GameManager.Match.Elimination.BracketUI::chooseBracketContestContainer
	Transform_t3275118058 * ___chooseBracketContestContainer_10;
	// RoomUI/UIData GameManager.Match.Elimination.BracketUI::roomUIData
	UIData_t2598208972 * ___roomUIData_11;

public:
	inline static int32_t get_offset_of_noBracketContest_6() { return static_cast<int32_t>(offsetof(BracketUI_t128116854, ___noBracketContest_6)); }
	inline GameObject_t1756533147 * get_noBracketContest_6() const { return ___noBracketContest_6; }
	inline GameObject_t1756533147 ** get_address_of_noBracketContest_6() { return &___noBracketContest_6; }
	inline void set_noBracketContest_6(GameObject_t1756533147 * value)
	{
		___noBracketContest_6 = value;
		Il2CppCodeGenWriteBarrier(&___noBracketContest_6, value);
	}

	inline static int32_t get_offset_of_bracketContestPrefab_7() { return static_cast<int32_t>(offsetof(BracketUI_t128116854, ___bracketContestPrefab_7)); }
	inline BracketContestUI_t1105050306 * get_bracketContestPrefab_7() const { return ___bracketContestPrefab_7; }
	inline BracketContestUI_t1105050306 ** get_address_of_bracketContestPrefab_7() { return &___bracketContestPrefab_7; }
	inline void set_bracketContestPrefab_7(BracketContestUI_t1105050306 * value)
	{
		___bracketContestPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContestPrefab_7, value);
	}

	inline static int32_t get_offset_of_bracketContestContainer_8() { return static_cast<int32_t>(offsetof(BracketUI_t128116854, ___bracketContestContainer_8)); }
	inline Transform_t3275118058 * get_bracketContestContainer_8() const { return ___bracketContestContainer_8; }
	inline Transform_t3275118058 ** get_address_of_bracketContestContainer_8() { return &___bracketContestContainer_8; }
	inline void set_bracketContestContainer_8(Transform_t3275118058 * value)
	{
		___bracketContestContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContestContainer_8, value);
	}

	inline static int32_t get_offset_of_chooseBracketContestPrefab_9() { return static_cast<int32_t>(offsetof(BracketUI_t128116854, ___chooseBracketContestPrefab_9)); }
	inline ChooseBracketContestUI_t2619032151 * get_chooseBracketContestPrefab_9() const { return ___chooseBracketContestPrefab_9; }
	inline ChooseBracketContestUI_t2619032151 ** get_address_of_chooseBracketContestPrefab_9() { return &___chooseBracketContestPrefab_9; }
	inline void set_chooseBracketContestPrefab_9(ChooseBracketContestUI_t2619032151 * value)
	{
		___chooseBracketContestPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___chooseBracketContestPrefab_9, value);
	}

	inline static int32_t get_offset_of_chooseBracketContestContainer_10() { return static_cast<int32_t>(offsetof(BracketUI_t128116854, ___chooseBracketContestContainer_10)); }
	inline Transform_t3275118058 * get_chooseBracketContestContainer_10() const { return ___chooseBracketContestContainer_10; }
	inline Transform_t3275118058 ** get_address_of_chooseBracketContestContainer_10() { return &___chooseBracketContestContainer_10; }
	inline void set_chooseBracketContestContainer_10(Transform_t3275118058 * value)
	{
		___chooseBracketContestContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___chooseBracketContestContainer_10, value);
	}

	inline static int32_t get_offset_of_roomUIData_11() { return static_cast<int32_t>(offsetof(BracketUI_t128116854, ___roomUIData_11)); }
	inline UIData_t2598208972 * get_roomUIData_11() const { return ___roomUIData_11; }
	inline UIData_t2598208972 ** get_address_of_roomUIData_11() { return &___roomUIData_11; }
	inline void set_roomUIData_11(UIData_t2598208972 * value)
	{
		___roomUIData_11 = value;
		Il2CppCodeGenWriteBarrier(&___roomUIData_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
