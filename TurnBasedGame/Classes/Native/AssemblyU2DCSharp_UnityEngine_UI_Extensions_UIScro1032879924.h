#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_UIScro1104322043.h"

// System.Collections.Generic.List`1<UnityEngine.KeyCode>
struct List_1_t1652516284;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UIScrollToSelection
struct  UIScrollToSelection_t1032879924  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Extensions.UIScrollToSelection/ScrollType UnityEngine.UI.Extensions.UIScrollToSelection::scrollDirection
	int32_t ___scrollDirection_2;
	// System.Single UnityEngine.UI.Extensions.UIScrollToSelection::scrollSpeed
	float ___scrollSpeed_3;
	// System.Boolean UnityEngine.UI.Extensions.UIScrollToSelection::cancelScrollOnInput
	bool ___cancelScrollOnInput_4;
	// System.Collections.Generic.List`1<UnityEngine.KeyCode> UnityEngine.UI.Extensions.UIScrollToSelection::cancelScrollKeycodes
	List_1_t1652516284 * ___cancelScrollKeycodes_5;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.UIScrollToSelection::<ScrollWindow>k__BackingField
	RectTransform_t3349966182 * ___U3CScrollWindowU3Ek__BackingField_6;
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.UIScrollToSelection::<TargetScrollRect>k__BackingField
	ScrollRect_t1199013257 * ___U3CTargetScrollRectU3Ek__BackingField_7;
	// UnityEngine.GameObject UnityEngine.UI.Extensions.UIScrollToSelection::<LastCheckedGameObject>k__BackingField
	GameObject_t1756533147 * ___U3CLastCheckedGameObjectU3Ek__BackingField_8;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.UIScrollToSelection::<CurrentTargetRectTransform>k__BackingField
	RectTransform_t3349966182 * ___U3CCurrentTargetRectTransformU3Ek__BackingField_9;
	// System.Boolean UnityEngine.UI.Extensions.UIScrollToSelection::<IsManualScrollingAvailable>k__BackingField
	bool ___U3CIsManualScrollingAvailableU3Ek__BackingField_10;

