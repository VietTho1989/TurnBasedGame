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
// UnityEngine.GameObject[]
struct GameObjectU5BU5D_t3057952154;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.Events.UnityEvent`1<System.Int32>
struct UnityEvent_1_t2110227463;
// System.Single[]
struct SingleU5BU5D_t577127397;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UIVerticalScroller
struct  UIVerticalScroller_t1840308474  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.UIVerticalScroller::_scrollingPanel
	RectTransform_t3349966182 * ____scrollingPanel_2;
	// UnityEngine.GameObject[] UnityEngine.UI.Extensions.UIVerticalScroller::_arrayOfElements
	GameObjectU5BU5D_t3057952154* ____arrayOfElements_3;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.UIVerticalScroller::_center
	RectTransform_t3349966182 * ____center_4;
	// System.Int32 UnityEngine.UI.Extensions.UIVerticalScroller::StartingIndex
	int32_t ___StartingIndex_5;
	// UnityEngine.GameObject UnityEngine.UI.Extensions.UIVerticalScroller::ScrollUpButton
	GameObject_t1756533147 * ___ScrollUpButton_6;
	// UnityEngine.GameObject UnityEngine.UI.Extensions.UIVerticalScroller::ScrollDownButton
	GameObject_t1756533147 * ___ScrollDownButton_7;
	// UnityEngine.Events.UnityEvent`1<System.Int32> UnityEngine.UI.Extensions.UIVerticalScroller::ButtonClicked
	UnityEvent_1_t2110227463 * ___ButtonClicked_8;
	// System.Single[] UnityEngine.UI.Extensions.UIVerticalScroller::distReposition
	SingleU5BU5D_t577127397* ___distReposition_9;
	// System.Single[] UnityEngine.UI.Extensions.UIVerticalScroller::distance
	SingleU5BU5D_t577127397* ___distance_10;
	// System.Int32 UnityEngine.UI.Extensions.UIVerticalScroller::minElementsNum
	int32_t ___minElementsNum_11;
	// System.Int32 UnityEngine.UI.Extensions.UIVerticalScroller::elementLength
	int32_t ___elementLength_12;
	// System.Single UnityEngine.UI.Extensions.UIVerticalScroller::deltaY
	float ___deltaY_13;
	// System.String UnityEngine.UI.Extensions.UIVerticalScroller::result
	String_t* ___result_14;

