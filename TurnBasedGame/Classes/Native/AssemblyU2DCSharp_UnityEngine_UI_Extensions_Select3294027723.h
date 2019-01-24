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
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// UnityEngine.Sprite
struct Sprite_t309593783;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.UI.Extensions.IBoxSelectable[]
struct IBoxSelectableU5BU5D_t1290335761;
// UnityEngine.MonoBehaviour[]
struct MonoBehaviourU5BU5D_t3035069757;
// UnityEngine.UI.Extensions.IBoxSelectable
struct IBoxSelectable_t1633048368;
// UnityEngine.UI.Extensions.SelectionBox/SelectionEvent
struct SelectionEvent_t1038911497;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.SelectionBox
struct  SelectionBox_t3294027723  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Color UnityEngine.UI.Extensions.SelectionBox::color
	Color_t2020392075  ___color_2;
	// UnityEngine.Sprite UnityEngine.UI.Extensions.SelectionBox::art
	Sprite_t309593783 * ___art_3;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.SelectionBox::origin
	Vector2_t2243707579  ___origin_4;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.SelectionBox::selectionMask
	RectTransform_t3349966182 * ___selectionMask_5;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.SelectionBox::boxRect
	RectTransform_t3349966182 * ___boxRect_6;
	// UnityEngine.UI.Extensions.IBoxSelectable[] UnityEngine.UI.Extensions.SelectionBox::selectables
	IBoxSelectableU5BU5D_t1290335761* ___selectables_7;
	// UnityEngine.MonoBehaviour[] UnityEngine.UI.Extensions.SelectionBox::selectableGroup
	MonoBehaviourU5BU5D_t3035069757* ___selectableGroup_8;
	// UnityEngine.UI.Extensions.IBoxSelectable UnityEngine.UI.Extensions.SelectionBox::clickedBeforeDrag
	Il2CppObject * ___clickedBeforeDrag_9;
	// UnityEngine.UI.Extensions.IBoxSelectable UnityEngine.UI.Extensions.SelectionBox::clickedAfterDrag
	Il2CppObject * ___clickedAfterDrag_10;
	// UnityEngine.UI.Extensions.SelectionBox/SelectionEvent UnityEngine.UI.Extensions.SelectionBox::onSelectionChange
	SelectionEvent_t1038911497 * ___onSelectionChange_11;

