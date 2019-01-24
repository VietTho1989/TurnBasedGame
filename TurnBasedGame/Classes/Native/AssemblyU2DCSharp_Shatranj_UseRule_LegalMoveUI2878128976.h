#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2799141527.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Image
struct Image_t2042527209;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.UseRule.LegalMoveUI
struct  LegalMoveUI_t2878128976  : public UIBehavior_1_t2799141527
{
public:
	// UnityEngine.GameObject Shatranj.UseRule.LegalMoveUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// UnityEngine.UI.Image Shatranj.UseRule.LegalMoveUI::imgType
	Image_t2042527209 * ___imgType_7;
	// UnityEngine.Color Shatranj.UseRule.LegalMoveUI::normalColor
	Color_t2020392075  ___normalColor_8;
	// UnityEngine.Color Shatranj.UseRule.LegalMoveUI::promotionColor
	Color_t2020392075  ___promotionColor_9;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LegalMoveUI_t2878128976, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_imgType_7() { return static_cast<int32_t>(offsetof(LegalMoveUI_t2878128976, ___imgType_7)); }
	inline Image_t2042527209 * get_imgType_7() const { return ___imgType_7; }
	inline Image_t2042527209 ** get_address_of_imgType_7() { return &___imgType_7; }
	inline void set_imgType_7(Image_t2042527209 * value)
	{
		___imgType_7 = value;
		Il2CppCodeGenWriteBarrier(&___imgType_7, value);
	}

	inline static int32_t get_offset_of_normalColor_8() { return static_cast<int32_t>(offsetof(LegalMoveUI_t2878128976, ___normalColor_8)); }
	inline Color_t2020392075  get_normalColor_8() const { return ___normalColor_8; }
	inline Color_t2020392075 * get_address_of_normalColor_8() { return &___normalColor_8; }
	inline void set_normalColor_8(Color_t2020392075  value)
	{
		___normalColor_8 = value;
	}

	inline static int32_t get_offset_of_promotionColor_9() { return static_cast<int32_t>(offsetof(LegalMoveUI_t2878128976, ___promotionColor_9)); }
	inline Color_t2020392075  get_promotionColor_9() const { return ___promotionColor_9; }
	inline Color_t2020392075 * get_address_of_promotionColor_9() { return &___promotionColor_9; }
	inline void set_promotionColor_9(Color_t2020392075  value)
	{
		___promotionColor_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
