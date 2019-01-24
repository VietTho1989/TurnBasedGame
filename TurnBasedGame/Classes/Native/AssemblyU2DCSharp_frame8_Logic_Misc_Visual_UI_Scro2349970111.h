#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3694468974.h"

// RoomUserAdapter/UIData
struct UIData_t115426826;
// System.Action`1<System.Single>
struct Action_1_t1878309314;
// System.Action`2<System.Int32,System.Int32>
struct Action_2_t1370245513;
// System.Collections.Generic.List`1<RoomUserHolder/UIData>
struct List_1_t1245000359;
// frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2/InternalState<RoomUserAdapter/UIData,RoomUserHolder/UIData>
struct InternalState_t24735391;
// frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor
struct ItemsDescriptor_t3229248635;
// UnityEngine.Coroutine
struct Coroutine_t2299508840;
// System.Func`5<UnityEngine.RectTransform,System.Single,UnityEngine.RectTransform,System.Single,System.Single>
struct Func_5_t1545632126;
// System.Func`2<UnityEngine.RectTransform,System.Single>
struct Func_2_t2546352383;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2<RoomUserAdapter/UIData,RoomUserHolder/UIData>
struct  SRIA_2_t2349970111  : public UIBehavior_1_t3694468974
{
public:
	// TParams frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::_Params
	UIData_t115426826 * ____Params_6;
	// System.Action`1<System.Single> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::ScrollPositionChanged
	Action_1_t1878309314 * ___ScrollPositionChanged_7;
	// System.Action`2<System.Int32,System.Int32> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::ItemsRefreshed
	Action_2_t1370245513 * ___ItemsRefreshed_8;
	// System.Boolean frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::<Initialized>k__BackingField
	bool ___U3CInitializedU3Ek__BackingField_9;
	// System.Collections.Generic.List`1<TItemViewsHolder> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::_VisibleItems
	List_1_t1245000359 * ____VisibleItems_10;
	// System.Int32 frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::_VisibleItemsCount
	int32_t ____VisibleItemsCount_11;
	// System.Collections.Generic.List`1<TItemViewsHolder> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::_RecyclableItems
	List_1_t1245000359 * ____RecyclableItems_12;
	// frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2/InternalState<TParams,TItemViewsHolder> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::_InternalState
	InternalState_t24735391 * ____InternalState_13;
	// frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::_ItemsDesc
	ItemsDescriptor_t3229248635 * ____ItemsDesc_14;
	// UnityEngine.Coroutine frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::_SmoothScrollCoroutine
	Coroutine_t2299508840 * ____SmoothScrollCoroutine_15;
	// System.Boolean frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::_SkipComputeVisibilityInUpdateOrOnScroll
	bool ____SkipComputeVisibilityInUpdateOrOnScroll_16;
	// System.Boolean frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::_CorrectedPositionInCurrentComputeVisibilityPass
	bool ____CorrectedPositionInCurrentComputeVisibilityPass_17;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::_PrevGalleryEffectAmount
	float ____PrevGalleryEffectAmount_18;
	// System.Double frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::_AVGVisibleItemsCount
	double ____AVGVisibleItemsCount_19;

public:
	inline static int32_t get_offset_of__Params_6() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ____Params_6)); }
	inline UIData_t115426826 * get__Params_6() const { return ____Params_6; }
	inline UIData_t115426826 ** get_address_of__Params_6() { return &____Params_6; }
	inline void set__Params_6(UIData_t115426826 * value)
	{
		____Params_6 = value;
		Il2CppCodeGenWriteBarrier(&____Params_6, value);
	}

	inline static int32_t get_offset_of_ScrollPositionChanged_7() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ___ScrollPositionChanged_7)); }
	inline Action_1_t1878309314 * get_ScrollPositionChanged_7() const { return ___ScrollPositionChanged_7; }
	inline Action_1_t1878309314 ** get_address_of_ScrollPositionChanged_7() { return &___ScrollPositionChanged_7; }
	inline void set_ScrollPositionChanged_7(Action_1_t1878309314 * value)
	{
		___ScrollPositionChanged_7 = value;
		Il2CppCodeGenWriteBarrier(&___ScrollPositionChanged_7, value);
	}

	inline static int32_t get_offset_of_ItemsRefreshed_8() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ___ItemsRefreshed_8)); }
	inline Action_2_t1370245513 * get_ItemsRefreshed_8() const { return ___ItemsRefreshed_8; }
	inline Action_2_t1370245513 ** get_address_of_ItemsRefreshed_8() { return &___ItemsRefreshed_8; }
	inline void set_ItemsRefreshed_8(Action_2_t1370245513 * value)
	{
		___ItemsRefreshed_8 = value;
		Il2CppCodeGenWriteBarrier(&___ItemsRefreshed_8, value);
	}

	inline static int32_t get_offset_of_U3CInitializedU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ___U3CInitializedU3Ek__BackingField_9)); }
	inline bool get_U3CInitializedU3Ek__BackingField_9() const { return ___U3CInitializedU3Ek__BackingField_9; }
	inline bool* get_address_of_U3CInitializedU3Ek__BackingField_9() { return &___U3CInitializedU3Ek__BackingField_9; }
	inline void set_U3CInitializedU3Ek__BackingField_9(bool value)
	{
		___U3CInitializedU3Ek__BackingField_9 = value;
	}

	inline static int32_t get_offset_of__VisibleItems_10() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ____VisibleItems_10)); }
	inline List_1_t1245000359 * get__VisibleItems_10() const { return ____VisibleItems_10; }
	inline List_1_t1245000359 ** get_address_of__VisibleItems_10() { return &____VisibleItems_10; }
	inline void set__VisibleItems_10(List_1_t1245000359 * value)
	{
		____VisibleItems_10 = value;
		Il2CppCodeGenWriteBarrier(&____VisibleItems_10, value);
	}

	inline static int32_t get_offset_of__VisibleItemsCount_11() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ____VisibleItemsCount_11)); }
	inline int32_t get__VisibleItemsCount_11() const { return ____VisibleItemsCount_11; }
	inline int32_t* get_address_of__VisibleItemsCount_11() { return &____VisibleItemsCount_11; }
	inline void set__VisibleItemsCount_11(int32_t value)
	{
		____VisibleItemsCount_11 = value;
	}

	inline static int32_t get_offset_of__RecyclableItems_12() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ____RecyclableItems_12)); }
	inline List_1_t1245000359 * get__RecyclableItems_12() const { return ____RecyclableItems_12; }
	inline List_1_t1245000359 ** get_address_of__RecyclableItems_12() { return &____RecyclableItems_12; }
	inline void set__RecyclableItems_12(List_1_t1245000359 * value)
	{
		____RecyclableItems_12 = value;
		Il2CppCodeGenWriteBarrier(&____RecyclableItems_12, value);
	}

	inline static int32_t get_offset_of__InternalState_13() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ____InternalState_13)); }
	inline InternalState_t24735391 * get__InternalState_13() const { return ____InternalState_13; }
	inline InternalState_t24735391 ** get_address_of__InternalState_13() { return &____InternalState_13; }
	inline void set__InternalState_13(InternalState_t24735391 * value)
	{
		____InternalState_13 = value;
		Il2CppCodeGenWriteBarrier(&____InternalState_13, value);
	}

	inline static int32_t get_offset_of__ItemsDesc_14() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ____ItemsDesc_14)); }
	inline ItemsDescriptor_t3229248635 * get__ItemsDesc_14() const { return ____ItemsDesc_14; }
	inline ItemsDescriptor_t3229248635 ** get_address_of__ItemsDesc_14() { return &____ItemsDesc_14; }
	inline void set__ItemsDesc_14(ItemsDescriptor_t3229248635 * value)
	{
		____ItemsDesc_14 = value;
		Il2CppCodeGenWriteBarrier(&____ItemsDesc_14, value);
	}

	inline static int32_t get_offset_of__SmoothScrollCoroutine_15() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ____SmoothScrollCoroutine_15)); }
	inline Coroutine_t2299508840 * get__SmoothScrollCoroutine_15() const { return ____SmoothScrollCoroutine_15; }
	inline Coroutine_t2299508840 ** get_address_of__SmoothScrollCoroutine_15() { return &____SmoothScrollCoroutine_15; }
	inline void set__SmoothScrollCoroutine_15(Coroutine_t2299508840 * value)
	{
		____SmoothScrollCoroutine_15 = value;
		Il2CppCodeGenWriteBarrier(&____SmoothScrollCoroutine_15, value);
	}

	inline static int32_t get_offset_of__SkipComputeVisibilityInUpdateOrOnScroll_16() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ____SkipComputeVisibilityInUpdateOrOnScroll_16)); }
	inline bool get__SkipComputeVisibilityInUpdateOrOnScroll_16() const { return ____SkipComputeVisibilityInUpdateOrOnScroll_16; }
	inline bool* get_address_of__SkipComputeVisibilityInUpdateOrOnScroll_16() { return &____SkipComputeVisibilityInUpdateOrOnScroll_16; }
	inline void set__SkipComputeVisibilityInUpdateOrOnScroll_16(bool value)
	{
		____SkipComputeVisibilityInUpdateOrOnScroll_16 = value;
	}

	inline static int32_t get_offset_of__CorrectedPositionInCurrentComputeVisibilityPass_17() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ____CorrectedPositionInCurrentComputeVisibilityPass_17)); }
	inline bool get__CorrectedPositionInCurrentComputeVisibilityPass_17() const { return ____CorrectedPositionInCurrentComputeVisibilityPass_17; }
	inline bool* get_address_of__CorrectedPositionInCurrentComputeVisibilityPass_17() { return &____CorrectedPositionInCurrentComputeVisibilityPass_17; }
	inline void set__CorrectedPositionInCurrentComputeVisibilityPass_17(bool value)
	{
		____CorrectedPositionInCurrentComputeVisibilityPass_17 = value;
	}

	inline static int32_t get_offset_of__PrevGalleryEffectAmount_18() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ____PrevGalleryEffectAmount_18)); }
	inline float get__PrevGalleryEffectAmount_18() const { return ____PrevGalleryEffectAmount_18; }
	inline float* get_address_of__PrevGalleryEffectAmount_18() { return &____PrevGalleryEffectAmount_18; }
	inline void set__PrevGalleryEffectAmount_18(float value)
	{
		____PrevGalleryEffectAmount_18 = value;
	}

	inline static int32_t get_offset_of__AVGVisibleItemsCount_19() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111, ____AVGVisibleItemsCount_19)); }
	inline double get__AVGVisibleItemsCount_19() const { return ____AVGVisibleItemsCount_19; }
	inline double* get_address_of__AVGVisibleItemsCount_19() { return &____AVGVisibleItemsCount_19; }
	inline void set__AVGVisibleItemsCount_19(double value)
	{
		____AVGVisibleItemsCount_19 = value;
	}
};

