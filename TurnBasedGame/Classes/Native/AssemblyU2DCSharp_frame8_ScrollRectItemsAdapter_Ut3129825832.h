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
// frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick/UnityFloatEvent
struct UnityFloatEvent_t3532842099;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick/ISizeChangesHandler
struct ISizeChangesHandler_t3584512361;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick
struct  ExpandCollapseOnClick_t3129825832  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Button frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick::button
	Button_t2872111280 * ___button_2;
	// System.Single frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick::expandFactor
	float ___expandFactor_3;
	// System.Single frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick::animDuration
	float ___animDuration_4;
	// System.Single frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick::nonExpandedSize
	float ___nonExpandedSize_5;
	// System.Boolean frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick::expanded
	bool ___expanded_6;
	// frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick/UnityFloatEvent frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick::onExpandAmounChanged
	UnityFloatEvent_t3532842099 * ___onExpandAmounChanged_7;
	// System.Single frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick::startSize
	float ___startSize_8;
	// System.Single frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick::endSize
	float ___endSize_9;
	// System.Single frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick::animStart
	float ___animStart_10;
	// System.Boolean frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick::animating
	bool ___animating_11;
	// UnityEngine.RectTransform frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick::rectTransform
	RectTransform_t3349966182 * ___rectTransform_12;
	// frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick/ISizeChangesHandler frame8.ScrollRectItemsAdapter.Util.ExpandCollapseOnClick::sizeChangesHandler
	Il2CppObject * ___sizeChangesHandler_13;

public:
	inline static int32_t get_offset_of_button_2() { return static_cast<int32_t>(offsetof(ExpandCollapseOnClick_t3129825832, ___button_2)); }
	inline Button_t2872111280 * get_button_2() const { return ___button_2; }
	inline Button_t2872111280 ** get_address_of_button_2() { return &___button_2; }
	inline void set_button_2(Button_t2872111280 * value)
	{
		___button_2 = value;
		Il2CppCodeGenWriteBarrier(&___button_2, value);
	}

	inline static int32_t get_offset_of_expandFactor_3() { return static_cast<int32_t>(offsetof(ExpandCollapseOnClick_t3129825832, ___expandFactor_3)); }
	inline float get_expandFactor_3() const { return ___expandFactor_3; }
	inline float* get_address_of_expandFactor_3() { return &___expandFactor_3; }
	inline void set_expandFactor_3(float value)
	{
		___expandFactor_3 = value;
	}

	inline static int32_t get_offset_of_animDuration_4() { return static_cast<int32_t>(offsetof(ExpandCollapseOnClick_t3129825832, ___animDuration_4)); }
	inline float get_animDuration_4() const { return ___animDuration_4; }
	inline float* get_address_of_animDuration_4() { return &___animDuration_4; }
	inline void set_animDuration_4(float value)
	{
		___animDuration_4 = value;
	}

	inline static int32_t get_offset_of_nonExpandedSize_5() { return static_cast<int32_t>(offsetof(ExpandCollapseOnClick_t3129825832, ___nonExpandedSize_5)); }
	inline float get_nonExpandedSize_5() const { return ___nonExpandedSize_5; }
	inline float* get_address_of_nonExpandedSize_5() { return &___nonExpandedSize_5; }
	inline void set_nonExpandedSize_5(float value)
	{
		___nonExpandedSize_5 = value;
	}

	inline static int32_t get_offset_of_expanded_6() { return static_cast<int32_t>(offsetof(ExpandCollapseOnClick_t3129825832, ___expanded_6)); }
	inline bool get_expanded_6() const { return ___expanded_6; }
	inline bool* get_address_of_expanded_6() { return &___expanded_6; }
	inline void set_expanded_6(bool value)
	{
		___expanded_6 = value;
	}

	inline static int32_t get_offset_of_onExpandAmounChanged_7() { return static_cast<int32_t>(offsetof(ExpandCollapseOnClick_t3129825832, ___onExpandAmounChanged_7)); }
	inline UnityFloatEvent_t3532842099 * get_onExpandAmounChanged_7() const { return ___onExpandAmounChanged_7; }
	inline UnityFloatEvent_t3532842099 ** get_address_of_onExpandAmounChanged_7() { return &___onExpandAmounChanged_7; }
	inline void set_onExpandAmounChanged_7(UnityFloatEvent_t3532842099 * value)
	{
		___onExpandAmounChanged_7 = value;
		Il2CppCodeGenWriteBarrier(&___onExpandAmounChanged_7, value);
	}

	inline static int32_t get_offset_of_startSize_8() { return static_cast<int32_t>(offsetof(ExpandCollapseOnClick_t3129825832, ___startSize_8)); }
	inline float get_startSize_8() const { return ___startSize_8; }
	inline float* get_address_of_startSize_8() { return &___startSize_8; }
	inline void set_startSize_8(float value)
	{
		___startSize_8 = value;
	}

	inline static int32_t get_offset_of_endSize_9() { return static_cast<int32_t>(offsetof(ExpandCollapseOnClick_t3129825832, ___endSize_9)); }
	inline float get_endSize_9() const { return ___endSize_9; }
	inline float* get_address_of_endSize_9() { return &___endSize_9; }
	inline void set_endSize_9(float value)
	{
		___endSize_9 = value;
	}

	inline static int32_t get_offset_of_animStart_10() { return static_cast<int32_t>(offsetof(ExpandCollapseOnClick_t3129825832, ___animStart_10)); }
	inline float get_animStart_10() const { return ___animStart_10; }
	inline float* get_address_of_animStart_10() { return &___animStart_10; }
	inline void set_animStart_10(float value)
	{
		___animStart_10 = value;
	}

	inline static int32_t get_offset_of_animating_11() { return static_cast<int32_t>(offsetof(ExpandCollapseOnClick_t3129825832, ___animating_11)); }
	inline bool get_animating_11() const { return ___animating_11; }
	inline bool* get_address_of_animating_11() { return &___animating_11; }
	inline void set_animating_11(bool value)
	{
		___animating_11 = value;
	}

	inline static int32_t get_offset_of_rectTransform_12() { return static_cast<int32_t>(offsetof(ExpandCollapseOnClick_t3129825832, ___rectTransform_12)); }
	inline RectTransform_t3349966182 * get_rectTransform_12() const { return ___rectTransform_12; }
	inline RectTransform_t3349966182 ** get_address_of_rectTransform_12() { return &___rectTransform_12; }
	inline void set_rectTransform_12(RectTransform_t3349966182 * value)
	{
		___rectTransform_12 = value;
		Il2CppCodeGenWriteBarrier(&___rectTransform_12, value);
	}

	inline static int32_t get_offset_of_sizeChangesHandler_13() { return static_cast<int32_t>(offsetof(ExpandCollapseOnClick_t3129825832, ___sizeChangesHandler_13)); }
	inline Il2CppObject * get_sizeChangesHandler_13() const { return ___sizeChangesHandler_13; }
	inline Il2CppObject ** get_address_of_sizeChangesHandler_13() { return &___sizeChangesHandler_13; }
	inline void set_sizeChangesHandler_13(Il2CppObject * value)
	{
		___sizeChangesHandler_13 = value;
		Il2CppCodeGenWriteBarrier(&___sizeChangesHandler_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
