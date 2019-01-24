#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_UI_LayoutGroup3962498969.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.CurvedLayout
struct  CurvedLayout_t31468887  : public LayoutGroup_t3962498969
{
public:
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.CurvedLayout::CurveOffset
	Vector3_t2243707580  ___CurveOffset_10;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.CurvedLayout::itemAxis
	Vector3_t2243707580  ___itemAxis_11;
	// System.Single UnityEngine.UI.Extensions.CurvedLayout::itemSize
	float ___itemSize_12;
	// System.Single UnityEngine.UI.Extensions.CurvedLayout::centerpoint
	float ___centerpoint_13;

public:
	inline static int32_t get_offset_of_CurveOffset_10() { return static_cast<int32_t>(offsetof(CurvedLayout_t31468887, ___CurveOffset_10)); }
	inline Vector3_t2243707580  get_CurveOffset_10() const { return ___CurveOffset_10; }
	inline Vector3_t2243707580 * get_address_of_CurveOffset_10() { return &___CurveOffset_10; }
	inline void set_CurveOffset_10(Vector3_t2243707580  value)
	{
		___CurveOffset_10 = value;
	}

	inline static int32_t get_offset_of_itemAxis_11() { return static_cast<int32_t>(offsetof(CurvedLayout_t31468887, ___itemAxis_11)); }
	inline Vector3_t2243707580  get_itemAxis_11() const { return ___itemAxis_11; }
	inline Vector3_t2243707580 * get_address_of_itemAxis_11() { return &___itemAxis_11; }
	inline void set_itemAxis_11(Vector3_t2243707580  value)
	{
		___itemAxis_11 = value;
	}

	inline static int32_t get_offset_of_itemSize_12() { return static_cast<int32_t>(offsetof(CurvedLayout_t31468887, ___itemSize_12)); }
	inline float get_itemSize_12() const { return ___itemSize_12; }
	inline float* get_address_of_itemSize_12() { return &___itemSize_12; }
	inline void set_itemSize_12(float value)
	{
		___itemSize_12 = value;
	}

	inline static int32_t get_offset_of_centerpoint_13() { return static_cast<int32_t>(offsetof(CurvedLayout_t31468887, ___centerpoint_13)); }
	inline float get_centerpoint_13() const { return ___centerpoint_13; }
	inline float* get_address_of_centerpoint_13() { return &___centerpoint_13; }
	inline void set_centerpoint_13(float value)
	{
		___centerpoint_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
