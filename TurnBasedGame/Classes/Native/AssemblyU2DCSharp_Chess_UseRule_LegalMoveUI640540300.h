#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3937791418.h"
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

// Chess.UseRule.LegalMoveUI
struct  LegalMoveUI_t640540300  : public UIBehavior_1_t3937791418
{
public:
	// UnityEngine.GameObject Chess.UseRule.LegalMoveUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// UnityEngine.UI.Image Chess.UseRule.LegalMoveUI::imgType
	Image_t2042527209 * ___imgType_7;
	// UnityEngine.Color Chess.UseRule.LegalMoveUI::normalColor
	Color_t2020392075  ___normalColor_8;
	// UnityEngine.Color Chess.UseRule.LegalMoveUI::promotionColor
	Color_t2020392075  ___promotionColor_9;
	// UnityEngine.Color Chess.UseRule.LegalMoveUI::passantColor
	Color_t2020392075  ___passantColor_10;
	// UnityEngine.Color Chess.UseRule.LegalMoveUI::castlingColor
	Color_t2020392075  ___castlingColor_11;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LegalMoveUI_t640540300, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_imgType_7() { return static_cast<int32_t>(offsetof(LegalMoveUI_t640540300, ___imgType_7)); }
	inline Image_t2042527209 * get_imgType_7() const { return ___imgType_7; }
	inline Image_t2042527209 ** get_address_of_imgType_7() { return &___imgType_7; }
	inline void set_imgType_7(Image_t2042527209 * value)
	{
		___imgType_7 = value;
		Il2CppCodeGenWriteBarrier(&___imgType_7, value);
	}

	inline static int32_t get_offset_of_normalColor_8() { return static_cast<int32_t>(offsetof(LegalMoveUI_t640540300, ___normalColor_8)); }
	inline Color_t2020392075  get_normalColor_8() const { return ___normalColor_8; }
	inline Color_t2020392075 * get_address_of_normalColor_8() { return &___normalColor_8; }
	inline void set_normalColor_8(Color_t2020392075  value)
	{
		___normalColor_8 = value;
	}

	inline static int32_t get_offset_of_promotionColor_9() { return static_cast<int32_t>(offsetof(LegalMoveUI_t640540300, ___promotionColor_9)); }
	inline Color_t2020392075  get_promotionColor_9() const { return ___promotionColor_9; }
	inline Color_t2020392075 * get_address_of_promotionColor_9() { return &___promotionColor_9; }
	inline void set_promotionColor_9(Color_t2020392075  value)
	{
		___promotionColor_9 = value;
	}

	inline static int32_t get_offset_of_passantColor_10() { return static_cast<int32_t>(offsetof(LegalMoveUI_t640540300, ___passantColor_10)); }
	inline Color_t2020392075  get_passantColor_10() const { return ___passantColor_10; }
	inline Color_t2020392075 * get_address_of_passantColor_10() { return &___passantColor_10; }
	inline void set_passantColor_10(Color_t2020392075  value)
	{
		___passantColor_10 = value;
	}

	inline static int32_t get_offset_of_castlingColor_11() { return static_cast<int32_t>(offsetof(LegalMoveUI_t640540300, ___castlingColor_11)); }
	inline Color_t2020392075  get_castlingColor_11() const { return ___castlingColor_11; }
	inline Color_t2020392075 * get_address_of_castlingColor_11() { return &___castlingColor_11; }
	inline void set_castlingColor_11(Color_t2020392075  value)
	{
		___castlingColor_11 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
