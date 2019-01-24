#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1501207257.h"

// GameManager.Match.ChooseContestManagerAdapter
struct ChooseContestManagerAdapter_t324860687;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.Match.ContestManagerInformUI
struct ContestManagerInformUI_t1492993402;
// RoomUI/UIData
struct UIData_t2598208972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseContestManagerUI
struct  ChooseContestManagerUI_t1115113002  : public UIBehavior_1_t1501207257
{
public:
	// GameManager.Match.ChooseContestManagerAdapter GameManager.Match.ChooseContestManagerUI::chooseContestManagerPrefab
	ChooseContestManagerAdapter_t324860687 * ___chooseContestManagerPrefab_6;
	// UnityEngine.Transform GameManager.Match.ChooseContestManagerUI::chooseContestManagerContainer
	Transform_t3275118058 * ___chooseContestManagerContainer_7;
	// GameManager.Match.ContestManagerInformUI GameManager.Match.ChooseContestManagerUI::contestManagerInformPrefab
	ContestManagerInformUI_t1492993402 * ___contestManagerInformPrefab_8;
	// UnityEngine.Transform GameManager.Match.ChooseContestManagerUI::contestManagerInformContainer
	Transform_t3275118058 * ___contestManagerInformContainer_9;
	// RoomUI/UIData GameManager.Match.ChooseContestManagerUI::roomUIData
	UIData_t2598208972 * ___roomUIData_10;

public:
	inline static int32_t get_offset_of_chooseContestManagerPrefab_6() { return static_cast<int32_t>(offsetof(ChooseContestManagerUI_t1115113002, ___chooseContestManagerPrefab_6)); }
	inline ChooseContestManagerAdapter_t324860687 * get_chooseContestManagerPrefab_6() const { return ___chooseContestManagerPrefab_6; }
	inline ChooseContestManagerAdapter_t324860687 ** get_address_of_chooseContestManagerPrefab_6() { return &___chooseContestManagerPrefab_6; }
	inline void set_chooseContestManagerPrefab_6(ChooseContestManagerAdapter_t324860687 * value)
	{
		___chooseContestManagerPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___chooseContestManagerPrefab_6, value);
	}

	inline static int32_t get_offset_of_chooseContestManagerContainer_7() { return static_cast<int32_t>(offsetof(ChooseContestManagerUI_t1115113002, ___chooseContestManagerContainer_7)); }
	inline Transform_t3275118058 * get_chooseContestManagerContainer_7() const { return ___chooseContestManagerContainer_7; }
	inline Transform_t3275118058 ** get_address_of_chooseContestManagerContainer_7() { return &___chooseContestManagerContainer_7; }
	inline void set_chooseContestManagerContainer_7(Transform_t3275118058 * value)
	{
		___chooseContestManagerContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___chooseContestManagerContainer_7, value);
	}

	inline static int32_t get_offset_of_contestManagerInformPrefab_8() { return static_cast<int32_t>(offsetof(ChooseContestManagerUI_t1115113002, ___contestManagerInformPrefab_8)); }
	inline ContestManagerInformUI_t1492993402 * get_contestManagerInformPrefab_8() const { return ___contestManagerInformPrefab_8; }
	inline ContestManagerInformUI_t1492993402 ** get_address_of_contestManagerInformPrefab_8() { return &___contestManagerInformPrefab_8; }
	inline void set_contestManagerInformPrefab_8(ContestManagerInformUI_t1492993402 * value)
	{
		___contestManagerInformPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerInformPrefab_8, value);
	}

	inline static int32_t get_offset_of_contestManagerInformContainer_9() { return static_cast<int32_t>(offsetof(ChooseContestManagerUI_t1115113002, ___contestManagerInformContainer_9)); }
	inline Transform_t3275118058 * get_contestManagerInformContainer_9() const { return ___contestManagerInformContainer_9; }
	inline Transform_t3275118058 ** get_address_of_contestManagerInformContainer_9() { return &___contestManagerInformContainer_9; }
	inline void set_contestManagerInformContainer_9(Transform_t3275118058 * value)
	{
		___contestManagerInformContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerInformContainer_9, value);
	}

	inline static int32_t get_offset_of_roomUIData_10() { return static_cast<int32_t>(offsetof(ChooseContestManagerUI_t1115113002, ___roomUIData_10)); }
	inline UIData_t2598208972 * get_roomUIData_10() const { return ___roomUIData_10; }
	inline UIData_t2598208972 ** get_address_of_roomUIData_10() { return &___roomUIData_10; }
	inline void set_roomUIData_10(UIData_t2598208972 * value)
	{
		___roomUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___roomUIData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
