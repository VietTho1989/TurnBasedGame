#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"

// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.GameObject[]
struct GameObjectU5BU5D_t3057952154;
// UnityEngine.UI.Extensions.ScrollSnapBase/SelectionChangeStartEvent
struct SelectionChangeStartEvent_t1331424750;
// UnityEngine.UI.Extensions.ScrollSnapBase/SelectionPageChangedEvent
struct SelectionPageChangedEvent_t3967268665;
// UnityEngine.UI.Extensions.ScrollSnapBase/SelectionChangeEndEvent
struct SelectionChangeEndEvent_t3994187929;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ScrollSnapBase
struct  ScrollSnapBase_t805675194  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ScrollSnapBase::_screensContainer
	RectTransform_t3349966182 * ____screensContainer_2;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnapBase::_isVertical
	bool ____isVertical_3;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnapBase::_screens
	int32_t ____screens_4;
	// System.Single UnityEngine.UI.Extensions.ScrollSnapBase::_scrollStartPosition
	float ____scrollStartPosition_5;
	// System.Single UnityEngine.UI.Extensions.ScrollSnapBase::_childSize
	float ____childSize_6;
	// System.Single UnityEngine.UI.Extensions.ScrollSnapBase::_childPos
	float ____childPos_7;
	// System.Single UnityEngine.UI.Extensions.ScrollSnapBase::_maskSize
	float ____maskSize_8;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.ScrollSnapBase::_childAnchorPoint
	Vector2_t2243707579  ____childAnchorPoint_9;
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.ScrollSnapBase::_scroll_rect
	ScrollRect_t1199013257 * ____scroll_rect_10;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.ScrollSnapBase::_lerp_target
	Vector3_t2243707580  ____lerp_target_11;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnapBase::_lerp
	bool ____lerp_12;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnapBase::_pointerDown
	bool ____pointerDown_13;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnapBase::_settled
	bool ____settled_14;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.ScrollSnapBase::_startPosition
	Vector3_t2243707580  ____startPosition_15;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnapBase::_currentPage
	int32_t ____currentPage_16;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnapBase::_previousPage
	int32_t ____previousPage_17;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnapBase::_halfNoVisibleItems
	int32_t ____halfNoVisibleItems_18;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnapBase::_bottomItem
	int32_t ____bottomItem_19;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnapBase::_topItem
	int32_t ____topItem_20;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnapBase::StartingScreen
	int32_t ___StartingScreen_21;
	// System.Single UnityEngine.UI.Extensions.ScrollSnapBase::PageStep
	float ___PageStep_22;
	// UnityEngine.GameObject UnityEngine.UI.Extensions.ScrollSnapBase::Pagination
	GameObject_t1756533147 * ___Pagination_23;
	// UnityEngine.GameObject UnityEngine.UI.Extensions.ScrollSnapBase::NextButton
	GameObject_t1756533147 * ___NextButton_24;
	// UnityEngine.GameObject UnityEngine.UI.Extensions.ScrollSnapBase::PrevButton
	GameObject_t1756533147 * ___PrevButton_25;
	// System.Single UnityEngine.UI.Extensions.ScrollSnapBase::transitionSpeed
	float ___transitionSpeed_26;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnapBase::UseFastSwipe
	bool ___UseFastSwipe_27;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnapBase::FastSwipeThreshold
	int32_t ___FastSwipeThreshold_28;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnapBase::SwipeVelocityThreshold
	int32_t ___SwipeVelocityThreshold_29;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ScrollSnapBase::MaskArea
	RectTransform_t3349966182 * ___MaskArea_30;
	// System.Single UnityEngine.UI.Extensions.ScrollSnapBase::MaskBuffer
	float ___MaskBuffer_31;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnapBase::UseParentTransform
	bool ___UseParentTransform_32;
	// UnityEngine.GameObject[] UnityEngine.UI.Extensions.ScrollSnapBase::ChildObjects
	GameObjectU5BU5D_t3057952154* ___ChildObjects_33;
	// UnityEngine.UI.Extensions.ScrollSnapBase/SelectionChangeStartEvent UnityEngine.UI.Extensions.ScrollSnapBase::m_OnSelectionChangeStartEvent
	SelectionChangeStartEvent_t1331424750 * ___m_OnSelectionChangeStartEvent_34;
	// UnityEngine.UI.Extensions.ScrollSnapBase/SelectionPageChangedEvent UnityEngine.UI.Extensions.ScrollSnapBase::m_OnSelectionPageChangedEvent
	SelectionPageChangedEvent_t3967268665 * ___m_OnSelectionPageChangedEvent_35;
	// UnityEngine.UI.Extensions.ScrollSnapBase/SelectionChangeEndEvent UnityEngine.UI.Extensions.ScrollSnapBase::m_OnSelectionChangeEndEvent
	SelectionChangeEndEvent_t3994187929 * ___m_OnSelectionChangeEndEvent_36;

