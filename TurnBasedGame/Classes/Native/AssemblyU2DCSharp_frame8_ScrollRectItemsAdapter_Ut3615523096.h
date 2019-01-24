#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.UI.Graphic
struct Graphic_t2426225576;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.SimpleImageColorBouncer
struct  SimpleImageColorBouncer_t3615523096  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Color frame8.ScrollRectItemsAdapter.Util.SimpleImageColorBouncer::a
	Color_t2020392075  ___a_2;
	// UnityEngine.Color frame8.ScrollRectItemsAdapter.Util.SimpleImageColorBouncer::b
	Color_t2020392075  ___b_3;
	// System.Single frame8.ScrollRectItemsAdapter.Util.SimpleImageColorBouncer::_PeriodInSeconds
	float ____PeriodInSeconds_4;
	// UnityEngine.UI.Graphic frame8.ScrollRectItemsAdapter.Util.SimpleImageColorBouncer::_Graphic
	Graphic_t2426225576 * ____Graphic_5;

public:
	inline static int32_t get_offset_of_a_2() { return static_cast<int32_t>(offsetof(SimpleImageColorBouncer_t3615523096, ___a_2)); }
	inline Color_t2020392075  get_a_2() const { return ___a_2; }
	inline Color_t2020392075 * get_address_of_a_2() { return &___a_2; }
	inline void set_a_2(Color_t2020392075  value)
	{
		___a_2 = value;
	}

	inline static int32_t get_offset_of_b_3() { return static_cast<int32_t>(offsetof(SimpleImageColorBouncer_t3615523096, ___b_3)); }
	inline Color_t2020392075  get_b_3() const { return ___b_3; }
	inline Color_t2020392075 * get_address_of_b_3() { return &___b_3; }
	inline void set_b_3(Color_t2020392075  value)
	{
		___b_3 = value;
	}

	inline static int32_t get_offset_of__PeriodInSeconds_4() { return static_cast<int32_t>(offsetof(SimpleImageColorBouncer_t3615523096, ____PeriodInSeconds_4)); }
	inline float get__PeriodInSeconds_4() const { return ____PeriodInSeconds_4; }
	inline float* get_address_of__PeriodInSeconds_4() { return &____PeriodInSeconds_4; }
	inline void set__PeriodInSeconds_4(float value)
	{
		____PeriodInSeconds_4 = value;
	}

	inline static int32_t get_offset_of__Graphic_5() { return static_cast<int32_t>(offsetof(SimpleImageColorBouncer_t3615523096, ____Graphic_5)); }
	inline Graphic_t2426225576 * get__Graphic_5() const { return ____Graphic_5; }
	inline Graphic_t2426225576 ** get_address_of__Graphic_5() { return &____Graphic_5; }
	inline void set__Graphic_5(Graphic_t2426225576 * value)
	{
		____Graphic_5 = value;
		Il2CppCodeGenWriteBarrier(&____Graphic_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
