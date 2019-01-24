#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_RectTransform_Edge3306019089.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// System.Action
struct Action_t3226471752;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.RectTransformEdgeDragger
struct  RectTransformEdgeDragger_t1087711563  : public MonoBehaviour_t1158329972
{
public:
	// System.Action frame8.ScrollRectItemsAdapter.Util.RectTransformEdgeDragger::TargetDragged
	Action_t3226471752 * ___TargetDragged_2;
	// UnityEngine.RectTransform frame8.ScrollRectItemsAdapter.Util.RectTransformEdgeDragger::draggedRectTransform
	RectTransform_t3349966182 * ___draggedRectTransform_3;
	// UnityEngine.RectTransform/Edge frame8.ScrollRectItemsAdapter.Util.RectTransformEdgeDragger::draggedEdge
	int32_t ___draggedEdge_4;
	// System.Single frame8.ScrollRectItemsAdapter.Util.RectTransformEdgeDragger::maxDistance
	float ___maxDistance_5;
	// UnityEngine.RectTransform frame8.ScrollRectItemsAdapter.Util.RectTransformEdgeDragger::rt
	RectTransform_t3349966182 * ___rt_6;
	// UnityEngine.Vector2 frame8.ScrollRectItemsAdapter.Util.RectTransformEdgeDragger::startDragPos
	Vector2_t2243707579  ___startDragPos_7;
	// UnityEngine.Vector2 frame8.ScrollRectItemsAdapter.Util.RectTransformEdgeDragger::initialPos
	Vector2_t2243707579  ___initialPos_8;
	// System.Single frame8.ScrollRectItemsAdapter.Util.RectTransformEdgeDragger::startInset
	float ___startInset_9;
	// System.Single frame8.ScrollRectItemsAdapter.Util.RectTransformEdgeDragger::startSize
	float ___startSize_10;

public:
	inline static int32_t get_offset_of_TargetDragged_2() { return static_cast<int32_t>(offsetof(RectTransformEdgeDragger_t1087711563, ___TargetDragged_2)); }
	inline Action_t3226471752 * get_TargetDragged_2() const { return ___TargetDragged_2; }
	inline Action_t3226471752 ** get_address_of_TargetDragged_2() { return &___TargetDragged_2; }
	inline void set_TargetDragged_2(Action_t3226471752 * value)
	{
		___TargetDragged_2 = value;
		Il2CppCodeGenWriteBarrier(&___TargetDragged_2, value);
	}

	inline static int32_t get_offset_of_draggedRectTransform_3() { return static_cast<int32_t>(offsetof(RectTransformEdgeDragger_t1087711563, ___draggedRectTransform_3)); }
	inline RectTransform_t3349966182 * get_draggedRectTransform_3() const { return ___draggedRectTransform_3; }
	inline RectTransform_t3349966182 ** get_address_of_draggedRectTransform_3() { return &___draggedRectTransform_3; }
	inline void set_draggedRectTransform_3(RectTransform_t3349966182 * value)
	{
		___draggedRectTransform_3 = value;
		Il2CppCodeGenWriteBarrier(&___draggedRectTransform_3, value);
	}

	inline static int32_t get_offset_of_draggedEdge_4() { return static_cast<int32_t>(offsetof(RectTransformEdgeDragger_t1087711563, ___draggedEdge_4)); }
	inline int32_t get_draggedEdge_4() const { return ___draggedEdge_4; }
	inline int32_t* get_address_of_draggedEdge_4() { return &___draggedEdge_4; }
	inline void set_draggedEdge_4(int32_t value)
	{
		___draggedEdge_4 = value;
	}

	inline static int32_t get_offset_of_maxDistance_5() { return static_cast<int32_t>(offsetof(RectTransformEdgeDragger_t1087711563, ___maxDistance_5)); }
	inline float get_maxDistance_5() const { return ___maxDistance_5; }
	inline float* get_address_of_maxDistance_5() { return &___maxDistance_5; }
	inline void set_maxDistance_5(float value)
	{
		___maxDistance_5 = value;
	}

	inline static int32_t get_offset_of_rt_6() { return static_cast<int32_t>(offsetof(RectTransformEdgeDragger_t1087711563, ___rt_6)); }
	inline RectTransform_t3349966182 * get_rt_6() const { return ___rt_6; }
	inline RectTransform_t3349966182 ** get_address_of_rt_6() { return &___rt_6; }
	inline void set_rt_6(RectTransform_t3349966182 * value)
	{
		___rt_6 = value;
		Il2CppCodeGenWriteBarrier(&___rt_6, value);
	}

	inline static int32_t get_offset_of_startDragPos_7() { return static_cast<int32_t>(offsetof(RectTransformEdgeDragger_t1087711563, ___startDragPos_7)); }
	inline Vector2_t2243707579  get_startDragPos_7() const { return ___startDragPos_7; }
	inline Vector2_t2243707579 * get_address_of_startDragPos_7() { return &___startDragPos_7; }
	inline void set_startDragPos_7(Vector2_t2243707579  value)
	{
		___startDragPos_7 = value;
	}

	inline static int32_t get_offset_of_initialPos_8() { return static_cast<int32_t>(offsetof(RectTransformEdgeDragger_t1087711563, ___initialPos_8)); }
	inline Vector2_t2243707579  get_initialPos_8() const { return ___initialPos_8; }
	inline Vector2_t2243707579 * get_address_of_initialPos_8() { return &___initialPos_8; }
	inline void set_initialPos_8(Vector2_t2243707579  value)
	{
		___initialPos_8 = value;
	}

	inline static int32_t get_offset_of_startInset_9() { return static_cast<int32_t>(offsetof(RectTransformEdgeDragger_t1087711563, ___startInset_9)); }
	inline float get_startInset_9() const { return ___startInset_9; }
	inline float* get_address_of_startInset_9() { return &___startInset_9; }
	inline void set_startInset_9(float value)
	{
		___startInset_9 = value;
	}

	inline static int32_t get_offset_of_startSize_10() { return static_cast<int32_t>(offsetof(RectTransformEdgeDragger_t1087711563, ___startSize_10)); }
	inline float get_startSize_10() const { return ___startSize_10; }
	inline float* get_address_of_startSize_10() { return &___startSize_10; }
	inline void set_startSize_10(float value)
	{
		___startSize_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
