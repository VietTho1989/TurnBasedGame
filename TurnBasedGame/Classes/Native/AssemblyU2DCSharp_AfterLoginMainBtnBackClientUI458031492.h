#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen797051979.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// ConfirmBackClientUI
struct ConfirmBackClientUI_t372218626;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AfterLoginMainBtnBackClientUI
struct  AfterLoginMainBtnBackClientUI_t458031492  : public UIBehavior_1_t797051979
{
public:
	// UnityEngine.UI.Button AfterLoginMainBtnBackClientUI::btnLogOut
	Button_t2872111280 * ___btnLogOut_6;
	// UnityEngine.UI.Text AfterLoginMainBtnBackClientUI::tvState
	Text_t356221433 * ___tvState_7;
	// ConfirmBackClientUI AfterLoginMainBtnBackClientUI::confirmBackPrefab
	ConfirmBackClientUI_t372218626 * ___confirmBackPrefab_8;
	// UnityEngine.Transform AfterLoginMainBtnBackClientUI::confirmBackContainer
	Transform_t3275118058 * ___confirmBackContainer_9;

public:
	inline static int32_t get_offset_of_btnLogOut_6() { return static_cast<int32_t>(offsetof(AfterLoginMainBtnBackClientUI_t458031492, ___btnLogOut_6)); }
	inline Button_t2872111280 * get_btnLogOut_6() const { return ___btnLogOut_6; }
	inline Button_t2872111280 ** get_address_of_btnLogOut_6() { return &___btnLogOut_6; }
	inline void set_btnLogOut_6(Button_t2872111280 * value)
	{
		___btnLogOut_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnLogOut_6, value);
	}

	inline static int32_t get_offset_of_tvState_7() { return static_cast<int32_t>(offsetof(AfterLoginMainBtnBackClientUI_t458031492, ___tvState_7)); }
	inline Text_t356221433 * get_tvState_7() const { return ___tvState_7; }
	inline Text_t356221433 ** get_address_of_tvState_7() { return &___tvState_7; }
	inline void set_tvState_7(Text_t356221433 * value)
	{
		___tvState_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvState_7, value);
	}

	inline static int32_t get_offset_of_confirmBackPrefab_8() { return static_cast<int32_t>(offsetof(AfterLoginMainBtnBackClientUI_t458031492, ___confirmBackPrefab_8)); }
	inline ConfirmBackClientUI_t372218626 * get_confirmBackPrefab_8() const { return ___confirmBackPrefab_8; }
	inline ConfirmBackClientUI_t372218626 ** get_address_of_confirmBackPrefab_8() { return &___confirmBackPrefab_8; }
	inline void set_confirmBackPrefab_8(ConfirmBackClientUI_t372218626 * value)
	{
		___confirmBackPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___confirmBackPrefab_8, value);
	}

	inline static int32_t get_offset_of_confirmBackContainer_9() { return static_cast<int32_t>(offsetof(AfterLoginMainBtnBackClientUI_t458031492, ___confirmBackContainer_9)); }
	inline Transform_t3275118058 * get_confirmBackContainer_9() const { return ___confirmBackContainer_9; }
	inline Transform_t3275118058 ** get_address_of_confirmBackContainer_9() { return &___confirmBackContainer_9; }
	inline void set_confirmBackContainer_9(Transform_t3275118058 * value)
	{
		___confirmBackContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___confirmBackContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
