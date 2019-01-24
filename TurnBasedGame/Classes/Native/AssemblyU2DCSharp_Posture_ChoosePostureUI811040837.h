#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4153737638.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.UI.Image
struct Image_t2042527209;
// Posture.ChoosePostureAdapter
struct ChoosePostureAdapter_t1026141852;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Posture.ChoosePostureUI
struct  ChoosePostureUI_t811040837  : public UIBehavior_1_t4153737638
{
public:
	// UnityEngine.UI.Text Posture.ChoosePostureUI::tvState
	Text_t356221433 * ___tvState_6;
	// UnityEngine.UI.Image Posture.ChoosePostureUI::bgState
	Image_t2042527209 * ___bgState_7;
	// Posture.ChoosePostureAdapter Posture.ChoosePostureUI::adapterPrefab
	ChoosePostureAdapter_t1026141852 * ___adapterPrefab_8;
	// UnityEngine.Transform Posture.ChoosePostureUI::adapterContainer
	Transform_t3275118058 * ___adapterContainer_9;

public:
	inline static int32_t get_offset_of_tvState_6() { return static_cast<int32_t>(offsetof(ChoosePostureUI_t811040837, ___tvState_6)); }
	inline Text_t356221433 * get_tvState_6() const { return ___tvState_6; }
	inline Text_t356221433 ** get_address_of_tvState_6() { return &___tvState_6; }
	inline void set_tvState_6(Text_t356221433 * value)
	{
		___tvState_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvState_6, value);
	}

	inline static int32_t get_offset_of_bgState_7() { return static_cast<int32_t>(offsetof(ChoosePostureUI_t811040837, ___bgState_7)); }
	inline Image_t2042527209 * get_bgState_7() const { return ___bgState_7; }
	inline Image_t2042527209 ** get_address_of_bgState_7() { return &___bgState_7; }
	inline void set_bgState_7(Image_t2042527209 * value)
	{
		___bgState_7 = value;
		Il2CppCodeGenWriteBarrier(&___bgState_7, value);
	}

	inline static int32_t get_offset_of_adapterPrefab_8() { return static_cast<int32_t>(offsetof(ChoosePostureUI_t811040837, ___adapterPrefab_8)); }
	inline ChoosePostureAdapter_t1026141852 * get_adapterPrefab_8() const { return ___adapterPrefab_8; }
	inline ChoosePostureAdapter_t1026141852 ** get_address_of_adapterPrefab_8() { return &___adapterPrefab_8; }
	inline void set_adapterPrefab_8(ChoosePostureAdapter_t1026141852 * value)
	{
		___adapterPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___adapterPrefab_8, value);
	}

	inline static int32_t get_offset_of_adapterContainer_9() { return static_cast<int32_t>(offsetof(ChoosePostureUI_t811040837, ___adapterContainer_9)); }
	inline Transform_t3275118058 * get_adapterContainer_9() const { return ___adapterContainer_9; }
	inline Transform_t3275118058 ** get_address_of_adapterContainer_9() { return &___adapterContainer_9; }
	inline void set_adapterContainer_9(Transform_t3275118058 * value)
	{
		___adapterContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___adapterContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