public:
	inline static int32_t get_offset_of_color_2() { return static_cast<int32_t>(offsetof(SelectionBox_t3294027723, ___color_2)); }
	inline Color_t2020392075  get_color_2() const { return ___color_2; }
	inline Color_t2020392075 * get_address_of_color_2() { return &___color_2; }
	inline void set_color_2(Color_t2020392075  value)
	{
		___color_2 = value;
	}

	inline static int32_t get_offset_of_art_3() { return static_cast<int32_t>(offsetof(SelectionBox_t3294027723, ___art_3)); }
	inline Sprite_t309593783 * get_art_3() const { return ___art_3; }
	inline Sprite_t309593783 ** get_address_of_art_3() { return &___art_3; }
	inline void set_art_3(Sprite_t309593783 * value)
	{
		___art_3 = value;
		Il2CppCodeGenWriteBarrier(&___art_3, value);
	}

	inline static int32_t get_offset_of_origin_4() { return static_cast<int32_t>(offsetof(SelectionBox_t3294027723, ___origin_4)); }
	inline Vector2_t2243707579  get_origin_4() const { return ___origin_4; }
	inline Vector2_t2243707579 * get_address_of_origin_4() { return &___origin_4; }
	inline void set_origin_4(Vector2_t2243707579  value)
	{
		___origin_4 = value;
	}

	inline static int32_t get_offset_of_selectionMask_5() { return static_cast<int32_t>(offsetof(SelectionBox_t3294027723, ___selectionMask_5)); }
	inline RectTransform_t3349966182 * get_selectionMask_5() const { return ___selectionMask_5; }
	inline RectTransform_t3349966182 ** get_address_of_selectionMask_5() { return &___selectionMask_5; }
	inline void set_selectionMask_5(RectTransform_t3349966182 * value)
	{
		___selectionMask_5 = value;
		Il2CppCodeGenWriteBarrier(&___selectionMask_5, value);
	}

	inline static int32_t get_offset_of_boxRect_6() { return static_cast<int32_t>(offsetof(SelectionBox_t3294027723, ___boxRect_6)); }
	inline RectTransform_t3349966182 * get_boxRect_6() const { return ___boxRect_6; }
	inline RectTransform_t3349966182 ** get_address_of_boxRect_6() { return &___boxRect_6; }
	inline void set_boxRect_6(RectTransform_t3349966182 * value)
	{
		___boxRect_6 = value;
		Il2CppCodeGenWriteBarrier(&___boxRect_6, value);
	}

	inline static int32_t get_offset_of_selectables_7() { return static_cast<int32_t>(offsetof(SelectionBox_t3294027723, ___selectables_7)); }
	inline IBoxSelectableU5BU5D_t1290335761* get_selectables_7() const { return ___selectables_7; }
	inline IBoxSelectableU5BU5D_t1290335761** get_address_of_selectables_7() { return &___selectables_7; }
	inline void set_selectables_7(IBoxSelectableU5BU5D_t1290335761* value)
	{
		___selectables_7 = value;
		Il2CppCodeGenWriteBarrier(&___selectables_7, value);
	}

	inline static int32_t get_offset_of_selectableGroup_8() { return static_cast<int32_t>(offsetof(SelectionBox_t3294027723, ___selectableGroup_8)); }
	inline MonoBehaviourU5BU5D_t3035069757* get_selectableGroup_8() const { return ___selectableGroup_8; }
	inline MonoBehaviourU5BU5D_t3035069757** get_address_of_selectableGroup_8() { return &___selectableGroup_8; }
	inline void set_selectableGroup_8(MonoBehaviourU5BU5D_t3035069757* value)
	{
		___selectableGroup_8 = value;
		Il2CppCodeGenWriteBarrier(&___selectableGroup_8, value);
	}

	inline static int32_t get_offset_of_clickedBeforeDrag_9() { return static_cast<int32_t>(offsetof(SelectionBox_t3294027723, ___clickedBeforeDrag_9)); }
	inline Il2CppObject * get_clickedBeforeDrag_9() const { return ___clickedBeforeDrag_9; }
	inline Il2CppObject ** get_address_of_clickedBeforeDrag_9() { return &___clickedBeforeDrag_9; }
	inline void set_clickedBeforeDrag_9(Il2CppObject * value)
	{
		___clickedBeforeDrag_9 = value;
		Il2CppCodeGenWriteBarrier(&___clickedBeforeDrag_9, value);
	}

	inline static int32_t get_offset_of_clickedAfterDrag_10() { return static_cast<int32_t>(offsetof(SelectionBox_t3294027723, ___clickedAfterDrag_10)); }
	inline Il2CppObject * get_clickedAfterDrag_10() const { return ___clickedAfterDrag_10; }
	inline Il2CppObject ** get_address_of_clickedAfterDrag_10() { return &___clickedAfterDrag_10; }
	inline void set_clickedAfterDrag_10(Il2CppObject * value)
	{
		___clickedAfterDrag_10 = value;
		Il2CppCodeGenWriteBarrier(&___clickedAfterDrag_10, value);
	}

	inline static int32_t get_offset_of_onSelectionChange_11() { return static_cast<int32_t>(offsetof(SelectionBox_t3294027723, ___onSelectionChange_11)); }
	inline SelectionEvent_t1038911497 * get_onSelectionChange_11() const { return ___onSelectionChange_11; }
	inline SelectionEvent_t1038911497 ** get_address_of_onSelectionChange_11() { return &___onSelectionChange_11; }
	inline void set_onSelectionChange_11(SelectionEvent_t1038911497 * value)
	{
		___onSelectionChange_11 = value;
		Il2CppCodeGenWriteBarrier(&___onSelectionChange_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
