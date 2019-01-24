#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_UI_BaseMeshEffect1728560551.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_Gradien763701076.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_Gradie3762654957.h"

// UnityEngine.Gradient
struct Gradient_t3600583008;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.Gradient2
struct  Gradient2_t998070926  : public BaseMeshEffect_t1728560551
{
public:
	// UnityEngine.UI.Extensions.Gradient2/Type UnityEngine.UI.Extensions.Gradient2::_gradientType
	int32_t ____gradientType_3;
	// UnityEngine.UI.Extensions.Gradient2/Blend UnityEngine.UI.Extensions.Gradient2::_blendMode
	int32_t ____blendMode_4;
	// System.Single UnityEngine.UI.Extensions.Gradient2::_offset
	float ____offset_5;
	// UnityEngine.Gradient UnityEngine.UI.Extensions.Gradient2::_effectGradient
	Gradient_t3600583008 * ____effectGradient_6;

public:
	inline static int32_t get_offset_of__gradientType_3() { return static_cast<int32_t>(offsetof(Gradient2_t998070926, ____gradientType_3)); }
	inline int32_t get__gradientType_3() const { return ____gradientType_3; }
	inline int32_t* get_address_of__gradientType_3() { return &____gradientType_3; }
	inline void set__gradientType_3(int32_t value)
	{
		____gradientType_3 = value;
	}

	inline static int32_t get_offset_of__blendMode_4() { return static_cast<int32_t>(offsetof(Gradient2_t998070926, ____blendMode_4)); }
	inline int32_t get__blendMode_4() const { return ____blendMode_4; }
	inline int32_t* get_address_of__blendMode_4() { return &____blendMode_4; }
	inline void set__blendMode_4(int32_t value)
	{
		____blendMode_4 = value;
	}

	inline static int32_t get_offset_of__offset_5() { return static_cast<int32_t>(offsetof(Gradient2_t998070926, ____offset_5)); }
	inline float get__offset_5() const { return ____offset_5; }
	inline float* get_address_of__offset_5() { return &____offset_5; }
	inline void set__offset_5(float value)
	{
		____offset_5 = value;
	}

	inline static int32_t get_offset_of__effectGradient_6() { return static_cast<int32_t>(offsetof(Gradient2_t998070926, ____effectGradient_6)); }
	inline Gradient_t3600583008 * get__effectGradient_6() const { return ____effectGradient_6; }
	inline Gradient_t3600583008 ** get_address_of__effectGradient_6() { return &____effectGradient_6; }
	inline void set__effectGradient_6(Gradient_t3600583008 * value)
	{
		____effectGradient_6 = value;
		Il2CppCodeGenWriteBarrier(&____effectGradient_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