public:
	inline static int32_t get_offset_of_scrollDirection_2() { return static_cast<int32_t>(offsetof(UIScrollToSelection_t1032879924, ___scrollDirection_2)); }
	inline int32_t get_scrollDirection_2() const { return ___scrollDirection_2; }
	inline int32_t* get_address_of_scrollDirection_2() { return &___scrollDirection_2; }
	inline void set_scrollDirection_2(int32_t value)
	{
		___scrollDirection_2 = value;
	}

	inline static int32_t get_offset_of_scrollSpeed_3() { return static_cast<int32_t>(offsetof(UIScrollToSelection_t1032879924, ___scrollSpeed_3)); }
	inline float get_scrollSpeed_3() const { return ___scrollSpeed_3; }
	inline float* get_address_of_scrollSpeed_3() { return &___scrollSpeed_3; }
	inline void set_scrollSpeed_3(float value)
	{
		___scrollSpeed_3 = value;
	}

	inline static int32_t get_offset_of_cancelScrollOnInput_4() { return static_cast<int32_t>(offsetof(UIScrollToSelection_t1032879924, ___cancelScrollOnInput_4)); }
	inline bool get_cancelScrollOnInput_4() const { return ___cancelScrollOnInput_4; }
	inline bool* get_address_of_cancelScrollOnInput_4() { return &___cancelScrollOnInput_4; }
	inline void set_cancelScrollOnInput_4(bool value)
	{
		___cancelScrollOnInput_4 = value;
	}

	inline static int32_t get_offset_of_cancelScrollKeycodes_5() { return static_cast<int32_t>(offsetof(UIScrollToSelection_t1032879924, ___cancelScrollKeycodes_5)); }
	inline List_1_t1652516284 * get_cancelScrollKeycodes_5() const { return ___cancelScrollKeycodes_5; }
	inline List_1_t1652516284 ** get_address_of_cancelScrollKeycodes_5() { return &___cancelScrollKeycodes_5; }
	inline void set_cancelScrollKeycodes_5(List_1_t1652516284 * value)
	{
		___cancelScrollKeycodes_5 = value;
		Il2CppCodeGenWriteBarrier(&___cancelScrollKeycodes_5, value);
	}

	inline static int32_t get_offset_of_U3CScrollWindowU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(UIScrollToSelection_t1032879924, ___U3CScrollWindowU3Ek__BackingField_6)); }
	inline RectTransform_t3349966182 * get_U3CScrollWindowU3Ek__BackingField_6() const { return ___U3CScrollWindowU3Ek__BackingField_6; }
	inline RectTransform_t3349966182 ** get_address_of_U3CScrollWindowU3Ek__BackingField_6() { return &___U3CScrollWindowU3Ek__BackingField_6; }
	inline void set_U3CScrollWindowU3Ek__BackingField_6(RectTransform_t3349966182 * value)
	{
		___U3CScrollWindowU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CScrollWindowU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_U3CTargetScrollRectU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(UIScrollToSelection_t1032879924, ___U3CTargetScrollRectU3Ek__BackingField_7)); }
	inline ScrollRect_t1199013257 * get_U3CTargetScrollRectU3Ek__BackingField_7() const { return ___U3CTargetScrollRectU3Ek__BackingField_7; }
	inline ScrollRect_t1199013257 ** get_address_of_U3CTargetScrollRectU3Ek__BackingField_7() { return &___U3CTargetScrollRectU3Ek__BackingField_7; }
	inline void set_U3CTargetScrollRectU3Ek__BackingField_7(ScrollRect_t1199013257 * value)
	{
		___U3CTargetScrollRectU3Ek__BackingField_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CTargetScrollRectU3Ek__BackingField_7, value);
	}

	inline static int32_t get_offset_of_U3CLastCheckedGameObjectU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(UIScrollToSelection_t1032879924, ___U3CLastCheckedGameObjectU3Ek__BackingField_8)); }
	inline GameObject_t1756533147 * get_U3CLastCheckedGameObjectU3Ek__BackingField_8() const { return ___U3CLastCheckedGameObjectU3Ek__BackingField_8; }
	inline GameObject_t1756533147 ** get_address_of_U3CLastCheckedGameObjectU3Ek__BackingField_8() { return &___U3CLastCheckedGameObjectU3Ek__BackingField_8; }
	inline void set_U3CLastCheckedGameObjectU3Ek__BackingField_8(GameObject_t1756533147 * value)
	{
		___U3CLastCheckedGameObjectU3Ek__BackingField_8 = value;
		Il2CppCodeGenWriteBarrier(&___U3CLastCheckedGameObjectU3Ek__BackingField_8, value);
	}

	inline static int32_t get_offset_of_U3CCurrentTargetRectTransformU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(UIScrollToSelection_t1032879924, ___U3CCurrentTargetRectTransformU3Ek__BackingField_9)); }
	inline RectTransform_t3349966182 * get_U3CCurrentTargetRectTransformU3Ek__BackingField_9() const { return ___U3CCurrentTargetRectTransformU3Ek__BackingField_9; }
	inline RectTransform_t3349966182 ** get_address_of_U3CCurrentTargetRectTransformU3Ek__BackingField_9() { return &___U3CCurrentTargetRectTransformU3Ek__BackingField_9; }
	inline void set_U3CCurrentTargetRectTransformU3Ek__BackingField_9(RectTransform_t3349966182 * value)
	{
		___U3CCurrentTargetRectTransformU3Ek__BackingField_9 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCurrentTargetRectTransformU3Ek__BackingField_9, value);
	}

	inline static int32_t get_offset_of_U3CIsManualScrollingAvailableU3Ek__BackingField_10() { return static_cast<int32_t>(offsetof(UIScrollToSelection_t1032879924, ___U3CIsManualScrollingAvailableU3Ek__BackingField_10)); }
	inline bool get_U3CIsManualScrollingAvailableU3Ek__BackingField_10() const { return ___U3CIsManualScrollingAvailableU3Ek__BackingField_10; }
	inline bool* get_address_of_U3CIsManualScrollingAvailableU3Ek__BackingField_10() { return &___U3CIsManualScrollingAvailableU3Ek__BackingField_10; }
	inline void set_U3CIsManualScrollingAvailableU3Ek__BackingField_10(bool value)
	{
		___U3CIsManualScrollingAvailableU3Ek__BackingField_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
