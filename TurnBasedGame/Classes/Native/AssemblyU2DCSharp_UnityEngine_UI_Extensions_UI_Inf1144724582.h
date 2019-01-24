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

// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;
// UnityEngine.UI.ContentSizeFitter
struct ContentSizeFitter_t1325211874;
// UnityEngine.UI.VerticalLayoutGroup
struct VerticalLayoutGroup_t2468316403;
// UnityEngine.UI.HorizontalLayoutGroup
struct HorizontalLayoutGroup_t2875670365;
// UnityEngine.UI.GridLayoutGroup
struct GridLayoutGroup_t1515633077;
// System.Collections.Generic.List`1<UnityEngine.RectTransform>
struct List_1_t2719087314;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UI_InfiniteScroll
struct  UI_InfiniteScroll_t1144724582  : public MonoBehaviour_t1158329972
{
public:
	// System.Boolean UnityEngine.UI.Extensions.UI_InfiniteScroll::InitByUser
	bool ___InitByUser_2;
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.UI_InfiniteScroll::_scrollRect
	ScrollRect_t1199013257 * ____scrollRect_3;
	// UnityEngine.UI.ContentSizeFitter UnityEngine.UI.Extensions.UI_InfiniteScroll::_contentSizeFitter
	ContentSizeFitter_t1325211874 * ____contentSizeFitter_4;
	// UnityEngine.UI.VerticalLayoutGroup UnityEngine.UI.Extensions.UI_InfiniteScroll::_verticalLayoutGroup
	VerticalLayoutGroup_t2468316403 * ____verticalLayoutGroup_5;
	// UnityEngine.UI.HorizontalLayoutGroup UnityEngine.UI.Extensions.UI_InfiniteScroll::_horizontalLayoutGroup
	HorizontalLayoutGroup_t2875670365 * ____horizontalLayoutGroup_6;
	// UnityEngine.UI.GridLayoutGroup UnityEngine.UI.Extensions.UI_InfiniteScroll::_gridLayoutGroup
	GridLayoutGroup_t1515633077 * ____gridLayoutGroup_7;
	// System.Boolean UnityEngine.UI.Extensions.UI_InfiniteScroll::_isVertical
	bool ____isVertical_8;
	// System.Boolean UnityEngine.UI.Extensions.UI_InfiniteScroll::_isHorizontal
	bool ____isHorizontal_9;
	// System.Single UnityEngine.UI.Extensions.UI_InfiniteScroll::_disableMarginX
	float ____disableMarginX_10;
	// System.Single UnityEngine.UI.Extensions.UI_InfiniteScroll::_disableMarginY
	float ____disableMarginY_11;
	// System.Boolean UnityEngine.UI.Extensions.UI_InfiniteScroll::_hasDisabledGridComponents
	bool ____hasDisabledGridComponents_12;
	// System.Collections.Generic.List`1<UnityEngine.RectTransform> UnityEngine.UI.Extensions.UI_InfiniteScroll::items
	List_1_t2719087314 * ___items_13;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.UI_InfiniteScroll::_newAnchoredPosition
	Vector2_t2243707579  ____newAnchoredPosition_14;
	// System.Single UnityEngine.UI.Extensions.UI_InfiniteScroll::_treshold
	float ____treshold_15;
	// System.Int32 UnityEngine.UI.Extensions.UI_InfiniteScroll::_itemCount
	int32_t ____itemCount_16;
	// System.Single UnityEngine.UI.Extensions.UI_InfiniteScroll::_recordOffsetX
	float ____recordOffsetX_17;
	// System.Single UnityEngine.UI.Extensions.UI_InfiniteScroll::_recordOffsetY
	float ____recordOffsetY_18;

public:
	inline static int32_t get_offset_of_InitByUser_2() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ___InitByUser_2)); }
	inline bool get_InitByUser_2() const { return ___InitByUser_2; }
	inline bool* get_address_of_InitByUser_2() { return &___InitByUser_2; }
	inline void set_InitByUser_2(bool value)
	{
		___InitByUser_2 = value;
	}

	inline static int32_t get_offset_of__scrollRect_3() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____scrollRect_3)); }
	inline ScrollRect_t1199013257 * get__scrollRect_3() const { return ____scrollRect_3; }
	inline ScrollRect_t1199013257 ** get_address_of__scrollRect_3() { return &____scrollRect_3; }
	inline void set__scrollRect_3(ScrollRect_t1199013257 * value)
	{
		____scrollRect_3 = value;
		Il2CppCodeGenWriteBarrier(&____scrollRect_3, value);
	}

	inline static int32_t get_offset_of__contentSizeFitter_4() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____contentSizeFitter_4)); }
	inline ContentSizeFitter_t1325211874 * get__contentSizeFitter_4() const { return ____contentSizeFitter_4; }
	inline ContentSizeFitter_t1325211874 ** get_address_of__contentSizeFitter_4() { return &____contentSizeFitter_4; }
	inline void set__contentSizeFitter_4(ContentSizeFitter_t1325211874 * value)
	{
		____contentSizeFitter_4 = value;
		Il2CppCodeGenWriteBarrier(&____contentSizeFitter_4, value);
	}

	inline static int32_t get_offset_of__verticalLayoutGroup_5() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____verticalLayoutGroup_5)); }
	inline VerticalLayoutGroup_t2468316403 * get__verticalLayoutGroup_5() const { return ____verticalLayoutGroup_5; }
	inline VerticalLayoutGroup_t2468316403 ** get_address_of__verticalLayoutGroup_5() { return &____verticalLayoutGroup_5; }
	inline void set__verticalLayoutGroup_5(VerticalLayoutGroup_t2468316403 * value)
	{
		____verticalLayoutGroup_5 = value;
		Il2CppCodeGenWriteBarrier(&____verticalLayoutGroup_5, value);
	}

	inline static int32_t get_offset_of__horizontalLayoutGroup_6() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____horizontalLayoutGroup_6)); }
	inline HorizontalLayoutGroup_t2875670365 * get__horizontalLayoutGroup_6() const { return ____horizontalLayoutGroup_6; }
	inline HorizontalLayoutGroup_t2875670365 ** get_address_of__horizontalLayoutGroup_6() { return &____horizontalLayoutGroup_6; }
	inline void set__horizontalLayoutGroup_6(HorizontalLayoutGroup_t2875670365 * value)
	{
		____horizontalLayoutGroup_6 = value;
		Il2CppCodeGenWriteBarrier(&____horizontalLayoutGroup_6, value);
	}

	inline static int32_t get_offset_of__gridLayoutGroup_7() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____gridLayoutGroup_7)); }
	inline GridLayoutGroup_t1515633077 * get__gridLayoutGroup_7() const { return ____gridLayoutGroup_7; }
	inline GridLayoutGroup_t1515633077 ** get_address_of__gridLayoutGroup_7() { return &____gridLayoutGroup_7; }
	inline void set__gridLayoutGroup_7(GridLayoutGroup_t1515633077 * value)
	{
		____gridLayoutGroup_7 = value;
		Il2CppCodeGenWriteBarrier(&____gridLayoutGroup_7, value);
	}

	inline static int32_t get_offset_of__isVertical_8() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____isVertical_8)); }
	inline bool get__isVertical_8() const { return ____isVertical_8; }
	inline bool* get_address_of__isVertical_8() { return &____isVertical_8; }
	inline void set__isVertical_8(bool value)
	{
		____isVertical_8 = value;
	}

	inline static int32_t get_offset_of__isHorizontal_9() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____isHorizontal_9)); }
	inline bool get__isHorizontal_9() const { return ____isHorizontal_9; }
	inline bool* get_address_of__isHorizontal_9() { return &____isHorizontal_9; }
	inline void set__isHorizontal_9(bool value)
	{
		____isHorizontal_9 = value;
	}

	inline static int32_t get_offset_of__disableMarginX_10() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____disableMarginX_10)); }
	inline float get__disableMarginX_10() const { return ____disableMarginX_10; }
	inline float* get_address_of__disableMarginX_10() { return &____disableMarginX_10; }
	inline void set__disableMarginX_10(float value)
	{
		____disableMarginX_10 = value;
	}

	inline static int32_t get_offset_of__disableMarginY_11() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____disableMarginY_11)); }
	inline float get__disableMarginY_11() const { return ____disableMarginY_11; }
	inline float* get_address_of__disableMarginY_11() { return &____disableMarginY_11; }
	inline void set__disableMarginY_11(float value)
	{
		____disableMarginY_11 = value;
	}

	inline static int32_t get_offset_of__hasDisabledGridComponents_12() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____hasDisabledGridComponents_12)); }
	inline bool get__hasDisabledGridComponents_12() const { return ____hasDisabledGridComponents_12; }
	inline bool* get_address_of__hasDisabledGridComponents_12() { return &____hasDisabledGridComponents_12; }
	inline void set__hasDisabledGridComponents_12(bool value)
	{
		____hasDisabledGridComponents_12 = value;
	}

	inline static int32_t get_offset_of_items_13() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ___items_13)); }
	inline List_1_t2719087314 * get_items_13() const { return ___items_13; }
	inline List_1_t2719087314 ** get_address_of_items_13() { return &___items_13; }
	inline void set_items_13(List_1_t2719087314 * value)
	{
		___items_13 = value;
		Il2CppCodeGenWriteBarrier(&___items_13, value);
	}

	inline static int32_t get_offset_of__newAnchoredPosition_14() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____newAnchoredPosition_14)); }
	inline Vector2_t2243707579  get__newAnchoredPosition_14() const { return ____newAnchoredPosition_14; }
	inline Vector2_t2243707579 * get_address_of__newAnchoredPosition_14() { return &____newAnchoredPosition_14; }
	inline void set__newAnchoredPosition_14(Vector2_t2243707579  value)
	{
		____newAnchoredPosition_14 = value;
	}

	inline static int32_t get_offset_of__treshold_15() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____treshold_15)); }
	inline float get__treshold_15() const { return ____treshold_15; }
	inline float* get_address_of__treshold_15() { return &____treshold_15; }
	inline void set__treshold_15(float value)
	{
		____treshold_15 = value;
	}

	inline static int32_t get_offset_of__itemCount_16() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____itemCount_16)); }
	inline int32_t get__itemCount_16() const { return ____itemCount_16; }
	inline int32_t* get_address_of__itemCount_16() { return &____itemCount_16; }
	inline void set__itemCount_16(int32_t value)
	{
		____itemCount_16 = value;
	}

	inline static int32_t get_offset_of__recordOffsetX_17() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____recordOffsetX_17)); }
	inline float get__recordOffsetX_17() const { return ____recordOffsetX_17; }
	inline float* get_address_of__recordOffsetX_17() { return &____recordOffsetX_17; }
	inline void set__recordOffsetX_17(float value)
	{
		____recordOffsetX_17 = value;
	}

	inline static int32_t get_offset_of__recordOffsetY_18() { return static_cast<int32_t>(offsetof(UI_InfiniteScroll_t1144724582, ____recordOffsetY_18)); }
	inline float get__recordOffsetY_18() const { return ____recordOffsetY_18; }
	inline float* get_address_of__recordOffsetY_18() { return &____recordOffsetY_18; }
	inline void set__recordOffsetY_18(float value)
	{
		____recordOffsetY_18 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
