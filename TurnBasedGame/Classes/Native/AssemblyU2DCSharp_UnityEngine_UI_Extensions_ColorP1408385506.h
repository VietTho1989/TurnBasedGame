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
// UnityEngine.UI.InputField
struct InputField_t1631627530;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ColorPicker.HexColorField
struct  HexColorField_t1408385506  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Extensions.ColorPicker.ColorPickerControl UnityEngine.UI.Extensions.ColorPicker.HexColorField::ColorPicker
	ColorPickerControl_t3621872136 * ___ColorPicker_2;
	// System.Boolean UnityEngine.UI.Extensions.ColorPicker.HexColorField::displayAlpha
	bool ___displayAlpha_3;
	// UnityEngine.UI.InputField UnityEngine.UI.Extensions.ColorPicker.HexColorField::hexInputField
	InputField_t1631627530 * ___hexInputField_4;

public:
	inline static int32_t get_offset_of_ColorPicker_2() { return static_cast<int32_t>(offsetof(HexColorField_t1408385506, ___ColorPicker_2)); }
	inline ColorPickerControl_t3621872136 * get_ColorPicker_2() const { return ___ColorPicker_2; }
	inline ColorPickerControl_t3621872136 ** get_address_of_ColorPicker_2() { return &___ColorPicker_2; }
	inline void set_ColorPicker_2(ColorPickerControl_t3621872136 * value)
	{
		___ColorPicker_2 = value;
		Il2CppCodeGenWriteBarrier(&___ColorPicker_2, value);
	}

	inline static int32_t get_offset_of_displayAlpha_3() { return static_cast<int32_t>(offsetof(HexColorField_t1408385506, ___displayAlpha_3)); }
	inline bool get_displayAlpha_3() const { return ___displayAlpha_3; }
	inline bool* get_address_of_displayAlpha_3() { return &___displayAlpha_3; }
	inline void set_displayAlpha_3(bool value)
	{
		___displayAlpha_3 = value;
	}

	inline static int32_t get_offset_of_hexInputField_4() { return static_cast<int32_t>(offsetof(HexColorField_t1408385506, ___hexInputField_4)); }
	inline InputField_t1631627530 * get_hexInputField_4() const { return ___hexInputField_4; }
	inline InputField_t1631627530 ** get_address_of_hexInputField_4() { return &___hexInputField_4; }
	inline void set_hexInputField_4(InputField_t1631627530 * value)
	{
		___hexInputField_4 = value;
		Il2CppCodeGenWriteBarrier(&___hexInputField_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
