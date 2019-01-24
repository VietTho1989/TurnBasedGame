#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "AssemblyU2DCSharp_AddComponent_List_ScrollOrientati732142070.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// AddComponent.List/OnItemLoadedHandler
struct OnItemLoadedHandler_t3344139814;
// AddComponent.List/OnItemSelectedHandler
struct OnItemSelectedHandler_t3478852502;
// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// System.Collections.Generic.List`1<AddComponent.ListItemBase>
struct List_1_t4227582488;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AddComponent.List
struct  List_t1060718126  : public MonoBehaviour_t1158329972
{
public:
	// AddComponent.List/OnItemLoadedHandler AddComponent.List::onItemLoaded
	OnItemLoadedHandler_t3344139814 * ___onItemLoaded_2;
	// AddComponent.List/OnItemSelectedHandler AddComponent.List::onItemSelected
	OnItemSelectedHandler_t3478852502 * ___onItemSelected_3;
	// UnityEngine.UI.ScrollRect AddComponent.List::_scrollRect
	ScrollRect_t1199013257 * ____scrollRect_4;
	// UnityEngine.RectTransform AddComponent.List::_viewport
	RectTransform_t3349966182 * ____viewport_5;
	// UnityEngine.RectTransform AddComponent.List::_content
	RectTransform_t3349966182 * ____content_6;
	// AddComponent.List/ScrollOrientation AddComponent.List::_scrollOrientation
	int32_t ____scrollOrientation_7;
	// System.Single AddComponent.List::_spacing
	float ____spacing_8;
	// System.Boolean AddComponent.List::_fitItemToViewport
	bool ____fitItemToViewport_9;
	// System.Boolean AddComponent.List::_centerOnItem
	bool ____centerOnItem_10;
	// System.Single AddComponent.List::_changeItemDragFactor
	float ____changeItemDragFactor_11;
	// System.Collections.Generic.List`1<AddComponent.ListItemBase> AddComponent.List::_itemsList
	List_1_t4227582488 * ____itemsList_12;
	// System.Single AddComponent.List::_itemSize
	float ____itemSize_13;
	// System.Single AddComponent.List::_lastPosition
	float ____lastPosition_14;
	// System.Int32 AddComponent.List::_itemsTotal
	int32_t ____itemsTotal_15;
	// System.Int32 AddComponent.List::_itemsVisible
	int32_t ____itemsVisible_16;
	// System.Int32 AddComponent.List::_itemsToRecycleBefore
	int32_t ____itemsToRecycleBefore_17;
	// System.Int32 AddComponent.List::_itemsToRecycleAfter
	int32_t ____itemsToRecycleAfter_18;
	// System.Int32 AddComponent.List::_currentItemIndex
	int32_t ____currentItemIndex_19;
	// System.Int32 AddComponent.List::_lastItemIndex
	int32_t ____lastItemIndex_20;
	// UnityEngine.Vector2 AddComponent.List::_dragInitialPosition
	Vector2_t2243707579  ____dragInitialPosition_21;

public:
	inline static int32_t get_offset_of_onItemLoaded_2() { return static_cast<int32_t>(offsetof(List_t1060718126, ___onItemLoaded_2)); }
	inline OnItemLoadedHandler_t3344139814 * get_onItemLoaded_2() const { return ___onItemLoaded_2; }
	inline OnItemLoadedHandler_t3344139814 ** get_address_of_onItemLoaded_2() { return &___onItemLoaded_2; }
	inline void set_onItemLoaded_2(OnItemLoadedHandler_t3344139814 * value)
	{
		___onItemLoaded_2 = value;
		Il2CppCodeGenWriteBarrier(&___onItemLoaded_2, value);
	}

	inline static int32_t get_offset_of_onItemSelected_3() { return static_cast<int32_t>(offsetof(List_t1060718126, ___onItemSelected_3)); }
	inline OnItemSelectedHandler_t3478852502 * get_onItemSelected_3() const { return ___onItemSelected_3; }
	inline OnItemSelectedHandler_t3478852502 ** get_address_of_onItemSelected_3() { return &___onItemSelected_3; }
	inline void set_onItemSelected_3(OnItemSelectedHandler_t3478852502 * value)
	{
		___onItemSelected_3 = value;
		Il2CppCodeGenWriteBarrier(&___onItemSelected_3, value);
	}

