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
// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.GameObject[]
struct GameObjectU5BU5D_t3057952154;
// UnityEngine.UI.Extensions.UIVerticalScroller
struct UIVerticalScroller_t1840308474;
// UnityEngine.UI.InputField
struct InputField_t1631627530;
// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ScrollingCalendar
struct  ScrollingCalendar_t976646069  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.RectTransform ScrollingCalendar::monthsScrollingPanel
	RectTransform_t3349966182 * ___monthsScrollingPanel_2;
	// UnityEngine.RectTransform ScrollingCalendar::yearsScrollingPanel
	RectTransform_t3349966182 * ___yearsScrollingPanel_3;
	// UnityEngine.RectTransform ScrollingCalendar::daysScrollingPanel
	RectTransform_t3349966182 * ___daysScrollingPanel_4;
	// UnityEngine.GameObject ScrollingCalendar::yearsButtonPrefab
	GameObject_t1756533147 * ___yearsButtonPrefab_5;
	// UnityEngine.GameObject ScrollingCalendar::monthsButtonPrefab
	GameObject_t1756533147 * ___monthsButtonPrefab_6;
	// UnityEngine.GameObject ScrollingCalendar::daysButtonPrefab
	GameObject_t1756533147 * ___daysButtonPrefab_7;
	// UnityEngine.GameObject[] ScrollingCalendar::monthsButtons
	GameObjectU5BU5D_t3057952154* ___monthsButtons_8;
	// UnityEngine.GameObject[] ScrollingCalendar::yearsButtons
	GameObjectU5BU5D_t3057952154* ___yearsButtons_9;
	// UnityEngine.GameObject[] ScrollingCalendar::daysButtons
	GameObjectU5BU5D_t3057952154* ___daysButtons_10;
	// UnityEngine.RectTransform ScrollingCalendar::monthCenter
	RectTransform_t3349966182 * ___monthCenter_11;
	// UnityEngine.RectTransform ScrollingCalendar::yearsCenter
	RectTransform_t3349966182 * ___yearsCenter_12;
	// UnityEngine.RectTransform ScrollingCalendar::daysCenter
	RectTransform_t3349966182 * ___daysCenter_13;
	// UnityEngine.UI.Extensions.UIVerticalScroller ScrollingCalendar::yearsVerticalScroller
	UIVerticalScroller_t1840308474 * ___yearsVerticalScroller_14;
	// UnityEngine.UI.Extensions.UIVerticalScroller ScrollingCalendar::monthsVerticalScroller
	UIVerticalScroller_t1840308474 * ___monthsVerticalScroller_15;
	// UnityEngine.UI.Extensions.UIVerticalScroller ScrollingCalendar::daysVerticalScroller
	UIVerticalScroller_t1840308474 * ___daysVerticalScroller_16;
	// UnityEngine.UI.InputField ScrollingCalendar::inputFieldDays
	InputField_t1631627530 * ___inputFieldDays_17;
	// UnityEngine.UI.InputField ScrollingCalendar::inputFieldMonths
	InputField_t1631627530 * ___inputFieldMonths_18;
	// UnityEngine.UI.InputField ScrollingCalendar::inputFieldYears
	InputField_t1631627530 * ___inputFieldYears_19;
	// UnityEngine.UI.Text ScrollingCalendar::dateText
	Text_t356221433 * ___dateText_20;
	// System.Int32 ScrollingCalendar::daysSet
	int32_t ___daysSet_21;
	// System.Int32 ScrollingCalendar::monthsSet
	int32_t ___monthsSet_22;
	// System.Int32 ScrollingCalendar::yearsSet
	int32_t ___yearsSet_23;

