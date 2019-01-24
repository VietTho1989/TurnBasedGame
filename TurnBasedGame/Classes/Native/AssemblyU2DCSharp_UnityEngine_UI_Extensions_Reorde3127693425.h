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

// System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>
struct List_1_t3685274804;
// UnityEngine.UI.Extensions.ReorderableList
struct ReorderableList_t970849249;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.UI.LayoutElement
struct LayoutElement_t2808691390;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ReorderableListElement
struct  ReorderableListElement_t3127693425  : public MonoBehaviour_t1158329972
{
public:
	// System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult> UnityEngine.UI.Extensions.ReorderableListElement::_raycastResults
	List_1_t3685274804 * ____raycastResults_2;
	// UnityEngine.UI.Extensions.ReorderableList UnityEngine.UI.Extensions.ReorderableListElement::_currentReorderableListRaycasted
	ReorderableList_t970849249 * ____currentReorderableListRaycasted_3;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ReorderableListElement::_draggingObject
	RectTransform_t3349966182 * ____draggingObject_4;
	// UnityEngine.UI.LayoutElement UnityEngine.UI.Extensions.ReorderableListElement::_draggingObjectLE
	LayoutElement_t2808691390 * ____draggingObjectLE_5;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.ReorderableListElement::_draggingObjectOriginalSize
	Vector2_t2243707579  ____draggingObjectOriginalSize_6;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ReorderableListElement::_fakeElement
	RectTransform_t3349966182 * ____fakeElement_7;
	// UnityEngine.UI.LayoutElement UnityEngine.UI.Extensions.ReorderableListElement::_fakeElementLE
	LayoutElement_t2808691390 * ____fakeElementLE_8;
	// System.Int32 UnityEngine.UI.Extensions.ReorderableListElement::_fromIndex
	int32_t ____fromIndex_9;
	// System.Boolean UnityEngine.UI.Extensions.ReorderableListElement::_isDragging
	bool ____isDragging_10;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ReorderableListElement::_rect
	RectTransform_t3349966182 * ____rect_11;
	// UnityEngine.UI.Extensions.ReorderableList UnityEngine.UI.Extensions.ReorderableListElement::_reorderableList
	ReorderableList_t970849249 * ____reorderableList_12;

public:
	inline static int32_t get_offset_of__raycastResults_2() { return static_cast<int32_t>(offsetof(ReorderableListElement_t3127693425, ____raycastResults_2)); }
	inline List_1_t3685274804 * get__raycastResults_2() const { return ____raycastResults_2; }
	inline List_1_t3685274804 ** get_address_of__raycastResults_2() { return &____raycastResults_2; }
	inline void set__raycastResults_2(List_1_t3685274804 * value)
	{
		____raycastResults_2 = value;
		Il2CppCodeGenWriteBarrier(&____raycastResults_2, value);
	}

	inline static int32_t get_offset_of__currentReorderableListRaycasted_3() { return static_cast<int32_t>(offsetof(ReorderableListElement_t3127693425, ____currentReorderableListRaycasted_3)); }
	inline ReorderableList_t970849249 * get__currentReorderableListRaycasted_3() const { return ____currentReorderableListRaycasted_3; }
	inline ReorderableList_t970849249 ** get_address_of__currentReorderableListRaycasted_3() { return &____currentReorderableListRaycasted_3; }
	inline void set__currentReorderableListRaycasted_3(ReorderableList_t970849249 * value)
	{
		____currentReorderableListRaycasted_3 = value;
		Il2CppCodeGenWriteBarrier(&____currentReorderableListRaycasted_3, value);
	}

	inline static int32_t get_offset_of__draggingObject_4() { return static_cast<int32_t>(offsetof(ReorderableListElement_t3127693425, ____draggingObject_4)); }
	inline RectTransform_t3349966182 * get__draggingObject_4() const { return ____draggingObject_4; }
	inline RectTransform_t3349966182 ** get_address_of__draggingObject_4() { return &____draggingObject_4; }
	inline void set__draggingObject_4(RectTransform_t3349966182 * value)
	{
		____draggingObject_4 = value;
		Il2CppCodeGenWriteBarrier(&____draggingObject_4, value);
	}

