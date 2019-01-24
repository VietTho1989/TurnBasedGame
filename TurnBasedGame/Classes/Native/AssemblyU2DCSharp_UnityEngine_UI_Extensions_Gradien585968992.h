#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UI_UnityEngine_UI_BaseMeshEffect1728560551.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_Gradie1452379243.h"
#include "AssemblyU2DCSharp_UnityEngine_UI_Extensions_Gradie2268096981.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.UI.Graphic
struct Graphic_t2426225576;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.Gradient
struct  Gradient_t585968992  : public BaseMeshEffect_t1728560551
{
public:
	// UnityEngine.UI.Extensions.GradientMode UnityEngine.UI.Extensions.Gradient::gradientMode
	int32_t ___gradientMode_3;
	// UnityEngine.UI.Extensions.GradientDir UnityEngine.UI.Extensions.Gradient::gradientDir
	int32_t ___gradientDir_4;
	// System.Boolean UnityEngine.UI.Extensions.Gradient::overwriteAllColor
	bool ___overwriteAllColor_5;
	// UnityEngine.Color UnityEngine.UI.Extensions.Gradient::vertex1
	Color_t2020392075  ___vertex1_6;
	// UnityEngine.Color UnityEngine.UI.Extensions.Gradient::vertex2
	Color_t2020392075  ___vertex2_7;
	// UnityEngine.UI.Graphic UnityEngine.UI.Extensions.Gradient::targetGraphic
	Graphic_t2426225576 * ___targetGraphic_8;

public:
	inline static int32_t get_offset_of_gradientMode_3() { return static_cast<int32_t>(offsetof(Gradient_t585968992, ___gradientMode_3)); }
	inline int32_t get_gradientMode_3() const { return ___gradientMode_3; }
	inline int32_t* get_address_of_gradientMode_3() { return &___gradientMode_3; }
	inline void set_gradientMode_3(int32_t value)
	{
		___gradientMode_3 = value;
	}

	inline static int32_t get_offset_of_gradientDir_4() { return static_cast<int32_t>(offsetof(Gradient_t585968992, ___gradientDir_4)); }
	inline int32_t get_gradientDir_4() const { return ___gradientDir_4; }
	inline int32_t* get_address_of_gradientDir_4() { return &___gradientDir_4; }
	inline void set_gradientDir_4(int32_t value)
	{
		___gradientDir_4 = value;
	}

	inline static int32_t get_offset_of_overwriteAllColor_5() { return static_cast<int32_t>(offsetof(Gradient_t585968992, ___overwriteAllColor_5)); }
	inline bool get_overwriteAllColor_5() const { return ___overwriteAllColor_5; }
	inline bool* get_address_of_overwriteAllColor_5() { return &___overwriteAllColor_5; }
	inline void set_overwriteAllColor_5(bool value)
	{
		___overwriteAllColor_5 = value;
	}

	inline static int32_t get_offset_of_vertex1_6() { return static_cast<int32_t>(offsetof(Gradient_t585968992, ___vertex1_6)); }
	inline Color_t2020392075  get_vertex1_6() const { return ___vertex1_6; }
	inline Color_t2020392075 * get_address_of_vertex1_6() { return &___vertex1_6; }
	inline void set_vertex1_6(Color_t2020392075  value)
	{
		___vertex1_6 = value;
	}

	inline static int32_t get_offset_of_vertex2_7() { return static_cast<int32_t>(offsetof(Gradient_t585968992, ___vertex2_7)); }
	inline Color_t2020392075  get_vertex2_7() const { return ___vertex2_7; }
	inline Color_t2020392075 * get_address_of_vertex2_7() { return &___vertex2_7; }
	inline void set_vertex2_7(Color_t2020392075  value)
	{
		___vertex2_7 = value;
	}

	inline static int32_t get_offset_of_targetGraphic_8() { return static_cast<int32_t>(offsetof(Gradient_t585968992, ___targetGraphic_8)); }
	inline Graphic_t2426225576 * get_targetGraphic_8() const { return ___targetGraphic_8; }
	inline Graphic_t2426225576 ** get_address_of_targetGraphic_8() { return &___targetGraphic_8; }
	inline void set_targetGraphic_8(Graphic_t2426225576 * value)
	{
		___targetGraphic_8 = value;
		Il2CppCodeGenWriteBarrier(&___targetGraphic_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
