#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1974097688.h"

// UnityEngine.UI.InputField
struct InputField_t1631627530;
// UnityEngine.UI.Slider
struct Slider_t297367283;
// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestChangeLongUI
struct  RequestChangeLongUI_t921704931  : public UIBehavior_1_t1974097688
{
public:
	// UnityEngine.UI.InputField RequestChangeLongUI::edtValue
	InputField_t1631627530 * ___edtValue_6;
	// UnityEngine.UI.Slider RequestChangeLongUI::sliderValue
	Slider_t297367283 * ___sliderValue_7;
	// UnityEngine.UI.Text RequestChangeLongUI::tvState
	Text_t356221433 * ___tvState_8;
	// UnityEngine.GameObject RequestChangeLongUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_9;

public:
	inline static int32_t get_offset_of_edtValue_6() { return static_cast<int32_t>(offsetof(RequestChangeLongUI_t921704931, ___edtValue_6)); }
	inline InputField_t1631627530 * get_edtValue_6() const { return ___edtValue_6; }
	inline InputField_t1631627530 ** get_address_of_edtValue_6() { return &___edtValue_6; }
	inline void set_edtValue_6(InputField_t1631627530 * value)
	{
		___edtValue_6 = value;
		Il2CppCodeGenWriteBarrier(&___edtValue_6, value);
	}

	inline static int32_t get_offset_of_sliderValue_7() { return static_cast<int32_t>(offsetof(RequestChangeLongUI_t921704931, ___sliderValue_7)); }
	inline Slider_t297367283 * get_sliderValue_7() const { return ___sliderValue_7; }
	inline Slider_t297367283 ** get_address_of_sliderValue_7() { return &___sliderValue_7; }
	inline void set_sliderValue_7(Slider_t297367283 * value)
	{
		___sliderValue_7 = value;
		Il2CppCodeGenWriteBarrier(&___sliderValue_7, value);
	}

	inline static int32_t get_offset_of_tvState_8() { return static_cast<int32_t>(offsetof(RequestChangeLongUI_t921704931, ___tvState_8)); }
	inline Text_t356221433 * get_tvState_8() const { return ___tvState_8; }
	inline Text_t356221433 ** get_address_of_tvState_8() { return &___tvState_8; }
	inline void set_tvState_8(Text_t356221433 * value)
	{
		___tvState_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvState_8, value);
	}

	inline static int32_t get_offset_of_differentIndicator_9() { return static_cast<int32_t>(offsetof(RequestChangeLongUI_t921704931, ___differentIndicator_9)); }
	inline GameObject_t1756533147 * get_differentIndicator_9() const { return ___differentIndicator_9; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_9() { return &___differentIndicator_9; }
	inline void set_differentIndicator_9(GameObject_t1756533147 * value)
	{
		___differentIndicator_9 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
