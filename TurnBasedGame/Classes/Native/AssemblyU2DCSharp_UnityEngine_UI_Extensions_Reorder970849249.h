#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.LayoutGroup
struct LayoutGroup_t3962498969;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// UnityEngine.UI.Extensions.ReorderableList/ReorderableListHandler
struct ReorderableListHandler_t1694188766;
// UnityEngine.UI.Extensions.ReorderableListContent
struct ReorderableListContent_t133253858;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ReorderableList
struct  ReorderableList_t970849249  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.LayoutGroup UnityEngine.UI.Extensions.ReorderableList::ContentLayout
	LayoutGroup_t3962498969 * ___ContentLayout_2;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ReorderableList::DraggableArea
	RectTransform_t3349966182 * ___DraggableArea_3;
	// System.Boolean UnityEngine.UI.Extensions.ReorderableList::IsDraggable
	bool ___IsDraggable_4;
	// System.Boolean UnityEngine.UI.Extensions.ReorderableList::CloneDraggedObject
	bool ___CloneDraggedObject_5;
	// System.Boolean UnityEngine.UI.Extensions.ReorderableList::IsDropable
	bool ___IsDropable_6;
	// UnityEngine.UI.Extensions.ReorderableList/ReorderableListHandler UnityEngine.UI.Extensions.ReorderableList::OnElementDropped
	ReorderableListHandler_t1694188766 * ___OnElementDropped_7;
	// UnityEngine.UI.Extensions.ReorderableList/ReorderableListHandler UnityEngine.UI.Extensions.ReorderableList::OnElementGrabbed
	ReorderableListHandler_t1694188766 * ___OnElementGrabbed_8;
	// UnityEngine.UI.Extensions.ReorderableList/ReorderableListHandler UnityEngine.UI.Extensions.ReorderableList::OnElementRemoved
	ReorderableListHandler_t1694188766 * ___OnElementRemoved_9;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ReorderableList::_content
	RectTransform_t3349966182 * ____content_10;
	// UnityEngine.UI.Extensions.ReorderableListContent UnityEngine.UI.Extensions.ReorderableList::_listContent
	ReorderableListContent_t133253858 * ____listContent_11;

