#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4166792544.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.CoTuongUpMoveUI
struct  CoTuongUpMoveUI_t2314359049  : public UIBehavior_1_t4166792544
{
public:
	// UnityEngine.Color CoTuongUp.CoTuongUpMoveUI::normalColor
	Color_t2020392075  ___normalColor_7;
	// UnityEngine.Color CoTuongUp.CoTuongUpMoveUI::hintColor
	Color_t2020392075  ___hintColor_8;
	// UnityEngine.UI.Extensions.UILineRenderer CoTuongUp.CoTuongUpMoveUI::lineRenderer
	UILineRenderer_t3031355003 * ___lineRenderer_9;

public:
	inline static int32_t get_offset_of_normalColor_7() { return static_cast<int32_t>(offsetof(CoTuongUpMoveUI_t2314359049, ___normalColor_7)); }
	inline Color_t2020392075  get_normalColor_7() const { return ___normalColor_7; }
	inline Color_t2020392075 * get_address_of_normalColor_7() { return &___normalColor_7; }
	inline void set_normalColor_7(Color_t2020392075  value)
	{
		___normalColor_7 = value;
	}

	inline static int32_t get_offset_of_hintColor_8() { return static_cast<int32_t>(offsetof(CoTuongUpMoveUI_t2314359049, ___hintColor_8)); }
	inline Color_t2020392075  get_hintColor_8() const { return ___hintColor_8; }
	inline Color_t2020392075 * get_address_of_hintColor_8() { return &___hintColor_8; }
	inline void set_hintColor_8(Color_t2020392075  value)
	{
		___hintColor_8 = value;
	}

	inline static int32_t get_offset_of_lineRenderer_9() { return static_cast<int32_t>(offsetof(CoTuongUpMoveUI_t2314359049, ___lineRenderer_9)); }
	inline UILineRenderer_t3031355003 * get_lineRenderer_9() const { return ___lineRenderer_9; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRenderer_9() { return &___lineRenderer_9; }
	inline void set_lineRenderer_9(UILineRenderer_t3031355003 * value)
	{
		___lineRenderer_9 = value;
		Il2CppCodeGenWriteBarrier(&___lineRenderer_9, value);
	}
};

struct CoTuongUpMoveUI_t2314359049_StaticFields
{
public:
	// UnityEngine.Vector2 CoTuongUp.CoTuongUpMoveUI::Delta
	Vector2_t2243707579  ___Delta_6;

public:
	inline static int32_t get_offset_of_Delta_6() { return static_cast<int32_t>(offsetof(CoTuongUpMoveUI_t2314359049_StaticFields, ___Delta_6)); }
	inline Vector2_t2243707579  get_Delta_6() const { return ___Delta_6; }
	inline Vector2_t2243707579 * get_address_of_Delta_6() { return &___Delta_6; }
	inline void set_Delta_6(Vector2_t2243707579  value)
	{
		___Delta_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
