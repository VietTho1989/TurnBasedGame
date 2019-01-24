#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

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

// UnityEngine.UI.Extensions.UI_ScrollRectOcclusion
struct  UI_ScrollRectOcclusion_t1850795053  : public MonoBehaviour_t1158329972
{
public:
	// System.Boolean UnityEngine.UI.Extensions.UI_ScrollRectOcclusion::InitByUser
	bool ___InitByUser_2;
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.UI_ScrollRectOcclusion::_scrollRect
	ScrollRect_t1199013257 * ____scrollRect_3;
	// UnityEngine.UI.ContentSizeFitter UnityEngine.UI.Extensions.UI_ScrollRectOcclusion::_contentSizeFitter
	ContentSizeFitter_t1325211874 * ____contentSizeFitter_4;
	// UnityEngine.UI.VerticalLayoutGroup UnityEngine.UI.Extensions.UI_ScrollRectOcclusion::_verticalLayoutGroup
	VerticalLayoutGroup_t2468316403 * ____verticalLayoutGroup_5;
	// UnityEngine.UI.HorizontalLayoutGroup UnityEngine.UI.Extensions.UI_ScrollRectOcclusion::_horizontalLayoutGroup
	HorizontalLayoutGroup_t2875670365 * ____horizontalLayoutGroup_6;
	// UnityEngine.UI.GridLayoutGroup UnityEngine.UI.Extensions.UI_ScrollRectOcclusion::_gridLayoutGroup
	GridLayoutGroup_t1515633077 * ____gridLayoutGroup_7;
	// System.Boolean UnityEngine.UI.Extensions.UI_ScrollRectOcclusion::_isVertical
	bool ____isVertical_8;
	// System.Boolean UnityEngine.UI.Extensions.UI_ScrollRectOcclusion::_isHorizontal
	bool ____isHorizontal_9;
	// System.Single UnityEngine.UI.Extensions.UI_ScrollRectOcclusion::_disableMarginX
	float ____disableMarginX_10;
	// System.Single UnityEngine.UI.Extensions.UI_ScrollRectOcclusion::_disableMarginY
	float ____disableMarginY_11;
	// System.Boolean UnityEngine.UI.Extensions.UI_ScrollRectOcclusion::hasDisabledGridComponents
	bool ___hasDisabledGridComponents_12;
	// System.Collections.Generic.List`1<UnityEngine.RectTransform> UnityEngine.UI.Extensions.UI_ScrollRectOcclusion::items
	List_1_t2719087314 * ___items_13;

public:
	inline static int32_t get_offset_of_InitByUser_2() { return static_cast<int32_t>(offsetof(UI_ScrollRectOcclusion_t1850795053, ___InitByUser_2)); }
	inline bool get_InitByUser_2() const { return ___InitByUser_2; }
	inline bool* get_address_of_InitByUser_2() { return &___InitByUser_2; }
	inline void set_InitByUser_2(bool value)
	{
		___InitByUser_2 = value;
	}

	inline static int32_t get_offset_of__scrollRect_3() { return static_cast<int32_t>(offsetof(UI_ScrollRectOcclusion_t1850795053, ____scrollRect_3)); }
	inline ScrollRect_t1199013257 * get__scrollRect_3() const { return ____scrollRect_3; }
	inline ScrollRect_t1199013257 ** get_address_of__scrollRect_3() { return &____scrollRect_3; }
	inline void set__scrollRect_3(ScrollRect_t1199013257 * value)
	{
		____scrollRect_3 = value;
		Il2CppCodeGenWriteBarrier(&____scrollRect_3, value);
	}

	inline static int32_t get_offset_of__contentSizeFitter_4() { return static_cast<int32_t>(offsetof(UI_ScrollRectOcclusion_t1850795053, ____contentSizeFitter_4)); }
	inline ContentSizeFitter_t1325211874 * get__contentSizeFitter_4() const { return ____contentSizeFitter_4; }
	inline ContentSizeFitter_t1325211874 ** get_address_of__contentSizeFitter_4() { return &____contentSizeFitter_4; }
	inline void set__contentSizeFitter_4(ContentSizeFitter_t1325211874 * value)
	{
		____contentSizeFitter_4 = value;
		Il2CppCodeGenWriteBarrier(&____contentSizeFitter_4, value);
	}

	inline static int32_t get_offset_of__verticalLayoutGroup_5() { return static_cast<int32_t>(offsetof(UI_ScrollRectOcclusion_t1850795053, ____verticalLayoutGroup_5)); }
	inline VerticalLayoutGroup_t2468316403 * get__verticalLayoutGroup_5() const { return ____verticalLayoutGroup_5; }
	inline VerticalLayoutGroup_t2468316403 ** get_address_of__verticalLayoutGroup_5() { return &____verticalLayoutGroup_5; }
	inline void set__verticalLayoutGroup_5(VerticalLayoutGroup_t2468316403 * value)
	{
		____verticalLayoutGroup_5 = value;
		Il2CppCodeGenWriteBarrier(&____verticalLayoutGroup_5, value);
	}

