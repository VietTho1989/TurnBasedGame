#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_RenderMode4280533217.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.Camera
struct Camera_t189460977;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ToolTip
struct  ToolTip_t1538012217  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Text UnityEngine.UI.Extensions.ToolTip::_text
	Text_t356221433 * ____text_2;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ToolTip::_rectTransform
	RectTransform_t3349966182 * ____rectTransform_3;
	// System.Boolean UnityEngine.UI.Extensions.ToolTip::_inside
	bool ____inside_4;
	// System.Single UnityEngine.UI.Extensions.ToolTip::width
	float ___width_5;
	// System.Single UnityEngine.UI.Extensions.ToolTip::height
	float ___height_6;
	// System.Single UnityEngine.UI.Extensions.ToolTip::YShift
	float ___YShift_7;
	// System.Single UnityEngine.UI.Extensions.ToolTip::xShift
	float ___xShift_8;
	// UnityEngine.RenderMode UnityEngine.UI.Extensions.ToolTip::_guiMode
	int32_t ____guiMode_9;
	// UnityEngine.Camera UnityEngine.UI.Extensions.ToolTip::_guiCamera
	Camera_t189460977 * ____guiCamera_10;

public:
	inline static int32_t get_offset_of__text_2() { return static_cast<int32_t>(offsetof(ToolTip_t1538012217, ____text_2)); }
	inline Text_t356221433 * get__text_2() const { return ____text_2; }
	inline Text_t356221433 ** get_address_of__text_2() { return &____text_2; }
	inline void set__text_2(Text_t356221433 * value)
	{
		____text_2 = value;
		Il2CppCodeGenWriteBarrier(&____text_2, value);
	}

	inline static int32_t get_offset_of__rectTransform_3() { return static_cast<int32_t>(offsetof(ToolTip_t1538012217, ____rectTransform_3)); }
	inline RectTransform_t3349966182 * get__rectTransform_3() const { return ____rectTransform_3; }
	inline RectTransform_t3349966182 ** get_address_of__rectTransform_3() { return &____rectTransform_3; }
	inline void set__rectTransform_3(RectTransform_t3349966182 * value)
	{
		____rectTransform_3 = value;
		Il2CppCodeGenWriteBarrier(&____rectTransform_3, value);
	}

	inline static int32_t get_offset_of__inside_4() { return static_cast<int32_t>(offsetof(ToolTip_t1538012217, ____inside_4)); }
	inline bool get__inside_4() const { return ____inside_4; }
	inline bool* get_address_of__inside_4() { return &____inside_4; }
	inline void set__inside_4(bool value)
	{
		____inside_4 = value;
	}

	inline static int32_t get_offset_of_width_5() { return static_cast<int32_t>(offsetof(ToolTip_t1538012217, ___width_5)); }
	inline float get_width_5() const { return ___width_5; }
	inline float* get_address_of_width_5() { return &___width_5; }
	inline void set_width_5(float value)
	{
		___width_5 = value;
	}

	inline static int32_t get_offset_of_height_6() { return static_cast<int32_t>(offsetof(ToolTip_t1538012217, ___height_6)); }
	inline float get_height_6() const { return ___height_6; }
	inline float* get_address_of_height_6() { return &___height_6; }
	inline void set_height_6(float value)
	{
		___height_6 = value;
	}

	inline static int32_t get_offset_of_YShift_7() { return static_cast<int32_t>(offsetof(ToolTip_t1538012217, ___YShift_7)); }
	inline float get_YShift_7() const { return ___YShift_7; }
	inline float* get_address_of_YShift_7() { return &___YShift_7; }
	inline void set_YShift_7(float value)
	{
		___YShift_7 = value;
	}

	inline static int32_t get_offset_of_xShift_8() { return static_cast<int32_t>(offsetof(ToolTip_t1538012217, ___xShift_8)); }
	inline float get_xShift_8() const { return ___xShift_8; }
	inline float* get_address_of_xShift_8() { return &___xShift_8; }
	inline void set_xShift_8(float value)
	{
		___xShift_8 = value;
	}

	inline static int32_t get_offset_of__guiMode_9() { return static_cast<int32_t>(offsetof(ToolTip_t1538012217, ____guiMode_9)); }
	inline int32_t get__guiMode_9() const { return ____guiMode_9; }
	inline int32_t* get_address_of__guiMode_9() { return &____guiMode_9; }
	inline void set__guiMode_9(int32_t value)
	{
		____guiMode_9 = value;
	}

	inline static int32_t get_offset_of__guiCamera_10() { return static_cast<int32_t>(offsetof(ToolTip_t1538012217, ____guiCamera_10)); }
	inline Camera_t189460977 * get__guiCamera_10() const { return ____guiCamera_10; }
	inline Camera_t189460977 ** get_address_of__guiCamera_10() { return &____guiCamera_10; }
	inline void set__guiCamera_10(Camera_t189460977 * value)
	{
		____guiCamera_10 = value;
		Il2CppCodeGenWriteBarrier(&____guiCamera_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