public:
	inline static int32_t get_offset_of__screensContainer_2() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____screensContainer_2)); }
	inline RectTransform_t3349966182 * get__screensContainer_2() const { return ____screensContainer_2; }
	inline RectTransform_t3349966182 ** get_address_of__screensContainer_2() { return &____screensContainer_2; }
	inline void set__screensContainer_2(RectTransform_t3349966182 * value)
	{
		____screensContainer_2 = value;
		Il2CppCodeGenWriteBarrier(&____screensContainer_2, value);
	}

	inline static int32_t get_offset_of__isVertical_3() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____isVertical_3)); }
	inline bool get__isVertical_3() const { return ____isVertical_3; }
	inline bool* get_address_of__isVertical_3() { return &____isVertical_3; }
	inline void set__isVertical_3(bool value)
	{
		____isVertical_3 = value;
	}

	inline static int32_t get_offset_of__screens_4() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____screens_4)); }
	inline int32_t get__screens_4() const { return ____screens_4; }
	inline int32_t* get_address_of__screens_4() { return &____screens_4; }
	inline void set__screens_4(int32_t value)
	{
		____screens_4 = value;
	}

	inline static int32_t get_offset_of__scrollStartPosition_5() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____scrollStartPosition_5)); }
	inline float get__scrollStartPosition_5() const { return ____scrollStartPosition_5; }
	inline float* get_address_of__scrollStartPosition_5() { return &____scrollStartPosition_5; }
	inline void set__scrollStartPosition_5(float value)
	{
		____scrollStartPosition_5 = value;
	}

	inline static int32_t get_offset_of__childSize_6() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____childSize_6)); }
	inline float get__childSize_6() const { return ____childSize_6; }
	inline float* get_address_of__childSize_6() { return &____childSize_6; }
	inline void set__childSize_6(float value)
	{
		____childSize_6 = value;
	}

	inline static int32_t get_offset_of__childPos_7() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____childPos_7)); }
	inline float get__childPos_7() const { return ____childPos_7; }
	inline float* get_address_of__childPos_7() { return &____childPos_7; }
	inline void set__childPos_7(float value)
	{
		____childPos_7 = value;
	}

	inline static int32_t get_offset_of__maskSize_8() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____maskSize_8)); }
	inline float get__maskSize_8() const { return ____maskSize_8; }
	inline float* get_address_of__maskSize_8() { return &____maskSize_8; }
	inline void set__maskSize_8(float value)
	{
		____maskSize_8 = value;
	}

	inline static int32_t get_offset_of__childAnchorPoint_9() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____childAnchorPoint_9)); }
	inline Vector2_t2243707579  get__childAnchorPoint_9() const { return ____childAnchorPoint_9; }
	inline Vector2_t2243707579 * get_address_of__childAnchorPoint_9() { return &____childAnchorPoint_9; }
	inline void set__childAnchorPoint_9(Vector2_t2243707579  value)
	{
		____childAnchorPoint_9 = value;
	}

	inline static int32_t get_offset_of__scroll_rect_10() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____scroll_rect_10)); }
	inline ScrollRect_t1199013257 * get__scroll_rect_10() const { return ____scroll_rect_10; }
	inline ScrollRect_t1199013257 ** get_address_of__scroll_rect_10() { return &____scroll_rect_10; }
	inline void set__scroll_rect_10(ScrollRect_t1199013257 * value)
	{
		____scroll_rect_10 = value;
		Il2CppCodeGenWriteBarrier(&____scroll_rect_10, value);
	}

	inline static int32_t get_offset_of__lerp_target_11() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____lerp_target_11)); }
	inline Vector3_t2243707580  get__lerp_target_11() const { return ____lerp_target_11; }
	inline Vector3_t2243707580 * get_address_of__lerp_target_11() { return &____lerp_target_11; }
	inline void set__lerp_target_11(Vector3_t2243707580  value)
	{
		____lerp_target_11 = value;
	}

	inline static int32_t get_offset_of__lerp_12() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____lerp_12)); }
	inline bool get__lerp_12() const { return ____lerp_12; }
	inline bool* get_address_of__lerp_12() { return &____lerp_12; }
	inline void set__lerp_12(bool value)
	{
		____lerp_12 = value;
	}

	inline static int32_t get_offset_of__pointerDown_13() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____pointerDown_13)); }
	inline bool get__pointerDown_13() const { return ____pointerDown_13; }
	inline bool* get_address_of__pointerDown_13() { return &____pointerDown_13; }
	inline void set__pointerDown_13(bool value)
	{
		____pointerDown_13 = value;
	}

	inline static int32_t get_offset_of__settled_14() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____settled_14)); }
	inline bool get__settled_14() const { return ____settled_14; }
	inline bool* get_address_of__settled_14() { return &____settled_14; }
	inline void set__settled_14(bool value)
	{
		____settled_14 = value;
	}

	inline static int32_t get_offset_of__startPosition_15() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____startPosition_15)); }
	inline Vector3_t2243707580  get__startPosition_15() const { return ____startPosition_15; }
	inline Vector3_t2243707580 * get_address_of__startPosition_15() { return &____startPosition_15; }
	inline void set__startPosition_15(Vector3_t2243707580  value)
	{
		____startPosition_15 = value;
	}

	inline static int32_t get_offset_of__currentPage_16() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____currentPage_16)); }
	inline int32_t get__currentPage_16() const { return ____currentPage_16; }
	inline int32_t* get_address_of__currentPage_16() { return &____currentPage_16; }
	inline void set__currentPage_16(int32_t value)
	{
		____currentPage_16 = value;
	}

	inline static int32_t get_offset_of__previousPage_17() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____previousPage_17)); }
	inline int32_t get__previousPage_17() const { return ____previousPage_17; }
	inline int32_t* get_address_of__previousPage_17() { return &____previousPage_17; }
	inline void set__previousPage_17(int32_t value)
	{
		____previousPage_17 = value;
	}

	inline static int32_t get_offset_of__halfNoVisibleItems_18() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____halfNoVisibleItems_18)); }
	inline int32_t get__halfNoVisibleItems_18() const { return ____halfNoVisibleItems_18; }
	inline int32_t* get_address_of__halfNoVisibleItems_18() { return &____halfNoVisibleItems_18; }
	inline void set__halfNoVisibleItems_18(int32_t value)
	{
		____halfNoVisibleItems_18 = value;
	}

	inline static int32_t get_offset_of__bottomItem_19() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____bottomItem_19)); }
	inline int32_t get__bottomItem_19() const { return ____bottomItem_19; }
	inline int32_t* get_address_of__bottomItem_19() { return &____bottomItem_19; }
	inline void set__bottomItem_19(int32_t value)
	{
		____bottomItem_19 = value;
	}

	inline static int32_t get_offset_of__topItem_20() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ____topItem_20)); }
	inline int32_t get__topItem_20() const { return ____topItem_20; }
	inline int32_t* get_address_of__topItem_20() { return &____topItem_20; }
	inline void set__topItem_20(int32_t value)
	{
		____topItem_20 = value;
	}

	inline static int32_t get_offset_of_StartingScreen_21() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___StartingScreen_21)); }
	inline int32_t get_StartingScreen_21() const { return ___StartingScreen_21; }
	inline int32_t* get_address_of_StartingScreen_21() { return &___StartingScreen_21; }
	inline void set_StartingScreen_21(int32_t value)
	{
		___StartingScreen_21 = value;
	}

	inline static int32_t get_offset_of_PageStep_22() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___PageStep_22)); }
	inline float get_PageStep_22() const { return ___PageStep_22; }
	inline float* get_address_of_PageStep_22() { return &___PageStep_22; }
	inline void set_PageStep_22(float value)
	{
		___PageStep_22 = value;
	}

	inline static int32_t get_offset_of_Pagination_23() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___Pagination_23)); }
	inline GameObject_t1756533147 * get_Pagination_23() const { return ___Pagination_23; }
	inline GameObject_t1756533147 ** get_address_of_Pagination_23() { return &___Pagination_23; }
	inline void set_Pagination_23(GameObject_t1756533147 * value)
	{
		___Pagination_23 = value;
		Il2CppCodeGenWriteBarrier(&___Pagination_23, value);
	}

	inline static int32_t get_offset_of_NextButton_24() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___NextButton_24)); }
	inline GameObject_t1756533147 * get_NextButton_24() const { return ___NextButton_24; }
	inline GameObject_t1756533147 ** get_address_of_NextButton_24() { return &___NextButton_24; }
	inline void set_NextButton_24(GameObject_t1756533147 * value)
	{
		___NextButton_24 = value;
		Il2CppCodeGenWriteBarrier(&___NextButton_24, value);
	}

	inline static int32_t get_offset_of_PrevButton_25() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___PrevButton_25)); }
	inline GameObject_t1756533147 * get_PrevButton_25() const { return ___PrevButton_25; }
	inline GameObject_t1756533147 ** get_address_of_PrevButton_25() { return &___PrevButton_25; }
	inline void set_PrevButton_25(GameObject_t1756533147 * value)
	{
		___PrevButton_25 = value;
		Il2CppCodeGenWriteBarrier(&___PrevButton_25, value);
	}

	inline static int32_t get_offset_of_transitionSpeed_26() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___transitionSpeed_26)); }
	inline float get_transitionSpeed_26() const { return ___transitionSpeed_26; }
	inline float* get_address_of_transitionSpeed_26() { return &___transitionSpeed_26; }
	inline void set_transitionSpeed_26(float value)
	{
		___transitionSpeed_26 = value;
	}

	inline static int32_t get_offset_of_UseFastSwipe_27() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___UseFastSwipe_27)); }
	inline bool get_UseFastSwipe_27() const { return ___UseFastSwipe_27; }
	inline bool* get_address_of_UseFastSwipe_27() { return &___UseFastSwipe_27; }
	inline void set_UseFastSwipe_27(bool value)
	{
		___UseFastSwipe_27 = value;
	}

	inline static int32_t get_offset_of_FastSwipeThreshold_28() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___FastSwipeThreshold_28)); }
	inline int32_t get_FastSwipeThreshold_28() const { return ___FastSwipeThreshold_28; }
	inline int32_t* get_address_of_FastSwipeThreshold_28() { return &___FastSwipeThreshold_28; }
	inline void set_FastSwipeThreshold_28(int32_t value)
	{
		___FastSwipeThreshold_28 = value;
	}

	inline static int32_t get_offset_of_SwipeVelocityThreshold_29() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___SwipeVelocityThreshold_29)); }
	inline int32_t get_SwipeVelocityThreshold_29() const { return ___SwipeVelocityThreshold_29; }
	inline int32_t* get_address_of_SwipeVelocityThreshold_29() { return &___SwipeVelocityThreshold_29; }
	inline void set_SwipeVelocityThreshold_29(int32_t value)
	{
		___SwipeVelocityThreshold_29 = value;
	}

	inline static int32_t get_offset_of_MaskArea_30() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___MaskArea_30)); }
	inline RectTransform_t3349966182 * get_MaskArea_30() const { return ___MaskArea_30; }
	inline RectTransform_t3349966182 ** get_address_of_MaskArea_30() { return &___MaskArea_30; }
	inline void set_MaskArea_30(RectTransform_t3349966182 * value)
	{
		___MaskArea_30 = value;
		Il2CppCodeGenWriteBarrier(&___MaskArea_30, value);
	}

	inline static int32_t get_offset_of_MaskBuffer_31() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___MaskBuffer_31)); }
	inline float get_MaskBuffer_31() const { return ___MaskBuffer_31; }
	inline float* get_address_of_MaskBuffer_31() { return &___MaskBuffer_31; }
	inline void set_MaskBuffer_31(float value)
	{
		___MaskBuffer_31 = value;
	}

	inline static int32_t get_offset_of_UseParentTransform_32() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___UseParentTransform_32)); }
	inline bool get_UseParentTransform_32() const { return ___UseParentTransform_32; }
	inline bool* get_address_of_UseParentTransform_32() { return &___UseParentTransform_32; }
	inline void set_UseParentTransform_32(bool value)
	{
		___UseParentTransform_32 = value;
	}

	inline static int32_t get_offset_of_ChildObjects_33() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___ChildObjects_33)); }
	inline GameObjectU5BU5D_t3057952154* get_ChildObjects_33() const { return ___ChildObjects_33; }
	inline GameObjectU5BU5D_t3057952154** get_address_of_ChildObjects_33() { return &___ChildObjects_33; }
	inline void set_ChildObjects_33(GameObjectU5BU5D_t3057952154* value)
	{
		___ChildObjects_33 = value;
		Il2CppCodeGenWriteBarrier(&___ChildObjects_33, value);
	}

	inline static int32_t get_offset_of_m_OnSelectionChangeStartEvent_34() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___m_OnSelectionChangeStartEvent_34)); }
	inline SelectionChangeStartEvent_t1331424750 * get_m_OnSelectionChangeStartEvent_34() const { return ___m_OnSelectionChangeStartEvent_34; }
	inline SelectionChangeStartEvent_t1331424750 ** get_address_of_m_OnSelectionChangeStartEvent_34() { return &___m_OnSelectionChangeStartEvent_34; }
	inline void set_m_OnSelectionChangeStartEvent_34(SelectionChangeStartEvent_t1331424750 * value)
	{
		___m_OnSelectionChangeStartEvent_34 = value;
		Il2CppCodeGenWriteBarrier(&___m_OnSelectionChangeStartEvent_34, value);
	}

	inline static int32_t get_offset_of_m_OnSelectionPageChangedEvent_35() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___m_OnSelectionPageChangedEvent_35)); }
	inline SelectionPageChangedEvent_t3967268665 * get_m_OnSelectionPageChangedEvent_35() const { return ___m_OnSelectionPageChangedEvent_35; }
	inline SelectionPageChangedEvent_t3967268665 ** get_address_of_m_OnSelectionPageChangedEvent_35() { return &___m_OnSelectionPageChangedEvent_35; }
	inline void set_m_OnSelectionPageChangedEvent_35(SelectionPageChangedEvent_t3967268665 * value)
	{
		___m_OnSelectionPageChangedEvent_35 = value;
		Il2CppCodeGenWriteBarrier(&___m_OnSelectionPageChangedEvent_35, value);
	}

	inline static int32_t get_offset_of_m_OnSelectionChangeEndEvent_36() { return static_cast<int32_t>(offsetof(ScrollSnapBase_t805675194, ___m_OnSelectionChangeEndEvent_36)); }
	inline SelectionChangeEndEvent_t3994187929 * get_m_OnSelectionChangeEndEvent_36() const { return ___m_OnSelectionChangeEndEvent_36; }
	inline SelectionChangeEndEvent_t3994187929 ** get_address_of_m_OnSelectionChangeEndEvent_36() { return &___m_OnSelectionChangeEndEvent_36; }
	inline void set_m_OnSelectionChangeEndEvent_36(SelectionChangeEndEvent_t3994187929 * value)
	{
		___m_OnSelectionChangeEndEvent_36 = value;
		Il2CppCodeGenWriteBarrier(&___m_OnSelectionChangeEndEvent_36, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
