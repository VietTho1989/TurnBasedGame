#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "AssemblyU2DCSharp_frame8_ScrollRectItemsAdapter_Ut1596984833.h"

// frame8.ScrollRectItemsAdapter.Util.ResizeablePanel/UnityEventBool
struct UnityEventBool_t372295329;
// UnityEngine.UI.LayoutElement
struct LayoutElement_t2808691390;
// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.ResizeablePanel
struct  ResizeablePanel_t1412874476  : public MonoBehaviour_t1158329972
{
public:
	// System.Boolean frame8.ScrollRectItemsAdapter.Util.ResizeablePanel::_Expanded
	bool ____Expanded_2;
	// System.Single frame8.ScrollRectItemsAdapter.Util.ResizeablePanel::_ExpandedSize
	float ____ExpandedSize_3;
	// System.Single frame8.ScrollRectItemsAdapter.Util.ResizeablePanel::_NonExpandedSize
	float ____NonExpandedSize_4;
	// System.Single frame8.ScrollRectItemsAdapter.Util.ResizeablePanel::_AnimTime
	float ____AnimTime_5;
	// frame8.ScrollRectItemsAdapter.Util.ResizeablePanel/DIRECTION frame8.ScrollRectItemsAdapter.Util.ResizeablePanel::_Direction
	int32_t ____Direction_6;
	// System.Boolean frame8.ScrollRectItemsAdapter.Util.ResizeablePanel::_RebuildNearestScrollRectParentDuringAnimation
	bool ____RebuildNearestScrollRectParentDuringAnimation_7;
	// frame8.ScrollRectItemsAdapter.Util.ResizeablePanel/UnityEventBool frame8.ScrollRectItemsAdapter.Util.ResizeablePanel::onExpandedStateChanged
	UnityEventBool_t372295329 * ___onExpandedStateChanged_8;
	// UnityEngine.UI.LayoutElement frame8.ScrollRectItemsAdapter.Util.ResizeablePanel::_LayoutElement
	LayoutElement_t2808691390 * ____LayoutElement_9;
	// UnityEngine.UI.ScrollRect frame8.ScrollRectItemsAdapter.Util.ResizeablePanel::_NearestScrollRectInParents
	ScrollRect_t1199013257 * ____NearestScrollRectInParents_10;
	// System.Boolean frame8.ScrollRectItemsAdapter.Util.ResizeablePanel::_Animating
	bool ____Animating_11;

public:
	inline static int32_t get_offset_of__Expanded_2() { return static_cast<int32_t>(offsetof(ResizeablePanel_t1412874476, ____Expanded_2)); }
	inline bool get__Expanded_2() const { return ____Expanded_2; }
	inline bool* get_address_of__Expanded_2() { return &____Expanded_2; }
	inline void set__Expanded_2(bool value)
	{
		____Expanded_2 = value;
	}

	inline static int32_t get_offset_of__ExpandedSize_3() { return static_cast<int32_t>(offsetof(ResizeablePanel_t1412874476, ____ExpandedSize_3)); }
	inline float get__ExpandedSize_3() const { return ____ExpandedSize_3; }
	inline float* get_address_of__ExpandedSize_3() { return &____ExpandedSize_3; }
	inline void set__ExpandedSize_3(float value)
	{
		____ExpandedSize_3 = value;
	}

	inline static int32_t get_offset_of__NonExpandedSize_4() { return static_cast<int32_t>(offsetof(ResizeablePanel_t1412874476, ____NonExpandedSize_4)); }
	inline float get__NonExpandedSize_4() const { return ____NonExpandedSize_4; }
	inline float* get_address_of__NonExpandedSize_4() { return &____NonExpandedSize_4; }
	inline void set__NonExpandedSize_4(float value)
	{
		____NonExpandedSize_4 = value;
	}

