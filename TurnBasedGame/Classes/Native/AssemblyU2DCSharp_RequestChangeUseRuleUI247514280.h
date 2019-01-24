#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3797857731.h"

// UnityEngine.UI.Toggle
struct Toggle_t3976754468;
// RequestChangeUseRuleStateNoneUI
struct RequestChangeUseRuleStateNoneUI_t307445893;
// RequestChangeUseRuleStateAskUI
struct RequestChangeUseRuleStateAskUI_t3633552914;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameData
struct GameData_t450274222;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestChangeUseRuleUI
struct  RequestChangeUseRuleUI_t247514280  : public UIBehavior_1_t3797857731
{
public:
	// UnityEngine.UI.Toggle RequestChangeUseRuleUI::tgUseRule
	Toggle_t3976754468 * ___tgUseRule_6;
	// RequestChangeUseRuleStateNoneUI RequestChangeUseRuleUI::nonePrefab
	RequestChangeUseRuleStateNoneUI_t307445893 * ___nonePrefab_7;
	// RequestChangeUseRuleStateAskUI RequestChangeUseRuleUI::askPrefab
	RequestChangeUseRuleStateAskUI_t3633552914 * ___askPrefab_8;
	// UnityEngine.Transform RequestChangeUseRuleUI::subContainer
	Transform_t3275118058 * ___subContainer_9;
	// GameData RequestChangeUseRuleUI::gameData
	GameData_t450274222 * ___gameData_10;

public:
	inline static int32_t get_offset_of_tgUseRule_6() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleUI_t247514280, ___tgUseRule_6)); }
	inline Toggle_t3976754468 * get_tgUseRule_6() const { return ___tgUseRule_6; }
	inline Toggle_t3976754468 ** get_address_of_tgUseRule_6() { return &___tgUseRule_6; }
	inline void set_tgUseRule_6(Toggle_t3976754468 * value)
	{
		___tgUseRule_6 = value;
		Il2CppCodeGenWriteBarrier(&___tgUseRule_6, value);
	}

	inline static int32_t get_offset_of_nonePrefab_7() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleUI_t247514280, ___nonePrefab_7)); }
	inline RequestChangeUseRuleStateNoneUI_t307445893 * get_nonePrefab_7() const { return ___nonePrefab_7; }
	inline RequestChangeUseRuleStateNoneUI_t307445893 ** get_address_of_nonePrefab_7() { return &___nonePrefab_7; }
	inline void set_nonePrefab_7(RequestChangeUseRuleStateNoneUI_t307445893 * value)
	{
		___nonePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___nonePrefab_7, value);
	}

	inline static int32_t get_offset_of_askPrefab_8() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleUI_t247514280, ___askPrefab_8)); }
	inline RequestChangeUseRuleStateAskUI_t3633552914 * get_askPrefab_8() const { return ___askPrefab_8; }
	inline RequestChangeUseRuleStateAskUI_t3633552914 ** get_address_of_askPrefab_8() { return &___askPrefab_8; }
	inline void set_askPrefab_8(RequestChangeUseRuleStateAskUI_t3633552914 * value)
	{
		___askPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___askPrefab_8, value);
	}

	inline static int32_t get_offset_of_subContainer_9() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleUI_t247514280, ___subContainer_9)); }
	inline Transform_t3275118058 * get_subContainer_9() const { return ___subContainer_9; }
	inline Transform_t3275118058 ** get_address_of_subContainer_9() { return &___subContainer_9; }
	inline void set_subContainer_9(Transform_t3275118058 * value)
	{
		___subContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_9, value);
	}

	inline static int32_t get_offset_of_gameData_10() { return static_cast<int32_t>(offsetof(RequestChangeUseRuleUI_t247514280, ___gameData_10)); }
	inline GameData_t450274222 * get_gameData_10() const { return ___gameData_10; }
	inline GameData_t450274222 ** get_address_of_gameData_10() { return &___gameData_10; }
	inline void set_gameData_10(GameData_t450274222 * value)
	{
		___gameData_10 = value;
		Il2CppCodeGenWriteBarrier(&___gameData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
