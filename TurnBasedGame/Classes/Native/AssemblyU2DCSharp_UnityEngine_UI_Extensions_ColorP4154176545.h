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
#include "UnityEngine_UI_UnityEngine_UI_Slider_Direction1525323322.h"

// UnityEngine.UI.Extensions.ColorPicker.ColorPickerControl
struct ColorPickerControl_t3621872136;
// UnityEngine.UI.RawImage
struct RawImage_t2749640213;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ColorPicker.ColorSliderImage
struct  ColorSliderImage_t4154176545  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Extensions.ColorPicker.ColorPickerControl UnityEngine.UI.Extensions.ColorPicker.ColorSliderImage::picker
	ColorPickerControl_t3621872136 * ___picker_2;
	// UnityEngine.UI.Extensions.ColorPicker.ColorValues UnityEngine.UI.Extensions.ColorPicker.ColorSliderImage::type
	int32_t ___type_3;
	// UnityEngine.UI.Slider/Direction UnityEngine.UI.Extensions.ColorPicker.ColorSliderImage::direction
	int32_t ___direction_4;
	// UnityEngine.UI.RawImage UnityEngine.UI.Extensions.ColorPicker.ColorSliderImage::image
	RawImage_t2749640213 * ___image_5;

public:
	inline static int32_t get_offset_of_picker_2() { return static_cast<int32_t>(offsetof(ColorSliderImage_t4154176545, ___picker_2)); }
	inline ColorPickerControl_t3621872136 * get_picker_2() const { return ___picker_2; }
	inline ColorPickerControl_t3621872136 ** get_address_of_picker_2() { return &___picker_2; }
	inline void set_picker_2(ColorPickerControl_t3621872136 * value)
	{
		___picker_2 = value;
		Il2CppCodeGenWriteBarrier(&___picker_2, value);
	}

	inline static int32_t get_offset_of_type_3() { return static_cast<int32_t>(offsetof(ColorSliderImage_t4154176545, ___type_3)); }
	inline int32_t get_type_3() const { return ___type_3; }
	inline int32_t* get_address_of_type_3() { return &___type_3; }
	inline void set_type_3(int32_t value)
	{
		___type_3 = value;
	}

	inline static int32_t get_offset_of_direction_4() { return static_cast<int32_t>(offsetof(ColorSliderImage_t4154176545, ___direction_4)); }
	inline int32_t get_direction_4() const { return ___direction_4; }
	inline int32_t* get_address_of_direction_4() { return &___direction_4; }
	inline void set_direction_4(int32_t value)
	{
		___direction_4 = value;
	}

	inline static int32_t get_offset_of_image_5() { return static_cast<int32_t>(offsetof(ColorSliderImage_t4154176545, ___image_5)); }
	inline RawImage_t2749640213 * get_image_5() const { return ___image_5; }
	inline RawImage_t2749640213 ** get_address_of_image_5() { return &___image_5; }
	inline void set_image_5(RawImage_t2749640213 * value)
	{
		___image_5 = value;
		Il2CppCodeGenWriteBarrier(&___image_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
