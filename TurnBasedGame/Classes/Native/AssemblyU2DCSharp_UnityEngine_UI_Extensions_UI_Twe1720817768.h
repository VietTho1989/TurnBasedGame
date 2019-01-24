#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"

// UnityEngine.AnimationCurve
struct AnimationCurve_t3306541151;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UI_TweenScale
struct  UI_TweenScale_t1720817768  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.AnimationCurve UnityEngine.UI.Extensions.UI_TweenScale::animCurve
	AnimationCurve_t3306541151 * ___animCurve_2;
	// System.Single UnityEngine.UI.Extensions.UI_TweenScale::speed
	float ___speed_3;
	// System.Boolean UnityEngine.UI.Extensions.UI_TweenScale::isLoop
	bool ___isLoop_4;
	// System.Boolean UnityEngine.UI.Extensions.UI_TweenScale::playAtAwake
	bool ___playAtAwake_5;
	// System.Boolean UnityEngine.UI.Extensions.UI_TweenScale::isUniform
	bool ___isUniform_6;
	// UnityEngine.AnimationCurve UnityEngine.UI.Extensions.UI_TweenScale::animCurveY
	AnimationCurve_t3306541151 * ___animCurveY_7;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.UI_TweenScale::initScale
	Vector3_t2243707580  ___initScale_8;
	// UnityEngine.Transform UnityEngine.UI.Extensions.UI_TweenScale::myTransform
	Transform_t3275118058 * ___myTransform_9;
	// UnityEngine.Vector3 UnityEngine.UI.Extensions.UI_TweenScale::newScale
	Vector3_t2243707580  ___newScale_10;

public:
	inline static int32_t get_offset_of_animCurve_2() { return static_cast<int32_t>(offsetof(UI_TweenScale_t1720817768, ___animCurve_2)); }
	inline AnimationCurve_t3306541151 * get_animCurve_2() const { return ___animCurve_2; }
	inline AnimationCurve_t3306541151 ** get_address_of_animCurve_2() { return &___animCurve_2; }
	inline void set_animCurve_2(AnimationCurve_t3306541151 * value)
	{
		___animCurve_2 = value;
		Il2CppCodeGenWriteBarrier(&___animCurve_2, value);
	}

	inline static int32_t get_offset_of_speed_3() { return static_cast<int32_t>(offsetof(UI_TweenScale_t1720817768, ___speed_3)); }
	inline float get_speed_3() const { return ___speed_3; }
	inline float* get_address_of_speed_3() { return &___speed_3; }
	inline void set_speed_3(float value)
	{
		___speed_3 = value;
	}

	inline static int32_t get_offset_of_isLoop_4() { return static_cast<int32_t>(offsetof(UI_TweenScale_t1720817768, ___isLoop_4)); }
	inline bool get_isLoop_4() const { return ___isLoop_4; }
	inline bool* get_address_of_isLoop_4() { return &___isLoop_4; }
	inline void set_isLoop_4(bool value)
	{
		___isLoop_4 = value;
	}

	inline static int32_t get_offset_of_playAtAwake_5() { return static_cast<int32_t>(offsetof(UI_TweenScale_t1720817768, ___playAtAwake_5)); }
	inline bool get_playAtAwake_5() const { return ___playAtAwake_5; }
	inline bool* get_address_of_playAtAwake_5() { return &___playAtAwake_5; }
	inline void set_playAtAwake_5(bool value)
	{
		___playAtAwake_5 = value;
	}

	inline static int32_t get_offset_of_isUniform_6() { return static_cast<int32_t>(offsetof(UI_TweenScale_t1720817768, ___isUniform_6)); }
	inline bool get_isUniform_6() const { return ___isUniform_6; }
	inline bool* get_address_of_isUniform_6() { return &___isUniform_6; }
	inline void set_isUniform_6(bool value)
	{
		___isUniform_6 = value;
	}

	inline static int32_t get_offset_of_animCurveY_7() { return static_cast<int32_t>(offsetof(UI_TweenScale_t1720817768, ___animCurveY_7)); }
	inline AnimationCurve_t3306541151 * get_animCurveY_7() const { return ___animCurveY_7; }
	inline AnimationCurve_t3306541151 ** get_address_of_animCurveY_7() { return &___animCurveY_7; }
	inline void set_animCurveY_7(AnimationCurve_t3306541151 * value)
	{
		___animCurveY_7 = value;
		Il2CppCodeGenWriteBarrier(&___animCurveY_7, value);
	}

	inline static int32_t get_offset_of_initScale_8() { return static_cast<int32_t>(offsetof(UI_TweenScale_t1720817768, ___initScale_8)); }
	inline Vector3_t2243707580  get_initScale_8() const { return ___initScale_8; }
	inline Vector3_t2243707580 * get_address_of_initScale_8() { return &___initScale_8; }
	inline void set_initScale_8(Vector3_t2243707580  value)
	{
		___initScale_8 = value;
	}

	inline static int32_t get_offset_of_myTransform_9() { return static_cast<int32_t>(offsetof(UI_TweenScale_t1720817768, ___myTransform_9)); }
	inline Transform_t3275118058 * get_myTransform_9() const { return ___myTransform_9; }
	inline Transform_t3275118058 ** get_address_of_myTransform_9() { return &___myTransform_9; }
	inline void set_myTransform_9(Transform_t3275118058 * value)
	{
		___myTransform_9 = value;
		Il2CppCodeGenWriteBarrier(&___myTransform_9, value);
	}

	inline static int32_t get_offset_of_newScale_10() { return static_cast<int32_t>(offsetof(UI_TweenScale_t1720817768, ___newScale_10)); }
	inline Vector3_t2243707580  get_newScale_10() const { return ___newScale_10; }
	inline Vector3_t2243707580 * get_address_of_newScale_10() { return &___newScale_10; }
	inline void set_newScale_10(Vector3_t2243707580  value)
	{
		___newScale_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
