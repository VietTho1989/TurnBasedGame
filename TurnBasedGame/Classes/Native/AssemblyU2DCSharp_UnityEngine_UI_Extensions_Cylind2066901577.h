#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_UI_BaseMeshEffect1728560551.h"

// UnityEngine.RectTransform
struct RectTransform_t3349966182;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.CylinderText
struct  CylinderText_t2066901577  : public BaseMeshEffect_t1728560551
{
public:
	// System.Single UnityEngine.UI.Extensions.CylinderText::radius
	float ___radius_3;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.CylinderText::rectTrans
	RectTransform_t3349966182 * ___rectTrans_4;

public:
	inline static int32_t get_offset_of_radius_3() { return static_cast<int32_t>(offsetof(CylinderText_t2066901577, ___radius_3)); }
	inline float get_radius_3() const { return ___radius_3; }
	inline float* get_address_of_radius_3() { return &___radius_3; }
	inline void set_radius_3(float value)
	{
		___radius_3 = value;
	}

	inline static int32_t get_offset_of_rectTrans_4() { return static_cast<int32_t>(offsetof(CylinderText_t2066901577, ___rectTrans_4)); }
	inline RectTransform_t3349966182 * get_rectTrans_4() const { return ___rectTrans_4; }
	inline RectTransform_t3349966182 ** get_address_of_rectTrans_4() { return &___rectTrans_4; }
	inline void set_rectTrans_4(RectTransform_t3349966182 * value)
	{
		___rectTrans_4 = value;
		Il2CppCodeGenWriteBarrier(&___rectTrans_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
