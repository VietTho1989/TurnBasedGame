#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen146229728.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// UnityEngine.UI.Image
struct Image_t2042527209;
// Shogi.ShogiGameDataUI/UIData
struct UIData_t2555805633;
// GameDataBoardCheckPerspectiveChange`1<Shogi.ShogiMoveUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t3401550472;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ShogiMoveUI
struct  ShogiMoveUI_t3235352245  : public UIBehavior_1_t146229728
{
public:
	// UnityEngine.UI.Extensions.UILineRenderer Shogi.ShogiMoveUI::lineRenderer
	UILineRenderer_t3031355003 * ___lineRenderer_14;
	// UnityEngine.UI.Image Shogi.ShogiMoveUI::imgHint
	Image_t2042527209 * ___imgHint_15;
	// Shogi.ShogiGameDataUI/UIData Shogi.ShogiMoveUI::shogiGameDataUIData
	UIData_t2555805633 * ___shogiGameDataUIData_16;
	// GameDataBoardCheckPerspectiveChange`1<Shogi.ShogiMoveUI/UIData> Shogi.ShogiMoveUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t3401550472 * ___perspectiveChange_17;

public:
	inline static int32_t get_offset_of_lineRenderer_14() { return static_cast<int32_t>(offsetof(ShogiMoveUI_t3235352245, ___lineRenderer_14)); }
	inline UILineRenderer_t3031355003 * get_lineRenderer_14() const { return ___lineRenderer_14; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRenderer_14() { return &___lineRenderer_14; }
	inline void set_lineRenderer_14(UILineRenderer_t3031355003 * value)
	{
		___lineRenderer_14 = value;
		Il2CppCodeGenWriteBarrier(&___lineRenderer_14, value);
	}

	inline static int32_t get_offset_of_imgHint_15() { return static_cast<int32_t>(offsetof(ShogiMoveUI_t3235352245, ___imgHint_15)); }
	inline Image_t2042527209 * get_imgHint_15() const { return ___imgHint_15; }
	inline Image_t2042527209 ** get_address_of_imgHint_15() { return &___imgHint_15; }
	inline void set_imgHint_15(Image_t2042527209 * value)
	{
		___imgHint_15 = value;
		Il2CppCodeGenWriteBarrier(&___imgHint_15, value);
	}

	inline static int32_t get_offset_of_shogiGameDataUIData_16() { return static_cast<int32_t>(offsetof(ShogiMoveUI_t3235352245, ___shogiGameDataUIData_16)); }
	inline UIData_t2555805633 * get_shogiGameDataUIData_16() const { return ___shogiGameDataUIData_16; }
	inline UIData_t2555805633 ** get_address_of_shogiGameDataUIData_16() { return &___shogiGameDataUIData_16; }
	inline void set_shogiGameDataUIData_16(UIData_t2555805633 * value)
	{
		___shogiGameDataUIData_16 = value;
		Il2CppCodeGenWriteBarrier(&___shogiGameDataUIData_16, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_17() { return static_cast<int32_t>(offsetof(ShogiMoveUI_t3235352245, ___perspectiveChange_17)); }
	inline GameDataBoardCheckPerspectiveChange_1_t3401550472 * get_perspectiveChange_17() const { return ___perspectiveChange_17; }
	inline GameDataBoardCheckPerspectiveChange_1_t3401550472 ** get_address_of_perspectiveChange_17() { return &___perspectiveChange_17; }
	inline void set_perspectiveChange_17(GameDataBoardCheckPerspectiveChange_1_t3401550472 * value)
	{
		___perspectiveChange_17 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_17, value);
	}
};

struct ShogiMoveUI_t3235352245_StaticFields
{
public:
	// UnityEngine.Color Shogi.ShogiMoveUI::NormalColor
	Color_t2020392075  ___NormalColor_8;
	// UnityEngine.Color Shogi.ShogiMoveUI::PromotionColor
	Color_t2020392075  ___PromotionColor_9;
	// UnityEngine.Color Shogi.ShogiMoveUI::DropColor
	Color_t2020392075  ___DropColor_10;
	// UnityEngine.Color Shogi.ShogiMoveUI::hintNormalColor
	Color_t2020392075  ___hintNormalColor_11;
	// UnityEngine.Color Shogi.ShogiMoveUI::hintPromotionColor
	Color_t2020392075  ___hintPromotionColor_12;
	// UnityEngine.Color Shogi.ShogiMoveUI::hintDropColor
	Color_t2020392075  ___hintDropColor_13;

public:
	inline static int32_t get_offset_of_NormalColor_8() { return static_cast<int32_t>(offsetof(ShogiMoveUI_t3235352245_StaticFields, ___NormalColor_8)); }
	inline Color_t2020392075  get_NormalColor_8() const { return ___NormalColor_8; }
	inline Color_t2020392075 * get_address_of_NormalColor_8() { return &___NormalColor_8; }
	inline void set_NormalColor_8(Color_t2020392075  value)
	{
		___NormalColor_8 = value;
	}

	inline static int32_t get_offset_of_PromotionColor_9() { return static_cast<int32_t>(offsetof(ShogiMoveUI_t3235352245_StaticFields, ___PromotionColor_9)); }
	inline Color_t2020392075  get_PromotionColor_9() const { return ___PromotionColor_9; }
	inline Color_t2020392075 * get_address_of_PromotionColor_9() { return &___PromotionColor_9; }
	inline void set_PromotionColor_9(Color_t2020392075  value)
	{
		___PromotionColor_9 = value;
	}

	inline static int32_t get_offset_of_DropColor_10() { return static_cast<int32_t>(offsetof(ShogiMoveUI_t3235352245_StaticFields, ___DropColor_10)); }
	inline Color_t2020392075  get_DropColor_10() const { return ___DropColor_10; }
	inline Color_t2020392075 * get_address_of_DropColor_10() { return &___DropColor_10; }
	inline void set_DropColor_10(Color_t2020392075  value)
	{
		___DropColor_10 = value;
	}

	inline static int32_t get_offset_of_hintNormalColor_11() { return static_cast<int32_t>(offsetof(ShogiMoveUI_t3235352245_StaticFields, ___hintNormalColor_11)); }
	inline Color_t2020392075  get_hintNormalColor_11() const { return ___hintNormalColor_11; }
	inline Color_t2020392075 * get_address_of_hintNormalColor_11() { return &___hintNormalColor_11; }
	inline void set_hintNormalColor_11(Color_t2020392075  value)
	{
		___hintNormalColor_11 = value;
	}

	inline static int32_t get_offset_of_hintPromotionColor_12() { return static_cast<int32_t>(offsetof(ShogiMoveUI_t3235352245_StaticFields, ___hintPromotionColor_12)); }
	inline Color_t2020392075  get_hintPromotionColor_12() const { return ___hintPromotionColor_12; }
	inline Color_t2020392075 * get_address_of_hintPromotionColor_12() { return &___hintPromotionColor_12; }
	inline void set_hintPromotionColor_12(Color_t2020392075  value)
	{
		___hintPromotionColor_12 = value;
	}

	inline static int32_t get_offset_of_hintDropColor_13() { return static_cast<int32_t>(offsetof(ShogiMoveUI_t3235352245_StaticFields, ___hintDropColor_13)); }
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