	inline static int32_t get_offset_of__draggingObjectLE_5() { return static_cast<int32_t>(offsetof(ReorderableListElement_t3127693425, ____draggingObjectLE_5)); }
	inline LayoutElement_t2808691390 * get__draggingObjectLE_5() const { return ____draggingObjectLE_5; }
	inline LayoutElement_t2808691390 ** get_address_of__draggingObjectLE_5() { return &____draggingObjectLE_5; }
	inline void set__draggingObjectLE_5(LayoutElement_t2808691390 * value)
	{
		____draggingObjectLE_5 = value;
		Il2CppCodeGenWriteBarrier(&____draggingObjectLE_5, value);
	}

	inline static int32_t get_offset_of__draggingObjectOriginalSize_6() { return static_cast<int32_t>(offsetof(ReorderableListElement_t3127693425, ____draggingObjectOriginalSize_6)); }
	inline Vector2_t2243707579  get__draggingObjectOriginalSize_6() const { return ____draggingObjectOriginalSize_6; }
	inline Vector2_t2243707579 * get_address_of__draggingObjectOriginalSize_6() { return &____draggingObjectOriginalSize_6; }
	inline void set__draggingObjectOriginalSize_6(Vector2_t2243707579  value)
	{
		____draggingObjectOriginalSize_6 = value;
	}

	inline static int32_t get_offset_of__fakeElement_7() { return static_cast<int32_t>(offsetof(ReorderableListElement_t3127693425, ____fakeElement_7)); }
	inline RectTransform_t3349966182 * get__fakeElement_7() const { return ____fakeElement_7; }
	inline RectTransform_t3349966182 ** get_address_of__fakeElement_7() { return &____fakeElement_7; }
	inline void set__fakeElement_7(RectTransform_t3349966182 * value)
	{
		____fakeElement_7 = value;
		Il2CppCodeGenWriteBarrier(&____fakeElement_7, value);
	}

	inline static int32_t get_offset_of__fakeElementLE_8() { return static_cast<int32_t>(offsetof(ReorderableListElement_t3127693425, ____fakeElementLE_8)); }
	inline LayoutElement_t2808691390 * get__fakeElementLE_8() const { return ____fakeElementLE_8; }
	inline LayoutElement_t2808691390 ** get_address_of__fakeElementLE_8() { return &____fakeElementLE_8; }
	inline void set__fakeElementLE_8(LayoutElement_t2808691390 * value)
	{
		____fakeElementLE_8 = value;
		Il2CppCodeGenWriteBarrier(&____fakeElementLE_8, value);
	}

	inline static int32_t get_offset_of__fromIndex_9() { return static_cast<int32_t>(offsetof(ReorderableListElement_t3127693425, ____fromIndex_9)); }
	inline int32_t get__fromIndex_9() const { return ____fromIndex_9; }
	inline int32_t* get_address_of__fromIndex_9() { return &____fromIndex_9; }
	inline void set__fromIndex_9(int32_t value)
	{
		____fromIndex_9 = value;
	}

	inline static int32_t get_offset_of__isDragging_10() { return static_cast<int32_t>(offsetof(ReorderableListElement_t3127693425, ____isDragging_10)); }
	inline bool get__isDragging_10() const { return ____isDragging_10; }
	inline bool* get_address_of__isDragging_10() { return &____isDragging_10; }
	inline void set__isDragging_10(bool value)
	{
		____isDragging_10 = value;
	}

	inline static int32_t get_offset_of__rect_11() { return static_cast<int32_t>(offsetof(ReorderableListElement_t3127693425, ____rect_11)); }
	inline RectTransform_t3349966182 * get__rect_11() const { return ____rect_11; }
	inline RectTransform_t3349966182 ** get_address_of__rect_11() { return &____rect_11; }
	inline void set__rect_11(RectTransform_t3349966182 * value)
	{
		____rect_11 = value;
		Il2CppCodeGenWriteBarrier(&____rect_11, value);
	}

	inline static int32_t get_offset_of__reorderableList_12() { return static_cast<int32_t>(offsetof(ReorderableListElement_t3127693425, ____reorderableList_12)); }
	inline ReorderableList_t970849249 * get__reorderableList_12() const { return ____reorderableList_12; }
	inline ReorderableList_t970849249 ** get_address_of__reorderableList_12() { return &____reorderableList_12; }
	inline void set__reorderableList_12(ReorderableList_t970849249 * value)
	{
		____reorderableList_12 = value;
		Il2CppCodeGenWriteBarrier(&____reorderableList_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
