#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"
#include "UnityEngine_UnityEngine_RectTransform_Edge3306019089.h"

// frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor
struct ItemsDescriptor_t3229248635;
// Seirawan.NoneRule.SetHandAdapter/UIData
struct UIData_t2529106927;
// System.Func`2<UnityEngine.RectTransform,System.Single>
struct Func_2_t2546352383;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2<Seirawan.NoneRule.SetHandAdapter/UIData,Seirawan.NoneRule.SetHandHolder/UIData>
struct  InternalStateGeneric_2_t1773261921  : public Il2CppObject
{
public:
	// UnityEngine.Vector2 frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::constantAnchorPosForAllItems
	Vector2_t2243707579  ___constantAnchorPosForAllItems_1;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::viewportSize
	float ___viewportSize_2;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::paddingContentStart
	float ___paddingContentStart_3;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::transversalPaddingContentStart
	float ___transversalPaddingContentStart_4;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::paddingContentEnd
	float ___paddingContentEnd_5;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::paddingStartPlusEnd
	float ___paddingStartPlusEnd_6;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::spacing
	float ___spacing_7;
	// UnityEngine.RectTransform/Edge frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::startEdge
	int32_t ___startEdge_8;
	// UnityEngine.RectTransform/Edge frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::endEdge
	int32_t ___endEdge_9;
	// UnityEngine.RectTransform/Edge frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::transvStartEdge
	int32_t ___transvStartEdge_10;
	// System.Double frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::lastProcessedCTVirtualInsetFromParentStart
	double ___lastProcessedCTVirtualInsetFromParentStart_11;
	// System.Double frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::contentPanelSkippedInsetDueToVirtualization
	double ___contentPanelSkippedInsetDueToVirtualization_12;
	// UnityEngine.Vector2 frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::scrollViewSize
	Vector2_t2243707579  ___scrollViewSize_13;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::contentPanelSize
	float ___contentPanelSize_14;
	// System.Double frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::contentPanelVirtualSize
	double ___contentPanelVirtualSize_15;
	// System.Boolean frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::updateRequestPending
	bool ___updateRequestPending_16;
	// System.Boolean frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::computeVisibilityTwinPassScheduled
	bool ___computeVisibilityTwinPassScheduled_17;
	// System.Boolean frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass
	bool ___preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass_18;
	// System.Boolean frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::lastComputeVisibilityHadATwinPass
	bool ___lastComputeVisibilityHadATwinPass_19;
	// frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::_ItemsDesc
	ItemsDescriptor_t3229248635 * ____ItemsDesc_20;
	// TParams frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::_SourceParams
	UIData_t2529106927 * ____SourceParams_21;
	// System.Func`2<UnityEngine.RectTransform,System.Single> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::_GetRTCurrentSizeFn
	Func_2_t2546352383 * ____GetRTCurrentSizeFn_22;

public:
	inline static int32_t get_offset_of_constantAnchorPosForAllItems_1() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___constantAnchorPosForAllItems_1)); }
	inline Vector2_t2243707579  get_constantAnchorPosForAllItems_1() const { return ___constantAnchorPosForAllItems_1; }
	inline Vector2_t2243707579 * get_address_of_constantAnchorPosForAllItems_1() { return &___constantAnchorPosForAllItems_1; }
	inline void set_constantAnchorPosForAllItems_1(Vector2_t2243707579  value)
	{
		___constantAnchorPosForAllItems_1 = value;
	}

	inline static int32_t get_offset_of_viewportSize_2() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___viewportSize_2)); }
	inline float get_viewportSize_2() const { return ___viewportSize_2; }
	inline float* get_address_of_viewportSize_2() { return &___viewportSize_2; }
	inline void set_viewportSize_2(float value)
	{
		___viewportSize_2 = value;
	}

	inline static int32_t get_offset_of_paddingContentStart_3() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___paddingContentStart_3)); }
	inline float get_paddingContentStart_3() const { return ___paddingContentStart_3; }
	inline float* get_address_of_paddingContentStart_3() { return &___paddingContentStart_3; }
	inline void set_paddingContentStart_3(float value)
	{
		___paddingContentStart_3 = value;
	}

	inline static int32_t get_offset_of_transversalPaddingContentStart_4() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___transversalPaddingContentStart_4)); }
	inline float get_transversalPaddingContentStart_4() const { return ___transversalPaddingContentStart_4; }
	inline float* get_address_of_transversalPaddingContentStart_4() { return &___transversalPaddingContentStart_4; }
	inline void set_transversalPaddingContentStart_4(float value)
	{
		___transversalPaddingContentStart_4 = value;
	}

	inline static int32_t get_offset_of_paddingContentEnd_5() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___paddingContentEnd_5)); }
	inline float get_paddingContentEnd_5() const { return ___paddingContentEnd_5; }
	inline float* get_address_of_paddingContentEnd_5() { return &___paddingContentEnd_5; }
	inline void set_paddingContentEnd_5(float value)
	{
		___paddingContentEnd_5 = value;
	}

	inline static int32_t get_offset_of_paddingStartPlusEnd_6() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___paddingStartPlusEnd_6)); }
	inline float get_paddingStartPlusEnd_6() const { return ___paddingStartPlusEnd_6; }
	inline float* get_address_of_paddingStartPlusEnd_6() { return &___paddingStartPlusEnd_6; }
	inline void set_paddingStartPlusEnd_6(float value)
	{
		___paddingStartPlusEnd_6 = value;
	}

	inline static int32_t get_offset_of_spacing_7() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___spacing_7)); }
	inline float get_spacing_7() const { return ___spacing_7; }
	inline float* get_address_of_spacing_7() { return &___spacing_7; }
	inline void set_spacing_7(float value)
	{
		___spacing_7 = value;
	}

	inline static int32_t get_offset_of_startEdge_8() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___startEdge_8)); }
	inline int32_t get_startEdge_8() const { return ___startEdge_8; }
	inline int32_t* get_address_of_startEdge_8() { return &___startEdge_8; }
	inline void set_startEdge_8(int32_t value)
	{
		___startEdge_8 = value;
	}

	inline static int32_t get_offset_of_endEdge_9() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___endEdge_9)); }
	inline int32_t get_endEdge_9() const { return ___endEdge_9; }
	inline int32_t* get_address_of_endEdge_9() { return &___endEdge_9; }
	inline void set_endEdge_9(int32_t value)
	{
		___endEdge_9 = value;
	}

	inline static int32_t get_offset_of_transvStartEdge_10() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___transvStartEdge_10)); }
	inline int32_t get_transvStartEdge_10() const { return ___transvStartEdge_10; }
	inline int32_t* get_address_of_transvStartEdge_10() { return &___transvStartEdge_10; }
	inline void set_transvStartEdge_10(int32_t value)
	{
		___transvStartEdge_10 = value;
	}

	inline static int32_t get_offset_of_lastProcessedCTVirtualInsetFromParentStart_11() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___lastProcessedCTVirtualInsetFromParentStart_11)); }
	inline double get_lastProcessedCTVirtualInsetFromParentStart_11() const { return ___lastProcessedCTVirtualInsetFromParentStart_11; }
	inline double* get_address_of_lastProcessedCTVirtualInsetFromParentStart_11() { return &___lastProcessedCTVirtualInsetFromParentStart_11; }
	inline void set_lastProcessedCTVirtualInsetFromParentStart_11(double value)
	{
		___lastProcessedCTVirtualInsetFromParentStart_11 = value;
	}

	inline static int32_t get_offset_of_contentPanelSkippedInsetDueToVirtualization_12() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___contentPanelSkippedInsetDueToVirtualization_12)); }
	inline double get_contentPanelSkippedInsetDueToVirtualization_12() const { return ___contentPanelSkippedInsetDueToVirtualization_12; }
	inline double* get_address_of_contentPanelSkippedInsetDueToVirtualization_12() { return &___contentPanelSkippedInsetDueToVirtualization_12; }
	inline void set_contentPanelSkippedInsetDueToVirtualization_12(double value)
	{
		___contentPanelSkippedInsetDueToVirtualization_12 = value;
	}

	inline static int32_t get_offset_of_scrollViewSize_13() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___scrollViewSize_13)); }
	inline Vector2_t2243707579  get_scrollViewSize_13() const { return ___scrollViewSize_13; }
	inline Vector2_t2243707579 * get_address_of_scrollViewSize_13() { return &___scrollViewSize_13; }
	inline void set_scrollViewSize_13(Vector2_t2243707579  value)
	{
		___scrollViewSize_13 = value;
	}

	inline static int32_t get_offset_of_contentPanelSize_14() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___contentPanelSize_14)); }
	inline float get_contentPanelSize_14() const { return ___contentPanelSize_14; }
	inline float* get_address_of_contentPanelSize_14() { return &___contentPanelSize_14; }
	inline void set_contentPanelSize_14(float value)
	{
		___contentPanelSize_14 = value;
	}

	inline static int32_t get_offset_of_contentPanelVirtualSize_15() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___contentPanelVirtualSize_15)); }
	inline double get_contentPanelVirtualSize_15() const { return ___contentPanelVirtualSize_15; }
	inline double* get_address_of_contentPanelVirtualSize_15() { return &___contentPanelVirtualSize_15; }
	inline void set_contentPanelVirtualSize_15(double value)
	{
		___contentPanelVirtualSize_15 = value;
	}

	inline static int32_t get_offset_of_updateRequestPending_16() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___updateRequestPending_16)); }
	inline bool get_updateRequestPending_16() const { return ___updateRequestPending_16; }
	inline bool* get_address_of_updateRequestPending_16() { return &___updateRequestPending_16; }
	inline void set_updateRequestPending_16(bool value)
	{
		___updateRequestPending_16 = value;
	}

	inline static int32_t get_offset_of_computeVisibilityTwinPassScheduled_17() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___computeVisibilityTwinPassScheduled_17)); }
	inline bool get_computeVisibilityTwinPassScheduled_17() const { return ___computeVisibilityTwinPassScheduled_17; }
	inline bool* get_address_of_computeVisibilityTwinPassScheduled_17() { return &___computeVisibilityTwinPassScheduled_17; }
	inline void set_computeVisibilityTwinPassScheduled_17(bool value)
	{
		___computeVisibilityTwinPassScheduled_17 = value;
	}

	inline static int32_t get_offset_of_preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass_18() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass_18)); }
	inline bool get_preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass_18() const { return ___preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass_18; }
	inline bool* get_address_of_preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass_18() { return &___preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass_18; }
	inline void set_preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass_18(bool value)
	{
		___preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass_18 = value;
	}

	inline static int32_t get_offset_of_lastComputeVisibilityHadATwinPass_19() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ___lastComputeVisibilityHadATwinPass_19)); }
	inline bool get_lastComputeVisibilityHadATwinPass_19() const { return ___lastComputeVisibilityHadATwinPass_19; }
	inline bool* get_address_of_lastComputeVisibilityHadATwinPass_19() { return &___lastComputeVisibilityHadATwinPass_19; }
	inline void set_lastComputeVisibilityHadATwinPass_19(bool value)
	{
		___lastComputeVisibilityHadATwinPass_19 = value;
	}

	inline static int32_t get_offset_of__ItemsDesc_20() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ____ItemsDesc_20)); }
	inline ItemsDescriptor_t3229248635 * get__ItemsDesc_20() const { return ____ItemsDesc_20; }
	inline ItemsDescriptor_t3229248635 ** get_address_of__ItemsDesc_20() { return &____ItemsDesc_20; }
	inline void set__ItemsDesc_20(ItemsDescriptor_t3229248635 * value)
	{
		____ItemsDesc_20 = value;
		Il2CppCodeGenWriteBarrier(&____ItemsDesc_20, value);
	}

	inline static int32_t get_offset_of__SourceParams_21() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ____SourceParams_21)); }
	inline UIData_t2529106927 * get__SourceParams_21() const { return ____SourceParams_21; }
	inline UIData_t2529106927 ** get_address_of__SourceParams_21() { return &____SourceParams_21; }
	inline void set__SourceParams_21(UIData_t2529106927 * value)
	{
		____SourceParams_21 = value;
		Il2CppCodeGenWriteBarrier(&____SourceParams_21, value);
	}

	inline static int32_t get_offset_of__GetRTCurrentSizeFn_22() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921, ____GetRTCurrentSizeFn_22)); }
	inline Func_2_t2546352383 * get__GetRTCurrentSizeFn_22() const { return ____GetRTCurrentSizeFn_22; }
	inline Func_2_t2546352383 ** get_address_of__GetRTCurrentSizeFn_22() { return &____GetRTCurrentSizeFn_22; }
	inline void set__GetRTCurrentSizeFn_22(Func_2_t2546352383 * value)
	{
		____GetRTCurrentSizeFn_22 = value;
		Il2CppCodeGenWriteBarrier(&____GetRTCurrentSizeFn_22, value);
	}
};

