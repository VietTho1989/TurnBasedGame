#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_EventSystems_UIBehaviou3960014691.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"
#include "UnityEngine_UnityEngine_DrivenRectTransformTracker154385424.h"

// UnityEngine.RectTransform
struct RectTransform_t3349966182;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.TileSizeFitter
struct  TileSizeFitter_t2558755467  : public UIBehaviour_t3960014691
{
public:
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.TileSizeFitter::m_Border
	Vector2_t2243707579  ___m_Border_2;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.TileSizeFitter::m_TileSize
	Vector2_t2243707579  ___m_TileSize_3;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.TileSizeFitter::m_Rect
	RectTransform_t3349966182 * ___m_Rect_4;
	// UnityEngine.DrivenRectTransformTracker UnityEngine.UI.Extensions.TileSizeFitter::m_Tracker
	DrivenRectTransformTracker_t154385424  ___m_Tracker_5;

public:
	inline static int32_t get_offset_of_m_Border_2() { return static_cast<int32_t>(offsetof(TileSizeFitter_t2558755467, ___m_Border_2)); }
	inline Vector2_t2243707579  get_m_Border_2() const { return ___m_Border_2; }
	inline Vector2_t2243707579 * get_address_of_m_Border_2() { return &___m_Border_2; }
	inline void set_m_Border_2(Vector2_t2243707579  value)
	{
		___m_Border_2 = value;
	}

	inline static int32_t get_offset_of_m_TileSize_3() { return static_cast<int32_t>(offsetof(TileSizeFitter_t2558755467, ___m_TileSize_3)); }
	inline Vector2_t2243707579  get_m_TileSize_3() const { return ___m_TileSize_3; }
	inline Vector2_t2243707579 * get_address_of_m_TileSize_3() { return &___m_TileSize_3; }
	inline void set_m_TileSize_3(Vector2_t2243707579  value)
	{
		___m_TileSize_3 = value;
	}

	inline static int32_t get_offset_of_m_Rect_4() { return static_cast<int32_t>(offsetof(TileSizeFitter_t2558755467, ___m_Rect_4)); }
	inline RectTransform_t3349966182 * get_m_Rect_4() const { return ___m_Rect_4; }
	inline RectTransform_t3349966182 ** get_address_of_m_Rect_4() { return &___m_Rect_4; }
	inline void set_m_Rect_4(RectTransform_t3349966182 * value)
	{
		___m_Rect_4 = value;
		Il2CppCodeGenWriteBarrier(&___m_Rect_4, value);
	}

	inline static int32_t get_offset_of_m_Tracker_5() { return static_cast<int32_t>(offsetof(TileSizeFitter_t2558755467, ___m_Tracker_5)); }
	inline DrivenRectTransformTracker_t154385424  get_m_Tracker_5() const { return ___m_Tracker_5; }
	inline DrivenRectTransformTracker_t154385424 * get_address_of_m_Tracker_5() { return &___m_Tracker_5; }
	inline void set_m_Tracker_5(DrivenRectTransformTracker_t154385424  value)
	{
		___m_Tracker_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
