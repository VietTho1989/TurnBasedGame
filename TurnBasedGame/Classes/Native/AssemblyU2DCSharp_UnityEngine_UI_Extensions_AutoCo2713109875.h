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
// System.Collections.Generic.List`1<System.String>
struct List_1_t1398341365;
// System.Action`1<System.Int32>
struct Action_1_t1873676830;
// UnityEngine.UI.InputField
struct InputField_t1631627530;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.Canvas
struct Canvas_t209405766;
// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;
// System.Collections.Generic.Dictionary`2<System.String,UnityEngine.GameObject>
struct Dictionary_2_t3671312409;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.AutoCompleteComboBox
struct  AutoCompleteComboBox_t2713109875  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Color UnityEngine.UI.Extensions.AutoCompleteComboBox::disabledTextColor
	Color_t2020392075  ___disabledTextColor_2;
	// UnityEngine.UI.Extensions.DropDownListItem UnityEngine.UI.Extensions.AutoCompleteComboBox::<SelectedItem>k__BackingField
	DropDownListItem_t1818608950 * ___U3CSelectedItemU3Ek__BackingField_3;
	// System.Collections.Generic.List`1<System.String> UnityEngine.UI.Extensions.AutoCompleteComboBox::AvailableOptions
	List_1_t1398341365 * ___AvailableOptions_4;
	// System.Action`1<System.Int32> UnityEngine.UI.Extensions.AutoCompleteComboBox::OnSelectionChanged
	Action_1_t1873676830 * ___OnSelectionChanged_5;
	// System.Boolean UnityEngine.UI.Extensions.AutoCompleteComboBox::_isPanelActive
	bool ____isPanelActive_6;
	// System.Boolean UnityEngine.UI.Extensions.AutoCompleteComboBox::_hasDrawnOnce
	bool ____hasDrawnOnce_7;
	// UnityEngine.UI.InputField UnityEngine.UI.Extensions.AutoCompleteComboBox::_mainInput
	InputField_t1631627530 * ____mainInput_8;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.AutoCompleteComboBox::_inputRT
	RectTransform_t3349966182 * ____inputRT_9;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.AutoCompleteComboBox::_rectTransform
	RectTransform_t3349966182 * ____rectTransform_10;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.AutoCompleteComboBox::_overlayRT
	RectTransform_t3349966182 * ____overlayRT_11;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.AutoCompleteComboBox::_scrollPanelRT
	RectTransform_t3349966182 * ____scrollPanelRT_12;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.AutoCompleteComboBox::_scrollBarRT
	RectTransform_t3349966182 * ____scrollBarRT_13;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.AutoCompleteComboBox::_slidingAreaRT
	RectTransform_t3349966182 * ____slidingAreaRT_14;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.AutoCompleteComboBox::_itemsPanelRT
	RectTransform_t3349966182 * ____itemsPanelRT_15;
	// UnityEngine.Canvas UnityEngine.UI.Extensions.AutoCompleteComboBox::_canvas
	Canvas_t209405766 * ____canvas_16;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.AutoCompleteComboBox::_canvasRT
	RectTransform_t3349966182 * ____canvasRT_17;
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.AutoCompleteComboBox::_scrollRect
	ScrollRect_t1199013257 * ____scrollRect_18;
	// System.Collections.Generic.List`1<System.String> UnityEngine.UI.Extensions.AutoCompleteComboBox::_panelItems
	List_1_t1398341365 * ____panelItems_19;
	// System.Collections.Generic.List`1<System.String> UnityEngine.UI.Extensions.AutoCompleteComboBox::_prunedPanelItems
	List_1_t1398341365 * ____prunedPanelItems_20;
	// System.Collections.Generic.Dictionary`2<System.String,UnityEngine.GameObject> UnityEngine.UI.Extensions.AutoCompleteComboBox::panelObjects
	Dictionary_2_t3671312409 * ___panelObjects_21;
	// UnityEngine.GameObject UnityEngine.UI.Extensions.AutoCompleteComboBox::itemTemplate
	GameObject_t1756533147 * ___itemTemplate_22;
	// System.String UnityEngine.UI.Extensions.AutoCompleteComboBox::<Text>k__BackingField
	String_t* ___U3CTextU3Ek__BackingField_23;
	// System.Single UnityEngine.UI.Extensions.AutoCompleteComboBox::_scrollBarWidth
	float ____scrollBarWidth_24;
	// System.Int32 UnityEngine.UI.Extensions.AutoCompleteComboBox::_itemsToDisplay
	int32_t ____itemsToDisplay_25;

