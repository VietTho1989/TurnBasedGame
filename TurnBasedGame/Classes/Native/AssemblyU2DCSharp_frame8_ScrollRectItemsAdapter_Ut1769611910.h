#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_ScrollRectItemsAdapter_Ut3372597009.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"

// UnityEngine.RectTransform
struct RectTransform_t3349966182;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshRotateGizmo
struct  PullToRefreshRotateGizmo_t1769611910  : public PullToRefreshGizmo_t3372597009
{
public:
	// UnityEngine.RectTransform frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshRotateGizmo::_StartingPoint
	RectTransform_t3349966182 * ____StartingPoint_3;
	// UnityEngine.RectTransform frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshRotateGizmo::_EndingPoint
	RectTransform_t3349966182 * ____EndingPoint_4;
	// System.Single frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshRotateGizmo::_ExcessPullRotationDamping
	float ____ExcessPullRotationDamping_5;
	// System.Single frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshRotateGizmo::_AutoRotationDegreesPerSec
	float ____AutoRotationDegreesPerSec_6;
	// System.Boolean frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshRotateGizmo::_WaitingForManualHide
	bool ____WaitingForManualHide_7;
	// UnityEngine.Vector3 frame8.ScrollRectItemsAdapter.Util.PullToRefresh.PullToRefreshRotateGizmo::_InitialLocalRotation
	Vector3_t2243707580  ____InitialLocalRotation_8;

public:
	inline static int32_t get_offset_of__StartingPoint_3() { return static_cast<int32_t>(offsetof(PullToRefreshRotateGizmo_t1769611910, ____StartingPoint_3)); }
	inline RectTransform_t3349966182 * get__StartingPoint_3() const { return ____StartingPoint_3; }
	inline RectTransform_t3349966182 ** get_address_of__StartingPoint_3() { return &____StartingPoint_3; }
	inline void set__StartingPoint_3(RectTransform_t3349966182 * value)
	{
		____StartingPoint_3 = value;
		Il2CppCodeGenWriteBarrier(&____StartingPoint_3, value);
	}

	inline static int32_t get_offset_of__EndingPoint_4() { return static_cast<int32_t>(offsetof(PullToRefreshRotateGizmo_t1769611910, ____EndingPoint_4)); }
	inline RectTransform_t3349966182 * get__EndingPoint_4() const { return ____EndingPoint_4; }
	inline RectTransform_t3349966182 ** get_address_of__EndingPoint_4() { return &____EndingPoint_4; }
	inline void set__EndingPoint_4(RectTransform_t3349966182 * value)
	{
		____EndingPoint_4 = value;
		Il2CppCodeGenWriteBarrier(&____EndingPoint_4, value);
	}

	inline static int32_t get_offset_of__ExcessPullRotationDamping_5() { return static_cast<int32_t>(offsetof(PullToRefreshRotateGizmo_t1769611910, ____ExcessPullRotationDamping_5)); }
	inline float get__ExcessPullRotationDamping_5() const { return ____ExcessPullRotationDamping_5; }
	inline float* get_address_of__ExcessPullRotationDamping_5() { return &____ExcessPullRotationDamping_5; }
	inline void set__ExcessPullRotationDamping_5(float value)
	{
		____ExcessPullRotationDamping_5 = value;
	}

	inline static int32_t get_offset_of__AutoRotationDegreesPerSec_6() { return static_cast<int32_t>(offsetof(PullToRefreshRotateGizmo_t1769611910, ____AutoRotationDegreesPerSec_6)); }
	inline float get__AutoRotationDegreesPerSec_6() const { return ____AutoRotationDegreesPerSec_6; }
	inline float* get_address_of__AutoRotationDegreesPerSec_6() { return &____AutoRotationDegreesPerSec_6; }
	inline void set__AutoRotationDegreesPerSec_6(float value)
	{
		____AutoRotationDegreesPerSec_6 = value;
	}

	inline static int32_t get_offset_of__WaitingForManualHide_7() { return static_cast<int32_t>(offsetof(PullToRefreshRotateGizmo_t1769611910, ____WaitingForManualHide_7)); }
	inline bool get__WaitingForManualHide_7() const { return ____WaitingForManualHide_7; }
	inline bool* get_address_of__WaitingForManualHide_7() { return &____WaitingForManualHide_7; }
	inline void set__WaitingForManualHide_7(bool value)
	{
		____WaitingForManualHide_7 = value;
	}

	inline static int32_t get_offset_of__InitialLocalRotation_8() { return static_cast<int32_t>(offsetof(PullToRefreshRotateGizmo_t1769611910, ____InitialLocalRotation_8)); }
	inline Vector3_t2243707580  get__InitialLocalRotation_8() const { return ____InitialLocalRotation_8; }
	inline Vector3_t2243707580 * get_address_of__InitialLocalRotation_8() { return &____InitialLocalRotation_8; }
	inline void set__InitialLocalRotation_8(Vector3_t2243707580  value)
	{
		____InitialLocalRotation_8 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
