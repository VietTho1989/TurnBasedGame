#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_UI_BaseMeshEffect1728560551.h"

// UnityEngine.AnimationCurve
struct AnimationCurve_t3306541151;
// UnityEngine.RectTransform
struct RectTransform_t3349966182;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.CurvedText
struct  CurvedText_t3665035540  : public BaseMeshEffect_t1728560551
{
public:
	// UnityEngine.AnimationCurve UnityEngine.UI.Extensions.CurvedText::curveForText
	AnimationCurve_t3306541151 * ___curveForText_3;
	// System.Single UnityEngine.UI.Extensions.CurvedText::curveMultiplier
	float ___curveMultiplier_4;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.CurvedText::rectTrans
	RectTransform_t3349966182 * ___rectTrans_5;

public:
	inline static int32_t get_offset_of_curveForText_3() { return static_cast<int32_t>(offsetof(CurvedText_t3665035540, ___curveForText_3)); }
	inline AnimationCurve_t3306541151 * get_curveForText_3() const { return ___curveForText_3; }
	inline AnimationCurve_t3306541151 ** get_address_of_curveForText_3() { return &___curveForText_3; }
	inline void set_curveForText_3(AnimationCurve_t3306541151 * value)
	{
		___curveForText_3 = value;
		Il2CppCodeGenWriteBarrier(&___curveForText_3, value);
	}

	inline static int32_t get_offset_of_curveMultiplier_4() { return static_cast<int32_t>(offsetof(CurvedText_t3665035540, ___curveMultiplier_4)); }
	inline float get_curveMultiplier_4() const { return ___curveMultiplier_4; }
	inline float* get_address_of_curveMultiplier_4() { return &___curveMultiplier_4; }
	inline void set_curveMultiplier_4(float value)
	{
		___curveMultiplier_4 = value;
	}

	inline static int32_t get_offset_of_rectTrans_5() { return static_cast<int32_t>(offsetof(CurvedText_t3665035540, ___rectTrans_5)); }
	inline RectTransform_t3349966182 * get_rectTrans_5() const { return ___rectTrans_5; }
	inline RectTransform_t3349966182 ** get_address_of_rectTrans_5() { return &___rectTrans_5; }
	inline void set_rectTrans_5(RectTransform_t3349966182 * value)
	{
		___rectTrans_5 = value;
		Il2CppCodeGenWriteBarrier(&___rectTrans_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