	inline static int32_t get_offset_of__AnimTime_5() { return static_cast<int32_t>(offsetof(ResizeablePanel_t1412874476, ____AnimTime_5)); }
	inline float get__AnimTime_5() const { return ____AnimTime_5; }
	inline float* get_address_of__AnimTime_5() { return &____AnimTime_5; }
	inline void set__AnimTime_5(float value)
	{
		____AnimTime_5 = value;
	}

	inline static int32_t get_offset_of__Direction_6() { return static_cast<int32_t>(offsetof(ResizeablePanel_t1412874476, ____Direction_6)); }
	inline int32_t get__Direction_6() const { return ____Direction_6; }
	inline int32_t* get_address_of__Direction_6() { return &____Direction_6; }
	inline void set__Direction_6(int32_t value)
	{
		____Direction_6 = value;
	}

	inline static int32_t get_offset_of__RebuildNearestScrollRectParentDuringAnimation_7() { return static_cast<int32_t>(offsetof(ResizeablePanel_t1412874476, ____RebuildNearestScrollRectParentDuringAnimation_7)); }
	inline bool get__RebuildNearestScrollRectParentDuringAnimation_7() const { return ____RebuildNearestScrollRectParentDuringAnimation_7; }
	inline bool* get_address_of__RebuildNearestScrollRectParentDuringAnimation_7() { return &____RebuildNearestScrollRectParentDuringAnimation_7; }
	inline void set__RebuildNearestScrollRectParentDuringAnimation_7(bool value)
	{
		____RebuildNearestScrollRectParentDuringAnimation_7 = value;
	}

	inline static int32_t get_offset_of_onExpandedStateChanged_8() { return static_cast<int32_t>(offsetof(ResizeablePanel_t1412874476, ___onExpandedStateChanged_8)); }
	inline UnityEventBool_t372295329 * get_onExpandedStateChanged_8() const { return ___onExpandedStateChanged_8; }
	inline UnityEventBool_t372295329 ** get_address_of_onExpandedStateChanged_8() { return &___onExpandedStateChanged_8; }
	inline void set_onExpandedStateChanged_8(UnityEventBool_t372295329 * value)
	{
		___onExpandedStateChanged_8 = value;
		Il2CppCodeGenWriteBarrier(&___onExpandedStateChanged_8, value);
	}

	inline static int32_t get_offset_of__LayoutElement_9() { return static_cast<int32_t>(offsetof(ResizeablePanel_t1412874476, ____LayoutElement_9)); }
	inline LayoutElement_t2808691390 * get__LayoutElement_9() const { return ____LayoutElement_9; }
	inline LayoutElement_t2808691390 ** get_address_of__LayoutElement_9() { return &____LayoutElement_9; }
	inline void set__LayoutElement_9(LayoutElement_t2808691390 * value)
	{
		____LayoutElement_9 = value;
		Il2CppCodeGenWriteBarrier(&____LayoutElement_9, value);
	}

	inline static int32_t get_offset_of__NearestScrollRectInParents_10() { return static_cast<int32_t>(offsetof(ResizeablePanel_t1412874476, ____NearestScrollRectInParents_10)); }
	inline ScrollRect_t1199013257 * get__NearestScrollRectInParents_10() const { return ____NearestScrollRectInParents_10; }
	inline ScrollRect_t1199013257 ** get_address_of__NearestScrollRectInParents_10() { return &____NearestScrollRectInParents_10; }
	inline void set__NearestScrollRectInParents_10(ScrollRect_t1199013257 * value)
	{
		____NearestScrollRectInParents_10 = value;
		Il2CppCodeGenWriteBarrier(&____NearestScrollRectInParents_10, value);
	}

	inline static int32_t get_offset_of__Animating_11() { return static_cast<int32_t>(offsetof(ResizeablePanel_t1412874476, ____Animating_11)); }
	inline bool get__Animating_11() const { return ____Animating_11; }
	inline bool* get_address_of__Animating_11() { return &____Animating_11; }
	inline void set__Animating_11(bool value)
	{
		____Animating_11 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
