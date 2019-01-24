#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.Extensions.ColorPicker.ColorPickerControl
struct ColorPickerControl_t3621872136;
// UnityEngine.UI.Extensions.BoxSlider
struct BoxSlider_t3758521666;
// UnityEngine.UI.RawImage
struct RawImage_t2749640213;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ColorPicker.SVBoxSlider
struct  SVBoxSlider_t1950342511  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Extensions.ColorPicker.ColorPickerControl UnityEngine.UI.Extensions.ColorPicker.SVBoxSlider::picker
	ColorPickerControl_t3621872136 * ___picker_2;
	// UnityEngine.UI.Extensions.BoxSlider UnityEngine.UI.Extensions.ColorPicker.SVBoxSlider::slider
	BoxSlider_t3758521666 * ___slider_3;
	// UnityEngine.UI.RawImage UnityEngine.UI.Extensions.ColorPicker.SVBoxSlider::image
	RawImage_t2749640213 * ___image_4;
	// System.Single UnityEngine.UI.Extensions.ColorPicker.SVBoxSlider::lastH
	float ___lastH_5;
	// System.Boolean UnityEngine.UI.Extensions.ColorPicker.SVBoxSlider::listen
	bool ___listen_6;

public:
	inline static int32_t get_offset_of_picker_2() { return static_cast<int32_t>(offsetof(SVBoxSlider_t1950342511, ___picker_2)); }
	inline ColorPickerControl_t3621872136 * get_picker_2() const { return ___picker_2; }
	inline ColorPickerControl_t3621872136 ** get_address_of_picker_2() { return &___picker_2; }
	inline void set_picker_2(ColorPickerControl_t3621872136 * value)
	{
		___picker_2 = value;
		Il2CppCodeGenWriteBarrier(&___picker_2, value);
	}

	inline static int32_t get_offset_of_slider_3() { return static_cast<int32_t>(offsetof(SVBoxSlider_t1950342511, ___slider_3)); }
	inline BoxSlider_t3758521666 * get_slider_3() const { return ___slider_3; }
	inline BoxSlider_t3758521666 ** get_address_of_slider_3() { return &___slider_3; }
	inline void set_slider_3(BoxSlider_t3758521666 * value)
	{
		___slider_3 = value;
		Il2CppCodeGenWriteBarrier(&___slider_3, value);
	}

	inline static int32_t get_offset_of_image_4() { return static_cast<int32_t>(offsetof(SVBoxSlider_t1950342511, ___image_4)); }
	inline RawImage_t2749640213 * get_image_4() const { return ___image_4; }
	inline RawImage_t2749640213 ** get_address_of_image_4() { return &___image_4; }
	inline void set_image_4(RawImage_t2749640213 * value)
	{
		___image_4 = value;
		Il2CppCodeGenWriteBarrier(&___image_4, value);
	}

	inline static int32_t get_offset_of_lastH_5() { return static_cast<int32_t>(offsetof(SVBoxSlider_t1950342511, ___lastH_5)); }
	inline float get_lastH_5() const { return ___lastH_5; }
	inline float* get_address_of_lastH_5() { return &___lastH_5; }
	inline void set_lastH_5(float value)
	{
		___lastH_5 = value;
	}

	inline static int32_t get_offset_of_listen_6() { return static_cast<int32_t>(offsetof(SVBoxSlider_t1950342511, ___listen_6)); }
	inline bool get_listen_6() const { return ___listen_6; }
	inline bool* get_address_of_listen_6() { return &___listen_6; }
	inline void set_listen_6(bool value)
	{
		___listen_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