public:
	inline static int32_t get_offset_of__scrollingPanel_2() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ____scrollingPanel_2)); }
	inline RectTransform_t3349966182 * get__scrollingPanel_2() const { return ____scrollingPanel_2; }
	inline RectTransform_t3349966182 ** get_address_of__scrollingPanel_2() { return &____scrollingPanel_2; }
	inline void set__scrollingPanel_2(RectTransform_t3349966182 * value)
	{
		____scrollingPanel_2 = value;
		Il2CppCodeGenWriteBarrier(&____scrollingPanel_2, value);
	}

	inline static int32_t get_offset_of__arrayOfElements_3() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ____arrayOfElements_3)); }
	inline GameObjectU5BU5D_t3057952154* get__arrayOfElements_3() const { return ____arrayOfElements_3; }
	inline GameObjectU5BU5D_t3057952154** get_address_of__arrayOfElements_3() { return &____arrayOfElements_3; }
	inline void set__arrayOfElements_3(GameObjectU5BU5D_t3057952154* value)
	{
		____arrayOfElements_3 = value;
		Il2CppCodeGenWriteBarrier(&____arrayOfElements_3, value);
	}

	inline static int32_t get_offset_of__center_4() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ____center_4)); }
	inline RectTransform_t3349966182 * get__center_4() const { return ____center_4; }
	inline RectTransform_t3349966182 ** get_address_of__center_4() { return &____center_4; }
	inline void set__center_4(RectTransform_t3349966182 * value)
	{
		____center_4 = value;
		Il2CppCodeGenWriteBarrier(&____center_4, value);
	}

	inline static int32_t get_offset_of_StartingIndex_5() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ___StartingIndex_5)); }
	inline int32_t get_StartingIndex_5() const { return ___StartingIndex_5; }
	inline int32_t* get_address_of_StartingIndex_5() { return &___StartingIndex_5; }
	inline void set_StartingIndex_5(int32_t value)
	{
		___StartingIndex_5 = value;
	}

	inline static int32_t get_offset_of_ScrollUpButton_6() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ___ScrollUpButton_6)); }
	inline GameObject_t1756533147 * get_ScrollUpButton_6() const { return ___ScrollUpButton_6; }
	inline GameObject_t1756533147 ** get_address_of_ScrollUpButton_6() { return &___ScrollUpButton_6; }
	inline void set_ScrollUpButton_6(GameObject_t1756533147 * value)
	{
		___ScrollUpButton_6 = value;
		Il2CppCodeGenWriteBarrier(&___ScrollUpButton_6, value);
	}

	inline static int32_t get_offset_of_ScrollDownButton_7() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ___ScrollDownButton_7)); }
	inline GameObject_t1756533147 * get_ScrollDownButton_7() const { return ___ScrollDownButton_7; }
	inline GameObject_t1756533147 ** get_address_of_ScrollDownButton_7() { return &___ScrollDownButton_7; }
	inline void set_ScrollDownButton_7(GameObject_t1756533147 * value)
	{
		___ScrollDownButton_7 = value;
		Il2CppCodeGenWriteBarrier(&___ScrollDownButton_7, value);
	}

	inline static int32_t get_offset_of_ButtonClicked_8() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ___ButtonClicked_8)); }
	inline UnityEvent_1_t2110227463 * get_ButtonClicked_8() const { return ___ButtonClicked_8; }
	inline UnityEvent_1_t2110227463 ** get_address_of_ButtonClicked_8() { return &___ButtonClicked_8; }
	inline void set_ButtonClicked_8(UnityEvent_1_t2110227463 * value)
	{
		___ButtonClicked_8 = value;
		Il2CppCodeGenWriteBarrier(&___ButtonClicked_8, value);
	}

	inline static int32_t get_offset_of_distReposition_9() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ___distReposition_9)); }
	inline SingleU5BU5D_t577127397* get_distReposition_9() const { return ___distReposition_9; }
	inline SingleU5BU5D_t577127397** get_address_of_distReposition_9() { return &___distReposition_9; }
	inline void set_distReposition_9(SingleU5BU5D_t577127397* value)
	{
		___distReposition_9 = value;
		Il2CppCodeGenWriteBarrier(&___distReposition_9, value);
	}

	inline static int32_t get_offset_of_distance_10() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ___distance_10)); }
	inline SingleU5BU5D_t577127397* get_distance_10() const { return ___distance_10; }
	inline SingleU5BU5D_t577127397** get_address_of_distance_10() { return &___distance_10; }
	inline void set_distance_10(SingleU5BU5D_t577127397* value)
	{
		___distance_10 = value;
		Il2CppCodeGenWriteBarrier(&___distance_10, value);
	}

	inline static int32_t get_offset_of_minElementsNum_11() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ___minElementsNum_11)); }
	inline int32_t get_minElementsNum_11() const { return ___minElementsNum_11; }
	inline int32_t* get_address_of_minElementsNum_11() { return &___minElementsNum_11; }
	inline void set_minElementsNum_11(int32_t value)
	{
		___minElementsNum_11 = value;
	}

	inline static int32_t get_offset_of_elementLength_12() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ___elementLength_12)); }
	inline int32_t get_elementLength_12() const { return ___elementLength_12; }
	inline int32_t* get_address_of_elementLength_12() { return &___elementLength_12; }
	inline void set_elementLength_12(int32_t value)
	{
		___elementLength_12 = value;
	}

	inline static int32_t get_offset_of_deltaY_13() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ___deltaY_13)); }
	inline float get_deltaY_13() const { return ___deltaY_13; }
	inline float* get_address_of_deltaY_13() { return &___deltaY_13; }
	inline void set_deltaY_13(float value)
	{
		___deltaY_13 = value;
	}

	inline static int32_t get_offset_of_result_14() { return static_cast<int32_t>(offsetof(UIVerticalScroller_t1840308474, ___result_14)); }
	inline String_t* get_result_14() const { return ___result_14; }
	inline String_t** get_address_of_result_14() { return &___result_14; }
	inline void set_result_14(String_t* value)
	{
		___result_14 = value;
		Il2CppCodeGenWriteBarrier(&___result_14, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
