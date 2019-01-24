#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_ScrollS778749221.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// UnityEngine.UI.Extensions.ScrollSnap/PageSnapChange
struct PageSnapChange_t737912504;
// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.Transform
struct Transform_t3275118058;
// UnityEngine.Vector3[]
struct Vector3U5BU5D_t1172311765;
// UnityEngine.UI.Button
struct Button_t2872111280;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ScrollSnap
struct  ScrollSnap_t2261190493  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Extensions.ScrollSnap/PageSnapChange UnityEngine.UI.Extensions.ScrollSnap::onPageChange
	PageSnapChange_t737912504 * ___onPageChange_2;
	// UnityEngine.UI.Extensions.ScrollSnap/ScrollDirection UnityEngine.UI.Extensions.ScrollSnap::direction
	int32_t ___direction_3;
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.ScrollSnap::scrollRect
	ScrollRect_t1199013257 * ___scrollRect_4;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ScrollSnap::scrollRectTransform
	RectTransform_t3349966182 * ___scrollRectTransform_5;
	// UnityEngine.Transform UnityEngine.UI.Extensions.ScrollSnap::listContainerTransform
	Transform_t3275118058 * ___listContainerTransform_6;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ScrollSnap::rectTransform
	RectTransform_t3349966182 * ___rectTransform_7;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnap::pages
	int32_t ___pages_8;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnap::startingPage
	int32_t ___startingPage_9;
	// UnityEngine.Vector3[] UnityEngine.UI.Extensions.ScrollSnap::pageAnchorPositions
	Vector3U5BU5D_t1172311765* ___pageAnchorPositions_10;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.ScrollSnap::lerpTarget
	Vector3_t2243707580  ___lerpTarget_11;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnap::lerp
	bool ___lerp_12;
	// System.Single UnityEngine.UI.Extensions.ScrollSnap::listContainerMinPosition
	float ___listContainerMinPosition_13;
	// System.Single UnityEngine.UI.Extensions.ScrollSnap::listContainerMaxPosition
	float ___listContainerMaxPosition_14;
	// System.Single UnityEngine.UI.Extensions.ScrollSnap::listContainerSize
	float ___listContainerSize_15;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ScrollSnap::listContainerRectTransform
	RectTransform_t3349966182 * ___listContainerRectTransform_16;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.ScrollSnap::listContainerCachedSize
	Vector2_t2243707579  ___listContainerCachedSize_17;
	// System.Single UnityEngine.UI.Extensions.ScrollSnap::itemSize
	float ___itemSize_18;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnap::itemsCount
	int32_t ___itemsCount_19;
	// UnityEngine.UI.Button UnityEngine.UI.Extensions.ScrollSnap::nextButton
	Button_t2872111280 * ___nextButton_20;
	// UnityEngine.UI.Button UnityEngine.UI.Extensions.ScrollSnap::prevButton
	Button_t2872111280 * ___prevButton_21;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnap::itemsVisibleAtOnce
	int32_t ___itemsVisibleAtOnce_22;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnap::autoLayoutItems
	bool ___autoLayoutItems_23;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnap::linkScrolbarSteps
	bool ___linkScrolbarSteps_24;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnap::linkScrolrectScrollSensitivity
	bool ___linkScrolrectScrollSensitivity_25;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnap::useFastSwipe
	bool ___useFastSwipe_26;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnap::fastSwipeThreshold
	int32_t ___fastSwipeThreshold_27;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnap::startDrag
	bool ___startDrag_28;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.ScrollSnap::positionOnDragStart
	Vector3_t2243707580  ___positionOnDragStart_29;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnap::pageOnDragStart
	int32_t ___pageOnDragStart_30;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnap::fastSwipeTimer
	bool ___fastSwipeTimer_31;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnap::fastSwipeCounter
	int32_t ___fastSwipeCounter_32;
	// System.Int32 UnityEngine.UI.Extensions.ScrollSnap::fastSwipeTarget
	int32_t ___fastSwipeTarget_33;
	// System.Boolean UnityEngine.UI.Extensions.ScrollSnap::fastSwipe
	bool ___fastSwipe_34;

