#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.UI.Extensions.DropDownListItem
struct DropDownListItem_t1818608950;
// System.Collections.Generic.List`1<UnityEngine.UI.Extensions.DropDownListItem>
struct List_1_t1187730082;
// System.Action`1<System.Int32>
struct Action_1_t1873676830;
// UnityEngine.UI.Extensions.DropDownListButton
struct DropDownListButton_t188411761;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.Canvas
struct Canvas_t209405766;
// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;
// System.Collections.Generic.List`1<UnityEngine.UI.Extensions.DropDownListButton>
struct List_1_t3852500189;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.DropDownList
struct  DropDownList_t2509108757  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Color UnityEngine.UI.Extensions.DropDownList::disabledTextColor
	Color_t2020392075  ___disabledTextColor_2;
	// UnityEngine.UI.Extensions.DropDownListItem UnityEngine.UI.Extensions.DropDownList::<SelectedItem>k__BackingField
	DropDownListItem_t1818608950 * ___U3CSelectedItemU3Ek__BackingField_3;
	// System.Collections.Generic.List`1<UnityEngine.UI.Extensions.DropDownListItem> UnityEngine.UI.Extensions.DropDownList::Items
	List_1_t1187730082 * ___Items_4;
	// System.Action`1<System.Int32> UnityEngine.UI.Extensions.DropDownList::OnSelectionChanged
	Action_1_t1873676830 * ___OnSelectionChanged_5;
	// System.Boolean UnityEngine.UI.Extensions.DropDownList::OverrideHighlighted
	bool ___OverrideHighlighted_6;
	// System.Boolean UnityEngine.UI.Extensions.DropDownList::_isPanelActive
	bool ____isPanelActive_7;
	// System.Boolean UnityEngine.UI.Extensions.DropDownList::_hasDrawnOnce
	bool ____hasDrawnOnce_8;
	// UnityEngine.UI.Extensions.DropDownListButton UnityEngine.UI.Extensions.DropDownList::_mainButton
	DropDownListButton_t188411761 * ____mainButton_9;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.DropDownList::_rectTransform
	RectTransform_t3349966182 * ____rectTransform_10;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.DropDownList::_overlayRT
	RectTransform_t3349966182 * ____overlayRT_11;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.DropDownList::_scrollPanelRT
	RectTransform_t3349966182 * ____scrollPanelRT_12;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.DropDownList::_scrollBarRT
	RectTransform_t3349966182 * ____scrollBarRT_13;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.DropDownList::_slidingAreaRT
	RectTransform_t3349966182 * ____slidingAreaRT_14;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.DropDownList::_itemsPanelRT
	RectTransform_t3349966182 * ____itemsPanelRT_15;
	// UnityEngine.Canvas UnityEngine.UI.Extensions.DropDownList::_canvas
	Canvas_t209405766 * ____canvas_16;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.DropDownList::_canvasRT
	RectTransform_t3349966182 * ____canvasRT_17;
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.DropDownList::_scrollRect
	ScrollRect_t1199013257 * ____scrollRect_18;
	// System.Collections.Generic.List`1<UnityEngine.UI.Extensions.DropDownListButton> UnityEngine.UI.Extensions.DropDownList::_panelItems
	List_1_t3852500189 * ____panelItems_19;
	// UnityEngine.GameObject UnityEngine.UI.Extensions.DropDownList::_itemTemplate
	GameObject_t1756533147 * ____itemTemplate_20;
	// System.Single UnityEngine.UI.Extensions.DropDownList::_scrollBarWidth
	float ____scrollBarWidth_21;
	// System.Int32 UnityEngine.UI.Extensions.DropDownList::_selectedIndex
	int32_t ____selectedIndex_22;
	// System.Int32 UnityEngine.UI.Extensions.DropDownList::_itemsToDisplay
	int32_t ____itemsToDisplay_23;

