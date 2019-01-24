#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.PointerScaleTween
struct  PointerScaleTween_t3089391554  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Button Foundation.Databinding.PointerScaleTween::Button
	Button_t2872111280 * ___Button_2;
	// System.Single Foundation.Databinding.PointerScaleTween::DownScale
	float ___DownScale_3;
	// System.Single Foundation.Databinding.PointerScaleTween::HoverScale
	float ___HoverScale_4;
	// System.Boolean Foundation.Databinding.PointerScaleTween::IsDown
	bool ___IsDown_5;
	// System.Boolean Foundation.Databinding.PointerScaleTween::IsOver
	bool ___IsOver_6;
	// System.Single Foundation.Databinding.PointerScaleTween::NormalScale
	float ___NormalScale_7;
	// UnityEngine.RectTransform Foundation.Databinding.PointerScaleTween::Transform
	RectTransform_t3349966182 * ___Transform_8;
	// System.Single Foundation.Databinding.PointerScaleTween::TweenTime
	float ___TweenTime_9;

public:
	inline static int32_t get_offset_of_Button_2() { return static_cast<int32_t>(offsetof(PointerScaleTween_t3089391554, ___Button_2)); }
	inline Button_t2872111280 * get_Button_2() const { return ___Button_2; }
	inline Button_t2872111280 ** get_address_of_Button_2() { return &___Button_2; }
	inline void set_Button_2(Button_t2872111280 * value)
	{
		___Button_2 = value;
		Il2CppCodeGenWriteBarrier(&___Button_2, value);
	}

	inline static int32_t get_offset_of_DownScale_3() { return static_cast<int32_t>(offsetof(PointerScaleTween_t3089391554, ___DownScale_3)); }
	inline float get_DownScale_3() const { return ___DownScale_3; }
	inline float* get_address_of_DownScale_3() { return &___DownScale_3; }
	inline void set_DownScale_3(float value)
	{
		___DownScale_3 = value;
	}

	inline static int32_t get_offset_of_HoverScale_4() { return static_cast<int32_t>(offsetof(PointerScaleTween_t3089391554, ___HoverScale_4)); }
	inline float get_HoverScale_4() const { return ___HoverScale_4; }
	inline float* get_address_of_HoverScale_4() { return &___HoverScale_4; }
	inline void set_HoverScale_4(float value)
	{
		___HoverScale_4 = value;
	}

	inline static int32_t get_offset_of_IsDown_5() { return static_cast<int32_t>(offsetof(PointerScaleTween_t3089391554, ___IsDown_5)); }
	inline bool get_IsDown_5() const { return ___IsDown_5; }
	inline bool* get_address_of_IsDown_5() { return &___IsDown_5; }
	inline void set_IsDown_5(bool value)
	{
		___IsDown_5 = value;
	}

	inline static int32_t get_offset_of_IsOver_6() { return static_cast<int32_t>(offsetof(PointerScaleTween_t3089391554, ___IsOver_6)); }
	inline bool get_IsOver_6() const { return ___IsOver_6; }
	inline bool* get_address_of_IsOver_6() { return &___IsOver_6; }
	inline void set_IsOver_6(bool value)
	{
		___IsOver_6 = value;
	}

	inline static int32_t get_offset_of_NormalScale_7() { return static_cast<int32_t>(offsetof(PointerScaleTween_t3089391554, ___NormalScale_7)); }
	inline float get_NormalScale_7() const { return ___NormalScale_7; }
	inline float* get_address_of_NormalScale_7() { return &___NormalScale_7; }
	inline void set_NormalScale_7(float value)
	{
		___NormalScale_7 = value;
	}

	inline static int32_t get_offset_of_Transform_8() { return static_cast<int32_t>(offsetof(PointerScaleTween_t3089391554, ___Transform_8)); }
	inline RectTransform_t3349966182 * get_Transform_8() const { return ___Transform_8; }
	inline RectTransform_t3349966182 ** get_address_of_Transform_8() { return &___Transform_8; }
	inline void set_Transform_8(RectTransform_t3349966182 * value)
	{
		___Transform_8 = value;
		Il2CppCodeGenWriteBarrier(&___Transform_8, value);
	}

	inline static int32_t get_offset_of_TweenTime_9() { return static_cast<int32_t>(offsetof(PointerScaleTween_t3089391554, ___TweenTime_9)); }
	inline float get_TweenTime_9() const { return ___TweenTime_9; }
	inline float* get_address_of_TweenTime_9() { return &___TweenTime_9; }
	inline void set_TweenTime_9(float value)
	{
		___TweenTime_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