	inline static int32_t get_offset_of__scrollRect_4() { return static_cast<int32_t>(offsetof(List_t1060718126, ____scrollRect_4)); }
	inline ScrollRect_t1199013257 * get__scrollRect_4() const { return ____scrollRect_4; }
	inline ScrollRect_t1199013257 ** get_address_of__scrollRect_4() { return &____scrollRect_4; }
	inline void set__scrollRect_4(ScrollRect_t1199013257 * value)
	{
		____scrollRect_4 = value;
		Il2CppCodeGenWriteBarrier(&____scrollRect_4, value);
	}

	inline static int32_t get_offset_of__viewport_5() { return static_cast<int32_t>(offsetof(List_t1060718126, ____viewport_5)); }
	inline RectTransform_t3349966182 * get__viewport_5() const { return ____viewport_5; }
	inline RectTransform_t3349966182 ** get_address_of__viewport_5() { return &____viewport_5; }
	inline void set__viewport_5(RectTransform_t3349966182 * value)
	{
		____viewport_5 = value;
		Il2CppCodeGenWriteBarrier(&____viewport_5, value);
	}

	inline static int32_t get_offset_of__content_6() { return static_cast<int32_t>(offsetof(List_t1060718126, ____content_6)); }
	inline RectTransform_t3349966182 * get__content_6() const { return ____content_6; }
	inline RectTransform_t3349966182 ** get_address_of__content_6() { return &____content_6; }
	inline void set__content_6(RectTransform_t3349966182 * value)
	{
		____content_6 = value;
		Il2CppCodeGenWriteBarrier(&____content_6, value);
	}

	inline static int32_t get_offset_of__scrollOrientation_7() { return static_cast<int32_t>(offsetof(List_t1060718126, ____scrollOrientation_7)); }
	inline int32_t get__scrollOrientation_7() const { return ____scrollOrientation_7; }
	inline int32_t* get_address_of__scrollOrientation_7() { return &____scrollOrientation_7; }
	inline void set__scrollOrientation_7(int32_t value)
	{
		____scrollOrientation_7 = value;
	}

	inline static int32_t get_offset_of__spacing_8() { return static_cast<int32_t>(offsetof(List_t1060718126, ____spacing_8)); }
	inline float get__spacing_8() const { return ____spacing_8; }
	inline float* get_address_of__spacing_8() { return &____spacing_8; }
	inline void set__spacing_8(float value)
	{
		____spacing_8 = value;
	}

	inline static int32_t get_offset_of__fitItemToViewport_9() { return static_cast<int32_t>(offsetof(List_t1060718126, ____fitItemToViewport_9)); }
	inline bool get__fitItemToViewport_9() const { return ____fitItemToViewport_9; }
	inline bool* get_address_of__fitItemToViewport_9() { return &____fitItemToViewport_9; }
	inline void set__fitItemToViewport_9(bool value)
	{
		____fitItemToViewport_9 = value;
	}

	inline static int32_t get_offset_of__centerOnItem_10() { return static_cast<int32_t>(offsetof(List_t1060718126, ____centerOnItem_10)); }
	inline bool get__centerOnItem_10() const { return ____centerOnItem_10; }
	inline bool* get_address_of__centerOnItem_10() { return &____centerOnItem_10; }
	inline void set__centerOnItem_10(bool value)
	{
		____centerOnItem_10 = value;
	}

	inline static int32_t get_offset_of__changeItemDragFactor_11() { return static_cast<int32_t>(offsetof(List_t1060718126, ____changeItemDragFactor_11)); }
	inline float get__changeItemDragFactor_11() const { return ____changeItemDragFactor_11; }
	inline float* get_address_of__changeItemDragFactor_11() { return &____changeItemDragFactor_11; }
	inline void set__changeItemDragFactor_11(float value)
	{
		____changeItemDragFactor_11 = value;
	}

	inline static int32_t get_offset_of__itemsList_12() { return static_cast<int32_t>(offsetof(List_t1060718126, ____itemsList_12)); }
	inline List_1_t4227582488 * get__itemsList_12() const { return ____itemsList_12; }
	inline List_1_t4227582488 ** get_address_of__itemsList_12() { return &____itemsList_12; }
	inline void set__itemsList_12(List_1_t4227582488 * value)
	{
		____itemsList_12 = value;
		Il2CppCodeGenWriteBarrier(&____itemsList_12, value);
	}

