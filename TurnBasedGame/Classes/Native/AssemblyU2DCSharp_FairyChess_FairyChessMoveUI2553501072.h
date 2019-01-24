#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1753449202.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// UnityEngine.UI.Image
struct Image_t2042527209;
// FairyChess.FairyChessGameDataUI/UIData
struct UIData_t3976046997;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.FairyChessMoveUI
struct  FairyChessMoveUI_t2553501072  : public UIBehavior_1_t1753449202
{
public:
	// UnityEngine.UI.Extensions.UILineRenderer FairyChess.FairyChessMoveUI::lineRenderer
	UILineRenderer_t3031355003 * ___lineRenderer_14;
	// UnityEngine.UI.Image FairyChess.FairyChessMoveUI::imgHint
	Image_t2042527209 * ___imgHint_15;
	// FairyChess.FairyChessGameDataUI/UIData FairyChess.FairyChessMoveUI::fairyChessGameDataUIData
	UIData_t3976046997 * ___fairyChessGameDataUIData_16;

public:
	inline static int32_t get_offset_of_lineRenderer_14() { return static_cast<int32_t>(offsetof(FairyChessMoveUI_t2553501072, ___lineRenderer_14)); }
	inline UILineRenderer_t3031355003 * get_lineRenderer_14() const { return ___lineRenderer_14; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRenderer_14() { return &___lineRenderer_14; }
	inline void set_lineRenderer_14(UILineRenderer_t3031355003 * value)
	{
		___lineRenderer_14 = value;
		Il2CppCodeGenWriteBarrier(&___lineRenderer_14, value);
	}

	inline static int32_t get_offset_of_imgHint_15() { return static_cast<int32_t>(offsetof(FairyChessMoveUI_t2553501072, ___imgHint_15)); }
	inline Image_t2042527209 * get_imgHint_15() const { return ___imgHint_15; }
	inline Image_t2042527209 ** get_address_of_imgHint_15() { return &___imgHint_15; }
	inline void set_imgHint_15(Image_t2042527209 * value)
	{
		___imgHint_15 = value;
		Il2CppCodeGenWriteBarrier(&___imgHint_15, value);
	}

	inline static int32_t get_offset_of_fairyChessGameDataUIData_16() { return static_cast<int32_t>(offsetof(FairyChessMoveUI_t2553501072, ___fairyChessGameDataUIData_16)); }
	inline UIData_t3976046997 * get_fairyChessGameDataUIData_16() const { return ___fairyChessGameDataUIData_16; }
	inline UIData_t3976046997 ** get_address_of_fairyChessGameDataUIData_16() { return &___fairyChessGameDataUIData_16; }
	inline void set_fairyChessGameDataUIData_16(UIData_t3976046997 * value)
	{
		___fairyChessGameDataUIData_16 = value;
		Il2CppCodeGenWriteBarrier(&___fairyChessGameDataUIData_16, value);
	}
};

struct FairyChessMoveUI_t2553501072_StaticFields
{
public:
	// UnityEngine.Color FairyChess.FairyChessMoveUI::NormalColor
	Color_t2020392075  ___NormalColor_8;
	// UnityEngine.Color FairyChess.FairyChessMoveUI::PromotionColor
	Color_t2020392075  ___PromotionColor_9;
	// UnityEngine.Color FairyChess.FairyChessMoveUI::DropColor
	Color_t2020392075  ___DropColor_10;
	// UnityEngine.Color FairyChess.FairyChessMoveUI::hintNormalColor
	Color_t2020392075  ___hintNormalColor_11;
	// UnityEngine.Color FairyChess.FairyChessMoveUI::hintPromotionColor
	Color_t2020392075  ___hintPromotionColor_12;
	// UnityEngine.Color FairyChess.FairyChessMoveUI::hintDropColor
	Color_t2020392075  ___hintDropColor_13;

public:
	inline static int32_t get_offset_of_NormalColor_8() { return static_cast<int32_t>(offsetof(FairyChessMoveUI_t2553501072_StaticFields, ___NormalColor_8)); }
	inline Color_t2020392075  get_NormalColor_8() const { return ___NormalColor_8; }
	inline Color_t2020392075 * get_address_of_NormalColor_8() { return &___NormalColor_8; }
	inline void set_NormalColor_8(Color_t2020392075  value)
	{
		___NormalColor_8 = value;
	}

	inline static int32_t get_offset_of_PromotionColor_9() { return static_cast<int32_t>(offsetof(FairyChessMoveUI_t2553501072_StaticFields, ___PromotionColor_9)); }
	inline Color_t2020392075  get_PromotionColor_9() const { return ___PromotionColor_9; }
	inline Color_t2020392075 * get_address_of_PromotionColor_9() { return &___PromotionColor_9; }
	inline void set_PromotionColor_9(Color_t2020392075  value)
	{
		___PromotionColor_9 = value;
	}

	inline static int32_t get_offset_of_DropColor_10() { return static_cast<int32_t>(offsetof(FairyChessMoveUI_t2553501072_StaticFields, ___DropColor_10)); }
	inline Color_t2020392075  get_DropColor_10() const { return ___DropColor_10; }
	inline Color_t2020392075 * get_address_of_DropColor_10() { return &___DropColor_10; }
	inline void set_DropColor_10(Color_t2020392075  value)
	{
		___DropColor_10 = value;
	}

	inline static int32_t get_offset_of_hintNormalColor_11() { return static_cast<int32_t>(offsetof(FairyChessMoveUI_t2553501072_StaticFields, ___hintNormalColor_11)); }
	inline Color_t2020392075  get_hintNormalColor_11() const { return ___hintNormalColor_11; }
	inline Color_t2020392075 * get_address_of_hintNormalColor_11() { return &___hintNormalColor_11; }
	inline void set_hintNormalColor_11(Color_t2020392075  value)
	{
		___hintNormalColor_11 = value;
	}

	inline static int32_t get_offset_of_hintPromotionColor_12() { return static_cast<int32_t>(offsetof(FairyChessMoveUI_t2553501072_StaticFields, ___hintPromotionColor_12)); }
	inline Color_t2020392075  get_hintPromotionColor_12() const { return ___hintPromotionColor_12; }
	inline Color_t2020392075 * get_address_of_hintPromotionColor_12() { return &___hintPromotionColor_12; }
	inline void set_hintPromotionColor_12(Color_t2020392075  value)
	{
		___hintPromotionColor_12 = value;
	}

	inline static int32_t get_offset_of_hintDropColor_13() { return static_cast<int32_t>(offsetof(FairyChessMoveUI_t2553501072_StaticFields, ___hintDropColor_13)); }
	inline Color_t2020392075  get_hintDropColor_13() const { return ___hintDropColor_13; }
	inline Color_t2020392075 * get_address_of_hintDropColor_13() { return &___hintDropColor_13; }
	inline void set_hintDropColor_13(Color_t2020392075  value)
	{
		___hintDropColor_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