	inline static int32_t get_offset_of__horizontalLayoutGroup_6() { return static_cast<int32_t>(offsetof(UI_ScrollRectOcclusion_t1850795053, ____horizontalLayoutGroup_6)); }
	inline HorizontalLayoutGroup_t2875670365 * get__horizontalLayoutGroup_6() const { return ____horizontalLayoutGroup_6; }
	inline HorizontalLayoutGroup_t2875670365 ** get_address_of__horizontalLayoutGroup_6() { return &____horizontalLayoutGroup_6; }
	inline void set__horizontalLayoutGroup_6(HorizontalLayoutGroup_t2875670365 * value)
	{
		____horizontalLayoutGroup_6 = value;
		Il2CppCodeGenWriteBarrier(&____horizontalLayoutGroup_6, value);
	}

	inline static int32_t get_offset_of__gridLayoutGroup_7() { return static_cast<int32_t>(offsetof(UI_ScrollRectOcclusion_t1850795053, ____gridLayoutGroup_7)); }
	inline GridLayoutGroup_t1515633077 * get__gridLayoutGroup_7() const { return ____gridLayoutGroup_7; }
	inline GridLayoutGroup_t1515633077 ** get_address_of__gridLayoutGroup_7() { return &____gridLayoutGroup_7; }
	inline void set__gridLayoutGroup_7(GridLayoutGroup_t1515633077 * value)
	{
		____gridLayoutGroup_7 = value;
		Il2CppCodeGenWriteBarrier(&____gridLayoutGroup_7, value);
	}

	inline static int32_t get_offset_of__isVertical_8() { return static_cast<int32_t>(offsetof(UI_ScrollRectOcclusion_t1850795053, ____isVertical_8)); }
	inline bool get__isVertical_8() const { return ____isVertical_8; }
	inline bool* get_address_of__isVertical_8() { return &____isVertical_8; }
	inline void set__isVertical_8(bool value)
	{
		____isVertical_8 = value;
	}

	inline static int32_t get_offset_of__isHorizontal_9() { return static_cast<int32_t>(offsetof(UI_ScrollRectOcclusion_t1850795053, ____isHorizontal_9)); }
	inline bool get__isHorizontal_9() const { return ____isHorizontal_9; }
	inline bool* get_address_of__isHorizontal_9() { return &____isHorizontal_9; }
	inline void set__isHorizontal_9(bool value)
	{
		____isHorizontal_9 = value;
	}

	inline static int32_t get_offset_of__disableMarginX_10() { return static_cast<int32_t>(offsetof(UI_ScrollRectOcclusion_t1850795053, ____disableMarginX_10)); }
	inline float get__disableMarginX_10() const { return ____disableMarginX_10; }
	inline float* get_address_of__disableMarginX_10() { return &____disableMarginX_10; }
	inline void set__disableMarginX_10(float value)
	{
		____disableMarginX_10 = value;
	}

	inline static int32_t get_offset_of__disableMarginY_11() { return static_cast<int32_t>(offsetof(UI_ScrollRectOcclusion_t1850795053, ____disableMarginY_11)); }
	inline float get__disableMarginY_11() const { return ____disableMarginY_11; }
	inline float* get_address_of__disableMarginY_11() { return &____disableMarginY_11; }
	inline void set__disableMarginY_11(float value)
	{
		____disableMarginY_11 = value;
	}

	inline static int32_t get_offset_of_hasDisabledGridComponents_12() { return static_cast<int32_t>(offsetof(UI_ScrollRectOcclusion_t1850795053, ___hasDisabledGridComponents_12)); }
	inline bool get_hasDisabledGridComponents_12() const { return ___hasDisabledGridComponents_12; }
	inline bool* get_address_of_hasDisabledGridComponents_12() { return &___hasDisabledGridComponents_12; }
	inline void set_hasDisabledGridComponents_12(bool value)
	{
		___hasDisabledGridComponents_12 = value;
	}

	inline static int32_t get_offset_of_items_13() { return static_cast<int32_t>(offsetof(UI_ScrollRectOcclusion_t1850795053, ___items_13)); }
	inline List_1_t2719087314 * get_items_13() const { return ___items_13; }
	inline List_1_t2719087314 ** get_address_of_items_13() { return &___items_13; }
	inline void set_items_13(List_1_t2719087314 * value)
	{
		___items_13 = value;
		Il2CppCodeGenWriteBarrier(&___items_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
