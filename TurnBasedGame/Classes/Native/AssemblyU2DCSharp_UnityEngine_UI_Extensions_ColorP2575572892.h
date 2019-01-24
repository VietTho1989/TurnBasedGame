#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.Renderer
struct Renderer_t257310565;
// UnityEngine.UI.Extensions.ColorPicker.ColorPickerControl
struct ColorPickerControl_t3621872136;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ColorPicker.ColorPickerTester
struct  ColorPickerTester_t2575572892  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Renderer UnityEngine.UI.Extensions.ColorPicker.ColorPickerTester::pickerRenderer
	Renderer_t257310565 * ___pickerRenderer_2;
	// UnityEngine.UI.Extensions.ColorPicker.ColorPickerControl UnityEngine.UI.Extensions.ColorPicker.ColorPickerTester::picker
	ColorPickerControl_t3621872136 * ___picker_3;

public:
	inline static int32_t get_offset_of_pickerRenderer_2() { return static_cast<int32_t>(offsetof(ColorPickerTester_t2575572892, ___pickerRenderer_2)); }
	inline Renderer_t257310565 * get_pickerRenderer_2() const { return ___pickerRenderer_2; }
	inline Renderer_t257310565 ** get_address_of_pickerRenderer_2() { return &___pickerRenderer_2; }
	inline void set_pickerRenderer_2(Renderer_t257310565 * value)
	{
		___pickerRenderer_2 = value;
		Il2CppCodeGenWriteBarrier(&___pickerRenderer_2, value);
	}

	inline static int32_t get_offset_of_picker_3() { return static_cast<int32_t>(offsetof(ColorPickerTester_t2575572892, ___picker_3)); }
	inline ColorPickerControl_t3621872136 * get_picker_3() const { return ___picker_3; }
	inline ColorPickerControl_t3621872136 ** get_address_of_picker_3() { return &___picker_3; }
	inline void set_picker_3(ColorPickerControl_t3621872136 * value)
	{
		___picker_3 = value;
		Il2CppCodeGenWriteBarrier(&___picker_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
