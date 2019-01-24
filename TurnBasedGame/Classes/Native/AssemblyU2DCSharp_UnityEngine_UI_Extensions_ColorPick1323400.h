#pragma once

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
// UnityEngine.UI.Slider
struct Slider_t297367283;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ColorPicker.ColorSlider
struct  ColorSlider_t1323400  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Extensions.ColorPicker.ColorPickerControl UnityEngine.UI.Extensions.ColorPicker.ColorSlider::ColorPicker
	ColorPickerControl_t3621872136 * ___ColorPicker_2;
	// UnityEngine.UI.Extensions.ColorPicker.ColorValues UnityEngine.UI.Extensions.ColorPicker.ColorSlider::type
	int32_t ___type_3;
	// UnityEngine.UI.Slider UnityEngine.UI.Extensions.ColorPicker.ColorSlider::slider
	Slider_t297367283 * ___slider_4;
	// System.Boolean UnityEngine.UI.Extensions.ColorPicker.ColorSlider::listen
	bool ___listen_5;

public:
	inline static int32_t get_offset_of_ColorPicker_2() { return static_cast<int32_t>(offsetof(ColorSlider_t1323400, ___ColorPicker_2)); }
	inline ColorPickerControl_t3621872136 * get_ColorPicker_2() const { return ___ColorPicker_2; }
	inline ColorPickerControl_t3621872136 ** get_address_of_ColorPicker_2() { return &___ColorPicker_2; }
	inline void set_ColorPicker_2(ColorPickerControl_t3621872136 * value)
	{
		___ColorPicker_2 = value;
		Il2CppCodeGenWriteBarrier(&___ColorPicker_2, value);
	}

	inline static int32_t get_offset_of_type_3() { return static_cast<int32_t>(offsetof(ColorSlider_t1323400, ___type_3)); }
	inline int32_t get_type_3() const { return ___type_3; }
	inline int32_t* get_address_of_type_3() { return &___type_3; }
	inline void set_type_3(int32_t value)
	{
		___type_3 = value;
	}

	inline static int32_t get_offset_of_slider_4() { return static_cast<int32_t>(offsetof(ColorSlider_t1323400, ___slider_4)); }
	inline Slider_t297367283 * get_slider_4() const { return ___slider_4; }
	inline Slider_t297367283 ** get_address_of_slider_4() { return &___slider_4; }
	inline void set_slider_4(Slider_t297367283 * value)
	{
		___slider_4 = value;
		Il2CppCodeGenWriteBarrier(&___slider_4, value);
	}

	inline static int32_t get_offset_of_listen_5() { return static_cast<int32_t>(offsetof(ColorSlider_t1323400, ___listen_5)); }
	inline bool get_listen_5() const { return ___listen_5; }
	inline bool* get_address_of_listen_5() { return &___listen_5; }
	inline void set_listen_5(bool value)
	{
		___listen_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
