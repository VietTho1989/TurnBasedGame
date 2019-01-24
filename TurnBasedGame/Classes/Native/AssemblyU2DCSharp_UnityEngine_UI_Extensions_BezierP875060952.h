#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<UnityEngine.Vector2>
struct List_1_t1612828711;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.BezierPath
struct  BezierPath_t875060952  : public Il2CppObject
{
public:
	// System.Int32 UnityEngine.UI.Extensions.BezierPath::SegmentsPerCurve
	int32_t ___SegmentsPerCurve_0;
	// System.Single UnityEngine.UI.Extensions.BezierPath::MINIMUM_SQR_DISTANCE
	float ___MINIMUM_SQR_DISTANCE_1;
	// System.Single UnityEngine.UI.Extensions.BezierPath::DIVISION_THRESHOLD
	float ___DIVISION_THRESHOLD_2;
	// System.Collections.Generic.List`1<UnityEngine.Vector2> UnityEngine.UI.Extensions.BezierPath::controlPoints
	List_1_t1612828711 * ___controlPoints_3;
	// System.Int32 UnityEngine.UI.Extensions.BezierPath::curveCount
	int32_t ___curveCount_4;

public:
	inline static int32_t get_offset_of_SegmentsPerCurve_0() { return static_cast<int32_t>(offsetof(BezierPath_t875060952, ___SegmentsPerCurve_0)); }
	inline int32_t get_SegmentsPerCurve_0() const { return ___SegmentsPerCurve_0; }
	inline int32_t* get_address_of_SegmentsPerCurve_0() { return &___SegmentsPerCurve_0; }
	inline void set_SegmentsPerCurve_0(int32_t value)
	{
		___SegmentsPerCurve_0 = value;
	}

	inline static int32_t get_offset_of_MINIMUM_SQR_DISTANCE_1() { return static_cast<int32_t>(offsetof(BezierPath_t875060952, ___MINIMUM_SQR_DISTANCE_1)); }
	inline float get_MINIMUM_SQR_DISTANCE_1() const { return ___MINIMUM_SQR_DISTANCE_1; }
	inline float* get_address_of_MINIMUM_SQR_DISTANCE_1() { return &___MINIMUM_SQR_DISTANCE_1; }
	inline void set_MINIMUM_SQR_DISTANCE_1(float value)
	{
		___MINIMUM_SQR_DISTANCE_1 = value;
	}

	inline static int32_t get_offset_of_DIVISION_THRESHOLD_2() { return static_cast<int32_t>(offsetof(BezierPath_t875060952, ___DIVISION_THRESHOLD_2)); }
	inline float get_DIVISION_THRESHOLD_2() const { return ___DIVISION_THRESHOLD_2; }
	inline float* get_address_of_DIVISION_THRESHOLD_2() { return &___DIVISION_THRESHOLD_2; }
	inline void set_DIVISION_THRESHOLD_2(float value)
	{
		___DIVISION_THRESHOLD_2 = value;
	}

	inline static int32_t get_offset_of_controlPoints_3() { return static_cast<int32_t>(offsetof(BezierPath_t875060952, ___controlPoints_3)); }
	inline List_1_t1612828711 * get_controlPoints_3() const { return ___controlPoints_3; }
	inline List_1_t1612828711 ** get_address_of_controlPoints_3() { return &___controlPoints_3; }
	inline void set_controlPoints_3(List_1_t1612828711 * value)
	{
		___controlPoints_3 = value;
		Il2CppCodeGenWriteBarrier(&___controlPoints_3, value);
	}

	inline static int32_t get_offset_of_curveCount_4() { return static_cast<int32_t>(offsetof(BezierPath_t875060952, ___curveCount_4)); }
	inline int32_t get_curveCount_4() const { return ___curveCount_4; }
	inline int32_t* get_address_of_curveCount_4() { return &___curveCount_4; }
	inline void set_curveCount_4(int32_t value)
	{
		___curveCount_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
