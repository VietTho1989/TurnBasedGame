#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2989049970.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// Makruk.MakrukGameDataUI/UIData
struct UIData_t925552405;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Makruk.MakrukMoveUI
struct  MakrukMoveUI_t468248000  : public UIBehavior_1_t2989049970
{
public:
	// UnityEngine.Color Makruk.MakrukMoveUI::normalColor
	Color_t2020392075  ___normalColor_7;
	// UnityEngine.Color Makruk.MakrukMoveUI::hintColor
	Color_t2020392075  ___hintColor_8;
	// UnityEngine.UI.Image Makruk.MakrukMoveUI::imgPromotion
	Image_t2042527209 * ___imgPromotion_9;
	// Makruk.MakrukGameDataUI/UIData Makruk.MakrukMoveUI::makrukGameDataUIData
	UIData_t925552405 * ___makrukGameDataUIData_10;

public:
	inline static int32_t get_offset_of_normalColor_7() { return static_cast<int32_t>(offsetof(MakrukMoveUI_t468248000, ___normalColor_7)); }
	inline Color_t2020392075  get_normalColor_7() const { return ___normalColor_7; }
	inline Color_t2020392075 * get_address_of_normalColor_7() { return &___normalColor_7; }
	inline void set_normalColor_7(Color_t2020392075  value)
	{
		___normalColor_7 = value;
	}

	inline static int32_t get_offset_of_hintColor_8() { return static_cast<int32_t>(offsetof(MakrukMoveUI_t468248000, ___hintColor_8)); }
	inline Color_t2020392075  get_hintColor_8() const { return ___hintColor_8; }
	inline Color_t2020392075 * get_address_of_hintColor_8() { return &___hintColor_8; }
	inline void set_hintColor_8(Color_t2020392075  value)
	{
		___hintColor_8 = value;
	}

	inline static int32_t get_offset_of_imgPromotion_9() { return static_cast<int32_t>(offsetof(MakrukMoveUI_t468248000, ___imgPromotion_9)); }
	inline Image_t2042527209 * get_imgPromotion_9() const { return ___imgPromotion_9; }
	inline Image_t2042527209 ** get_address_of_imgPromotion_9() { return &___imgPromotion_9; }
	inline void set_imgPromotion_9(Image_t2042527209 * value)
	{
		___imgPromotion_9 = value;
		Il2CppCodeGenWriteBarrier(&___imgPromotion_9, value);
	}

	inline static int32_t get_offset_of_makrukGameDataUIData_10() { return static_cast<int32_t>(offsetof(MakrukMoveUI_t468248000, ___makrukGameDataUIData_10)); }
	inline UIData_t925552405 * get_makrukGameDataUIData_10() const { return ___makrukGameDataUIData_10; }
	inline UIData_t925552405 ** get_address_of_makrukGameDataUIData_10() { return &___makrukGameDataUIData_10; }
	inline void set_makrukGameDataUIData_10(UIData_t925552405 * value)
	{
		___makrukGameDataUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___makrukGameDataUIData_10, value);
	}
};

struct MakrukMoveUI_t468248000_StaticFields
{
public:
	// UnityEngine.Vector2 Makruk.MakrukMoveUI::Delta
	Vector2_t2243707579  ___Delta_6;

public:
	inline static int32_t get_offset_of_Delta_6() { return static_cast<int32_t>(offsetof(MakrukMoveUI_t468248000_StaticFields, ___Delta_6)); }
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