struct SRIA_2_t2349970111_StaticFields
{
public:
	// System.Func`5<UnityEngine.RectTransform,System.Single,UnityEngine.RectTransform,System.Single,System.Single> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::<>f__mg$cache0
	Func_5_t1545632126 * ___U3CU3Ef__mgU24cache0_20;
	// System.Func`5<UnityEngine.RectTransform,System.Single,UnityEngine.RectTransform,System.Single,System.Single> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::<>f__mg$cache1
	Func_5_t1545632126 * ___U3CU3Ef__mgU24cache1_21;
	// System.Func`2<UnityEngine.RectTransform,System.Single> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::<>f__mg$cache2
	Func_2_t2546352383 * ___U3CU3Ef__mgU24cache2_22;
	// System.Func`2<UnityEngine.RectTransform,System.Single> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.SRIA`2::<>f__mg$cache3
	Func_2_t2546352383 * ___U3CU3Ef__mgU24cache3_23;

public:
	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache0_20() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111_StaticFields, ___U3CU3Ef__mgU24cache0_20)); }
	inline Func_5_t1545632126 * get_U3CU3Ef__mgU24cache0_20() const { return ___U3CU3Ef__mgU24cache0_20; }
	inline Func_5_t1545632126 ** get_address_of_U3CU3Ef__mgU24cache0_20() { return &___U3CU3Ef__mgU24cache0_20; }
	inline void set_U3CU3Ef__mgU24cache0_20(Func_5_t1545632126 * value)
	{
		___U3CU3Ef__mgU24cache0_20 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache0_20, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache1_21() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111_StaticFields, ___U3CU3Ef__mgU24cache1_21)); }
	inline Func_5_t1545632126 * get_U3CU3Ef__mgU24cache1_21() const { return ___U3CU3Ef__mgU24cache1_21; }
	inline Func_5_t1545632126 ** get_address_of_U3CU3Ef__mgU24cache1_21() { return &___U3CU3Ef__mgU24cache1_21; }
	inline void set_U3CU3Ef__mgU24cache1_21(Func_5_t1545632126 * value)
	{
		___U3CU3Ef__mgU24cache1_21 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache1_21, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache2_22() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111_StaticFields, ___U3CU3Ef__mgU24cache2_22)); }
	inline Func_2_t2546352383 * get_U3CU3Ef__mgU24cache2_22() const { return ___U3CU3Ef__mgU24cache2_22; }
	inline Func_2_t2546352383 ** get_address_of_U3CU3Ef__mgU24cache2_22() { return &___U3CU3Ef__mgU24cache2_22; }
	inline void set_U3CU3Ef__mgU24cache2_22(Func_2_t2546352383 * value)
	{
		___U3CU3Ef__mgU24cache2_22 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache2_22, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache3_23() { return static_cast<int32_t>(offsetof(SRIA_2_t2349970111_StaticFields, ___U3CU3Ef__mgU24cache3_23)); }
	inline Func_2_t2546352383 * get_U3CU3Ef__mgU24cache3_23() const { return ___U3CU3Ef__mgU24cache3_23; }
	inline Func_2_t2546352383 ** get_address_of_U3CU3Ef__mgU24cache3_23() { return &___U3CU3Ef__mgU24cache3_23; }
	inline void set_U3CU3Ef__mgU24cache3_23(Func_2_t2546352383 * value)
	{
		___U3CU3Ef__mgU24cache3_23 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache3_23, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