struct InternalStateGeneric_2_t1773261921_StaticFields
{
public:
	// System.Func`2<UnityEngine.RectTransform,System.Single> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::<>f__am$cache0
	Func_2_t2546352383 * ___U3CU3Ef__amU24cache0_23;
	// System.Func`2<UnityEngine.RectTransform,System.Single> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.InternalStateGeneric`2::<>f__am$cache1
	Func_2_t2546352383 * ___U3CU3Ef__amU24cache1_24;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_23() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921_StaticFields, ___U3CU3Ef__amU24cache0_23)); }
	inline Func_2_t2546352383 * get_U3CU3Ef__amU24cache0_23() const { return ___U3CU3Ef__amU24cache0_23; }
	inline Func_2_t2546352383 ** get_address_of_U3CU3Ef__amU24cache0_23() { return &___U3CU3Ef__amU24cache0_23; }
	inline void set_U3CU3Ef__amU24cache0_23(Func_2_t2546352383 * value)
	{
		___U3CU3Ef__amU24cache0_23 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_23, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache1_24() { return static_cast<int32_t>(offsetof(InternalStateGeneric_2_t1773261921_StaticFields, ___U3CU3Ef__amU24cache1_24)); }
	inline Func_2_t2546352383 * get_U3CU3Ef__amU24cache1_24() const { return ___U3CU3Ef__amU24cache1_24; }
	inline Func_2_t2546352383 ** get_address_of_U3CU3Ef__amU24cache1_24() { return &___U3CU3Ef__amU24cache1_24; }
	inline void set_U3CU3Ef__amU24cache1_24(Func_2_t2546352383 * value)
	{
		___U3CU3Ef__amU24cache1_24 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache1_24, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
