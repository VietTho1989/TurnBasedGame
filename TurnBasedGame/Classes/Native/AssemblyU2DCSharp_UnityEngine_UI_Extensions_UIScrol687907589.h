#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UIScrollToSelectionXY
struct  UIScrollToSelectionXY_t687907589  : public MonoBehaviour_t1158329972
{
public:
	// System.Single UnityEngine.UI.Extensions.UIScrollToSelectionXY::scrollSpeed
	float ___scrollSpeed_2;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.UIScrollToSelectionXY::layoutListGroup
	RectTransform_t3349966182 * ___layoutListGroup_3;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.UIScrollToSelectionXY::targetScrollObject
	RectTransform_t3349966182 * ___targetScrollObject_4;
	// System.Boolean UnityEngine.UI.Extensions.UIScrollToSelectionXY::scrollToSelection
	bool ___scrollToSelection_5;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.UIScrollToSelectionXY::scrollWindow
	RectTransform_t3349966182 * ___scrollWindow_6;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.UIScrollToSelectionXY::currentCanvas
	RectTransform_t3349966182 * ___currentCanvas_7;
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.UIScrollToSelectionXY::targetScrollRect
	ScrollRect_t1199013257 * ___targetScrollRect_8;

public:
	inline static int32_t get_offset_of_scrollSpeed_2() { return static_cast<int32_t>(offsetof(UIScrollToSelectionXY_t687907589, ___scrollSpeed_2)); }
	inline float get_scrollSpeed_2() const { return ___scrollSpeed_2; }
	inline float* get_address_of_scrollSpeed_2() { return &___scrollSpeed_2; }
	inline void set_scrollSpeed_2(float value)
	{
		___scrollSpeed_2 = value;
	}

	inline static int32_t get_offset_of_layoutListGroup_3() { return static_cast<int32_t>(offsetof(UIScrollToSelectionXY_t687907589, ___layoutListGroup_3)); }
	inline RectTransform_t3349966182 * get_layoutListGroup_3() const { return ___layoutListGroup_3; }
	inline RectTransform_t3349966182 ** get_address_of_layoutListGroup_3() { return &___layoutListGroup_3; }
	inline void set_layoutListGroup_3(RectTransform_t3349966182 * value)
	{
		___layoutListGroup_3 = value;
		Il2CppCodeGenWriteBarrier(&___layoutListGroup_3, value);
	}

	inline static int32_t get_offset_of_targetScrollObject_4() { return static_cast<int32_t>(offsetof(UIScrollToSelectionXY_t687907589, ___targetScrollObject_4)); }
	inline RectTransform_t3349966182 * get_targetScrollObject_4() const { return ___targetScrollObject_4; }
	inline RectTransform_t3349966182 ** get_address_of_targetScrollObject_4() { return &___targetScrollObject_4; }
	inline void set_targetScrollObject_4(RectTransform_t3349966182 * value)
	{
		___targetScrollObject_4 = value;
		Il2CppCodeGenWriteBarrier(&___targetScrollObject_4, value);
	}

	inline static int32_t get_offset_of_scrollToSelection_5() { return static_cast<int32_t>(offsetof(UIScrollToSelectionXY_t687907589, ___scrollToSelection_5)); }
	inline bool get_scrollToSelection_5() const { return ___scrollToSelection_5; }
	inline bool* get_address_of_scrollToSelection_5() { return &___scrollToSelection_5; }
	inline void set_scrollToSelection_5(bool value)
	{
		___scrollToSelection_5 = value;
	}

	inline static int32_t get_offset_of_scrollWindow_6() { return static_cast<int32_t>(offsetof(UIScrollToSelectionXY_t687907589, ___scrollWindow_6)); }
	inline RectTransform_t3349966182 * get_scrollWindow_6() const { return ___scrollWindow_6; }
	inline RectTransform_t3349966182 ** get_address_of_scrollWindow_6() { return &___scrollWindow_6; }
	inline void set_scrollWindow_6(RectTransform_t3349966182 * value)
	{
		___scrollWindow_6 = value;
		Il2CppCodeGenWriteBarrier(&___scrollWindow_6, value);
	}

	inline static int32_t get_offset_of_currentCanvas_7() { return static_cast<int32_t>(offsetof(UIScrollToSelectionXY_t687907589, ___currentCanvas_7)); }
	inline RectTransform_t3349966182 * get_currentCanvas_7() const { return ___currentCanvas_7; }
	inline RectTransform_t3349966182 ** get_address_of_currentCanvas_7() { return &___currentCanvas_7; }
	inline void set_currentCanvas_7(RectTransform_t3349966182 * value)
	{
		___currentCanvas_7 = value;
		Il2CppCodeGenWriteBarrier(&___currentCanvas_7, value);
	}

	inline static int32_t get_offset_of_targetScrollRect_8() { return static_cast<int32_t>(offsetof(UIScrollToSelectionXY_t687907589, ___targetScrollRect_8)); }
	inline ScrollRect_t1199013257 * get_targetScrollRect_8() const { return ___targetScrollRect_8; }
	inline ScrollRect_t1199013257 ** get_address_of_targetScrollRect_8() { return &___targetScrollRect_8; }
	inline void set_targetScrollRect_8(ScrollRect_t1199013257 * value)
	{
		___targetScrollRect_8 = value;
		Il2CppCodeGenWriteBarrier(&___targetScrollRect_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