	inline static int32_t get_offset_of__itemSize_13() { return static_cast<int32_t>(offsetof(List_t1060718126, ____itemSize_13)); }
	inline float get__itemSize_13() const { return ____itemSize_13; }
	inline float* get_address_of__itemSize_13() { return &____itemSize_13; }
	inline void set__itemSize_13(float value)
	{
		____itemSize_13 = value;
	}

	inline static int32_t get_offset_of__lastPosition_14() { return static_cast<int32_t>(offsetof(List_t1060718126, ____lastPosition_14)); }
	inline float get__lastPosition_14() const { return ____lastPosition_14; }
	inline float* get_address_of__lastPosition_14() { return &____lastPosition_14; }
	inline void set__lastPosition_14(float value)
	{
		____lastPosition_14 = value;
	}

	inline static int32_t get_offset_of__itemsTotal_15() { return static_cast<int32_t>(offsetof(List_t1060718126, ____itemsTotal_15)); }
	inline int32_t get__itemsTotal_15() const { return ____itemsTotal_15; }
	inline int32_t* get_address_of__itemsTotal_15() { return &____itemsTotal_15; }
	inline void set__itemsTotal_15(int32_t value)
	{
		____itemsTotal_15 = value;
	}

	inline static int32_t get_offset_of__itemsVisible_16() { return static_cast<int32_t>(offsetof(List_t1060718126, ____itemsVisible_16)); }
	inline int32_t get__itemsVisible_16() const { return ____itemsVisible_16; }
	inline int32_t* get_address_of__itemsVisible_16() { return &____itemsVisible_16; }
	inline void set__itemsVisible_16(int32_t value)
	{
		____itemsVisible_16 = value;
	}

	inline static int32_t get_offset_of__itemsToRecycleBefore_17() { return static_cast<int32_t>(offsetof(List_t1060718126, ____itemsToRecycleBefore_17)); }
	inline int32_t get__itemsToRecycleBefore_17() const { return ____itemsToRecycleBefore_17; }
	inline int32_t* get_address_of__itemsToRecycleBefore_17() { return &____itemsToRecycleBefore_17; }
	inline void set__itemsToRecycleBefore_17(int32_t value)
	{
		____itemsToRecycleBefore_17 = value;
	}

	inline static int32_t get_offset_of__itemsToRecycleAfter_18() { return static_cast<int32_t>(offsetof(List_t1060718126, ____itemsToRecycleAfter_18)); }
	inline int32_t get__itemsToRecycleAfter_18() const { return ____itemsToRecycleAfter_18; }
	inline int32_t* get_address_of__itemsToRecycleAfter_18() { return &____itemsToRecycleAfter_18; }
	inline void set__itemsToRecycleAfter_18(int32_t value)
	{
		____itemsToRecycleAfter_18 = value;
	}

	inline static int32_t get_offset_of__currentItemIndex_19() { return static_cast<int32_t>(offsetof(List_t1060718126, ____currentItemIndex_19)); }
	inline int32_t get__currentItemIndex_19() const { return ____currentItemIndex_19; }
	inline int32_t* get_address_of__currentItemIndex_19() { return &____currentItemIndex_19; }
	inline void set__currentItemIndex_19(int32_t value)
	{
		____currentItemIndex_19 = value;
	}

	inline static int32_t get_offset_of__lastItemIndex_20() { return static_cast<int32_t>(offsetof(List_t1060718126, ____lastItemIndex_20)); }
	inline int32_t get__lastItemIndex_20() const { return ____lastItemIndex_20; }
	inline int32_t* get_address_of__lastItemIndex_20() { return &____lastItemIndex_20; }
	inline void set__lastItemIndex_20(int32_t value)
	{
		____lastItemIndex_20 = value;
	}

	inline static int32_t get_offset_of__dragInitialPosition_21() { return static_cast<int32_t>(offsetof(List_t1060718126, ____dragInitialPosition_21)); }
	inline Vector2_t2243707579  get__dragInitialPosition_21() const { return ____dragInitialPosition_21; }
	inline Vector2_t2243707579 * get_address_of__dragInitialPosition_21() { return &____dragInitialPosition_21; }
	inline void set__dragInitialPosition_21(Vector2_t2243707579  value)
	{
		____dragInitialPosition_21 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