public:
	inline static int32_t get_offset_of_disabledTextColor_2() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ___disabledTextColor_2)); }
	inline Color_t2020392075  get_disabledTextColor_2() const { return ___disabledTextColor_2; }
	inline Color_t2020392075 * get_address_of_disabledTextColor_2() { return &___disabledTextColor_2; }
	inline void set_disabledTextColor_2(Color_t2020392075  value)
	{
		___disabledTextColor_2 = value;
	}

	inline static int32_t get_offset_of_U3CSelectedItemU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ___U3CSelectedItemU3Ek__BackingField_3)); }
	inline DropDownListItem_t1818608950 * get_U3CSelectedItemU3Ek__BackingField_3() const { return ___U3CSelectedItemU3Ek__BackingField_3; }
	inline DropDownListItem_t1818608950 ** get_address_of_U3CSelectedItemU3Ek__BackingField_3() { return &___U3CSelectedItemU3Ek__BackingField_3; }
	inline void set_U3CSelectedItemU3Ek__BackingField_3(DropDownListItem_t1818608950 * value)
	{
		___U3CSelectedItemU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CSelectedItemU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_Items_4() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ___Items_4)); }
	inline List_1_t1187730082 * get_Items_4() const { return ___Items_4; }
	inline List_1_t1187730082 ** get_address_of_Items_4() { return &___Items_4; }
	inline void set_Items_4(List_1_t1187730082 * value)
	{
		___Items_4 = value;
		Il2CppCodeGenWriteBarrier(&___Items_4, value);
	}

	inline static int32_t get_offset_of_OnSelectionChanged_5() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ___OnSelectionChanged_5)); }
	inline Action_1_t1873676830 * get_OnSelectionChanged_5() const { return ___OnSelectionChanged_5; }
	inline Action_1_t1873676830 ** get_address_of_OnSelectionChanged_5() { return &___OnSelectionChanged_5; }
	inline void set_OnSelectionChanged_5(Action_1_t1873676830 * value)
	{
		___OnSelectionChanged_5 = value;
		Il2CppCodeGenWriteBarrier(&___OnSelectionChanged_5, value);
	}

	inline static int32_t get_offset_of_OverrideHighlighted_6() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ___OverrideHighlighted_6)); }
	inline bool get_OverrideHighlighted_6() const { return ___OverrideHighlighted_6; }
	inline bool* get_address_of_OverrideHighlighted_6() { return &___OverrideHighlighted_6; }
	inline void set_OverrideHighlighted_6(bool value)
	{
		___OverrideHighlighted_6 = value;
	}

	inline static int32_t get_offset_of__isPanelActive_7() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____isPanelActive_7)); }
	inline bool get__isPanelActive_7() const { return ____isPanelActive_7; }
	inline bool* get_address_of__isPanelActive_7() { return &____isPanelActive_7; }
	inline void set__isPanelActive_7(bool value)
	{
		____isPanelActive_7 = value;
	}

	inline static int32_t get_offset_of__hasDrawnOnce_8() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____hasDrawnOnce_8)); }
	inline bool get__hasDrawnOnce_8() const { return ____hasDrawnOnce_8; }
	inline bool* get_address_of__hasDrawnOnce_8() { return &____hasDrawnOnce_8; }
	inline void set__hasDrawnOnce_8(bool value)
	{
		____hasDrawnOnce_8 = value;
	}

	inline static int32_t get_offset_of__mainButton_9() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____mainButton_9)); }
	inline DropDownListButton_t188411761 * get__mainButton_9() const { return ____mainButton_9; }
	inline DropDownListButton_t188411761 ** get_address_of__mainButton_9() { return &____mainButton_9; }
	inline void set__mainButton_9(DropDownListButton_t188411761 * value)
	{
		____mainButton_9 = value;
		Il2CppCodeGenWriteBarrier(&____mainButton_9, value);
	}

	inline static int32_t get_offset_of__rectTransform_10() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____rectTransform_10)); }
	inline RectTransform_t3349966182 * get__rectTransform_10() const { return ____rectTransform_10; }
	inline RectTransform_t3349966182 ** get_address_of__rectTransform_10() { return &____rectTransform_10; }
	inline void set__rectTransform_10(RectTransform_t3349966182 * value)
	{
		____rectTransform_10 = value;
		Il2CppCodeGenWriteBarrier(&____rectTransform_10, value);
	}

	inline static int32_t get_offset_of__overlayRT_11() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____overlayRT_11)); }
	inline RectTransform_t3349966182 * get__overlayRT_11() const { return ____overlayRT_11; }
	inline RectTransform_t3349966182 ** get_address_of__overlayRT_11() { return &____overlayRT_11; }
	inline void set__overlayRT_11(RectTransform_t3349966182 * value)
	{
		____overlayRT_11 = value;
		Il2CppCodeGenWriteBarrier(&____overlayRT_11, value);
	}

	inline static int32_t get_offset_of__scrollPanelRT_12() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____scrollPanelRT_12)); }
	inline RectTransform_t3349966182 * get__scrollPanelRT_12() const { return ____scrollPanelRT_12; }
	inline RectTransform_t3349966182 ** get_address_of__scrollPanelRT_12() { return &____scrollPanelRT_12; }
	inline void set__scrollPanelRT_12(RectTransform_t3349966182 * value)
	{
		____scrollPanelRT_12 = value;
		Il2CppCodeGenWriteBarrier(&____scrollPanelRT_12, value);
	}

	inline static int32_t get_offset_of__scrollBarRT_13() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____scrollBarRT_13)); }
	inline RectTransform_t3349966182 * get__scrollBarRT_13() const { return ____scrollBarRT_13; }
	inline RectTransform_t3349966182 ** get_address_of__scrollBarRT_13() { return &____scrollBarRT_13; }
	inline void set__scrollBarRT_13(RectTransform_t3349966182 * value)
	{
		____scrollBarRT_13 = value;
		Il2CppCodeGenWriteBarrier(&____scrollBarRT_13, value);
	}

	inline static int32_t get_offset_of__slidingAreaRT_14() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____slidingAreaRT_14)); }
	inline RectTransform_t3349966182 * get__slidingAreaRT_14() const { return ____slidingAreaRT_14; }
	inline RectTransform_t3349966182 ** get_address_of__slidingAreaRT_14() { return &____slidingAreaRT_14; }
	inline void set__slidingAreaRT_14(RectTransform_t3349966182 * value)
	{
		____slidingAreaRT_14 = value;
		Il2CppCodeGenWriteBarrier(&____slidingAreaRT_14, value);
	}

	inline static int32_t get_offset_of__itemsPanelRT_15() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____itemsPanelRT_15)); }
	inline RectTransform_t3349966182 * get__itemsPanelRT_15() const { return ____itemsPanelRT_15; }
	inline RectTransform_t3349966182 ** get_address_of__itemsPanelRT_15() { return &____itemsPanelRT_15; }
	inline void set__itemsPanelRT_15(RectTransform_t3349966182 * value)
	{
		____itemsPanelRT_15 = value;
		Il2CppCodeGenWriteBarrier(&____itemsPanelRT_15, value);
	}

	inline static int32_t get_offset_of__canvas_16() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____canvas_16)); }
	inline Canvas_t209405766 * get__canvas_16() const { return ____canvas_16; }
	inline Canvas_t209405766 ** get_address_of__canvas_16() { return &____canvas_16; }
	inline void set__canvas_16(Canvas_t209405766 * value)
	{
		____canvas_16 = value;
		Il2CppCodeGenWriteBarrier(&____canvas_16, value);
	}

	inline static int32_t get_offset_of__canvasRT_17() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____canvasRT_17)); }
	inline RectTransform_t3349966182 * get__canvasRT_17() const { return ____canvasRT_17; }
	inline RectTransform_t3349966182 ** get_address_of__canvasRT_17() { return &____canvasRT_17; }
	inline void set__canvasRT_17(RectTransform_t3349966182 * value)
	{
		____canvasRT_17 = value;
		Il2CppCodeGenWriteBarrier(&____canvasRT_17, value);
	}

	inline static int32_t get_offset_of__scrollRect_18() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____scrollRect_18)); }
	inline ScrollRect_t1199013257 * get__scrollRect_18() const { return ____scrollRect_18; }
	inline ScrollRect_t1199013257 ** get_address_of__scrollRect_18() { return &____scrollRect_18; }
	inline void set__scrollRect_18(ScrollRect_t1199013257 * value)
	{
		____scrollRect_18 = value;
		Il2CppCodeGenWriteBarrier(&____scrollRect_18, value);
	}

	inline static int32_t get_offset_of__panelItems_19() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____panelItems_19)); }
	inline List_1_t3852500189 * get__panelItems_19() const { return ____panelItems_19; }
	inline List_1_t3852500189 ** get_address_of__panelItems_19() { return &____panelItems_19; }
	inline void set__panelItems_19(List_1_t3852500189 * value)
	{
		____panelItems_19 = value;
		Il2CppCodeGenWriteBarrier(&____panelItems_19, value);
	}

	inline static int32_t get_offset_of__itemTemplate_20() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____itemTemplate_20)); }
	inline GameObject_t1756533147 * get__itemTemplate_20() const { return ____itemTemplate_20; }
	inline GameObject_t1756533147 ** get_address_of__itemTemplate_20() { return &____itemTemplate_20; }
	inline void set__itemTemplate_20(GameObject_t1756533147 * value)
	{
		____itemTemplate_20 = value;
		Il2CppCodeGenWriteBarrier(&____itemTemplate_20, value);
	}

	inline static int32_t get_offset_of__scrollBarWidth_21() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____scrollBarWidth_21)); }
	inline float get__scrollBarWidth_21() const { return ____scrollBarWidth_21; }
	inline float* get_address_of__scrollBarWidth_21() { return &____scrollBarWidth_21; }
	inline void set__scrollBarWidth_21(float value)
	{
		____scrollBarWidth_21 = value;
	}

	inline static int32_t get_offset_of__selectedIndex_22() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____selectedIndex_22)); }
	inline int32_t get__selectedIndex_22() const { return ____selectedIndex_22; }
	inline int32_t* get_address_of__selectedIndex_22() { return &____selectedIndex_22; }
	inline void set__selectedIndex_22(int32_t value)
	{
		____selectedIndex_22 = value;
	}

	inline static int32_t get_offset_of__itemsToDisplay_23() { return static_cast<int32_t>(offsetof(DropDownList_t2509108757, ____itemsToDisplay_23)); }
	inline int32_t get__itemsToDisplay_23() const { return ____itemsToDisplay_23; }
	inline int32_t* get_address_of__itemsToDisplay_23() { return &____itemsToDisplay_23; }
	inline void set__itemsToDisplay_23(int32_t value)
	{
		____itemsToDisplay_23 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