public:
	inline static int32_t get_offset_of_monthsScrollingPanel_2() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___monthsScrollingPanel_2)); }
	inline RectTransform_t3349966182 * get_monthsScrollingPanel_2() const { return ___monthsScrollingPanel_2; }
	inline RectTransform_t3349966182 ** get_address_of_monthsScrollingPanel_2() { return &___monthsScrollingPanel_2; }
	inline void set_monthsScrollingPanel_2(RectTransform_t3349966182 * value)
	{
		___monthsScrollingPanel_2 = value;
		Il2CppCodeGenWriteBarrier(&___monthsScrollingPanel_2, value);
	}

	inline static int32_t get_offset_of_yearsScrollingPanel_3() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___yearsScrollingPanel_3)); }
	inline RectTransform_t3349966182 * get_yearsScrollingPanel_3() const { return ___yearsScrollingPanel_3; }
	inline RectTransform_t3349966182 ** get_address_of_yearsScrollingPanel_3() { return &___yearsScrollingPanel_3; }
	inline void set_yearsScrollingPanel_3(RectTransform_t3349966182 * value)
	{
		___yearsScrollingPanel_3 = value;
		Il2CppCodeGenWriteBarrier(&___yearsScrollingPanel_3, value);
	}

	inline static int32_t get_offset_of_daysScrollingPanel_4() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___daysScrollingPanel_4)); }
	inline RectTransform_t3349966182 * get_daysScrollingPanel_4() const { return ___daysScrollingPanel_4; }
	inline RectTransform_t3349966182 ** get_address_of_daysScrollingPanel_4() { return &___daysScrollingPanel_4; }
	inline void set_daysScrollingPanel_4(RectTransform_t3349966182 * value)
	{
		___daysScrollingPanel_4 = value;
		Il2CppCodeGenWriteBarrier(&___daysScrollingPanel_4, value);
	}

	inline static int32_t get_offset_of_yearsButtonPrefab_5() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___yearsButtonPrefab_5)); }
	inline GameObject_t1756533147 * get_yearsButtonPrefab_5() const { return ___yearsButtonPrefab_5; }
	inline GameObject_t1756533147 ** get_address_of_yearsButtonPrefab_5() { return &___yearsButtonPrefab_5; }
	inline void set_yearsButtonPrefab_5(GameObject_t1756533147 * value)
	{
		___yearsButtonPrefab_5 = value;
		Il2CppCodeGenWriteBarrier(&___yearsButtonPrefab_5, value);
	}

	inline static int32_t get_offset_of_monthsButtonPrefab_6() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___monthsButtonPrefab_6)); }
	inline GameObject_t1756533147 * get_monthsButtonPrefab_6() const { return ___monthsButtonPrefab_6; }
	inline GameObject_t1756533147 ** get_address_of_monthsButtonPrefab_6() { return &___monthsButtonPrefab_6; }
	inline void set_monthsButtonPrefab_6(GameObject_t1756533147 * value)
	{
		___monthsButtonPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___monthsButtonPrefab_6, value);
	}

	inline static int32_t get_offset_of_daysButtonPrefab_7() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___daysButtonPrefab_7)); }
	inline GameObject_t1756533147 * get_daysButtonPrefab_7() const { return ___daysButtonPrefab_7; }
	inline GameObject_t1756533147 ** get_address_of_daysButtonPrefab_7() { return &___daysButtonPrefab_7; }
	inline void set_daysButtonPrefab_7(GameObject_t1756533147 * value)
	{
		___daysButtonPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___daysButtonPrefab_7, value);
	}

	inline static int32_t get_offset_of_monthsButtons_8() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___monthsButtons_8)); }
	inline GameObjectU5BU5D_t3057952154* get_monthsButtons_8() const { return ___monthsButtons_8; }
	inline GameObjectU5BU5D_t3057952154** get_address_of_monthsButtons_8() { return &___monthsButtons_8; }
	inline void set_monthsButtons_8(GameObjectU5BU5D_t3057952154* value)
	{
		___monthsButtons_8 = value;
		Il2CppCodeGenWriteBarrier(&___monthsButtons_8, value);
	}

	inline static int32_t get_offset_of_yearsButtons_9() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___yearsButtons_9)); }
	inline GameObjectU5BU5D_t3057952154* get_yearsButtons_9() const { return ___yearsButtons_9; }
	inline GameObjectU5BU5D_t3057952154** get_address_of_yearsButtons_9() { return &___yearsButtons_9; }
	inline void set_yearsButtons_9(GameObjectU5BU5D_t3057952154* value)
	{
		___yearsButtons_9 = value;
		Il2CppCodeGenWriteBarrier(&___yearsButtons_9, value);
	}

	inline static int32_t get_offset_of_daysButtons_10() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___daysButtons_10)); }
	inline GameObjectU5BU5D_t3057952154* get_daysButtons_10() const { return ___daysButtons_10; }
	inline GameObjectU5BU5D_t3057952154** get_address_of_daysButtons_10() { return &___daysButtons_10; }
	inline void set_daysButtons_10(GameObjectU5BU5D_t3057952154* value)
	{
		___daysButtons_10 = value;
		Il2CppCodeGenWriteBarrier(&___daysButtons_10, value);
	}

	inline static int32_t get_offset_of_monthCenter_11() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___monthCenter_11)); }
	inline RectTransform_t3349966182 * get_monthCenter_11() const { return ___monthCenter_11; }
	inline RectTransform_t3349966182 ** get_address_of_monthCenter_11() { return &___monthCenter_11; }
	inline void set_monthCenter_11(RectTransform_t3349966182 * value)
	{
		___monthCenter_11 = value;
		Il2CppCodeGenWriteBarrier(&___monthCenter_11, value);
	}

	inline static int32_t get_offset_of_yearsCenter_12() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___yearsCenter_12)); }
	inline RectTransform_t3349966182 * get_yearsCenter_12() const { return ___yearsCenter_12; }
	inline RectTransform_t3349966182 ** get_address_of_yearsCenter_12() { return &___yearsCenter_12; }
	inline void set_yearsCenter_12(RectTransform_t3349966182 * value)
	{
		___yearsCenter_12 = value;
		Il2CppCodeGenWriteBarrier(&___yearsCenter_12, value);
	}

	inline static int32_t get_offset_of_daysCenter_13() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___daysCenter_13)); }
	inline RectTransform_t3349966182 * get_daysCenter_13() const { return ___daysCenter_13; }
	inline RectTransform_t3349966182 ** get_address_of_daysCenter_13() { return &___daysCenter_13; }
	inline void set_daysCenter_13(RectTransform_t3349966182 * value)
	{
		___daysCenter_13 = value;
		Il2CppCodeGenWriteBarrier(&___daysCenter_13, value);
	}

	inline static int32_t get_offset_of_yearsVerticalScroller_14() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___yearsVerticalScroller_14)); }
	inline UIVerticalScroller_t1840308474 * get_yearsVerticalScroller_14() const { return ___yearsVerticalScroller_14; }
	inline UIVerticalScroller_t1840308474 ** get_address_of_yearsVerticalScroller_14() { return &___yearsVerticalScroller_14; }
	inline void set_yearsVerticalScroller_14(UIVerticalScroller_t1840308474 * value)
	{
		___yearsVerticalScroller_14 = value;
		Il2CppCodeGenWriteBarrier(&___yearsVerticalScroller_14, value);
	}

	inline static int32_t get_offset_of_monthsVerticalScroller_15() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___monthsVerticalScroller_15)); }
	inline UIVerticalScroller_t1840308474 * get_monthsVerticalScroller_15() const { return ___monthsVerticalScroller_15; }
	inline UIVerticalScroller_t1840308474 ** get_address_of_monthsVerticalScroller_15() { return &___monthsVerticalScroller_15; }
	inline void set_monthsVerticalScroller_15(UIVerticalScroller_t1840308474 * value)
	{
		___monthsVerticalScroller_15 = value;
		Il2CppCodeGenWriteBarrier(&___monthsVerticalScroller_15, value);
	}

	inline static int32_t get_offset_of_daysVerticalScroller_16() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___daysVerticalScroller_16)); }
	inline UIVerticalScroller_t1840308474 * get_daysVerticalScroller_16() const { return ___daysVerticalScroller_16; }
	inline UIVerticalScroller_t1840308474 ** get_address_of_daysVerticalScroller_16() { return &___daysVerticalScroller_16; }
	inline void set_daysVerticalScroller_16(UIVerticalScroller_t1840308474 * value)
	{
		___daysVerticalScroller_16 = value;
		Il2CppCodeGenWriteBarrier(&___daysVerticalScroller_16, value);
	}

	inline static int32_t get_offset_of_inputFieldDays_17() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___inputFieldDays_17)); }
	inline InputField_t1631627530 * get_inputFieldDays_17() const { return ___inputFieldDays_17; }
	inline InputField_t1631627530 ** get_address_of_inputFieldDays_17() { return &___inputFieldDays_17; }
	inline void set_inputFieldDays_17(InputField_t1631627530 * value)
	{
		___inputFieldDays_17 = value;
		Il2CppCodeGenWriteBarrier(&___inputFieldDays_17, value);
	}

	inline static int32_t get_offset_of_inputFieldMonths_18() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___inputFieldMonths_18)); }
	inline InputField_t1631627530 * get_inputFieldMonths_18() const { return ___inputFieldMonths_18; }
	inline InputField_t1631627530 ** get_address_of_inputFieldMonths_18() { return &___inputFieldMonths_18; }
	inline void set_inputFieldMonths_18(InputField_t1631627530 * value)
	{
		___inputFieldMonths_18 = value;
		Il2CppCodeGenWriteBarrier(&___inputFieldMonths_18, value);
	}

	inline static int32_t get_offset_of_inputFieldYears_19() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___inputFieldYears_19)); }
	inline InputField_t1631627530 * get_inputFieldYears_19() const { return ___inputFieldYears_19; }
	inline InputField_t1631627530 ** get_address_of_inputFieldYears_19() { return &___inputFieldYears_19; }
	inline void set_inputFieldYears_19(InputField_t1631627530 * value)
	{
		___inputFieldYears_19 = value;
		Il2CppCodeGenWriteBarrier(&___inputFieldYears_19, value);
	}

	inline static int32_t get_offset_of_dateText_20() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___dateText_20)); }
	inline Text_t356221433 * get_dateText_20() const { return ___dateText_20; }
	inline Text_t356221433 ** get_address_of_dateText_20() { return &___dateText_20; }
	inline void set_dateText_20(Text_t356221433 * value)
	{
		___dateText_20 = value;
		Il2CppCodeGenWriteBarrier(&___dateText_20, value);
	}

	inline static int32_t get_offset_of_daysSet_21() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___daysSet_21)); }
	inline int32_t get_daysSet_21() const { return ___daysSet_21; }
	inline int32_t* get_address_of_daysSet_21() { return &___daysSet_21; }
	inline void set_daysSet_21(int32_t value)
	{
		___daysSet_21 = value;
	}

	inline static int32_t get_offset_of_monthsSet_22() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___monthsSet_22)); }
	inline int32_t get_monthsSet_22() const { return ___monthsSet_22; }
	inline int32_t* get_address_of_monthsSet_22() { return &___monthsSet_22; }
	inline void set_monthsSet_22(int32_t value)
	{
		___monthsSet_22 = value;
	}

	inline static int32_t get_offset_of_yearsSet_23() { return static_cast<int32_t>(offsetof(ScrollingCalendar_t976646069, ___yearsSet_23)); }
	inline int32_t get_yearsSet_23() const { return ___yearsSet_23; }
	inline int32_t* get_address_of_yearsSet_23() { return &___yearsSet_23; }
	inline void set_yearsSet_23(int32_t value)
	{
		___yearsSet_23 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
