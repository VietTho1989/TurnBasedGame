#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.String
struct String_t;
// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.UI.Slider
struct Slider_t297367283;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.SliderLabel
struct  SliderLabel_t3791105713  : public MonoBehaviour_t1158329972
{
public:
	// System.String Foundation.Databinding.SliderLabel::FormatString
	String_t* ___FormatString_2;
	// System.Boolean Foundation.Databinding.SliderLabel::IsInit
	bool ___IsInit_3;
	// UnityEngine.UI.Text Foundation.Databinding.SliderLabel::Label
	Text_t356221433 * ___Label_4;
	// System.Boolean Foundation.Databinding.SliderLabel::MakeInt
	bool ___MakeInt_5;
	// UnityEngine.UI.Slider Foundation.Databinding.SliderLabel::MySlider
	Slider_t297367283 * ___MySlider_6;

public:
	inline static int32_t get_offset_of_FormatString_2() { return static_cast<int32_t>(offsetof(SliderLabel_t3791105713, ___FormatString_2)); }
	inline String_t* get_FormatString_2() const { return ___FormatString_2; }
	inline String_t** get_address_of_FormatString_2() { return &___FormatString_2; }
	inline void set_FormatString_2(String_t* value)
	{
		___FormatString_2 = value;
		Il2CppCodeGenWriteBarrier(&___FormatString_2, value);
	}

	inline static int32_t get_offset_of_IsInit_3() { return static_cast<int32_t>(offsetof(SliderLabel_t3791105713, ___IsInit_3)); }
	inline bool get_IsInit_3() const { return ___IsInit_3; }
	inline bool* get_address_of_IsInit_3() { return &___IsInit_3; }
	inline void set_IsInit_3(bool value)
	{
		___IsInit_3 = value;
	}

	inline static int32_t get_offset_of_Label_4() { return static_cast<int32_t>(offsetof(SliderLabel_t3791105713, ___Label_4)); }
	inline Text_t356221433 * get_Label_4() const { return ___Label_4; }
	inline Text_t356221433 ** get_address_of_Label_4() { return &___Label_4; }
	inline void set_Label_4(Text_t356221433 * value)
	{
		___Label_4 = value;
		Il2CppCodeGenWriteBarrier(&___Label_4, value);
	}

	inline static int32_t get_offset_of_MakeInt_5() { return static_cast<int32_t>(offsetof(SliderLabel_t3791105713, ___MakeInt_5)); }
	inline bool get_MakeInt_5() const { return ___MakeInt_5; }
	inline bool* get_address_of_MakeInt_5() { return &___MakeInt_5; }
	inline void set_MakeInt_5(bool value)
	{
		___MakeInt_5 = value;
	}

	inline static int32_t get_offset_of_MySlider_6() { return static_cast<int32_t>(offsetof(SliderLabel_t3791105713, ___MySlider_6)); }
	inline Slider_t297367283 * get_MySlider_6() const { return ___MySlider_6; }
	inline Slider_t297367283 ** get_address_of_MySlider_6() { return &___MySlider_6; }
	inline void set_MySlider_6(Slider_t297367283 * value)
	{
		___MySlider_6 = value;
		Il2CppCodeGenWriteBarrier(&___MySlider_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
