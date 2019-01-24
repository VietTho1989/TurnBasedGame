#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2022449921.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// MiniGameDataUI
struct MiniGameDataUI_t29488987;
// UnityEngine.Transform
struct Transform_t3275118058;
// Posture.EditPostureGameDataUI
struct EditPostureGameDataUI_t1506665454;
// RequestChangeBoolUI
struct RequestChangeBoolUI_t2618169711;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PostureGameDataFactoryUI
struct  PostureGameDataFactoryUI_t4105453318  : public UIBehavior_1_t2022449921
{
public:
	// UnityEngine.UI.Button PostureGameDataFactoryUI::btnEdit
	Button_t2872111280 * ___btnEdit_6;
	// System.Boolean PostureGameDataFactoryUI::needReset
	bool ___needReset_7;
	// UnityEngine.GameObject PostureGameDataFactoryUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_8;
	// MiniGameDataUI PostureGameDataFactoryUI::miniGameDataUIPrefab
	MiniGameDataUI_t29488987 * ___miniGameDataUIPrefab_9;
	// UnityEngine.Transform PostureGameDataFactoryUI::miniGameDataUIContainer
	Transform_t3275118058 * ___miniGameDataUIContainer_10;
	// Posture.EditPostureGameDataUI PostureGameDataFactoryUI::editPostureGameDataPrefab
	EditPostureGameDataUI_t1506665454 * ___editPostureGameDataPrefab_11;
	// RequestChangeBoolUI PostureGameDataFactoryUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_12;
	// RequestChangeEnumUI PostureGameDataFactoryUI::requestEnumPrefab
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefab_13;
	// UnityEngine.Transform PostureGameDataFactoryUI::gameTypeContainer
	Transform_t3275118058 * ___gameTypeContainer_14;
	// UnityEngine.Transform PostureGameDataFactoryUI::useRuleContainer
	Transform_t3275118058 * ___useRuleContainer_15;
	// Server PostureGameDataFactoryUI::server
	Server_t2724320767 * ___server_16;

public:
	inline static int32_t get_offset_of_btnEdit_6() { return static_cast<int32_t>(offsetof(PostureGameDataFactoryUI_t4105453318, ___btnEdit_6)); }
	inline Button_t2872111280 * get_btnEdit_6() const { return ___btnEdit_6; }
	inline Button_t2872111280 ** get_address_of_btnEdit_6() { return &___btnEdit_6; }
	inline void set_btnEdit_6(Button_t2872111280 * value)
	{
		___btnEdit_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnEdit_6, value);
	}

	inline static int32_t get_offset_of_needReset_7() { return static_cast<int32_t>(offsetof(PostureGameDataFactoryUI_t4105453318, ___needReset_7)); }
	inline bool get_needReset_7() const { return ___needReset_7; }
	inline bool* get_address_of_needReset_7() { return &___needReset_7; }
	inline void set_needReset_7(bool value)
	{
		___needReset_7 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_8() { return static_cast<int32_t>(offsetof(PostureGameDataFactoryUI_t4105453318, ___differentIndicator_8)); }
	inline GameObject_t1756533147 * get_differentIndicator_8() const { return ___differentIndicator_8; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_8() { return &___differentIndicator_8; }
	inline void set_differentIndicator_8(GameObject_t1756533147 * value)
	{
		___differentIndicator_8 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_8, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIPrefab_9() { return static_cast<int32_t>(offsetof(PostureGameDataFactoryUI_t4105453318, ___miniGameDataUIPrefab_9)); }
	inline MiniGameDataUI_t29488987 * get_miniGameDataUIPrefab_9() const { return ___miniGameDataUIPrefab_9; }
	inline MiniGameDataUI_t29488987 ** get_address_of_miniGameDataUIPrefab_9() { return &___miniGameDataUIPrefab_9; }
	inline void set_miniGameDataUIPrefab_9(MiniGameDataUI_t29488987 * value)
	{
		___miniGameDataUIPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIPrefab_9, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIContainer_10() { return static_cast<int32_t>(offsetof(PostureGameDataFactoryUI_t4105453318, ___miniGameDataUIContainer_10)); }
	inline Transform_t3275118058 * get_miniGameDataUIContainer_10() const { return ___miniGameDataUIContainer_10; }
	inline Transform_t3275118058 ** get_address_of_miniGameDataUIContainer_10() { return &___miniGameDataUIContainer_10; }
	inline void set_miniGameDataUIContainer_10(Transform_t3275118058 * value)
	{
		___miniGameDataUIContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIContainer_10, value);
	}

	inline static int32_t get_offset_of_editPostureGameDataPrefab_11() { return static_cast<int32_t>(offsetof(PostureGameDataFactoryUI_t4105453318, ___editPostureGameDataPrefab_11)); }
	inline EditPostureGameDataUI_t1506665454 * get_editPostureGameDataPrefab_11() const { return ___editPostureGameDataPrefab_11; }
	inline EditPostureGameDataUI_t1506665454 ** get_address_of_editPostureGameDataPrefab_11() { return &___editPostureGameDataPrefab_11; }
	inline void set_editPostureGameDataPrefab_11(EditPostureGameDataUI_t1506665454 * value)
	{
		___editPostureGameDataPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___editPostureGameDataPrefab_11, value);
	}

	inline static int32_t get_offset_of_requestBoolPrefab_12() { return static_cast<int32_t>(offsetof(PostureGameDataFactoryUI_t4105453318, ___requestBoolPrefab_12)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_12() const { return ___requestBoolPrefab_12; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_12() { return &___requestBoolPrefab_12; }
	inline void set_requestBoolPrefab_12(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_12 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_12, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefab_13() { return static_cast<int32_t>(offsetof(PostureGameDataFactoryUI_t4105453318, ___requestEnumPrefab_13)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefab_13() const { return ___requestEnumPrefab_13; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefab_13() { return &___requestEnumPrefab_13; }
	inline void set_requestEnumPrefab_13(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefab_13, value);
	}

	inline static int32_t get_offset_of_gameTypeContainer_14() { return static_cast<int32_t>(offsetof(PostureGameDataFactoryUI_t4105453318, ___gameTypeContainer_14)); }
	inline Transform_t3275118058 * get_gameTypeContainer_14() const { return ___gameTypeContainer_14; }
	inline Transform_t3275118058 ** get_address_of_gameTypeContainer_14() { return &___gameTypeContainer_14; }
	inline void set_gameTypeContainer_14(Transform_t3275118058 * value)
	{
		___gameTypeContainer_14 = value;
		Il2CppCodeGenWriteBarrier(&___gameTypeContainer_14, value);
	}

	inline static int32_t get_offset_of_useRuleContainer_15() { return static_cast<int32_t>(offsetof(PostureGameDataFactoryUI_t4105453318, ___useRuleContainer_15)); }
	inline Transform_t3275118058 * get_useRuleContainer_15() const { return ___useRuleContainer_15; }
	inline Transform_t3275118058 ** get_address_of_useRuleContainer_15() { return &___useRuleContainer_15; }
	inline void set_useRuleContainer_15(Transform_t3275118058 * value)
	{
		___useRuleContainer_15 = value;
		Il2CppCodeGenWriteBarrier(&___useRuleContainer_15, value);
	}

	inline static int32_t get_offset_of_server_16() { return static_cast<int32_t>(offsetof(PostureGameDataFactoryUI_t4105453318, ___server_16)); }
	inline Server_t2724320767 * get_server_16() const { return ___server_16; }
	inline Server_t2724320767 ** get_address_of_server_16() { return &___server_16; }
	inline void set_server_16(Server_t2724320767 * value)
	{
		___server_16 = value;
		Il2CppCodeGenWriteBarrier(&___server_16, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