public:
	inline static int32_t get_offset_of_disabledTextColor_2() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ___disabledTextColor_2)); }
	inline Color_t2020392075  get_disabledTextColor_2() const { return ___disabledTextColor_2; }
	inline Color_t2020392075 * get_address_of_disabledTextColor_2() { return &___disabledTextColor_2; }
	inline void set_disabledTextColor_2(Color_t2020392075  value)
	{
		___disabledTextColor_2 = value;
	}

	inline static int32_t get_offset_of_U3CSelectedItemU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ___U3CSelectedItemU3Ek__BackingField_3)); }
	inline DropDownListItem_t1818608950 * get_U3CSelectedItemU3Ek__BackingField_3() const { return ___U3CSelectedItemU3Ek__BackingField_3; }
	inline DropDownListItem_t1818608950 ** get_address_of_U3CSelectedItemU3Ek__BackingField_3() { return &___U3CSelectedItemU3Ek__BackingField_3; }
	inline void set_U3CSelectedItemU3Ek__BackingField_3(DropDownListItem_t1818608950 * value)
	{
		___U3CSelectedItemU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CSelectedItemU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_AvailableOptions_4() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ___AvailableOptions_4)); }
	inline List_1_t1398341365 * get_AvailableOptions_4() const { return ___AvailableOptions_4; }
	inline List_1_t1398341365 ** get_address_of_AvailableOptions_4() { return &___AvailableOptions_4; }
	inline void set_AvailableOptions_4(List_1_t1398341365 * value)
	{
		___AvailableOptions_4 = value;
		Il2CppCodeGenWriteBarrier(&___AvailableOptions_4, value);
	}

	inline static int32_t get_offset_of_OnSelectionChanged_5() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ___OnSelectionChanged_5)); }
	inline Action_1_t1873676830 * get_OnSelectionChanged_5() const { return ___OnSelectionChanged_5; }
	inline Action_1_t1873676830 ** get_address_of_OnSelectionChanged_5() { return &___OnSelectionChanged_5; }
	inline void set_OnSelectionChanged_5(Action_1_t1873676830 * value)
	{
		___OnSelectionChanged_5 = value;
		Il2CppCodeGenWriteBarrier(&___OnSelectionChanged_5, value);
	}

	inline static int32_t get_offset_of__isPanelActive_6() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____isPanelActive_6)); }
	inline bool get__isPanelActive_6() const { return ____isPanelActive_6; }
	inline bool* get_address_of__isPanelActive_6() { return &____isPanelActive_6; }
	inline void set__isPanelActive_6(bool value)
	{
		____isPanelActive_6 = value;
	}

	inline static int32_t get_offset_of__hasDrawnOnce_7() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____hasDrawnOnce_7)); }
	inline bool get__hasDrawnOnce_7() const { return ____hasDrawnOnce_7; }
	inline bool* get_address_of__hasDrawnOnce_7() { return &____hasDrawnOnce_7; }
	inline void set__hasDrawnOnce_7(bool value)
	{
		____hasDrawnOnce_7 = value;
	}

	inline static int32_t get_offset_of__mainInput_8() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____mainInput_8)); }
	inline InputField_t1631627530 * get__mainInput_8() const { return ____mainInput_8; }
	inline InputField_t1631627530 ** get_address_of__mainInput_8() { return &____mainInput_8; }
	inline void set__mainInput_8(InputField_t1631627530 * value)
	{
		____mainInput_8 = value;
		Il2CppCodeGenWriteBarrier(&____mainInput_8, value);
	}

	inline static int32_t get_offset_of__inputRT_9() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____inputRT_9)); }
	inline RectTransform_t3349966182 * get__inputRT_9() const { return ____inputRT_9; }
	inline RectTransform_t3349966182 ** get_address_of__inputRT_9() { return &____inputRT_9; }
	inline void set__inputRT_9(RectTransform_t3349966182 * value)
	{
		____inputRT_9 = value;
		Il2CppCodeGenWriteBarrier(&____inputRT_9, value);
	}

	inline static int32_t get_offset_of__rectTransform_10() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____rectTransform_10)); }
	inline RectTransform_t3349966182 * get__rectTransform_10() const { return ____rectTransform_10; }
	inline RectTransform_t3349966182 ** get_address_of__rectTransform_10() { return &____rectTransform_10; }
	inline void set__rectTransform_10(RectTransform_t3349966182 * value)
	{
		____rectTransform_10 = value;
		Il2CppCodeGenWriteBarrier(&____rectTransform_10, value);
	}

	inline static int32_t get_offset_of__overlayRT_11() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____overlayRT_11)); }
	inline RectTransform_t3349966182 * get__overlayRT_11() const { return ____overlayRT_11; }
	inline RectTransform_t3349966182 ** get_address_of__overlayRT_11() { return &____overlayRT_11; }
	inline void set__overlayRT_11(RectTransform_t3349966182 * value)
	{
		____overlayRT_11 = value;
		Il2CppCodeGenWriteBarrier(&____overlayRT_11, value);
	}

	inline static int32_t get_offset_of__scrollPanelRT_12() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____scrollPanelRT_12)); }
	inline RectTransform_t3349966182 * get__scrollPanelRT_12() const { return ____scrollPanelRT_12; }
	inline RectTransform_t3349966182 ** get_address_of__scrollPanelRT_12() { return &____scrollPanelRT_12; }
	inline void set__scrollPanelRT_12(RectTransform_t3349966182 * value)
	{
		____scrollPanelRT_12 = value;
		Il2CppCodeGenWriteBarrier(&____scrollPanelRT_12, value);
	}

	inline static int32_t get_offset_of__scrollBarRT_13() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____scrollBarRT_13)); }
	inline RectTransform_t3349966182 * get__scrollBarRT_13() const { return ____scrollBarRT_13; }
	inline RectTransform_t3349966182 ** get_address_of__scrollBarRT_13() { return &____scrollBarRT_13; }
	inline void set__scrollBarRT_13(RectTransform_t3349966182 * value)
	{
		____scrollBarRT_13 = value;
		Il2CppCodeGenWriteBarrier(&____scrollBarRT_13, value);
	}

	inline static int32_t get_offset_of__slidingAreaRT_14() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____slidingAreaRT_14)); }
	inline RectTransform_t3349966182 * get__slidingAreaRT_14() const { return ____slidingAreaRT_14; }
	inline RectTransform_t3349966182 ** get_address_of__slidingAreaRT_14() { return &____slidingAreaRT_14; }
	inline void set__slidingAreaRT_14(RectTransform_t3349966182 * value)
	{
		____slidingAreaRT_14 = value;
		Il2CppCodeGenWriteBarrier(&____slidingAreaRT_14, value);
	}

	inline static int32_t get_offset_of__itemsPanelRT_15() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____itemsPanelRT_15)); }
	inline RectTransform_t3349966182 * get__itemsPanelRT_15() const { return ____itemsPanelRT_15; }
	inline RectTransform_t3349966182 ** get_address_of__itemsPanelRT_15() { return &____itemsPanelRT_15; }
	inline void set__itemsPanelRT_15(RectTransform_t3349966182 * value)
	{
		____itemsPanelRT_15 = value;
		Il2CppCodeGenWriteBarrier(&____itemsPanelRT_15, value);
	}

	inline static int32_t get_offset_of__canvas_16() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____canvas_16)); }
	inline Canvas_t209405766 * get__canvas_16() const { return ____canvas_16; }
	inline Canvas_t209405766 ** get_address_of__canvas_16() { return &____canvas_16; }
	inline void set__canvas_16(Canvas_t209405766 * value)
	{
		____canvas_16 = value;
		Il2CppCodeGenWriteBarrier(&____canvas_16, value);
	}

	inline static int32_t get_offset_of__canvasRT_17() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____canvasRT_17)); }
	inline RectTransform_t3349966182 * get__canvasRT_17() const { return ____canvasRT_17; }
	inline RectTransform_t3349966182 ** get_address_of__canvasRT_17() { return &____canvasRT_17; }
	inline void set__canvasRT_17(RectTransform_t3349966182 * value)
	{
		____canvasRT_17 = value;
		Il2CppCodeGenWriteBarrier(&____canvasRT_17, value);
	}

	inline static int32_t get_offset_of__scrollRect_18() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____scrollRect_18)); }
	inline ScrollRect_t1199013257 * get__scrollRect_18() const { return ____scrollRect_18; }
	inline ScrollRect_t1199013257 ** get_address_of__scrollRect_18() { return &____scrollRect_18; }
	inline void set__scrollRect_18(ScrollRect_t1199013257 * value)
	{
		____scrollRect_18 = value;
		Il2CppCodeGenWriteBarrier(&____scrollRect_18, value);
	}

	inline static int32_t get_offset_of__panelItems_19() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____panelItems_19)); }
	inline List_1_t1398341365 * get__panelItems_19() const { return ____panelItems_19; }
	inline List_1_t1398341365 ** get_address_of__panelItems_19() { return &____panelItems_19; }
	inline void set__panelItems_19(List_1_t1398341365 * value)
	{
		____panelItems_19 = value;
		Il2CppCodeGenWriteBarrier(&____panelItems_19, value);
	}

	inline static int32_t get_offset_of__prunedPanelItems_20() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____prunedPanelItems_20)); }
	inline List_1_t1398341365 * get__prunedPanelItems_20() const { return ____prunedPanelItems_20; }
	inline List_1_t1398341365 ** get_address_of__prunedPanelItems_20() { return &____prunedPanelItems_20; }
	inline void set__prunedPanelItems_20(List_1_t1398341365 * value)
	{
		____prunedPanelItems_20 = value;
		Il2CppCodeGenWriteBarrier(&____prunedPanelItems_20, value);
	}

	inline static int32_t get_offset_of_panelObjects_21() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ___panelObjects_21)); }
	inline Dictionary_2_t3671312409 * get_panelObjects_21() const { return ___panelObjects_21; }
	inline Dictionary_2_t3671312409 ** get_address_of_panelObjects_21() { return &___panelObjects_21; }
	inline void set_panelObjects_21(Dictionary_2_t3671312409 * value)
	{
		___panelObjects_21 = value;
		Il2CppCodeGenWriteBarrier(&___panelObjects_21, value);
	}

	inline static int32_t get_offset_of_itemTemplate_22() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ___itemTemplate_22)); }
	inline GameObject_t1756533147 * get_itemTemplate_22() const { return ___itemTemplate_22; }
	inline GameObject_t1756533147 ** get_address_of_itemTemplate_22() { return &___itemTemplate_22; }
	inline void set_itemTemplate_22(GameObject_t1756533147 * value)
	{
		___itemTemplate_22 = value;
		Il2CppCodeGenWriteBarrier(&___itemTemplate_22, value);
	}

	inline static int32_t get_offset_of_U3CTextU3Ek__BackingField_23() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ___U3CTextU3Ek__BackingField_23)); }
	inline String_t* get_U3CTextU3Ek__BackingField_23() const { return ___U3CTextU3Ek__BackingField_23; }
	inline String_t** get_address_of_U3CTextU3Ek__BackingField_23() { return &___U3CTextU3Ek__BackingField_23; }
	inline void set_U3CTextU3Ek__BackingField_23(String_t* value)
	{
		___U3CTextU3Ek__BackingField_23 = value;
		Il2CppCodeGenWriteBarrier(&___U3CTextU3Ek__BackingField_23, value);
	}

	inline static int32_t get_offset_of__scrollBarWidth_24() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____scrollBarWidth_24)); }
	inline float get__scrollBarWidth_24() const { return ____scrollBarWidth_24; }
	inline float* get_address_of__scrollBarWidth_24() { return &____scrollBarWidth_24; }
	inline void set__scrollBarWidth_24(float value)
	{
		____scrollBarWidth_24 = value;
	}

	inline static int32_t get_offset_of__itemsToDisplay_25() { return static_cast<int32_t>(offsetof(AutoCompleteComboBox_t2713109875, ____itemsToDisplay_25)); }
	inline int32_t get__itemsToDisplay_25() const { return ____itemsToDisplay_25; }
	inline int32_t* get_address_of__itemsToDisplay_25() { return &____itemsToDisplay_25; }
	inline void set__itemsToDisplay_25(int32_t value)
	{
		____itemsToDisplay_25 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
