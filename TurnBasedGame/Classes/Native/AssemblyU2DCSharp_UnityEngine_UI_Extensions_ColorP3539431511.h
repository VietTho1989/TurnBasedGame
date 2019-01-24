﻿#pragma once

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
// UnityEngine.GameObject[]
struct GameObjectU5BU5D_t3057952154;
// UnityEngine.UI.Image
struct Image_t2042527209;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ColorPicker.ColorPickerPresets
struct  ColorPickerPresets_t3539431511  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Extensions.ColorPicker.ColorPickerControl UnityEngine.UI.Extensions.ColorPicker.ColorPickerPresets::picker
	ColorPickerControl_t3621872136 * ___picker_2;
	// UnityEngine.GameObject[] UnityEngine.UI.Extensions.ColorPicker.ColorPickerPresets::presets
	GameObjectU5BU5D_t3057952154* ___presets_3;
	// UnityEngine.UI.Image UnityEngine.UI.Extensions.ColorPicker.ColorPickerPresets::createPresetImage
	Image_t2042527209 * ___createPresetImage_4;

public:
	inline static int32_t get_offset_of_picker_2() { return static_cast<int32_t>(offsetof(ColorPickerPresets_t3539431511, ___picker_2)); }
	inline ColorPickerControl_t3621872136 * get_picker_2() const { return ___picker_2; }
	inline ColorPickerControl_t3621872136 ** get_address_of_picker_2() { return &___picker_2; }
	inline void set_picker_2(ColorPickerControl_t3621872136 * value)
	{
		___picker_2 = value;
		Il2CppCodeGenWriteBarrier(&___picker_2, value);
	}

	inline static int32_t get_offset_of_presets_3() { return static_cast<int32_t>(offsetof(ColorPickerPresets_t3539431511, ___presets_3)); }
	inline GameObjectU5BU5D_t3057952154* get_presets_3() const { return ___presets_3; }
	inline GameObjectU5BU5D_t3057952154** get_address_of_presets_3() { return &___presets_3; }
	inline void set_presets_3(GameObjectU5BU5D_t3057952154* value)
	{
		___presets_3 = value;
		Il2CppCodeGenWriteBarrier(&___presets_3, value);
	}

	inline static int32_t get_offset_of_createPresetImage_4() { return static_cast<int32_t>(offsetof(ColorPickerPresets_t3539431511, ___createPresetImage_4)); }
	inline Image_t2042527209 * get_createPresetImage_4() const { return ___createPresetImage_4; }
	inline Image_t2042527209 ** get_address_of_createPresetImage_4() { return &___createPresetImage_4; }
	inline void set_createPresetImage_4(Image_t2042527209 * value)
	{
		___createPresetImage_4 = value;
		Il2CppCodeGenWriteBarrier(&___createPresetImage_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
