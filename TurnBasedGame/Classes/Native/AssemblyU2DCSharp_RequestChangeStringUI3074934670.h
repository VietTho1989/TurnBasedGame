#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen431373227.h"

// UnityEngine.UI.InputField
struct InputField_t1631627530;
// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.UI.ContentSizeFitter
struct ContentSizeFitter_t1325211874;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// TextSettingCheckChange
struct TextSettingCheckChange_t1980666161;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestChangeStringUI
struct  RequestChangeStringUI_t3074934670  : public UIBehavior_1_t431373227
{
public:
	// UnityEngine.UI.InputField RequestChangeStringUI::edtValue
	InputField_t1631627530 * ___edtValue_6;
	// UnityEngine.UI.Text RequestChangeStringUI::txtValue
	Text_t356221433 * ___txtValue_7;
	// UnityEngine.UI.ContentSizeFitter RequestChangeStringUI::contentSizeFilter
	ContentSizeFitter_t1325211874 * ___contentSizeFilter_8;
	// UnityEngine.UI.Text RequestChangeStringUI::tvState
	Text_t356221433 * ___tvState_9;
	// UnityEngine.GameObject RequestChangeStringUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_10;
	// TextSettingCheckChange RequestChangeStringUI::textSettingCheckChange
	TextSettingCheckChange_t1980666161 * ___textSettingCheckChange_11;

public:
	inline static int32_t get_offset_of_edtValue_6() { return static_cast<int32_t>(offsetof(RequestChangeStringUI_t3074934670, ___edtValue_6)); }
	inline InputField_t1631627530 * get_edtValue_6() const { return ___edtValue_6; }
	inline InputField_t1631627530 ** get_address_of_edtValue_6() { return &___edtValue_6; }
	inline void set_edtValue_6(InputField_t1631627530 * value)
	{
		___edtValue_6 = value;
		Il2CppCodeGenWriteBarrier(&___edtValue_6, value);
	}

	inline static int32_t get_offset_of_txtValue_7() { return static_cast<int32_t>(offsetof(RequestChangeStringUI_t3074934670, ___txtValue_7)); }
	inline Text_t356221433 * get_txtValue_7() const { return ___txtValue_7; }
	inline Text_t356221433 ** get_address_of_txtValue_7() { return &___txtValue_7; }
	inline void set_txtValue_7(Text_t356221433 * value)
	{
		___txtValue_7 = value;
		Il2CppCodeGenWriteBarrier(&___txtValue_7, value);
	}

	inline static int32_t get_offset_of_contentSizeFilter_8() { return static_cast<int32_t>(offsetof(RequestChangeStringUI_t3074934670, ___contentSizeFilter_8)); }
	inline ContentSizeFitter_t1325211874 * get_contentSizeFilter_8() const { return ___contentSizeFilter_8; }
	inline ContentSizeFitter_t1325211874 ** get_address_of_contentSizeFilter_8() { return &___contentSizeFilter_8; }
	inline void set_contentSizeFilter_8(ContentSizeFitter_t1325211874 * value)
	{
		___contentSizeFilter_8 = value;
		Il2CppCodeGenWriteBarrier(&___contentSizeFilter_8, value);
	}

	inline static int32_t get_offset_of_tvState_9() { return static_cast<int32_t>(offsetof(RequestChangeStringUI_t3074934670, ___tvState_9)); }
	inline Text_t356221433 * get_tvState_9() const { return ___tvState_9; }
	inline Text_t356221433 ** get_address_of_tvState_9() { return &___tvState_9; }
	inline void set_tvState_9(Text_t356221433 * value)
	{
		___tvState_9 = value;
		Il2CppCodeGenWriteBarrier(&___tvState_9, value);
	}

	inline static int32_t get_offset_of_differentIndicator_10() { return static_cast<int32_t>(offsetof(RequestChangeStringUI_t3074934670, ___differentIndicator_10)); }
	inline GameObject_t1756533147 * get_differentIndicator_10() const { return ___differentIndicator_10; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_10() { return &___differentIndicator_10; }
	inline void set_differentIndicator_10(GameObject_t1756533147 * value)
	{
		___differentIndicator_10 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_10, value);
	}

	inline static int32_t get_offset_of_textSettingCheckChange_11() { return static_cast<int32_t>(offsetof(RequestChangeStringUI_t3074934670, ___textSettingCheckChange_11)); }
	inline TextSettingCheckChange_t1980666161 * get_textSettingCheckChange_11() const { return ___textSettingCheckChange_11; }
	inline TextSettingCheckChange_t1980666161 ** get_address_of_textSettingCheckChange_11() { return &___textSettingCheckChange_11; }
	inline void set_textSettingCheckChange_11(TextSettingCheckChange_t1980666161 * value)
	{
		___textSettingCheckChange_11 = value;
		Il2CppCodeGenWriteBarrier(&___textSettingCheckChange_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
