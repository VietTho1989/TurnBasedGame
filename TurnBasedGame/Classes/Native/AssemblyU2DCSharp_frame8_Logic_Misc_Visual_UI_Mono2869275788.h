#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"

// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// frame8.Logic.Misc.Visual.UI.IScrollRectProxy
struct IScrollRectProxy_t1619251202;
// UnityEngine.UI.Scrollbar
struct Scrollbar_t3248359358;
// UnityEngine.CanvasGroup
struct CanvasGroup_t3296560743;
// UnityEngine.Coroutine
struct Coroutine_t2299508840;
// System.Action`1<System.Single>
struct Action_1_t1878309314;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8
struct  ScrollbarFixer8_t2869275788  : public MonoBehaviour_t1158329972
{
public:
	// System.Boolean frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::hideWhenNotNeeded
	bool ___hideWhenNotNeeded_2;
	// System.Boolean frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::autoHide
	bool ___autoHide_3;
	// System.Boolean frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::autoHideFadeEffect
	bool ___autoHideFadeEffect_4;
	// System.Boolean frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::autoHideCollapseEffect
	bool ___autoHideCollapseEffect_5;
	// System.Single frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::autoHideTime
	float ___autoHideTime_6;
	// System.Single frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::autoHideFadeEffectMinAlpha
	float ___autoHideFadeEffectMinAlpha_7;
	// System.Single frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::autoHideCollapseEffectMinScale
	float ___autoHideCollapseEffectMinScale_8;
	// System.Single frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::minSize
	float ___minSize_9;
	// System.Single frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::sizeUpdateInterval
	float ___sizeUpdateInterval_10;
	// System.Int32 frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::skippedFramesBetweenPositionChanges
	int32_t ___skippedFramesBetweenPositionChanges_11;
	// UnityEngine.UI.ScrollRect frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::scrollRect
	ScrollRect_t1199013257 * ___scrollRect_12;
	// UnityEngine.RectTransform frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::viewport
	RectTransform_t3349966182 * ___viewport_13;
	// frame8.Logic.Misc.Visual.UI.IScrollRectProxy frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::externalScrollRectProxy
	Il2CppObject * ___externalScrollRectProxy_14;
	// UnityEngine.RectTransform frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_ScrollRectRT
	RectTransform_t3349966182 * ____ScrollRectRT_16;
	// UnityEngine.RectTransform frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_ViewPortRT
	RectTransform_t3349966182 * ____ViewPortRT_17;
	// UnityEngine.UI.Scrollbar frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_Scrollbar
	Scrollbar_t3248359358 * ____Scrollbar_18;
	// UnityEngine.CanvasGroup frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_CanvasGroupForFadeEffect
	CanvasGroup_t3296560743 * ____CanvasGroupForFadeEffect_19;
	// System.Boolean frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_HorizontalScrollBar
	bool ____HorizontalScrollBar_20;
	// UnityEngine.Vector3 frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_InitialScale
	Vector3_t2243707580  ____InitialScale_21;
	// System.Boolean frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_Hidden
	bool ____Hidden_22;
	// System.Boolean frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_AutoHidden
	bool ____AutoHidden_23;
	// System.Boolean frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_HiddenNotNeeded
	bool ____HiddenNotNeeded_24;
	// System.Single frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_LastValue
	float ____LastValue_25;
	// System.Single frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_TimeOnLastValueChange
	float ____TimeOnLastValueChange_26;
	// System.Boolean frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_Dragging
	bool ____Dragging_27;
	// UnityEngine.Coroutine frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_SlowUpdateCoroutine
	Coroutine_t2299508840 * ____SlowUpdateCoroutine_28;
	// System.Single frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_TransversalScaleOnLastDrag
	float ____TransversalScaleOnLastDrag_29;
	// System.Single frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_AlphaOnLastDrag
	float ____AlphaOnLastDrag_30;
	// System.Boolean frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_FullyInitialized
	bool ____FullyInitialized_31;
	// System.Int32 frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::_FrameCountOnLastPositionUpdate
	int32_t ____FrameCountOnLastPositionUpdate_32;
	// System.Action`1<System.Single> frame8.Logic.Misc.Visual.UI.MonoBehaviours.ScrollbarFixer8::ScrollPositionChanged
	Action_1_t1878309314 * ___ScrollPositionChanged_33;

public:
	inline static int32_t get_offset_of_hideWhenNotNeeded_2() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___hideWhenNotNeeded_2)); }
	inline bool get_hideWhenNotNeeded_2() const { return ___hideWhenNotNeeded_2; }
	inline bool* get_address_of_hideWhenNotNeeded_2() { return &___hideWhenNotNeeded_2; }
	inline void set_hideWhenNotNeeded_2(bool value)
	{
		___hideWhenNotNeeded_2 = value;
	}

	inline static int32_t get_offset_of_autoHide_3() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___autoHide_3)); }
	inline bool get_autoHide_3() const { return ___autoHide_3; }
	inline bool* get_address_of_autoHide_3() { return &___autoHide_3; }
	inline void set_autoHide_3(bool value)
	{
		___autoHide_3 = value;
	}

	inline static int32_t get_offset_of_autoHideFadeEffect_4() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___autoHideFadeEffect_4)); }
	inline bool get_autoHideFadeEffect_4() const { return ___autoHideFadeEffect_4; }
	inline bool* get_address_of_autoHideFadeEffect_4() { return &___autoHideFadeEffect_4; }
	inline void set_autoHideFadeEffect_4(bool value)
	{
		___autoHideFadeEffect_4 = value;
	}

	inline static int32_t get_offset_of_autoHideCollapseEffect_5() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___autoHideCollapseEffect_5)); }
	inline bool get_autoHideCollapseEffect_5() const { return ___autoHideCollapseEffect_5; }
	inline bool* get_address_of_autoHideCollapseEffect_5() { return &___autoHideCollapseEffect_5; }
	inline void set_autoHideCollapseEffect_5(bool value)
	{
		___autoHideCollapseEffect_5 = value;
	}

	inline static int32_t get_offset_of_autoHideTime_6() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___autoHideTime_6)); }
	inline float get_autoHideTime_6() const { return ___autoHideTime_6; }
	inline float* get_address_of_autoHideTime_6() { return &___autoHideTime_6; }
	inline void set_autoHideTime_6(float value)
	{
		___autoHideTime_6 = value;
	}

	inline static int32_t get_offset_of_autoHideFadeEffectMinAlpha_7() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___autoHideFadeEffectMinAlpha_7)); }
	inline float get_autoHideFadeEffectMinAlpha_7() const { return ___autoHideFadeEffectMinAlpha_7; }
	inline float* get_address_of_autoHideFadeEffectMinAlpha_7() { return &___autoHideFadeEffectMinAlpha_7; }
	inline void set_autoHideFadeEffectMinAlpha_7(float value)
	{
		___autoHideFadeEffectMinAlpha_7 = value;
	}

	inline static int32_t get_offset_of_autoHideCollapseEffectMinScale_8() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___autoHideCollapseEffectMinScale_8)); }
	inline float get_autoHideCollapseEffectMinScale_8() const { return ___autoHideCollapseEffectMinScale_8; }
	inline float* get_address_of_autoHideCollapseEffectMinScale_8() { return &___autoHideCollapseEffectMinScale_8; }
	inline void set_autoHideCollapseEffectMinScale_8(float value)
	{
		___autoHideCollapseEffectMinScale_8 = value;
	}

	inline static int32_t get_offset_of_minSize_9() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___minSize_9)); }
	inline float get_minSize_9() const { return ___minSize_9; }
	inline float* get_address_of_minSize_9() { return &___minSize_9; }
	inline void set_minSize_9(float value)
	{
		___minSize_9 = value;
	}

	inline static int32_t get_offset_of_sizeUpdateInterval_10() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___sizeUpdateInterval_10)); }
	inline float get_sizeUpdateInterval_10() const { return ___sizeUpdateInterval_10; }
	inline float* get_address_of_sizeUpdateInterval_10() { return &___sizeUpdateInterval_10; }
	inline void set_sizeUpdateInterval_10(float value)
	{
		___sizeUpdateInterval_10 = value;
	}

	inline static int32_t get_offset_of_skippedFramesBetweenPositionChanges_11() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___skippedFramesBetweenPositionChanges_11)); }
	inline int32_t get_skippedFramesBetweenPositionChanges_11() const { return ___skippedFramesBetweenPositionChanges_11; }
	inline int32_t* get_address_of_skippedFramesBetweenPositionChanges_11() { return &___skippedFramesBetweenPositionChanges_11; }
	inline void set_skippedFramesBetweenPositionChanges_11(int32_t value)
	{
		___skippedFramesBetweenPositionChanges_11 = value;
	}

	inline static int32_t get_offset_of_scrollRect_12() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___scrollRect_12)); }
	inline ScrollRect_t1199013257 * get_scrollRect_12() const { return ___scrollRect_12; }
	inline ScrollRect_t1199013257 ** get_address_of_scrollRect_12() { return &___scrollRect_12; }
	inline void set_scrollRect_12(ScrollRect_t1199013257 * value)
	{
		___scrollRect_12 = value;
		Il2CppCodeGenWriteBarrier(&___scrollRect_12, value);
	}

	inline static int32_t get_offset_of_viewport_13() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___viewport_13)); }
	inline RectTransform_t3349966182 * get_viewport_13() const { return ___viewport_13; }
	inline RectTransform_t3349966182 ** get_address_of_viewport_13() { return &___viewport_13; }
	inline void set_viewport_13(RectTransform_t3349966182 * value)
	{
		___viewport_13 = value;
		Il2CppCodeGenWriteBarrier(&___viewport_13, value);
	}

	inline static int32_t get_offset_of_externalScrollRectProxy_14() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___externalScrollRectProxy_14)); }
	inline Il2CppObject * get_externalScrollRectProxy_14() const { return ___externalScrollRectProxy_14; }
	inline Il2CppObject ** get_address_of_externalScrollRectProxy_14() { return &___externalScrollRectProxy_14; }
	inline void set_externalScrollRectProxy_14(Il2CppObject * value)
	{
		___externalScrollRectProxy_14 = value;
		Il2CppCodeGenWriteBarrier(&___externalScrollRectProxy_14, value);
	}

	inline static int32_t get_offset_of__ScrollRectRT_16() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____ScrollRectRT_16)); }
	inline RectTransform_t3349966182 * get__ScrollRectRT_16() const { return ____ScrollRectRT_16; }
	inline RectTransform_t3349966182 ** get_address_of__ScrollRectRT_16() { return &____ScrollRectRT_16; }
	inline void set__ScrollRectRT_16(RectTransform_t3349966182 * value)
	{
		____ScrollRectRT_16 = value;
		Il2CppCodeGenWriteBarrier(&____ScrollRectRT_16, value);
	}

	inline static int32_t get_offset_of__ViewPortRT_17() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____ViewPortRT_17)); }
	inline RectTransform_t3349966182 * get__ViewPortRT_17() const { return ____ViewPortRT_17; }
	inline RectTransform_t3349966182 ** get_address_of__ViewPortRT_17() { return &____ViewPortRT_17; }
	inline void set__ViewPortRT_17(RectTransform_t3349966182 * value)
	{
		____ViewPortRT_17 = value;
		Il2CppCodeGenWriteBarrier(&____ViewPortRT_17, value);
	}

	inline static int32_t get_offset_of__Scrollbar_18() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____Scrollbar_18)); }
	inline Scrollbar_t3248359358 * get__Scrollbar_18() const { return ____Scrollbar_18; }
	inline Scrollbar_t3248359358 ** get_address_of__Scrollbar_18() { return &____Scrollbar_18; }
	inline void set__Scrollbar_18(Scrollbar_t3248359358 * value)
	{
		____Scrollbar_18 = value;
		Il2CppCodeGenWriteBarrier(&____Scrollbar_18, value);
	}

	inline static int32_t get_offset_of__CanvasGroupForFadeEffect_19() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____CanvasGroupForFadeEffect_19)); }
	inline CanvasGroup_t3296560743 * get__CanvasGroupForFadeEffect_19() const { return ____CanvasGroupForFadeEffect_19; }
	inline CanvasGroup_t3296560743 ** get_address_of__CanvasGroupForFadeEffect_19() { return &____CanvasGroupForFadeEffect_19; }
	inline void set__CanvasGroupForFadeEffect_19(CanvasGroup_t3296560743 * value)
	{
		____CanvasGroupForFadeEffect_19 = value;
		Il2CppCodeGenWriteBarrier(&____CanvasGroupForFadeEffect_19, value);
	}

	inline static int32_t get_offset_of__HorizontalScrollBar_20() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____HorizontalScrollBar_20)); }
	inline bool get__HorizontalScrollBar_20() const { return ____HorizontalScrollBar_20; }
	inline bool* get_address_of__HorizontalScrollBar_20() { return &____HorizontalScrollBar_20; }
	inline void set__HorizontalScrollBar_20(bool value)
	{
		____HorizontalScrollBar_20 = value;
	}

	inline static int32_t get_offset_of__InitialScale_21() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____InitialScale_21)); }
	inline Vector3_t2243707580  get__InitialScale_21() const { return ____InitialScale_21; }
	inline Vector3_t2243707580 * get_address_of__InitialScale_21() { return &____InitialScale_21; }
	inline void set__InitialScale_21(Vector3_t2243707580  value)
	{
		____InitialScale_21 = value;
	}

	inline static int32_t get_offset_of__Hidden_22() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____Hidden_22)); }
	inline bool get__Hidden_22() const { return ____Hidden_22; }
	inline bool* get_address_of__Hidden_22() { return &____Hidden_22; }
	inline void set__Hidden_22(bool value)
	{
		____Hidden_22 = value;
	}

	inline static int32_t get_offset_of__AutoHidden_23() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____AutoHidden_23)); }
	inline bool get__AutoHidden_23() const { return ____AutoHidden_23; }
	inline bool* get_address_of__AutoHidden_23() { return &____AutoHidden_23; }
	inline void set__AutoHidden_23(bool value)
	{
		____AutoHidden_23 = value;
	}

	inline static int32_t get_offset_of__HiddenNotNeeded_24() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____HiddenNotNeeded_24)); }
	inline bool get__HiddenNotNeeded_24() const { return ____HiddenNotNeeded_24; }
	inline bool* get_address_of__HiddenNotNeeded_24() { return &____HiddenNotNeeded_24; }
	inline void set__HiddenNotNeeded_24(bool value)
	{
		____HiddenNotNeeded_24 = value;
	}

	inline static int32_t get_offset_of__LastValue_25() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____LastValue_25)); }
	inline float get__LastValue_25() const { return ____LastValue_25; }
	inline float* get_address_of__LastValue_25() { return &____LastValue_25; }
	inline void set__LastValue_25(float value)
	{
		____LastValue_25 = value;
	}

	inline static int32_t get_offset_of__TimeOnLastValueChange_26() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____TimeOnLastValueChange_26)); }
	inline float get__TimeOnLastValueChange_26() const { return ____TimeOnLastValueChange_26; }
	inline float* get_address_of__TimeOnLastValueChange_26() { return &____TimeOnLastValueChange_26; }
	inline void set__TimeOnLastValueChange_26(float value)
	{
		____TimeOnLastValueChange_26 = value;
	}

	inline static int32_t get_offset_of__Dragging_27() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____Dragging_27)); }
	inline bool get__Dragging_27() const { return ____Dragging_27; }
	inline bool* get_address_of__Dragging_27() { return &____Dragging_27; }
	inline void set__Dragging_27(bool value)
	{
		____Dragging_27 = value;
	}

	inline static int32_t get_offset_of__SlowUpdateCoroutine_28() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____SlowUpdateCoroutine_28)); }
	inline Coroutine_t2299508840 * get__SlowUpdateCoroutine_28() const { return ____SlowUpdateCoroutine_28; }
	inline Coroutine_t2299508840 ** get_address_of__SlowUpdateCoroutine_28() { return &____SlowUpdateCoroutine_28; }
	inline void set__SlowUpdateCoroutine_28(Coroutine_t2299508840 * value)
	{
		____SlowUpdateCoroutine_28 = value;
		Il2CppCodeGenWriteBarrier(&____SlowUpdateCoroutine_28, value);
	}

	inline static int32_t get_offset_of__TransversalScaleOnLastDrag_29() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____TransversalScaleOnLastDrag_29)); }
	inline float get__TransversalScaleOnLastDrag_29() const { return ____TransversalScaleOnLastDrag_29; }
	inline float* get_address_of__TransversalScaleOnLastDrag_29() { return &____TransversalScaleOnLastDrag_29; }
	inline void set__TransversalScaleOnLastDrag_29(float value)
	{
		____TransversalScaleOnLastDrag_29 = value;
	}

	inline static int32_t get_offset_of__AlphaOnLastDrag_30() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____AlphaOnLastDrag_30)); }
	inline float get__AlphaOnLastDrag_30() const { return ____AlphaOnLastDrag_30; }
	inline float* get_address_of__AlphaOnLastDrag_30() { return &____AlphaOnLastDrag_30; }
	inline void set__AlphaOnLastDrag_30(float value)
	{
		____AlphaOnLastDrag_30 = value;
	}

	inline static int32_t get_offset_of__FullyInitialized_31() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____FullyInitialized_31)); }
	inline bool get__FullyInitialized_31() const { return ____FullyInitialized_31; }
	inline bool* get_address_of__FullyInitialized_31() { return &____FullyInitialized_31; }
	inline void set__FullyInitialized_31(bool value)
	{
		____FullyInitialized_31 = value;
	}

	inline static int32_t get_offset_of__FrameCountOnLastPositionUpdate_32() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ____FrameCountOnLastPositionUpdate_32)); }
	inline int32_t get__FrameCountOnLastPositionUpdate_32() const { return ____FrameCountOnLastPositionUpdate_32; }
	inline int32_t* get_address_of__FrameCountOnLastPositionUpdate_32() { return &____FrameCountOnLastPositionUpdate_32; }
	inline void set__FrameCountOnLastPositionUpdate_32(int32_t value)
	{
		____FrameCountOnLastPositionUpdate_32 = value;
	}

	inline static int32_t get_offset_of_ScrollPositionChanged_33() { return static_cast<int32_t>(offsetof(ScrollbarFixer8_t2869275788, ___ScrollPositionChanged_33)); }
	inline Action_1_t1878309314 * get_ScrollPositionChanged_33() const { return ___ScrollPositionChanged_33; }
	inline Action_1_t1878309314 ** get_address_of_ScrollPositionChanged_33() { return &___ScrollPositionChanged_33; }
	inline void set_ScrollPositionChanged_33(Action_1_t1878309314 * value)
	{
		___ScrollPositionChanged_33 = value;
		Il2CppCodeGenWriteBarrier(&___ScrollPositionChanged_33, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