public:
	inline static int32_t get_offset_of_onPageChange_2() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___onPageChange_2)); }
	inline PageSnapChange_t737912504 * get_onPageChange_2() const { return ___onPageChange_2; }
	inline PageSnapChange_t737912504 ** get_address_of_onPageChange_2() { return &___onPageChange_2; }
	inline void set_onPageChange_2(PageSnapChange_t737912504 * value)
	{
		___onPageChange_2 = value;
		Il2CppCodeGenWriteBarrier(&___onPageChange_2, value);
	}

	inline static int32_t get_offset_of_direction_3() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___direction_3)); }
	inline int32_t get_direction_3() const { return ___direction_3; }
	inline int32_t* get_address_of_direction_3() { return &___direction_3; }
	inline void set_direction_3(int32_t value)
	{
		___direction_3 = value;
	}

	inline static int32_t get_offset_of_scrollRect_4() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___scrollRect_4)); }
	inline ScrollRect_t1199013257 * get_scrollRect_4() const { return ___scrollRect_4; }
	inline ScrollRect_t1199013257 ** get_address_of_scrollRect_4() { return &___scrollRect_4; }
	inline void set_scrollRect_4(ScrollRect_t1199013257 * value)
	{
		___scrollRect_4 = value;
		Il2CppCodeGenWriteBarrier(&___scrollRect_4, value);
	}

	inline static int32_t get_offset_of_scrollRectTransform_5() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___scrollRectTransform_5)); }
	inline RectTransform_t3349966182 * get_scrollRectTransform_5() const { return ___scrollRectTransform_5; }
	inline RectTransform_t3349966182 ** get_address_of_scrollRectTransform_5() { return &___scrollRectTransform_5; }
	inline void set_scrollRectTransform_5(RectTransform_t3349966182 * value)
	{
		___scrollRectTransform_5 = value;
		Il2CppCodeGenWriteBarrier(&___scrollRectTransform_5, value);
	}

	inline static int32_t get_offset_of_listContainerTransform_6() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___listContainerTransform_6)); }
	inline Transform_t3275118058 * get_listContainerTransform_6() const { return ___listContainerTransform_6; }
	inline Transform_t3275118058 ** get_address_of_listContainerTransform_6() { return &___listContainerTransform_6; }
	inline void set_listContainerTransform_6(Transform_t3275118058 * value)
	{
		___listContainerTransform_6 = value;
		Il2CppCodeGenWriteBarrier(&___listContainerTransform_6, value);
	}

	inline static int32_t get_offset_of_rectTransform_7() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___rectTransform_7)); }
	inline RectTransform_t3349966182 * get_rectTransform_7() const { return ___rectTransform_7; }
	inline RectTransform_t3349966182 ** get_address_of_rectTransform_7() { return &___rectTransform_7; }
	inline void set_rectTransform_7(RectTransform_t3349966182 * value)
	{
		___rectTransform_7 = value;
		Il2CppCodeGenWriteBarrier(&___rectTransform_7, value);
	}

	inline static int32_t get_offset_of_pages_8() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___pages_8)); }
	inline int32_t get_pages_8() const { return ___pages_8; }
	inline int32_t* get_address_of_pages_8() { return &___pages_8; }
	inline void set_pages_8(int32_t value)
	{
		___pages_8 = value;
	}

	inline static int32_t get_offset_of_startingPage_9() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___startingPage_9)); }
	inline int32_t get_startingPage_9() const { return ___startingPage_9; }
	inline int32_t* get_address_of_startingPage_9() { return &___startingPage_9; }
	inline void set_startingPage_9(int32_t value)
	{
		___startingPage_9 = value;
	}

	inline static int32_t get_offset_of_pageAnchorPositions_10() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___pageAnchorPositions_10)); }
	inline Vector3U5BU5D_t1172311765* get_pageAnchorPositions_10() const { return ___pageAnchorPositions_10; }
	inline Vector3U5BU5D_t1172311765** get_address_of_pageAnchorPositions_10() { return &___pageAnchorPositions_10; }
	inline void set_pageAnchorPositions_10(Vector3U5BU5D_t1172311765* value)
	{
		___pageAnchorPositions_10 = value;
		Il2CppCodeGenWriteBarrier(&___pageAnchorPositions_10, value);
	}

	inline static int32_t get_offset_of_lerpTarget_11() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___lerpTarget_11)); }
	inline Vector3_t2243707580  get_lerpTarget_11() const { return ___lerpTarget_11; }
	inline Vector3_t2243707580 * get_address_of_lerpTarget_11() { return &___lerpTarget_11; }
	inline void set_lerpTarget_11(Vector3_t2243707580  value)
	{
		___lerpTarget_11 = value;
	}

	inline static int32_t get_offset_of_lerp_12() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___lerp_12)); }
	inline bool get_lerp_12() const { return ___lerp_12; }
	inline bool* get_address_of_lerp_12() { return &___lerp_12; }
	inline void set_lerp_12(bool value)
	{
		___lerp_12 = value;
	}

	inline static int32_t get_offset_of_listContainerMinPosition_13() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___listContainerMinPosition_13)); }
	inline float get_listContainerMinPosition_13() const { return ___listContainerMinPosition_13; }
	inline float* get_address_of_listContainerMinPosition_13() { return &___listContainerMinPosition_13; }
	inline void set_listContainerMinPosition_13(float value)
	{
		___listContainerMinPosition_13 = value;
	}

	inline static int32_t get_offset_of_listContainerMaxPosition_14() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___listContainerMaxPosition_14)); }
	inline float get_listContainerMaxPosition_14() const { return ___listContainerMaxPosition_14; }
	inline float* get_address_of_listContainerMaxPosition_14() { return &___listContainerMaxPosition_14; }
	inline void set_listContainerMaxPosition_14(float value)
	{
		___listContainerMaxPosition_14 = value;
	}

	inline static int32_t get_offset_of_listContainerSize_15() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___listContainerSize_15)); }
	inline float get_listContainerSize_15() const { return ___listContainerSize_15; }
	inline float* get_address_of_listContainerSize_15() { return &___listContainerSize_15; }
	inline void set_listContainerSize_15(float value)
	{
		___listContainerSize_15 = value;
	}

	inline static int32_t get_offset_of_listContainerRectTransform_16() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___listContainerRectTransform_16)); }
	inline RectTransform_t3349966182 * get_listContainerRectTransform_16() const { return ___listContainerRectTransform_16; }
	inline RectTransform_t3349966182 ** get_address_of_listContainerRectTransform_16() { return &___listContainerRectTransform_16; }
	inline void set_listContainerRectTransform_16(RectTransform_t3349966182 * value)
	{
		___listContainerRectTransform_16 = value;
		Il2CppCodeGenWriteBarrier(&___listContainerRectTransform_16, value);
	}

	inline static int32_t get_offset_of_listContainerCachedSize_17() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___listContainerCachedSize_17)); }
	inline Vector2_t2243707579  get_listContainerCachedSize_17() const { return ___listContainerCachedSize_17; }
	inline Vector2_t2243707579 * get_address_of_listContainerCachedSize_17() { return &___listContainerCachedSize_17; }
	inline void set_listContainerCachedSize_17(Vector2_t2243707579  value)
	{
		___listContainerCachedSize_17 = value;
	}

	inline static int32_t get_offset_of_itemSize_18() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___itemSize_18)); }
	inline float get_itemSize_18() const { return ___itemSize_18; }
	inline float* get_address_of_itemSize_18() { return &___itemSize_18; }
	inline void set_itemSize_18(float value)
	{
		___itemSize_18 = value;
	}

	inline static int32_t get_offset_of_itemsCount_19() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___itemsCount_19)); }
	inline int32_t get_itemsCount_19() const { return ___itemsCount_19; }
	inline int32_t* get_address_of_itemsCount_19() { return &___itemsCount_19; }
	inline void set_itemsCount_19(int32_t value)
	{
		___itemsCount_19 = value;
	}

	inline static int32_t get_offset_of_nextButton_20() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___nextButton_20)); }
	inline Button_t2872111280 * get_nextButton_20() const { return ___nextButton_20; }
	inline Button_t2872111280 ** get_address_of_nextButton_20() { return &___nextButton_20; }
	inline void set_nextButton_20(Button_t2872111280 * value)
	{
		___nextButton_20 = value;
		Il2CppCodeGenWriteBarrier(&___nextButton_20, value);
	}

	inline static int32_t get_offset_of_prevButton_21() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___prevButton_21)); }
	inline Button_t2872111280 * get_prevButton_21() const { return ___prevButton_21; }
	inline Button_t2872111280 ** get_address_of_prevButton_21() { return &___prevButton_21; }
	inline void set_prevButton_21(Button_t2872111280 * value)
	{
		___prevButton_21 = value;
		Il2CppCodeGenWriteBarrier(&___prevButton_21, value);
	}

	inline static int32_t get_offset_of_itemsVisibleAtOnce_22() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___itemsVisibleAtOnce_22)); }
	inline int32_t get_itemsVisibleAtOnce_22() const { return ___itemsVisibleAtOnce_22; }
	inline int32_t* get_address_of_itemsVisibleAtOnce_22() { return &___itemsVisibleAtOnce_22; }
	inline void set_itemsVisibleAtOnce_22(int32_t value)
	{
		___itemsVisibleAtOnce_22 = value;
	}

	inline static int32_t get_offset_of_autoLayoutItems_23() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___autoLayoutItems_23)); }
	inline bool get_autoLayoutItems_23() const { return ___autoLayoutItems_23; }
	inline bool* get_address_of_autoLayoutItems_23() { return &___autoLayoutItems_23; }
	inline void set_autoLayoutItems_23(bool value)
	{
		___autoLayoutItems_23 = value;
	}

	inline static int32_t get_offset_of_linkScrolbarSteps_24() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___linkScrolbarSteps_24)); }
	inline bool get_linkScrolbarSteps_24() const { return ___linkScrolbarSteps_24; }
	inline bool* get_address_of_linkScrolbarSteps_24() { return &___linkScrolbarSteps_24; }
	inline void set_linkScrolbarSteps_24(bool value)
	{
		___linkScrolbarSteps_24 = value;
	}

	inline static int32_t get_offset_of_linkScrolrectScrollSensitivity_25() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___linkScrolrectScrollSensitivity_25)); }
	inline bool get_linkScrolrectScrollSensitivity_25() const { return ___linkScrolrectScrollSensitivity_25; }
	inline bool* get_address_of_linkScrolrectScrollSensitivity_25() { return &___linkScrolrectScrollSensitivity_25; }
	inline void set_linkScrolrectScrollSensitivity_25(bool value)
	{
		___linkScrolrectScrollSensitivity_25 = value;
	}

	inline static int32_t get_offset_of_useFastSwipe_26() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___useFastSwipe_26)); }
	inline bool get_useFastSwipe_26() const { return ___useFastSwipe_26; }
	inline bool* get_address_of_useFastSwipe_26() { return &___useFastSwipe_26; }
	inline void set_useFastSwipe_26(bool value)
	{
		___useFastSwipe_26 = value;
	}

	inline static int32_t get_offset_of_fastSwipeThreshold_27() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___fastSwipeThreshold_27)); }
	inline int32_t get_fastSwipeThreshold_27() const { return ___fastSwipeThreshold_27; }
	inline int32_t* get_address_of_fastSwipeThreshold_27() { return &___fastSwipeThreshold_27; }
	inline void set_fastSwipeThreshold_27(int32_t value)
	{
		___fastSwipeThreshold_27 = value;
	}

	inline static int32_t get_offset_of_startDrag_28() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___startDrag_28)); }
	inline bool get_startDrag_28() const { return ___startDrag_28; }
	inline bool* get_address_of_startDrag_28() { return &___startDrag_28; }
	inline void set_startDrag_28(bool value)
	{
		___startDrag_28 = value;
	}

	inline static int32_t get_offset_of_positionOnDragStart_29() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___positionOnDragStart_29)); }
	inline Vector3_t2243707580  get_positionOnDragStart_29() const { return ___positionOnDragStart_29; }
	inline Vector3_t2243707580 * get_address_of_positionOnDragStart_29() { return &___positionOnDragStart_29; }
	inline void set_positionOnDragStart_29(Vector3_t2243707580  value)
	{
		___positionOnDragStart_29 = value;
	}

	inline static int32_t get_offset_of_pageOnDragStart_30() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___pageOnDragStart_30)); }
	inline int32_t get_pageOnDragStart_30() const { return ___pageOnDragStart_30; }
	inline int32_t* get_address_of_pageOnDragStart_30() { return &___pageOnDragStart_30; }
	inline void set_pageOnDragStart_30(int32_t value)
	{
		___pageOnDragStart_30 = value;
	}

	inline static int32_t get_offset_of_fastSwipeTimer_31() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___fastSwipeTimer_31)); }
	inline bool get_fastSwipeTimer_31() const { return ___fastSwipeTimer_31; }
	inline bool* get_address_of_fastSwipeTimer_31() { return &___fastSwipeTimer_31; }
	inline void set_fastSwipeTimer_31(bool value)
	{
		___fastSwipeTimer_31 = value;
	}

	inline static int32_t get_offset_of_fastSwipeCounter_32() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___fastSwipeCounter_32)); }
	inline int32_t get_fastSwipeCounter_32() const { return ___fastSwipeCounter_32; }
	inline int32_t* get_address_of_fastSwipeCounter_32() { return &___fastSwipeCounter_32; }
	inline void set_fastSwipeCounter_32(int32_t value)
	{
		___fastSwipeCounter_32 = value;
	}

	inline static int32_t get_offset_of_fastSwipeTarget_33() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___fastSwipeTarget_33)); }
	inline int32_t get_fastSwipeTarget_33() const { return ___fastSwipeTarget_33; }
	inline int32_t* get_address_of_fastSwipeTarget_33() { return &___fastSwipeTarget_33; }
	inline void set_fastSwipeTarget_33(int32_t value)
	{
		___fastSwipeTarget_33 = value;
	}

	inline static int32_t get_offset_of_fastSwipe_34() { return static_cast<int32_t>(offsetof(ScrollSnap_t2261190493, ___fastSwipe_34)); }
	inline bool get_fastSwipe_34() const { return ___fastSwipe_34; }
	inline bool* get_address_of_fastSwipe_34() { return &___fastSwipe_34; }
	inline void set_fastSwipe_34(bool value)
	{
		___fastSwipe_34 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