public:
	inline static int32_t get_offset_of_ContentLayout_2() { return static_cast<int32_t>(offsetof(ReorderableList_t970849249, ___ContentLayout_2)); }
	inline LayoutGroup_t3962498969 * get_ContentLayout_2() const { return ___ContentLayout_2; }
	inline LayoutGroup_t3962498969 ** get_address_of_ContentLayout_2() { return &___ContentLayout_2; }
	inline void set_ContentLayout_2(LayoutGroup_t3962498969 * value)
	{
		___ContentLayout_2 = value;
		Il2CppCodeGenWriteBarrier(&___ContentLayout_2, value);
	}

	inline static int32_t get_offset_of_DraggableArea_3() { return static_cast<int32_t>(offsetof(ReorderableList_t970849249, ___DraggableArea_3)); }
	inline RectTransform_t3349966182 * get_DraggableArea_3() const { return ___DraggableArea_3; }
	inline RectTransform_t3349966182 ** get_address_of_DraggableArea_3() { return &___DraggableArea_3; }
	inline void set_DraggableArea_3(RectTransform_t3349966182 * value)
	{
		___DraggableArea_3 = value;
		Il2CppCodeGenWriteBarrier(&___DraggableArea_3, value);
	}

	inline static int32_t get_offset_of_IsDraggable_4() { return static_cast<int32_t>(offsetof(ReorderableList_t970849249, ___IsDraggable_4)); }
	inline bool get_IsDraggable_4() const { return ___IsDraggable_4; }
	inline bool* get_address_of_IsDraggable_4() { return &___IsDraggable_4; }
	inline void set_IsDraggable_4(bool value)
	{
		___IsDraggable_4 = value;
	}

	inline static int32_t get_offset_of_CloneDraggedObject_5() { return static_cast<int32_t>(offsetof(ReorderableList_t970849249, ___CloneDraggedObject_5)); }
	inline bool get_CloneDraggedObject_5() const { return ___CloneDraggedObject_5; }
	inline bool* get_address_of_CloneDraggedObject_5() { return &___CloneDraggedObject_5; }
	inline void set_CloneDraggedObject_5(bool value)
	{
		___CloneDraggedObject_5 = value;
	}

	inline static int32_t get_offset_of_IsDropable_6() { return static_cast<int32_t>(offsetof(ReorderableList_t970849249, ___IsDropable_6)); }
	inline bool get_IsDropable_6() const { return ___IsDropable_6; }
	inline bool* get_address_of_IsDropable_6() { return &___IsDropable_6; }
	inline void set_IsDropable_6(bool value)
	{
		___IsDropable_6 = value;
	}

	inline static int32_t get_offset_of_OnElementDropped_7() { return static_cast<int32_t>(offsetof(ReorderableList_t970849249, ___OnElementDropped_7)); }
	inline ReorderableListHandler_t1694188766 * get_OnElementDropped_7() const { return ___OnElementDropped_7; }
	inline ReorderableListHandler_t1694188766 ** get_address_of_OnElementDropped_7() { return &___OnElementDropped_7; }
	inline void set_OnElementDropped_7(ReorderableListHandler_t1694188766 * value)
	{
		___OnElementDropped_7 = value;
		Il2CppCodeGenWriteBarrier(&___OnElementDropped_7, value);
	}

	inline static int32_t get_offset_of_OnElementGrabbed_8() { return static_cast<int32_t>(offsetof(ReorderableList_t970849249, ___OnElementGrabbed_8)); }
	inline ReorderableListHandler_t1694188766 * get_OnElementGrabbed_8() const { return ___OnElementGrabbed_8; }
	inline ReorderableListHandler_t1694188766 ** get_address_of_OnElementGrabbed_8() { return &___OnElementGrabbed_8; }
	inline void set_OnElementGrabbed_8(ReorderableListHandler_t1694188766 * value)
	{
		___OnElementGrabbed_8 = value;
		Il2CppCodeGenWriteBarrier(&___OnElementGrabbed_8, value);
	}

	inline static int32_t get_offset_of_OnElementRemoved_9() { return static_cast<int32_t>(offsetof(ReorderableList_t970849249, ___OnElementRemoved_9)); }
	inline ReorderableListHandler_t1694188766 * get_OnElementRemoved_9() const { return ___OnElementRemoved_9; }
	inline ReorderableListHandler_t1694188766 ** get_address_of_OnElementRemoved_9() { return &___OnElementRemoved_9; }
	inline void set_OnElementRemoved_9(ReorderableListHandler_t1694188766 * value)
	{
		___OnElementRemoved_9 = value;
		Il2CppCodeGenWriteBarrier(&___OnElementRemoved_9, value);
	}

	inline static int32_t get_offset_of__content_10() { return static_cast<int32_t>(offsetof(ReorderableList_t970849249, ____content_10)); }
	inline RectTransform_t3349966182 * get__content_10() const { return ____content_10; }
	inline RectTransform_t3349966182 ** get_address_of__content_10() { return &____content_10; }
	inline void set__content_10(RectTransform_t3349966182 * value)
	{
		____content_10 = value;
		Il2CppCodeGenWriteBarrier(&____content_10, value);
	}

	inline static int32_t get_offset_of__listContent_11() { return static_cast<int32_t>(offsetof(ReorderableList_t970849249, ____listContent_11)); }
	inline ReorderableListContent_t133253858 * get__listContent_11() const { return ____listContent_11; }
	inline ReorderableListContent_t133253858 ** get_address_of__listContent_11() { return &____listContent_11; }
	inline void set__listContent_11(ReorderableListContent_t133253858 * value)
	{
		____listContent_11 = value;
		Il2CppCodeGenWriteBarrier(&____listContent_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
