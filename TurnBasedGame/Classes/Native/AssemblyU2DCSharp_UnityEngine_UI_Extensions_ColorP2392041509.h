﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_ColorP3669995107.h"

// UnityEngine.UI.Extensions.ColorPicker.ColorPickerControl
struct ColorPickerControl_t3621872136;
// System.String
struct String_t;
// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ColorPicker.ColorLabel
struct  ColorLabel_t2392041509  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Extensions.ColorPicker.ColorPickerControl UnityEngine.UI.Extensions.ColorPicker.ColorLabel::picker
	ColorPickerControl_t3621872136 * ___picker_2;
	// UnityEngine.UI.Extensions.ColorPicker.ColorValues UnityEngine.UI.Extensions.ColorPicker.ColorLabel::type
	int32_t ___type_3;
	// System.String UnityEngine.UI.Extensions.ColorPicker.ColorLabel::prefix
	String_t* ___prefix_4;
	// System.Single UnityEngine.UI.Extensions.ColorPicker.ColorLabel::minValue
	float ___minValue_5;
	// System.Single UnityEngine.UI.Extensions.ColorPicker.ColorLabel::maxValue
	float ___maxValue_6;
	// System.Int32 UnityEngine.UI.Extensions.ColorPicker.ColorLabel::precision
	int32_t ___precision_7;
	// UnityEngine.UI.Text UnityEngine.UI.Extensions.ColorPicker.ColorLabel::label
	Text_t356221433 * ___label_8;

public:
	inline static int32_t get_offset_of_picker_2() { return static_cast<int32_t>(offsetof(ColorLabel_t2392041509, ___picker_2)); }
	inline ColorPickerControl_t3621872136 * get_picker_2() const { return ___picker_2; }
	inline ColorPickerControl_t3621872136 ** get_address_of_picker_2() { return &___picker_2; }
	inline void set_picker_2(ColorPickerControl_t3621872136 * value)
	{
		___picker_2 = value;
		Il2CppCodeGenWriteBarrier(&___picker_2, value);
	}

	inline static int32_t get_offset_of_type_3() { return static_cast<int32_t>(offsetof(ColorLabel_t2392041509, ___type_3)); }
	inline int32_t get_type_3() const { return ___type_3; }
	inline int32_t* get_address_of_type_3() { return &___type_3; }
	inline void set_type_3(int32_t value)
	{
		___type_3 = value;
	}

	inline static int32_t get_offset_of_prefix_4() { return static_cast<int32_t>(offsetof(ColorLabel_t2392041509, ___prefix_4)); }
	inline String_t* get_prefix_4() const { return ___prefix_4; }
	inline String_t** get_address_of_prefix_4() { return &___prefix_4; }
	inline void set_prefix_4(String_t* value)
	{
		___prefix_4 = value;
		Il2CppCodeGenWriteBarrier(&___prefix_4, value);
	}

	inline static int32_t get_offset_of_minValue_5() { return static_cast<int32_t>(offsetof(ColorLabel_t2392041509, ___minValue_5)); }
	inline float get_minValue_5() const { return ___minValue_5; }
	inline float* get_address_of_minValue_5() { return &___minValue_5; }
	inline void set_minValue_5(float value)
	{
		___minValue_5 = value;
	}

	inline static int32_t get_offset_of_maxValue_6() { return static_cast<int32_t>(offsetof(ColorLabel_t2392041509, ___maxValue_6)); }
	inline float get_maxValue_6() const { return ___maxValue_6; }
	inline float* get_address_of_maxValue_6() { return &___maxValue_6; }
	inline void set_maxValue_6(float value)
	{
		___maxValue_6 = value;
	}

	inline static int32_t get_offset_of_precision_7() { return static_cast<int32_t>(offsetof(ColorLabel_t2392041509, ___precision_7)); }
	inline int32_t get_precision_7() const { return ___precision_7; }
	inline int32_t* get_address_of_precision_7() { return &___precision_7; }
	inline void set_precision_7(int32_t value)
	{
		___precision_7 = value;
	}

	inline static int32_t get_offset_of_label_8() { return static_cast<int32_t>(offsetof(ColorLabel_t2392041509, ___label_8)); }
	inline Text_t356221433 * get_label_8() const { return ___label_8; }
	inline Text_t356221433 ** get_address_of_label_8() { return &___label_8; }
	inline void set_label_8(Text_t356221433 * value)
	{
		___label_8 = value;
		Il2CppCodeGenWriteBarrier(&___label_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
