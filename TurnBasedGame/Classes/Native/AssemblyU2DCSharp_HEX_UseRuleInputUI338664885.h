#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1738965685.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// HEX.HexGameDataUI/UIData
struct UIData_t3485590849;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.UseRuleInputUI
struct  UseRuleInputUI_t338664885  : public UIBehavior_1_t1738965685
{
public:
	// UnityEngine.GameObject HEX.UseRuleInputUI::switchSideContainer
	GameObject_t1756533147 * ___switchSideContainer_6;
	// UnityEngine.RectTransform HEX.UseRuleInputUI::rectTransform
	RectTransform_t3349966182 * ___rectTransform_7;
	// HEX.HexGameDataUI/UIData HEX.UseRuleInputUI::hexGameDataUIData
	UIData_t3485590849 * ___hexGameDataUIData_8;

public:
	inline static int32_t get_offset_of_switchSideContainer_6() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t338664885, ___switchSideContainer_6)); }
	inline GameObject_t1756533147 * get_switchSideContainer_6() const { return ___switchSideContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_switchSideContainer_6() { return &___switchSideContainer_6; }
	inline void set_switchSideContainer_6(GameObject_t1756533147 * value)
	{
		___switchSideContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___switchSideContainer_6, value);
	}

	inline static int32_t get_offset_of_rectTransform_7() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t338664885, ___rectTransform_7)); }
	inline RectTransform_t3349966182 * get_rectTransform_7() const { return ___rectTransform_7; }
	inline RectTransform_t3349966182 ** get_address_of_rectTransform_7() { return &___rectTransform_7; }
	inline void set_rectTransform_7(RectTransform_t3349966182 * value)
	{
		___rectTransform_7 = value;
		Il2CppCodeGenWriteBarrier(&___rectTransform_7, value);
	}

	inline static int32_t get_offset_of_hexGameDataUIData_8() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t338664885, ___hexGameDataUIData_8)); }
	inline UIData_t3485590849 * get_hexGameDataUIData_8() const { return ___hexGameDataUIData_8; }
	inline UIData_t3485590849 ** get_address_of_hexGameDataUIData_8() { return &___hexGameDataUIData_8; }
	inline void set_hexGameDataUIData_8(UIData_t3485590849 * value)
	{
		___hexGameDataUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___hexGameDataUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
